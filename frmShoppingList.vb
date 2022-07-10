
Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Collections.Specialized
Imports Newtonsoft.Json

Public Class frmShoppingList

    ' Inline grid row update variables
    Private Structure SavedLoc
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Private SavedListClickLoc As SavedLoc
    Private RefreshingGrid As Boolean
    Private CutPasteUpdate As Boolean

    Private CurrentRow As ListViewItem
    Private PreviousRow As ListViewItem
    Private NextRow As ListViewItem

    Private NextCellRow As ListViewItem
    Private PreviousCellRow As ListViewItem

    Private CurrentCell As ListViewItem.ListViewSubItem
    Private PreviousCell As ListViewItem.ListViewSubItem
    Private NextCell As ListViewItem.ListViewSubItem

    Private UpdateQuantity As Boolean
    Private UpdatePrice As Boolean
    Private DataEntered As Boolean
    Private IgnoreFocusChange As Boolean
    Private SelectedGrid As ListView

    Private ItemListColumnClicked As Integer
    Private ItemListColumnSortOrder As SortOrder
    Private BuyListColumnClicked As Integer
    Private BuyListColumnSortOrder As SortOrder
    Private BuildListColumnClicked As Integer
    Private BuildListColumnSortOrder As SortOrder

    Public Shared ItemBuyTypeList As List(Of ItemBuyType)

    Private Const BuyListLabel As String = "Buy List"
    Private Const BuildListLabel As String = "Build List"
    Private Const ItemsListLabel As String = "Item List"

    ' To use for copy and pasting data from the game into IPH
    Public CopyPasteMaterialText As String

    ' For finding structure in import lists
    Private ItemQuantityToFind As ItemQuantity
    Private BuildQuantityToFind As BuildQuantity
    Private FacilityToFind As IndustryFacility

    Private BuyListHeaderCSV As String = "Material,Quantity,Cost Per Item,Min Sell,Max Buy,Buy Type,Total m3,Isk/m3,TotalCost"
    Private BuildListHeaderCSV As String = "Build Item,Quantity,ME"
    Private BuildListHeaderCSVAdd As String = ",TE,Facility Location,Facility Type,IncludeActivityCost,IncludeActivityTime,IncludeUsageCost,Facility Build Type"
    Private ItemsListHeaderCSV As String = "Item,Quantity,ME,NumBps,Build Type,Decryptor,Relic"
    Private ItemsListHeaderCSVAdd As String = ",Facility Type,Location,IgnoredInvention,IgnoredMinerals,IgnoredT1BaseItem,IncludeActivityCost,IncludeActivityTime,IncludeUsageCost,Facility Build Type"

    Private BuyListHeaderTXT As String = "Material|Quantity|Cost Per Item|Min Sell|Max Buy|Buy Type|Total m3|Isk/m3|TotalCost"
    Private BuildListHeaderTXT As String = "Build Item|Quantity|ME"
    Private BuildListHeaderTXTAdd As String = "|TE|Facility Location|Facility Type|IncludeActivityCost|IncludeActivityTime|IncludeUsageCost|Facility Build Type"
    Private ItemsListHeaderTXT As String = "Item|Quantity|ME|NumBps|Build Type|Decryptor|Relic"
    Private ItemsListHeaderTXTAdd As String = "|Facility Type|Location|IgnoredInvention|IgnoredMinerals|IgnoredT1BaseItem|IncludeActivityCost|IncludeActivityTime|IncludeUsageCost|Facility Build Type"

    Private BuyListHeaderSSV As String = "Material;Quantity;Cost Per Item;Min Sell;Max Buy;Buy Type;Total m3;Isk/m3;TotalCost"
    Private BuildListHeaderSSV As String = "Build Item;Quantity;ME"
    Private BuildListHeaderSSVAdd As String = ";TE;Facility Location; Facility Type;IncludeActivityCost;IncludeActivityTime;IncludeUsageCost;Facility Build Type"
    Private ItemsListHeaderSSV As String = "Item;Quantity;ME;NumBps;Build Type;Decryptor;Relic"
    Private ItemsListHeaderSSVAdd As String = ";Facility Type;Location;IgnoredInvention;IgnoredMinerals;IgnoredT1BaseItem;IncludeActivityCost;IncludeActivityTime;IncludeUsageCost;Facility Build Type"

    Private FirstFormLoad As Boolean

    Private Structure ItemQuantity
        Dim ItemName As String
        Dim ItemQuantity As Long
        Dim ItemME As Integer
    End Structure

    Private Structure BuildQuantity
        Dim ItemName As String
        Dim ItemQuantity As Long
        Dim ItemME As Integer
        Dim ItemTE As Integer
        Dim FacilityType As String
        Dim FacilityBuildType As ProductionType
        Dim FacilityLocation As String
        Dim IncludeActivityUsage As Boolean
        Dim IncludeActivityCost As Boolean
        Dim IncludeActivityTime As Boolean
    End Structure

    ' Predicate for finding the item in full list
    Private Function FindItemQuantity(ByVal Item As ItemQuantity) As Boolean
        If Item.ItemName = ItemQuantityToFind.ItemName Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Predicate for finding the item in full list
    Private Function FindBuildQuantity(ByVal Item As BuildQuantity) As Boolean
        If Item.ItemName = BuildQuantityToFind.ItemName Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Structure BPItem
        'Item List Format: Item, Quantity, ME, NumBPs Build Type, Decryptor, Relic (in file, in grid it is put with item name)
        Dim ItemName As String
        Dim ItemQuantity As Long
        Dim ItemME As Integer
        Dim NumBPs As Integer
        Dim BuildType As String
        Dim Decryptor As String
        Dim Relic As String
        Dim BuildLocation As String
        Dim FacilityType As String
        Dim FacilityBuildType As ProductionType
        Dim IgnoredInvention As Boolean
        Dim IgnoredMinerals As Boolean
        Dim IgnoredT1BaseItem As Boolean
        Dim IncludeActivityCost As Boolean
        Dim IncludeActivityTime As Boolean
        Dim IncludeActivityUsage As Boolean
    End Structure

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Item Buy List - width = 1081 (21 width for verticle scroll bar)
        lstBuy.Columns.Add("TypeID", 0, HorizontalAlignment.Left) ' Hidden
        lstBuy.Columns.Add("Material", 245, HorizontalAlignment.Left)
        lstBuy.Columns.Add("Quantity", 94, HorizontalAlignment.Right) ' Min 94
        lstBuy.Columns.Add("Cost per Item", 0, HorizontalAlignment.Right) ' Min 90
        lstBuy.Columns.Add("Min Sell", 0, HorizontalAlignment.Right) ' Min 90
        lstBuy.Columns.Add("Max Buy", 0, HorizontalAlignment.Right) ' Min 90
        lstBuy.Columns.Add("Buy Type", 66, HorizontalAlignment.Right) ' Min 66
        lstBuy.Columns.Add("Total m3", 100, HorizontalAlignment.Right) ' Min 100
        lstBuy.Columns.Add("Isk/m3", 83, HorizontalAlignment.Right) ' Min 85
        lstBuy.Columns.Add("Fees", 0, HorizontalAlignment.Right)
        lstBuy.Columns.Add("Total Cost", 112, HorizontalAlignment.Right) ' Min 129

        ' Item List - What we are building - width = 711 (21 for verticle scroll bar)
        lstItems.Columns.Add("TypeID", 0, HorizontalAlignment.Center) ' always left allignment this column for some reason, so add a dummy, store bpID here though
        lstItems.Columns.Add("Item", 225, HorizontalAlignment.Left) ' 
        lstItems.Columns.Add("Quantity", 67, HorizontalAlignment.Right) ' 51 min text
        lstItems.Columns.Add("ME", 0, HorizontalAlignment.Right) ' 30 min text
        lstItems.Columns.Add("Num BPs", 0, HorizontalAlignment.Left) ' 60 min text
        lstItems.Columns.Add("Build Type", 0, HorizontalAlignment.Left) ' 71 min text
        lstItems.Columns.Add("Decryptor", 0, HorizontalAlignment.Left) '105 min text
        lstItems.Columns.Add("Location", 0, HorizontalAlignment.Left) '132 min text
        lstItems.Columns.Add("Facility Type", 0, HorizontalAlignment.Left) 'Hidden flag
        lstItems.Columns.Add("IgnoredInvention", 0, HorizontalAlignment.Left) 'Hidden flag for ignore variables
        lstItems.Columns.Add("IgnoredMinerals", 0, HorizontalAlignment.Left) 'Hidden flag for ignore variables
        lstItems.Columns.Add("IgnoredT1BaseItem", 0, HorizontalAlignment.Left) 'Hidden flag for ignore variables
        lstItems.Columns.Add("IncludeActivityCost", 0, HorizontalAlignment.Left) 'Hidden flag for ignore variables
        lstItems.Columns.Add("IncludeActivityTime", 0, HorizontalAlignment.Left) 'Hidden flag for ignore variables
        lstItems.Columns.Add("IncludeActivityUsage", 0, HorizontalAlignment.Left) 'Hidden flag for ignore variables
        lstItems.Columns.Add("TE", 0, HorizontalAlignment.Right) ' Hidden
        lstItems.Columns.Add("Facility Build type", 0, HorizontalAlignment.Center) ' Hidden for saving

        IgnoreFocusChange = False

        btnCopy.Enabled = False

        ItemListColumnClicked = 0
        ItemListColumnSortOrder = SortOrder.None
        BuyListColumnClicked = 0
        BuyListColumnSortOrder = SortOrder.None
        BuildListColumnClicked = 0
        BuildListColumnSortOrder = SortOrder.None

        CutPasteUpdate = False

        FirstFormLoad = True

        CopyPasteMaterialText = ""

        UserShoppingListSettings = AllSettings.LoadShoppingListSettings

    End Sub

    Public Sub RefreshLists()
        RefreshingGrid = True
        Call LoadBuyList()
        Call LoadItemList()
        Call LoadFormStats()

        ' Enable the buttons if there are rows
        If lstItems.Items.Count > 0 Then
            btnCopy.Enabled = True
        Else
            btnCopy.Enabled = False
            ' No more items so clear lists
            Call ClearLists()
        End If

        RefreshingGrid = False
    End Sub

    Private Sub ClearLists()
        ' Reset global list
        TotalShoppingList.Clear()

        lstItems.Items.Clear()
        lstBuy.Items.Clear()

        lstItems.Update()
        lstBuy.Update()

        lblTotalProfit.Text = "0.00 ISK"
        lblAvgIPH.Text = "0.00 ISK"

        btnCopy.Enabled = False

        Me.Refresh()

    End Sub

    ' Loads all the main items we want to buy into the main table
    Private Sub LoadBuyList()
        Dim RawmatList As ListViewItem
        Dim RawItems As New Materials

        Dim SQL As String
        Dim readerItemPrices As SQLiteDataReader

        Dim BuyOrderText As String
        Dim SellPrice As Double
        Dim BuyOrderPrice As Double
        Dim BuyOrderFees As Double
        Dim TotalPrice As Double
        Dim PriceType As String
        Dim StoredPrice As Double
        Dim MinSellUnitPrice As Double
        Dim MaxBuyUnitPrice As Double

        Const BuyOrder As String = "Buy Order"
        Const BuyMarket As String = "Buy Market"
        Const Unknown As String = "Unknown"

        lstBuy.Items.Clear()
        lstBuy.BeginUpdate()

        ' Get the list of items
        RawItems = TotalShoppingList.GetFullBuyList

        ' Reset buy type list
        ItemBuyTypeList = New List(Of ItemBuyType)

        ' Set to 0 first
        lblTotalProfit.Text = "0.00 ISK"
        lblAvgIPH.Text = "0.00 ISK"

        If Not IsNothing(RawItems) Then
            If Not IsNothing(RawItems.GetMaterialList) Then

                ' Sort the list of mats
                RawItems.SortMaterialListByQuantity()

                ' Fill Component List
                For i = 0 To RawItems.GetMaterialList.Count - 1
                    ' Reset
                    BuyOrderText = Unknown

                    RawmatList = New ListViewItem(CStr(RawItems.GetMaterialList(i).GetMaterialTypeID)) ' Hidden
                    'The remaining columns are subitems  
                    RawmatList.SubItems.Add(RawItems.GetMaterialList(i).GetMaterialName)
                    RawmatList.SubItems.Add(FormatNumber(RawItems.GetMaterialList(i).GetQuantity, 0))
                    RawmatList.SubItems.Add(FormatNumber(RawItems.GetMaterialList(i).GetCostPerItem, 2)) ' Cost per item (as the user has it stored)

                    ' Look up the price of buying directly off the market (min sell - no tax, no broker fee) and compare it to the price
                    ' of max buy (buy order) plus the brokers fees to set up that order (no tax). Then show the value in the grid of what they should do
                    ' First find out what price and type we have stored
                    SQL = "SELECT PRICE, PRICE_TYPE FROM ITEM_PRICES WHERE ITEM_ID = " & RawItems.GetMaterialList(i).GetMaterialTypeID
                    DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                    readerItemPrices = DBCommand.ExecuteReader
                    readerItemPrices.Read()

                    If readerItemPrices.HasRows Then
                        ' Figure out what they have stored so we know what type of price we need to get
                        StoredPrice = CDbl(readerItemPrices.GetValue(0))
                        PriceType = readerItemPrices.GetString(1)
                    Else
                        PriceType = None
                    End If

                    readerItemPrices.Close()

                    ' Load the Min Sell and Max Buy prices from cache
                    SQL = "SELECT sellMin, buyMax FROM ITEM_PRICES_CACHE WHERE typeID = " & RawItems.GetMaterialList(i).GetMaterialTypeID
                    SQL = SQL & " AND sellMin IS NOT NULL and buyMax IS NOT NULL"
                    DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                    readerItemPrices = DBCommand.ExecuteReader
                    readerItemPrices.Read()

                    ' Get the buy and sell prices
                    If readerItemPrices.HasRows Then
                        MinSellUnitPrice = CDbl(readerItemPrices.GetValue(0))
                        MaxBuyUnitPrice = CDbl(readerItemPrices.GetValue(1))
                    Else
                        ' Something went wrong, so re-mark as none
                        PriceType = None
                    End If

                    readerItemPrices.Close()

                    'Calucate buy order fees
                    If MaxBuyUnitPrice <> 0 Then
                        BuyOrderFees = GetSalesBrokerFee(MaxBuyUnitPrice * RawItems.GetMaterialList(i).GetQuantity, GetBrokerFeeData())
                    Else
                        BuyOrderFees = 0
                    End If

                    ' Now that we have the prices, compare the two
                    If MinSellUnitPrice <> 0 And MaxBuyUnitPrice <> 0 Then

                        ' Now look at max buy
                        TotalPrice = MaxBuyUnitPrice * RawItems.GetMaterialList(i).GetQuantity
                        BuyOrderPrice = TotalPrice + BuyOrderFees

                        ' Use min sell
                        SellPrice = MinSellUnitPrice * RawItems.GetMaterialList(i).GetQuantity

                        If BuyOrderPrice < SellPrice Then
                            ' They should do an order
                            BuyOrderText = BuyOrder
                        Else
                            ' Buy from the Market
                            BuyOrderText = BuyMarket
                            ' No fees straight off market
                            BuyOrderFees = 0
                        End If
                    Else
                        BuyOrderText = Unknown
                        BuyOrderFees = 0
                    End If

                    ' Add the minsell/maxbuy for reference
                    RawmatList.SubItems.Add(FormatNumber(MinSellUnitPrice, 2))
                    RawmatList.SubItems.Add(FormatNumber(MaxBuyUnitPrice, 2))

                    ' Finally Add the correct column value for how to buy it
                    RawmatList.SubItems.Add(BuyOrderText) ' Buy or Buy Market flag

                    ' Add this item to the list
                    Dim Temp As ItemBuyType
                    Temp.ItemName = RawItems.GetMaterialList(i).GetMaterialName
                    Temp.BuyType = BuyOrderText
                    ItemBuyTypeList.Add(Temp)

                    RawmatList.SubItems.Add(FormatNumber(RawItems.GetMaterialList(i).GetTotalVolume, 2)) ' Volume

                    If RawItems.GetMaterialList(i).GetTotalVolume <> 0 Then
                        RawmatList.SubItems.Add(FormatNumber(RawItems.GetMaterialList(i).GetTotalCost / RawItems.GetMaterialList(i).GetTotalVolume, 2)) ' Isk per m3
                    Else
                        RawmatList.SubItems.Add("0.00") ' Isk per m3
                    End If

                    RawmatList.SubItems.Add(FormatNumber(BuyOrderFees, 2)) ' Fees for buy orders
                    RawmatList.SubItems.Add(FormatNumber(RawItems.GetMaterialList(i).GetTotalCost + BuyOrderFees, 2)) ' Total Cost

                    Call lstBuy.Items.Add(RawmatList)
                Next

            End If
        End If

        ' Finally sort it if there is a value it's already sorted
        'Call ListViewColumnSorter(ItemListColumnClicked, CType(lstItems, ListView), ItemListColumnClicked, ItemListColumnSortOrder)

        lstBuy.EndUpdate()

    End Sub

    ' Loads the list of items into the items list
    Private Sub LoadItemList()
        Dim lstItem As ListViewItem
        Dim ItemList As List(Of ShoppingListItem)

        lstItems.BeginUpdate()
        lstItems.Items.Clear()

        ItemList = TotalShoppingList.GetFullShoppingList()

        ' Loop through the list and display all items
        For i = 0 To ItemList.Count - 1
            With ItemList(i)
                lstItem = lstItems.Items.Add(CStr(.TypeID)) ' Hidden
                If .TechLevel <> 3 Then
                    lstItem.SubItems.Add(ItemList(i).Name)
                Else
                    lstItem.SubItems.Add(ItemList(i).Name & " (" & "" & ")") ' Add relic name after the item
                End If
                lstItem.SubItems.Add(CStr(FormatNumber(ItemList(i).Runs, 0)))
                lstItem.SubItems.Add(CStr(ItemList(i).ItemME))
                lstItem.SubItems.Add(CStr(ItemList(i).NumBPs))
                lstItem.SubItems.Add(ItemList(i).BuildType)
                lstItem.SubItems.Add(ItemList(i).ManufacturingFacility.FacilityName)
                lstItem.SubItems.Add(CStr(ItemList(i).ManufacturingFacility.FacilityType))
                lstItem.SubItems.Add(CStr(ItemList(i).IgnoredInvention))
                lstItem.SubItems.Add(CStr(ItemList(i).IgnoredMinerals))
                lstItem.SubItems.Add(CStr(ItemList(i).IgnoredT1BaseItem))
                lstItem.SubItems.Add(CStr(ItemList(i).IncludeActivityCost))
                lstItem.SubItems.Add(CStr(ItemList(i).IncludeActivityTime))
                lstItem.SubItems.Add(CStr(ItemList(i).IncludeActivityUsage))
                lstItem.SubItems.Add(CStr(ItemList(i).ItemTE))
                lstItem.SubItems.Add(CStr(ItemList(i).ManufacturingFacility.FacilityProductionType))
            End With
        Next

        ' Add the number of item(s) to the label on the shopping list
        Dim ItemCount As Integer = ItemList.Count

        lstItems.EndUpdate()

    End Sub

    ' Loads up the IPH, profit, etc
    Private Sub LoadFormStats()

        If TotalShoppingList.GetNumShoppingItems <> 0 Then

            Dim BFI As BrokerFeeInfo = GetBrokerFeeData()

            Call TotalShoppingList.SetPriceData(BFI, True, ItemBuyTypeList)

            lblTotalProfit.Text = FormatNumber(TotalShoppingList.GetTotalProfit(), 2) & " ISK"
            lblAvgIPH.Text = FormatNumber(TotalShoppingList.GetTotalIPH(), 2) & " ISK"

        End If

    End Sub

    ' Clears the lists and variables
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MsgBox("Delete all items in the shopping list?", CType(vbYesNo + vbQuestion, MsgBoxStyle), Application.ProductName) = vbYes Then
            Call ClearLists()
            Call PlayNotifySound()
        End If

    End Sub

    ' Save the few settings on the form to xml
    Public Sub saveSettings()
        Dim TempList As ShoppingListSettings = Nothing
        Dim TempSettings As New ProgramSettings

        TempList.UpdateAssetsWhenUsed = False
        TempList.Usage = True
        TempList.Fees = True

        TempList.CalcBuyBuyOrder = 1

        TempList.ReloadBPsFromFile = False

        ' Save the data in the XML file
        Call TempSettings.SaveShoppingListSettings(TempList)

        Application.UseWaitCursor = False

    End Sub

    ' Save the lists to file 
    Private Sub btnSaveListToFile_Click(sender As System.Object, e As System.EventArgs)
        Dim MyStream As StreamWriter
        Dim FileName As String
        Dim OutputText As String
        Dim ListItem As ListViewItem

        Dim Items As ListView.ListViewItemCollection
        Dim i As Integer = 0

        ' Show the dialog
        Dim ExportTypeString As String
        Dim BuyListHeader As String
        Dim BuildListHeader As String
        Dim ItemsListHeader As String
        Dim Separator As String

        ' Save file name with date
        FileName = "Shopping List - " & Format(Now, "MMddyyyy") & ".txt"
        ExportTypeString = DefaultTextDataExport
        Separator = "|"
        BuyListHeader = BuyListHeaderTXT
        BuildListHeader = BuildListHeaderTXT & BuildListHeaderTXTAdd
        ItemsListHeader = ItemsListHeaderTXT & ItemsListHeaderTXTAdd
        SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.RestoreDirectory = True
        SaveFileDialog.FileName = FileName

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                MyStream = File.CreateText(SaveFileDialog.FileName)

                If Not (MyStream Is Nothing) Then

                    ' Output the buy list first
                    Items = lstBuy.Items

                    If Items.Count > 0 Then
                        Cursor.Current = Cursors.WaitCursor

                        Application.DoEvents()

                        OutputText = BuyListLabel
                        MyStream.Write(OutputText & Environment.NewLine)
                        OutputText = BuyListHeader
                        MyStream.Write(OutputText & Environment.NewLine)

                        For Each ListItem In Items
                            Application.DoEvents()

                            ' Build the output text 
                            If ExportTypeString = SSVDataExport Then
                                ' Format to EU
                                OutputText = ListItem.SubItems(1).Text & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(2).Text) & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(3).Text) & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(4).Text) & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(5).Text) & Separator
                                OutputText = OutputText & ListItem.SubItems(6).Text & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(7).Text) & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(8).Text) & Separator
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(9).Text)
                            Else
                                OutputText = ListItem.SubItems(1).Text & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(2).Text, "Fixed") & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(3).Text, "Fixed") & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(4).Text, "Fixed") & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(5).Text, "Fixed") & Separator
                                OutputText = OutputText & ListItem.SubItems(6).Text & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(7).Text, "Fixed") & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(8).Text, "Fixed") & Separator
                                OutputText = OutputText & Format(ListItem.SubItems(9).Text, "Fixed")
                            End If

                            MyStream.Write(OutputText & Environment.NewLine)
                        Next

                    End If

                    MyStream.Write("" & Environment.NewLine)

                    If Items.Count > 0 Then
                        Cursor.Current = Cursors.WaitCursor

                        Application.DoEvents()

                        OutputText = BuildListLabel
                        MyStream.Write(OutputText & Environment.NewLine)
                        OutputText = BuildListHeader
                        MyStream.Write(OutputText & Environment.NewLine)

                        For Each ListItem In Items
                            Application.DoEvents()

                            ' Build the output text for checked items
                            OutputText = ListItem.SubItems(1).Text & Separator
                            If ExportTypeString = SSVDataExport Then
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(2).Text) & Separator
                            Else
                                OutputText = OutputText & Format(ListItem.SubItems(2).Text, "Fixed") & Separator
                            End If

                            OutputText = OutputText & ListItem.SubItems(3).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(4).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(5).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(6).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(7).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(8).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(9).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(11).Text ' production type (BPTypeID is index 10)

                            MyStream.Write(OutputText & Environment.NewLine)
                        Next

                    End If

                    MyStream.Write("" & Environment.NewLine)

                    ' Output the item list
                    Items = lstItems.Items

                    If Items.Count > 0 Then
                        Cursor.Current = Cursors.WaitCursor

                        Application.DoEvents()
                        Dim TempName As String = ""
                        Dim TempRelic As String = ""

                        OutputText = ItemsListLabel
                        MyStream.Write(OutputText & Environment.NewLine)
                        OutputText = ItemsListHeader
                        MyStream.Write(OutputText & Environment.NewLine)

                        For Each ListItem In Items
                            Application.DoEvents()

                            If ListItem.SubItems(1).Text.Contains("(") Then
                                TempName = ListItem.SubItems(1).Text.Substring(0, InStr(ListItem.SubItems(1).Text, "(") - 2)
                                TempRelic = ListItem.SubItems(1).Text.Substring(InStr(ListItem.SubItems(1).Text, "("), InStr(ListItem.SubItems(1).Text, ")") - InStr(ListItem.SubItems(1).Text, "(") - 1)
                            Else
                                TempName = ListItem.SubItems(1).Text
                                TempRelic = ""
                            End If

                            ' Build the output text for checked items
                            OutputText = TempName & Separator
                            If ExportTypeString = SSVDataExport Then
                                OutputText = OutputText & ConvertUStoEUDecimal(ListItem.SubItems(2).Text) & Separator
                            Else
                                OutputText = OutputText & Format(ListItem.SubItems(2).Text, "Fixed") & Separator
                            End If
                            OutputText = OutputText & ListItem.SubItems(3).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(4).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(5).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(6).Text & Separator
                            OutputText = OutputText & TempRelic & Separator
                            OutputText = OutputText & ListItem.SubItems(8).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(7).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(9).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(10).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(11).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(12).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(13).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(14).Text & Separator
                            OutputText = OutputText & ListItem.SubItems(16).Text ' Facility build type (TE is index 15)

                            MyStream.Write(OutputText & Environment.NewLine)
                        Next

                    End If

                    MyStream.Flush()
                    MyStream.Close()

                    MsgBox("Shopping List Saved", vbInformation, Application.ProductName)

                End If
            Catch
                MsgBox(Err.Description, vbExclamation, Application.ProductName)
            End Try
        End If

        ' Done processing 
        Cursor.Current = Cursors.Default
        Me.Refresh()
        Application.DoEvents()

    End Sub

    Private Function FindFacility(SentFacility As IndustryFacility) As Boolean
        If FacilityToFind.FacilityName = SentFacility.FacilityName And FacilityToFind.FacilityProductionType = SentFacility.FacilityProductionType Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Copy's data shown and exports it to clipboard
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Dim ClipboardData As New DataObject
        Dim MatList() As String
        Dim ItemList() As String

        Dim i As Integer

        ' Get the order of the list of items that they set up by clicking on the columns - They could sort on any column so focus on unique columns to sort
        ReDim MatList(lstBuy.Items.Count - 1)
        ReDim ItemList(lstItems.Items.Count - 1)

        i = 0
        ' Material sort order - Just Name
        For Each item As ListViewItem In lstBuy.Items
            MatList(i) = item.SubItems(1).Text
            i += 1
        Next

        i = 0
        ' List Item sort order Name, Quantity, ME, Num BPs, Build Type, Decryptor, Location
        For Each item As ListViewItem In lstItems.Items
            ItemList(i) = item.SubItems(1).Text & "|" & item.SubItems(2).Text & "|" & item.SubItems(3).Text & "|" & item.SubItems(4).Text & "|" & item.SubItems(5).Text & "|" & item.SubItems(6).Text & "|" & item.SubItems(7).Text
            i += 1
        Next

        Dim ExportTypeString As String

        ExportTypeString = MultiBuyDataExport

        ' Paste to clipboard
        Call CopyTextToClipboard(TotalShoppingList.GetClipboardList(ExportTypeString, True, MatList, ItemList, False))

    End Sub

    Private Sub chkFees_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad Then
            ' Reload the list
            Call LoadBuyList()
            Call LoadFormStats()
        End If
    End Sub

    Private Sub chkBuyorBuyOrder_Click(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad Then
            ' Reload the list
            Call LoadBuyList()
            Call LoadFormStats()
        End If
    End Sub

    Private Sub chkUsage_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad Then
            Call LoadFormStats()
        End If
    End Sub

    Private Sub lstItems_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstItems.ColumnClick
        Call ListViewColumnSorter(e.Column, CType(lstItems, ListView), ItemListColumnClicked, ItemListColumnSortOrder)
    End Sub

    ' Turn off resizing for the last 4 columns
    Private Sub lstItems_ColumnWidthChanging(sender As Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lstItems.ColumnWidthChanging
        If e.ColumnIndex >= 8 Or e.ColumnIndex = 0 Then
            e.Cancel = True
            e.NewWidth = lstItems.Columns(e.ColumnIndex).Width
        End If
    End Sub

    ' Double Click build and load the blueprint for the item they clicked
    Private Sub lstItems_DoubleClick(sender As Object, e As System.EventArgs) Handles lstItems.DoubleClick
        Dim InputDecryptor As String = ""
        Dim InputRelic As String = ""
        Dim Inputs As String = None
        Dim TempMaterial As Material = Nothing
        Dim rsBPLookup As SQLiteDataReader
        Dim SQL As String

        ' Check Decryptor
        If lstItems.SelectedItems(0).SubItems(5).Text <> "" Then
            InputDecryptor = lstItems.SelectedItems(0).SubItems(6).Text
        End If

        ' Check for relic
        If lstItems.SelectedItems(0).SubItems(1).Text.Contains("(") Then
            With lstItems.SelectedItems(0).SubItems(1)
                InputRelic = .Text.Substring(InStr(.Text, "("), InStr(.Text, ")") - InStr(.Text, "(") - 1)
            End With
        End If

        If InputDecryptor <> "" And InputRelic <> "" Then
            Inputs = InputDecryptor & "|" & InputRelic
        ElseIf InputRelic <> "" Then
            Inputs = InputRelic
        ElseIf InputDecryptor <> "" Then
            Inputs = InputDecryptor
        Else
            Inputs = ""
        End If

        SQL = "SELECT BLUEPRINT_ID FROM ALL_BLUEPRINTS WHERE ITEM_ID = " & lstItems.SelectedItems(0).SubItems(0).Text

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsBPLookup = DBCommand.ExecuteReader
        rsBPLookup.Read()

        Dim BFI As BrokerFeeInfo
        BFI.IncludeFee = CType(UserBPTabSettings.IncludeFees, BrokerFeeType)
        BFI.FixedRate = UserBPTabSettings.BrokerFeeRate

        ' Get the decryptor or relic used from the item
        Call frmMain.LoadBPfromEvent(CLng(rsBPLookup.GetValue(0)), lstItems.SelectedItems(0).SubItems(5).Text, Inputs, SentFromLocation.ShoppingList,
                                           Nothing, Nothing, Nothing, Nothing, Nothing,
                                           UserBPTabSettings.IncludeTaxes, BFI,
                                           lstItems.SelectedItems(0).SubItems(3).Text, lstItems.SelectedItems(0).SubItems(15).Text,
                                           lstItems.SelectedItems(0).SubItems(2).Text, "1", CStr(UserBPTabSettings.LaboratoryLines),
                                           lstItems.SelectedItems(0).SubItems(4).Text, "0", False)
    End Sub

    Private Sub lstBuy_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstBuy.ColumnClick
        Call ListViewColumnSorter(e.Column, CType(lstBuy, ListView), BuyListColumnClicked, BuyListColumnSortOrder)
    End Sub

    ' Don't allow resizing of the first oclumn (hidden)
    Private Sub lstBuy_ColumnWidthChanging(sender As Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lstBuy.ColumnWidthChanging
        If e.ColumnIndex = 0 Then
            e.Cancel = True
            e.NewWidth = lstItems.Columns(e.ColumnIndex).Width
        End If
    End Sub

    Private Sub lstBuy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lstBuy.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call DeleteMaterials()
        End If
    End Sub

    Private Sub lstItems_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lstItems.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call DeleteItems()
        End If
    End Sub

    ' Add or take away tax from the total items from total and refresh prices
    Private Sub chkTotalItemTax_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad Then
            Call LoadFormStats()
        End If
    End Sub

    ' Add or take away brokers fees from the total items from total and refresh prices
    Private Sub chkTotalItemFees_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad Then
            Call LoadFormStats()
        End If
    End Sub

#Region "Delete list items"

    ' Checks to see if we have any items left and resets the lists and panel on frmmain and refreshes the lists
    Private Sub ReloadListsafterDelete()

        ' Just deleted, so notify
        Call PlayNotifySound()

        ' Check the total items in the list, if we delete all the materials, we aren't building anything anymore
        If IsNothing(TotalShoppingList.GetFullBuyList) Or TotalShoppingList.GetNumShoppingItems = 0 Then
            Call ClearLists()
        End If

        ' Refresh grids
        Call RefreshLists()

        Application.DoEvents()

    End Sub

    Private Sub DeleteItemStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DeleteItemStrip.Opening

        If lstItems.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If

        ' Change the name of the strip to allow for multiple mat selection
        If lstItems.SelectedItems.Count > 1 Then
            DeleteItem.Text = "Delete Items"
        Else
            DeleteItem.Text = "Delete Item"
        End If

    End Sub

    Private Sub DeleteMaterialStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DeleteMaterialStrip.Opening

        If lstBuy.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If

        ' Change the name of the strip to allow for multiple mat selection
        If lstBuy.SelectedItems.Count > 1 Then
            DeleteMaterial.Text = "Delete Materials"
        Else
            DeleteMaterial.Text = "Delete Material"
        End If

    End Sub

    Private Sub DeleteItemStrip_Click(sender As System.Object, e As System.EventArgs) Handles DeleteItem.Click
        Call DeleteItems()
    End Sub

    Private Sub DeleteMaterialStrip_Click(sender As System.Object, e As System.EventArgs) Handles DeleteMaterial.Click
        Call DeleteMaterials()
    End Sub

    Private Sub DeleteItems()
        Dim ShopListItem As New ShoppingListItem
        Dim SelectedItem As String

        If lstItems.SelectedItems.Count > 0 Then
            For i = 0 To lstItems.SelectedItems.Count - 1

                SelectedItem = lstItems.SelectedItems(i).SubItems(1).Text

                If SelectedItem <> "" Then
                    ' Get the name, build type, and ME, and meta of the item selected
                    If SelectedItem.Contains("(") Then
                        ' Strip off the relic from the name
                        ShopListItem.Name = SelectedItem.Substring(0, InStr(SelectedItem, "(") - 2)
                    Else
                        ShopListItem.Name = SelectedItem
                    End If
                    ShopListItem.Runs = CLng(lstItems.SelectedItems(i).SubItems(2).Text)
                    ShopListItem.ItemME = CInt(lstItems.SelectedItems(i).SubItems(3).Text)
                    ShopListItem.ItemTE = CInt(CBool(lstItems.SelectedItems(i).SubItems(12).Text))
                    ShopListItem.NumBPs = CInt(lstItems.SelectedItems(i).SubItems(4).Text)
                    ShopListItem.BuildType = lstItems.SelectedItems(i).SubItems(5).Text
                    ShopListItem.ManufacturingFacility.FacilityName = lstItems.SelectedItems(i).SubItems(7).Text

                    ' Remove it from shopping list
                    TotalShoppingList.UpdateShoppingItemQuantity(ShopListItem, 0)

                End If
            Next

            ' Just updated, so notify
            Call PlayNotifySound()
            Call RefreshLists()

        End If
    End Sub

    Private Sub DeleteMaterials()
        If lstBuy.SelectedItems.Count > 0 Then
            For i = 0 To lstBuy.SelectedItems.Count - 1
                ' Remove it
                Call TotalShoppingList.UpdateShoppingBuyQuantity(lstBuy.SelectedItems(i).SubItems(1).Text, 0)
            Next

            ' Just updated, so notify
            Call PlayNotifySound()
            Call RefreshLists()

        End If
    End Sub

#End Region

#Region "InlineListUpdate"

    ' Determines where to show the text box when clicking on the list sent
    Private Sub ListClicked(ListRef As ListView, sender As Object, e As MouseEventArgs)
        Dim iSubIndex As Integer = 0

        ' Hide the text box when a new line is selected
        txtListEdit.Hide()

        CurrentRow = ListRef.GetItemAt(e.X, e.Y) ' which listviewitem was clicked
        SelectedGrid = ListRef

        If CurrentRow Is Nothing Then
            Exit Sub
        End If

        CurrentCell = CurrentRow.GetSubItemAt(e.X, e.Y)  ' which subitem was clicked

        ' See which column has been clicked
        iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell)

        ' Determine where the previous and next item boxes will be based on what they clicked - used in tab event handling as well
        Call SetNextandPreviousCells(ListRef)

        ' Look at the buy list for price and quantity
        If ListRef.Name = lstBuy.Name Then
            ' Set the columns that can be edited, just Quantity and Price
            Select Case iSubIndex
                Case 1
                    ' Item - only showing box
                    UpdateQuantity = False
                    UpdatePrice = False
                    Call ShowUpdateTextBox(ListRef, HorizontalAlignment.Left)
                Case 2
                    UpdateQuantity = True
                    UpdatePrice = False
                    Call ShowUpdateTextBox(ListRef)
                Case 3
                    UpdateQuantity = False
                    UpdatePrice = True
                    Call ShowUpdateTextBox(ListRef)
                Case Else
                    UpdateQuantity = False
                    UpdatePrice = False
            End Select

        Else ' Just Quantity updates in the other two grids
            ' Set the columns that can be edited, just Price
            If iSubIndex = 2 Then
                UpdateQuantity = True
                UpdatePrice = False
                Call ShowUpdateTextBox(ListRef)
            ElseIf iSubIndex = 1 Then
                ' Show the item box for copy/paste purposes
                UpdateQuantity = False
                UpdatePrice = False
                Call ShowUpdateTextBox(ListRef, HorizontalAlignment.Left)
            Else
                UpdateQuantity = False
                UpdatePrice = False
            End If
        End If

    End Sub

    ' Shows the text box on the grid where clicked if enabled
    Private Sub ShowUpdateTextBox(ListRef As ListView, Optional TextAlignment As HorizontalAlignment = HorizontalAlignment.Right)
        Dim lLeft As Integer = 0
        Dim lWidth As Integer = 0

        ' Get size of column and location
        lLeft = CurrentCell.Bounds.Left + 2
        lWidth = CurrentCell.Bounds.Width

        ' Save the center location of the edit box
        SavedListClickLoc.X = CurrentCell.Bounds.Left + CInt(CurrentCell.Bounds.Width / 2)
        SavedListClickLoc.Y = CurrentCell.Bounds.Top + CInt(CurrentCell.Bounds.Height / 2)

        With txtListEdit
            .Hide()
            .SetBounds(lLeft + ListRef.Left, CurrentCell.Bounds.Top + ListRef.Top, lWidth, CurrentCell.Bounds.Height)
            .Text = CurrentCell.Text
            .Show()
            .TextAlign = TextAlignment
            .Focus()
        End With

    End Sub

    ' Determines where the previous and next item boxes will be based on what they clicked - used in tab event handling
    Private Sub SetNextandPreviousCells(ListRef As ListView, Optional CellType As String = "")
        Dim iSubIndex As Integer = 0

        ' Normal Row
        If CellType = "Next" Then
            CurrentRow = NextCellRow
        ElseIf CellType = "Previous" Then
            CurrentRow = PreviousCellRow
        End If

        ' Get index of column
        iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell)

        ' Get next and previous rows. If at end, wrap to top. If at top, wrap to bottom
        If ListRef.Items.Count = 1 Then
            NextRow = CurrentRow
            PreviousRow = CurrentRow
        ElseIf CurrentRow.Index <> ListRef.Items.Count - 1 And CurrentRow.Index <> 0 Then
            ' Not the last line, so set the next and previous
            NextRow = ListRef.Items.Item(CurrentRow.Index + 1)
            PreviousRow = ListRef.Items.Item(CurrentRow.Index - 1)
        ElseIf CurrentRow.Index = 0 Then
            NextRow = ListRef.Items.Item(CurrentRow.Index + 1)
            ' Wrap to bottom
            PreviousRow = ListRef.Items.Item(ListRef.Items.Count - 1)
        ElseIf CurrentRow.Index = ListRef.Items.Count - 1 Then
            ' Need to wrap up to top
            NextRow = ListRef.Items.Item(0)
            PreviousRow = ListRef.Items.Item(CurrentRow.Index - 1)
        End If

        ' Check for buy list
        If ListRef.Name = lstBuy.Name Then

            ' The next row must be a Quantity or Price box on the next row 
            ' or a previous Quantity or Price box on the previous row
            Select Case iSubIndex
                Case 1 ' Just item
                    NextCell = CurrentRow.SubItems.Item(2) ' Current row Quantity box
                    NextCellRow = CurrentRow
                    PreviousCell = PreviousRow.SubItems.Item(3) ' Previous row Price box
                    PreviousCellRow = PreviousRow

                    UpdateQuantity = False
                    UpdatePrice = False
                Case 2 ' Quantity
                    NextCell = CurrentRow.SubItems.Item(3) ' Current row Price box
                    NextCellRow = CurrentRow
                    PreviousCell = CurrentRow.SubItems.Item(1) ' Current row Item box
                    PreviousCellRow = CurrentRow

                    UpdateQuantity = True
                    UpdatePrice = False
                Case 3 ' Price
                    NextCell = NextRow.SubItems.Item(1) ' Next row Item box
                    NextCellRow = NextRow
                    PreviousCell = CurrentRow.SubItems.Item(2) ' Current row Quantity box
                    PreviousCellRow = CurrentRow

                    UpdateQuantity = False
                    UpdatePrice = True
                Case Else
                    NextCell = Nothing
                    PreviousCell = Nothing
                    CurrentCell = Nothing
            End Select

        Else ' For quantity updates only
            ' Set the next and previous quantity boxes
            If iSubIndex = 1 Then
                NextCell = CurrentRow.SubItems.Item(2) ' Next quantity box
                NextCellRow = CurrentRow
                PreviousCell = PreviousRow.SubItems.Item(2) ' Previous quantity box
                PreviousCellRow = PreviousRow

                UpdateQuantity = True
                UpdatePrice = False
            ElseIf iSubIndex = 2 Then
                NextCell = NextRow.SubItems.Item(1) ' Next name box
                NextCellRow = NextRow
                PreviousCell = CurrentRow.SubItems.Item(1) ' Previous name box
                PreviousCellRow = CurrentRow

                UpdateQuantity = False
                UpdatePrice = False
            Else
                NextCell = Nothing
                PreviousCell = Nothing
                CurrentCell = Nothing
            End If
        End If

    End Sub

    ' For updating the items in the list by clicking on them
    Private Sub ProcessKeyDownUpdateEdit(SentKey As Keys, ListRef As ListView)
        Dim QuantityValue As Integer = 0
        Dim PriceValue As Double = 0
        Dim SQL As String

        ' Change blank entry to 0
        If Trim(txtListEdit.Text) = "" Then
            txtListEdit.Text = "0"
        End If

        ' If they hit enter or tab away, mark the BP as owned in the DB with the values entered
        If (SentKey = Keys.Enter Or SentKey = Keys.ShiftKey Or SentKey = Keys.Tab) And DataEntered Then

            ' Check the input first
            If Not IsNumeric(txtListEdit.Text) And UpdateQuantity Then
                MsgBox("Invalid Quantity Value", vbExclamation)
                Exit Sub
            End If

            If Not IsNumeric(txtListEdit.Text) And UpdatePrice Then
                MsgBox("Invalid Price Value", vbExclamation)
                Exit Sub
            End If

            ' Save the data depending on what we are updating
            If UpdateQuantity Then
                QuantityValue = CInt(txtListEdit.Text)
            End If

            If UpdatePrice Then
                PriceValue = CDbl(txtListEdit.Text)
            End If

            ' Update the quantity data in all three grids
            If UpdateQuantity Then

                ' Adjust the mats to what they enter - if it said 100, and they enter 90, then adjust to 90
                If ListRef.Name = lstBuy.Name Then ' The materials we buy to build items 
                    ' Check the numbers, if the same then don't update
                    If QuantityValue = CInt(CurrentRow.SubItems(2).Text) And PriceValue = CDbl(CurrentRow.SubItems(3).Text) Then
                        ' Skip down
                        GoTo Tabs
                    End If

                    ' Save the mats they probably have on hand to make this change - calc from value in grid vs. value entered
                    Dim OnHandQuantity As Long = CLng(CurrentRow.SubItems(2).Text) - QuantityValue
                    Dim OnHandMaterial As New Material(0, CurrentRow.SubItems(1).Text, "", OnHandQuantity, 0, 0, 0, "", "")
                    TotalShoppingList.OnHandMatList.InsertMaterial(OnHandMaterial)

                    ' Update the buy list
                    Call TotalShoppingList.UpdateShoppingBuyQuantity(CurrentRow.SubItems(1).Text, QuantityValue)

                ElseIf ListRef.Name = lstItems.Name Then ' The items we are building
                    ' Check the numbers, if the same then don't update
                    If QuantityValue = CInt(CurrentRow.SubItems(2).Text) Then
                        ' Skip down
                        GoTo Tabs
                    End If

                    Dim ShopListItem As New ShoppingListItem
                    Dim TempName As String = CurrentRow.SubItems(1).Text
                    If TempName.Contains("(") Then
                        ShopListItem.Name = TempName.Substring(0, InStr(TempName, "(") - 2)
                    Else
                        ShopListItem.Name = TempName
                    End If
                    ShopListItem.Runs = CLng(CurrentRow.SubItems(2).Text)
                    ShopListItem.ItemME = CInt(CurrentRow.SubItems(3).Text)
                    ShopListItem.ItemTE = CInt(CurrentRow.SubItems(15).Text)
                    ShopListItem.NumBPs = CInt(CurrentRow.SubItems(4).Text)
                    ShopListItem.BuildType = CurrentRow.SubItems(5).Text
                    ShopListItem.ManufacturingFacility.FacilityName = CurrentRow.SubItems(7).Text

                    ' Update the full shopping list
                    Call TotalShoppingList.UpdateShoppingItemQuantity(ShopListItem, QuantityValue)

                End If

            ElseIf ListRef.Name = lstBuy.Name And UpdatePrice Then ' Price update on the lstBuy screen
                ' Update the price in the database
                SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " & CStr(CDbl(txtListEdit.Text)) & ", PRICE_TYPE = 'User' WHERE ITEM_ID = " & CurrentRow.SubItems(0).Text
                Call EVEDB.ExecuteNonQuerySQL(SQL)

                ' Change the value in the price grid, but don't update the grid
                CurrentRow.SubItems(2).Text = FormatNumber(txtListEdit.Text, 2)

                ' Update the Prices
                Call UpdateProgramPrices()
                Me.Focus()

            Else
                GoTo Tabs
            End If

            Call RefreshLists()

            ' Just updated, so notify
            Call PlayNotifySound()

            ' Reset text they entered if tabbed
            If SentKey = Keys.ShiftKey Or SentKey = Keys.Tab Then
                txtListEdit.Text = ""
            End If

            ' Data updated, so reset
            DataEntered = False

            If SentKey = Keys.Enter Then
                ' Just refresh and select the current row
                CurrentRow.Selected = True
                txtListEdit.Visible = False
            End If

        End If

Tabs:
        ' If they hit tab, then tab to the next cell
        If SentKey = Keys.Tab Then
            If CurrentRow.Index = -1 Then
                ' Reset the current row based on the original click
                CurrentRow = ListRef.GetItemAt(SavedListClickLoc.X, SavedListClickLoc.Y)
                CurrentCell = CurrentRow.GetSubItemAt(SavedListClickLoc.X, SavedListClickLoc.Y)
                ' Reset the next and previous cells
                SetNextandPreviousCells(ListRef)
            End If

            CurrentCell = NextCell

            ' Reset these each time
            Call SetNextandPreviousCells(ListRef, "Next")
            If CurrentRow.Index = 0 Then
                ' Scroll to top
                ListRef.Items.Item(0).Selected = True
                ListRef.EnsureVisible(0)
                ListRef.Update()
            Else
                ' Make sure the row is visible
                ListRef.EnsureVisible(CurrentRow.Index)
            End If

            ' Show the text box
            If CurrentRow.SubItems.IndexOf(CurrentCell) = 1 Then
                Call ShowUpdateTextBox(ListRef, HorizontalAlignment.Left)
            Else
                Call ShowUpdateTextBox(ListRef)
            End If

        End If

        ' If shift+tab, then go to the previous cell 
        If SentKey = Keys.ShiftKey Then
            If CurrentRow.Index = -1 Then
                ' Reset the current row based on the original click
                CurrentRow = ListRef.GetItemAt(SavedListClickLoc.X, SavedListClickLoc.Y)
                CurrentCell = CurrentRow.GetSubItemAt(SavedListClickLoc.X, SavedListClickLoc.Y)
                ' Reset the next and previous cells
                SetNextandPreviousCells(ListRef)
            End If

            CurrentCell = PreviousCell
            ' Reset these each time
            Call SetNextandPreviousCells(ListRef, "Previous")
            If CurrentRow.Index = ListRef.Items.Count - 1 Then
                ' Scroll to bottom
                ListRef.Items.Item(ListRef.Items.Count - 1).Selected = True
                ListRef.EnsureVisible(ListRef.Items.Count - 1)
                ListRef.Update()
            Else
                ' Make sure the row is visible
                ListRef.EnsureVisible(CurrentRow.Index)
            End If

            ' Show the text box
            If CurrentRow.SubItems.IndexOf(CurrentCell) = 1 Then
                Call ShowUpdateTextBox(ListRef, HorizontalAlignment.Left)
            Else
                Call ShowUpdateTextBox(ListRef)
            End If

        End If

    End Sub

    ' Processes the tab function in the text box for the grid. This overrides the default tabbing between controls
    Protected Overrides Function ProcessTabKey(ByVal TabForward As Boolean) As Boolean
        Dim ac As Control = Me.ActiveControl

        If TabForward Then
            If ac Is txtListEdit Then
                Call ProcessKeyDownUpdateEdit(Keys.Tab, SelectedGrid)
                Return True
            End If
        Else
            If ac Is txtListEdit Then
                ' This is Shift + Tab but just send Shift for ease of processing
                Call ProcessKeyDownUpdateEdit(Keys.ShiftKey, SelectedGrid)
                Return True
            End If
        End If

        Return MyBase.ProcessTabKey(TabForward)

    End Function

    Private Sub txtListEdit_GotFocus(sender As Object, e As System.EventArgs) Handles txtListEdit.GotFocus
        Call txtListEdit.SelectAll()
    End Sub

    Private Sub txtListEdit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtListEdit.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If UpdateQuantity Then
                If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                    ' Invalid Character
                    e.Handled = True
                Else
                    DataEntered = True
                End If
            ElseIf UpdatePrice Then
                If allowedPriceChars.IndexOf(e.KeyChar) = -1 Then
                    ' Invalid Character
                    e.Handled = True
                Else
                    DataEntered = True
                End If
            End If

        End If

    End Sub

    Private Sub txtListEdit_LostFocus(sender As Object, e As System.EventArgs) Handles txtListEdit.LostFocus
        If Not RefreshingGrid And DataEntered And Not IgnoreFocusChange Then
            Call ProcessKeyDownUpdateEdit(Keys.Enter, SelectedGrid)
        End If
        txtListEdit.Visible = False
    End Sub

    Private Sub lstBuy_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstBuy.MouseClick
        If e.Button <> Windows.Forms.MouseButtons.Right And Not (My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CtrlKeyDown) Then
            Call ListClicked(lstBuy, sender, e)
        End If
    End Sub

    Private Sub lstItems_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstItems.MouseClick
        If e.Button <> Windows.Forms.MouseButtons.Right And Not (My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CtrlKeyDown) Then
            Call ListClicked(lstItems, sender, e)
        End If
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstBuild_ProcMsg(ByVal m As System.Windows.Forms.Message)
        txtListEdit.Hide()
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstBuy_ProcMsg(ByVal m As System.Windows.Forms.Message) Handles lstBuy.ProcMsg
        txtListEdit.Hide()
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstItems_ProcMsg(ByVal m As System.Windows.Forms.Message) Handles lstItems.ProcMsg
        txtListEdit.Hide()
    End Sub

    Private Sub txtBrokerFeeRate_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Only allow numbers, decimal, percent or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPercentChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

#End Region

End Class

Public Class EVEPraisal
    <JsonProperty("appraisal")> Public appraisal As eveappraisal
End Class

Public Class eveappraisal
    <JsonProperty("created")> Public created As Double
    <JsonProperty("id")> Public id As String
    <JsonProperty("items")> Public items As List(Of eprasialItems)
    <JsonProperty("market_name")> Public market_name As String
    <JsonProperty("raw")> Public raw As String
End Class

Public Class eprasialItems
    <JsonProperty("appraisal")> Public appraisal As eveappraisal
    <JsonProperty("method")> Public method As String
    <JsonProperty("route")> Public route As String
    <JsonProperty("status")> Public status As String
    <JsonProperty("tags")> Public tags As List(Of String)
End Class

Public Class EAItem
    Public market_name As String
    Public items As List(Of typeIDs)
End Class

Public Class typeIDs
    Public type_id As Integer
End Class