' Main form for all processing
Imports System.Data.SQLite
Imports System.Globalization
Imports System.Threading
Imports System.IO
Imports System.Net
Imports MoreLinq.MoreEnumerable
Imports GoogleAnalyticsClientDotNet

Public Class frmMain

    ' Update Prices Variables
    Private m_ControlsCollection As ControlsCollection
    Private RegionCheckBoxes() As MetroFramework.Controls.MetroRadioButton
    Private SystemCheckBoxes() As MetroFramework.Controls.MetroRadioButton
    ' For saving the price type that was used in the download
    Private GroupPricesList As New List(Of GroupPriceType)
    Private GroupPriceTypetoFind As New GroupPriceType
    Private Class GroupPriceType
        Public PriceType As String
        Public ItemID As Long

        Public Sub New()
            PriceType = ""
            ItemID = 0
        End Sub
    End Class

    ' Datacores
    Private DCSkillCheckBoxes() As CheckBox
    Private DCSkillLabels() As Label
    Private DCSkillCombos() As ComboBox
    Private DCCorpCheckBoxes() As CheckBox
    Private DCCorpLabels() As Label
    Private DCCorpTextboxes() As TextBox

    ' Mining ore processing skills
    Private MineProcessingCheckBoxes() As CheckBox
    Private MineProcessingLabels() As Label
    Private MineProcessingCombos() As ComboBox

    ' Manufacturing
    Private CalcRelicCheckboxes() As CheckBox
    Private CalcDecryptorCheckBoxes() As CheckBox
    Private TypeIDToFind As Long ' For searching a price list

    ' Manufacturing Column stuff
    Private ColumnPositions(NumManufacturingTabColumns) As String ' For saving the column order
    Private AddingColumns As Boolean
    Private MovedColumn As Integer

    Private DCIPH_COLUMN As Integer ' The number of the DC IPH column for totalling up the price

    Private IgnoreRefresh As Boolean = False
    Private RunUpdatePriceList As Boolean = True ' If we want to run the price list update
    Private RefreshList As Boolean = True
    Private UpdateAllTechChecks As Boolean = True ' Whether to update all Tech checks in prices or not
    Private FirstShowMining As Boolean = True ' If we have clicked on the Mining tab yet to load initial data
    Private FirstShowDatacores As Boolean = True ' If we have clicked on the Datacores tab yet or not (only load initial data on first click)

    ' For fixing double-click / check box on listview item box
    Private inhibitAutoCheck As Boolean

    ' Blueprints Variables
    Private cmbBPsLoaded As Boolean

    ' BP List for Previous/Next
    Private BPHistory As New List(Of BPHistoryItem)

    ' For letting manual check/override of build/buy calculations
    Private IgnoreListViewItemChecks As Boolean
    Private BPBBItems As New List(Of BPBBItem)

    Private BPBBItemtoFind As New Integer
    Private BBItemtoFind As New BuildBuyItem

    Public Structure BPBBItem
        Dim BPID As Integer
        Dim BBItems As List(Of BuildBuyItem)
    End Structure

    Private Structure BPHistoryItem
        Dim BPID As Long
        Dim BPName As String
        Dim BuildType As String
        Dim Inputs As String
        Dim SentFrom As SentFromLocation
        Dim BuildFacility As IndustryFacility
        Dim ComponentFacility As IndustryFacility
        Dim CapComponentFacility As IndustryFacility
        Dim InventionFacility As IndustryFacility
        Dim CopyFacility As IndustryFacility
        Dim IncludeTaxes As Boolean
        Dim BrokerFeeData As BrokerFeeInfo
        Dim MEValue As String
        Dim TEValue As String
        Dim SentRuns As String
        Dim ManufacturingLines As String
        Dim LabLines As String
        Dim NumBPs As String
        Dim AddlCosts As String
        Dim PPU As Boolean
    End Structure

    Private CurrentBPHistoryIndex As Integer
    Private ResetBPTab As Boolean ' If we recalled the InitBP to enable all the stuff on the screen

    ' BP Combo processing
    Public ComboMenuDown As Boolean
    Public MouseWheelSelection As Boolean
    Public ComboBoxArrowKeys As Boolean
    Public BPSelected As Boolean
    Public BPComboKeyDown As Boolean

    ' Relics
    Private LoadingRelics As Boolean
    Private RelicsLoaded As Boolean

    ' Decryptors
    Private SelectedDecryptor As New Decryptor

    ' Invention
    Private UpdatingInventionChecks As Boolean

    Private LoadingInventionDecryptors As Boolean
    Private LoadingT3Decryptors As Boolean

    Private InventionDecryptorsLoaded As Boolean
    Private T3DecryptorsLoaded As Boolean

    ' If we are loading from history
    Private LoadingBPfromHistory As Boolean
    Private PreviousBPfromHistory As Boolean

    ' Updates for threading
    Public PriceHistoryUpdateCount As Integer
    Public PriceOrdersUpdateCount As Integer

    ' BP stats
    Private OwnedBP As Boolean

    ' For T2 BPOs mainly so we can load the stored ME/TE if it changes
    Private OwnedBPME As String
    Private OwnedBPPE As String
    Private CalcTempME As Integer = 5
    Private CalcTempTE As Integer = 10

    Private UpdatingCheck As Boolean
    Private UpdatingStructureIDText As Boolean

    ' For checks that are enabled
    Private PriceCheckT1Enabled As Boolean
    Private PriceCheckT2Enabled As Boolean
    Private PriceCheckT3Enabled As Boolean
    Private PriceCheckT4Enabled As Boolean
    Private PriceCheckT5Enabled As Boolean
    Private PriceCheckT6Enabled As Boolean

    ' For updating several checks at once
    Private IgnoreSystemCheckUpdates As Boolean
    Private IgnoreRegionCheckUpdates As Boolean

    Private PriceToggleButtonHit As Boolean

    ' Total isk per hour selected on datacore grid
    Private TotalSelectedIPH As Double

    ' Loading the solar system combo on the price page
    Private FirstSolarSystemComboLoad As Boolean
    Private FirstPriceShipTypesComboLoad As Boolean
    Private FirstPriceChargeTypesComboLoad As Boolean

    ' For loading the Manufacturing Grid
    Private FirstLoadCalcBPTypes As Boolean
    Private FirstManufacturingGridLoad As Boolean

    Private UserInventedBPs As New List(Of Long)  ' This is a list of all the BPs that the user will invent from owned T1s (Manufacturing Grid)

    ' For ignoring updates to the ship booster combo in mining
    Private UpdatingMiningShips As Boolean

    ' If we refresh the manufacturing data or recalcuate
    Private RefreshCalcData As Boolean

    ' Reload of Regions on Datacore class
    Private DCRegionsLoaded As Boolean

    ' Final list of items for manufacturing (keep form level so we can refresh it if needed)
    Private FinalManufacturingItemList As List(Of ManufacturingItem)
    Private ManufacturingRecordIDToFind As Long ' for Predicate
    Private ManufacturingNameToFind As String ' for Predicate

    ' For column sorting - What column did they click on to sort
    Private ManufacturingColumnClicked As Integer
    Private ManufacturingColumnSortType As SortOrder
    Private UpdatePricesColumnClicked As Integer
    Private UpdatePricesColumnSortType As SortOrder
    Private BPCompColumnClicked As Integer
    Private BPCompColumnSortType As SortOrder
    Private BPRawColumnClicked As Integer
    Private BPRawColumnSortType As SortOrder
    Private DCColumnClicked As Integer
    Private DCColumnSortType As SortOrder
    Private MiningColumnClicked As Integer
    Private MiningColumnSortType As SortOrder
    Private ReactionsColumnClicked As Integer
    Private ReactionsColumnSortType As SortOrder

    Private SelectedBPText As String = ""

    Private ProfitText As String
    Private ProfitPercentText As String

    Private DefaultSettings As New ProgramSettings ' For default constants

    Private ListIDIterator As Integer ' For setting a unique record id in the manufacturing tab
    Private ListRowFormats As New List(Of RowFormat) ' The lists of formats to use in drawing the manufacturing list

    Private SelectedBPTabIndex As Integer ' So we don't move around the different facility/invention/re tabs on the user

    ' Inline grid row update variables
    Private Structure SavedLoc
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Private SavedListClickLoc As SavedLoc
    Private RefreshingGrid As Boolean

    Private CurrentRow As ListViewItem
    Private PreviousRow As ListViewItem
    Private NextRow As ListViewItem

    Private NextCellRow As ListViewItem
    Private PreviousCellRow As ListViewItem

    Private CurrentCell As ListViewItem.ListViewSubItem
    Private PreviousCell As ListViewItem.ListViewSubItem
    Private NextCell As ListViewItem.ListViewSubItem

    Private MEUpdate As Boolean
    Private PriceUpdate As Boolean
    Private DataUpdated As Boolean
    Private DataEntered As Boolean
    Private EnterKeyPressed As Boolean
    Private SelectedGrid As ListView

    Private PriceTypeUpdate As Boolean
    Private PriceSystemUpdate As Boolean
    Private PriceRegionUpdate As Boolean
    Private PriceModifierUpdate As Boolean
    Private PreviousPriceType As String
    Private PreviousRegion As String
    Private PreviousSystem As String
    Private PreviousPriceMod As String
    Private TabPressed As Boolean
    Private UpdatingCombo As Boolean

    Private PPRawSystemsLoaded As Boolean
    Private DefaultPreviousRawRegion As String
    Private PPItemsSystemsLoaded As Boolean
    Private DefaultPreviousItemsRegion As String
    Private calcHistoryRegion As String

    Private IgnoreFocus As Boolean
    Private IgnoreMarketFocus As Boolean

    ' Column width consts - may change depending on Ore, Ice or Gas so change the widths of the columns based on these and use them to add and move
    Private Const MineOreNameColumnWidth As Integer = 120
    Private Const MineRefineYieldColumnWidth As Integer = 70
    Private Const MineCrystalColumnWidth As Integer = 45
    Private Const PriceListHeaderCSV As String = "Group Name,Item Name,Price,Price Type,Raw Material,Type ID"
    Private Const PriceListHeaderTXT As String = "Group Name|Item Name|Price|Price Type|Raw Material|Type ID"
    Private Const PriceListHeaderSSV As String = "Group Name;Item Name;Price;Price Type;Raw Material;Type ID"

#Region "Initialization Code"

    ' Set default window theme so tabs in invention window display correctly on all systems
    Public Declare Unicode Function SetWindowTheme Lib "uxtheme.dll" (ByVal hWnd As IntPtr,
        ByVal pszSubAppName As String, ByVal pszSubIdList As String) As Integer

    Public Sub New()

        MyBase.New()

        ErrorTracker = ""
        ESIErrorHandler = New ESIErrorProcessor()

        Dim ErrorData As ErrObject = Nothing
        Dim ESIData As New ESI

        ' Set developer flag
        If File.Exists("Developer.txt") Then
            Developer = True
        Else
            Developer = False
        End If

        ' Covert to new ESI registration system to use my registration and PKCE
        ' If they registered before, show a pop-up and require registration. Then delete the registration file
        Dim AppRegistrationFileName As String = Path.ChangeExtension(Path.Combine(DynamicFilePath, "", "AppRegistrationInformation"), ".xml")
        If File.Exists(AppRegistrationFileName) Then
            Dim f1 As New frmAppRegistrationNotice
            f1.ShowDialog()

            ' Now delete the registration file
            File.Delete(AppRegistrationFileName)

        End If

        ' Set test platform
        If File.Exists("Test.txt") Then
            TestingVersion = True
        Else
            TestingVersion = False
        End If

        Call SetProgress("Initializing...")

        Application.DoEvents()

        ' This call is required by the designer.
        InitializeComponent()

        FirstLoad = True

        ' See if they've disabled GA tracking
        If Not UserApplicationSettings.DisableGATracking Then
            ' Use google analytics to track number of users using IPH (no user information passed except MAC address for Client ID)
            On Error Resume Next

            Dim GATracker As New AnalyticsService()
            Call GATracker.Initialize("UA-125827521-1", "EVE IPH", "EVE Isk per Hour", My.Application.Info.Version.ToString)

            Dim MACAddress As String = GetMacAddress() ' Use this for the Client ID
            Dim EventData As New ServiceModel.EventParameter

            EventData.Category = "Program Usage"
            EventData.Action = "Open IPH"
            EventData.Label = "Initialized"
            EventData.ClientId = HashSHA(MACAddress) ' Hash the MAC address for security

            Call GATracker.TrackEvent(EventData)

            On Error GoTo 0
        End If

        ' Always use US for now and don't take into account user overrided stuff like the system clock format
        LocalCulture = New CultureInfo("en-US", False)
        ' Sets the CurrentCulture 
        Thread.CurrentThread.CurrentCulture = LocalCulture

        ' Add any initialization after the InitializeComponent() call.

        ' Find out if we are running all in the current folder or with updates and the DB in the appdata folder
        If File.Exists(SQLiteDBFileName) Then
            ' Single folder that we are in, so set the path variables to it for updates
            DynamicFilePath = Path.GetDirectoryName(Application.ExecutablePath)
            DBFilePath = Path.GetDirectoryName(Application.ExecutablePath)
        Else
            ' They ran the installer (or we assume they did) and all the files are updated in the appdata/roaming folder
            ' Set where files will be updated
            DynamicFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DynamicAppDataPath)
            DBFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DynamicAppDataPath)
        End If

        ' Get the user settings then check for updates
        UserApplicationSettings = AllSettings.LoadApplicationSettings

        ' Check for program updates first
        If UserApplicationSettings.CheckforUpdatesonStart Then
            ' Check for program updates
            Application.UseWaitCursor = True
            Me.Activate()
            Call CheckForUpdates(False, Me.Icon)
            Application.UseWaitCursor = False
            Application.DoEvents()
        End If

        ' Initialize stuff
        Call SetProgress("Initializing Database...")
        Application.DoEvents()
        EVEDB = New DBConnection(Path.Combine(DBFilePath, SQLiteDBFileName))

        ' Add a column for risk prices
        Dim riskStatus As SQLiteDataReader
        Dim SQL As String = ""
        ' Check if the risk price column exists already
        SQL = "pragma table_info(ITEM_PRICES_FACT)"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        riskStatus = DBCommand.ExecuteReader
        Dim columnName As String
        Dim riskColumnFound As Boolean
        While (riskStatus.Read())
            columnName = riskStatus.GetString(1)
            If String.Equals(columnName, "RISK_PRICE") Then
                riskColumnFound = True
            End If
        End While
        ' If not found, add it
        If Not riskColumnFound Then
            ' Add the risk price column
            SQL = "ALTER TABLE ITEM_PRICES_FACT ADD RISK_PRICE float"
            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            riskStatus = DBCommand.ExecuteReader
        End If

        ' For speed on ESI calls
        ServicePointManager.DefaultConnectionLimit = 20
        ServicePointManager.UseNagleAlgorithm = False
        ServicePointManager.Expect100Continue = False

        ' Load the user settings
        Call SetProgress("Loading User Settings...")
        UserBPTabSettings = AllSettings.LoadBPSettings
        UserUpdatePricesTabSettings = AllSettings.LoadUpdatePricesSettings
        UserManufacturingTabSettings = AllSettings.LoadManufacturingSettings
        UserDCTabSettings = AllSettings.LoadDatacoreSettings
        UserReactionTabSettings = AllSettings.LoadReactionSettings
        UserMiningTabSettings = AllSettings.LoadMiningSettings
        UserIndustryJobsColumnSettings = AllSettings.LoadIndustryJobsColumnSettings
        UserManufacturingTabColumnSettings = AllSettings.LoadManufacturingTabColumnSettings
        UserShoppingListSettings = AllSettings.LoadShoppingListSettings
        UserMHViewerSettings = AllSettings.LoadMarketHistoryViewerSettingsSettings
        UserBPViewerSettings = AllSettings.LoadBPViewerSettings
        UserUpwellStructureSettings = AllSettings.LoadUpwellStructureViewerSettings
        StructureBonusPopoutViewerSettings = AllSettings.LoadStructureBonusPopoutViewerSettings

        UserIndustryFlipBeltSettings = AllSettings.LoadIndustryFlipBeltColumnSettings
        UserIndustryFlipBeltOreCheckSettings1 = AllSettings.LoadIndustryBeltOreChecksSettings(BeltType.Small)
        UserIndustryFlipBeltOreCheckSettings2 = AllSettings.LoadIndustryBeltOreChecksSettings(BeltType.Medium)
        UserIndustryFlipBeltOreCheckSettings3 = AllSettings.LoadIndustryBeltOreChecksSettings(BeltType.Large)
        UserIndustryFlipBeltOreCheckSettings4 = AllSettings.LoadIndustryBeltOreChecksSettings(BeltType.Enormous)
        UserIndustryFlipBeltOreCheckSettings5 = AllSettings.LoadIndustryBeltOreChecksSettings(BeltType.Colossal)

        UserAssetWindowManufacturingTabSettings = AllSettings.LoadAssetWindowSettings(AssetWindow.ManufacturingTab)
        UserAssetWindowShoppingListSettings = AllSettings.LoadAssetWindowSettings(AssetWindow.ShoppingList)
        UserAssetWindowDefaultSettings = AllSettings.LoadAssetWindowSettings(AssetWindow.DefaultView)

        ' Display to the user any issues with ESI endpoints
        Call SetProgress("Checking Status of ESI...")
        Call ESIData.GetESIStatus()
        If Not UserApplicationSettings.SupressESIStatusMessages Then
            Call DisplayESIStatusMessages()
        End If

        ' Load the default character data
        Call SetProgress("Loading Character Data from ESI...")
        Call LoadCharacter(UserApplicationSettings.LoadAssetsonStartup, UserApplicationSettings.LoadBPsonStartup)
        Call LoadCharacterNamesinMenu()

        ' Type of skills loaded
        Call UpdateSkillPanel()

        ' Update System Cost Indicies
        If UserApplicationSettings.LoadESISystemCostIndiciesDataonStartup Then
            Application.UseWaitCursor = True
            Call SetProgress("Updating Industry System Indicies...")
            Application.DoEvents()
            Call ESIData.UpdateIndustrySystemsCostIndex()
            Application.UseWaitCursor = False
            Application.DoEvents()
        End If

        DBCommand = Nothing

        ' ESI Market Data
        If UserApplicationSettings.LoadESIMarketDataonStartup Then
            Application.UseWaitCursor = True
            Application.DoEvents()
            Call SetProgress("Updating Avg/Adj Market Prices...")
            Call ESIData.UpdateAdjAvgMarketPrices()
            Application.UseWaitCursor = False
            Application.DoEvents()
        End If

        ' Refresh Public Structures
        If UserApplicationSettings.LoadESIPublicStructuresonStartup And SelectedCharacter.PublicStructuresAccess Then
            Application.UseWaitCursor = True
            Application.DoEvents()
            Call SetProgress("Updating Public Structures Data...")
            Call ESIData.UpdatePublicStructureswithMarkets()
            Application.UseWaitCursor = False
            Application.DoEvents()
        End If

        If TestingVersion Then
            Me.Text = Me.Text & " - Testing"
        End If

        If Developer Then
            Me.Text = Me.Text & " - Developer"
        Else
            ' Hide all the development stuff
        End If

        ' Load all the forms' facilities
        Call LoadFacilities()

        ' Init Tool tips
        If UserApplicationSettings.ShowToolTips Then
            Me.ttBP = New ToolTip(Me.components)
            Me.ttBP.IsBalloon = True
        End If

        ' Nothing in shopping List
        pnlShoppingList.Text = "No Items in Shopping List"

        Call SetProgress("Finalizing Forms...")

        '****************************************
        '**** Blueprints Tab Initializations ****
        '****************************************

        Call InitBPTab()

        ' Base Decryptor
        SelectedDecryptor.MEMod = 0
        SelectedDecryptor.TEMod = 0
        SelectedDecryptor.RunMod = 0
        SelectedDecryptor.ProductionMod = 1
        SelectedDecryptor.Name = None

        ' For the disabling of the price update form
        PriceCheckT1Enabled = True
        PriceCheckT2Enabled = True
        PriceCheckT3Enabled = True
        PriceCheckT4Enabled = True
        PriceCheckT5Enabled = True
        PriceCheckT6Enabled = True

        ' Tool Tips
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblBPCanMakeBP, "Double-Click here to see required skills to make this BP")
        End If

        '*******************************************
        '**** Update Prices Tab Initializations ****
        '*******************************************
        ' Create the controls collection class
        m_ControlsCollection = New ControlsCollection(Me)
        ' Get Region check boxes (note index starts at 1)
        SystemCheckBoxes = DirectCast(ControlArrayUtils.getControlArray(Me, Me.MyControls, "chkSystems"), MetroFramework.Controls.MetroRadioButton())

        ' Columns of Update Prices Listview (width = 639) + 21 for scroll = 660
        lstPricesView.Columns.Add("TypeID", 0, HorizontalAlignment.Left) ' Hidden
        lstPricesView.Columns.Add("Group", 220, HorizontalAlignment.Left)
        lstPricesView.Columns.Add("Item", 319, HorizontalAlignment.Left)
        lstPricesView.Columns.Add("Price", 100, HorizontalAlignment.Right)
        lstPricesView.Columns.Add("Manufacture", 0, HorizontalAlignment.Right) ' Hidden
        lstPricesView.Columns.Add("Market ID", 0, HorizontalAlignment.Right) ' Hidden
        lstPricesView.Columns.Add("Price Type", 0, HorizontalAlignment.Right) ' Hidden

        FirstSolarSystemComboLoad = True
        FirstPriceChargeTypesComboLoad = True
        FirstPriceShipTypesComboLoad = True
        IgnoreSystemCheckUpdates = False

        PriceTypeUpdate = False
        PriceSystemUpdate = False
        PriceRegionUpdate = False
        PriceModifierUpdate = False
        PreviousPriceType = ""
        PreviousRegion = ""
        PreviousSystem = ""
        PreviousPriceMod = ""
        TabPressed = False
        UpdatingCombo = False

        PPRawSystemsLoaded = False
        PPItemsSystemsLoaded = False

        PriceHistoryUpdateCount = 0
        PriceOrdersUpdateCount = 0
        CancelUpdatePrices = False
        CancelManufacturingTabCalc = False
        CancelThreading = False

        Call InitUpdatePricesTab()

        '****************************************
        '**** Manufacturing Tab Initializations ****
        '****************************************

        ' Add the columns based on settings
        Call RefreshManufacturingTabColumns()

        If UserApplicationSettings.ShowToolTips Then
            ' Decryptor Tool tips
            ttUpdatePrices.SetToolTip(txtCalcProdLines, "Will assume Number of BPs is same as Number of Production lines for Calculations")
            ttUpdatePrices.SetToolTip(txtCalcProdLines, "Enter the number of Manufacturing Lines you have to build items per day for calculations. Calculations will assume the same number of BPs used." & vbCrLf & "Calculations for components will also use this value. Double-Click to enter max runs for this character.")
            ttUpdatePrices.SetToolTip(txtCalcLabLines, "Enter the number of Laboratory Lines you have to invent per day for calculations. Double-Click to enter max runs for this character.")

        End If
        FirstLoadCalcBPTypes = True
        FirstManufacturingGridLoad = True

        ' If there is an error in price updates, only show once
        ShownPriceUpdateError = False

        UpdatingStructureIDText = False

        Call InitManufacturingTab()

        '****************************************
        '**** All Tabs **************************
        '****************************************

        ' For indy jobs viewer
        FirstIndustryJobsViewerLoad = True

        ' For handling click events
        UpdatingCheck = False

        ' All set, we are done loading
        FirstLoad = False

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        On Error Resume Next
        EVEDB.CloseDB()
        On Error GoTo 0
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ShowSupportSplash() Then
            Dim f1 As New frmsupportSplash
            f1.ShowDialog()
        End If
    End Sub

    ' If the text file is there, read the counter in it. Only show the splash on the first run and after every 100 uses
    Private Function ShowSupportSplash() As Boolean
        Dim ReturnValue As Boolean = True

        Try
            Dim FilePath As String = Path.Combine(DynamicFilePath, "SupportCounter.txt")

            If File.Exists(FilePath) Then
                ' See what the count is
                Dim fileReader As String
                fileReader = My.Computer.FileSystem.ReadAllText(FilePath)

                Dim Counter As Integer

                If fileReader <> "" Then
                    Counter = CInt(fileReader) + 1
                Else
                    Counter = 1
                End If

                ' If the counter divides evenly by 100, show the form
                If Counter Mod 100 <> 0 Then
                    ReturnValue = False
                End If

                ' Always increment counter
                Call File.Delete(FilePath)
                Call File.Create(FilePath).Dispose()
                Dim tfile As StreamWriter
                tfile = My.Computer.FileSystem.OpenTextFileWriter(FilePath, True)
                tfile.WriteLine(CStr(Counter))
                tfile.Close()

            Else
                ' Make the file for counting
                Call File.Create(FilePath).Dispose()
                Dim objWriter As New StreamWriter(FilePath)
                objWriter.Write("1")
                objWriter.Close()
            End If

        Catch ex As Exception
            ReturnValue = False
        End Try

        Return ReturnValue

    End Function

    Public ReadOnly Property MyControls() As Collection
        Get
            Return m_ControlsCollection.Controls
        End Get
    End Property

    ' Loads up the facilities for the selected character
    Public Sub LoadFacilities(Optional FacilityLocation As ProgramLocation = Nothing, Optional FacilityType As ProductionType = ProductionType.None)

        ' See what ID we use for the facilities
        Dim CharID As Long = 0
        If UserApplicationSettings.SaveFacilitiesbyChar Then
            ' Use the ID sent
            CharID = SelectedCharacter.ID
        Else
            CharID = CommonLoadBPsID
        End If

        If FacilityType = ProductionType.None Then
            ' Load up the Manufacturing tab facilities
            Call CalcBaseFacility.InitializeControl(FacilityView.LimitedControls, CharID, ProgramLocation.ManufacturingTab, ProductionType.Manufacturing, Me)

        Else ' Multi-save
            ' They saved a facility on the manufacturing tab, so init all the facilities on the bp tab and reload the current facility
            Select Case FacilityType
                Case ProductionType.Manufacturing
                    Call CalcBaseFacility.InitializeControl(FacilityView.LimitedControls, CharID, ProgramLocation.ManufacturingTab, ProductionType.Manufacturing, Me)
            End Select
        End If

    End Sub

    ' Checks the status of ESI since last updated and displays any messageboxes on yellow or red endpoints
    Private Sub DisplayESIStatusMessages()
        Dim SQL As String = ""
        Dim rsStatus As SQLiteDataReader

        Dim CharacterTokenData As SavedTokenData = SelectedCharacter.CharacterTokenData

        SQL = "SELECT scope, status, purpose FROM ESI_STATUS_ITEMS, ESI_ENDPOINT_ROUTE_TO_SCOPE WHERE route = endpoint_route"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsStatus = DBCommand.ExecuteReader

        While rsStatus.Read
            ' Read through each status and show only those that they have scopes for
            With CharacterTokenData.Scopes
                ' Required
                If rsStatus.GetString(0) = ESI.ESICharacterSkillsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                ' Personal Scopes
                If .Contains(ESI.ESICharacterWalletScope) And rsStatus.GetString(0) = ESI.ESICharacterWalletScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICharacterIndustryJobsScope) And rsStatus.GetString(0) = ESI.ESICharacterIndustryJobsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICharacterStandingsScope) And rsStatus.GetString(0) = ESI.ESICharacterStandingsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICharacterResearchAgentsScope) And rsStatus.GetString(0) = ESI.ESICharacterResearchAgentsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICharacterBlueprintsScope) And rsStatus.GetString(0) = ESI.ESICharacterBlueprintsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICharacterAssetScope) And rsStatus.GetString(0) = ESI.ESICharacterAssetScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                ' Corporation scopes
                If .Contains(ESI.ESICorporationMembership) And rsStatus.GetString(0) = ESI.ESICorporationMembership And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICorporationIndustryJobsScope) And rsStatus.GetString(0) = ESI.ESICorporationIndustryJobsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICorporationBlueprintsScope) And rsStatus.GetString(0) = ESI.ESICorporationBlueprintsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESICorporationAssetScope) And rsStatus.GetString(0) = ESI.ESICorporationAssetScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                ' Structures
                If .Contains(ESI.ESIUniverseStructuresScope) And rsStatus.GetString(0) = ESI.ESIUniverseStructuresScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If

                If .Contains(ESI.ESIStructureMarketsScope) And rsStatus.GetString(0) = ESI.ESIStructureMarketsScope And rsStatus.GetString(1) <> "green" Then
                    Call DisplayESIStatusMessage(rsStatus.GetString(1), rsStatus.GetString(0), rsStatus.GetString(2))
                End If
            End With


        End While

    End Sub

    Private Sub DisplayESIStatusMessage(Status As String, Scope As String, Purpose As String)
        Select Case Status
            Case "yellow"
                MsgBox("ESI is experincing issues with the " & Scope & " scope " & Purpose & " and you may not have access to certain data until fixed.")
            Case "red"
                MsgBox("The " & Scope & " ESI scope is down and will not be able to " & Purpose & ". You may not have access to certain data until fixed.")
            Case Else
                Application.DoEvents()
        End Select
    End Sub

#End Region

#Region "Form Functions/Procedures"

#Region "Tool Tip Processing"

    ' Manufacturing Tab
    Private Sub lblCalcColorCode1_MouseEnter(sender As Object, e As System.EventArgs)
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblCalcColorCode1, "Beige Background: Owned Blueprint")
        End If
    End Sub

    Private Sub lblCalcColorCode2_MouseEnter(sender As System.Object, e As System.EventArgs)
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblCalcColorCode2, "Light Blue Background: T2 item with Owned T1 Blueprint (for invention)")
        End If
    End Sub

    Private Sub lblCalcColorCode3_MouseEnter(sender As System.Object, e As System.EventArgs)
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblCalcColorCode3, "Green Text: Unable to T3 Invent Item")
        End If
    End Sub

    Private Sub lblCalcColorCode4_MouseEnter(sender As System.Object, e As System.EventArgs)
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblCalcColorCode4, "Orange Text: Unable to Invent Item")
        End If
    End Sub

    Private Sub lblCalcColorCode5_MouseEnter(sender As System.Object, e As System.EventArgs)
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblCalcColorCode5, "Red Text: Unable to Build Item")
        End If
    End Sub

    Private Sub lblCalcColorCode6_MouseEnter(sender As System.Object, e As System.EventArgs)
        If UserApplicationSettings.ShowToolTips Then
            ttBP.SetToolTip(lblCalcColorCode6, "Green Background: Corp Owned Blueprint")
        End If
    End Sub

#End Region

#Region "SVR Functions"

    ' Determine the Sales per Volume Ratio, which will be the amount of items we can build in 24 hours (include fractions) when sent the region, avg days, and production time in seconds to make ItemsProduced (runs * portion size)
    Public Function GetItemSVR(TypeID As Long, RegionID As Long, AvgDays As Integer, ProductionTimeSeconds As Double,
                               ItemsProduced As Long) As String
        Dim SQL As String
        Dim readerAverage As SQLiteDataReader
        Dim ItemsperDay As Double

        ' The amount of items we can build in 24 hours (include fractions) divided by the average volume (volume/avgdays)
        ' The data is stored as a record per day, so just count up the number of records in the time period (days - might not be the same as days shown)
        ' and divide by the sum of the volumes over that time period
        SQL = "SELECT SUM(TOTAL_VOLUME_FILLED)/COUNT(PRICE_HISTORY_DATE) FROM MARKET_HISTORY "
        SQL = SQL & "WHERE TYPE_ID = " & TypeID & " AND REGION_ID = " & RegionID & " "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) >= " & " DateTime('" & Format(DateAdd(DateInterval.Day, -(AvgDays + 1), Date.UtcNow.Date), SQLiteDateFormat) & "') "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) < " & " DateTime('" & Format(Date.UtcNow.Date, SQLiteDateFormat) & "') "
        SQL = SQL & "AND TOTAL_VOLUME_FILLED IS NOT NULL "

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerAverage = DBCommand.ExecuteReader

        readerAverage.Read()

        If Not IsDBNull(readerAverage.GetValue(0)) Then
            If ProductionTimeSeconds <> 0 Then
                ' The number of blueprint runs we can build with the sent production time in a day - Seconds to produce 1, then divide that into seconds per day
                ItemsperDay = (24 * 60 * 60) / (ProductionTimeSeconds / ItemsProduced)
                ' Take the items per day and compare to the avg sales volume per day, if it's greater than one you can't make enough items in a day to meet demand = good item to build
                Return FormatNumber(readerAverage.GetDouble(0) / ItemsperDay, 2)
            Else
                ' Just want the volume for the day
                Return FormatNumber(readerAverage.GetDouble(0), 2)
            End If
        Else
            ' Since 0.00 SVR is possible, return nothing instead
            Return "-"
        End If

    End Function

    ' Updates the SVR value and then returns it as a string for the item associated with the Selected BP
    Private Function GetBPItemSVR(ProductionTime As Double) As String
        Dim MH As New MarketPriceInterface(Nothing)

        Application.UseWaitCursor = True
        Application.DoEvents()
        Dim TypeID As New List(Of Long) ' for just one
        Dim RegionID As Long = GetRegionID(UserApplicationSettings.SVRAveragePriceRegion)

        Call TypeID.Add(SelectedBlueprint.GetItemID)
        PriceHistoryUpdateCount = 0
        If Not MH.UpdateESIPriceHistory(TypeID, RegionID) Then
            Call MsgBox("Some prices did not update. Please try again.", vbInformation, Application.ProductName)
        End If

        'Update SVRAveragePriceDuration to the defualt
        UserApplicationSettings.SVRAveragePriceDuration = ProgramSettings.DefaultSVRAveragePriceDuration

        Dim ReturnValue As String = GetItemSVR(TypeID(0), RegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration), ProductionTime,
                                                SelectedBlueprint.GetTotalUnits)

        Application.UseWaitCursor = False
        Application.DoEvents()

        Return ReturnValue

    End Function

#End Region

    Public Sub LoadCharacterNamesinMenu()
        ' Also, load all characters we have
        Dim rsCharacters As SQLiteDataReader
        Dim SQL As String = "SELECT CHARACTER_NAME, CASE WHEN GENDER IS NULL THEN 'male' ELSE GENDER END AS GENDER "
        SQL = SQL & "FROM ESI_CHARACTER_DATA ORDER BY CHARACTER_NAME"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsCharacters = DBCommand.ExecuteReader

        Dim Counter As Integer = 1

        While rsCharacters.Read And Counter < 21
            ' Add all the character names to the list for the number we have - only load 20 characters
            mnuChar.Items.Add(rsCharacters.GetString(0))
            Counter += 1 ' increment
        End While

        Dim rsCharacter As SQLiteDataReader

        ' See if we have a character ID loaded
        SQL = "SELECT CHARACTER_NAME FROM ESI_CHARACTER_DATA WHERE IS_DEFAULT <> 0"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsCharacter = DBCommand.ExecuteReader
        Dim name As String

        If rsCharacter.Read() Then
            ' Set the base data, character ID and access token data
            name = rsCharacter.GetString(0)
            'Set the current name to the default
            mnuChar.SelectedIndex = mnuChar.FindString(name)

            rsCharacter.Close()

            'Set the default again
            ' Update them all to 0 first
            Call EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = 0")
            Call EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = " & CStr(DefaultCharacterCode) & " WHERE CHARACTER_NAME = '" & FormatDBString(name) & "'")


        Else ' No record in DB
            rsCharacter.Close()
        End If



    End Sub

    Private Sub SetCharToolStripImage(ByRef TS As ToolStripMenuItem, ByVal Gender As String)
        If Gender = Male Then
            TS.Image = My.Resources._46_64_1
        Else
            TS.Image = My.Resources._46_64_2
        End If
        TS.ImageTransparentColor = Color.White
    End Sub

    Private Sub LoadSelectedCharacter(ToolStripText As String)
        Cursor.Current = Cursors.WaitCursor
        Call LoadCharacter(ToolStripText)
        ' New character so make sure the facilities reflect that
        Call LoadFacilities()
        Cursor.Current = Cursors.Default
    End Sub

    ' Predicate for finding the BPBuildBuyItem in full list
    Public Function FindBPBBItem(ByVal Item As BPBBItem) As Boolean
        If BPBBItemtoFind = Item.BPID Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Set all the tool strips for characters since I can't process them if they aren't set at runtime
    Private Sub mnuChar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mnuChar.SelectedIndexChanged
        Call LoadSelectedCharacter(mnuChar.Text)
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' After initializing everything, refresh the tabs so they draw fast on first click

        ' Done loading
        Call SetProgress("")

    End Sub

    ' Adds mouse down handlers for all controls of the parent
    Private Sub MouseDownSetting(ByVal parentCtr As Control)
        Dim ctr As Control

        For Each ctr In parentCtr.Controls
            AddHandler ctr.MouseDown, AddressOf MouseDownHandling
            MouseDownSetting(ctr)
        Next

    End Sub

    ' Function to deal with mouse down events to load next or previous blueprint
    Private Sub MouseDownHandling(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    ' Loads a BP sent from a double click on shopping list or manufacturing list, or loading history
    Public Sub LoadBPfromEvent(BPID As Long, BuildType As String, Inputs As String, SentFrom As SentFromLocation,
                                BuildFacility As IndustryFacility, ComponentFacility As IndustryFacility, CapCompentFacility As IndustryFacility,
                                InventionFacility As IndustryFacility, CopyFacility As IndustryFacility,
                                IncludeTaxes As Boolean, BrokerFeeData As BrokerFeeInfo,
                                MEValue As String, TEValue As String, SentRuns As String,
                                ManufacturingLines As String, LaboratoryLines As String, NumBPs As String,
                                AddlCosts As String, PPUCheck As Boolean,
                                Optional CompareType As String = "", Optional T2T3MatType As BuildMatType = Nothing)
        Dim BPTech As Integer
        Dim DecryptorName As String = None
        Dim BPDecryptor As New Decryptor
        Dim readerBP As SQLiteDataReader
        Dim readerRelic As SQLiteDataReader
        Dim SQL As String
        Dim AdjustedRuns As Integer = 0

        Dim TempLines As Integer = CInt(ManufacturingLines)

        SQL = "SELECT BLUEPRINT_NAME, TECH_LEVEL, PORTION_SIZE FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID = " & BPID

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerBP = DBCommand.ExecuteReader

        readerBP.Read()
        RemoveHandler cmbBPBlueprintSelection.TextChanged, AddressOf cmbBPBlueprintSelection_TextChanged
        cmbBPBlueprintSelection.Text = readerBP.GetString(0)
        SelectedBPText = readerBP.GetString(0)
        AddHandler cmbBPBlueprintSelection.TextChanged, AddressOf cmbBPBlueprintSelection_TextChanged
        BPTech = readerBP.GetInt32(1)
        If SentFrom = SentFromLocation.BlueprintTab Then
            AdjustedRuns = CInt(Math.Ceiling(CInt(SentRuns) / readerBP.GetInt64(2)))
        Else
            AdjustedRuns = CInt(SentRuns)
        End If

        If BPTech = BPTechLevel.T2 Or BPTech = BPTechLevel.T3 Then
            ' Set the decryptor
            If Inputs <> None Then
                If Not CBool(InStr(Inputs, "No Decryptor")) Then
                    If BPTech = 2 Then
                        DecryptorName = Inputs
                    ElseIf InStr(Inputs, "|") <> 0 Then ' For T3
                        DecryptorName = Inputs.Substring(0, InStr(Inputs, "|") - 1)
                    ElseIf InStr(Inputs, " - ") <> 0 Then
                        DecryptorName = Inputs.Substring(0, InStr(Inputs, "-") - 2)
                    End If
                End If
            End If

            If BPTech = 3 Then
                LoadingT3Decryptors = True
                LoadingT3Decryptors = False

                ' Also load the relic
                LoadingRelics = True
                Dim TempRelic As String = ""
                If InStr(Inputs, "|") <> 0 Then ' For T3
                    TempRelic = Inputs.Substring(InStr(Inputs, "|")) ' Removed the -1 in the substring it was including | in the SQL Query
                ElseIf InStr(Inputs, " - ") <> 0 Then
                    TempRelic = Inputs.Substring(InStr(Inputs, "-") + 1)
                End If

                SQL = "SELECT typeName FROM INVENTORY_TYPES, INDUSTRY_ACTIVITY_PRODUCTS WHERE productTypeID =" & BPID & " "
                SQL = SQL & "And typeID = blueprintTypeID And activityID = 8 And typeName Like '%" & TempRelic & "%'"

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                readerRelic = DBCommand.ExecuteReader
                readerRelic.Read()
                LoadingRelics = False
                RelicsLoaded = False ' Allow reload on drop down

            Else ' T2
                ' Check the include cost/time
                If Inputs <> "Unknown" Then ' Unknown inputs is T2 BPO or pre-industry patch
                    LoadingInventionDecryptors = True
                    LoadingInventionDecryptors = False
                End If

            End If

        End If

        UpdatingCheck = True
        UpdatingCheck = False

        ' Set the optimize check
        UpdatingCheck = True
        UpdatingCheck = False

        readerBP.Close()

        ' Finally, load the blueprint with data in the row selected like it was just selected
        Call SelectBlueprint(True, SentFrom, True)

    End Sub

    ' Loads the popup with all the costs for total raw
    Private Sub lblBPRawTotalCost_DoubleClick(sender As Object, e As System.EventArgs)
        Call ShowCostSplitViewer(SelectedBlueprint.GetRawMaterials.GetTotalMaterialsCost, "Raw")
    End Sub

    ' Loads the popup with all the costs for total components
    Private Sub lblBPTotalCompCost_DoubleClick(sender As Object, e As System.EventArgs)
        Call ShowCostSplitViewer(SelectedBlueprint.GetComponentMaterials.GetTotalMaterialsCost, "Component")
    End Sub

    ' Loads the popup with all the costs for the material cost sent
    Private Sub ShowCostSplitViewer(MaterialsCost As Double, MaterialType As String)
        Dim f1 As New frmCostSplitViewer
        Dim RawCostSplit As CostSplit

        ' Fill up the array to display
        If Not IsNothing(SelectedBlueprint) Then
            f1.CostSplitType = "Total " & MaterialType & " Material Cost Split"
            ' Mat cost
            RawCostSplit.SplitName = MaterialType & " Materials Cost"
            RawCostSplit.SplitValue = MaterialsCost
            f1.CostSplits.Add(RawCostSplit)

            ' Add reaction usage if it's a reaction for main bp
            If ReactionTypes.Contains(SelectedBlueprint.GetItemData.GetMaterialGroup) Then
                RawCostSplit.SplitName = "Reaction Facility Usage"
                RawCostSplit.SplitValue = SelectedBlueprint.GetReactionFacilityUsage
            Else
                ' Manufacturing Facility usage
                RawCostSplit.SplitName = "Manufacturing Facilities Usage"
                RawCostSplit.SplitValue = SelectedBlueprint.GetManufacturingFacilityUsage
            End If

            f1.CostSplits.Add(RawCostSplit)

            If (SelectedBlueprint.HasComponents) Or MaterialType = "Raw" Then
                If ReactionTypes.Contains(SelectedBlueprint.GetItemData.GetMaterialGroup) Then
                    ' Reactions Facility Usage
                    If SelectedBlueprint.GetTotalReactionFacilityUsage - SelectedBlueprint.GetReactionFacilityUsage > 0 Then
                        RawCostSplit.SplitName = "Component Reaction Facilities Usage"
                        RawCostSplit.SplitValue = SelectedBlueprint.GetTotalReactionFacilityUsage - SelectedBlueprint.GetReactionFacilityUsage
                        f1.CostSplits.Add(RawCostSplit)
                    End If
                    ' Manufacturing Facility usage for fuel blocks
                    RawCostSplit.SplitName = "Manufacturing Facilities Usage"
                    RawCostSplit.SplitValue = SelectedBlueprint.GetManufacturingFacilityUsage
                    f1.CostSplits.Add(RawCostSplit)
                End If

                ' The reaction blueprint won't have components or cap components
                If Not ReactionTypes.Contains(SelectedBlueprint.GetItemData.GetMaterialGroup) Then
                    ' Component Facility Usage
                    RawCostSplit.SplitName = "Component Facilities Usage"
                    RawCostSplit.SplitValue = SelectedBlueprint.GetComponentFacilityUsage
                    f1.CostSplits.Add(RawCostSplit)

                    ' Capital Component Facility Usage
                    Select Case SelectedBlueprint.GetItemGroupID
                        Case ItemIDs.TitanGroupID, ItemIDs.SupercarrierGroupID, ItemIDs.CarrierGroupID, ItemIDs.DreadnoughtGroupID,
                        ItemIDs.JumpFreighterGroupID, ItemIDs.FreighterGroupID, ItemIDs.IndustrialCommandShipGroupID, ItemIDs.CapitalIndustrialShipGroupID, ItemIDs.FAXGroupID
                            ' Only add cap component usage for ships that use them
                            RawCostSplit.SplitName = "Capital Component Facilities Usage"
                            RawCostSplit.SplitValue = SelectedBlueprint.GetCapComponentFacilityUsage
                            f1.CostSplits.Add(RawCostSplit)
                    End Select
                End If
            End If

            ' Taxes
            RawCostSplit.SplitName = "Taxes"
            RawCostSplit.SplitValue = SelectedBlueprint.GetSalesTaxes
            f1.CostSplits.Add(RawCostSplit)

            ' Broker fees
            RawCostSplit.SplitName = "Broker Fees"
            RawCostSplit.SplitValue = SelectedBlueprint.GetSalesBrokerFees
            f1.CostSplits.Add(RawCostSplit)

            ' Additional Costs the user added
            If SelectedBlueprint.GetAdditionalCosts <> 0 Then
                RawCostSplit.SplitName = "Additional Costs"
                RawCostSplit.SplitValue = SelectedBlueprint.GetAdditionalCosts
                f1.CostSplits.Add(RawCostSplit)
            End If

            If SelectedBlueprint.GetTechLevel <> BPTechLevel.T1 Then
                ' Total Invention Costs
                RawCostSplit.SplitName = "Invention Costs"
                RawCostSplit.SplitValue = SelectedBlueprint.GetInventionCost
                f1.CostSplits.Add(RawCostSplit)

                RawCostSplit.SplitName = "Invention Usage"
                RawCostSplit.SplitValue = SelectedBlueprint.GetInventionUsage
                f1.CostSplits.Add(RawCostSplit)

                ' Total Copy Costs
                RawCostSplit.SplitName = "Copy Costs"
                RawCostSplit.SplitValue = SelectedBlueprint.GetCopyCost
                f1.CostSplits.Add(RawCostSplit)

                RawCostSplit.SplitName = "Copy Usage"
                RawCostSplit.SplitValue = SelectedBlueprint.GetCopyUsage
                f1.CostSplits.Add(RawCostSplit)
            End If

            f1.Show()

        End If

    End Sub

    ' Clears the BP history (forward / back) functionality
    Private Sub mnuClearBPHistory_Click(sender As System.Object, e As System.EventArgs) Handles mnuClearBPHistory.Click
        BPHistory = New List(Of BPHistoryItem)
        ' Reset the index
        CurrentBPHistoryIndex = -1
    End Sub

    ' Menu update to show the patch notes
    Private Sub mnuPatchNotes_Click(sender As System.Object, e As System.EventArgs) Handles mnuPatchNotes.Click
        Dim f1 As New frmPatchNotes

        Application.UseWaitCursor = True
        Application.DoEvents()

        f1.Show()

    End Sub

    Private Sub mnuViewESIStatus_Click(sender As Object, e As EventArgs) Handles mnuViewESIStatus.Click
        Dim f1 As New frmESIStatus

        f1.Show()
    End Sub

    ' Full reset - will delete all data downloaded, updated, or otherwise set by the user
    Private Sub mnuResetAllData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResetAllData.Click
        Dim Response As MsgBoxResult
        Dim SQL As String

        Response = MsgBox("This will reset all data for the program including ESI Tokens, Blueprints, Assets, Industry Jobs, and Price data." & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            SQL = "DELETE FROM ESI_CHARACTER_DATA"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM ESI_CORPORATION_DATA"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM CHARACTER_STANDINGS"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM CHARACTER_SKILLS"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM OWNED_BLUEPRINTS"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM ITEM_PRICES_CACHE"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM ASSETS"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM INDUSTRY_JOBS"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM CURRENT_RESEARCH_AGENTS"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = 0"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM MARKET_HISTORY"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM MARKET_HISTORY_UPDATE_CACHE"
            EVEDB.ExecuteNonQuerySQL(SQL)

            ' Reset all the cache dates
            Call ResetESIDates()

            ' Reset ESI data
            Call ResetESIIndustrySystemIndicies()
            Call ResetESIAdjustedMarketPrices()

            FirstLoad = True ' Temporarily just to get screen to show correctly

            Application.UseWaitCursor = False
            Application.DoEvents()

            Call SelectedCharacter.LoadDummyCharacter(True)

            MsgBox("All Data Reset", vbInformation, Application.ProductName)

            ' Need to set a default, open that form
            Dim f2 = New frmSetCharacterDefault
            f2.ShowDialog()

            Call LoadCharacterNamesinMenu()

            ' Reset the tabs
            Call ResetTabs()

            FirstLoad = False

        End If

    End Sub

    Private Sub mnuResetPriceData_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetPriceData.Click
        Dim Response As MsgBoxResult
        Dim SQL As String

        Response = MsgBox("This will reset all stored price data for this character." & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            SQL = "DELETE FROM ITEM_PRICES_CACHE"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM MARKET_HISTORY"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM MARKET_HISTORY_UPDATE_CACHE"
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = 0"
            EVEDB.ExecuteNonQuerySQL(SQL)

            Application.UseWaitCursor = False
            Application.DoEvents()

            MsgBox("Prices reset", vbInformation, Application.ProductName)

        End If

        Call UpdateProgramPrices()

    End Sub

    Private Sub mnuResetESIDates_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetESIDates.Click
        Call ResetESIDates()
    End Sub

    Private Sub ResetESIDates()
        Dim SQL As String

        ' Simple update, just set all the ESI cache dates to null
        SQL = "DELETE FROM ESI_PUBLIC_CACHE_DATES"
        EVEDB.ExecuteNonQuerySQL(SQL)

        MsgBox("ESI cache dates reset", vbInformation, Application.ProductName)

    End Sub

    Private Sub ResetESIIndustrySystemIndicies()

        ' Simple update, just set all the ESI cache dates to null
        Call EVEDB.ExecuteNonQuerySQL("UPDATE ESI_PUBLIC_CACHE_DATES SET INDUSTRY_SYSTEMS_CACHED_UNTIL = NULL")

        MsgBox("ESI Industry System Indicies reset", vbInformation, Application.ProductName)

    End Sub

    Public Sub ResetESIAdjustedMarketPrices()

        ' Simple update, just set all the data back to zero
        Call EVEDB.ExecuteNonQuerySQL("UPDATE ITEM_PRICES_FACT SET ADJUSTED_PRICE = 0, AVERAGE_PRICE = 0")
        Call EVEDB.ExecuteNonQuerySQL("UPDATE ESI_PUBLIC_CACHE_DATES SET MARKET_PRICES_CACHED_UNTIL = NULL")

        MsgBox("ESI Adjusted Market Prices reset", vbInformation, Application.ProductName)

    End Sub

    Private Sub mnuResetESIPublicStructures_Click(sender As Object, e As EventArgs) Handles mnuResetESIPublicStructures.Click
        ' Delete all the public structures
        Call ResetPublicStructureData()
        Call EVEDB.ExecuteNonQuerySQL("UPDATE ESI_PUBLIC_CACHE_DATES SET PUBLIC_STRUCTURES_CACHED_UNTIL = NULL")

        MsgBox("ESI Public Structure data reset", vbInformation, Application.ProductName)

    End Sub

    Private Sub mnuResetMarketOrders_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetMarketOrders.Click

        Application.UseWaitCursor = True
        Application.DoEvents()

        ' Simple update, just set all the data back to zero
        Call EVEDB.ExecuteNonQuerySQL("DELETE FROM MARKET_ORDERS_UPDATE_CACHE")
        Call EVEDB.ExecuteNonQuerySQL("DELETE FROM MARKET_ORDERS")
        Call EVEDB.ExecuteNonQuerySQL("DELETE FROM STRUCTURE_MARKET_ORDERS_UPDATE_CACHE")
        Call EVEDB.ExecuteNonQuerySQL("DELETE FROM STRUCTURE_MARKET_ORDERS")

        MsgBox("Market Orders reset", vbInformation, Application.ProductName)

        Application.UseWaitCursor = False
        Application.DoEvents()
    End Sub

    Private Sub mnuResetMarketHistory_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetMarketHistory.Click

        Application.UseWaitCursor = True
        Application.DoEvents()

        ' Simple update, just set all the data back to zero
        Call EVEDB.ExecuteNonQuerySQL("DELETE FROM MARKET_HISTORY_UPDATE_CACHE")
        Call EVEDB.ExecuteNonQuerySQL("DELETE FROM MARKET_HISTORY")

        MsgBox("Market History reset", vbInformation, Application.ProductName)

        Application.UseWaitCursor = False
        Application.DoEvents()
    End Sub

    Private Sub mnuResetBlueprintData_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetBlueprintData.Click
        Dim Response As MsgBoxResult

        Response = MsgBox("This will reset all blueprints for this character" & Environment.NewLine & "deleting all scanned data and stored ME/TE values." & Environment.NewLine & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            Call ResetAllBPData()

            Application.UseWaitCursor = False
            Application.DoEvents()

        End If

    End Sub

    Private Sub mnuResetAgents_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetAgents.Click
        Dim Response As MsgBoxResult
        Dim SQL As String

        Response = MsgBox("This will reset all stored Research Agents for this character." & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            SQL = "DELETE FROM CURRENT_RESEARCH_AGENTS WHERE CHARACTER_ID =" & SelectedCharacter.ID
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "UPDATE ESI_CHARACTER_DATA SET RESEARCH_AGENTS_CACHE_DATE = NULL WHERE CHARACTER_ID = " & CStr(SelectedCharacter.ID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            Application.UseWaitCursor = False
            Application.DoEvents()

            MsgBox("Research Agents reset", vbInformation, Application.ProductName)
        End If

    End Sub

    Private Sub mnuResetIndustryJobs_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetIndustryJobs.Click
        Dim Response As MsgBoxResult
        Dim SQL As String

        Response = MsgBox("This will reset all stored Industry Jobs for this character." & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            SQL = "DELETE FROM INDUSTRY_JOBS WHERE InstallerID =" & SelectedCharacter.ID & " AND JobType =" & ScanType.Personal
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "UPDATE ESI_CHARACTER_DATA SET INDUSTRY_JOBS_CACHE_DATE = NULL WHERE CHARACTER_ID =" & CStr(SelectedCharacter.ID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            Application.UseWaitCursor = False
            Application.DoEvents()

            MsgBox("Industry Jobs reset", vbInformation, Application.ProductName)
        End If

    End Sub

    Private Sub mnuResetIgnoredBPs_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetIgnoredBPs.Click
        Dim Response As MsgBoxResult
        Dim SQL As String

        Response = MsgBox("This will reset all blueprints to non-ignored" & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            SQL = "UPDATE ALL_BLUEPRINTS_FACT SET IGNORE = 0"
            EVEDB.ExecuteNonQuerySQL(SQL)

            Application.UseWaitCursor = False
            Application.DoEvents()

            MsgBox("Ignored Blueprints reset", vbInformation, Application.ProductName)
        End If
    End Sub

    Private Sub mnuResetAssets_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetAssets.Click
        Dim Response As MsgBoxResult
        Dim SQL As String

        Response = MsgBox("This will reset all stored Assets for this character." & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            ' Personal
            SQL = "DELETE FROM ASSETS WHERE ID =" & SelectedCharacter.ID
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "UPDATE ESI_CHARACTER_DATA SET ASSETS_CACHE_DATE = NULL WHERE CHARACTER_ID =" & CStr(SelectedCharacter.ID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            ' Corp
            SQL = "DELETE FROM ASSETS WHERE ID =" & SelectedCharacter.CharacterCorporation.CorporationID
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "UPDATE ESI_CORPORATION_DATA SET ASSETS_CACHE_DATE = NULL WHERE CORPORATION_ID =" & CStr(SelectedCharacter.CharacterCorporation.CorporationID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            ' Reload the asset variables for the character, which will load nothing but clear the assets out
            Call SelectedCharacter.GetAssets().LoadAssets(SelectedCharacter.ID, SelectedCharacter.CharacterTokenData, UserApplicationSettings.LoadAssetsonStartup)
            Call SelectedCharacter.CharacterCorporation.GetAssets().LoadAssets(SelectedCharacter.CharacterCorporation.CorporationID, SelectedCharacter.CharacterTokenData, UserApplicationSettings.LoadAssetsonStartup)

            Application.UseWaitCursor = False
            Application.DoEvents()

            MsgBox("Assets reset", vbInformation, Application.ProductName)
        End If

    End Sub

    Private Sub mnuCurrentIndustryJobs_Click(sender As System.Object, e As System.EventArgs) Handles mnuCurrentIndustryJobs.Click
        Dim f1 As New frmIndustryJobsViewer
        f1.Show()
    End Sub

    Private Sub mnuResetESIMarketPrices_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetESIMarketPrices.Click
        Call ResetESIAdjustedMarketPrices()
    End Sub

    Private Sub mnuResetESIIndustryFacilities_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetESIIndustryFacilities.Click
        Call ResetESIIndustrySystemIndicies()
    End Sub

    Private Sub mnuSelectionAddChar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectionAddChar.Click

        ' Open up the default select box here
        Dim f1 = New frmAddCharacter
        f1.ShowDialog()

        Call LoadCharacterNamesinMenu()

        ' Reinit form
        Call ResetTabs()

    End Sub

    Private Sub mnuSelectionManageCharacters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectionManageCharacters.Click
        Dim f1 As New frmManageAccounts

        Call f1.ShowDialog()

        ' Default character set, now set the panel if it changed
        If SelectedCharacter.Name <> mnuChar.SelectedText Then
            ' If we returned, we got a default character set
            Call ResetTabs()
            Call LoadCharacterNamesinMenu()
        End If

    End Sub

    Private Sub mnuChangeDummyCharacterName_Click(sender As Object, e As EventArgs) Handles mnuChangeDummyCharacterName.Click
        Dim f1 As New frmChangeDummyCharacter

        f1.ShowDialog()

        If SelectedCharacter.ID = DummyCharacterID Then
            ' Reload with new information
            SelectedCharacter.LoadDefaultCharacter(False, False, True)
            Call LoadCharacterNamesinMenu()
        End If
    End Sub

    Private Sub mnuCheckforUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckforUpdates.Click
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Call CheckForUpdates(True, Me.Icon)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnCancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelUpdate.Click
        CancelUpdatePrices = True
    End Sub

    Private Sub mnuSelectionExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSelectionExit.Click
        End
    End Sub

    Private Sub mnuSelectionShoppingList_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectionShoppingList.Click
        Call ShowShoppingList()
    End Sub

    Private Sub mnuViewAssets_Click(sender As Object, e As EventArgs) Handles mnuViewAssets.Click
        ' Make sure it's not disposed
        If IsNothing(frmDefaultAssets) Then
            ' Make new form
            frmDefaultAssets = New frmAssetsViewer(AssetWindow.DefaultView)
        Else
            If frmDefaultAssets.IsDisposed Then
                ' Make new form
                frmDefaultAssets = New frmAssetsViewer(AssetWindow.DefaultView)
            End If
        End If

        ' Now open the Asset List
        frmDefaultAssets.Show()
        frmDefaultAssets.Focus()

        Application.DoEvents()
    End Sub

    Private Sub mnuManageBlueprintsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManageBlueprintsToolStripMenuItem.Click
        Dim f1 = New frmBlueprintManagement
        f1.Show()
        Call ResetRefresh()
        ' Reload the bp if there is one loaded so we get the most updated bps
        'If Not IsNothing(SelectedBlueprint) Then
        '    Call SelectBlueprint(False)
        'End If
    End Sub

    Private Sub mnuSelectDefaultChar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectDefaultChar.Click
        Dim f1 = New frmSetCharacterDefault
        Dim PreviousChar As String

        PreviousChar = SelectedCharacter.Name
        f1.ShowDialog()
        ' If we returned, we got a default character set
        Call LoadCharacterNamesinMenu()

        ' If they cancel or choose the same one, don't re load everything
        If PreviousChar <> SelectedCharacter.Name Then
            Call ResetTabs()
            Call ResetRefresh()
        End If
    End Sub

    Private Sub pnlShoppingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ShowShoppingList()
    End Sub

    Private Sub mnuSelectionShoppingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ShowShoppingList()
    End Sub

    Private Sub mnuSelectionAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectionAbout.Click
        Dim f1 = New frmAbout
        ' Open the Shopping List
        f1.ShowDialog()
    End Sub

    Private Sub mnuCharacterSkills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCharacterSkills.Click
        Call OpenCharacterSkills()
    End Sub

    Private Sub pnlSkills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call OpenCharacterSkills()
    End Sub

    Private Sub OpenCharacterSkills()
        Dim f1 = New frmCharacterSkills
        ' Open the character screen
        SkillsUpdated = False
        f1.ShowDialog()

        If SkillsUpdated Then
            Call UpdateSkillPanel()
        End If
    End Sub

    Private Sub mnuCharacterStandings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCharacterStandings.Click
        Dim f1 = New frmCharacterStandings
        ' Open the character screen
        f1.ShowDialog()
    End Sub

    Private Sub mnuUserSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUserSettings.Click
        Dim f1 = New frmSettings
        Dim OldFacilitySaveSetting As Boolean = UserApplicationSettings.SaveFacilitiesbyChar

        ' Open the settings form
        f1.ShowDialog()

    End Sub

    Private Sub ShowShoppingList()

        ' Make sure it's not disposed
        If frmShop.IsDisposed Then
            ' Make new form
            frmShop = New frmShoppingList
        End If

        ' First refresh the lists
        frmShop.RefreshLists()

        ' Now open the Shopping List
        frmShop.Show()
        frmShop.Focus()

        Application.DoEvents()

    End Sub

    Private Sub UpdateSkillPanel()
        If UserApplicationSettings.AllowSkillOverride Then
            pnlSkills.ForeColor = Color.Red
            pnlSkills.Text = "Skills Overridden"
        Else
            pnlSkills.ForeColor = Color.Black
            pnlSkills.Text = "Skills Loaded"
        End If
    End Sub

    Public Sub ResetTabs(Optional ResetBPTab As Boolean = True)
        ' Init all forms
        Cursor.Current = Cursors.WaitCursor
        Call InitBPTab(ResetBPTab)
        Call InitManufacturingTab()
        Call InitUpdatePricesTab()

        ' Update skill override
        Call UpdateSkillPanel()

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub mnuRestoreDefaultBP_Click(sender As System.Object, e As System.EventArgs) Handles mnuRestoreDefaultBP.Click
        Call AllSettings.SetDefaultBPSettings()

        ' Also need to reset the shared variables
        UserApplicationSettings.CheckBuildBuy = DefaultSettings.DefaultCheckBuildBuy

        ' Save them
        Call AllSettings.SaveBPSettings(AllSettings.GetBPSettings)
        Call AllSettings.SaveApplicationSettings(UserApplicationSettings)

        ' Load them again
        UserBPTabSettings = AllSettings.LoadBPSettings()
        UserApplicationSettings = AllSettings.LoadApplicationSettings()

        ' Reload the tab
        Call InitBPTab()

        MsgBox("BP Tab Default Settings Restored", vbInformation, Application.ProductName)

    End Sub

    Private Sub mnuRestoreDefaultUpdatePrices_Click(sender As System.Object, e As System.EventArgs) Handles mnuRestoreDefaultUpdatePrices.Click
        Call AllSettings.SetDefaultUpdatePriceSettings()
        ' Save them
        Call AllSettings.SaveUpdatePricesSettings(AllSettings.GetUpdatePricesSettings)
        ' Load them again
        UserUpdatePricesTabSettings = AllSettings.LoadUpdatePricesSettings()

        ' Reload the tab
        Call InitUpdatePricesTab()

        MsgBox("Update Prices Tab Default Settings Restored", vbInformation, Application.ProductName)

    End Sub

    Private Sub mnuRestoreDefaultManufacturing_Click(sender As System.Object, e As System.EventArgs) Handles mnuRestoreDefaultManufacturing.Click
        Call AllSettings.SetDefaultManufacturingSettings()

        ' Also need to reset the shared variables
        UserApplicationSettings.DefaultBPME = DefaultSettings.DefaultSettingME
        UserApplicationSettings.DefaultBPTE = DefaultSettings.DefaultSettingTE

        ' Save them
        Call AllSettings.SaveManufacturingSettings(AllSettings.GetManufacturingSettings)
        Call AllSettings.SaveApplicationSettings(UserApplicationSettings)

        ' Load them again
        UserManufacturingTabSettings = AllSettings.LoadManufacturingSettings()
        UserApplicationSettings = AllSettings.LoadApplicationSettings()

        ' Reload the tab
        Call InitManufacturingTab()
        ' Also update these shared form variables
        'cmbBPBuildMod.Text = DefaultSettings.DefaultBuildSlotModifier

        MsgBox("Manufacturing Tab Default Settings Restored", vbInformation, Application.ProductName)

    End Sub

    Private Sub UpdateIndustryFacilitiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuUpdateIndustryFacilities.Click
        Dim ESIData As New ESI
        Dim f1 As New frmStatus

        Application.UseWaitCursor = True
        Call f1.Show()
        Application.DoEvents()

        ' Always do indicies first since facilities has a field it uses
        If ESIData.UpdateIndustrySystemsCostIndex(f1.lblStatus, f1.pgStatus) Then
            MsgBox("Industry System Indicies Updated", vbInformation, Application.ProductName)
        End If

        f1.Dispose()
        Application.UseWaitCursor = False
    End Sub

    Private Sub UpdateMarketPricesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuUpdateESIMarketPrices.Click
        Dim ESIData As New ESI
        Dim f1 As New frmStatus

        Application.UseWaitCursor = True
        Call f1.Show()
        Application.DoEvents()
        If ESIData.UpdateAdjAvgMarketPrices(f1.lblStatus, f1.pgStatus) Then

            ' Update all the prices in the program
            Call UpdateProgramPrices()

            MsgBox("Market Prices Updated", vbInformation, Application.ProductName)
        End If

        f1.Dispose()
        Application.UseWaitCursor = False
    End Sub

    Private Sub mnuUpdateESIPublicStructures_Click(sender As Object, e As EventArgs) Handles mnuUpdateESIPublicStructures.Click
        Dim ESIData As New ESI
        Dim f1 As New frmStatus

        Application.UseWaitCursor = True
        Call f1.Show()
        Application.DoEvents()
        If ESIData.UpdatePublicStructureswithMarkets(f1.lblStatus, f1.pgStatus) Then
            MsgBox("Public Structure Data Updated", vbInformation, Application.ProductName)
        End If

        f1.Dispose()
        Application.UseWaitCursor = False

    End Sub

#End Region

#Region "InlineListUpdate"

    ' Determines where to show the text box when clicking on the list sent
    Private Sub ListClicked(ListRef As ListView, sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim iSubIndex As Integer = 0

        ' Hide the text box when a new line is selected
        txtListEdit.Hide()
        cmbEdit.Hide()

        CurrentRow = ListRef.GetItemAt(e.X, e.Y) ' which listviewitem was clicked
        SelectedGrid = ListRef

        If CurrentRow Is Nothing Then
            Exit Sub
        End If

        CurrentCell = CurrentRow.GetSubItemAt(e.X, e.Y)  ' which subitem was clicked

        ' Determine where the previous and next item boxes will be based on what they clicked - used in tab event handling
        Call SetNextandPreviousCells(ListRef)

        ' See which column has been clicked
        iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell)

        If ListRef.Name <> lstPricesView.Name Then
            ' Set the columns that can be edited, just ME and Price
            If iSubIndex = 2 Or iSubIndex = 3 Then

                If iSubIndex = 2 Then
                    MEUpdate = True
                Else
                    MEUpdate = False
                End If

                If iSubIndex = 3 Then
                    PriceUpdate = True
                Else
                    PriceUpdate = False
                End If

                ' For the update grids in the Blueprint Tab, only show the box if
                ' 1 - If the ME is clicked and it has something other than a '-' in it (meaning no BP)
                ' 2 - If the Price is clicked and the ME box has '-' in it
                If (CurrentRow.SubItems(2).Text <> "-" And MEUpdate) Or (CurrentRow.SubItems(2).Text = "-" And PriceUpdate) Then
                    Call ShowEditBox(ListRef)
                End If

            End If

        ElseIf ListRef.Name = lstPricesView.Name Then ' Price update for update prices and mining grid

            ' Set the columns that can be edited, just Price
            If iSubIndex = 3 Then
                Call ShowEditBox(ListRef)
                PriceUpdate = True
            End If

        End If

    End Sub

    ' For updating the items in the list by clicking on them
    Private Sub ProcessKeyDownEdit(SentKey As Keys, ListRef As ListView)
        Dim SQL As String = ""
        Dim rsData As SQLiteDataReader

        Dim MEValue As String = ""
        Dim PriceValue As Double = 0
        Dim PriceUpdated As Boolean = False

        ' Change blank entry to 0
        If Trim(txtListEdit.Text) = "" Then
            txtListEdit.Text = "0"
        End If

        DataUpdated = False

        ' If they hit enter or tab away, mark the BP as owned in the DB with the values entered
        If (SentKey = Keys.Enter Or SentKey = Keys.ShiftKey Or SentKey = Keys.Tab) And DataEntered Then

            ' Check the input first
            If Not IsNumeric(txtListEdit.Text) And MEUpdate Then
                MsgBox("Invalid ME Value", vbExclamation)
                Exit Sub
            End If

            If Not IsNumeric(txtListEdit.Text) And PriceUpdate Then
                MsgBox("Invalid Price Value", vbExclamation)
                Exit Sub
            End If

            ' Save the data depending on what we are updating
            If MEUpdate Then
                MEValue = txtListEdit.Text
            End If

            If PriceUpdate Then
                PriceValue = CDbl(txtListEdit.Text)
            End If

            ' Now do the update for the grids
            If ListRef.Name <> lstPricesView.Name Then

                ' BP Grid update

                ' Check the numbers, if the same then don't update
                If MEValue = CurrentRow.SubItems(2).Text And PriceValue = CDbl(CurrentRow.SubItems(3).Text) Then
                    ' Skip down
                    GoTo Tabs
                End If

                ' First, see if we are updating an ME or a price, then deal with each separately
                If MEUpdate Then
                    ' First we need to look up the Blueprint ID
                    SQL = "SELECT ALL_BLUEPRINTS.BLUEPRINT_ID, ALL_BLUEPRINTS.BLUEPRINT_NAME, TECH_LEVEL, "
                    SQL = SQL & "CASE WHEN ALL_BLUEPRINTS.FAVORITE IS NULL THEN 0 ELSE ALL_BLUEPRINTS.FAVORITE END AS FAVORITE, IGNORE, "
                    SQL = SQL & "CASE WHEN TE IS NULL THEN 0 ELSE TE END AS BP_TE "
                    SQL = SQL & "FROM ALL_BLUEPRINTS LEFT JOIN OWNED_BLUEPRINTS ON ALL_BLUEPRINTS.BLUEPRINT_ID = OWNED_BLUEPRINTS.BLUEPRINT_ID  "
                    SQL = SQL & "WHERE ITEM_NAME = '" & RemoveItemNameRuns(CurrentRow.SubItems(0).Text) & "'"

                    DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                    rsData = DBCommand.ExecuteReader
                    rsData.Read()

                    ' If they update the ME of the blueprint, then we mark it as Owned and a 0 for TE value, but set the type depending on the bp loaded
                    Dim TempBPType As BPType
                    Dim AdditionalCost As Double
                    Dim TempTE As Integer = rsData.GetInt32(5)

                    If rsData.GetInt64(2) = BPTechLevel.T1 Then
                        ' T1 BPO
                        TempBPType = BPType.Original
                    Else
                        ' Remaining T2 and T3 must be invited
                        TempBPType = BPType.InventedBPC
                    End If

                    AdditionalCost = 0

                    ' If there is no TE for an invented BPC then set it to the base
                    If TempBPType = BPType.InventedBPC And TempTE = 0 Then
                        TempTE = BaseT2T3TE
                    End If

                    Call UpdateBPinDB(rsData.GetInt64(0), rsData.GetString(1), CInt(MEValue), TempTE, TempBPType, CInt(MEValue), 0,
                                      CBool(rsData.GetInt32(3)), CBool(rsData.GetInt32(4)), AdditionalCost)

                    ' Mark the line with white color since it's no longer going to be unowned
                    CurrentRow.BackColor = Color.White

                    rsData.Close()

                Else ' Price per unit update

                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " & CStr(CDbl(txtListEdit.Text)) & ", PRICE_TYPE = 'User' WHERE ITEM_ID = " & GetTypeID(CurrentRow.SubItems(0).Text)
                    Call EVEDB.ExecuteNonQuerySQL(SQL)

                    ' Mark the line text with black incase it is red for no price
                    CurrentRow.ForeColor = Color.Black

                    PriceUpdated = True

                End If

                ' Update the data in the current row
                CurrentRow.SubItems(2).Text = CStr(MEValue)
                CurrentRow.SubItems(3).Text = FormatNumber(PriceValue, 2)

                ' For both ME and Prices, we need to re-calculate the blueprint (hit the Refresh Button) to reflect the new numbers
                ' First save the current grid for locations
                RefreshingGrid = True
                RefreshingGrid = False

            Else
                ' Price Profile update
                Dim RawMat As String
                RawMat = "0"

                ' See if they have the profile set already
                SQL = "SELECT 'X' FROM PRICE_PROFILES WHERE ID = " & CStr(SelectedCharacter.ID) & " "
                SQL = SQL & "AND GROUP_NAME = '" & CurrentRow.SubItems(0).Text & "' "
                SQL = SQL & "AND RAW_MATERIAL = " & RawMat

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsData = DBCommand.ExecuteReader

                If rsData.Read() Then
                    ' Update
                    SQL = "UPDATE PRICE_PROFILES SET "
                    If PriceTypeUpdate Then
                        ' Save current region/system
                        SQL = SQL & "PRICE_TYPE = '" & cmbEdit.Text & "' "
                        CurrentRow.SubItems(1).Text = cmbEdit.Text
                    ElseIf PriceSystemUpdate Then
                        ' Just update system, save others
                        SQL = SQL & "SOLAR_SYSTEM_NAME = '" & cmbEdit.Text & "' "
                        CurrentRow.SubItems(3).Text = cmbEdit.Text
                    ElseIf PriceRegionUpdate Then
                        ' Set region, but set system to all systems (blank)
                        SQL = SQL & "REGION_NAME ='" & cmbEdit.Text & "', SOLAR_SYSTEM_NAME = 'All Systems' "
                        CurrentRow.SubItems(2).Text = cmbEdit.Text
                        CurrentRow.SubItems(3).Text = AllSystems
                    ElseIf PriceModifierUpdate Then
                        Dim PM As Double = CDbl(txtListEdit.Text.Replace("%", "")) / 100
                        SQL = SQL & "PRICE_MODIFIER = " & CStr(PM) & " "
                        CurrentRow.SubItems(4).Text = FormatPercent(PM, 1)
                    End If

                    SQL = SQL & "WHERE ID = " & CStr(SelectedCharacter.ID) & " "
                    SQL = SQL & "AND GROUP_NAME ='" & CurrentRow.SubItems(0).Text & "' "
                    SQL = SQL & "AND RAW_MATERIAL = " & RawMat

                Else
                    ' Insert new record
                    Dim TempPercent As String = CStr(CDbl(CurrentRow.SubItems(4).Text.Replace("%", "")) / 100)
                    SQL = "INSERT INTO PRICE_PROFILES VALUES (" & CStr(SelectedCharacter.ID) & ",'" & CurrentRow.SubItems(0).Text & "','"
                    If PriceTypeUpdate Then
                        ' Save current region/system
                        SQL = SQL & FormatDBString(cmbEdit.Text) & "','" & CurrentRow.SubItems(2).Text & "','" & CurrentRow.SubItems(3).Text & "'," & TempPercent & "," & RawMat & ")"
                        CurrentRow.SubItems(1).Text = cmbEdit.Text
                    ElseIf PriceSystemUpdate Then
                        ' Just update system, save others
                        SQL = SQL & CurrentRow.SubItems(1).Text & "','" & CurrentRow.SubItems(2).Text & "','" & FormatDBString(cmbEdit.Text) & "'," & TempPercent & "," & RawMat & ")"
                        CurrentRow.SubItems(3).Text = cmbEdit.Text
                    ElseIf PriceRegionUpdate Then
                        ' Set region, but set system to all systems (blank)
                        SQL = SQL & CurrentRow.SubItems(1).Text & "','" & FormatDBString(cmbEdit.Text) & "','All Systems'," & TempPercent & "," & RawMat & ")"
                        ' Set the text
                        CurrentRow.SubItems(2).Text = cmbEdit.Text
                        CurrentRow.SubItems(3).Text = AllSystems
                    ElseIf PriceModifierUpdate Then
                        ' Save current region/system/type
                        SQL = SQL & CurrentRow.SubItems(1).Text & "','" & CurrentRow.SubItems(2).Text & "','" & CurrentRow.SubItems(3).Text & "',"
                        Dim PM As Double = CDbl(txtListEdit.Text.Replace("%", "")) / 100
                        SQL = SQL & CStr(PM) & "," & RawMat & ")"
                        CurrentRow.SubItems(4).Text = FormatPercent(PM, 1)
                    End If

                End If

                Call EVEDB.ExecuteNonQuerySQL(SQL)

                ' Reset these
                PriceTypeUpdate = False
                PriceRegionUpdate = False
                PriceSystemUpdate = False
                PreviousPriceType = ""
                PreviousRegion = ""
                PreviousSystem = ""
                PriceUpdated = False

            End If

            ' If we updated a price, then update the program everywhere to be consistent
            If PriceUpdated Then
                IgnoreFocus = True
                Call UpdateProgramPrices(False) ' Don't refresh the grid, we are already updating it
                IgnoreFocus = False
            End If

            ' Play sound to indicate update complete
            If PriceUpdated Then
                Call PlayNotifySound()
            End If

            ' Reset text they entered if tabbed
            If SentKey = Keys.ShiftKey Or SentKey = Keys.Tab Then
                txtListEdit.Text = ""
                cmbEdit.Text = ""
            End If

            If SentKey = Keys.Enter Then
                ' Just refresh and select the current row
                CurrentRow.Selected = True
                txtListEdit.Visible = False
            End If

            ' Data updated, so reset
            DataEntered = False
            DataUpdated = True

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
            Call ShowEditBox(ListRef)
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
            Call ShowEditBox(ListRef)
        End If

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

        If ListRef.Name <> lstPricesView.Name Then

            ' For the update grids in the Blueprint Tab, only show the box if
            ' 1 - If the ME is clicked and it has something other than a '-' in it (meaning no BP)
            ' 2 - If the Price is clicked and the ME box has '-' in it

            ' The next row must be an ME or Price box on the next row 
            ' or a previous ME or price box on the previous row
            If iSubIndex = 2 Or iSubIndex = 3 Then
                ' Set the next and previous ME boxes (subitems)
                ' If the next row ME box is a '-' then the next row cell is Price
                If NextRow.SubItems(2).Text = "-" Then
                    NextCell = NextRow.SubItems.Item(3) ' Next row price box
                Else ' It can be the ME box in the next row
                    NextCell = NextRow.SubItems.Item(2) ' Next row ME box
                End If

                NextCellRow = NextRow

                'If the previous row ME box is a '-' then the previous row is Price
                If PreviousRow.SubItems(2).Text = "-" Then
                    PreviousCell = PreviousRow.SubItems.Item(3) ' Next row price box
                Else ' It can be the ME box in the next row
                    PreviousCell = PreviousRow.SubItems.Item(2) ' Next row ME box
                End If

                PreviousCellRow = PreviousRow

                If iSubIndex = 2 Then
                    MEUpdate = True
                    PriceUpdate = False
                Else
                    MEUpdate = False
                    PriceUpdate = True
                End If

            Else
                NextCell = Nothing
                PreviousCell = Nothing
                CurrentCell = Nothing
            End If

        Else ' Price list 
            ' For this, just go up and down the rows
            NextCell = NextRow.SubItems.Item(3)
            NextCellRow = NextRow
            PreviousCell = PreviousRow.SubItems.Item(3)
            PreviousCellRow = PreviousRow
            PriceUpdate = True
            MEUpdate = False
        End If

    End Sub

    ' Shows the text box on the grid where clicked if enabled
    Private Sub ShowEditBox(ListRef As ListView)

        ' Save the center location of the edit box
        SavedListClickLoc.X = CurrentCell.Bounds.Left + CInt(CurrentCell.Bounds.Width / 2)
        SavedListClickLoc.Y = CurrentCell.Bounds.Top + CInt(CurrentCell.Bounds.Height / 2)

        ' Get the boundry data for the control now
        Dim pTop As Integer = ListRef.Top + CurrentCell.Bounds.Top
        Dim pLeft As Integer = ListRef.Left + CurrentCell.Bounds.Left + 2 ' pad right by 2 to align better
        Dim CurrentParent As Control

        CurrentParent = ListRef.Parent
        ' Look up all locations of parent controls to get the location for the control boundaries when shown
        Do Until CurrentParent.Name = "frmMain"
            pTop = pTop + CurrentParent.Top
            pLeft = pLeft + CurrentParent.Left
            CurrentParent = CurrentParent.Parent
        Loop

        If PriceModifierUpdate Then
            With txtListEdit
                .Hide()
                ' Set the bounds of the control
                .SetBounds(pLeft, pTop, CurrentCell.Bounds.Width, CurrentCell.Bounds.Height)
                .Text = CurrentCell.Text
                .Show()
                If CurrentRow.SubItems(2).Text = txtListEdit.Text Then
                    .TextAlign = HorizontalAlignment.Center
                Else
                    .TextAlign = HorizontalAlignment.Right
                End If

                .Focus()
            End With
            cmbEdit.Visible = False
        Else ' updates on the price profile grids

            Dim rsData As SQLiteDataReader
            Dim SQL As String = ""

            With cmbEdit
                UpdatingCombo = True

                If PriceRegionUpdate Then
                    Call LoadRegionCombo(cmbEdit, CurrentCell.Text)
                    ' Set the bounds of the control
                    .SetBounds(pLeft, pTop, CurrentCell.Bounds.Width, CurrentCell.Bounds.Height)
                    .Show()
                    .Focus()
                Else
                    .Hide()
                    .BeginUpdate()
                    .Items.Clear()
                    If PriceSystemUpdate Then
                        ' Base it off the data in the region cell
                        SQL = "SELECT solarSystemName FROM SOLAR_SYSTEMS, REGIONS "
                        SQL = SQL & "WHERE SOLAR_SYSTEMS.regionID = REGIONS.regionID "
                        SQL = SQL & "AND REGIONS.regionName = '" & PreviousCell.Text & "' "
                        SQL = SQL & "ORDER BY solarSystemName"
                        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                        rsData = DBCommand.ExecuteReader

                        ' Add all systems if it's the system
                        .Items.Add(AllSystems)
                        While rsData.Read
                            .Items.Add(rsData.GetString(0))
                        End While
                    ElseIf PriceTypeUpdate Then
                        ' Manually enter these
                        .Items.Add("Min Sell")
                        .Items.Add("Max Sell")
                        .Items.Add("Avg Sell")
                        .Items.Add("Median Sell")
                        .Items.Add("Percentile Sell")
                        .Items.Add("Min Buy")
                        .Items.Add("Max Buy")
                        .Items.Add("Avg Buy")
                        .Items.Add("Median Buy")
                        .Items.Add("Percentile Buy")
                        .Items.Add("Min Buy & Sell")
                        .Items.Add("Max Buy & Sell")
                        .Items.Add("Avg Buy & Sell")
                        .Items.Add("Median Buy & Sell")
                        .Items.Add("Percentile Buy & Sell")
                    End If

                    ' Set the bounds of the control
                    .SetBounds(pLeft, pTop, CurrentCell.Bounds.Width, CurrentCell.Bounds.Height)
                    .Text = CurrentCell.Text
                    .EndUpdate()
                    .Show()
                    .Focus()
                End If
                DataEntered = False ' We just updated so reset
                UpdatingCombo = False
            End With
            txtListEdit.Visible = False
        End If
    End Sub

    ' Processes the tab function in the text box for the grid. This overrides the default tabbing between controls
    Protected Overrides Function ProcessTabKey(ByVal TabForward As Boolean) As Boolean
        Dim ac As Control = Me.ActiveControl

        TabPressed = True

        If TabForward Then
            If ac Is txtListEdit Or ac Is cmbEdit Then
                Call ProcessKeyDownEdit(Keys.Tab, SelectedGrid)
                Return True
            End If
        Else
            If ac Is txtListEdit Or ac Is cmbEdit Then
                ' This is Shift + Tab but just send Shift for ease of processing
                Call ProcessKeyDownEdit(Keys.ShiftKey, SelectedGrid)
                Return True
            End If
        End If

        Return MyBase.ProcessTabKey(TabForward)

    End Function

    Private Sub cmbEdit_DropDownClosed(sender As Object, e As System.EventArgs) Handles cmbEdit.DropDownClosed
        If (PriceRegionUpdate And cmbEdit.Text <> PreviousRegion) Or
            (PriceSystemUpdate And cmbEdit.Text <> PreviousSystem) Or
            (PriceTypeUpdate And cmbEdit.Text <> PreviousPriceType) And Not UpdatingCombo Then
            DataEntered = True
            Call ProcessKeyDownEdit(Keys.Enter, SelectedGrid)
        End If
    End Sub

    Private Sub cmbEdit_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbEdit.SelectedIndexChanged
        If Not DataUpdated Then
            DataEntered = True
        End If
    End Sub

    Private Sub cmbEdit_LostFocus(sender As Object, e As System.EventArgs) Handles cmbEdit.LostFocus
        ' Lost focus some other way than tabbing
        If ((PriceRegionUpdate And cmbEdit.Text <> PreviousRegion) Or
            (PriceSystemUpdate And cmbEdit.Text <> PreviousSystem) Or
            (PriceTypeUpdate And cmbEdit.Text <> PreviousPriceType)) _
            And Not TabPressed And Not UpdatingCombo Then
            DataEntered = True
            Call ProcessKeyDownEdit(Keys.Enter, SelectedGrid)
        End If
        cmbEdit.Visible = False
        TabPressed = False
    End Sub

    Private Sub txtListEdit_GotFocus(sender As Object, e As System.EventArgs) Handles txtListEdit.GotFocus
        Call txtListEdit.SelectAll()
    End Sub

    Private Sub txtListEdit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtListEdit.KeyPress
        ' Make sure it's the right format for ME or Price update
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If MEUpdate Then
                If allowedMETEChars.IndexOf(e.KeyChar) = -1 Then
                    ' Invalid Character
                    e.Handled = True
                Else
                    DataEntered = True
                End If
            ElseIf PriceUpdate Then
                If allowedPriceChars.IndexOf(e.KeyChar) = -1 Then
                    ' Invalid Character
                    e.Handled = True
                Else
                    DataEntered = True
                End If
            ElseIf PriceModifierUpdate Then
                e.Handled = CheckPercentCharEntry(e, txtListEdit)
                If e.Handled = False Then
                    DataEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtListEdit_LostFocus(sender As Object, e As System.EventArgs) Handles txtListEdit.LostFocus
        If Not RefreshingGrid And DataEntered And Not IgnoreFocus And (PriceModifierUpdate And txtListEdit.Text <> PreviousPriceMod) Then
            Call ProcessKeyDownEdit(Keys.Enter, SelectedGrid)
        End If
        txtListEdit.Visible = False
    End Sub

    ' Sets the variables for price profiles
    Private Sub SetPriceProfileVariables(Index As Integer)
        PriceTypeUpdate = False
        PriceRegionUpdate = False
        PriceSystemUpdate = False
        PriceModifierUpdate = False

        Select Case Index
            Case 1
                PriceTypeUpdate = True
                PreviousPriceType = CurrentCell.Text
            Case 2
                PriceRegionUpdate = True
                PreviousRegion = CurrentCell.Text
            Case 3
                PriceSystemUpdate = True
                PreviousSystem = CurrentCell.Text
            Case 4
                PriceModifierUpdate = True
                PreviousPriceMod = CurrentCell.Text
        End Select

    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstBPComponentMats_ProcMsg(ByVal m As System.Windows.Forms.Message)
        txtListEdit.Hide()
        cmbEdit.Hide()
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstBPRawMats_ProcMsg(ByVal m As System.Windows.Forms.Message)
        txtListEdit.Hide()
        cmbEdit.Hide()
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstPricesView_ProcMsg(ByVal m As System.Windows.Forms.Message)
        txtListEdit.Hide()
        cmbEdit.Hide()
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstRawPriceProfile_ProcMsg(ByVal m As System.Windows.Forms.Message)
        txtListEdit.Hide()
        cmbEdit.Hide()
    End Sub

    ' Detects Scroll event and hides boxes
    Private Sub lstManufacturedPriceProfile_ProcMsg(ByVal m As System.Windows.Forms.Message)
        txtListEdit.Hide()
        cmbEdit.Hide()
    End Sub

#End Region

#Region "Blueprints Tab"

#Region "Blueprints Tab User Objects (Check boxes, Text, Buttons) Functions/Procedures "

    Private Sub chkPerUnit_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad And Not UpdatingCheck Then
            Call UpdateBPPriceLabels()
        End If
    End Sub

    Private Sub txtBPLines_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtBPInventionLines_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub lblBPInventStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f1 As New frmReqSkills(SkillType.InventionReqSkills)
        f1.Show()
    End Sub

    Private Sub lblReverseEngineerStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f1 As New frmReqSkills(SkillType.REReqSkills)
        f1.Show()
    End Sub

    Private Sub txtBPCCosts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPriceChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ResetfromTechSizeCheck()
        cmbBPsLoaded = False

        ComboMenuDown = False
        MouseWheelSelection = False
        ComboBoxArrowKeys = False
        BPComboKeyDown = False

        Call LoadBlueprintCombo()

        cmbBPBlueprintSelection.Text = "Select Blueprint"
        cmbBPBlueprintSelection.Focus()

    End Sub

    Private Sub txtBPRuns_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBPRuns_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If Not EnterKeyPressed Then
            EnterKeyPressed = False
        End If
    End Sub

    Private Sub txtBPRuns_LostFocus(sender As Object, e As System.EventArgs)
        If Not IgnoreFocus Then
            IgnoreFocus = True
        End If
    End Sub

    Private Sub txtBPAddlCosts_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPriceChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBPME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedMETEChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBPTE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedMETEChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chkBPTaxesFees_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstLoad And SetTaxFeeChecks Then
            Call RefreshBPData()
        End If
    End Sub

    Private Sub chkBPBrokerFees_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstLoad And SetTaxFeeChecks Then
            Call RefreshBPData()
        End If
    End Sub

    Private Sub chkBPBrokerFees_Click(sender As Object, e As EventArgs)
        If Not FirstLoad And SetTaxFeeChecks Then
            Call RefreshBPData()
        End If
    End Sub

    Private Sub txtBPBrokerFeeRate_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Call RefreshBPData()
        End If
    End Sub

    Private Sub txtBPBrokerFeeRate_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Only allow numbers, decimal, percent or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPercentChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBPBrokerFeeRate_LostFocus(sender As Object, e As EventArgs)
        Call RefreshBPData()
    End Sub

    Public Sub RefreshBPData()
        If Not IsNothing(SelectedBlueprint) Then
            Call UpdateBPPriceLabels()
        End If
    End Sub

    Private Sub txtBPNumBPs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBPUpdateCostIndex_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPercentChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBPMarketPriceEdit_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            IgnoreMarketFocus = True
            ' Update the price for this item
            IgnoreMarketFocus = False
        End If
    End Sub

    Private Sub txtBPMarketPriceEdit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Make sure it's the right format for Price update
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPriceChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub lstPricesView_ColumnWidthChanging(sender As Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs)
        If e.ColumnIndex = 0 Or e.ColumnIndex >= 4 Then
            e.Cancel = True
            e.NewWidth = lstPricesView.Columns(e.ColumnIndex).Width
        End If
    End Sub

#End Region

#Region "BP Combo / List Processing "

    Private Sub cmbBPBlueprintSelection_DropDown(sender As Object, e As System.EventArgs) Handles cmbBPBlueprintSelection.DropDown
        ' If you drop down, don't show the text window
        'cmbBPBlueprintSelection.AutoCompleteMode = AutoCompleteMode.None
        lstBPList.Hide()
        ComboMenuDown = True
        ' if we drop down, we aren't using the arrow keys
        ComboBoxArrowKeys = False
        BPComboKeyDown = False
    End Sub

    Private Sub cmbBPBlueprintSelection_DropDownClosed(sender As Object, e As System.EventArgs) Handles cmbBPBlueprintSelection.DropDownClosed
        ' If it closes up, re-enable autocomplete
        'cmbBPBlueprintSelection.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboMenuDown = False
        lstBPList.Hide() ' This could show up if people type into the list when combo down
        'Call SelectBlueprint() ' Loads in selectionchangecommitted
        cmbBPBlueprintSelection.Focus()
    End Sub

    Private Sub cmbBPBlueprintSelection_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles cmbBPBlueprintSelection.MouseWheel
        ' Only set mouse boolean when the combo isn't dropped down since users might want to use the wheel and click to select
        If ComboMenuDown Then
            MouseWheelSelection = False
        Else
            MouseWheelSelection = True
            cmbBPBlueprintSelection.Focus()
        End If

    End Sub

    Private Sub cmbBPBlueprintSelection_DoubleClick(sender As Object, e As EventArgs) Handles cmbBPBlueprintSelection.DoubleClick
        cmbBPBlueprintSelection.SelectAll()
    End Sub

    Private Sub cmbBPBlueprintSelection_LostFocus(sender As Object, e As EventArgs) Handles cmbBPBlueprintSelection.LostFocus
        ' Close the list view when lost focus
        Call lstBPList.Hide()
        Call cmbBPBlueprintSelection.SelectAll()
    End Sub

    ' Thrown when the user changes the value in the combo box
    Private Sub cmbBPBlueprintSelection_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cmbBPBlueprintSelection.SelectionChangeCommitted

        If Not MouseWheelSelection And Not ComboBoxArrowKeys Then
            lstBPList.Visible = False ' We are loading the bp, so hide this
            BPSelected = True
            Call LoadBPFromCombo()
        End If

        BPSelected = False

    End Sub

    ' Load the list box when the user types and don't use the drop down list
    Private Sub cmbBPBlueprintSelection_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbBPBlueprintSelection.TextChanged
        If Not FirstLoad And Not BPSelected And Trim(cmbBPBlueprintSelection.Text) <> "Select Blueprint" And BPComboKeyDown Then
            If ComboBoxArrowKeys = False Then
                If (cmbBPBlueprintSelection.Text <> "") Then
                    GetBPWithName(cmbBPBlueprintSelection.Text)
                End If
                If (String.IsNullOrEmpty(cmbBPBlueprintSelection.Text)) Then
                    lstBPList.Items.Clear()
                    lstBPList.Visible = False
                End If
            End If
        End If
    End Sub

    ' Process keys for bp combo
    Private Sub cmbBPBlueprintSelection_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbBPBlueprintSelection.KeyDown

        If cmbBPBlueprintSelection.DroppedDown = False Then
            BPComboKeyDown = True
        Else
            BPComboKeyDown = False
        End If

        If e.KeyValue = Keys.Up Or e.KeyValue = Keys.Down Then
            ComboBoxArrowKeys = True
        Else
            ComboBoxArrowKeys = False
        End If

        ' If they hit the arrow keys when the combo is dropped down (just in the combo it won't throw this)
        If lstBPList.Visible = False Then
            ' If they select enter, then load the BP
            If e.KeyValue = Keys.Enter Then
                Call LoadBPFromCombo()
            End If
        Else
            ' They have the list down, so process up and down keys to work with selecting in the list
            e.Handled = True ' Don't process up and down in the combo when the list shown
            Select Case (e.KeyCode)
                Case Keys.Down
                    If (lstBPList.SelectedIndex < lstBPList.Items.Count - 1) Then
                        lstBPList.SelectedIndex = lstBPList.SelectedIndex + 1
                    End If
                Case Keys.Up
                    If (lstBPList.SelectedIndex > 0) Then
                        lstBPList.SelectedIndex = lstBPList.SelectedIndex - 1
                    End If
                Case Keys.Enter
                    If (lstBPList.SelectedIndex > -1) Then
                        SelectedBPText = lstBPList.SelectedItem.ToString()
                        cmbBPBlueprintSelection.Text = SelectedBPText
                        lstBPList.Visible = False
                        BPSelected = True
                        Call SelectBlueprint()
                        BPSelected = False
                    End If
                Case Keys.Escape
                    lstBPList.Visible = False
            End Select
        End If

    End Sub

    Private Sub cmbBlueprintSelection_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call cmbBPBlueprintSelection.SelectAll()
    End Sub

    ' Process up down arrows in bp list
    Private Sub lstBPList_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstBPList.SelectedValueChanged
        If Not IsNothing(lstBPList.SelectedItem) Then
            cmbBPBlueprintSelection.Text = lstBPList.SelectedItem.ToString
            cmbBPBlueprintSelection.SelectAll()
        End If
    End Sub

    ' Loads the item by clicking on the item selected
    Private Sub lstBPList_MouseDown(sender As Object, e As MouseEventArgs) Handles lstBPList.MouseDown
        If lstBPList.SelectedItems.Count <> 0 Then
            SelectedBPText = lstBPList.SelectedItem.ToString()
            cmbBPBlueprintSelection.Text = SelectedBPText
            lstBPList.Visible = False
            Call SelectBlueprint()
            cmbBPBlueprintSelection.SelectAll()
        End If
    End Sub

    Private Sub lstBPList_MouseMove(sender As Object, e As MouseEventArgs) Handles lstBPList.MouseMove
        Dim Index As Integer = lstBPList.IndexFromPoint(e.X, e.Y)

        RemoveHandler lstBPList.SelectedValueChanged, AddressOf lstBPList_SelectedValueChanged
        lstBPList.SelectedIndex = Index
        AddHandler lstBPList.SelectedValueChanged, AddressOf lstBPList_SelectedValueChanged
    End Sub

    Private Sub lstBPList_LostFocus(sender As Object, e As EventArgs) Handles lstBPList.LostFocus
        ' hide when losing focus
        Call lstBPList.Hide()
        Call cmbBPBlueprintSelection.SelectAll()
    End Sub

    ' Loads the blueprint combo based on what was selected
    Private Sub LoadBlueprintCombo()
        Dim readerBPs As SQLiteDataReader
        Dim SQL As String = ""

        Application.UseWaitCursor = True
        If Not cmbBPsLoaded Then
            ' Clear anything that was there
            cmbBPBlueprintSelection.Items.Clear()
            cmbBPBlueprintSelection.BeginUpdate()

            SQL = "SELECT ALL_BLUEPRINTS.BLUEPRINT_NAME, REPLACE(LOWER(BLUEPRINT_NAME),'''','') AS X FROM ALL_BLUEPRINTS, INVENTORY_TYPES AS IT, INVENTORY_TYPES AS IT2 "
            SQL = SQL & "WHERE ALL_BLUEPRINTS.ITEM_ID = IT.typeID AND ALL_BLUEPRINTS.BLUEPRINT_ID = IT2.typeID "
            SQL = SQL & BuildBPSelectQuery()

            If SQL = "" Then
                Application.UseWaitCursor = False
                Exit Sub
            End If

            SQL = SQL & " ORDER BY X"

            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            readerBPs = DBCommand.ExecuteReader

            While readerBPs.Read
                ' Add the data to the array and combo
                cmbBPBlueprintSelection.Items.Add(Trim(readerBPs.GetString(0)))
                Application.DoEvents()
            End While

            readerBPs.Close()

            readerBPs = Nothing
            DBCommand = Nothing

            cmbBPBlueprintSelection.EndUpdate()

            cmbBPsLoaded = True

        End If
        Application.UseWaitCursor = False

    End Sub

    Private Sub GetBPWithName(bpName As String)
        ' Query: SELECT BLUEPRINT_NAME AS bpName FROM ALL_BLUEPRINTS b, INVENTORY_TYPES t WHERE b.ITEM_ID = t.typeID AND bpName LIKE '%Repair%'
        Dim readerBP As SQLiteDataReader
        Dim SQL As String = ""

        cmbBPBlueprintSelection.Text = bpName
        lstBPList.Items.Clear()

        ' Add limiting functions here based on radio buttons
        ' Use replace to Get rid of 's in blueprint name for sorting
        SQL = "SELECT ALL_BLUEPRINTS.BLUEPRINT_NAME, REPLACE(LOWER(BLUEPRINT_NAME),'''','') AS X FROM ALL_BLUEPRINTS, INVENTORY_TYPES AS IT2 "
        SQL &= "WHERE ALL_BLUEPRINTS.ITEM_ID = IT2.typeID "
        SQL &= BuildBPSelectQuery()
        SQL &= " AND ALL_BLUEPRINTS.BLUEPRINT_NAME LIKE '%" & FormatDBString(bpName) & "%'"
        SQL &= " ORDER BY X"

        ' query = "SELECT BLUEPRINT_NAME AS bpName FROM ALL_BLUEPRINTS b, INVENTORY_TYPES t WHERE b.ITEM_ID = t.typeID AND bpName LIKE '%" & bpName & "%'"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerBP = DBCommand.ExecuteReader
        lstBPList.BeginUpdate()

        While readerBP.Read()
            lstBPList.Items.Add(readerBP.GetString(0))
            Application.DoEvents()
        End While

        readerBP.Close()
        readerBP = Nothing
        lstBPList.EndUpdate()
        lstBPList.Visible = True
        Application.UseWaitCursor = False

    End Sub

    ' Builds the query for the select combo
    Private Function BuildBPSelectQuery() As String
        Dim SQL As String = ""
        Dim SQLItemType As String = ""

        ' See what ID we use for character bps
        Dim CharID As Long = 0
        If UserApplicationSettings.LoadBPsbyChar Then
            ' Use the ID sent
            CharID = SelectedCharacter.ID
        Else
            CharID = CommonLoadBPsID
        End If

        ' Item Type Definitions - These are set by me based on existing data
        ' 1, 2, 14 are T1, T2, T3
        ' 3 is Storyline
        ' 15 is Pirate Faction
        ' 16 is Navy Faction

        ' Add Item Type
        If SQLItemType <> "" Then
            SQLItemType = " ALL_BLUEPRINTS.ITEM_TYPE IN (" & SQLItemType.Substring(0, SQLItemType.Length - 1) & ") "
        Else
            ' They need to have at least one. If not, just return nothing
            BuildBPSelectQuery = ""
            Exit Function
        End If

        ' Add the item types
        SQL = SQL & " And " & SQLItemType

        Dim SizesClause As String = ""

        If SizesClause <> "" Then
            SizesClause = " AND SIZE_GROUP IN (" & SizesClause.Substring(0, Len(SizesClause) - 1) & ") "
        End If

        Dim NPCBPOsClause As String = ""

        SQL = SQL & SizesClause & NPCBPOsClause

        BuildBPSelectQuery = SQL

    End Function

    ' Loads a blueprint if selected in the combo box by different methods
    Private Sub LoadBPFromCombo()

        If Not IsNothing(cmbBPBlueprintSelection.SelectedItem) Then
            SelectedBPText = cmbBPBlueprintSelection.SelectedItem.ToString
            cmbBPBlueprintSelection.Text = SelectedBPText

            Call SelectBlueprint()

            ComboMenuDown = False
            MouseWheelSelection = False
            ComboBoxArrowKeys = False
            BPComboKeyDown = False
        End If

    End Sub

    ' Reloads the BP combo when run
    Private Sub ResetBlueprintCombo(ByVal T1 As Boolean, ByVal T2 As Boolean, ByVal T3 As Boolean, ByVal Storyline As Boolean, ByVal NavyFaction As Boolean, ByVal PirateFaction As Boolean)
        cmbBPsLoaded = False
        ComboMenuDown = False
        MouseWheelSelection = False
        ComboBoxArrowKeys = False
        BPComboKeyDown = False

        ' Load the New data
        Call LoadBlueprintCombo()

        cmbBPBlueprintSelection.Text = "Select Blueprint"
        cmbBPBlueprintSelection.Focus()

    End Sub

    Private Sub UpdateSelectedBPText(bpName As String)
        If bpName.Contains("Blueprint") Then
            RemoveHandler cmbBPBlueprintSelection.TextChanged, AddressOf cmbBPBlueprintSelection_TextChanged
            cmbBPBlueprintSelection.Text = bpName
            SelectedBPText = bpName
            AddHandler cmbBPBlueprintSelection.TextChanged, AddressOf cmbBPBlueprintSelection_TextChanged
            Call SelectBlueprint()
        End If

    End Sub

#End Region

    ' Initializes all the boxes on the BP tab
    Private Sub InitBPTab(Optional ResetBPHistory As Boolean = True)

        pictBP.Image = Nothing
        pictBP.BackgroundImage = Nothing
        pictBP.Update()

        cmbBPBlueprintSelection.Text = "Select Blueprint"

        With UserBPTabSettings
            cmbBPsLoaded = False
            InventionDecryptorsLoaded = False

            ' Don't show labels to make
            lblBPCanMakeBP.Visible = False

            SetTaxFeeChecks = False

            SetTaxFeeChecks = True

            BPRawColumnClicked = .RawColumnSort
            BPCompColumnClicked = .CompColumnSort

            If .RawColumnSortType = "Ascending" Then
                BPRawColumnSortType = SortOrder.Ascending
            Else
                BPRawColumnSortType = SortOrder.Descending
            End If

            If .CompColumnSortType = "Ascending" Then
                BPCompColumnSortType = SortOrder.Ascending
            Else
                BPCompColumnSortType = SortOrder.Descending
            End If

            ' Invention checks
            UpdatingInventionChecks = True
            UpdatingInventionChecks = False

        End With

        ' BP Combo selection booleans
        ComboMenuDown = False
        MouseWheelSelection = False
        ComboBoxArrowKeys = False
        BPComboKeyDown = False

        ResetBPTab = True
        EnterKeyPressed = False

        LoadingBPfromHistory = False
        PreviousBPfromHistory = False

        ' Load the combo
        Call LoadBlueprintCombo()

        ' BP History
        If ResetBPHistory Then
            BPHistory = New List(Of BPHistoryItem)
            CurrentBPHistoryIndex = -1 ' Nothing added yet
        Else
            Call LoadBPfromHistory(CurrentBPHistoryIndex, "")
        End If

    End Sub

    ' Selects the blueprint from the combo and loads it into the grids
    Private Sub SelectBlueprint(Optional ByVal NewBP As Boolean = True, Optional SentFrom As SentFromLocation = 0, Optional FromEvent As Boolean = False)
        Dim SQL As String
        Dim readerBP As SQLiteDataReader
        Dim readerMat As SQLiteDataReader
        Dim BPID As Integer
        Dim TempTech As Integer
        Dim ItemType As Integer
        Dim ItemGroupID As Integer
        Dim ItemCategoryID As Integer
        Dim BPGroup As String
        Dim Reaction As Boolean = False

        SQL = "SELECT ALL_BLUEPRINTS.BLUEPRINT_ID, TECH_LEVEL, ITEM_TYPE, ITEM_GROUP_ID, ITEM_CATEGORY_ID, BLUEPRINT_GROUP "
        SQL = SQL & "FROM ALL_BLUEPRINTS "
        SQL = SQL & "WHERE ALL_BLUEPRINTS.BLUEPRINT_NAME = "

        If SelectedBPText = "" Then
            SelectedBPText = cmbBPBlueprintSelection.Text
        End If

        SQL = SQL & "'" & FormatDBString(SelectedBPText) & "'"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerBP = DBCommand.ExecuteReader

        If readerBP.Read() Then
            BPID = readerBP.GetInt32(0)
            TempTech = readerBP.GetInt32(1)
            ItemType = readerBP.GetInt32(2)
            ItemGroupID = readerBP.GetInt32(3)
            ItemCategoryID = readerBP.GetInt32(4)
            BPGroup = readerBP.GetString(5)
        Else
            Exit Sub
        End If

        readerBP.Close()

        ' Load the image
        Call LoadBlueprintPicture(BPID, ItemType)

        ' Set for max production lines 
        If SentFrom = SentFromLocation.None Then ' We might have different values there and they set on double click
        ElseIf SentFrom <> SentFromLocation.None Then  ' Sent from manufacturing tab, bp tab, history, or shopping list
            ' Set up for Reloading the decryptor combo on T2/T3
            ' Allow reloading of Decryptors
            InventionDecryptorsLoaded = False
            T3DecryptorsLoaded = False
            ' Allow loading decryptors on drop down
            LoadingInventionDecryptors = False
            LoadingT3Decryptors = False
            ' Allow reloading of relics
            RelicsLoaded = False
        End If

        Reaction = IsReaction(ItemGroupID)

        ' If the previous bp was loaded from history and the current bp isn't loaded from history or event, then reset the facilities to default
        If PreviousBPfromHistory And SentFrom <> SentFromLocation.History And Not FromEvent Then
            PreviousBPfromHistory = False
        End If

        ' See if it has moon/gas mats
        SQL = "SELECT DISTINCT 'X' FROM ALL_BLUEPRINT_MATERIALS "
        SQL &= "WHERE BLUEPRINT_ID = " & CStr(BPID) & " "
        SQL &= "AND MATERIAL_GROUP IN ('Intermediate Materials', 'Composite','Hybrid Polymers')"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerMat = DBCommand.ExecuteReader()
        readerMat.Read()

        readerMat.Close()

        cmbBPBlueprintSelection.Focus()

        ' Make sure everything is enabled on first BP load
        If ResetBPTab Then
            ResetBPTab = False ' Reset
        End If

        readerBP.Close()
        readerBP = Nothing
        DBCommand = Nothing

        Application.DoEvents()

        cmbBPBlueprintSelection.SelectionLength = 0

    End Sub

    ' Selects the images to be shown in the picture when a blueprint is selected
    Private Sub LoadBlueprintPicture(ByVal BPID As Long, ByVal ItemType As Integer)
        Dim BPImage As String
        Dim BPTechImagePath As String = ""

        ' Load the image - use absolute value since I use negative bpid's for special bps
        BPImage = Path.Combine(UserImagePath, CStr(Math.Abs(BPID)) & "_64.png")

        ' Check for the Tech Image
        If File.Exists(BPImage) Then
            pictBP.Image = Image.FromFile(BPImage)
        Else
            pictBP.Image = Nothing
        End If

        pictBP.Update()

    End Sub

    ' Updates the price and other labels on the BP tab for the selected BP
    Public Sub UpdateBPPriceLabels()
        ' For final printout in boxes
        Dim TotalRawProfit As Double
        Dim TotalCompProfit As Double
        Dim TotalRawIPH As Double
        Dim TotalCompIPH As Double
        Dim DivideUnits As Long

        DivideUnits = 1

        ' Update usage labels
        Call UpdateFacilityUsage(DivideUnits)

        ' Profit labels (market cost - total cost of mats and invention)
        TotalRawProfit = SelectedBlueprint.GetTotalRawProfit / DivideUnits

        TotalCompProfit = SelectedBlueprint.GetTotalComponentProfit / DivideUnits

        If DivideUnits = 1 Then
            TotalRawIPH = SelectedBlueprint.GetTotalIskperHourRaw
            TotalCompIPH = SelectedBlueprint.GetTotalIskperHourComponents
        Else ' Need to adjust the production time per unit then calck IPH
            ' ISK per Hour (divide total cost by production time in seconds for a isk per second calc, then multiply by 3600 for isk per hour)
            TotalRawIPH = TotalRawProfit / (SelectedBlueprint.GetTotalProductionTime / DivideUnits) * 3600 ' Build everything

            TotalCompIPH = TotalCompProfit / (SelectedBlueprint.GetProductionTime / DivideUnits) * 3600 ' Buy all components, just production time of BP

        End If

        ' Set the labels if the User Can make this item and/or all components
        If SelectedBlueprint.UserCanBuildBlueprint Then
            lblBPCanMakeBP.Text = "Can make this Item"
            lblBPCanMakeBP.ForeColor = Color.Black
        Else
            lblBPCanMakeBP.Text = "Cannot make this Item"
            lblBPCanMakeBP.ForeColor = Color.Red
        End If

        ' SVR Values
        If UserApplicationSettings.AutoUpdateSVRonBPTab Then
            Dim TempRawSVR As String = GetBPItemSVR(SelectedBlueprint.GetTotalProductionTime)
            Dim TempBPSVR As String
            TempBPSVR = GetBPItemSVR(SelectedBlueprint.GetProductionTime)
        End If

    End Sub

    ' Update the facility usage directly in the object
    Private Sub UpdateFacilityUsage(DivideUnits As Long)
        Dim UsedFacility As IndustryFacility = CalcBaseFacility.GetSelectedFacility()
        Dim TTText As String = ""
        Dim SelectedManufacturingFacility As IndustryFacility = CalcBaseFacility.GetSelectedManufacturingFacility(SelectedBlueprint.GetItemGroupID, SelectedBlueprint.GetItemCategoryID)

        ' Save all the usage values each time we update to allow updates for changing the facility
        If SelectedManufacturingFacility.FacilityProductionType = ProductionType.Reactions Then
            SelectedManufacturingFacility.FacilityUsage = SelectedBlueprint.GetReactionFacilityUsage / DivideUnits
        Else
            SelectedManufacturingFacility.FacilityUsage = SelectedBlueprint.GetManufacturingFacilityUsage / DivideUnits
        End If

        ' Show the usage cost for the activity selected
        If UsedFacility.IncludeActivityUsage Then
            Select Case UsedFacility.Activity
                Case ManufacturingFacility.ActivityManufacturing
                    UsedFacility.FacilityUsage = SelectedBlueprint.GetManufacturingFacilityUsage / DivideUnits
                    TTText = GetUsageToolTipText(SelectedBlueprint.GetManufacturingFacility, True)
                Case ManufacturingFacility.ActivityInvention
                    UsedFacility.FacilityUsage = SelectedBlueprint.GetInventionUsage / DivideUnits
                    TTText = GetUsageToolTipText(SelectedBlueprint.GetInventionFacility, False)
                Case ManufacturingFacility.ActivityCopying
                    UsedFacility.FacilityUsage = SelectedBlueprint.GetCopyUsage / DivideUnits
                    TTText = GetUsageToolTipText(SelectedBlueprint.GetCopyFacility, False)
                Case ManufacturingFacility.ActivityComponentManufacturing
                    UsedFacility.FacilityUsage = SelectedBlueprint.GetComponentFacilityUsage / DivideUnits
                    TTText = GetUsageToolTipText(SelectedBlueprint.GetComponentManufacturingFacility, True)
                Case ManufacturingFacility.ActivityCapComponentManufacturing
                    UsedFacility.FacilityUsage = SelectedBlueprint.GetCapComponentFacilityUsage / DivideUnits
                    TTText = GetUsageToolTipText(SelectedBlueprint.GetCapitalComponentManufacturingFacility, True)
                Case ManufacturingFacility.ActivityReactions
                    UsedFacility.FacilityUsage = SelectedBlueprint.GetReactionFacilityUsage / DivideUnits
                    TTText = GetUsageToolTipText(SelectedBlueprint.GetReactionFacility, True)
            End Select
        Else
            UsedFacility.FacilityUsage = 0
        End If

    End Sub

    ' Returns the number of BPs to use for item type and runs sent
    Private Function GetUsedNumBPs(ByVal BlueprintTypeID As Long, ByVal SentTechLevel As Integer,
                                   ByVal SentRuns As Integer, ByVal SentLines As Integer, ByVal SentNumBps As Integer, ByVal DecryptorMod As Integer) As Integer
        Dim MaxProductionRuns As Long
        Dim ReturnValue As Integer

        If SentTechLevel = 1 Then
            If SentRuns >= SentNumBps Then
                Return SentNumBps
            Else
                Return SentRuns
            End If
        End If

        MaxProductionRuns = MaxProductionRuns + DecryptorMod
        ' Set the num bps off of the calculated amount
        ReturnValue = CInt(Math.Ceiling(SentRuns / MaxProductionRuns))

        Return ReturnValue

    End Function

    Private Sub LoadBPfromHistory(ByRef LocationID As Integer, BPType As String)

        If BPHistory.Count > 0 And LocationID < BPHistory.Count And LocationID >= 0 Then
            With BPHistory(LocationID)
                LoadingBPfromHistory = True
                PreviousBPfromHistory = True
                Call LoadBPfromEvent(.BPID, .BuildType, .Inputs, .SentFrom, .BuildFacility, .ComponentFacility, .CapComponentFacility, .InventionFacility, .CopyFacility, .IncludeTaxes,
                                           .BrokerFeeData, .MEValue, .TEValue, .SentRuns, .ManufacturingLines, .LabLines, .NumBPs, .AddlCosts, .PPU)
            End With

            CurrentBPHistoryIndex = LocationID

        End If
    End Sub

    ' Takes the facility and sets all the tool tip text based on the data it used
    Private Function GetUsageToolTipText(SentFacility As IndustryFacility, IncludeTax As Boolean) As String
        ' Set the usage tool tip data
        Dim TTString As String = ""

        TTString = TTString & "System Index = " & FormatPercent(SentFacility.CostIndex, 2) & " " & vbCrLf
        If IncludeTax Then
            TTString = TTString & "Facility Tax Rate = " & FormatPercent(SentFacility.TaxRate, 2) & " " & vbCrLf
        End If
        TTString = TTString & "Double-click for a list of facility usages"

        Return TTString

    End Function

    ' Private Sub CalculateCompressedOres(ByVal bpMaterialList As List(Of Material))
    'Dim newList As New List(Of OreMineral)
    '    Dim oreQuantityList As ListViewItem
    '    Dim materialQuantityList As ListViewItem
    '    Dim materialList As New List(Of Material)
    '    Dim oreID As Integer
    '    Dim oreSkillReproSkillID As Integer
    '    Dim reproSkill As Integer
    '    Dim reproEffSkill As Integer
    '    Dim reproSpecOreSkill As Integer
    '    Dim refinePercent As Double ' Start with 50% refining
    '    Dim stationTax As Double
    '    Dim lockedList As New List(Of Integer)
    '    Dim mineralTotal As Double
    '    Dim oreCost As Double

    '    Dim skillDict As New Dictionary(Of String, Integer) From {
    '            {"Arkonor", 12180},
    '            {"Bistot", 12181},
    '            {"Crokite", 12182},
    '            {"Dark Ochre", 12183},
    '            {"Gneiss", 12184},
    '            {"Hedbergite", 12185},
    '            {"Hemorphite", 12186},
    '            {"Jaspet", 12187},
    '            {"Kernite", 12188},
    '            {"Mercoxit", 12189},
    '            {"Omber", 12190},
    '            {"Plagioclase", 12191},
    '            {"Pyroxeres", 12192},
    '            {"Scordite", 12193},
    '            {"Spodumain", 12194},
    '            {"Veldspar", 12195}}


    '    Dim oreSQL = "SELECT o.OreID, o.MineralID, o.MineralQuantity, i.typeName, g.groupName FROM ORE_REFINE o " +
    '                 "JOIN INVENTORY_TYPES i ON o.OreID = i.typeID " +
    '                 "JOIN INVENTORY_GROUPS g ON i.groupID = g.groupID " +
    '                 "WHERE o.OreID = {0} " +
    '                 "ORDER BY o.MineralQuantity DESC"

    '    Dim mineralSQL = "SELECT o.OreID FROM ORE_REFINE o " +
    '                     "JOIN INVENTORY_TYPES i ON o.OreID = i.typeID " +
    '                     "WHERE i.typeName LIKE 'Compressed%' " +
    '                     "AND o.MineralID = {0} " +
    '                     "ORDER BY o.MineralQuantity DESC LIMIT 1"

    '    reproSkill = SelectedCharacter.Skills.GetSkillLevel(3385)
    '    reproEffSkill = SelectedCharacter.Skills.GetSkillLevel(3389)

    '    If BPTabFacility.GetFacility(BPTabFacility.GetCurrentFacilityProductionType).GetFacilityTypeDescription = ManufacturingFacility.StationFacility Then
    '        Using DBCommand = New SQLiteCommand(String.Format("SELECT REPROCESSING_EFFICIENCY FROM STATIONS WHERE STATION_NAME = '{0}'", BPTabFacility.GetFacility(BPTabFacility.GetCurrentFacilityProductionType).FacilityName), EVEDB.DBREf)
    '            refinePercent = CType(DBCommand.ExecuteScalar, Double)
    '        End Using
    '    ElseIf BPTabFacility.GetFacility(BPTabFacility.GetCurrentFacilityProductionType).GetFacilityTypeDescription = ManufacturingFacility.StructureFacility Then
    '        stationTax = 0.0
    '        refinePercent = 0.5
    '    ElseIf BPTabFacility.GetFacility(BPTabFacility.GetCurrentFacilityProductionType).GetFacilityTypeDescription = ManufacturingFacility.POSFacility Then
    '        stationTax = 0.0
    '        refinePercent = 0.52
    '    End If

    '    If refinePercent = 0 Then
    '        refinePercent = 0.5 ' Setting the refine percent to 50 if it comes back as 0 for corrupt station data.
    '    End If

    '    For i = 0 To bpMaterialList.Count - 1 Step 1
    '        Dim loopCounter = i
    '        Dim currentMineralID = CType(bpMaterialList(loopCounter).GetMaterialTypeID(), Integer)

    '        If (currentMineralID > 40) Then
    '            materialList.Add(bpMaterialList(i))
    '            Continue For
    '        End If

    '        Using DBCommand = New SQLiteCommand(String.Format(mineralSQL, currentMineralID), EVEDB.DBREf)
    '            oreID = CType(DBCommand.ExecuteScalar(), Integer)
    '        End Using

    '        If oreID = 28367 And currentMineralID = 36 Then
    '            oreID = 28397
    '        End If

    '        ' Reprocessing = 3385 -> 0.03 => 0.15
    '        ' Repro Efficiency = 3389 -> 0.02 => 0.10
    '        ' Ore Special = 12180-12195 -> 0.02 => 0.10
    '        ' Station Equipment x (1 + Processing skill x 0.03) x (1 + Processing Efficiency skill x 0.02) x (1 + Ore Processing skill x 0.02) x (1 + Processing Implant)
    '        ' Beancounter 27169, 27174, 27175 (2, 4, 1) 

    '        Using DBCommand = New SQLiteCommand(String.Format(oreSQL, oreID), EVEDB.DBREf)
    '            Dim result = DBCommand.ExecuteReader()
    '            While result.Read()
    '                skillDict.TryGetValue(result.GetString(4), oreSkillReproSkillID)
    '                reproSpecOreSkill = SelectedCharacter.Skills.GetSkillLevel(oreSkillReproSkillID)

    '                Dim mineralRefinePercent As Double = refinePercent * (1 + reproSkill * 0.03) * (1 + reproEffSkill * 0.02) * (1 + reproSpecOreSkill * 0.02) * (1 + UserApplicationSettings.RefiningImplantValue)

    '                Dim mineralQuantity = result.GetInt32(2) * mineralRefinePercent

    '                'Dim mineralList = newList.Where(Function(b) b.MineralID = currentMineralID)



    '                ' TODO : FIX THE MULTIPLIER
    '                mineralTotal = newList.Where(Function(b) b.MineralID = currentMineralID).Sum(Function(a) a.MineralQuantity * a.OreMultiplier)

    '                If mineralTotal < bpMaterialList(loopCounter).GetQuantity() Or currentMineralID <> result.GetInt32(1) Then
    '                    newList.Add(New OreMineral With {
    '                                .OreID = result.GetInt32(0),
    '                                .MineralID = result.GetInt32(1),
    '                                .MineralQuantity = mineralQuantity,
    '                                .OreMultiplier = 0,
    '                                .OreName = result.GetString(3),
    '                                .OreSelectedFor = currentMineralID})
    '                End If
    '            End While

    '            ' Make sure we're not grabbing the same Ore numerous times.
    '            Dim currentMineral = newList.FirstOrDefault(Function(x) x.OreID = oreID And x.MineralID = currentMineralID And x.Locked = False)

    '            If currentMineral Is Nothing Then
    '                Continue For
    '            End If

    '            If currentMineralID = 35 And oreID = 28420 Then
    '                mineralTotal = 0
    '            End If
    '            Dim multiplier = (bpMaterialList(loopCounter).GetQuantity() - mineralTotal) / currentMineral.MineralQuantity

    '            If (multiplier > 0) Then
    '                Dim updateMultipliers = newList.Where(Function(y) y.OreID = currentMineral.OreID And y.OreSelectedFor = currentMineralID)
    '                lockedList.Add(oreID)
    '                For Each item As OreMineral In updateMultipliers
    '                    item.OreMultiplier = CType(Math.Ceiling(multiplier), Int64)
    '                    ' If an ore has been 'multiplied' then lock it so we can no longer modify it.
    '                    item.Locked = True
    '                Next
    '            End If

    '            ' Moved this down here because the Tritanium/Pyerite problem wasn't getting resolved if the item only required the two minerals.
    '            ' This will fix the issue by forcing it to reset Spodumain properly.
    '            Dim mineralList = newList.Where(Function(b) b.MineralID = currentMineralID)

    '            Dim tempList = mineralList.OrderByDescending(Function(c) c.OreMultiplier).Where(Function(o) o.OreID = 28420)

    '            If tempList.Count > 1 Then
    '                Dim tmpRange = newList.Where(Function(y) y.OreID = 28420 And y.OreSelectedFor = tempList(1).OreSelectedFor And y.OreMultiplier > 0)
    '                For Each item As OreMineral In tmpRange
    '                    item.OreMultiplier = 0
    '                Next
    '            End If

    '        End Using

    '    Next

    '    'Populate the final list with distinct ore names (no point showing Compressed Arkonor 3 times for each mineral type)
    '    Dim oreList = newList.Where(Function(x) x.OreMultiplier > 0).DistinctBy(Function(c) c.OreSelectedFor)

    '    For Each item As OreMineral In oreList
    '        oreQuantityList = New ListViewItem(item.OreName)
    '        oreQuantityList.SubItems.Add(CType(item.OreMultiplier, String))
    '        oreQuantityList.SubItems.Add("-")
    '        Using DBCommand = New SQLiteCommand(String.Format("SELECT PRICE FROM ITEM_PRICES WHERE ITEM_ID = {0}", item.OreID), EVEDB.DBREf)
    '            Dim avgPrice = CType(DBCommand.ExecuteScalar(), Double)
    '            oreQuantityList.SubItems.Add(FormatNumber(avgPrice, 2))
    '            oreQuantityList.SubItems.Add(FormatNumber(avgPrice * item.OreMultiplier, 2))

    '            oreCost += avgPrice * item.OreMultiplier
    '        End Using
    '        Call lstBPRawMats.Items.Add(oreQuantityList)

    '    Next

    '    For Each item As Material In materialList
    '        materialQuantityList = New ListViewItem(item.GetMaterialName())
    '        materialQuantityList.SubItems.Add(CType(item.GetQuantity(), String))
    '        materialQuantityList.SubItems.Add("-")
    '        materialQuantityList.SubItems.Add(FormatNumber(item.GetCostPerItem(), 2))
    '        materialQuantityList.SubItems.Add(FormatNumber(item.GetTotalCost(), 2))
    '        oreCost += item.GetTotalCost()

    '        Call lstBPRawMats.Items.Add(materialQuantityList)
    '    Next

    '    lblBPRawMatCost.Text = FormatNumber(oreCost, 2)


    'End Sub

#End Region

#Region "Update Prices Tab"

#Region "Update Prices Tab User Object (Check boxes, Text, Buttons) Functions/Procedures "

    ' Disables the forms and controls on update prices
    Private Sub DisableUpdatePricesTab(Value As Boolean)
        ' Disable tab
        gbTradeHubSystems.Enabled = Not Value
        btnDownloadPrices.Enabled = Not Value
        lstPricesView.Enabled = Not Value
    End Sub

    ' Checks or unchecks all the prices
    Private Sub UpdateAllPrices()
        If RunUpdatePriceList Then
            ' Don't update prices yet
            UpdateAllTechChecks = True
            RunUpdatePriceList = False

            Application.DoEvents()

            ' Good to go, update or clear
            RunUpdatePriceList = True
            UpdateAllTechChecks = True

            Application.DoEvents()

            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkPriceSelectManufacturedItems_CheckedChanged(sender As System.Object, e As System.EventArgs)

        If PriceToggleButtonHit = False And Not FirstLoad Then
            Call UpdatePriceList()
        End If

    End Sub

    Private Sub chkPriceRawMaterialPrices_CheckedChanged(sender As System.Object, e As System.EventArgs)

        If PriceToggleButtonHit = False And Not FirstLoad Then
            Call UpdatePriceList()
        End If

    End Sub

    ' EVE Central Link
    Private Sub llblEVEMarketerContribute_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("http://eve-central.com/home/software.html")
    End Sub

    ' Updates the T1, T2 and T3 check boxes depending on item selections
    Private Sub UpdateTechChecks()
        Dim T1 As Boolean = False
        Dim T2 As Boolean = False
        Dim T3 As Boolean = False
        Dim Storyline As Boolean = False
        Dim Navy As Boolean = False
        Dim Pirate As Boolean = False

        Dim ItemsSelected As Boolean = False
        Dim TechChecks As Boolean = False

        ' Check each item checked and set the check boxes accordingly
        T1 = True
        T2 = True
        T3 = True
        Pirate = True
        ItemsSelected = True
        Navy = True
        Storyline = True

        ' Save status of the Tech check boxes
        PriceCheckT1Enabled = True

    End Sub

    ' Clears all system's that may be checked including resetting the system combo
    Private Sub ClearSystemChecks(Optional ResetSystemCombo As Boolean = True)
        Dim i As Integer

        If Not IgnoreSystemCheckUpdates Then
            For i = 1 To SystemCheckBoxes.Length - 1
                SystemCheckBoxes(i).Checked = False
            Next
        End If
    End Sub

    Private Sub cmbPriceShipTypes_DropDown(sender As Object, e As System.EventArgs)
        If FirstPriceShipTypesComboLoad Then
            Call LoadPriceShipTypes()
            FirstPriceShipTypesComboLoad = False
        End If
    End Sub

    Private Sub cmbPriceChargeTypes_DropDown(sender As Object, e As System.EventArgs)
        If FirstPriceChargeTypesComboLoad Then
            Call LoadPriceChargeTypes()
            FirstPriceChargeTypesComboLoad = False
        End If
    End Sub

    Private Sub txtPriceItemFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Call ProcessCutCopyPasteSelect(txtPriceItemFilter, e)
        If e.KeyCode = Keys.Enter Then
            Call UpdatePriceList()
        End If
    End Sub

    ' Checks all item check's to see if there is one checked. True if one or more checked, False if not
    Private Function ItemsSelected() As Boolean

        ' If the prices list doesnt' have any items in it, nothing to update so nothing checked
        If lstPricesView.Items.Count <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub chkPricesT1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RefreshList Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkPricesT2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RefreshList Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkPricesT3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RefreshList Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkPricesT4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RefreshList Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkPricesT5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RefreshList Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkPricesT6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RefreshList Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub chkMinerals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkIceProducts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkDataCores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkDecryptors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkGas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkAbyssalMaterials_CheckedChanged(sender As Object, e As EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkBlueprints_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkMisc_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkSalvage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkAncientSalvage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkAncientRelics_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkPolymers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkRawMats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkPlanetary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkAsteroids_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkProcessedMats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkAdvancedMats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkMatsandCompounds_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkDroneComponents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkStructureRigs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkDeployables_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkStructureModules_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkCelestial_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkImplants_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkBoosterMats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkTools_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkFuelBlocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkDataInterfaces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkHybrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkStructureComponents_CheckedChanged(sender As Object, e As EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkComponents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkCapitalComponents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkCapT2Components_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call UpdatePriceList()
    End Sub

    Private Sub chkBoosters_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkRigs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkShips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True

    End Sub

    Private Sub chkModules_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkDrones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkCharges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True

    End Sub

    Private Sub chkSubsystems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkStructures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkUpdatPricesNoPrice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshList = False
        Call UpdateTechChecks()
        Call UpdatePriceList()
        RefreshList = True
    End Sub

    Private Sub chkSystems1_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call SyncPriceCheckBoxes(1)
        Call ResetRefresh()
    End Sub

    Private Sub chkSystems2_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call SyncPriceCheckBoxes(2)
        Call ResetRefresh()
    End Sub

    Private Sub chkSystems3_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call SyncPriceCheckBoxes(3)
        Call ResetRefresh()
    End Sub

    Private Sub chkSystems4_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call SyncPriceCheckBoxes(4)
        Call ResetRefresh()
    End Sub

    Private Sub chkSystems5_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call SyncPriceCheckBoxes(5)
        Call ResetRefresh()
    End Sub

    Private Sub cmbPriceSystems_DropDown(sender As Object, e As System.EventArgs)
        If FirstSolarSystemComboLoad Then
            Call LoadPriceSolarSystems()
            FirstSolarSystemComboLoad = False
        End If
    End Sub

    Private Sub cmbPriceShipTypes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstPriceShipTypesComboLoad Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub cmbPriceChargeTypes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstPriceChargeTypesComboLoad Then
            Call UpdatePriceList()
        End If
    End Sub

    Private Sub SyncPriceCheckBoxes(ByVal TriggerIndex As Integer)
        Dim i As Integer

        If Not FirstLoad Then
            ' Trigger Index is a box that was checked on or off
            If SystemCheckBoxes(TriggerIndex).Checked = True Then
                ' Uncheck all other systems and regions
                For i = 1 To SystemCheckBoxes.Length - 1
                    If i <> TriggerIndex Then
                        SystemCheckBoxes(i).Checked = False
                    End If
                Next
                'Set the region to match
                Select Case TriggerIndex
                    Case 1
                        calcHistoryRegion = "The Forge"
                    Case 2
                        calcHistoryRegion = "Domain"
                    Case 3
                        calcHistoryRegion = "Sinq Laison"
                    Case 4
                        calcHistoryRegion = "Heimatar"
                    Case 5
                        calcHistoryRegion = "Metropolis"
                    Case Else
                        calcHistoryRegion = "The Forge"
                End Select
            End If
        End If

    End Sub

    Private Sub lstPricesView_ColumnClick(sender As System.Object, e As System.Windows.Forms.ColumnClickEventArgs)

        Call ListViewColumnSorter(e.Column, CType(lstPricesView, ListView), UpdatePricesColumnClicked, UpdatePricesColumnSortType)

    End Sub

    Private Sub btnRawMaterialsDefaults_Click(sender As System.Object, e As System.EventArgs)

        AllSettings.SaveUpdatePricesSettings(UserUpdatePricesTabSettings)

        ' Refresh the grids
        Call LoadPriceProfileGrids()

        MsgBox("Defaults set", vbInformation, Application.ProductName)

    End Sub

    Private Sub btnItemsDefaults_Click(sender As System.Object, e As System.EventArgs)

        AllSettings.SaveUpdatePricesSettings(UserUpdatePricesTabSettings)

        ' Refresh the grids
        Call LoadPriceProfileGrids()

        MsgBox("Defaults set", vbInformation, Application.ProductName)

    End Sub

#End Region

    ' Initalizes all the prices tab boxes, etc
    Private Sub InitUpdatePricesTab()
        Dim i As Integer
        Dim TempRegion As String = ""

        FirstPriceChargeTypesComboLoad = True
        FirstPriceShipTypesComboLoad = True
        RefreshList = False

        Call ClearSystemChecks()

        With UserUpdatePricesTabSettings
            RunUpdatePriceList = False ' If the settings trigger an update, we don't want to update the prices
            RunUpdatePriceList = False ' If the settings trigger an update, we don't want to update the prices

            ' First load the regions combo, then set the default region
            DefaultPreviousRawRegion = .PPRawRegion
            PPRawSystemsLoaded = True

            ' First load the regions combo, then set the default region
            DefaultPreviousItemsRegion = .PPItemsRegion
            PPItemsSystemsLoaded = True

        End With

        RunUpdatePriceList = True
        RefreshList = True

        ' Disable cancel
        btnCancelUpdate.Enabled = False

        ' Preload the systems combo
        Call LoadPriceSolarSystems()

        ' Set system/region 
        If UserUpdatePricesTabSettings.SelectedSystem <> "0" Then
            ' Check the preset systems fist
            Select Case UserUpdatePricesTabSettings.SelectedSystem
                Case "Jita"
                    chkSystems1.Checked = True
                Case "Amarr"
                    chkSystems2.Checked = True
                Case "Dodixie"
                    chkSystems3.Checked = True
                Case "Rens"
                    chkSystems4.Checked = True
                Case "Hek"
                    chkSystems5.Checked = True
            End Select

        Else ' They set a region
            ' Loop through the checks and check the ones they set
            IgnoreSystemCheckUpdates = True
            For i = 1 To RegionCheckBoxes.Count - 1
                If UserUpdatePricesTabSettings.SelectedRegions.Contains(RegionCheckBoxes(i).Text) Then
                    RegionCheckBoxes(i).Checked = True
                End If
            Next
            IgnoreSystemCheckUpdates = False
        End If

        UpdatePricesColumnClicked = UserUpdatePricesTabSettings.ColumnSort
        If UserUpdatePricesTabSettings.ColumnSortType = "Ascending" Then
            UpdatePricesColumnSortType = SortOrder.Ascending
        Else
            UpdatePricesColumnSortType = SortOrder.Descending
        End If

        ' Load up the price profile grids
        Call LoadPriceProfileGrids()

        ' Refresh the prices
        Call UpdatePriceList()

    End Sub

    ' Structure for loading price profiles in the appropriate grids
    Private Structure PriceProfile
        Dim GroupName As String
        Dim PriceType As String
        Dim RegionName As String
        Dim SolarSystemName As String
        Dim PriceModifier As Double
        Dim RawMaterial As Boolean
    End Structure

    ' Loads the price profiles system combo
    Private Sub LoadPPDefaultsSystemCombo(ByRef SystemCombo As ComboBox, ByVal Region As String, ByVal System As String)

        Dim SQL As String = ""
        Dim rsData As SQLiteDataReader

        SQL = "SELECT solarSystemName FROM SOLAR_SYSTEMS, REGIONS "
        SQL = SQL & "WHERE SOLAR_SYSTEMS.regionID = REGIONS.regionID "
        SQL = SQL & "AND REGIONS.regionName = '" & Region & "' ORDER BY solarSystemName"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsData = DBCommand.ExecuteReader
        SystemCombo.BeginUpdate()
        SystemCombo.Items.Clear()
        ' Add the all systems item
        SystemCombo.Items.Add(AllSystems)
        While rsData.Read
            SystemCombo.Items.Add(rsData.GetString(0))
        End While
        SystemCombo.Text = Region
        SystemCombo.EndUpdate()
        rsData.Close()
        SystemCombo.Text = System

    End Sub

    ' Loads up the settings in the price profile grids on update prices
    Private Sub LoadPriceProfileGrids()
        Dim rsPP As SQLiteDataReader
        Dim SQL As String
        Dim GroupRawFlagList As String = ""
        Dim Profiles As New List(Of PriceProfile)
        Dim TempProfile As PriceProfile

        SQL = "SELECT GROUP_NAME, PRICE_TYPE, REGION_NAME, SOLAR_SYSTEM_NAME, PRICE_MODIFIER, RAW_MATERIAL "
        SQL = SQL & "FROM PRICE_PROFILES WHERE ID = " & CStr(SelectedCharacter.ID)
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsPP = DBCommand.ExecuteReader

        While rsPP.Read
            ' Build the list of groups we have, then use to query the ones we don't
            GroupRawFlagList = GroupRawFlagList & "AND NOT (GROUP_NAME ='" & rsPP.GetString(0) & "' AND RAW_MATERIAL =" & CStr(rsPP.GetInt32(5)) & ") "

            TempProfile.GroupName = rsPP.GetString(0)
            TempProfile.PriceType = rsPP.GetString(1)
            TempProfile.RegionName = rsPP.GetString(2)
            TempProfile.SolarSystemName = rsPP.GetString(3)
            TempProfile.PriceModifier = rsPP.GetDouble(4)
            TempProfile.RawMaterial = CBool(rsPP.GetInt32(5))
            Profiles.Add(TempProfile)
        End While

        rsPP.Close()

        ' Now get everything we don't have
        SQL = "SELECT GROUP_NAME, PRICE_TYPE, REGION_NAME, SOLAR_SYSTEM_NAME, PRICE_MODIFIER, RAW_MATERIAL "
        SQL = SQL & "FROM PRICE_PROFILES WHERE ID = 0 " & GroupRawFlagList & ""
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsPP = DBCommand.ExecuteReader

        While rsPP.Read
            TempProfile.GroupName = rsPP.GetString(0)
            TempProfile.PriceType = rsPP.GetString(1)
            TempProfile.RegionName = rsPP.GetString(2)
            TempProfile.SolarSystemName = rsPP.GetString(3)
            TempProfile.PriceModifier = rsPP.GetDouble(4)
            TempProfile.RawMaterial = CBool(rsPP.GetInt32(5))
            Profiles.Add(TempProfile)
        End While

        rsPP.Close()

        ' Load the lists
        Dim listRow As New ListViewItem

        For i = 0 To Profiles.Count - 1
            With Profiles(i)
                listRow = New ListViewItem(.GroupName)
                'The remaining columns are subitems  
                listRow.SubItems.Add(.PriceType)
                listRow.SubItems.Add(.RegionName)
                listRow.SubItems.Add(.SolarSystemName)
                listRow.SubItems.Add(FormatPercent(.PriceModifier, 1))

            End With
        Next

        rsPP.Close()

    End Sub

    ' Save the settings
    Private Sub SaveUpdatePrices()
        Dim i As Integer
        Dim TempSettings As UpdatePriceTabSettings = Nothing
        Dim TempRegions As New List(Of String)

        Dim RegionChecked As Boolean = False
        Dim SystemChecked As Boolean = False
        Dim SearchSystem As String = ""

        ' Check systems too
        For i = 1 To SystemCheckBoxes.Length - 1
            If SystemCheckBoxes(i).Checked = True Then
                ' Save the checked system (can only be one)
                SearchSystem = SystemCheckBoxes(i).Text
                SystemChecked = True
                Exit For
            End If
        Next

        ' Finally check system combo
        If Not SystemChecked Then
            SystemChecked = True
        End If

        If Not RegionChecked And Not SystemChecked Then
            MsgBox("Must Choose a Region or System", MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If

        If Not ItemsSelected() Then
            MsgBox("Must Choose at least one Item type", MsgBoxStyle.Exclamation, Me.Name)
            Exit Sub
        End If

        TempSettings.ItemsCombo = "0.0%"
        TempSettings.RawMatsCombo = "0.0%"

        TempSettings.RawPriceModifier = 0
        TempSettings.ItemsPriceModifier = 0

        ' Search for a set system first
        TempSettings.SelectedSystem = "0"
        For i = 1 To SystemCheckBoxes.Count - 1
            If SystemCheckBoxes(i).Checked Then
                ' Save it
                TempSettings.SelectedSystem = SystemCheckBoxes(i).Text
                Exit For
            End If
        Next

        ' If no system found, then region
        If TempSettings.SelectedSystem = "0" Then
            ' Loop through the region checks and find checked regions
            For i = 1 To RegionCheckBoxes.Count - 1
                If RegionCheckBoxes(i).Checked = True Then
                    TempRegions.Add(RegionCheckBoxes(i).Text)
                End If
            Next
            TempSettings.SelectedRegions = TempRegions
        End If

        ' Raw items
        ' Manufactured Items
        With TempSettings
            .Minerals = True
            .IceProducts = True
            .AbyssalMaterials = True
            .Misc = True
            .Salvage = True
            .Planetary = True
            .MatsandCompounds = True
            .Asteroids = True
            .Ships = True
            .Modules = True
            .Drones = True
            .Rigs = True
            .Charges = True
            .Tools = True
            .FuelBlocks = True
            .T1 = True
            .UseESIData = True
            .UsePriceProfile = False

        End With

        TempSettings.ColumnSort = UpdatePricesColumnClicked

        If UpdatePricesColumnSortType = SortOrder.Ascending Then
            TempSettings.ColumnSortType = "Ascending"
        Else
            TempSettings.ColumnSortType = "Descending"
        End If

        ' Save the data in the XML file
        Call AllSettings.SaveUpdatePricesSettings(TempSettings)

        ' Save the data to the local variable
        UserUpdatePricesTabSettings = TempSettings

        btnDownloadPrices.Focus()
        Application.UseWaitCursor = False

    End Sub

    Private Sub lstPricesView_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Call ListClicked(lstPricesView, sender, e)
    End Sub

    Private Sub btnAddStructureIDs_Click(sender As Object, e As EventArgs)
        Dim f1 As New frmAddStructureIDs

        f1.ShowDialog()

    End Sub

    ' Sets the price profile defaults for anything that has a price profile set
    Private Sub SetPriceProfileDefaults(PriceType As String, PriceRegion As String, PriceSystem As String, PriceMod As String, RawMat As Boolean)
        Dim SQL As String = ""
        Dim PriceModStr As String = PriceMod.Replace("%", "")

        SQL = "UPDATE PRICE_PROFILES SET PRICE_TYPE = '" & Trim(PriceType) & "', REGION_NAME = '" & FormatDBString(PriceRegion) & "', "
        SQL = SQL & "SOLAR_SYSTEM_NAME = '" & FormatDBString(PriceSystem) & "', PRICE_MODIFIER = " & CStr(CDbl(PriceMod.Replace("%", "")) / 100) & " "
        SQL = SQL & "WHERE ID IN (" & SelectedCharacter.ID & ",0) AND RAW_MATERIAL = "
        If RawMat Then
            SQL = SQL & "1"
        Else
            SQL = SQL & "0"
        End If

        EVEDB.ExecuteNonQuerySQL(SQL)

    End Sub

    ' Checks the user entry and then sends the type ids and regions to the cache update
    Private Sub btnImportPrices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadPrices.Click
        Dim i As Integer
        Dim j As Integer

        Dim RegionChecked As Boolean
        Dim SystemChecked As Boolean
        Dim readerSystems As SQLiteDataReader
        Dim SQL As String

        Dim RegionName As String = ""
        Dim Items As New List(Of PriceItem)
        Dim TempItem As PriceItem
        Dim SearchRegion As String = ""
        Dim SearchSystem As String = ""
        Dim SearchStructureID As String = ""
        Dim NumSystems As Integer = 0

        RegionChecked = False
        SystemChecked = False

        'Save Settings
        SaveUpdatePrices()

        ' Progress Bar Init
        MetroProgressBar.Value = 0

        Dim RegionSelectedCount As Integer = 0

        ' Check systems too
        For i = 1 To SystemCheckBoxes.Length - 1
            If SystemCheckBoxes(i).Checked = True Then
                ' Save the checked system (can only be one)
                SearchSystem = SystemCheckBoxes(i).Text
                SystemChecked = True
                Exit For
            End If
        Next

        ' Finally check system combo
        If Not SystemChecked Then
            SystemChecked = True
        End If

        If Not RegionChecked And Not SystemChecked Then
            MsgBox("Must Choose a Region or System", MsgBoxStyle.Exclamation, Me.Name)
            GoTo ExitSub
        End If

        If Not ItemsSelected() Then
            MsgBox("Must Choose at least one Item type", MsgBoxStyle.Exclamation, Me.Name)
            GoTo ExitSub
        End If

        If RegionSelectedCount > 1 Then
            MsgBox("You cannot choose more than one region when downloading CCP Data", MsgBoxStyle.Exclamation, Me.Name)
            GoTo ExitSub
        End If

        ' Working
        Call DisableUpdatePricesTab(True)

        ' Enable cancel
        btnCancelUpdate.Enabled = True

        Me.Refresh()
        Cursor.Current = Cursors.WaitCursor
        pnlStatus.Text = "Initializing Query..."
        Application.DoEvents()

        ' Find the checked region - single select
        If True Then ' Always use single select
            If RegionChecked Then
                For i = 1 To (RegionCheckBoxes.Length - 1)
                    If RegionCheckBoxes(i).Checked Then
                        Select Case i
                            Case 15, 26, 36, 50, 59 'These have () in description

                                ' Find the location of the ( and trim back from that
                                RegionName = RegionCheckBoxes(i).Text
                                j = InStr(1, RegionName, "(")

                                RegionName = RegionName.Substring(0, j - 2)

                            Case Else
                                RegionName = RegionCheckBoxes(i).Text
                        End Select

                        SearchRegion = RegionName
                        Exit For
                    End If
                Next

                ' Get the search list string
                SQL = "SELECT regionID FROM REGIONS "
                SQL = SQL & "WHERE regionName = '" & SearchRegion & "'"

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                readerSystems = DBCommand.ExecuteReader
                If readerSystems.Read Then
                    SearchRegion = CStr(readerSystems.GetValue(0))
                Else
                    MsgBox("Invalid Region Name", vbCritical, Application.ProductName)
                    GoTo ExitSub
                End If

                readerSystems.Close()
                readerSystems = Nothing
                DBCommand = Nothing

            ElseIf SystemChecked Then
                ' Get the system list string
                SQL = "SELECT solarSystemID, regionName FROM SOLAR_SYSTEMS, REGIONS "
                SQL = SQL & "WHERE REGIONS.regionID = SOLAR_SYSTEMS.regionID AND solarSystemName = '" & SearchSystem & "'"

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                readerSystems = DBCommand.ExecuteReader
                If readerSystems.Read Then
                    SearchSystem = CStr(readerSystems.GetValue(0))
                Else
                    MsgBox("Invalid Solar System Name", vbCritical, Application.ProductName)
                    GoTo ExitSub
                End If

                readerSystems.Close()
                readerSystems = Nothing
                DBCommand = Nothing
            End If
        End If

        ' Build the list of types we want to update and include the type, region/system
        For i = 0 To lstPricesView.Items.Count - 1

            ' Only include items that are in the market (Market ID not null in Inventory Types)
            If lstPricesView.Items(i).SubItems(5).Text <> "" Then
                TempItem = New PriceItem
                TempItem.TypeID = CLng(lstPricesView.Items(i).SubItems(0).Text)
                TempItem.GroupName = GetPriceGroupName(TempItem.TypeID)

                ' If the group name exists, then look it up
                If TempItem.GroupName <> "" Then
                    TempItem.Manufacture = CBool(lstPricesView.Items(i).SubItems(4).Text)
                    TempItem.RegionID = ""

                    If True Then 'Always use single select
                        TempItem.RegionID = SearchRegion
                        TempItem.SystemID = SearchSystem
                        TempItem.StructureID = SearchStructureID
                        'Start with the maximum IPH (normal Buy Orders for Raw and Sell Orders for Manufactured)
                        If TempItem.Manufacture Then
                            TempItem.PriceType = "Percentile Sell"
                            TempItem.PriceModifier = 0
                        Else
                            TempItem.PriceType = "Percentile Buy"
                            TempItem.PriceModifier = 0
                        End If
                    Else
                        ' Using price profiles, so look up all the data per group name
                        Dim rsPP As SQLiteDataReader
                        SQL = "SELECT PRICE_TYPE, regionID, SOLAR_SYSTEM_NAME, PRICE_MODIFIER FROM PRICE_PROFILES, REGIONS "
                        SQL = SQL & "WHERE REGIONS.regionName = PRICE_PROFILES.REGION_NAME "
                        SQL = SQL & "AND (ID = " & CStr(SelectedCharacter.ID) & " OR ID = 0) AND GROUP_NAME = '" & TempItem.GroupName & "' ORDER BY ID DESC"

                        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                        rsPP = DBCommand.ExecuteReader

                        If rsPP.Read Then
                            TempItem.PriceType = rsPP.GetString(0)
                            If rsPP.GetString(2) = AllSystems Then
                                ' Can only do one region for price profile
                                TempItem.RegionID = CStr(rsPP.GetInt64(1))
                                TempItem.SystemID = ""
                            Else
                                ' Look up the system name
                                TempItem.SystemID = CStr(GetSolarSystemID(rsPP.GetString(2)))
                            End If
                            TempItem.PriceModifier = rsPP.GetDouble(3)
                        End If
                    End If

                    ' Add the item to the list if not there and it's not a blueprint (we don't want to query blueprints since it will return bpo price and we are using this for bpc
                    If Not Items.Contains(TempItem) And Not lstPricesView.Items(i).SubItems(1).Text.Contains("Blueprint") Then
                        Items.Add(TempItem)
                    End If
                End If
            End If
        Next

        ' Load the prices
        Call LoadPrices(Items)

UpdateProgramPrices:

        ' Update all the prices in the program
        Call UpdateProgramPrices()

ExitSub:

        Application.UseWaitCursor = False
        Application.DoEvents()
        ' Enable tab
        Call DisableUpdatePricesTab(False)

        ' Disable cancel
        btnCancelUpdate.Enabled = False

        Me.Refresh()
        Cursor.Current = Cursors.Default
        MetroProgressBar.Visible = False
        pnlStatus.Text = ""

    End Sub

    ' Loads prices from the cache into the ITEM_PRICES table based on the info selected on the main form
    Private Sub LoadPrices(ByVal SentItems As List(Of PriceItem))
        Dim readerPrices As SQLiteDataReader
        Dim RiskPrices As SQLiteDataReader
        Dim SQL As String = ""
        Dim RiskSQL As String = ""
        Dim i As Integer
        Dim RegionList As String
        Dim SelectedPrice As Double
        Dim RiskPrice As Double
        Dim MP As New MarketPriceInterface(MetroProgressBar)
        Dim ESIData As New ESI
        Dim ItemTypeIDs = New List(Of String)
        Dim RegionID As String = ""
        Dim PriceRegions As New List(Of String)
        Dim PriceType As String = "" ' Default
        Dim Items As New List(Of TypeIDRegion)

        ' Use CCP Data
        If True Then 'Always use CCP Data
            ' Loop through each item and set it's pair for query
            For i = 0 To SentItems.Count - 1
                Dim Temp As New TypeIDRegion
                Temp.TypeIDs.Add(CStr(SentItems(i).TypeID))

                ' Look up regionID since we can only look up regions in ESI
                If SentItems(i).SystemID <> "" Then
                    DBCommand = New SQLiteCommand("SELECT regionID FROM SOLAR_SYSTEMS WHERE solarsystemID = '" & SentItems(i).SystemID & "'", EVEDB.DBREf)
                    readerPrices = DBCommand.ExecuteReader
                    readerPrices.Read()
                    RegionID = CStr(readerPrices.GetInt64(0))
                    readerPrices.Close()
                    DBCommand = Nothing
                Else
                    ' for ESI, only one region per update
                    RegionID = SentItems(i).RegionID
                End If

                ' Set the region
                Temp.RegionString = RegionID

                ' Save the ItemID in the list
                ItemTypeIDs.Add(CStr(SentItems(i).TypeID))
                ' Save the regionID in the list
                If Not PriceRegions.Contains(RegionID) Then
                    PriceRegions.Add(RegionID)
                End If

                ' Save the item with the region on it
                Items.Add(Temp)
            Next

            pnlStatus.Text = "Downloading Station Prices..."

            ' Update the ESI prices cache
            If Not MP.UpdateESIMarketOrders(Items) Then
                ' Update Failed, don't reload everything
                Call MsgBox("Some prices did not update from stations. Please try again.", vbInformation, Application.ProductName)
                pnlStatus.Text = ""
                Exit Sub
            End If

            If CancelThreading Then
                ' They had a ton of errors
                Call MsgBox("You had an excessive amount of errors while attempting to update station orders and the process was canceled. Please try again later.", vbCritical, Application.ProductName)
                CancelThreading = False
                Exit Sub
            End If

            pnlStatus.Text = ""
            Application.DoEvents()

            ' Now, based on the region and selected items, select the public upwell structures and get each set of market data from those
            If SelectedCharacter.StructureMarketsAccess And SelectedCharacter.PublicStructuresAccess And Not CancelUpdatePrices Then
                pnlStatus.Text = "Downloading Public Structure Prices..."

                ' First, make sure we have structures in the table to query
                Call ESIData.UpdatePublicStructureswithMarkets()

                If Not ESIData.UpdateStructureMarketOrders(PriceRegions, SelectedCharacter.CharacterTokenData, MetroProgressBar) Then
                    ' Update Failed, don't reload everything
                    Call MsgBox("Some prices did not update from public structures. Please try again.", vbInformation, Application.ProductName)
                    pnlStatus.Text = ""
                    Exit Sub
                End If

                If CancelThreading Then
                    ' They had a ton of errors
                    Call MsgBox("You had an excessive amount of errors while attempting to update structure orders and the process was canceled. Please try again later.", vbCritical, Application.ProductName)
                    CancelThreading = False
                    Exit Sub
                End If

                pnlStatus.Text = ""
            End If
        Else
            ' Update the EVE Marketer cache
            If Not UpdatePricesCache(SentItems) Then
                ' Update Failed, don't reload everything
                Exit Sub
            End If

        End If

        ' Working
        pnlStatus.Text = "Updating Item Prices..."
        RegionList = ""
        MetroProgressBar.Value = 0
        MetroProgressBar.Minimum = 0
        MetroProgressBar.Maximum = SentItems.Count + 1
        MetroProgressBar.Visible = True

        Application.DoEvents()

        If EVEDB.TransactionActive And CancelUpdatePrices Then
            ' We Canceled the update so rollback anything
            EVEDB.RollbackSQLiteTransaction()
        End If

        Call EVEDB.BeginSQLiteTransaction()

        ' Select the prices from the cache table
        For i = 0 To SentItems.Count - 1
            ' Use combo values for min or max.
            Select Case SentItems(i).PriceType
                Case "Min Sell"
                    PriceType = "sellMin"
                Case "Max Sell"
                    PriceType = "sellMax"
                Case "Avg Sell"
                    PriceType = "sellAvg"
                Case "Median Sell"
                    PriceType = "sellMedian"
                Case "Percentile Sell"
                    PriceType = "sellPercentile"
                Case "Min Buy"
                    PriceType = "buyMin"
                Case "Max Buy"
                    PriceType = "buyMax"
                Case "Avg Buy"
                    PriceType = "buyAvg"
                Case "Median Buy"
                    PriceType = "buyMedian"
                Case "Percentile Buy"
                    PriceType = "buyPercentile"
                Case "Split Price"
                    PriceType = "splitPrice"
            End Select

            ' Build the region list for each item
            RegionList = ""
            If SentItems(i).SystemID = "" Then
                RegionList = SentItems(i).RegionID
            Else
                RegionList = SentItems(i).SystemID
            End If

            Dim LimittoBuy As Boolean = False
            Dim LimittoSell As Boolean = False
            Dim SystemID As String = ""

            RegionID = ""

            If SentItems(i).SystemID <> "" Then
                SystemID = RegionList
            Else
                RegionID = RegionList
            End If

            ' Get the data from ESI so we need to do some calcuations depending on the type they want
            SQL = "SELECT "
            RiskSQL = "SELECT "
            Select Case PriceType
                Case "buyAvg"
                    SQL = SQL & "AVG(PRICE)"
                    LimittoBuy = True
                Case "buyMax"
                    SQL = SQL & "MAX(PRICE)"
                    LimittoBuy = True
                Case "buyMedian"
                    SQL = SQL & CalcMedian(SentItems(i).TypeID, RegionID, SystemID, True)
                Case "buyMin"
                    SQL = SQL & "MIN(PRICE)"
                    LimittoBuy = True
                Case "buyPercentile"
                    SQL = SQL & CalcPercentile(SentItems(i).TypeID, RegionID, SystemID, True)
                Case "sellAvg"
                    SQL = SQL & "AVG(PRICE)"
                    LimittoSell = True
                Case "sellMax"
                    SQL = SQL & "MAX(PRICE)"
                    LimittoSell = True
                Case "sellMedian"
                    SQL = SQL & CalcMedian(SentItems(i).TypeID, RegionID, SystemID, False)
                Case "sellMin"
                    SQL = SQL & "MIN(PRICE)"
                    LimittoSell = True
                Case "sellPercentile"
                    SQL = SQL & CalcPercentile(SentItems(i).TypeID, RegionID, SystemID, False)
                Case "splitPrice"
                    SQL = SQL & CalcSplit(SentItems(i).TypeID, RegionID, SystemID)
            End Select

            'Switch to the other price type for the risk price
            If PriceType = "buyPercentile" Then
                RiskSQL = RiskSQL & CalcPercentile(SentItems(i).TypeID, RegionID, SystemID, False)
            Else
                RiskSQL = RiskSQL & CalcPercentile(SentItems(i).TypeID, RegionID, SystemID, True)
            End If


            ' Set the main from using both price locations
            SQL = SQL & " FROM (SELECT * FROM MARKET_ORDERS UNION ALL SELECT * FROM STRUCTURE_MARKET_ORDERS) WHERE TYPE_ID = " & CStr(SentItems(i).TypeID) & " "
            RiskSQL = RiskSQL & " FROM (SELECT * FROM MARKET_ORDERS UNION ALL SELECT * FROM STRUCTURE_MARKET_ORDERS) WHERE TYPE_ID = " & CStr(SentItems(i).TypeID) & " "

            ' If they want a system, then limit all the data to that system id
            If SentItems(i).SystemID <> "" Then
                SQL = SQL & "AND SOLAR_SYSTEM_ID = " & RegionList & " "
                RiskSQL = RiskSQL & "AND SOLAR_SYSTEM_ID = " & RegionList & " "
            Else
                ' Use the region
                SQL = SQL & "AND REGION_ID = " & RegionList & " "
                RiskSQL = RiskSQL & "AND REGION_ID = " & RegionList & " "
            End If

            ' See if we limit to buy/sell only
            If LimittoBuy Then
                SQL = SQL & "AND IS_BUY_ORDER <> 0"
                RiskSQL = RiskSQL & "AND IS_BUY_ORDER <> 0"
            ElseIf LimittoSell Then
                SQL = SQL & "AND IS_BUY_ORDER = 0"
                RiskSQL = RiskSQL & "AND IS_BUY_ORDER = 0"
            End If

            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            readerPrices = DBCommand.ExecuteReader

            DBCommand = New SQLiteCommand(RiskSQL, EVEDB.DBREf)
            RiskPrices = DBCommand.ExecuteReader

            ' Grab the first record, which will be the latest one, if no record just leave what is already in item prices
            If readerPrices.Read Then
                If Not IsDBNull(readerPrices.GetValue(0)) Then
                    ' Modify the price depending on modifier
                    SelectedPrice = readerPrices.GetDouble(0) * (1 + SentItems(i).PriceModifier)

                    'If this is a manufactured product, predict the future price that we will sell at, for raw materials, we use the current price above
                    If SentItems(i).Manufacture Then
                        'Using The Forge as the default region identify the near and long trends
                        Dim LongTrend As Double = CalculatePriceTrend(SentItems(i).TypeID, TheForgeTypeID, 90)
                        Dim NearTrend As Double = CalculatePriceTrend(SentItems(i).TypeID, TheForgeTypeID, 15)
                        'Now calculate how much that trend would affect the price if we sold next week
                        LongTrend = LongTrend / (90 / 7)
                        NearTrend = NearTrend / (15 / 7)
                        'Modify the price based on the trend. The long term trend is more likely overall, but the near trend may be more indicative of the price next week, the weight for each is equal
                        'Limit any trends over 25% per week since it could be a spike
                        Dim TrendModifier = (LongTrend + NearTrend) / 2
                        If TrendModifier > 0.25 Then
                            TrendModifier = 0.25
                        ElseIf TrendModifier < -0.25 Then
                            TrendModifier = -0.25
                        End If
                        SelectedPrice = SelectedPrice * (1 + TrendModifier)

                        'Now eliminate spikes to avoid market manipulation
                        'If the price we came up with was way above the 3month average, just use that
                        Dim average = CalculatePriceAverage(SentItems(i).TypeID, TheForgeTypeID, 90)
                        If average > 0 Then
                            If SelectedPrice > 3 * average Then
                                SelectedPrice = average
                            End If
                        End If

                    End If

                    ' Now Update the ITEM_PRICES table, set price and price type
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " & CStr(SelectedPrice) & ", PRICE_TYPE = '" & PriceType & "' WHERE ITEM_ID = " & CStr(SentItems(i).TypeID)
                    Call EVEDB.ExecuteNonQuerySQL(SQL)

                End If
                readerPrices.Close()
                readerPrices = Nothing
                DBCommand = Nothing
            End If

            ' Grab the first record, which will be the latest one, if no record just leave what is already in item prices
            If RiskPrices.Read Then
                If Not IsDBNull(RiskPrices.GetValue(0)) Then
                    ' Modify the price depending on modifier
                    RiskPrice = RiskPrices.GetDouble(0) * (1 + SentItems(i).PriceModifier)

                    ' Now Update the ITEM_PRICES table, set price and price type
                    SQL = "UPDATE ITEM_PRICES_FACT SET RISK_PRICE = " & CStr(RiskPrice) & " WHERE ITEM_ID = " & CStr(SentItems(i).TypeID)
                    Call EVEDB.ExecuteNonQuerySQL(SQL)

                End If
                RiskPrices.Close()
                RiskPrices = Nothing
                DBCommand = Nothing
            End If

            ' For each record, update the progress bar
            Call IncrementToolStripProgressBar(MetroProgressBar)

            Application.DoEvents()
        Next

        Call EVEDB.CommitSQLiteTransaction()

        ' Done updating, hide the progress bar
        MetroProgressBar.Visible = False
        pnlStatus.Text = ""
        Application.DoEvents()

    End Sub

    Private Function CalcSplit(TypeID As Long, RegionID As String, SystemID As String) As String
        Dim SQL As String = ""
        Dim rsData As SQLiteDataReader
        Dim PriceList As New List(Of Double)
        Dim SellOrderSQL As String = "AND IS_BUY_ORDER = 0 "
        Dim BuyOrderSQL As String = "AND IS_BUY_ORDER <> 0 "

        Dim MinSellPrice As Double = 0
        Dim MaxBuyPrice As Double = 0

        SQL = "SELECT MIN(PRICE) FROM (SELECT * FROM MARKET_ORDERS UNION ALL SELECT * FROM STRUCTURE_MARKET_ORDERS) WHERE TYPE_ID = " & CStr(TypeID) & " "
        If SystemID <> "" Then
            SQL = SQL & "AND SOLAR_SYSTEM_ID = " & SystemID & " "
        Else
            ' Use the region
            SQL = SQL & "AND REGION_ID = " & RegionID & " "
        End If

        ' Look up the min sell price
        DBCommand = New SQLiteCommand(SQL & SellOrderSQL, EVEDB.DBREf)
        rsData = DBCommand.ExecuteReader
        rsData.Read()

        If rsData.HasRows Then
            If Not IsDBNull(rsData.GetValue(0)) Then
                MinSellPrice = rsData.GetDouble(0)
            End If
        End If

        SQL = "SELECT MAX(PRICE) FROM (SELECT * FROM MARKET_ORDERS UNION ALL SELECT * FROM STRUCTURE_MARKET_ORDERS) WHERE TYPE_ID = " & CStr(TypeID) & " "
        If SystemID <> "" Then
            SQL = SQL & "AND SOLAR_SYSTEM_ID = " & SystemID & " "
        Else
            ' Use the region
            SQL = SQL & "AND REGION_ID = " & RegionID & " "
        End If

        ' Look up the max buy order
        DBCommand = New SQLiteCommand(SQL & BuyOrderSQL, EVEDB.DBREf)
        rsData = DBCommand.ExecuteReader
        rsData.Read()

        If rsData.HasRows Then
            If Not IsDBNull(rsData.GetValue(0)) Then
                MaxBuyPrice = rsData.GetDouble(0)
            End If
        End If

        rsData.Close()

        Return CStr((MaxBuyPrice + MinSellPrice) / 2)

    End Function

    ' Queries market orders and calculates the median and returns the median as a string
    Private Function CalcMedian(TypeID As Long, RegionID As String, SystemID As String, IsBuyOrder As Boolean) As String
        Dim MedianList As List(Of Double) = GetMarketOrderPriceList(TypeID, RegionID, SystemID, IsBuyOrder)
        Dim value As Double
        Dim size As Integer = MedianList.Count

        ' Calculate the median
        If size > 0 Then
            If size Mod 2 = 0 Then
                ' Need to average
                Dim a As Double = MedianList(CInt(size / 2 - 1))
                Dim b As Double = MedianList(CInt(size / 2))
                value = (a + b) / 2
            Else
                value = MedianList(CInt(Math.Floor(size / 2)))
            End If
        Else
            value = 0
        End If

        ' return 2 decimals
        Return FormatNumber(value, 2)

    End Function

    ' Queries market orders and calculates the percential price
    Private Function CalcPercentile(TypeID As Long, RegionID As String, SystemID As String, IsBuyOrder As Boolean) As String
        Dim PriceList As List(Of Double) = GetMarketOrderPriceList(TypeID, RegionID, SystemID, IsBuyOrder)
        Dim index As Integer

        If PriceList.Count > 0 Then
            If IsBuyOrder Then
                ' Get the top 5% 
                index = CInt(Math.Floor(0.95 * PriceList.Count))
            Else
                ' Get the bottom 5% for SELL or ALL - matches EVE Central?
                index = CInt(Math.Floor(0.05 * PriceList.Count))
            End If
            Return CStr(PriceList(index))
        Else
            Return "0.00"
        End If

    End Function

    ' Returns the list of prices for variables sent, sorted ascending
    Private Function GetMarketOrderPriceList(TypeID As Long, RegionID As String, SystemID As String, IsBuyOrder As Boolean) As List(Of Double)
        Dim SQL As String = ""
        Dim rsData As SQLiteDataReader
        Dim PriceList As New List(Of Double)

        SQL = "SELECT PRICE FROM (SELECT * FROM MARKET_ORDERS UNION ALL SELECT * FROM STRUCTURE_MARKET_ORDERS) WHERE TYPE_ID = " & CStr(TypeID) & " "
        If SystemID <> "" Then
            SQL = SQL & "AND SOLAR_SYSTEM_ID = " & SystemID & " "
        Else
            ' Use the region
            SQL = SQL & "AND REGION_ID = " & RegionID & " "
        End If

        If IsBuyOrder Then
            SQL = SQL & "AND IS_BUY_ORDER <> 0 "
        Else
            SQL = SQL & "AND IS_BUY_ORDER = 0 "
        End If

        SQL = SQL & "ORDER BY PRICE ASC"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsData = DBCommand.ExecuteReader

        While rsData.Read
            PriceList.Add(rsData.GetDouble(0))
        End While

        Return PriceList

    End Function

    ' Gets the group name from ITEM_PRICES
    Private Function GetPriceGroupName(TypeID As Long) As String
        Dim SQL As String = "SELECT ITEM_GROUP, ITEM_CATEGORY, ITEM_NAME FROM ITEM_PRICES WHERE ITEM_ID = " & CStr(TypeID)
        Dim rsGroup As SQLiteDataReader
        Dim RGN As String = ""
        Dim GN As String = ""
        Dim CN As String = ""
        Dim ITN As String = ""

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsGroup = DBCommand.ExecuteReader

        If rsGroup.Read Then
            GN = rsGroup.GetString(0)
            CN = rsGroup.GetString(1)
            ITN = rsGroup.GetString(2)

            Select Case GN
                Case "Mineral"
                    RGN = "Minerals"
                Case "Ice Product"
                    RGN = "Ice Products"
                Case "Datacores"
                    RGN = "Datacores"
                Case "Harvestable Cloud"
                    RGN = "Gas"
                Case "Abyssal Materials"
                    RGN = "Abyssal Materials"
                Case "Salvaged Materials"
                    RGN = "Salvage"
                Case "Ancient Salvage"
                    RGN = "Ancient Salvage"
                Case "Hybrid Polymers"
                    RGN = "Hybrid Polymers"
                Case "Moon Materials"
                    RGN = "Raw Moon Materials"
                Case "Intermediate Materials"
                    RGN = "Processed Moon Materials"
                Case "Composite"
                    RGN = "Advanced Moon Materials"
                Case "Materials and Compounds", "Artifacts and Prototypes", "Named Components"
                    RGN = "Materials & Compounds"
                Case "Biochemical Material"
                    RGN = "Booster Materials"
                Case "Advanced Capital Construction Components"
                    RGN = "Adv. Capital Construction Components"
                Case "Capital Construction Components"
                    RGN = "Capital Construction Components"
                Case "Construction Components"
                    RGN = "Construction Components"
                Case "Hybrid Tech Components"
                    RGN = "Hybrid Tech Components"
                Case "Tool"
                    RGN = "Tools"
                Case "Fuel Block"
                    RGN = "Fuel Blocks"
                Case "Station Components"
                    RGN = "Station Parts"
                Case "Booster"
                    RGN = "Boosters"
                Case "Structure Components"
                    RGN = "Structure Components"
                Case Else
                    ' Do if checks or select on category
                    If GN.Contains("Decryptor") Then
                        RGN = "Decryptors"
                    ElseIf (GN = "General" Or GN = "Livestock" Or GN = "Radioactive" Or GN = "Biohazard" Or GN = "Commodities" _
                        Or GN = "Empire Insignia Drops" Or GN = "Criminal Tags" Or GN = "Miscellaneous" Or GN = "Unknown Components" Or GN = "Lease") _
                        And (ITN <> "Oxygen" And ITN <> "Water" And ITN <> "Elite Drone AI") Then
                        RGN = "Misc."
                    ElseIf GN = "Rogue Drone Components" Or ITN = "Elite Drone AI" Then
                        RGN = "Rogue Drone Components"
                    ElseIf GN = "Cyberimplant" Or (CN = "Implant" And GN <> "Booster") Then
                        RGN = "Implants"
                    ElseIf CN.Contains("Planetary") Or ITN = "Oxygen" Or ITN = "Water" Then
                        RGN = "Planetary"
                    ElseIf CN = "Blueprint" Then
                        RGN = "Blueprints"
                    ElseIf CN = "Ancient Relics" Then
                        RGN = "Ancient Relics"
                    ElseIf CN = "Deployable" Then
                        RGN = "Deployables"
                    ElseIf CN = "Asteroid" Then
                        RGN = "Asteroids"
                    ElseIf CN = "Ship" Then
                        RGN = "Ships"
                    ElseIf CN = "Subsystem" Then
                        RGN = "Subsystems"
                    ElseIf CN = "Structure Module" Then
                        RGN = "Structure Modules"
                    ElseIf CN = "Starbase" Then
                        RGN = "Structures"
                    ElseIf CN = "Charge" Then
                        RGN = "Charges"
                    ElseIf CN = "Drone" Or CN = "Fighter" Then
                        RGN = "Drones"
                    ElseIf CN = "Module" And Not GN.Contains("Rig") Then
                        RGN = "Modules"
                    ElseIf CN = "Module" And GN.Contains("Rig") Then
                        RGN = "Rigs"
                    ElseIf (CN = "Celestial" Or CN = "Orbitals" Or CN = "Sovereignty Structures" Or CN = "Station" Or CN = "Accessories" Or CN = "Infrastructure Upgrades") And GN <> "Harvestable Clound" Then
                        RGN = "Celestials"
                    ElseIf CN = "Structure" Then
                        RGN = "Structures"
                    ElseIf CN = "Structure Rigs" Then
                        RGN = "Structure Rigs"
                    Else
                        RGN = CN
                    End If
            End Select
        End If

        Return RGN

    End Function

    ' Adds prices for each type id and region to the cache 
    Private Function UpdatePricesCache(ByVal CacheItems As List(Of PriceItem)) As Boolean
        Dim TypeIDUpdatePriceList As New List(Of Long)
        Dim i As Integer
        Dim SQL As String = ""
        Dim PriceRecords As List(Of EVEMarketerPrice)
        Dim EVEMarketerPrices = New EVEMarketer
        Dim EVEMarketerError As MyError

        Dim RegionSystem As String = "" ' Used for querying the Price Cache for regions
        Dim RegionID As Integer = 0
        Dim SystemID As Integer = 0
        Dim TotalUpdateItems As Integer = 0 ' For progress bar, only count the ones we update
        Dim InsertRecord As Boolean = False
        Dim QueryEVEMarketer As Boolean = False
        Dim readerPriceCheck As SQLiteDataReader

        ' Reset the value of the progress bar
        MetroProgressBar.Value = 0
        If CacheItems.Count <> 0 Then
            MetroProgressBar.Maximum = CacheItems.Count - 1
        Else
            MetroProgressBar.Maximum = 0
        End If

        MetroProgressBar.Visible = True
        CancelUpdatePrices = False

        pnlStatus.Text = "Checking Items..."
        Application.DoEvents()

        ' Loop through the list of items to get full query of just those that need to be updated
        For i = 0 To CacheItems.Count - 1

            If CancelUpdatePrices Then
                Exit For
            End If

            ' Reset Insert
            InsertRecord = False

            ' Get the region/system list since they will always be the same, use the first one for EVE Marketer
            If CacheItems(i).SystemID <> "" Then
                RegionSystem = CacheItems(i).SystemID
                SystemID = CInt(RegionSystem)
            Else
                RegionSystem = CacheItems(i).RegionID
                RegionID = CInt(RegionSystem)
            End If

            ' See if the record is in the cache first
            SQL = "SELECT * FROM ITEM_PRICES_CACHE WHERE TYPEID = " & CStr(CacheItems(i).TypeID) & " And RegionOrSystem = '" & RegionSystem & "'"

            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            readerPriceCheck = DBCommand.ExecuteReader

            If Not readerPriceCheck.HasRows Then
                ' Not found
                InsertRecord = True
                readerPriceCheck.Close()
                readerPriceCheck = Nothing
                DBCommand = Nothing
            Else
                readerPriceCheck.Close()
                readerPriceCheck = Nothing
                DBCommand = Nothing

                ' There is a record, see if it needs to be updated (only update every 6 hours)
                SQL = "SELECT UPDATEDATE FROM ITEM_PRICES_CACHE WHERE TYPEID = " & CStr(CacheItems(i).TypeID) & " AND RegionOrSystem = '" & RegionSystem & "'"
                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                readerPriceCheck = DBCommand.ExecuteReader

                ' If no record or the max date
                If readerPriceCheck.Read Then
                    ' If older than the interval, add a new record
                    If DateTime.ParseExact(readerPriceCheck.GetString(0), SQLiteDateFormat, LocalCulture) < DateAdd(DateInterval.Hour, -1 * UserApplicationSettings.EVEMarketerRefreshInterval, Now) Then
                        InsertRecord = True
                    End If
                End If

                readerPriceCheck.Close()
                readerPriceCheck = Nothing
                DBCommand = Nothing

            End If

            ' Add to query item list for EVE Central
            If InsertRecord Then
                ' Add to the list
                TypeIDUpdatePriceList.Add(CacheItems(i).TypeID)

                ' Count up the update items
                TotalUpdateItems = TotalUpdateItems + 1
                ' We are inserting at least one record, so query eve central
                QueryEVEMarketer = True

            End If

            ' For each record, update the progress bar
            Call IncrementToolStripProgressBar(MetroProgressBar)

            Application.DoEvents()
        Next

        ' Don't show until download is done
        MetroProgressBar.Visible = False
        ' Reset the value of the progress bar
        MetroProgressBar.Value = 0
        ' Set the maximum updates for the progress bar
        MetroProgressBar.Maximum = TotalUpdateItems + 1

        If QueryEVEMarketer Then
            pnlStatus.Text = "Downloading Item Prices..."
            Application.DoEvents()

            ' Get the list of records to insert
            PriceRecords = EVEMarketerPrices.GetPrices(TypeIDUpdatePriceList, RegionID, SystemID)

            If IsNothing(PriceRecords) Then
                ' There was an error in the request 
                EVEMarketerError = EVEMarketerPrices.GetErrorData
                MsgBox("EVE Marketer Server is Unavailable" & Chr(13) & EVEMarketerError.Description & Chr(13) & "Please try again later", vbExclamation, Me.Text)
                UpdatePricesCache = False
                Exit Function
            End If

            ' Show the progress bar now and update status
            MetroProgressBar.Visible = True
            pnlStatus.Text = "Updating Price Cache..."
            Application.DoEvents()

            Call EVEDB.BeginSQLiteTransaction()

            ' Loop through the price records and insert each one
            For i = 0 To PriceRecords.Count - 1

                If CancelUpdatePrices Then
                    Exit For
                End If

                ' Insert record in Cache
                With PriceRecords(i)
                    ' First, delete the record
                    SQL = "DELETE FROM ITEM_PRICES_CACHE WHERE TYPEID = " & CStr(.TypeID) & " AND RegionOrSystem = '" & .RegionOrSystem & "'"
                    Call EVEDB.ExecuteNonQuerySQL(SQL)

                    ' Insert new data
                    SQL = "INSERT INTO ITEM_PRICES_CACHE (typeID, buyVolume, buyAvg, buyweightedAvg, buyMax, buyMin, buyStdDev, buyMedian, buyPercentile, buyVariance, "
                    SQL = SQL & "sellVolume, sellAvg, sellweightedAvg, sellMax, sellMin, sellStdDev, sellMedian, sellPercentile, sellVariance, RegionOrSystem, UpdateDate) VALUES "
                    SQL = SQL & "(" & CStr(.TypeID) & "," & CStr(.BuyVolume) & "," & CStr(.BuyAvgPrice) & "," & CStr(.BuyWeightedAveragePrice) & "," & CStr(.BuyMaxPrice) & "," & CStr(.BuyMinPrice) & "," & CStr(.BuyStdDev) & "," & CStr(.BuyMedian) & "," & CStr(.BuyPercentile) & "," & CStr(.BuyVariance) & ","
                    SQL = SQL & CStr(.SellVolume) & "," & CStr(.SellAvgPrice) & "," & CStr(.SellWeightedAveragePrice) & "," & CStr(.SellMaxPrice) & "," & CStr(.SellMinPrice) & "," & CStr(.SellStdDev) & "," & CStr(.SellMedian) & "," & CStr(.SellPercentile) & "," & CStr(.SellVariance) & ","
                    SQL = SQL & "'" & .RegionOrSystem & "','" & Format(Now, SQLiteDateFormat) & "')"

                End With

                Call EVEDB.ExecuteNonQuerySQL(SQL)

                ' For each record, update the progress bar
                Call IncrementToolStripProgressBar(MetroProgressBar)

                Application.DoEvents()
            Next

            Call EVEDB.CommitSQLiteTransaction()

        End If

        If CancelUpdatePrices Then
            Call MsgBox("Price Update Canceled", vbInformation, Application.ProductName)
        End If

        ' Done updating, hide the progress bar
        CancelUpdatePrices = False
        MetroProgressBar.Visible = False
        UpdatePricesCache = True
        pnlStatus.Text = ""
        Application.DoEvents()

    End Function

    ' Function just queries the items table based on the item type selection then updates the list
    Public Sub UpdatePriceList()
        Dim readerMats As SQLiteDataReader
        Dim SQL As String
        Dim TechSQL As String = ""
        Dim lstViewRow As ListViewItem
        Dim ItemChecked As Boolean = False

        ' See if we want to run the update
        ' This will happen in times of things like selecting all boxes
        If Not RunUpdatePriceList Then
            Exit Sub
        End If

        ' Working
        'Cursor.Current = Cursors.WaitCursor
        pnlStatus.Text = "Refreshing List..."
        Application.DoEvents()

        ' Add the marketGroupID to the list for checks later
        SQL = "SELECT ITEM_ID, ITEM_NAME, ITEM_GROUP, PRICE, MANUFACTURE, marketGroupID, PRICE_TYPE FROM ITEM_PRICES, INVENTORY_TYPES"
        SQL = SQL & " WHERE ITEM_PRICES.ITEM_ID = INVENTORY_TYPES.typeID AND ("

        ' Raw materials - non-manufacturable
        SQL = SQL & "ITEM_GROUP = 'Mineral' OR "
        SQL = SQL & "ITEM_GROUP = 'Ice Product' OR "
        SQL = SQL & "(ITEM_CATEGORY LIKE 'Planetary%' OR ITEM_NAME IN ('Oxygen','Water')) OR "
        ItemChecked = True
        'If chkAbyssalMaterials.Checked Then
        '    SQL = SQL & "ITEM_GROUP LIKE 'Abyssal%' OR "
        '    ItemChecked = True
        'End If
        ' Commodities = Shattered Villard Wheel
        SQL = SQL & "(ITEM_GROUP IN ('General','Livestock','Abyssal Materials','Radioactive','Biohazard','Commodities','Empire Insignia Drops','Criminal Tags','Miscellaneous','Unknown Components','Lease') AND ITEM_NAME NOT IN ('Oxygen','Water', 'Elite Drone AI')) OR "
        SQL = SQL & "ITEM_GROUP = 'Salvaged Materials' OR "
        SQL = SQL & "ITEM_GROUP IN ('Materials and Compounds', 'Artifacts and Prototypes', 'Named Components') OR "
        SQL = SQL & "ITEM_CATEGORY = 'Asteroid' OR "
        SQL = SQL & "ITEM_GROUP = 'Tool' OR "
        SQL = SQL & "ITEM_GROUP = 'Fuel Block' OR "

        ItemChecked = True

        If PriceCheckT1Enabled Then
            ' Add to SQL query for tech level
            TechSQL = TechSQL & "ITEM_TYPE = 1 OR "
        End If

        ' Format TechSQL - Add on Meta codes - 21,22,23,24 are T3
        If TechSQL <> "" Then
            TechSQL = "(" & TechSQL.Substring(0, TechSQL.Length - 3) & "OR ITEM_TYPE IN (21,22,23,24)) "
        End If

        ' Build Tech 1,2,3 Manufactured Items
        SQL = SQL & "(ITEM_CATEGORY = 'Charge' AND " & TechSQL
        SQL = SQL & ") OR "
        SQL = SQL & "(ITEM_CATEGORY IN ('Drone', 'Fighter') AND " & TechSQL & ") OR "
        SQL = SQL & "(ITEM_CATEGORY = 'Module' AND ITEM_GROUP NOT LIKE 'Rig%' AND " & TechSQL & ") OR "
        SQL = SQL & "(ITEM_CATEGORY = 'Ship' AND " & TechSQL
        SQL = SQL & ") OR "
        SQL = SQL & "((ITEM_CATEGORY = 'Module' AND ITEM_GROUP LIKE 'Rig%' AND " & TechSQL & ") OR (ITEM_CATEGORY = 'Structure Module' AND ITEM_GROUP LIKE '%Rig%')) OR "


        ' Leave function if no items checked
        If Not ItemChecked Then
            lstPricesView.Items.Clear()
        Else
            ' Take off last OR and add the final )
            SQL = SQL.Substring(0, SQL.Length - 4)
            SQL = SQL & ")"

            SQL = SQL & " ORDER BY ITEM_GROUP, ITEM_CATEGORY, ITEM_NAME"

            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            readerMats = DBCommand.ExecuteReader

            ' Clear List
            lstPricesView.Items.Clear()
            ' Disable sorting because it will crawl after we update if there are too many records
            lstPricesView.ListViewItemSorter = Nothing
            lstPricesView.BeginUpdate()
            'Cursor.Current = Cursors.WaitCursor

            ' Fill list
            While readerMats.Read
                'ITEM_ID, ITEM_NAME, ITEM_GROUP, PRICE, MANUFACTURE
                lstViewRow = New ListViewItem(CStr(readerMats.GetValue(0))) ' ID
                'The remaining columns are subitems  
                lstViewRow.SubItems.Add(CStr(readerMats.GetString(2))) ' Group
                lstViewRow.SubItems.Add(CStr(readerMats.GetString(1))) ' Name
                lstViewRow.SubItems.Add(FormatNumber(readerMats.GetDouble(3), 2))
                lstViewRow.SubItems.Add(CStr(readerMats.GetValue(4)))
                If IsDBNull(readerMats.GetValue(5)) Then
                    lstViewRow.SubItems.Add("")
                Else
                    lstViewRow.SubItems.Add(CStr(readerMats.GetInt64(5)))
                End If
                ' Price Type - look it up
                lstViewRow.SubItems.Add(CStr(readerMats.GetString(6)))

                Call lstPricesView.Items.Add(lstViewRow)
            End While

            readerMats.Close()
            readerMats = Nothing
            DBCommand = Nothing

            ' Now sort this
            Dim TempType As SortOrder
            If UpdatePricesColumnSortType = SortOrder.Ascending Then
                TempType = SortOrder.Descending
            Else
                TempType = SortOrder.Ascending
            End If
            Call ListViewColumnSorter(UpdatePricesColumnClicked, CType(lstPricesView, ListView), UpdatePricesColumnClicked, TempType)

            Cursor.Current = Cursors.Default
            lstPricesView.EndUpdate()
        End If

        ' Reset
        txtListEdit.Visible = False
        Cursor.Current = Cursors.Default
        Application.DoEvents()
        pnlStatus.Text = ""

    End Sub

    ' Loads the solar systems into the combo for system prices
    Private Sub LoadPriceSolarSystems()
        Dim SQL As String
        Dim readerSS As SQLiteDataReader

        ' Load the select systems combobox with systems - no WH systems
        SQL = "SELECT solarSystemName FROM SOLAR_SYSTEMS, REGIONS AS R WHERE SOLAR_SYSTEMS.regionID = R.regionID "
        SQL = SQL & "AND R.regionName NOT LIKE '%-R%' "
        SQL = SQL & "OR solarSystemName = 'Thera' "
        SQL = SQL & "ORDER BY solarSystemName"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerSS = DBCommand.ExecuteReader
        readerSS.Close()
        readerSS = Nothing
        DBCommand = Nothing

    End Sub

    Private Sub LoadPriceShipTypes()
        Dim SQL As String
        Dim readerShipType As SQLiteDataReader

        ' Load the select systems combobox with systems
        SQL = "SELECT groupName from inventory_types, inventory_groups, inventory_categories "
        SQL = SQL & "WHERE  inventory_types.groupID = inventory_groups.groupID "
        SQL = SQL & "AND inventory_groups.categoryID = inventory_categories.categoryID "
        SQL = SQL & "AND categoryname = 'Ship' AND groupName NOT IN ('Rookie ship','Prototype Exploration Ship') "
        SQL = SQL & "AND inventory_types.published <> 0  "
        SQL = SQL & "GROUP BY groupName "

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerShipType = DBCommand.ExecuteReader

        readerShipType.Close()
        readerShipType = Nothing
        DBCommand = Nothing

    End Sub

    Private Sub LoadPriceChargeTypes()
        Dim SQL As String
        Dim readerChargeType As SQLiteDataReader

        ' Load the select systems combobox with systems
        SQL = "SELECT groupName from inventory_types, inventory_groups, inventory_categories "
        SQL = SQL & "WHERE  inventory_types.groupID = inventory_groups.groupID "
        SQL = SQL & "AND inventory_groups.categoryID = inventory_categories.categoryID "
        SQL = SQL & "AND categoryname = 'Charge' "
        SQL = SQL & "AND inventory_types.published <> 0 and inventory_groups.published <> 0 and inventory_categories.published <> 0 "
        SQL = SQL & "GROUP BY groupName "

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerChargeType = DBCommand.ExecuteReader

        readerChargeType.Close()
        readerChargeType = Nothing
        DBCommand = Nothing

    End Sub

    Private Sub btnSavePricestoFile_Click(sender As System.Object, e As System.EventArgs)
        Dim MyStream As StreamWriter
        Dim FileName As String
        Dim OutputText As String
        Dim Price As ListViewItem

        Dim Items As ListView.ListViewItemCollection
        Dim i As Integer = 0

        ' Show the dialog
        Dim ExportTypeString As String
        Dim Separator As String
        Dim FileHeader As String

        If UserApplicationSettings.DataExportFormat = CSVDataExport Then
            ' Save file name with date
            FileName = "Price List - " & Format(Now, "MMddyyyy") & ".csv"
            ExportTypeString = CSVDataExport
            Separator = ","
            FileHeader = PriceListHeaderCSV
            SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
        ElseIf UserApplicationSettings.DataExportFormat = SSVDataExport Then
            ' Save file name with date
            FileName = "Price List - " & Format(Now, "MMddyyyy") & ".ssv"
            ExportTypeString = SSVDataExport
            Separator = ";"
            FileHeader = PriceListHeaderSSV
            SaveFileDialog.Filter = "ssv files (*.ssv*)|*.ssv*|All files (*.*)|*.*"
        Else
            ' Save file name with date
            FileName = "Price List - " & Format(Now, "MMddyyyy") & ".txt"
            ExportTypeString = DefaultTextDataExport
            Separator = "|"
            FileHeader = PriceListHeaderTXT
            SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        End If

        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.RestoreDirectory = True
        SaveFileDialog.FileName = FileName

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                MyStream = File.CreateText(SaveFileDialog.FileName)

                If Not (MyStream Is Nothing) Then

                    ' Output the buy list first
                    Items = lstPricesView.Items

                    If Items.Count > 0 Then
                        Cursor.Current = Cursors.WaitCursor

                        Application.DoEvents()

                        OutputText = FileHeader
                        MyStream.Write(OutputText & Environment.NewLine)

                        For Each Price In Items
                            Application.DoEvents()
                            ' Build the output text -"Group,Item Name,Price,Price Type,Raw Material,Type ID"
                            OutputText = Price.SubItems(1).Text & Separator
                            OutputText = OutputText & Price.SubItems(2).Text & Separator
                            If ExportTypeString = SSVDataExport Then
                                ' Format to EU
                                OutputText = OutputText & ConvertUStoEUDecimal(Price.SubItems(3).Text) & Separator
                            Else
                                OutputText = OutputText & Format(Price.SubItems(3).Text, "Fixed") & Separator
                            End If
                            OutputText = OutputText & Price.SubItems(6).Text & Separator
                            ' Manufacturing flag - set if raw mat or not (raw mats are not manufactured)
                            If Price.SubItems(4).Text = "0" Then
                                OutputText = OutputText & "TRUE" & Separator
                            Else
                                OutputText = OutputText & "FALSE" & Separator
                            End If
                            OutputText = OutputText & Price.SubItems(0).Text

                            MyStream.Write(OutputText & Environment.NewLine)
                        Next

                    End If

                    MyStream.Flush()
                    MyStream.Close()

                    MsgBox("Price List Saved", vbInformation, Application.ProductName)

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

    Private Sub btnLoadPricesfromFile_Click(sender As System.Object, e As System.EventArgs)
        Dim SQL As String
        Dim BPStream As StreamReader = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim Line As String
        Dim Header As String = ""
        Dim ParsedLine As String()
        Dim Separator As String = ""
        Dim FileType As String

        If UserApplicationSettings.DataExportFormat = CSVDataExport Then
            FileType = CSVDataExport
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
            openFileDialog1.FileName = "*.csv"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True
        ElseIf UserApplicationSettings.DataExportFormat = SSVDataExport Then
            FileType = SSVDataExport
            openFileDialog1.Filter = "ssv files (*.ssv*)|*.ssv*|All files (*.*)|*.*"
            openFileDialog1.FileName = "*.ssv"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True
        Else
            FileType = DefaultTextDataExport
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FileName = "*.txt"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True
        End If

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                BPStream = New StreamReader(openFileDialog1.FileName)

                If (BPStream IsNot Nothing) Then
                    ' Read the file line by line here, start with headers
                    Header = BPStream.ReadLine
                    Line = BPStream.ReadLine ' First line of data

                    If Line Is Nothing Then
                        ' Leave loop
                        Exit Try
                    Else
                        ' disable the tab
                        Call DisableUpdatePricesTab(True)
                    End If

                    Call EVEDB.BeginSQLiteTransaction()
                    Application.UseWaitCursor = True

                    While Line IsNot Nothing
                        Application.DoEvents()
                        ' Format for IPH saved file is is: Group Name, Item Name, Price, Price Type, Raw Material, Type ID

                        ' Parse it
                        Select Case FileType
                            Case CSVDataExport
                                ParsedLine = Line.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                            Case SSVDataExport
                                ParsedLine = Line.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
                            Case Else ' Text
                                ' See if this is an IPH saved file or an EVE Client file
                                If Header = "price,volRemaining,typeID,range,orderID,volEntered,minVolume,bid,issueDate,duration,stationID,regionID,solarSystemID,jumps," Then
                                    ' This is the EVE Client format so just throw a message and exit
                                    ParsedLine = Nothing
                                    MsgBox("This file was exprted by the EVE Client. IPH does not load prices from the EVE Client export.", vbInformation, Application.ProductName)
                                    GoTo ExitPRocessing
                                Else
                                    ' IPH format
                                    ParsedLine = Line.Split(New Char() {"|"c}, StringSplitOptions.RemoveEmptyEntries)
                                End If
                        End Select

                        ' Loop through and update the price and price type, the rest is static
                        SQL = "UPDATE ITEM_PRICES_FACT SET "
                        If FileType = SSVDataExport Then
                            ' Need to swap periods and commas before inserting
                            ParsedLine(2) = ParsedLine(2).Replace(".", "") ' Just replace the periods as they are commas for numbers, which aren't needed
                            ParsedLine(2) = ParsedLine(2).Replace(",", ".") ' now update the commas for decimal
                        Else
                            ParsedLine(2) = ParsedLine(2).Replace(",", "") ' Make sure we format correctly, strip out any commas
                        End If
                        SQL = SQL & "PRICE = " & ParsedLine(2) & ","
                        SQL = SQL & "PRICE_TYPE = '" & ParsedLine(3) & "' "
                        SQL = SQL & "WHERE ITEM_ID = " & ParsedLine(5)

                        ' Update the record
                        Call EVEDB.ExecuteNonQuerySQL(SQL)

                        Line = BPStream.ReadLine ' Read next line

                    End While

                    Call EVEDB.CommitSQLiteTransaction()

                    Application.UseWaitCursor = False
                    MsgBox("Prices Loaded", vbInformation, Application.ProductName)

                End If
            Catch Ex As Exception
                Application.UseWaitCursor = False
                Call EVEDB.RollbackSQLiteTransaction()
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (BPStream IsNot Nothing) Then
                    BPStream.Close()
                End If
            End Try
        End If

ExitPRocessing:

        Application.UseWaitCursor = False
        ' Enable the tab
        Call DisableUpdatePricesTab(False)
        Call UpdatePriceList()
        Application.DoEvents()

    End Sub

#End Region

#Region "Manufacturing"

#Region "Manufacturing Object Functions"

    Private Sub lstManufacturing_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.C AndAlso e.Control = True Then ' Copy
            ' Find the bp record selected
            Dim FoundItem As New ManufacturingItem
            ' Copy the bps to the clipboard or item name if bp isn't set
            Dim OutputText As String = ""

            For i = 0 To lstManufacturing.SelectedItems.Count - 1
                ' Find the item clicked in the list of items then just send those values over
                ManufacturingRecordIDToFind = CLng(lstManufacturing.SelectedItems(i).SubItems(0).Text)
                FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItem)
                OutputText &= FoundItem.ItemName & vbCrLf
            Next

            Call CopyTextToClipboard(OutputText)

        ElseIf e.KeyCode = Keys.A AndAlso e.Control = True Then ' Select all
            For i = 0 To lstManufacturing.Items.Count - 1
                lstManufacturing.Items(i).Selected = True
                Application.DoEvents()
            Next
        End If

    End Sub

    Private Sub btnCalcShowAssets_Click(sender As System.Object, e As System.EventArgs)
        ' Make sure it's not disposed
        If IsNothing(frmDefaultAssets) Then
            ' Make new form
            frmDefaultAssets = New frmAssetsViewer(AssetWindow.ManufacturingTab)
        Else
            If frmDefaultAssets.IsDisposed Then
                ' Make new form
                frmDefaultAssets = New frmAssetsViewer(AssetWindow.ManufacturingTab)
            End If
        End If

        ' Now open the Asset List
        frmDefaultAssets.Show()
        frmDefaultAssets.Focus()

        Application.DoEvents()
    End Sub

    Private Sub cmbCalcFWManufUpgradeLevel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcFWCopyUpgradeLevel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcFWInventionUpgradeLevel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcFWUpgrade_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub txtCalcProdLines_DoubleClick(sender As Object, e As System.EventArgs) Handles txtCalcProdLines.DoubleClick
        ' Enter the max lines we have
        txtCalcProdLines.Text = CStr(SelectedCharacter.MaximumProductionLines)
    End Sub

    Private Sub txtCalcProdLines_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalcProdLines.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtCalcProdLines_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCalcProdLines.TextChanged
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcBPs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalcNumBPs.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtCalcBPs_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCalcNumBPs.TextChanged
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcRuns_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCalcRuns.TextChanged
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcLabLines_DoubleClick(sender As Object, e As System.EventArgs) Handles txtCalcLabLines.DoubleClick
        ' Enter the max lab lines we have
        txtCalcLabLines.Text = CStr(SelectedCharacter.MaximumLaboratoryLines)
    End Sub

    Private Sub txtCalcLabLines_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalcLabLines.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtCalcLabLines_TextChanged(sender As Object, e As System.EventArgs) Handles txtCalcLabLines.TextChanged
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreLowSVR_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcAvgPriceDuration_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub cmbCalcAvgPriceDuration_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreMinerals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreT1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcTaxes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcFees_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcSellExessItems_CheckedChanged(sender As Object, e As EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcUsage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreRAMS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreInvention_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcEstimateCopyCost_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreInvention_CheckedChanged_1(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreMinerals_CheckedChanged_1(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIgnoreT1Item_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub rbtnCalcCompareAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcSVRThreshold_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers, decimal, negative or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtCalcSVRThreshold_TextChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcSVRIncludeNull_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub rbtnCalcCompareBuildBuy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub rbtnCalcCompareRawMats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub rbtnCalcCompareComponents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcPPU_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcShipBPCNoD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcShipBPCD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcNonShipBPCNoD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcNonShipBPCD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcCanBuild_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcCanInvent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub txtTempME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers, negative or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedMETEChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtTempPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedMETEChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtCalcItemFilter_TextChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcUseMaxBPCRunsNoRunsDecryptor_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub btnCalcReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FirstManufacturingGridLoad = True ' Reset
        Call InitManufacturingTab()
        ' Load the calc types because it won't get loaded if firstmanufacturinggridload = true
        Call LoadCalcBPTypes()
    End Sub

    Private Sub cmbCalcBPTypeFilter_DropDown(ByVal sender As Object, ByVal e As System.EventArgs)
        If FirstLoadCalcBPTypes Then
            Call LoadCalcBPTypes()
            FirstLoadCalcBPTypes = False
        End If
    End Sub

    Private Sub cmbCalcBPTypeFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only let them select a bp by clicking
        Dim i As Integer
        i = 0
    End Sub

    Private Sub cmbCalcBPTypeFilter_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcOnlyOwnedBPOInvent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcT1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True

            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcStoryline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcNavyFaction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcPirateFaction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcNPCBPOs_CheckedChanged(sender As Object, e As EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcShips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcModules_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcDrones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcAmmo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcRigs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcComponents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcStationParts_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcSubsystems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcStructures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcBoosters_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcMisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcCelestials_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcReactions_CheckedChanged(sender As Object, e As EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcStructureModules_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcDeployables_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub rbtnCalcBPOwned_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub rbtnCalcAllBPs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCalcAllBPs.CheckedChanged

        If rbtnCalcAllBPs.Checked = True Then
            autoShopping.Checked = False
        End If

        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub rbtnCalcBPFavorites_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub txtCalcItemFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Call ProcessCutCopyPasteSelect(txtCalcItemFilter, e)
        If e.KeyCode = Keys.Enter Then
            Call ResetRefresh()
            Call DisplayManufacturingResults(False)
        End If
    End Sub

    Private Sub btnCalcResetTextSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub txtCalcBPCCosts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedPriceChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub chkCalcDecryptor0_Click(sender As System.Object, e As System.EventArgs)

        If Not FirstLoad Then
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcIncludeT2Owned_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcIncludeT3Owned_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcRaceAmarr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcRaceCaldari_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcRaceGallente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcRaceMinmatar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcRacePirate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcRaceOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcSVRRegion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub cmbCalcBuildTimeMod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcSmall_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcMedium_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcLarge_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub chkCalcXL_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If Not FirstManufacturingGridLoad Then
            FirstLoadCalcBPTypes = True
            Call ResetRefresh()
        End If
    End Sub

    Private Sub btnCalcSelectColumns_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcSelectColumns.Click
        Dim f1 As New frmSelectManufacturingTabColumns
        ManufacturingTabColumnsChanged = False
        f1.ShowDialog()

        ' Now Refresh the grid if it changed
        If ManufacturingTabColumnsChanged Then
            If lstManufacturing.Items.Count <> 0 Then
                RefreshCalcData = True
                Call DisplayManufacturingResults(False)
            Else
                Call RefreshManufacturingTabColumns()
            End If
        End If
    End Sub

    Private Sub chkCalcAutoCalcT2NumBPs_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub lstManufacturing_ColumnClick(sender As System.Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstManufacturing.ColumnClick

        Call ListViewColumnSorter(e.Column, CType(lstManufacturing, ListView), ManufacturingColumnClicked, ManufacturingColumnSortType)

    End Sub

    Private Sub txtCalcIPHThreshold_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers, decimal, negative or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub txtCalcVolumeThreshold_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow postive numbers
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                Call ResetRefresh()
            End If
        End If
    End Sub

    Private Sub cmbCalcPriceTrend_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcIPHThreshold_TextChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcProfitThreshold_TextChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub txtCalcVolumeThreshold_TextChanged(sender As System.Object, e As System.EventArgs)
        Call ResetRefresh()
    End Sub

    Private Sub chkCalcMinBuildTimeFilter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCalcMinBuildTimeFilter.CheckedChanged
        Call ResetRefresh()
        If chkCalcMinBuildTimeFilter.Checked Then
            tpMinBuildTimeFilter.Enabled = True
        Else
            tpMinBuildTimeFilter.Enabled = False
        End If
    End Sub

    Private Sub chkCalcMaxBuildTimeFilter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCalcMaxBuildTimeFilter.CheckedChanged
        Call ResetRefresh()
        If chkCalcMaxBuildTimeFilter.Checked Then
            tpMaxBuildTimeFilter.Enabled = True
        Else
            tpMaxBuildTimeFilter.Enabled = False
        End If
    End Sub

    Private Sub tpMinBuildTimeFilter_TimeChange(sender As Object, e As System.EventArgs) Handles tpMinBuildTimeFilter.TimeChange
        Call ResetRefresh()
    End Sub

    Private Sub tpMaxBuildTimeFilter_TimeChange(sender As Object, e As System.EventArgs) Handles tpMaxBuildTimeFilter.TimeChange
        Call ResetRefresh()
    End Sub

#End Region

#Region "Column Select Functions"

    ' Clears the list and rebuilds it with columns they selected
    Private Sub RefreshManufacturingTabColumns()

        Call LoadManufacturingTabColumnPositions()
        Call lstManufacturing.Clear()
        AddingColumns = True

        ' Add the first hidden column
        lstManufacturing.Columns.Add("ListID")
        lstManufacturing.Columns(0).Width = 0

        ' Now load all the columns in order of the settings
        For i = 1 To ColumnPositions.Count - 1
            If ColumnPositions(i) <> "" Then
                lstManufacturing.Columns.Add(ColumnPositions(i), GetColumnWidth(ColumnPositions(i)), GetColumnAlignment(ColumnPositions(i)))
            End If
        Next

        ' Hack to get around the scroll bar not showing
        lstManufacturing.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.None)

        AddingColumns = False

    End Sub

    ' Takes the column settings and saves the order to an array
    Private Sub LoadManufacturingTabColumnPositions()

        For i = 0 To ColumnPositions.Count - 1
            ColumnPositions(i) = ""
        Next

        With UserManufacturingTabColumnSettings
            ColumnPositions(.ItemCategory) = ProgramSettings.ItemCategoryColumnName
            ColumnPositions(.ItemGroup) = ProgramSettings.ItemGroupColumnName
            ColumnPositions(.ItemName) = ProgramSettings.ItemNameColumnName
            ColumnPositions(.Owned) = ProgramSettings.OwnedColumnName
            ColumnPositions(.Tech) = ProgramSettings.TechColumnName
            ColumnPositions(.BPME) = ProgramSettings.BPMEColumnName
            ColumnPositions(.BPTE) = ProgramSettings.BPTEColumnName
            ColumnPositions(.Inputs) = ProgramSettings.InputsColumnName
            ColumnPositions(.Compared) = ProgramSettings.ComparedColumnName
            ColumnPositions(.TotalRuns) = ProgramSettings.TotalRunsColumnName
            ColumnPositions(.SingleInventedBPCRuns) = ProgramSettings.SingleInventedBPCRunsColumnName
            ColumnPositions(.ProductionLines) = ProgramSettings.ProductionLinesColumnName
            ColumnPositions(.LaboratoryLines) = ProgramSettings.LaboratoryLinesColumnName
            ColumnPositions(.TotalInventionCost) = ProgramSettings.TotalInventionCostColumnName
            ColumnPositions(.TotalCopyCost) = ProgramSettings.TotalCopyCostColumnName
            ColumnPositions(.Taxes) = ProgramSettings.TaxesColumnName
            ColumnPositions(.BrokerFees) = ProgramSettings.BrokerFeesColumnName
            ColumnPositions(.BPProductionTime) = ProgramSettings.BPProductionTimeColumnName
            ColumnPositions(.TotalProductionTime) = ProgramSettings.TotalProductionTimeColumnName
            ColumnPositions(.CopyTime) = ProgramSettings.CopyTimeColumnName
            ColumnPositions(.InventionTime) = ProgramSettings.InventionTimeColumnName
            ColumnPositions(.ItemMarketPrice) = ProgramSettings.ItemMarketPriceColumnName
            ColumnPositions(.Profit) = ProgramSettings.ProfitColumnName
            ColumnPositions(.ProfitPercentage) = ProgramSettings.ProfitPercentageColumnName
            ColumnPositions(.IskperHour) = ProgramSettings.IskperHourColumnName
            ColumnPositions(.SVR) = ProgramSettings.SVRColumnName
            ColumnPositions(.SVRxIPH) = ProgramSettings.SVRxIPHColumnName
            ColumnPositions(.PriceTrend) = ProgramSettings.PriceTrendColumnName
            ColumnPositions(.Score) = ProgramSettings.ScoreColumnName
            ColumnPositions(.RiskProfit) = ProgramSettings.RiskProfitColumnName
            ColumnPositions(.RiskIPH) = ProgramSettings.RiskIPHColumnName
            ColumnPositions(.RiskPrice) = ProgramSettings.RiskPriceColumnName
            ColumnPositions(.Volatility) = ProgramSettings.VolatilityColumnName
            ColumnPositions(.TotalItemsSold) = ProgramSettings.TotalItemsSoldColumnName
            ColumnPositions(.TotalOrdersFilled) = ProgramSettings.TotalOrdersFilledColumnName
            ColumnPositions(.AvgItemsperOrder) = ProgramSettings.AvgItemsperOrderColumnName
            ColumnPositions(.CurrentSellOrders) = ProgramSettings.CurrentSellOrdersColumnName
            ColumnPositions(.CurrentBuyOrders) = ProgramSettings.CurrentBuyOrdersColumnName
            ColumnPositions(.ItemsinStock) = ProgramSettings.ItemsinStockColumnName
            ColumnPositions(.ItemsinProduction) = ProgramSettings.ItemsinProductionColumnName
            ColumnPositions(.TotalCost) = ProgramSettings.TotalCostColumnName
            ColumnPositions(.BaseJobCost) = ProgramSettings.BaseJobCostColumnName
            ColumnPositions(.NumBPs) = ProgramSettings.NumBPsColumnName
            ColumnPositions(.InventionChance) = ProgramSettings.InventionChanceColumnName
            ColumnPositions(.BPType) = ProgramSettings.BPTypeColumnName
            ColumnPositions(.Race) = ProgramSettings.RaceColumnName
            ColumnPositions(.VolumeperItem) = ProgramSettings.VolumeperItemColumnName
            ColumnPositions(.TotalVolume) = ProgramSettings.TotalVolumeColumnName
            ColumnPositions(.PortionSize) = ProgramSettings.PortionSizeColumnName
            ColumnPositions(.ManufacturingJobFee) = ProgramSettings.ManufacturingJobFeeColumnName
            ColumnPositions(.ManufacturingFacilityName) = ProgramSettings.ManufacturingFacilityNameColumnName
            ColumnPositions(.ManufacturingFacilitySystem) = ProgramSettings.ManufacturingFacilitySystemColumnName
            ColumnPositions(.ManufacturingFacilityRegion) = ProgramSettings.ManufacturingFacilityRegionColumnName
            ColumnPositions(.ManufacturingFacilitySystemIndex) = ProgramSettings.ManufacturingFacilitySystemIndexColumnName
            ColumnPositions(.ManufacturingFacilityTax) = ProgramSettings.ManufacturingFacilityTaxColumnName
            ColumnPositions(.ManufacturingFacilityMEBonus) = ProgramSettings.ManufacturingFacilityMEBonusColumnName
            ColumnPositions(.ManufacturingFacilityTEBonus) = ProgramSettings.ManufacturingFacilityTEBonusColumnName
            ColumnPositions(.ManufacturingFacilityUsage) = ProgramSettings.ManufacturingFacilityUsageColumnName
            ColumnPositions(.ManufacturingFacilityFWSystemLevel) = ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName
            ColumnPositions(.ComponentFacilityName) = ProgramSettings.ComponentFacilityNameColumnName
            ColumnPositions(.ComponentFacilitySystem) = ProgramSettings.ComponentFacilitySystemColumnName
            ColumnPositions(.ComponentFacilityRegion) = ProgramSettings.ComponentFacilityRegionColumnName
            ColumnPositions(.ComponentFacilitySystemIndex) = ProgramSettings.ComponentFacilitySystemIndexColumnName
            ColumnPositions(.ComponentFacilityTax) = ProgramSettings.ComponentFacilityTaxColumnName
            ColumnPositions(.ComponentFacilityMEBonus) = ProgramSettings.ComponentFacilityMEBonusColumnName
            ColumnPositions(.ComponentFacilityTEBonus) = ProgramSettings.ComponentFacilityTEBonusColumnName
            ColumnPositions(.ComponentFacilityUsage) = ProgramSettings.ComponentFacilityUsageColumnName
            ColumnPositions(.ComponentFacilityFWSystemLevel) = ProgramSettings.ComponentFacilityFWSystemLevelColumnName
            ColumnPositions(.CapComponentFacilityName) = ProgramSettings.CapComponentFacilityNameColumnName
            ColumnPositions(.CapComponentFacilitySystem) = ProgramSettings.CapComponentFacilitySystemColumnName
            ColumnPositions(.CapComponentFacilityRegion) = ProgramSettings.CapComponentFacilityRegionColumnName
            ColumnPositions(.CapComponentFacilitySystemIndex) = ProgramSettings.CapComponentFacilitySystemIndexColumnName
            ColumnPositions(.CapComponentFacilityTax) = ProgramSettings.CapComponentFacilityTaxColumnName
            ColumnPositions(.CapComponentFacilityMEBonus) = ProgramSettings.CapComponentFacilityMEBonusColumnName
            ColumnPositions(.CapComponentFacilityTEBonus) = ProgramSettings.CapComponentFacilityTEBonusColumnName
            ColumnPositions(.CapComponentFacilityUsage) = ProgramSettings.CapComponentFacilityUsageColumnName
            ColumnPositions(.CapComponentFacilityFWSystemLevel) = ProgramSettings.CapComponentFacilityFWSystemLevelColumnName
            ColumnPositions(.CopyingFacilityName) = ProgramSettings.CopyingFacilityNameColumnName
            ColumnPositions(.CopyingFacilitySystem) = ProgramSettings.CopyingFacilitySystemColumnName
            ColumnPositions(.CopyingFacilityRegion) = ProgramSettings.CopyingFacilityRegionColumnName
            ColumnPositions(.CopyingFacilitySystemIndex) = ProgramSettings.CopyingFacilitySystemIndexColumnName
            ColumnPositions(.CopyingFacilityTax) = ProgramSettings.CopyingFacilityTaxColumnName
            ColumnPositions(.CopyingFacilityMEBonus) = ProgramSettings.CopyingFacilityMEBonusColumnName
            ColumnPositions(.CopyingFacilityTEBonus) = ProgramSettings.CopyingFacilityTEBonusColumnName
            ColumnPositions(.CopyingFacilityUsage) = ProgramSettings.CopyingFacilityUsageColumnName
            ColumnPositions(.CopyingFacilityFWSystemLevel) = ProgramSettings.CopyingFacilityFWSystemLevelColumnName
            ColumnPositions(.InventionFacilityName) = ProgramSettings.InventionFacilityNameColumnName
            ColumnPositions(.InventionFacilitySystem) = ProgramSettings.InventionFacilitySystemColumnName
            ColumnPositions(.InventionFacilityRegion) = ProgramSettings.InventionFacilityRegionColumnName
            ColumnPositions(.InventionFacilitySystemIndex) = ProgramSettings.InventionFacilitySystemIndexColumnName
            ColumnPositions(.InventionFacilityTax) = ProgramSettings.InventionFacilityTaxColumnName
            ColumnPositions(.InventionFacilityMEBonus) = ProgramSettings.InventionFacilityMEBonusColumnName
            ColumnPositions(.InventionFacilityTEBonus) = ProgramSettings.InventionFacilityTEBonusColumnName
            ColumnPositions(.InventionFacilityUsage) = ProgramSettings.InventionFacilityUsageColumnName
            ColumnPositions(.InventionFacilityFWSystemLevel) = ProgramSettings.InventionFacilityFWSystemLevelColumnName
            ColumnPositions(.ReactionFacilityName) = ProgramSettings.ReactionFacilityNameColumnName
            ColumnPositions(.ReactionFacilitySystem) = ProgramSettings.ReactionFacilitySystemColumnName
            ColumnPositions(.ReactionFacilityRegion) = ProgramSettings.ReactionFacilityRegionColumnName
            ColumnPositions(.ReactionFacilitySystemIndex) = ProgramSettings.ReactionFacilitySystemIndexColumnName
            ColumnPositions(.ReactionFacilityTax) = ProgramSettings.ReactionFacilityTaxColumnName
            ColumnPositions(.ReactionFacilityMEBonus) = ProgramSettings.ReactionFacilityMEBonusColumnName
            ColumnPositions(.ReactionFacilityTEBonus) = ProgramSettings.ReactionFacilityTEBonusColumnName
            ColumnPositions(.ReactionFacilityUsage) = ProgramSettings.ReactionFacilityUsageColumnName
            ColumnPositions(.ReactionFacilityFWSystemLevel) = ProgramSettings.ReactionFacilityFWSystemLevelColumnName
        End With

        ' First column is always the ListID
        ColumnPositions(0) = "ListID"

    End Sub

    ' Returns the column Width for the sent column name
    Private Function GetColumnWidth(ColumnName As String) As Integer

        With UserManufacturingTabColumnSettings
            Select Case ColumnName
                Case ProgramSettings.ItemCategoryColumnName
                    Return .ItemCategoryWidth
                Case ProgramSettings.ItemGroupColumnName
                    Return .ItemGroupWidth
                Case ProgramSettings.ItemNameColumnName
                    Return .ItemNameWidth
                Case ProgramSettings.OwnedColumnName
                    Return .OwnedWidth
                Case ProgramSettings.TechColumnName
                    Return .TechWidth
                Case ProgramSettings.BPMEColumnName
                    Return .BPMEWidth
                Case ProgramSettings.BPTEColumnName
                    Return .BPTEWidth
                Case ProgramSettings.InputsColumnName
                    Return .InputsWidth
                Case ProgramSettings.ComparedColumnName
                    Return .ComparedWidth
                Case ProgramSettings.TotalRunsColumnName
                    Return .TotalRunsWidth
                Case ProgramSettings.SingleInventedBPCRunsColumnName
                    Return .SingleInventedBPCRunsWidth
                Case ProgramSettings.ProductionLinesColumnName
                    Return .ProductionLinesWidth
                Case ProgramSettings.LaboratoryLinesColumnName
                    Return .LaboratoryLinesWidth
                Case ProgramSettings.TotalInventionCostColumnName
                    Return .TotalInventionCostWidth
                Case ProgramSettings.TotalCopyCostColumnName
                    Return .TotalCopyCostWidth
                Case ProgramSettings.TaxesColumnName
                    Return .TaxesWidth
                Case ProgramSettings.BrokerFeesColumnName
                    Return .BrokerFeesWidth
                Case ProgramSettings.BPProductionTimeColumnName
                    Return .BPProductionTimeWidth
                Case ProgramSettings.TotalProductionTimeColumnName
                    Return .TotalProductionTimeWidth
                Case ProgramSettings.CopyTimeColumnName
                    Return .CopyTimeWidth
                Case ProgramSettings.InventionTimeColumnName
                    Return .InventionTimeWidth
                Case ProgramSettings.ItemMarketPriceColumnName
                    Return .ItemMarketPriceWidth
                Case ProgramSettings.ProfitColumnName
                    Return .ProfitWidth
                Case ProgramSettings.ProfitPercentageColumnName
                    Return .ProfitPercentageWidth
                Case ProgramSettings.IskperHourColumnName
                    Return .IskperHourWidth
                Case ProgramSettings.SVRColumnName
                    Return .SVRWidth
                Case ProgramSettings.SVRxIPHColumnName
                    Return .SVRxIPHWidth
                Case ProgramSettings.ScoreColumnName
                    Return .ScoreWidth
                Case ProgramSettings.RiskProfitColumnName
                    Return .RiskProfitWidth
                Case ProgramSettings.RiskIPHColumnName
                    Return .RiskIPHWidth
                Case ProgramSettings.RiskPriceColumnName
                    Return .RiskPriceWidth
                Case ProgramSettings.VolatilityColumnName
                    Return .VolatilityWidth
                Case ProgramSettings.PriceTrendColumnName
                    Return .PriceTrendWidth
                Case ProgramSettings.TotalItemsSoldColumnName
                    Return .TotalItemsSoldWidth
                Case ProgramSettings.TotalOrdersFilledColumnName
                    Return .TotalOrdersFilledWidth
                Case ProgramSettings.ItemsinProductionColumnName
                    Return .ItemsinProductionWidth
                Case ProgramSettings.ItemsinStockColumnName
                    Return .ItemsinStockWidth
                Case ProgramSettings.AvgItemsperOrderColumnName
                    Return .AvgItemsperOrderWidth
                Case ProgramSettings.CurrentSellOrdersColumnName
                    Return .CurrentSellOrdersWidth
                Case ProgramSettings.CurrentBuyOrdersColumnName
                    Return .CurrentBuyOrdersWidth
                Case ProgramSettings.TotalCostColumnName
                    Return .TotalCostWidth
                Case ProgramSettings.BaseJobCostColumnName
                    Return .BaseJobCostWidth
                Case ProgramSettings.NumBPsColumnName
                    Return .NumBPsWidth
                Case ProgramSettings.InventionChanceColumnName
                    Return .InventionChanceWidth
                Case ProgramSettings.BPTypeColumnName
                    Return .BPTypeWidth
                Case ProgramSettings.RaceColumnName
                    Return .RaceWidth
                Case ProgramSettings.VolumeperItemColumnName
                    Return .VolumeperItemWidth
                Case ProgramSettings.TotalVolumeColumnName
                    Return .TotalVolumeWidth
                Case ProgramSettings.PortionSizeColumnName
                    Return .PortionSizeWidth
                Case ProgramSettings.ManufacturingJobFeeColumnName
                    Return .ManufacturingJobFeeWidth
                Case ProgramSettings.ManufacturingFacilityNameColumnName
                    Return .ManufacturingFacilityNameWidth
                Case ProgramSettings.ManufacturingFacilitySystemColumnName
                    Return .ManufacturingFacilitySystemWidth
                Case ProgramSettings.ManufacturingFacilityRegionColumnName
                    Return .ManufacturingFacilityRegionWidth
                Case ProgramSettings.ManufacturingFacilitySystemIndexColumnName
                    Return .ManufacturingFacilitySystemIndexWidth
                Case ProgramSettings.ManufacturingFacilityTaxColumnName
                    Return .ManufacturingFacilityTaxWidth
                Case ProgramSettings.ManufacturingFacilityMEBonusColumnName
                    Return .ManufacturingFacilityMEBonusWidth
                Case ProgramSettings.ManufacturingFacilityTEBonusColumnName
                    Return .ManufacturingFacilityTEBonusWidth
                Case ProgramSettings.ManufacturingFacilityUsageColumnName
                    Return .ManufacturingFacilityUsageWidth
                Case ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName
                    Return .ManufacturingFacilityFWSystemLevelWidth
                Case ProgramSettings.ComponentFacilityNameColumnName
                    Return .ComponentFacilityNameWidth
                Case ProgramSettings.ComponentFacilitySystemColumnName
                    Return .ComponentFacilitySystemWidth
                Case ProgramSettings.ComponentFacilityRegionColumnName
                    Return .ComponentFacilityRegionWidth
                Case ProgramSettings.ComponentFacilitySystemIndexColumnName
                    Return .ComponentFacilitySystemIndexWidth
                Case ProgramSettings.ComponentFacilityTaxColumnName
                    Return .ComponentFacilityTaxWidth
                Case ProgramSettings.ComponentFacilityMEBonusColumnName
                    Return .ComponentFacilityMEBonusWidth
                Case ProgramSettings.ComponentFacilityTEBonusColumnName
                    Return .ComponentFacilityTEBonusWidth
                Case ProgramSettings.ComponentFacilityUsageColumnName
                    Return .ComponentFacilityUsageWidth
                Case ProgramSettings.ComponentFacilityFWSystemLevelColumnName
                    Return .ComponentFacilityFWSystemLevelWidth
                Case ProgramSettings.CapComponentFacilityNameColumnName
                    Return .CapComponentFacilityNameWidth
                Case ProgramSettings.CapComponentFacilitySystemColumnName
                    Return .CapComponentFacilitySystemWidth
                Case ProgramSettings.CapComponentFacilityRegionColumnName
                    Return .CapComponentFacilityRegionWidth
                Case ProgramSettings.CapComponentFacilitySystemIndexColumnName
                    Return .CapComponentFacilitySystemIndexWidth
                Case ProgramSettings.CapComponentFacilityTaxColumnName
                    Return .CapComponentFacilityTaxWidth
                Case ProgramSettings.CapComponentFacilityMEBonusColumnName
                    Return .CapComponentFacilityMEBonusWidth
                Case ProgramSettings.CapComponentFacilityTEBonusColumnName
                    Return .CapComponentFacilityTEBonusWidth
                Case ProgramSettings.CapComponentFacilityUsageColumnName
                    Return .CapComponentFacilityUsageWidth
                Case ProgramSettings.CapComponentFacilityFWSystemLevelColumnName
                    Return .CapComponentFacilityFWSystemLevelWidth
                Case ProgramSettings.CopyingFacilityNameColumnName
                    Return .CopyingFacilityNameWidth
                Case ProgramSettings.CopyingFacilitySystemColumnName
                    Return .CopyingFacilitySystemWidth
                Case ProgramSettings.CopyingFacilityRegionColumnName
                    Return .CopyingFacilityRegionWidth
                Case ProgramSettings.CopyingFacilitySystemIndexColumnName
                    Return .CopyingFacilitySystemIndexWidth
                Case ProgramSettings.CopyingFacilityTaxColumnName
                    Return .CopyingFacilityTaxWidth
                Case ProgramSettings.CopyingFacilityMEBonusColumnName
                    Return .CopyingFacilityMEBonusWidth
                Case ProgramSettings.CopyingFacilityTEBonusColumnName
                    Return .CopyingFacilityTEBonusWidth
                Case ProgramSettings.CopyingFacilityUsageColumnName
                    Return .CopyingFacilityUsageWidth
                Case ProgramSettings.CopyingFacilityFWSystemLevelColumnName
                    Return .CopyingFacilityFWSystemLevelWidth
                Case ProgramSettings.InventionFacilityNameColumnName
                    Return .InventionFacilityNameWidth
                Case ProgramSettings.InventionFacilitySystemColumnName
                    Return .InventionFacilitySystemWidth
                Case ProgramSettings.InventionFacilityRegionColumnName
                    Return .InventionFacilityRegionWidth
                Case ProgramSettings.InventionFacilitySystemIndexColumnName
                    Return .InventionFacilitySystemIndexWidth
                Case ProgramSettings.InventionFacilityTaxColumnName
                    Return .InventionFacilityTaxWidth
                Case ProgramSettings.InventionFacilityMEBonusColumnName
                    Return .InventionFacilityMEBonusWidth
                Case ProgramSettings.InventionFacilityTEBonusColumnName
                    Return .InventionFacilityTEBonusWidth
                Case ProgramSettings.InventionFacilityUsageColumnName
                    Return .InventionFacilityUsageWidth
                Case ProgramSettings.InventionFacilityFWSystemLevelColumnName
                    Return .InventionFacilityFWSystemLevelWidth
                Case ProgramSettings.ReactionFacilityNameColumnName
                    Return .ReactionFacilityNameWidth
                Case ProgramSettings.ReactionFacilitySystemColumnName
                    Return .ReactionFacilitySystemWidth
                Case ProgramSettings.ReactionFacilityRegionColumnName
                    Return .ReactionFacilityRegionWidth
                Case ProgramSettings.ReactionFacilitySystemIndexColumnName
                    Return .ReactionFacilitySystemIndexWidth
                Case ProgramSettings.ReactionFacilityTaxColumnName
                    Return .ReactionFacilityTaxWidth
                Case ProgramSettings.ReactionFacilityMEBonusColumnName
                    Return .ReactionFacilityMEBonusWidth
                Case ProgramSettings.ReactionFacilityTEBonusColumnName
                    Return .ReactionFacilityTEBonusWidth
                Case ProgramSettings.ReactionFacilityUsageColumnName
                    Return .ReactionFacilityUsageWidth
                Case ProgramSettings.ReactionFacilityFWSystemLevelColumnName
                    Return .ReactionFacilityFWSystemLevelWidth
                Case Else
                    Return 0
            End Select
        End With

    End Function

    ' Updates the column order when changed
    Private Sub lstManufacturing_ColumnReordered(sender As Object, e As System.Windows.Forms.ColumnReorderedEventArgs)
        Dim TempArray(NumManufacturingTabColumns) As String
        Dim Minus1 As Boolean = False

        e.Cancel = True ' Cancel the event so we can manually update the grid columns

        For i = 0 To NumManufacturingTabColumns
            TempArray(i) = ""
        Next

        ' First index is the ListID
        TempArray(0) = "ListID"

        If e.OldDisplayIndex > e.NewDisplayIndex Then
            ' For all indices larger than the new index, need to move it to the next array
            For i = 1 To e.NewDisplayIndex - 1
                TempArray(i) = ColumnPositions(i)
            Next

            ' Insert the new column
            TempArray(e.NewDisplayIndex) = ColumnPositions(e.OldDisplayIndex)

            ' Move all the rest of the items up one
            For i = e.NewDisplayIndex + 1 To TempArray.Count - 1
                If i < e.OldDisplayIndex + 1 Then
                    TempArray(i) = ColumnPositions(i - 1)
                Else
                    TempArray(i) = ColumnPositions(i)
                End If
            Next
        Else
            ' For all indices larger than the new index, need to move it to the next array
            For i = 1 To e.OldDisplayIndex - 1
                TempArray(i) = ColumnPositions(i)
            Next

            ' Insert the new column
            TempArray(e.NewDisplayIndex) = ColumnPositions(e.OldDisplayIndex)

            ' Back fill the array between the column we moved and the new location
            For i = e.OldDisplayIndex To e.NewDisplayIndex - 1
                TempArray(i) = ColumnPositions(i + 1)
            Next

            ' Replace all the items left
            For i = e.NewDisplayIndex + 1 To TempArray.Count - 1
                TempArray(i) = ColumnPositions(i)
            Next

        End If

        ColumnPositions = TempArray

        ' Save the columns based on the current order
        With UserManufacturingTabColumnSettings
            For i = 1 To ColumnPositions.Count - 1
                Select Case ColumnPositions(i)
                    Case ProgramSettings.ItemCategoryColumnName
                        .ItemCategory = i
                    Case ProgramSettings.ItemGroupColumnName
                        .ItemGroup = i
                    Case ProgramSettings.ItemNameColumnName
                        .ItemName = i
                    Case ProgramSettings.OwnedColumnName
                        .Owned = i
                    Case ProgramSettings.TechColumnName
                        .Tech = i
                    Case ProgramSettings.BPMEColumnName
                        .BPME = i
                    Case ProgramSettings.BPTEColumnName
                        .BPTE = i
                    Case ProgramSettings.InputsColumnName
                        .Inputs = i
                    Case ProgramSettings.ComparedColumnName
                        .Compared = i
                    Case ProgramSettings.TotalRunsColumnName
                        .TotalRuns = i
                    Case ProgramSettings.SingleInventedBPCRunsColumnName
                        .SingleInventedBPCRuns = i
                    Case ProgramSettings.ProductionLinesColumnName
                        .ProductionLines = i
                    Case ProgramSettings.LaboratoryLinesColumnName
                        .LaboratoryLines = i
                    Case ProgramSettings.TotalInventionCostColumnName
                        .TotalInventionCost = i
                    Case ProgramSettings.TotalCopyCostColumnName
                        .TotalCopyCost = i
                    Case ProgramSettings.TaxesColumnName
                        .Taxes = i
                    Case ProgramSettings.BrokerFeesColumnName
                        .BrokerFees = i
                    Case ProgramSettings.BPProductionTimeColumnName
                        .BPProductionTime = i
                    Case ProgramSettings.TotalProductionTimeColumnName
                        .TotalProductionTime = i
                    Case ProgramSettings.CopyTimeColumnName
                        .CopyTime = i
                    Case ProgramSettings.InventionTimeColumnName
                        .InventionTime = i
                    Case ProgramSettings.ItemMarketPriceColumnName
                        .ItemMarketPrice = i
                    Case ProgramSettings.ProfitColumnName
                        .Profit = i
                    Case ProgramSettings.ProfitPercentageColumnName
                        .ProfitPercentage = i
                    Case ProgramSettings.IskperHourColumnName
                        .IskperHour = i
                    Case ProgramSettings.SVRColumnName
                        .SVR = i
                    Case ProgramSettings.SVRxIPHColumnName
                        .SVRxIPH = i
                    Case ProgramSettings.ScoreColumnName
                        .Score = i
                    Case ProgramSettings.RiskProfitColumnName
                        .RiskProfit = i
                    Case ProgramSettings.RiskIPHColumnName
                        .RiskIPH = i
                    Case ProgramSettings.RiskPriceColumnName
                        .RiskPrice = i
                    Case ProgramSettings.VolatilityColumnName
                        .Volatility = i
                    Case ProgramSettings.PriceTrendColumnName
                        .PriceTrend = i
                    Case ProgramSettings.TotalItemsSoldColumnName
                        .TotalItemsSold = i
                    Case ProgramSettings.TotalOrdersFilledColumnName
                        .TotalOrdersFilled = i
                    Case ProgramSettings.AvgItemsperOrderColumnName
                        .AvgItemsperOrder = i
                    Case ProgramSettings.CurrentSellOrdersColumnName
                        .CurrentSellOrders = i
                    Case ProgramSettings.CurrentBuyOrdersColumnName
                        .CurrentBuyOrders = i
                    Case ProgramSettings.TotalCostColumnName
                        .TotalCost = i
                    Case ProgramSettings.BaseJobCostColumnName
                        .BaseJobCost = i
                    Case ProgramSettings.NumBPsColumnName
                        .NumBPs = i
                    Case ProgramSettings.InventionChanceColumnName
                        .InventionChance = i
                    Case ProgramSettings.BPTypeColumnName
                        .BPType = i
                    Case ProgramSettings.RaceColumnName
                        .Race = i
                    Case ProgramSettings.VolumeperItemColumnName
                        .VolumeperItem = i
                    Case ProgramSettings.TotalVolumeColumnName
                        .TotalVolume = i
                    Case ProgramSettings.PortionSizeColumnName
                        .PortionSize = i
                    Case ProgramSettings.ManufacturingJobFeeColumnName
                        .ManufacturingJobFee = i
                    Case ProgramSettings.ManufacturingFacilityNameColumnName
                        .ManufacturingFacilityName = i
                    Case ProgramSettings.ManufacturingFacilitySystemColumnName
                        .ManufacturingFacilitySystem = i
                    Case ProgramSettings.ManufacturingFacilityRegionColumnName
                        .ManufacturingFacilityRegion = i
                    Case ProgramSettings.ManufacturingFacilitySystemIndexColumnName
                        .ManufacturingFacilitySystemIndex = i
                    Case ProgramSettings.ManufacturingFacilityTaxColumnName
                        .ManufacturingFacilityTax = i
                    Case ProgramSettings.ManufacturingFacilityMEBonusColumnName
                        .ManufacturingFacilityMEBonus = i
                    Case ProgramSettings.ManufacturingFacilityTEBonusColumnName
                        .ManufacturingFacilityTEBonus = i
                    Case ProgramSettings.ManufacturingFacilityUsageColumnName
                        .ManufacturingFacilityUsage = i
                    Case ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName
                        .ManufacturingFacilityFWSystemLevel = i
                    Case ProgramSettings.ComponentFacilityNameColumnName
                        .ComponentFacilityName = i
                    Case ProgramSettings.ComponentFacilitySystemColumnName
                        .ComponentFacilitySystem = i
                    Case ProgramSettings.ComponentFacilityRegionColumnName
                        .ComponentFacilityRegion = i
                    Case ProgramSettings.ComponentFacilitySystemIndexColumnName
                        .ComponentFacilitySystemIndex = i
                    Case ProgramSettings.ComponentFacilityTaxColumnName
                        .ComponentFacilityTax = i
                    Case ProgramSettings.ComponentFacilityMEBonusColumnName
                        .ComponentFacilityMEBonus = i
                    Case ProgramSettings.ComponentFacilityTEBonusColumnName
                        .ComponentFacilityTEBonus = i
                    Case ProgramSettings.ComponentFacilityUsageColumnName
                        .ComponentFacilityUsage = i
                    Case ProgramSettings.ComponentFacilityFWSystemLevelColumnName
                        .ComponentFacilityFWSystemLevel = i
                    Case ProgramSettings.CapComponentFacilityNameColumnName
                        .CapComponentFacilityName = i
                    Case ProgramSettings.CapComponentFacilitySystemColumnName
                        .CapComponentFacilitySystem = i
                    Case ProgramSettings.CapComponentFacilityRegionColumnName
                        .CapComponentFacilityRegion = i
                    Case ProgramSettings.CapComponentFacilitySystemIndexColumnName
                        .CapComponentFacilitySystemIndex = i
                    Case ProgramSettings.CapComponentFacilityTaxColumnName
                        .CapComponentFacilityTax = i
                    Case ProgramSettings.CapComponentFacilityMEBonusColumnName
                        .CapComponentFacilityMEBonus = i
                    Case ProgramSettings.CapComponentFacilityTEBonusColumnName
                        .CapComponentFacilityTEBonus = i
                    Case ProgramSettings.CapComponentFacilityUsageColumnName
                        .CapComponentFacilityUsage = i
                    Case ProgramSettings.CapComponentFacilityFWSystemLevelColumnName
                        .CapComponentFacilityFWSystemLevel = i
                    Case ProgramSettings.CopyingFacilityNameColumnName
                        .CopyingFacilityName = i
                    Case ProgramSettings.CopyingFacilitySystemColumnName
                        .CopyingFacilitySystem = i
                    Case ProgramSettings.CopyingFacilityRegionColumnName
                        .CopyingFacilityRegion = i
                    Case ProgramSettings.CopyingFacilitySystemIndexColumnName
                        .CopyingFacilitySystemIndex = i
                    Case ProgramSettings.CopyingFacilityTaxColumnName
                        .CopyingFacilityTax = i
                    Case ProgramSettings.CopyingFacilityMEBonusColumnName
                        .CopyingFacilityMEBonus = i
                    Case ProgramSettings.CopyingFacilityTEBonusColumnName
                        .CopyingFacilityTEBonus = i
                    Case ProgramSettings.CopyingFacilityUsageColumnName
                        .CopyingFacilityUsage = i
                    Case ProgramSettings.CopyingFacilityFWSystemLevelColumnName
                        .CopyingFacilityFWSystemLevel = i
                    Case ProgramSettings.InventionFacilityNameColumnName
                        .InventionFacilityName = i
                    Case ProgramSettings.InventionFacilitySystemColumnName
                        .InventionFacilitySystem = i
                    Case ProgramSettings.InventionFacilityRegionColumnName
                        .InventionFacilityRegion = i
                    Case ProgramSettings.InventionFacilitySystemIndexColumnName
                        .InventionFacilitySystemIndex = i
                    Case ProgramSettings.InventionFacilityTaxColumnName
                        .InventionFacilityTax = i
                    Case ProgramSettings.InventionFacilityMEBonusColumnName
                        .InventionFacilityMEBonus = i
                    Case ProgramSettings.InventionFacilityTEBonusColumnName
                        .InventionFacilityTEBonus = i
                    Case ProgramSettings.InventionFacilityUsageColumnName
                        .InventionFacilityUsage = i
                    Case ProgramSettings.InventionFacilityFWSystemLevelColumnName
                        .InventionFacilityFWSystemLevel = i
                    Case ProgramSettings.ReactionFacilityNameColumnName
                        .ReactionFacilityName = i
                    Case ProgramSettings.ReactionFacilitySystemColumnName
                        .ReactionFacilitySystem = i
                    Case ProgramSettings.ReactionFacilityRegionColumnName
                        .ReactionFacilityRegion = i
                    Case ProgramSettings.ReactionFacilitySystemIndexColumnName
                        .ReactionFacilitySystemIndex = i
                    Case ProgramSettings.ReactionFacilityTaxColumnName
                        .ReactionFacilityTax = i
                    Case ProgramSettings.ReactionFacilityMEBonusColumnName
                        .ReactionFacilityMEBonus = i
                    Case ProgramSettings.ReactionFacilityTEBonusColumnName
                        .ReactionFacilityTEBonus = i
                    Case ProgramSettings.ReactionFacilityUsageColumnName
                        .ReactionFacilityUsage = i
                    Case ProgramSettings.ReactionFacilityFWSystemLevelColumnName
                        .ReactionFacilityFWSystemLevel = i
                End Select
            Next
        End With

        ' Now Refresh the grid
        If lstManufacturing.Items.Count <> 0 Then
            RefreshCalcData = True
            Call DisplayManufacturingResults(False)
        Else
            Call RefreshManufacturingTabColumns()
        End If

    End Sub

    ' Updates the column sizes when changed
    Private Sub lstManufacturing_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.ColumnWidthChangedEventArgs)
        Dim NewWidth As Integer = lstManufacturing.Columns(e.ColumnIndex).Width

        If Not AddingColumns Then
            With UserManufacturingTabColumnSettings
                Select Case ColumnPositions(e.ColumnIndex)
                    Case ProgramSettings.ItemCategoryColumnName
                        .ItemCategoryWidth = NewWidth
                    Case ProgramSettings.ItemGroupColumnName
                        .ItemGroupWidth = NewWidth
                    Case ProgramSettings.ItemNameColumnName
                        .ItemNameWidth = NewWidth
                    Case ProgramSettings.OwnedColumnName
                        .OwnedWidth = NewWidth
                    Case ProgramSettings.TechColumnName
                        .TechWidth = NewWidth
                    Case ProgramSettings.BPMEColumnName
                        .BPMEWidth = NewWidth
                    Case ProgramSettings.BPTEColumnName
                        .BPTEWidth = NewWidth
                    Case ProgramSettings.InputsColumnName
                        .InputsWidth = NewWidth
                    Case ProgramSettings.ComparedColumnName
                        .ComparedWidth = NewWidth
                    Case ProgramSettings.TotalRunsColumnName
                        .TotalRunsWidth = NewWidth
                    Case ProgramSettings.SingleInventedBPCRunsColumnName
                        .SingleInventedBPCRunsWidth = NewWidth
                    Case ProgramSettings.ProductionLinesColumnName
                        .ProductionLinesWidth = NewWidth
                    Case ProgramSettings.LaboratoryLinesColumnName
                        .LaboratoryLinesWidth = NewWidth
                    Case ProgramSettings.TotalInventionCostColumnName
                        .TotalInventionCostWidth = NewWidth
                    Case ProgramSettings.TotalCopyCostColumnName
                        .TotalCopyCostWidth = NewWidth
                    Case ProgramSettings.TaxesColumnName
                        .TaxesWidth = NewWidth
                    Case ProgramSettings.BrokerFeesColumnName
                        .BrokerFeesWidth = NewWidth
                    Case ProgramSettings.BPProductionTimeColumnName
                        .BPProductionTimeWidth = NewWidth
                    Case ProgramSettings.TotalProductionTimeColumnName
                        .TotalProductionTimeWidth = NewWidth
                    Case ProgramSettings.CopyTimeColumnName
                        .CopyTimeWidth = NewWidth
                    Case ProgramSettings.InventionTimeColumnName
                        .InventionTimeWidth = NewWidth
                    Case ProgramSettings.ItemMarketPriceColumnName
                        .ItemMarketPriceWidth = NewWidth
                    Case ProgramSettings.ProfitColumnName
                        .ProfitWidth = NewWidth
                    Case ProgramSettings.ProfitPercentageColumnName
                        .ProfitPercentageWidth = NewWidth
                    Case ProgramSettings.IskperHourColumnName
                        .IskperHourWidth = NewWidth
                    Case ProgramSettings.SVRColumnName
                        .SVRWidth = NewWidth
                    Case ProgramSettings.SVRxIPHColumnName
                        .SVRxIPHWidth = NewWidth
                    Case ProgramSettings.ScoreColumnName
                        .ScoreWidth = NewWidth
                    Case ProgramSettings.RiskProfitColumnName
                        .RiskProfitWidth = NewWidth
                    Case ProgramSettings.RiskIPHColumnName
                        .RiskIPHWidth = NewWidth
                    Case ProgramSettings.RiskPriceColumnName
                        .RiskPriceWidth = NewWidth
                    Case ProgramSettings.VolatilityColumnName
                        .VolatilityWidth = NewWidth
                    Case ProgramSettings.PriceTrendColumnName
                        .PriceTrendWidth = NewWidth
                    Case ProgramSettings.TotalItemsSoldColumnName
                        .TotalItemsSoldWidth = NewWidth
                    Case ProgramSettings.TotalOrdersFilledColumnName
                        .TotalOrdersFilledWidth = NewWidth
                    Case ProgramSettings.AvgItemsperOrderColumnName
                        .AvgItemsperOrderWidth = NewWidth
                    Case ProgramSettings.CurrentSellOrdersColumnName
                        .CurrentSellOrdersWidth = NewWidth
                    Case ProgramSettings.CurrentBuyOrdersColumnName
                        .CurrentBuyOrdersWidth = NewWidth
                    Case ProgramSettings.TotalCostColumnName
                        .TotalCostWidth = NewWidth
                    Case ProgramSettings.BaseJobCostColumnName
                        .BaseJobCostWidth = NewWidth
                    Case ProgramSettings.NumBPsColumnName
                        .NumBPsWidth = NewWidth
                    Case ProgramSettings.InventionChanceColumnName
                        .InventionChanceWidth = NewWidth
                    Case ProgramSettings.BPTypeColumnName
                        .BPTypeWidth = NewWidth
                    Case ProgramSettings.RaceColumnName
                        .RaceWidth = NewWidth
                    Case ProgramSettings.VolumeperItemColumnName
                        .VolumeperItemWidth = NewWidth
                    Case ProgramSettings.TotalVolumeColumnName
                        .TotalVolumeWidth = NewWidth
                    Case ProgramSettings.PortionSizeColumnName
                        .PortionSizeWidth = NewWidth
                    Case ProgramSettings.ManufacturingJobFeeColumnName
                        .ManufacturingJobFeeWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityNameColumnName
                        .ManufacturingFacilityNameWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilitySystemColumnName
                        .ManufacturingFacilitySystemWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityRegionColumnName
                        .ManufacturingFacilityRegionWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilitySystemIndexColumnName
                        .ManufacturingFacilitySystemIndexWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityTaxColumnName
                        .ManufacturingFacilityTaxWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityMEBonusColumnName
                        .ManufacturingFacilityMEBonusWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityTEBonusColumnName
                        .ManufacturingFacilityTEBonusWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityUsageColumnName
                        .ManufacturingFacilityUsageWidth = NewWidth
                    Case ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName
                        .ManufacturingFacilityFWSystemLevelWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityNameColumnName
                        .ComponentFacilityNameWidth = NewWidth
                    Case ProgramSettings.ComponentFacilitySystemColumnName
                        .ComponentFacilitySystemWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityRegionColumnName
                        .ComponentFacilityRegionWidth = NewWidth
                    Case ProgramSettings.ComponentFacilitySystemIndexColumnName
                        .ComponentFacilitySystemIndexWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityTaxColumnName
                        .ComponentFacilityTaxWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityMEBonusColumnName
                        .ComponentFacilityMEBonusWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityTEBonusColumnName
                        .ComponentFacilityTEBonusWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityUsageColumnName
                        .ComponentFacilityUsageWidth = NewWidth
                    Case ProgramSettings.ComponentFacilityFWSystemLevelColumnName
                        .ComponentFacilityFWSystemLevelWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityNameColumnName
                        .CapComponentFacilityNameWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilitySystemColumnName
                        .CapComponentFacilitySystemWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityRegionColumnName
                        .CapComponentFacilityRegionWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilitySystemIndexColumnName
                        .CapComponentFacilitySystemIndexWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityTaxColumnName
                        .CapComponentFacilityTaxWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityMEBonusColumnName
                        .CapComponentFacilityMEBonusWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityTEBonusColumnName
                        .CapComponentFacilityTEBonusWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityUsageColumnName
                        .CapComponentFacilityUsageWidth = NewWidth
                    Case ProgramSettings.CapComponentFacilityFWSystemLevelColumnName
                        .CapComponentFacilityFWSystemLevelWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityNameColumnName
                        .CopyingFacilityNameWidth = NewWidth
                    Case ProgramSettings.CopyingFacilitySystemColumnName
                        .CopyingFacilitySystemWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityRegionColumnName
                        .CopyingFacilityRegionWidth = NewWidth
                    Case ProgramSettings.CopyingFacilitySystemIndexColumnName
                        .CopyingFacilitySystemIndexWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityTaxColumnName
                        .CopyingFacilityTaxWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityMEBonusColumnName
                        .CopyingFacilityMEBonusWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityTEBonusColumnName
                        .CopyingFacilityTEBonusWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityUsageColumnName
                        .CopyingFacilityUsageWidth = NewWidth
                    Case ProgramSettings.CopyingFacilityFWSystemLevelColumnName
                        .CopyingFacilityFWSystemLevelWidth = NewWidth
                    Case ProgramSettings.InventionFacilityNameColumnName
                        .InventionFacilityNameWidth = NewWidth
                    Case ProgramSettings.InventionFacilitySystemColumnName
                        .InventionFacilitySystemWidth = NewWidth
                    Case ProgramSettings.InventionFacilityRegionColumnName
                        .InventionFacilityRegionWidth = NewWidth
                    Case ProgramSettings.InventionFacilitySystemIndexColumnName
                        .InventionFacilitySystemIndexWidth = NewWidth
                    Case ProgramSettings.InventionFacilityTaxColumnName
                        .InventionFacilityTaxWidth = NewWidth
                    Case ProgramSettings.InventionFacilityMEBonusColumnName
                        .InventionFacilityMEBonusWidth = NewWidth
                    Case ProgramSettings.InventionFacilityTEBonusColumnName
                        .InventionFacilityTEBonusWidth = NewWidth
                    Case ProgramSettings.InventionFacilityUsageColumnName
                        .InventionFacilityUsageWidth = NewWidth
                    Case ProgramSettings.InventionFacilityFWSystemLevelColumnName
                        .InventionFacilityFWSystemLevelWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityNameColumnName
                        .ReactionFacilityNameWidth = NewWidth
                    Case ProgramSettings.ReactionFacilitySystemColumnName
                        .ReactionFacilitySystemWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityRegionColumnName
                        .ReactionFacilityRegionWidth = NewWidth
                    Case ProgramSettings.ReactionFacilitySystemIndexColumnName
                        .ReactionFacilitySystemIndexWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityTaxColumnName
                        .ReactionFacilityTaxWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityMEBonusColumnName
                        .ReactionFacilityMEBonusWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityTEBonusColumnName
                        .ReactionFacilityTEBonusWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityUsageColumnName
                        .ReactionFacilityUsageWidth = NewWidth
                    Case ProgramSettings.ReactionFacilityFWSystemLevelColumnName
                        .ReactionFacilityFWSystemLevelWidth = NewWidth
                End Select
            End With
        End If

    End Sub

    ' Determines if we display the sent column
    Private Function ShowColumn(ColumnName As String) As Boolean
        If Array.IndexOf(ColumnPositions, ColumnName) <> -1 Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Returns the allignment for the column name sent
    Private Function GetColumnAlignment(ColumnName As String) As HorizontalAlignment

        Select Case ColumnName
            Case ProgramSettings.ItemCategoryColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ItemGroupColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ItemNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.OwnedColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.TechColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.BPMEColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.BPTEColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InputsColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ComparedColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.TotalRunsColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.SingleInventedBPCRunsColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ProductionLinesColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.LaboratoryLinesColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalInventionCostColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalCopyCostColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TaxesColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.BrokerFeesColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.BPProductionTimeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalProductionTimeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CopyTimeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionTimeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ItemMarketPriceColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ProfitColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ProfitPercentageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.IskperHourColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.SVRColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.SVRxIPHColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ScoreColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.RiskProfitColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.RiskIPHColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.RiskPriceColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.VolatilityColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.PriceTrendColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalItemsSoldColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalOrdersFilledColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.AvgItemsperOrderColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CurrentSellOrdersColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CurrentBuyOrdersColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ItemsinProductionColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ItemsinStockColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalCostColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.BaseJobCostColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.NumBPsColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionChanceColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.BPTypeColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.RaceColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.VolumeperItemColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.TotalVolumeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.PortionSizeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ManufacturingJobFeeColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ManufacturingFacilityNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ManufacturingFacilitySystemColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ManufacturingFacilityRegionColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ManufacturingFacilitySystemIndexColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ManufacturingFacilityTaxColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ManufacturingFacilityMEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ManufacturingFacilityTEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ManufacturingFacilityUsageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ComponentFacilityNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ComponentFacilitySystemColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ComponentFacilityRegionColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ComponentFacilitySystemIndexColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ComponentFacilityTaxColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ComponentFacilityMEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ComponentFacilityTEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ComponentFacilityUsageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ComponentFacilityFWSystemLevelColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CapComponentFacilityNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CapComponentFacilitySystemColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CapComponentFacilityRegionColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CapComponentFacilitySystemIndexColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CapComponentFacilityTaxColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CapComponentFacilityMEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CapComponentFacilityTEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CapComponentFacilityUsageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CapComponentFacilityFWSystemLevelColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CopyingFacilityNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CopyingFacilitySystemColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CopyingFacilityRegionColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CopyingFacilitySystemIndexColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.CopyingFacilityTaxColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CopyingFacilityMEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CopyingFacilityTEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CopyingFacilityUsageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.CopyingFacilityFWSystemLevelColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionFacilityNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.InventionFacilitySystemColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.InventionFacilityRegionColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.InventionFacilitySystemIndexColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.InventionFacilityTaxColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionFacilityMEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionFacilityTEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionFacilityUsageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.InventionFacilityFWSystemLevelColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ReactionFacilityNameColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ReactionFacilitySystemColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ReactionFacilityRegionColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ReactionFacilitySystemIndexColumnName
                Return HorizontalAlignment.Left
            Case ProgramSettings.ReactionFacilityTaxColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ReactionFacilityMEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ReactionFacilityTEBonusColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ReactionFacilityUsageColumnName
                Return HorizontalAlignment.Right
            Case ProgramSettings.ReactionFacilityFWSystemLevelColumnName
                Return HorizontalAlignment.Right
            Case Else
                Return 0
        End Select

    End Function

#End Region

    Private Sub InitManufacturingTab()

        lstManufacturing.Items.Clear()

        With UserManufacturingTabSettings

            ' Blueprint load types
            Select Case .BlueprintType
                Case rbtnCalcAllBPs.Text
                    rbtnCalcAllBPs.Checked = True
                Case rbtnCalcBPOwned.Text
                    rbtnCalcBPOwned.Checked = True
            End Select

            FirstManufacturingGridLoad = False ' Change this now so it will load the grids for all on reset

            chkCalcCanBuild.Checked = .CheckOnlyBuild
            autoShopping.Checked = .CheckAutoShop

            calcHistoryRegion = UserApplicationSettings.SVRAveragePriceRegion

            txtCalcProdLines.Text = CStr(.ProductionLines)
            txtCalcLabLines.Text = CStr(.LaboratoryLines)
            txtCalcRuns.Text = CStr(.Runs)
            txtCalcNumBPs.Text = CStr(.BPRuns)

            ' Time pickers
            chkCalcMaxBuildTimeFilter.Checked = .MaxBuildTimeCheck
            chkCalcMinBuildTimeFilter.Checked = .MinBuildTimeCheck
            tpMaxBuildTimeFilter.Text = .MaxBuildTime
            tpMinBuildTimeFilter.Text = .MinBuildTime

            ProfitPercentText = "0.0%"
            ProfitText = "0.00"

            ListIDIterator = 0

            btnCalcCalculate.Enabled = True
            lstManufacturing.Enabled = True

            If .ColumnSortType = "Ascending" Then
                ManufacturingColumnSortType = SortOrder.Ascending
            Else
                ManufacturingColumnSortType = SortOrder.Descending
            End If

            ManufacturingColumnClicked = .ColumnSort

            AddToShoppingListToolStripMenuItem.Enabled = False ' Don't enable this until they calculate something

        End With

        Call ResetRefresh()

    End Sub

    ' Saves all the settings on the screen
    Private Sub btnCalcSaveSettings()
        Dim TempSettings As ManufacturingTabSettings = Nothing
        Dim Settings As New ProgramSettings

        If Trim(txtCalcProdLines.Text) <> "" Then
            If Not IsNumeric(txtCalcProdLines.Text) Then
                MsgBox("Invalid Production Lines Value", vbExclamation, Application.ProductName)
                txtCalcProdLines.Focus()
                Exit Sub
            End If
        End If

        If Trim(txtCalcLabLines.Text) <> "" Then
            If Not IsNumeric(txtCalcLabLines.Text) Then
                MsgBox("Invalid Laboratory Lines Value", vbExclamation, Application.ProductName)
                txtCalcLabLines.Focus()
                Exit Sub
            End If
        End If

        If Trim(txtCalcRuns.Text) <> "" Then
            If Not IsNumeric(txtCalcRuns.Text) Then
                MsgBox("Invalid Runs Value", vbExclamation, Application.ProductName)
                txtCalcRuns.Focus()
                Exit Sub
            End If
        End If

        ' Save the column order and width first
        AllSettings.SaveManufacturingTabColumnSettings(UserManufacturingTabColumnSettings)

        With TempSettings
            .CheckBPTypeNPCBPOs = True
            .CheckBPTypeAmmoCharges = True
            .CheckBPTypeDrones = True
            .CheckBPTypeModules = True
            .CheckBPTypeRigs = True
            .CheckBPTypeShips = True
            .CheckBPTypeMisc = True

            .CheckTech1 = True

            .CheckAutoCalcNumBPs = False

            ' Blueprint load types
            If rbtnCalcAllBPs.Checked Then
                .BlueprintType = rbtnCalcAllBPs.Text
            ElseIf rbtnCalcBPOwned.Checked Then
                .BlueprintType = rbtnCalcBPOwned.Text
            End If

            .ItemTypeFilter = "All Types"
            .TextItemFilter = ""

            .CheckIncludeTaxes = True
            .CheckIncludeBrokersFees = 1

            .CheckRaceAmarr = True
            .CheckRaceCaldari = True
            .CheckRaceMinmatar = True
            .CheckRaceGallente = True
            .CheckRacePirate = True
            .CheckRaceOther = True

            .CalcPPU = False
            .CheckSellExcessItems = False

            .ColumnSort = ManufacturingColumnClicked
            If ManufacturingColumnSortType = SortOrder.Ascending Then
                .ColumnSortType = "Ascending"
            Else
                .ColumnSortType = "Decending"
            End If

            ' Sort the list based on the saved column, if they change the number of columns below value, then find IPH, if not there, use column 0
            If ManufacturingColumnClicked > lstManufacturing.Columns.Count Then
                ' Find the IPH column
                If UserManufacturingTabColumnSettings.IskperHour <> 0 Then
                    ManufacturingColumnClicked = UserManufacturingTabColumnSettings.IskperHour
                Else
                    ManufacturingColumnClicked = 0 ' Default, will always be there
                End If

            End If

            .ColumnSort = ManufacturingColumnClicked

            .PriceCompare = "Compare All"

            .CheckSmall = True
            .CheckMedium = True
            .CheckLarge = True
            .CheckXL = True

            .CheckSVRIncludeNull = True
            .ProductionLines = CInt(txtCalcProdLines.Text)
            .LaboratoryLines = CInt(txtCalcLabLines.Text)
            .Runs = CInt(txtCalcRuns.Text)
            .BPRuns = CInt(txtCalcNumBPs.Text)

            .CheckOnlyBuild = chkCalcCanBuild.Checked
            .CheckAutoShop = autoShopping.Checked

            .PriceTrend = "All"

            .MaxBuildTimeCheck = chkCalcMaxBuildTimeFilter.Checked
            .MaxBuildTime = tpMaxBuildTimeFilter.Text
            .MinBuildTimeCheck = chkCalcMinBuildTimeFilter.Checked
            .MinBuildTime = tpMinBuildTimeFilter.Text

            .BuildT2T3Materials = BuildMatType.RawMaterials

            .ProfitThresholdCheck = CheckState.Unchecked
            .ProfitThreshold = 0

            ' Save these here as well as in settings
            With UserApplicationSettings
                .IgnoreSVRThresholdValue = 0
                .SVRAveragePriceRegion = calcHistoryRegion
                .SVRAveragePriceDuration = ""
            End With

            Call Settings.SaveApplicationSettings(UserApplicationSettings)

        End With


        ' Save the data in the XML file
        Call Settings.SaveManufacturingSettings(TempSettings)

        ' Save the data to the local variable
        UserManufacturingTabSettings = TempSettings

    End Sub

    ' Switches button to calculate
    Public Sub ResetRefresh()
        RefreshCalcData = False
        btnCalcCalculate.Text = "Calculate"
    End Sub

    Structure OptimalDecryptorItem
        Dim ItemTypeID As Long
        Dim ListLocationID As Integer ' The unique number of the item in the list
        Dim CalcType As String ' Raw, Component, or Build/Buy
        Dim CompareValue As Double ' IPH or profit
    End Structure

    ' Displays the results of the options on the screen. If Calculate is true, then it will run the calculations. If not, just a preview of the data
    Private Sub DisplayManufacturingResults(ByVal Calculate As Boolean)
        Dim SQL As String
        Dim readerBPs As SQLiteDataReader
        Dim readerIDs As SQLiteDataReader
        Dim readerArray As SQLiteDataReader

        Dim UpdateTypeIDs As New List(Of Long) ' Full list of TypeID's to update SVR data with, these will have Market IDs
        Dim MarketRegionID As Long

        Dim BaseItems As New List(Of ManufacturingItem) ' Holds all the items and their decryptors, relics, meta etc for initial list
        Dim ManufacturingList As New List(Of ManufacturingItem) ' List of all the items we manufactured - may be different than the item list
        Dim FinalItemList As New List(Of ManufacturingItem) ' Final list of data

        Dim InsertItem As New ManufacturingItem

        Dim ManufacturingBlueprint As Blueprint

        Dim BPList As ListViewItem

        Dim i, j As Integer
        Dim BPRecordCount As Integer = 0
        Dim TotalItemCount As Integer = 0
        Dim TempItemType As Integer = 0

        Dim InventionDecryptors As New DecryptorList

        Dim OrigME As Integer
        Dim OrigTE As Integer

        Dim AddItem As Boolean

        ' For multi-use pos arrays
        Dim ProcessAllMultiUsePOSArrays As Boolean = False
        Dim ArrayName As String = ""
        Dim MultiUsePOSArrays As List(Of IndustryFacility)

        Dim DecryptorUsed As New Decryptor

        ' T2/T3 variables
        Dim RelicName As String = ""
        Dim InputText As String = ""
        Dim DecryptorName As String = ""

        ' BPC stuff
        Dim CopyPricePerSecond As Double = 0
        Dim T1BPCType As String = ""
        Dim T1BPCName As String = ""
        Dim T1BPCMaxRuns As Integer = 0

        ' SVR Threshold
        Dim SVRThresholdValue As Double
        Dim TypeIDCheck As String = ""

        ' Number of blueprints used
        Dim NumberofBlueprints As Integer

        Dim OriginalBPOwnedFlag As Boolean

        ' For the optimal decryptor checking
        Dim OptimalDecryptorItems As New List(Of OptimalDecryptorItem)

        ' Set this now and enable it if they calculate
        AddToShoppingListToolStripMenuItem.Enabled = False

        If Trim(txtCalcProdLines.Text) <> "" Then
            If Not IsNumeric(txtCalcProdLines.Text) Then
                MsgBox("Invalid Production Lines value", vbExclamation, Application.ProductName)
                txtCalcProdLines.Focus()
                txtCalcProdLines.SelectAll()
                Exit Sub
            End If
        End If

        If Val(txtCalcProdLines.Text) = 0 Then
            MsgBox("You must select a non-zero production lines value.", vbExclamation, Application.ProductName)
            txtCalcProdLines.Focus()
            txtCalcProdLines.SelectAll()
            Exit Sub
        End If

        If Trim(txtCalcNumBPs.Text) <> "" Then
            If Not IsNumeric(txtCalcNumBPs.Text) Then
                MsgBox("Invalid Num BPs value", vbExclamation, Application.ProductName)
                txtCalcNumBPs.Focus()
                txtCalcNumBPs.SelectAll()
                Exit Sub
            End If
        End If

        If Val(txtCalcNumBPs.Text) = 0 Then
            MsgBox("You must select a non-zero Num BPs value.", vbExclamation, Application.ProductName)
            txtCalcNumBPs.Focus()
            txtCalcNumBPs.SelectAll()
            Exit Sub
        End If

        If Trim(txtCalcRuns.Text) <> "" Then
            If Not IsNumeric(txtCalcRuns.Text) Then
                MsgBox("Invalid Runs value", vbExclamation, Application.ProductName)
                txtCalcRuns.Focus()
                txtCalcRuns.SelectAll()
                Exit Sub
            End If
        End If

        If Val(txtCalcRuns.Text) = 0 Then
            MsgBox("You must select a non-zero Runs value.", vbExclamation, Application.ProductName)
            txtCalcRuns.Focus()
            txtCalcRuns.SelectAll()
            Exit Sub
        End If

        If Trim(txtCalcLabLines.Text) <> "" Then
            If Not IsNumeric(txtCalcLabLines.Text) Then
                MsgBox("Invalid Laboratory Lines value", vbExclamation, Application.ProductName)
                txtCalcLabLines.Focus()
                txtCalcLabLines.SelectAll()
                Exit Sub
            End If
        End If

        If Val(txtCalcLabLines.Text) = 0 Then
            MsgBox("You must select a non-zero laboratory lines value.", vbExclamation, Application.ProductName)
            txtCalcLabLines.Focus()
            txtCalcLabLines.SelectAll()
            Exit Sub
        End If

        ' Make sure the build times don't overlap if both checked
        If chkCalcMinBuildTimeFilter.Checked And chkCalcMaxBuildTimeFilter.Checked Then
            If ConvertDHMSTimetoSeconds(tpMinBuildTimeFilter.Text) >= ConvertDHMSTimetoSeconds(tpMaxBuildTimeFilter.Text) Then
                MsgBox("You must select a Min Build time less than the Max Build time selected.", vbExclamation, Application.ProductName)
                chkCalcMinBuildTimeFilter.Focus()
                Exit Sub
            End If
        End If

        SVRThresholdValue = Nothing ' Include everything

        ' Save the refresh value since everytime we load the facility it will change it
        Dim SavedRefreshValue As Boolean = RefreshCalcData

        ' Make sure they have a facility loaded - if not, load the default for the type
        If Not CalcBaseFacility.GetFacility(ProductionType.Manufacturing).FullyLoaded Then
            CalcBaseFacility.InitializeFacilities(FacilityView.LimitedControls, ProductionType.Manufacturing)
        End If

        If Not SavedRefreshValue Then
            Application.UseWaitCursor = True
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            ' Only cancel if they hit the cancel button
            btnCalcCalculate.Text = "Cancel"

            ' Get the query for the data
            SQL = BuildManufacturingSelectQuery(BPRecordCount, UserInventedBPs)

            If SQL = "" Then
                ' No valid query so just show nothing
                lstManufacturing.Items.Clear()
                FinalManufacturingItemList = Nothing
                GoTo ExitCalc
            End If

            ' Get data
            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            DBCommand.Parameters.AddWithValue("@USERBP_USERID", GetBPUserID(SelectedCharacter.ID)) ' need to search for corp ID too
            DBCommand.Parameters.AddWithValue("@USERBP_CORPID", CStr(SelectedCharacter.CharacterCorporation.CorporationID))
            readerBPs = DBCommand.ExecuteReader

            If Not readerBPs.HasRows Then
                ' No data
                lstManufacturing.Items.Clear()
                ' Clear list of data
                FinalManufacturingItemList = Nothing
                GoTo ExitCalc
            End If

            'Cursor.Current = Cursors.WaitCursor
            MetroProgressBar.Minimum = 0
            MetroProgressBar.Maximum = BPRecordCount
            MetroProgressBar.Value = 0
            MetroProgressBar.Visible = True

            ' Reset the record Iterator and list formats
            ListIDIterator = 0
            ListRowFormats = New List(Of RowFormat)

            pnlStatus.Text = "Building List..."

            ' Add the data to the final list, then display into the grid
            While readerBPs.Read
                Application.DoEvents()
                ' If they cancel the calc
                If CancelManufacturingTabCalc Then
                    GoTo ExitCalc
                End If

                ' 0-BP_ID, 1-BLUEPRINT_GROUP, 2-BLUEPRINT_NAME, 3-ITEM_GROUP_ID, 4-ITEM_GROUP, 5-ITEM_CATEGORY_ID, 
                ' 6-ITEM_CATEGORY, 7-ITEM_ID, 8-ITEM_NAME, 9-ME, 10-TE, 11-USERID, 12-ITEM_TYPE, 13-RACE_ID, 14-OWNED, 15-SCANNED 
                ' 16-BP_TYPE, 17-UNIQUE_BP_ITEM_ID, 18-FAVORITE, 19-VOLUME, 20-MARKET_GROUP_ID, 21-ADDITIONAL_COSTS, 
                ' 22-LOCATION_ID, 23-QUANTITY, 24-FLAG_ID, 25-RUNS, 26-IGNORE, 27-TECH_LEVEL
                InsertItem = New ManufacturingItem

                ' Reset
                MultiUsePOSArrays = New List(Of IndustryFacility)
                ProcessAllMultiUsePOSArrays = False
                ArrayName = ""

                ' Save the items before adding
                InsertItem.BPID = CLng(readerBPs.GetValue(0)) ' Hidden
                InsertItem.ItemGroupID = readerBPs.GetInt32(3)
                InsertItem.ItemGroup = readerBPs.GetString(4)
                InsertItem.ItemCategoryID = readerBPs.GetInt32(5)
                InsertItem.ItemCategory = readerBPs.GetString(6)
                InsertItem.ItemTypeID = CLng(readerBPs.GetValue(7))
                InsertItem.ItemName = readerBPs.GetString(8)
                InsertItem.AddlCosts = readerBPs.GetDouble(21)

                ' 1, 2, 14 are T1, T2, T3
                ' 3 is Storyline
                ' 15 is Pirate Faction
                ' 16 is Navy Faction
                TempItemType = CInt(readerBPs.GetValue(12))

                Select Case TempItemType ' For Tech
                    Case 1
                        InsertItem.TechLevel = "T1"
                    Case 2
                        InsertItem.TechLevel = "T2"
                    Case 14
                        InsertItem.TechLevel = "T3"
                    Case 3
                        InsertItem.TechLevel = "Storyline"
                    Case 15
                        InsertItem.TechLevel = "Pirate"
                    Case 16
                        InsertItem.TechLevel = "Navy"
                    Case Else
                        InsertItem.TechLevel = ""
                End Select

                ' Owned flag
                If readerBPs.GetInt32(14) = 0 Then
                    InsertItem.Owned = No
                    OriginalBPOwnedFlag = False
                Else
                    InsertItem.Owned = Yes
                    OriginalBPOwnedFlag = True
                End If

                ' Scanned flag for corp or personal bps
                InsertItem.Scanned = readerBPs.GetInt32(15)

                ' BP Type
                InsertItem.BlueprintType = GetBPType(readerBPs.GetInt32(16))

                ' Save the runs for checking decryptors and relics later
                InsertItem.SavedBPRuns = readerBPs.GetInt32(25)

                ' ME value, either what the entered or in the table
                Select Case TempItemType
                    Case 3, 15, 16
                        ' Storyline, Pirate, and Navy can't be updated
                        InsertItem.BPME = 0
                    Case 2, 14 ' T2 or T3 - either Invented, or BPO
                        If InsertItem.Owned = No Then
                            InsertItem.BPME = BaseT2T3ME
                        Else
                            ' Use what they entered
                            InsertItem.BPME = CInt(readerBPs.GetValue(9))
                        End If
                    Case Else
                        If InsertItem.Owned = No Then
                            ' Use the default
                            InsertItem.BPME = CInt(CalcTempME)
                        Else
                            ' Use what they entered
                            InsertItem.BPME = CInt(readerBPs.GetValue(9))
                        End If
                End Select

                ' TE value, either what the entered or in the table
                Select Case TempItemType
                    Case 3, 15, 16
                        ' Storyline, Pirate, and Navy can't be updated
                        InsertItem.BPTE = 0
                    Case 2, 14 ' T2 or T3 - either Invented, or BPO
                        If InsertItem.Owned = No Then
                            InsertItem.BPTE = BaseT2T3TE
                        Else
                            ' Use what they entered
                            InsertItem.BPTE = CInt(readerBPs.GetValue(10))
                        End If
                    Case Else
                        If InsertItem.Owned = No Then
                            ' Use the default
                            InsertItem.BPTE = CInt(CalcTempTE)
                        Else
                            ' Use what they entered
                            InsertItem.BPTE = CInt(readerBPs.GetValue(10))
                        End If
                End Select

                ' Default to building/inventing/RE'ing all
                InsertItem.CanBuildBP = True
                InsertItem.CanInvent = True
                InsertItem.CanRE = True

                ' Default prices
                InsertItem.Profit = 0
                InsertItem.ProfitPercent = 0
                InsertItem.IPH = 0

                ' Save the original ME/TE
                OrigME = CInt(InsertItem.BPME)
                OrigTE = CInt(InsertItem.BPTE)

                ' Runs and lines
                InsertItem.Runs = CInt(txtCalcRuns.Text)
                InsertItem.ProductionLines = CInt(txtCalcProdLines.Text)
                InsertItem.LaboratoryLines = CInt(txtCalcLabLines.Text)

                ' Reset all the industry facilities
                InsertItem.ManufacturingFacility = New IndustryFacility
                InsertItem.ComponentManufacturingFacility = New IndustryFacility
                InsertItem.CapComponentManufacturingFacility = New IndustryFacility
                InsertItem.CopyFacility = New IndustryFacility
                InsertItem.InventionFacility = New IndustryFacility
                InsertItem.ReactionFacility = New IndustryFacility

                Dim SelectedIndyType As ProductionType
                Dim TempFacility As New ManufacturingFacility

                Dim BuildType As ProductionType

                ' Set the facility for manufacturing
                If CalcBaseFacility.GetFacility(ProductionType.Manufacturing).FacilityType = FacilityTypes.POS Then
                    ' If this is visible, then look up as a pos, else just look up normally
                    SelectedIndyType = CalcBaseFacility.GetProductionType(InsertItem.ItemGroupID, InsertItem.ItemCategoryID, ManufacturingFacility.ActivityManufacturing)
                    ' See if we will have to add duplicate entries for each type of multi-use array
                    Select Case SelectedIndyType
                        Case ProductionType.POSFuelBlockManufacturing
                            If CalcBaseFacility.GetPOSFuelBlockComboName = "All" Then
                                ProcessAllMultiUsePOSArrays = True
                            Else
                                ProcessAllMultiUsePOSArrays = False
                                ArrayName = GetCalcPOSMultiUseArrayName(CalcBaseFacility.GetPOSFuelBlockComboName)
                            End If
                        Case ProductionType.POSLargeShipManufacturing
                            If CalcBaseFacility.GetPOSLargeShipComboName = "All" Then
                                ProcessAllMultiUsePOSArrays = True
                            Else
                                ProcessAllMultiUsePOSArrays = False
                                ArrayName = GetCalcPOSMultiUseArrayName(CalcBaseFacility.GetPOSLargeShipComboName)
                            End If
                        Case ProductionType.POSModuleManufacturing
                            If CalcBaseFacility.GetPOSModulesComboName = "All" Then
                                ProcessAllMultiUsePOSArrays = True
                            Else
                                ProcessAllMultiUsePOSArrays = False
                                ArrayName = GetCalcPOSMultiUseArrayName(CalcBaseFacility.GetPOSModulesComboName)
                            End If
                        Case Else
                            ProcessAllMultiUsePOSArrays = False
                            ArrayName = ""
                    End Select

                    ' Need to autoselect the pos array by type of blueprint
                    SQL = "SELECT DISTINCT ARRAY_NAME, MATERIAL_MULTIPLIER, TIME_MULTIPLIER FROM ASSEMBLY_ARRAYS "
                    SQL = SQL & "WHERE ACTIVITY_ID = "
                    SQL = SQL & CStr(IndustryActivities.Manufacturing) & " "
                    ' Check groups and categories
                    SQL = SQL & CalcBaseFacility.GetFacilityCatGroupIDSQL(InsertItem.ItemCategoryID, InsertItem.ItemGroupID, IndustryActivities.Manufacturing) & " "
                    If ArrayName <> "" Then
                        SQL = SQL & "AND ARRAY_NAME = '" & ArrayName & "'"
                    End If

                    DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                    readerArray = DBCommand.ExecuteReader

                    While readerArray.Read()
                        ' Set the facility
                        InsertItem.ManufacturingFacility = CalcBaseFacility.GetFacility(SelectedIndyType)
                        InsertItem.ManufacturingFacility.FacilityName = readerArray.GetString(0)
                        InsertItem.ManufacturingFacility.MaterialMultiplier = readerArray.GetDouble(1)
                        InsertItem.ManufacturingFacility.TimeMultiplier = readerArray.GetDouble(2)
                        InsertItem.ManufacturingFacility.TaxRate = POSTaxRate

                        ' Add the facility if multiple
                        If ProcessAllMultiUsePOSArrays Then
                            Call MultiUsePOSArrays.Add(InsertItem.ManufacturingFacility)
                        End If
                    End While

                    readerArray.Close()
                Else

                    ' Nothing special, just set it to the current selected facility for this type
                    Select Case InsertItem.ItemGroupID
                        Case ItemIDs.ReactionBiochmeicalsGroupID, ItemIDs.ReactionCompositesGroupID, ItemIDs.ReactionPolymersGroupID, ItemIDs.ReactionsIntermediateGroupID
                            BuildType = ProductionType.Reactions
                        Case Else
                            BuildType = TempFacility.GetProductionType(InsertItem.ItemGroupID, InsertItem.ItemCategoryID, ManufacturingFacility.ActivityManufacturing)
                    End Select

                    Select Case BuildType
                        Case ProductionType.Manufacturing
                            InsertItem.ManufacturingFacility = CalcBaseFacility.GetFacility(BuildType)
                    End Select
                End If

                If BuildType = ProductionType.Reactions Then
                    'Need to use the manufacturing facility instead of component facility since they are more likely to make fuel blocks for reactions there
                    InsertItem.ComponentManufacturingFacility = CalcBaseFacility.GetFacility(ProductionType.Manufacturing)
                End If

                ' Now determine how many copies of the base item we need with different data changed
                ' If T1, just select compare types (raw and components)
                ' If T2, first select each decryptor, then select Compare types (raw and components)
                ' If T3, first choose a decryptor, then Relic, then select compare types (raw and components)
                ' Insert each different combination
                If InsertItem.TechLevel = "T2" Or InsertItem.TechLevel = "T3" Then
                    ' For determining the owned blueprints
                    Dim TempDecryptors As New DecryptorList
                    Dim OriginalRelicUsed As String = ""
                    Dim CheckOwnedBP As Boolean = False
                    Dim OriginalBPType As BPType = InsertItem.BlueprintType
                    Dim OriginalDecryptorUsed As Decryptor = TempDecryptors.GetDecryptor(OrigME, OrigTE, InsertItem.SavedBPRuns, CInt(InsertItem.TechLevel.Substring(1)))
                    If InsertItem.TechLevel = "T3" Then
                        OriginalRelicUsed = GetRelicfromInputs(OriginalDecryptorUsed, InsertItem.BPID, InsertItem.SavedBPRuns)
                    End If

                    ' Now add additional records for each decryptor
                    For j = 1 To CalcDecryptorCheckBoxes.Count - 1
                        ' If it's checked or if optimal is checked, add the decryptor
                        If CalcDecryptorCheckBoxes(j).Checked Then

                            ' These are all invented BPCs, BPC and BPOs are added separately below
                            InsertItem.BlueprintType = BPType.InventedBPC

                            ' If they are not using for T2 or T3 then only add No Decyrptor and exit for
                            If CalcDecryptorCheckBoxes(j).Text <> None Then

                                ' Select a decryptor
                                DecryptorUsed = InventionDecryptors.GetDecryptor(CDbl(CalcDecryptorCheckBoxes(j).Text.Substring(0, 3)))

                                ' Add decryptor
                                InsertItem.Decryptor = DecryptorUsed
                                InsertItem.Inputs = DecryptorUsed.Name
                                InsertItem.BPME = BaseT2T3ME + InsertItem.Decryptor.MEMod
                                InsertItem.BPTE = BaseT2T3TE + InsertItem.Decryptor.TEMod

                            Else
                                ' Add no decryptor, this is a copy or bpo
                                InsertItem.Decryptor = NoDecryptor
                                InsertItem.Inputs = NoDecryptor.Name
                                InsertItem.BPME = BaseT2T3ME
                                InsertItem.BPTE = BaseT2T3TE
                            End If

                            ' Relics
                            If InsertItem.TechLevel = "T3" Then
                                ' Skip T3 items
                            Else
                                ' No relic for T2
                                InsertItem.Relic = ""
                                ' Set the owned flag before inserting
                                CheckOwnedBP = SetItemOwnedFlag(InsertItem, OriginalDecryptorUsed, OriginalRelicUsed, OrigME, OrigTE, OriginalBPOwnedFlag)
                                If rbtnCalcAllBPs.Checked Or (UserInventedBPs.Contains(InsertItem.BPID)) Or
                                    (rbtnCalcBPOwned.Checked And CheckOwnedBP) Or rbtnCalcBPFavorites.Checked Then
                                    ' Insert the item 
                                    Call InsertItemCalcType(BaseItems, InsertItem, ProcessAllMultiUsePOSArrays, MultiUsePOSArrays, ListRowFormats)
                                End If
                            End If

                            ' If they don't want to include decryptors, then exit loop after adding none
                            If InsertItem.TechLevel = "T2" Then
                                Exit For
                            End If
                        End If
                    Next

                    ' Finally, see if the original blueprint was not invented and then add it separately - BPCs and BPOs (should only be T2)
                    If OriginalBPType = BPType.Copy Or OriginalBPType = BPType.Original Then
                        ' Get the original me/te
                        InsertItem.BPME = OrigME
                        InsertItem.BPTE = OrigTE
                        InsertItem.Owned = Yes
                        InsertItem.Inputs = Unknown
                        InsertItem.BlueprintType = OriginalBPType

                        ' Insert the item 
                        Call InsertItemCalcType(BaseItems, InsertItem, ProcessAllMultiUsePOSArrays, MultiUsePOSArrays, ListRowFormats)
                    End If

                Else ' All T1 and others
                    InsertItem.Inputs = None
                    InsertItem.Relic = ""
                    InsertItem.Decryptor = NoDecryptor

                    InsertItem.InventionFacility = NoFacility
                    InsertItem.CopyFacility = NoFacility

                    ' Insert the items based on compare types
                    Call InsertItemCalcType(BaseItems, InsertItem, ProcessAllMultiUsePOSArrays, MultiUsePOSArrays, ListRowFormats)
                End If

                ' For each record, update the progress bar
                Call IncrementToolStripProgressBar(MetroProgressBar)

            End While

            ' Set the formats
            Call lstManufacturing.SetRowFormats(ListRowFormats)
            Application.DoEvents()

            readerBPs.Close()
            readerBPs = Nothing
            DBCommand = Nothing

            TotalItemCount = BaseItems.Count

            ' *** Calculate ***
            ' Got all the data, now see if they want to calculate prices
            If Calculate Then
                'If TotalItemCount > 1000 Then
                '    ' Make sure they know this will take a bit to run - unless this is fairly quick
                '    Response = MsgBox("This may take some time to complete. Do you want to continue?", vbYesNo, Me.Text)

                '    If Response = vbNo Then
                '        ' Just display the results of the query
                '        GoTo DisplayResults
                '    End If
                'End If

                ListIDIterator = 0 ' Reset the iterator for new list
                ' Reset the format list and recalc
                ListRowFormats = New List(Of RowFormat)

                ' Disable all the controls individulally so we can use cancel button
                btnCalcSelectColumns.Enabled = False
                gbCalcBPSelect.Enabled = False
                gbCalcProdLines.Enabled = False
                gbCalcTextColors.Enabled = False
                lstManufacturing.Enabled = False

                If Not UserApplicationSettings.DisableSVR Then

                    Dim MH As New MarketPriceInterface(MetroProgressBar)

                    ' First thing we want to do is update the manufactured item prices
                    pnlStatus.Text = "Updating Market History..."
                    MetroProgressBar.Visible = False
                    Application.DoEvents()

                    ' First find out which of the typeIDs in BaseItems have MarketID's
                    For i = 0 To BaseItems.Count - 1
                        TypeIDCheck = TypeIDCheck & BaseItems(i).ItemTypeID & ","
                    Next

                    ' Format string
                    TypeIDCheck = "(" & TypeIDCheck.Substring(0, Len(TypeIDCheck) - 1) & ")"
                    SQL = "SELECT typeID FROM INVENTORY_TYPES WHERE typeID IN " & TypeIDCheck & " AND marketGroupID IS NOT NULL"
                    DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                    readerIDs = DBCommand.ExecuteReader

                    ' Now add these to the list
                    While readerIDs.Read()
                        If Not UpdateTypeIDs.Contains(readerIDs.GetInt64(0)) Then
                            UpdateTypeIDs.Add(readerIDs.GetInt64(0))
                        End If
                    End While
                    readerIDs.Close()

                    ' Get the region ID
                    MarketRegionID = GetRegionID(calcHistoryRegion)

                    If MarketRegionID = 0 Then
                        MarketRegionID = TheForgeTypeID ' The Forge as default
                        calcHistoryRegion = "The Forge"
                    End If

                    ' Update the prices
                    If Not MH.UpdateESIPriceHistory(UpdateTypeIDs, MarketRegionID) Then
                        ' Update Failed, don't reload everything
                        Call MsgBox("Price update timed out for some items. Please try again.", vbInformation, Application.ProductName)
                    End If
                    If CancelThreading Then
                        ' They had a ton of errors
                        Call MsgBox("You had an excessive amount of errors while attempting to update price history and the process was canceled. Please try again later.", vbCritical, Application.ProductName)
                        CancelThreading = False
                    End If
                End If

                pnlStatus.Text = "Calculating..."
                MetroProgressBar.Minimum = 0
                MetroProgressBar.Maximum = TotalItemCount
                MetroProgressBar.Value = 0
                MetroProgressBar.Visible = True

                Application.DoEvents()

                ' Loop through the item list and calculate data
                For i = 0 To BaseItems.Count - 1

                    Application.DoEvents()

                    InsertItem = BaseItems(i)

                    ' If they cancel the calc
                    If CancelManufacturingTabCalc Then
                        GoTo ExitCalc
                    End If

                    ' Set the number of BPs
                    With InsertItem
                        If (.TechLevel = "T2" Or .TechLevel = "T3") And (.BlueprintType = BPType.InventedBPC Or .BlueprintType = BPType.NotOwned) Then
                            ' For T3 or if they have calc checked, we will never have a BPO so determine the number of BPs
                            NumberofBlueprints = GetUsedNumBPs(.BPID, CInt(.TechLevel.Substring(1, 1)), .Runs, .ProductionLines, .NumBPs, .Decryptor.RunMod)
                        Else
                            NumberofBlueprints = CInt(txtCalcNumBPs.Text)
                        End If
                    End With

                    ' Construct the BP
                    ManufacturingBlueprint = New Blueprint(InsertItem.BPID, CInt(txtCalcRuns.Text), InsertItem.BPME, InsertItem.BPTE,
                                                           NumberofBlueprints, CInt(txtCalcProdLines.Text), SelectedCharacter,
                                                           UserApplicationSettings, False, InsertItem.AddlCosts, InsertItem.ManufacturingFacility,
                                                           InsertItem.ComponentManufacturingFacility, InsertItem.CapComponentManufacturingFacility, InsertItem.ReactionFacility,
                                                           False, UserManufacturingTabSettings.BuildT2T3Materials, True)

                    ' Set the T2 and T3 inputs if necessary
                    If ((InsertItem.TechLevel = "T2" Or InsertItem.TechLevel = "T3") And InsertItem.BlueprintType = BPType.InventedBPC) Then

                        ' Strip off the relic if in here for the decryptor
                        If InsertItem.Inputs.Contains("-") Then
                            InputText = InsertItem.Inputs.Substring(0, InStr(InsertItem.Inputs, "-") - 2)
                        Else
                            InputText = InsertItem.Inputs
                        End If

                        If InputText = None Then
                            SelectedDecryptor = NoDecryptor
                        Else ' A decryptor is set
                            SelectedDecryptor = InventionDecryptors.GetDecryptor(InputText)
                        End If

                        ' Construct the T2/T3 BP
                        Call ManufacturingBlueprint.InventBlueprint(CInt(txtCalcLabLines.Text), SelectedDecryptor, InsertItem.InventionFacility,
                                                               InsertItem.CopyFacility, GetInventItemTypeID(InsertItem.BPID, InsertItem.Relic))

                    End If

                    ' Build the blueprint(s)
                    Call ManufacturingBlueprint.BuildItems(True, GetBrokerFeeData(), False, False, False)

                    ' If checked, Add the values to the array only if we can Build, Invent, or RE it
                    AddItem = True

                    ' User can Build
                    If chkCalcCanBuild.Checked And Not ManufacturingBlueprint.UserCanBuildBlueprint Then
                        AddItem = False
                    End If

                    ' User can Invent
                    If Not ManufacturingBlueprint.UserCanInventRE And (ManufacturingBlueprint.GetTechLevel = 2 Or ManufacturingBlueprint.GetTechLevel = 3) Then
                        AddItem = False
                    End If

                    'Update SVRAveragePriceDuration to the defualt
                    UserApplicationSettings.SVRAveragePriceDuration = ProgramSettings.DefaultSVRAveragePriceDuration

                    ' Adjust the item with calculations
                    If AddItem Then
                        Application.DoEvents()
                        ' Add data that will the same for all options (need to move more from the bottom but have to test)
                        InsertItem.CanBuildBP = ManufacturingBlueprint.UserCanBuildBlueprint
                        InsertItem.CanInvent = ManufacturingBlueprint.UserCanInventRE
                        InsertItem.CanRE = ManufacturingBlueprint.UserCanInventRE
                        ' Trend data
                        InsertItem.PriceTrend = CalculatePriceTrend(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration))
                        InsertItem.Volatility = CalculateVolatility(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration))
                        InsertItem.ItemMarketPrice = ManufacturingBlueprint.GetItemMarketPrice

                        ' Add all the volume, items on hand, etc here since they won't change
                        InsertItem.TotalItemsSold = CalculateTotalItemsSold(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration))
                        InsertItem.TotalOrdersFilled = CalculateTotalOrdersFilled(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration))
                        InsertItem.AvgItemsperOrder = CDbl(IIf(InsertItem.TotalOrdersFilled = 0, 0, InsertItem.TotalItemsSold / InsertItem.TotalOrdersFilled))
                        Call GetCurrentOrders(InsertItem.ItemTypeID, MarketRegionID, InsertItem.CurrentBuyOrders, InsertItem.CurrentSellOrders)

                        InsertItem.ItemsinStock = GetTotalItemsinStock(InsertItem.ItemTypeID)
                        InsertItem.ItemsinProduction = GetTotalItemsinProduction(InsertItem.ItemTypeID)

                        ' Get the output data
                        If True Then
                            ' Need to add a record for each of the three types

                            ' *** For components, only add if it has buildable components
                            If ManufacturingBlueprint.HasComponents Then
                                ' Components first
                                InsertItem.ProfitPercent = ManufacturingBlueprint.GetTotalComponentProfitPercent
                                InsertItem.Profit = ManufacturingBlueprint.GetTotalComponentProfit
                                InsertItem.IPH = ManufacturingBlueprint.GetTotalIskperHourComponents
                                InsertItem.CalcType = "Components"
                                InsertItem.SVR = GetItemSVR(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration), ManufacturingBlueprint.GetProductionTime, ManufacturingBlueprint.GetTotalUnits)
                                If InsertItem.SVR = "-" Then
                                    InsertItem.SVRxIPH = "0.00"
                                Else
                                    InsertItem.SVRxIPH = FormatNumber(CType(InsertItem.SVR, Double) * InsertItem.IPH, 2)
                                End If
                                InsertItem.TotalCost = ManufacturingBlueprint.GetTotalComponentCost
                                InsertItem.Taxes = ManufacturingBlueprint.GetSalesTaxes
                                InsertItem.BrokerFees = ManufacturingBlueprint.GetSalesBrokerFees
                                InsertItem.SingleInventedBPCRunsperBPC = ManufacturingBlueprint.GetSingleInventedBPCRuns
                                InsertItem.BaseJobCost = ManufacturingBlueprint.GetBaseJobCost
                                InsertItem.JobFee = ManufacturingBlueprint.GetJobFee
                                InsertItem.NumBPs = ManufacturingBlueprint.GetUsedNumBPs
                                InsertItem.InventionChance = ManufacturingBlueprint.GetInventionChance
                                InsertItem.Race = GetRace(ManufacturingBlueprint.GetRaceID)
                                InsertItem.VolumeperItem = ManufacturingBlueprint.GetItemVolume
                                InsertItem.TotalVolume = ManufacturingBlueprint.GetTotalItemVolume

                                InsertItem.DivideUnits = 1
                                InsertItem.PortionSize = CInt(ManufacturingBlueprint.GetTotalUnits)

                                InsertItem.BPProductionTime = FormatIPHTime(ManufacturingBlueprint.GetProductionTime / InsertItem.DivideUnits)
                                InsertItem.TotalProductionTime = FormatIPHTime(ManufacturingBlueprint.GetProductionTime / InsertItem.DivideUnits) ' Total production time for components only is always the bp production time
                                InsertItem.CopyTime = FormatIPHTime(ManufacturingBlueprint.GetCopyTime / InsertItem.DivideUnits)
                                InsertItem.InventionTime = FormatIPHTime(ManufacturingBlueprint.GetInventionTime / InsertItem.DivideUnits)

                                If (ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 Or ManufacturingBlueprint.GetTechLevel = BPTechLevel.T3) _
                                    And (InsertItem.BlueprintType <> BPType.Original And InsertItem.BlueprintType <> BPType.Copy) Then
                                    InsertItem.InventionCost = ManufacturingBlueprint.GetInventionCost
                                Else
                                    InsertItem.InventionCost = 0
                                End If

                                If ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 Then
                                    InsertItem.CopyCost = ManufacturingBlueprint.GetCopyCost
                                Else
                                    InsertItem.CopyCost = 0
                                End If

                                ' Usage
                                InsertItem.ManufacturingFacilityUsage = ManufacturingBlueprint.GetManufacturingFacilityUsage
                                ' Don't build components in this calculation
                                InsertItem.ComponentManufacturingFacilityUsage = 0
                                InsertItem.CapComponentManufacturingFacilityUsage = 0
                                InsertItem.CopyFacilityUsage = ManufacturingBlueprint.GetCopyUsage
                                InsertItem.InventionFacilityUsage = ManufacturingBlueprint.GetInventionUsage
                                ' Save the bp
                                InsertItem.Blueprint = ManufacturingBlueprint

                                InsertItem.RiskPrice = ManufacturingBlueprint.GetTotalRiskRawCost
                                InsertItem.RiskProfit = ManufacturingBlueprint.GetTotalRiskRawProfit
                                InsertItem.RiskIPH = ManufacturingBlueprint.GetTotalRiskIskperHourRaw

                                ' Insert Components Item
                                Call InsertManufacturingItem(InsertItem, SVRThresholdValue, True, ManufacturingList, ListRowFormats)

                            End If

                            ' *** Raw Mats - always add
                            InsertItem.ProfitPercent = ManufacturingBlueprint.GetTotalRawProfitPercent
                            InsertItem.Profit = ManufacturingBlueprint.GetTotalRawProfit
                            InsertItem.IPH = ManufacturingBlueprint.GetTotalIskperHourRaw
                            InsertItem.CalcType = "Raw Materials"
                            InsertItem.SVR = GetItemSVR(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration), ManufacturingBlueprint.GetTotalProductionTime, ManufacturingBlueprint.GetTotalUnits)
                            If InsertItem.SVR = "-" Then
                                InsertItem.SVRxIPH = "0.00"
                            Else
                                InsertItem.SVRxIPH = FormatNumber(CType(InsertItem.SVR, Double) * InsertItem.IPH, 2)
                            End If
                            InsertItem.TotalCost = ManufacturingBlueprint.GetTotalRawCost
                            InsertItem.Taxes = ManufacturingBlueprint.GetSalesTaxes
                            InsertItem.BrokerFees = ManufacturingBlueprint.GetSalesBrokerFees
                            InsertItem.SingleInventedBPCRunsperBPC = ManufacturingBlueprint.GetSingleInventedBPCRuns
                            InsertItem.BaseJobCost = ManufacturingBlueprint.GetBaseJobCost
                            InsertItem.JobFee = ManufacturingBlueprint.GetJobFee
                            InsertItem.NumBPs = ManufacturingBlueprint.GetUsedNumBPs
                            InsertItem.InventionChance = ManufacturingBlueprint.GetInventionChance
                            InsertItem.Race = GetRace(ManufacturingBlueprint.GetRaceID)
                            InsertItem.VolumeperItem = ManufacturingBlueprint.GetItemVolume
                            InsertItem.TotalVolume = ManufacturingBlueprint.GetTotalItemVolume

                            InsertItem.DivideUnits = CInt(ManufacturingBlueprint.GetTotalUnits)
                            InsertItem.PortionSize = 1

                            InsertItem.BPProductionTime = FormatIPHTime(ManufacturingBlueprint.GetProductionTime / InsertItem.DivideUnits)
                            InsertItem.TotalProductionTime = FormatIPHTime(ManufacturingBlueprint.GetTotalProductionTime / InsertItem.DivideUnits)
                            InsertItem.CopyTime = FormatIPHTime(ManufacturingBlueprint.GetCopyTime / InsertItem.DivideUnits)
                            InsertItem.InventionTime = FormatIPHTime(ManufacturingBlueprint.GetInventionTime / InsertItem.DivideUnits)

                            If (ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 Or ManufacturingBlueprint.GetTechLevel = BPTechLevel.T3) _
                                    And (InsertItem.BlueprintType <> BPType.Original And InsertItem.BlueprintType <> BPType.Copy) Then
                                InsertItem.InventionCost = ManufacturingBlueprint.GetInventionCost
                            Else
                                InsertItem.InventionCost = 0
                            End If

                            If ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 And InsertItem.BlueprintType <> BPType.Original Then
                                InsertItem.CopyCost = ManufacturingBlueprint.GetCopyCost
                            Else
                                InsertItem.CopyCost = 0
                            End If

                            ' Usage
                            InsertItem.ManufacturingFacilityUsage = ManufacturingBlueprint.GetManufacturingFacilityUsage
                            InsertItem.ComponentManufacturingFacilityUsage = ManufacturingBlueprint.GetComponentFacilityUsage
                            InsertItem.CapComponentManufacturingFacilityUsage = ManufacturingBlueprint.GetCapComponentFacilityUsage
                            InsertItem.ReactionFacilityUsage = ManufacturingBlueprint.GetTotalReactionFacilityUsage
                            InsertItem.CopyFacilityUsage = ManufacturingBlueprint.GetCopyUsage
                            InsertItem.InventionFacilityUsage = ManufacturingBlueprint.GetInventionUsage

                            ' Save the bp
                            InsertItem.Blueprint = ManufacturingBlueprint

                            InsertItem.RiskPrice = ManufacturingBlueprint.GetTotalRiskRawCost
                            InsertItem.RiskProfit = ManufacturingBlueprint.GetTotalRiskRawProfit
                            InsertItem.RiskIPH = ManufacturingBlueprint.GetTotalRiskIskperHourRaw

                            ' Insert Raw Mats item
                            Call InsertManufacturingItem(InsertItem, SVRThresholdValue, True, ManufacturingList, ListRowFormats)

                            ' *** For Build/Buy we need to construct a new BP and add that
                            ' Construct the BP
                            ManufacturingBlueprint = New Blueprint(InsertItem.BPID, CInt(txtCalcRuns.Text), InsertItem.BPME, InsertItem.BPTE,
                                                        NumberofBlueprints, CInt(txtCalcProdLines.Text), SelectedCharacter,
                                                        UserApplicationSettings, True, InsertItem.AddlCosts, InsertItem.ManufacturingFacility,
                                                        InsertItem.ComponentManufacturingFacility, InsertItem.CapComponentManufacturingFacility,
                                                        InsertItem.ReactionFacility, False, UserManufacturingTabSettings.BuildT2T3Materials, True)

                            If ((InsertItem.TechLevel = "T2" Or InsertItem.TechLevel = "T3") And InsertItem.BlueprintType = BPType.InventedBPC) Then
                                ' Construct the T2/T3 BP
                                ManufacturingBlueprint.InventBlueprint(CInt(txtCalcLabLines.Text), SelectedDecryptor, InsertItem.InventionFacility,
                                                                       InsertItem.CopyFacility, GetInventItemTypeID(InsertItem.BPID, InsertItem.Relic))

                            End If

                            ' Get the list of materials
                            Call ManufacturingBlueprint.BuildItems(True, GetBrokerFeeData(), False, False, False)

                            ' Build/Buy (add only if it has components we build)
                            If ManufacturingBlueprint.HasComponents Then
                                InsertItem.ProfitPercent = ManufacturingBlueprint.GetTotalRawProfitPercent
                                InsertItem.Profit = ManufacturingBlueprint.GetTotalRawProfit
                                InsertItem.IPH = ManufacturingBlueprint.GetTotalIskperHourRaw
                                InsertItem.CalcType = "Build/Buy"
                                InsertItem.SVR = GetItemSVR(InsertItem.ItemTypeID, MarketRegionID, CInt(UserApplicationSettings.SVRAveragePriceDuration), ManufacturingBlueprint.GetTotalProductionTime, ManufacturingBlueprint.GetTotalUnits)
                                If InsertItem.SVR = "-" Then
                                    InsertItem.SVRxIPH = "0.00"
                                Else
                                    InsertItem.SVRxIPH = FormatNumber(CType(InsertItem.SVR, Double) * InsertItem.IPH, 2)
                                End If
                                InsertItem.TotalCost = ManufacturingBlueprint.GetTotalRawCost
                                InsertItem.Taxes = ManufacturingBlueprint.GetSalesTaxes
                                InsertItem.BrokerFees = ManufacturingBlueprint.GetSalesBrokerFees
                                InsertItem.SingleInventedBPCRunsperBPC = ManufacturingBlueprint.GetSingleInventedBPCRuns
                                InsertItem.BaseJobCost = ManufacturingBlueprint.GetBaseJobCost
                                InsertItem.JobFee = ManufacturingBlueprint.GetJobFee
                                InsertItem.NumBPs = ManufacturingBlueprint.GetUsedNumBPs
                                InsertItem.InventionChance = ManufacturingBlueprint.GetInventionChance
                                InsertItem.Race = GetRace(ManufacturingBlueprint.GetRaceID)
                                InsertItem.VolumeperItem = ManufacturingBlueprint.GetItemVolume
                                InsertItem.TotalVolume = ManufacturingBlueprint.GetTotalItemVolume

                                InsertItem.DivideUnits = CInt(ManufacturingBlueprint.GetTotalUnits)
                                InsertItem.PortionSize = 1

                                InsertItem.BPProductionTime = FormatIPHTime(ManufacturingBlueprint.GetProductionTime / InsertItem.DivideUnits)
                                InsertItem.TotalProductionTime = FormatIPHTime(ManufacturingBlueprint.GetTotalProductionTime / InsertItem.DivideUnits)
                                InsertItem.CopyTime = FormatIPHTime(ManufacturingBlueprint.GetCopyTime / InsertItem.DivideUnits)
                                InsertItem.InventionTime = FormatIPHTime(ManufacturingBlueprint.GetInventionTime / InsertItem.DivideUnits)

                                If (ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 Or ManufacturingBlueprint.GetTechLevel = BPTechLevel.T3) _
                                    And (InsertItem.BlueprintType <> BPType.Original And InsertItem.BlueprintType <> BPType.Copy) Then
                                    InsertItem.InventionCost = ManufacturingBlueprint.GetInventionCost
                                Else
                                    InsertItem.InventionCost = 0
                                End If

                                If ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 And InsertItem.BlueprintType <> BPType.Original Then
                                    InsertItem.CopyCost = ManufacturingBlueprint.GetCopyCost
                                Else
                                    InsertItem.CopyCost = 0
                                End If

                                ' Usage
                                InsertItem.ManufacturingFacilityUsage = ManufacturingBlueprint.GetManufacturingFacilityUsage
                                InsertItem.ComponentManufacturingFacilityUsage = ManufacturingBlueprint.GetComponentFacilityUsage
                                InsertItem.CapComponentManufacturingFacilityUsage = ManufacturingBlueprint.GetCapComponentFacilityUsage
                                InsertItem.ReactionFacilityUsage = ManufacturingBlueprint.GetReactionFacilityUsage
                                InsertItem.CopyFacilityUsage = ManufacturingBlueprint.GetCopyUsage
                                InsertItem.InventionFacilityUsage = ManufacturingBlueprint.GetInventionUsage

                                ' Save the bp
                                InsertItem.Blueprint = ManufacturingBlueprint

                                InsertItem.RiskPrice = ManufacturingBlueprint.GetTotalRiskRawCost
                                InsertItem.RiskProfit = ManufacturingBlueprint.GetTotalRiskRawProfit
                                InsertItem.RiskIPH = ManufacturingBlueprint.GetTotalRiskIskperHourRaw

                                ' Insert Build/Buy item
                                Call InsertManufacturingItem(InsertItem, SVRThresholdValue, True, ManufacturingList, ListRowFormats)

                            End If
                        Else

                            InsertItem.Taxes = ManufacturingBlueprint.GetSalesTaxes
                            InsertItem.BrokerFees = ManufacturingBlueprint.GetSalesBrokerFees
                            InsertItem.SingleInventedBPCRunsperBPC = ManufacturingBlueprint.GetSingleInventedBPCRuns
                            InsertItem.BaseJobCost = ManufacturingBlueprint.GetBaseJobCost
                            InsertItem.JobFee = ManufacturingBlueprint.GetJobFee
                            InsertItem.NumBPs = ManufacturingBlueprint.GetUsedNumBPs
                            InsertItem.InventionChance = ManufacturingBlueprint.GetInventionChance
                            InsertItem.Race = GetRace(ManufacturingBlueprint.GetRaceID)
                            InsertItem.VolumeperItem = ManufacturingBlueprint.GetItemVolume
                            InsertItem.TotalVolume = ManufacturingBlueprint.GetTotalItemVolume

                            InsertItem.DivideUnits = 1
                            InsertItem.PortionSize = CInt(ManufacturingBlueprint.GetTotalUnits)

                            InsertItem.BPProductionTime = FormatIPHTime(ManufacturingBlueprint.GetProductionTime / InsertItem.DivideUnits)
                            InsertItem.TotalProductionTime = FormatIPHTime(ManufacturingBlueprint.GetTotalProductionTime / InsertItem.DivideUnits)

                            InsertItem.CopyTime = FormatIPHTime(ManufacturingBlueprint.GetCopyTime / InsertItem.DivideUnits)
                            InsertItem.InventionTime = FormatIPHTime(ManufacturingBlueprint.GetInventionTime / InsertItem.DivideUnits)

                            If (ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 Or ManufacturingBlueprint.GetTechLevel = BPTechLevel.T3) _
                                    And (InsertItem.BlueprintType <> BPType.Original And InsertItem.BlueprintType <> BPType.Copy) Then
                                InsertItem.InventionCost = ManufacturingBlueprint.GetInventionCost
                            Else
                                InsertItem.InventionCost = 0
                            End If

                            If ManufacturingBlueprint.GetTechLevel = BPTechLevel.T2 And InsertItem.BlueprintType <> BPType.Original Then
                                InsertItem.CopyCost = ManufacturingBlueprint.GetCopyCost
                            Else
                                InsertItem.CopyCost = 0
                            End If

                            ' Usage
                            ' If it's a reaction, we don't want to add the manufacturing usage for any fuel blocks if it's a component
                            Select Case InsertItem.ItemGroupID
                                Case ItemIDs.ReactionsIntermediateGroupID, ItemIDs.ReactionCompositesGroupID, ItemIDs.ReactionPolymersGroupID, ItemIDs.ReactionBiochmeicalsGroupID
                                    InsertItem.ManufacturingFacilityUsage = 0
                                Case Else
                                    InsertItem.ManufacturingFacilityUsage = ManufacturingBlueprint.GetManufacturingFacilityUsage
                            End Select
                            InsertItem.ComponentManufacturingFacilityUsage = ManufacturingBlueprint.GetComponentFacilityUsage
                            InsertItem.CapComponentManufacturingFacilityUsage = ManufacturingBlueprint.GetCapComponentFacilityUsage
                            InsertItem.ReactionFacilityUsage = ManufacturingBlueprint.GetReactionFacilityUsage
                            InsertItem.CopyFacilityUsage = ManufacturingBlueprint.GetCopyUsage
                            InsertItem.InventionFacilityUsage = ManufacturingBlueprint.GetInventionUsage

                            ' Save the bp
                            InsertItem.Blueprint = ManufacturingBlueprint

                            InsertItem.RiskPrice = ManufacturingBlueprint.GetTotalRiskRawCost
                            InsertItem.RiskProfit = ManufacturingBlueprint.GetTotalRiskRawProfit
                            InsertItem.RiskIPH = ManufacturingBlueprint.GetTotalRiskIskperHourRaw

                            ' Insert the chosen item
                            Call InsertManufacturingItem(InsertItem, SVRThresholdValue, True, ManufacturingList, ListRowFormats)

                        End If

                    End If

                    ' For each record, update the progress bar
                    Call IncrementToolStripProgressBar(MetroProgressBar)

                Next

                'Once the blue prints have all been processed, calculate the score for each blueprint
                CalculateScore(ManufacturingList)

                ' Done processing the blueprints
                MetroProgressBar.Value = 0
                MetroProgressBar.Visible = False
                Cursor.Current = Cursors.Default
                pnlStatus.Text = ""

                ' BPs were calcualted so enable it
                AddToShoppingListToolStripMenuItem.Enabled = True

            End If

        End If

        ' **********************************************************************
        ' *** Display results in grid - use for both calcuations and preview ***
        ' **********************************************************************
DisplayResults:

        ' Reset the columns before processing data
        Call RefreshManufacturingTabColumns()

        Dim NumManufacturingItems As Integer

        ' If no records first, then don't let them try and refresh nothing
        If IsNothing(FinalManufacturingItemList) And SavedRefreshValue Then
            Exit Sub
        End If

        If Not SavedRefreshValue Then
            ' Calc or new display data
            NumManufacturingItems = ManufacturingList.Count

            If NumManufacturingItems = 0 Then
                If Not Calculate Then
                    FinalManufacturingItemList = BaseItems ' Save for later use, this was just display
                Else
                    FinalManufacturingItemList = Nothing ' It didn't calculate anything, so just clear the grid and exit
                    lstManufacturing.Items.Clear()
                    GoTo ExitCalc
                End If
            Else
                ' Use Current data lists and save
                FinalManufacturingItemList = ManufacturingList
            End If
        Else
            ' Use pre-calc'd or loaded list
            NumManufacturingItems = FinalManufacturingItemList.Count
        End If

        ' Remove only but the optimal decryptor items before final display, and set the final list
        FinalItemList = SetOptimalDecryptorList(FinalManufacturingItemList, OptimalDecryptorItems)

        MetroProgressBar.Minimum = 0
        MetroProgressBar.Maximum = FinalItemList.Count
        MetroProgressBar.Value = 0
        MetroProgressBar.Visible = True

        lstManufacturing.Items.Clear()
        lstManufacturing.BeginUpdate()
        ' Disable sorting because it will crawl after we update if there are too many records
        lstManufacturing.ListViewItemSorter = Nothing
        lstManufacturing.SmallImageList = CalcImageList
        ' Set the formats before drawing
        lstManufacturing.SetRowFormats(ListRowFormats)

        pnlStatus.Text = "Refreshing List..."

        Dim BonusString As String = ""

        ' Load the final grid
        For i = 0 To FinalItemList.Count - 1
            Application.DoEvents()

            BPList = New ListViewItem(CStr(FinalItemList(i).ListID)) ' Always the first item

            If FinalItemList(i).DivideUnits = 0 Then
                ' So the display will show zeros instead of NaN (divide by zero)
                FinalItemList(i).DivideUnits = 1
            End If

            ' If the bp is a blueprint, change the reaction facility equal to the manufacturing facility (used in bp)
            ' and the manufacturing facility equal to the component facility
            Select Case FinalItemList(i).ItemGroup
                Case "Composite", "Biochemical Material", "Hybrid Polymers", "Intermediate Materials"
                    FinalItemList(i).ReactionFacility = CType(FinalItemList(i).ManufacturingFacility.Clone, IndustryFacility)
                    FinalItemList(i).ManufacturingFacility = CType(FinalItemList(i).ComponentManufacturingFacility.Clone, IndustryFacility) ' fuel blocks
            End Select

            For j = 1 To ColumnPositions.Count - 1
                Select Case ColumnPositions(j)
                    Case ProgramSettings.ItemCategoryColumnName
                        BPList.SubItems.Add(FinalItemList(i).ItemCategory)
                    Case ProgramSettings.ItemGroupColumnName
                        BPList.SubItems.Add(FinalItemList(i).ItemGroup)
                    Case ProgramSettings.ItemNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).ItemName)
                    Case ProgramSettings.OwnedColumnName
                        BPList.SubItems.Add(FinalItemList(i).Owned)
                    Case ProgramSettings.TechColumnName
                        BPList.SubItems.Add(FinalItemList(i).TechLevel)
                    Case ProgramSettings.BPMEColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).BPME))
                    Case ProgramSettings.BPTEColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).BPTE))
                    Case ProgramSettings.InputsColumnName
                        BPList.SubItems.Add(FinalItemList(i).Inputs)
                    Case ProgramSettings.ComparedColumnName
                        BPList.SubItems.Add(FinalItemList(i).CalcType)
                    Case ProgramSettings.TotalRunsColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).Runs))
                    Case ProgramSettings.SingleInventedBPCRunsColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).SingleInventedBPCRunsperBPC))
                    Case ProgramSettings.ProductionLinesColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ProductionLines))
                    Case ProgramSettings.LaboratoryLinesColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).LaboratoryLines))
                    Case ProgramSettings.TotalInventionCostColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).InventionCost / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.TotalCopyCostColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CopyCost / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.TaxesColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).Taxes / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.BrokerFeesColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).BrokerFees / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.BPProductionTimeColumnName
                        BPList.SubItems.Add(FinalItemList(i).BPProductionTime)
                    Case ProgramSettings.TotalProductionTimeColumnName
                        BPList.SubItems.Add(FinalItemList(i).TotalProductionTime)
                    Case ProgramSettings.CopyTimeColumnName
                        BPList.SubItems.Add(FinalItemList(i).CopyTime)
                    Case ProgramSettings.InventionTimeColumnName
                        BPList.SubItems.Add(FinalItemList(i).InventionTime)
                    Case ProgramSettings.ItemMarketPriceColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ItemMarketPrice / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.ProfitColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).Profit / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.ProfitPercentageColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).ProfitPercent, 2))
                    Case ProgramSettings.IskperHourColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).IPH, 2))
                    Case ProgramSettings.SVRColumnName
                        BPList.SubItems.Add(FinalItemList(i).SVR)
                    Case ProgramSettings.SVRxIPHColumnName
                        BPList.SubItems.Add(FinalItemList(i).SVRxIPH)
                    Case ProgramSettings.ScoreColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).Score, 3))
                    Case ProgramSettings.RiskProfitColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).RiskProfit, 2))
                    Case ProgramSettings.RiskIPHColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).RiskIPH, 2))
                    Case ProgramSettings.RiskPriceColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).RiskPrice, 2))
                    Case ProgramSettings.VolatilityColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).Volatility, 3))
                    Case ProgramSettings.PriceTrendColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).PriceTrend, 2))
                    Case ProgramSettings.TotalItemsSoldColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).TotalItemsSold, 0))
                    Case ProgramSettings.TotalOrdersFilledColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).TotalOrdersFilled, 0))
                    Case ProgramSettings.AvgItemsperOrderColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).AvgItemsperOrder, 2))
                    Case ProgramSettings.CurrentSellOrdersColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CurrentSellOrders, 0))
                    Case ProgramSettings.CurrentBuyOrdersColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CurrentBuyOrders, 0))
                    Case ProgramSettings.ItemsinStockColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ItemsinStock, 0))
                    Case ProgramSettings.ItemsinProductionColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ItemsinProduction, 0))
                    Case ProgramSettings.TotalCostColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).TotalCost / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.BaseJobCostColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).BaseJobCost / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.NumBPsColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).NumBPs))
                    Case ProgramSettings.InventionChanceColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).InventionChance, 2))
                    Case ProgramSettings.BPTypeColumnName
                        BPList.SubItems.Add(GetBPTypeString(FinalItemList(i).BlueprintType))
                    Case ProgramSettings.RaceColumnName
                        BPList.SubItems.Add(FinalItemList(i).Race)
                    Case ProgramSettings.VolumeperItemColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).VolumeperItem, 2))
                    Case ProgramSettings.TotalVolumeColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).TotalVolume / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.PortionSizeColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).PortionSize, 0))

                    Case ProgramSettings.ManufacturingJobFeeColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).JobFee / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.ManufacturingFacilityNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).ManufacturingFacility.FacilityName)
                    Case ProgramSettings.ManufacturingFacilitySystemColumnName
                        BPList.SubItems.Add(FinalItemList(i).ManufacturingFacility.SolarSystemName)
                    Case ProgramSettings.ManufacturingFacilitySystemIndexColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ManufacturingFacility.CostIndex, 5))
                    Case ProgramSettings.ManufacturingFacilityTaxColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).ManufacturingFacility.TaxRate, 1))
                    Case ProgramSettings.ManufacturingFacilityRegionColumnName
                        BPList.SubItems.Add(FinalItemList(i).ManufacturingFacility.RegionName)
                    Case ProgramSettings.ManufacturingFacilityMEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ManufacturingFacility.MaterialMultiplier))
                    Case ProgramSettings.ManufacturingFacilityTEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ManufacturingFacility.TimeMultiplier))
                    Case ProgramSettings.ManufacturingFacilityUsageColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ManufacturingFacilityUsage / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.ManufacturingFacilityFWSystemLevelColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ManufacturingFacility.FWUpgradeLevel))

                    Case ProgramSettings.ComponentFacilityNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).ComponentManufacturingFacility.FacilityName)
                    Case ProgramSettings.ComponentFacilitySystemColumnName
                        BPList.SubItems.Add(FinalItemList(i).ComponentManufacturingFacility.SolarSystemName)
                    Case ProgramSettings.ComponentFacilitySystemIndexColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ComponentManufacturingFacility.CostIndex, 5))
                    Case ProgramSettings.ComponentFacilityTaxColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).ComponentManufacturingFacility.TaxRate, 1))
                    Case ProgramSettings.ComponentFacilityRegionColumnName
                        BPList.SubItems.Add(FinalItemList(i).ComponentManufacturingFacility.RegionName)
                    Case ProgramSettings.ComponentFacilityMEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ComponentManufacturingFacility.MaterialMultiplier))
                    Case ProgramSettings.ComponentFacilityTEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ComponentManufacturingFacility.TimeMultiplier))
                    Case ProgramSettings.ComponentFacilityUsageColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ComponentManufacturingFacilityUsage / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.ComponentFacilityFWSystemLevelColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ComponentManufacturingFacility.FWUpgradeLevel))

                    Case ProgramSettings.CapComponentFacilityNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).CapComponentManufacturingFacility.FacilityName)
                    Case ProgramSettings.CapComponentFacilitySystemColumnName
                        BPList.SubItems.Add(FinalItemList(i).CapComponentManufacturingFacility.SolarSystemName)
                    Case ProgramSettings.CapComponentFacilitySystemIndexColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CapComponentManufacturingFacility.CostIndex, 5))
                    Case ProgramSettings.CapComponentFacilityTaxColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).CapComponentManufacturingFacility.TaxRate, 1))
                    Case ProgramSettings.CapComponentFacilityRegionColumnName
                        BPList.SubItems.Add(FinalItemList(i).CapComponentManufacturingFacility.RegionName)
                    Case ProgramSettings.CapComponentFacilityMEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).CapComponentManufacturingFacility.MaterialMultiplier))
                    Case ProgramSettings.CapComponentFacilityTEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).CapComponentManufacturingFacility.TimeMultiplier))
                    Case ProgramSettings.CapComponentFacilityUsageColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CapComponentManufacturingFacilityUsage / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.CapComponentFacilityFWSystemLevelColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).CapComponentManufacturingFacility.FWUpgradeLevel))

                    Case ProgramSettings.CopyingFacilityNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).CopyFacility.FacilityName)
                    Case ProgramSettings.CopyingFacilitySystemColumnName
                        BPList.SubItems.Add(FinalItemList(i).CopyFacility.SolarSystemName)
                    Case ProgramSettings.CopyingFacilitySystemIndexColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CopyFacility.CostIndex, 5))
                    Case ProgramSettings.CopyingFacilityTaxColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).CopyFacility.TaxRate, 1))
                    Case ProgramSettings.CopyingFacilityRegionColumnName
                        BPList.SubItems.Add(FinalItemList(i).CopyFacility.RegionName)
                    Case ProgramSettings.CopyingFacilityMEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).CopyFacility.MaterialMultiplier))
                    Case ProgramSettings.CopyingFacilityTEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).CopyFacility.TimeMultiplier))
                    Case ProgramSettings.CopyingFacilityUsageColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).CopyFacilityUsage / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.CopyingFacilityFWSystemLevelColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).CopyFacility.FWUpgradeLevel))

                    Case ProgramSettings.InventionFacilityNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).InventionFacility.FacilityName)
                    Case ProgramSettings.InventionFacilitySystemColumnName
                        BPList.SubItems.Add(FinalItemList(i).InventionFacility.SolarSystemName)
                    Case ProgramSettings.InventionFacilitySystemIndexColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).InventionFacility.CostIndex, 5))
                    Case ProgramSettings.InventionFacilityTaxColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).InventionFacility.TaxRate, 1))
                    Case ProgramSettings.InventionFacilityRegionColumnName
                        BPList.SubItems.Add(FinalItemList(i).InventionFacility.RegionName)
                    Case ProgramSettings.InventionFacilityMEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).InventionFacility.MaterialMultiplier))
                    Case ProgramSettings.InventionFacilityTEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).InventionFacility.TimeMultiplier))
                    Case ProgramSettings.InventionFacilityUsageColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).InventionFacilityUsage / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.InventionFacilityFWSystemLevelColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).InventionFacility.FWUpgradeLevel))

                    Case ProgramSettings.ReactionFacilityNameColumnName
                        BPList.SubItems.Add(FinalItemList(i).ReactionFacility.FacilityName)
                    Case ProgramSettings.ReactionFacilitySystemColumnName
                        BPList.SubItems.Add(FinalItemList(i).ReactionFacility.SolarSystemName)
                    Case ProgramSettings.ReactionFacilitySystemIndexColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ReactionFacility.CostIndex, 5))
                    Case ProgramSettings.ReactionFacilityTaxColumnName
                        BPList.SubItems.Add(FormatPercent(FinalItemList(i).ReactionFacility.TaxRate, 1))
                    Case ProgramSettings.ReactionFacilityRegionColumnName
                        BPList.SubItems.Add(FinalItemList(i).ReactionFacility.RegionName)
                    Case ProgramSettings.ReactionFacilityMEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ReactionFacility.MaterialMultiplier))
                    Case ProgramSettings.ReactionFacilityTEBonusColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ReactionFacility.TimeMultiplier))
                    Case ProgramSettings.ReactionFacilityUsageColumnName
                        BPList.SubItems.Add(FormatNumber(FinalItemList(i).ReactionFacilityUsage / FinalItemList(i).DivideUnits, 2))
                    Case ProgramSettings.ReactionFacilityFWSystemLevelColumnName
                        BPList.SubItems.Add(CStr(FinalItemList(i).ReactionFacility.FWUpgradeLevel))
                End Select
            Next

            ' Add the record
            Call lstManufacturing.Items.Add(BPList)

            ' For each record, update the progress bar
            Call IncrementToolStripProgressBar(MetroProgressBar)

        Next

        Dim TempType As SortOrder

        ' Now sort this
        If ManufacturingColumnSortType = SortOrder.Ascending Then
            TempType = SortOrder.Descending
        Else
            TempType = SortOrder.Ascending
        End If

        ' Sort the list based on the saved column, if they change the number of columns below value, then find IPH, if not there, use column 0
        If ManufacturingColumnClicked > lstManufacturing.Columns.Count Then
            ' Find the IPH column
            If UserManufacturingTabColumnSettings.IskperHour <> 0 Then
                ManufacturingColumnClicked = UserManufacturingTabColumnSettings.IskperHour
            Else
                ManufacturingColumnClicked = 0 ' Default, will always be there
            End If

        End If

        ' Sort away
        Call ListViewColumnSorter(ManufacturingColumnClicked, CType(lstManufacturing, ListView), ManufacturingColumnClicked, TempType)

        lstManufacturing.EndUpdate()

ExitCalc:
        MetroProgressBar.Value = 0
        MetroProgressBar.Visible = False
        pnlStatus.Text = ""
        lstManufacturing.EndUpdate()

        ' Enable all the controls
        btnCalcSelectColumns.Enabled = True
        gbCalcBPSelect.Enabled = True
        gbCalcProdLines.Enabled = True
        gbCalcTextColors.Enabled = True
        lstManufacturing.Enabled = True

        Application.UseWaitCursor = False
        Cursor.Current = Cursors.Default

        Application.DoEvents()

        If lstManufacturing.Items.Count = 0 And Not CancelManufacturingTabCalc Then
            MsgBox("No Blueprints calculated for options selected.", vbExclamation, Application.ProductName)
        End If

        If Not Calculate Or CancelManufacturingTabCalc Then
            Call ResetRefresh()
            CancelManufacturingTabCalc = False
        Else
            btnCalcCalculate.Text = "Refresh"
            RefreshCalcData = True ' Allow data to be refreshed since we just calcuated
        End If

    End Sub

    ' Finds the total items sold over the time period for the region sent
    Private Function CalculateTotalItemsSold(ByVal TypeID As Long, ByVal RegionID As Long, DaysfromToday As Integer) As Long
        Dim SQL As String
        Dim rsItems As SQLiteDataReader

        SQL = "SELECT SUM(TOTAL_VOLUME_FILLED) FROM MARKET_HISTORY WHERE TYPE_ID = " & CStr(TypeID) & " AND REGION_ID = " & CStr(RegionID) & " "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) >= " & " DateTime('" & Format(DateAdd(DateInterval.Day, -(DaysfromToday + 1), Date.UtcNow.Date), SQLiteDateFormat) & "') "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) < " & " DateTime('" & Format(Date.UtcNow.Date, SQLiteDateFormat) & "') "
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsItems = DBCommand.ExecuteReader

        If rsItems.Read() And Not IsDBNull(rsItems.GetValue(0)) Then
            Return rsItems.GetInt64(0)
        Else
            Return 0
        End If

    End Function

    ' Finds the total orders filled over the time period for the region sent
    Private Function CalculateTotalOrdersFilled(ByVal TypeID As Long, ByVal RegionID As Long, DaysfromToday As Integer) As Long
        Dim SQL As String
        Dim rsItems As SQLiteDataReader

        SQL = "SELECT SUM(TOTAL_ORDERS_FILLED) FROM MARKET_HISTORY WHERE TYPE_ID = " & CStr(TypeID) & " AND REGION_ID = " & CStr(RegionID) & " "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) >= " & " DateTime('" & Format(DateAdd(DateInterval.Day, -(DaysfromToday + 1), Date.UtcNow.Date), SQLiteDateFormat) & "') "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) < " & " DateTime('" & Format(Date.UtcNow.Date, SQLiteDateFormat) & "') "
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsItems = DBCommand.ExecuteReader

        If rsItems.Read() And Not IsDBNull(rsItems.GetValue(0)) Then
            Return rsItems.GetInt64(0)
        Else
            Return 0
        End If

    End Function

    ' Finds the average items sold per order over the time period for the region sent, and sets the two by reference
    Private Sub GetCurrentOrders(ByVal TypeID As Long, ByVal RegionID As Long, ByRef BuyOrders As Long, ByRef SellOrders As Long)
        Dim SQL As String
        Dim rsItems As SQLiteDataReader

        SQL = "SELECT IS_BUY_ORDER, SUM(VOLUME_REMAINING) FROM (SELECT * FROM MARKET_ORDERS UNION ALL SELECT * FROM STRUCTURE_MARKET_ORDERS) "
        SQL &= "WHERE TYPE_ID = " & CStr(TypeID) & " And REGION_ID = " & CStr(RegionID) & " "
        SQL = SQL & "GROUP BY IS_BUY_ORDER"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsItems = DBCommand.ExecuteReader

        While rsItems.Read
            If rsItems.GetInt32(0) = 0 Then
                SellOrders = rsItems.GetInt64(1)
            Else
                BuyOrders = rsItems.GetInt64(1)
            End If
        End While

    End Sub

    ' Finds the number of items in stock for the asset settings set here
    Private Function GetTotalItemsinStock(ByVal TypeID As Long) As Integer
        Dim SQL As String
        Dim readerAssets As SQLiteDataReader
        Dim CurrentItemName As String = ""
        Dim ItemQuantity As Integer = 0

        Application.UseWaitCursor = True
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()

        Dim IDString As String = ""

        ' Set the ID string we will use to update
        If UserAssetWindowShoppingListSettings.AssetType = "Both" Then
            IDString = CStr(SelectedCharacter.ID) & "," & CStr(SelectedCharacter.CharacterCorporation.CorporationID)
        ElseIf UserAssetWindowShoppingListSettings.AssetType = "Personal" Then
            IDString = CStr(SelectedCharacter.ID)
        ElseIf UserAssetWindowShoppingListSettings.AssetType = "Corporation" Then
            IDString = CStr(SelectedCharacter.CharacterCorporation.CorporationID)
        End If

        ' Build the where clause to look up data
        Dim AssetLocationFlagList As New List(Of String)
        ' First look up the location and flagID pairs - unique ID of asset locations
        SQL = "SELECT LocationID, FlagID FROM ASSET_LOCATIONS WHERE EnumAssetType = " & CStr(AssetWindow.ManufacturingTab) & " And ID IN (" & IDString & ")"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerAssets = DBCommand.ExecuteReader

        While readerAssets.Read
            If readerAssets.GetInt32(1) = -4 Then
                ' If the flag is the base location, then we want all items at the location id
                AssetLocationFlagList.Add("(LocationID = " & CStr(readerAssets.GetInt64(0)) & ")")
            Else
                AssetLocationFlagList.Add("(LocationID = " & CStr(readerAssets.GetInt64(0)) & " And Flag = " & CStr(readerAssets.GetInt32(1)) & ")")
            End If
        End While

        readerAssets.Close()

        ' Look up each item in their assets in their locations stored, and sum up the quantity'
        ' Split into groups to run (1000 identifiers max so limit to 900)
        Dim Splits As Integer = CInt(Math.Ceiling(AssetLocationFlagList.Count / 900))
        For k = 0 To Splits - 1
            Application.DoEvents()
            Dim TempAssetWhereList As String = ""
            ' Build the partial asset location id/flag list
            For z = k * 900 To (k + 1) * 900 - 1
                If z = AssetLocationFlagList.Count Then
                    ' exit if we get to the end of the list
                    Exit For
                End If
                TempAssetWhereList = TempAssetWhereList & AssetLocationFlagList(z) & " Or "
            Next

            ' Strip final OR
            TempAssetWhereList = TempAssetWhereList.Substring(0, Len(TempAssetWhereList) - 4)

            SQL = "SELECT SUM(Quantity) FROM ASSETS WHERE (" & TempAssetWhereList & ") "
            SQL = SQL & " And ASSETS.TypeID = " & CStr(TypeID) & " And ID IN (" & IDString & ")"

            DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            readerAssets = DBCommand.ExecuteReader
            readerAssets.Read()

            If readerAssets.HasRows And Not IsDBNull(readerAssets.GetValue(0)) Then
                ItemQuantity += readerAssets.GetInt32(0) ' sum up
            End If

        Next

        Return ItemQuantity

    End Function

    ' Finds the number of items in production from all loaded characters
    Private Function GetTotalItemsinProduction(ByVal TypeID As Long) As Integer
        Dim SQL As String
        Dim rsItems As SQLiteDataReader

        SQL = "SELECT SUM(runs * PORTION_SIZE) FROM INDUSTRY_JOBS, ALL_BLUEPRINTS WHERE INDUSTRY_JOBS.productTypeID = ALL_BLUEPRINTS.ITEM_ID "
        SQL = SQL & "And productTypeID = " & CStr(TypeID) & " And status = 'active' And activityID IN (1,11) "
        'SQL = SQL & "And installerID = " & CStr(SelectedCharacter.ID) & " "

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsItems = DBCommand.ExecuteReader

        If rsItems.Read() And Not IsDBNull(rsItems.GetValue(0)) Then
            Return rsItems.GetInt32(0)
        Else
            Return 0
        End If

    End Function

    ' Sets the name of the array to use on the pos for multiuse arrays
    Private Function GetCalcPOSMultiUseArrayName(ShortName As String) As String

        Select Case ShortName
            Case "Equipment"
                Return "Equipment Assembly Array"
            Case "Rapid"
                Return "Rapid Equipment Assembly Array"
            Case "Ammunition"
                Return "Ammunition Assembly Array"
            Case "Component"
                Return "Component Assembly Array"
            Case "Large"
                Return "Large Ship Assembly Array"
            Case "Capital"
                Return "Capital Ship Assembly Array"
            Case "All"
                Return "All"
        End Select

        Return ""

    End Function

    ' Sets the name of the array to the short name when long name sent
    Private Function GetTruncatedCalcPOSMultiUseArrayName(LongName As String) As String

        Select Case LongName
            Case "Equipment Assembly Array"
                Return "Equipment"
            Case "Rapid Equipment Assembly Array"
                Return "Rapid"
            Case "Ammunition Assembly Array"
                Return "Ammunition"
            Case "Component Assembly Array"
                Return "Component"
            Case "Large Ship Assembly Array"
                Return "Large"
            Case "Capital Ship Assembly Array"
                Return "Capital"
            Case "All"
                Return "All"
        End Select

        Return ""

    End Function

    ' Sets the owned flag for an insert item
    Private Function SetItemOwnedFlag(ByRef SentItem As ManufacturingItem, ByVal SentOrigDecryptor As Decryptor, ByVal SentOrigRelic As String,
                                 ByVal SentOrigME As Integer, ByVal SentOrigTE As Integer, ByVal SentOriginalBPOwnedFlag As Boolean) As Boolean
        ' We know the original decryptor and relic used for this bp so see if they match what we just 
        ' used and set the owned flag and it's invented, which all these are - also make sure the me/te are same
        ' as base if no decryptor used
        If SentItem.Decryptor.Name = SentOrigDecryptor.Name And SentOrigRelic.Contains(SentItem.Relic) _
            And SentOriginalBPOwnedFlag = True And SentItem.BlueprintType = BPType.InventedBPC _
            And Not (SentOrigDecryptor.Name = NoDecryptor.Name And SentOrigME <> BaseT2T3ME And SentOrigTE <> BaseT2T3TE) Then
            SentItem.Owned = Yes
            Return True
        Else
            SentItem.Owned = No
            Return False
        End If
    End Function

    ' Loads the cmbBPTypeFilter object with types based on the radio button selected - Ie, Drones will load Drone types (Small, Medium, Heavy...etc)
    Private Sub LoadCalcBPTypes()
        Dim SQL As String
        Dim WhereClause As String = ""
        Dim readerTypes As SQLiteDataReader
        Dim InventedBPs As New List(Of Long)

        SQL = "SELECT ITEM_GROUP FROM " & USER_BLUEPRINTS

        WhereClause = BuildManufactureWhereClause(True, InventedBPs)

        If WhereClause = "" Then
            ' They didn't select anything, just clear and exit
            Exit Sub
        End If

        ' See if we are looking at User Owned blueprints or All
        If rbtnCalcBPOwned.Checked Then
            WhereClause = WhereClause & "And USER_ID = " & SelectedCharacter.ID & " And OWNED <> 0  "
        End If

        SQL = SQL & WhereClause & "GROUP BY ITEM_GROUP"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        DBCommand.Parameters.AddWithValue("@USERBP_USERID", GetBPUserID(SelectedCharacter.ID)) ' need to search for corp ID too
        DBCommand.Parameters.AddWithValue("@USERBP_CORPID", CStr(SelectedCharacter.CharacterCorporation.CorporationID))
        readerTypes = DBCommand.ExecuteReader

    End Sub

    ' Just adds an item into the list and duplicates if raw or components checked
    Private Sub InsertItemCalcType(ByRef ManufacturingItemList As List(Of ManufacturingItem), ByVal BaseItem As ManufacturingItem,
                                   ByVal AddMultipleFacilities As Boolean, ByVal FacilityList As List(Of IndustryFacility), ByRef FormatList As List(Of RowFormat))

        Dim CalcType As String = ""
        Dim TempItem As New ManufacturingItem
        Dim CurrentRowFormat As New RowFormat

        If IsNothing(BaseItem.ReactionFacility) Then
            Application.DoEvents()
        End If

        CalcType = "All Calcs"

        If AddMultipleFacilities Then
            For i = 0 To FacilityList.Count - 1
                ' Set data
                TempItem = CType(BaseItem.Clone, ManufacturingItem)
                ListIDIterator += 1
                TempItem.ListID = ListIDIterator
                TempItem.ManufacturingFacility = CType(FacilityList(i).Clone(), IndustryFacility)
                TempItem.CalcType = CalcType
                ' Add it
                ManufacturingItemList.Add(TempItem)
                ' Reset the Item
                TempItem = New ManufacturingItem
            Next
        Else
            TempItem = CType(BaseItem.Clone, ManufacturingItem)
            ListIDIterator += 1
            TempItem.ListID = ListIDIterator
            TempItem.CalcType = CalcType

            ManufacturingItemList.Add(TempItem)
        End If

        ' Set the list row format for just display, after calcs it will reset
        ' Now determine the format of the item and save it for drawing the list
        CurrentRowFormat.ListID = TempItem.ListID

        'Set the row format for background and foreground colors
        'All columns need to be colored properly
        ' Color owned BP's
        If TempItem.Owned = Yes Then
            If TempItem.Scanned = 1 Or TempItem.Scanned = 0 Then
                CurrentRowFormat.BackColor = Brushes.BlanchedAlmond
            ElseIf TempItem.Scanned = 2 Then
                ' Corp owned
                CurrentRowFormat.BackColor = Brushes.LightGreen
            End If
        ElseIf UserInventedBPs.Contains(TempItem.BPID) Then
            ' It's an invented BP that we own the T1 BP for
            CurrentRowFormat.BackColor = Brushes.LightSteelBlue
        Else
            CurrentRowFormat.BackColor = Brushes.White
        End If

        ' Set default and change if needed
        CurrentRowFormat.ForeColor = Brushes.Black

        ' Insert the format
        FormatList.Add(CurrentRowFormat)

    End Sub

    ' Exports the list to clipboard
    Private Sub btnCalcExportList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MyStream As StreamWriter
        Dim FileName As String
        Dim OutputText As String
        Dim Price As ListViewItem
        Dim Separator As String = ""
        Dim Items As ListView.ListViewItemCollection
        Dim ExportColumns As New List(Of String)
        Dim NumItems As Integer = 0

        If UserApplicationSettings.DataExportFormat = SSVDataExport Then
            ' Save file name with date
            FileName = "Manufacturing Calculations Export - " & Format(Now, "MMddyyyy") & ".ssv"

            ' Show the dialog
            SaveFileDialog.Filter = "ssv files (*.ssv)|*.ssv|All files (*.*)|*.*"
            Separator = ";"
        Else ' All others in CSV for now
            ' Save file name with date
            FileName = "Manufacturing Calculations Export - " & Format(Now, "MMddyyyy") & ".csv"

            ' Show the dialog
            SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
            Separator = ","
        End If

        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.RestoreDirectory = True
        SaveFileDialog.FileName = FileName

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                MyStream = File.CreateText(SaveFileDialog.FileName)

                If Not (MyStream Is Nothing) Then

                    Items = lstManufacturing.Items

                    If Items.Count > 0 Then
                        Cursor.Current = Cursors.WaitCursor
                        MetroProgressBar.Minimum = 0
                        MetroProgressBar.Maximum = Items.Count - 1
                        MetroProgressBar.Value = 0
                        MetroProgressBar.Visible = True
                        pnlStatus.Text = "Exporting Table..."
                        Application.DoEvents()

                        OutputText = ""
                        For i = 1 To ColumnPositions.Count - 1
                            If ColumnPositions(i) <> "" Then
                                OutputText = OutputText & ColumnPositions(i) & Separator
                                ExportColumns.Add(ColumnPositions(i))
                            End If
                        Next
                        OutputText = OutputText.Substring(0, Len(OutputText) - 1) ' Strip last separator

                        MyStream.Write(OutputText & Environment.NewLine)

                        For Each Price In Items
                            OutputText = ""
                            For j = 0 To ExportColumns.Count - 1
                                ' Format each column value and save
                                OutputText = OutputText & GetOutputText(ExportColumns(j), Price.SubItems(j + 1).Text, Separator, UserApplicationSettings.DataExportFormat)
                            Next

                            ' For each record, update the progress bar
                            Call IncrementToolStripProgressBar(MetroProgressBar)
                            Application.DoEvents()

                            MyStream.Write(OutputText & Environment.NewLine)
                        Next

                        MyStream.Flush()
                        MyStream.Close()

                        MsgBox("Manufacturing Data Exported", vbInformation, Application.ProductName)

                    End If
                End If
            Catch
                MsgBox(Err.Description, vbExclamation, Application.ProductName)
            End Try
        End If

        ' Done processing the blueprints
        MetroProgressBar.Value = 0
        MetroProgressBar.Visible = False

        Cursor.Current = Cursors.Default
        Me.Refresh()
        Application.DoEvents()
        pnlStatus.Text = ""

    End Sub

    ' Outputs text in the correct format
    Private Function GetOutputText(ColumnName As String, DataText As String, Separator As String, ExportDataType As String) As String
        Dim ExportData As String

        Select Case ColumnName
            Case ProgramSettings.InventionChanceColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.VolumeperItemColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TotalVolumeColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TotalInventionCostColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TotalCopyCostColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TaxesColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.BrokerFeesColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ItemMarketPriceColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ProfitColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.IskperHourColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.SVRColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.SVRxIPHColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TotalItemsSoldColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TotalOrdersFilledColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.AvgItemsperOrderColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.CurrentSellOrdersColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.CurrentBuyOrdersColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ItemsinProductionColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ItemsinStockColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.TotalCostColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.BaseJobCostColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ManufacturingJobFeeColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ManufacturingFacilitySystemIndexColumnName
                ExportData = FormatNumber(DataText, 5) & Separator
            Case ProgramSettings.ManufacturingFacilityUsageColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.ComponentFacilitySystemIndexColumnName
                ExportData = FormatNumber(DataText, 5) & Separator
            Case ProgramSettings.ComponentFacilityUsageColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.CapComponentFacilitySystemIndexColumnName
                ExportData = FormatNumber(DataText, 5) & Separator
            Case ProgramSettings.CapComponentFacilityUsageColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.CopyingFacilitySystemIndexColumnName
                ExportData = FormatNumber(DataText, 5) & Separator
            Case ProgramSettings.CopyingFacilityUsageColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.InventionFacilitySystemIndexColumnName
                ExportData = FormatNumber(DataText, 5) & Separator
            Case ProgramSettings.InventionFacilityUsageColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case ProgramSettings.PortionSizeColumnName
                ExportData = Format(DataText, "Fixed") & Separator
            Case Else
                ExportData = DataText & Separator
        End Select

        If ExportDataType = SSVDataExport Then
            ' Format to EU
            ExportData = ConvertUStoEUDecimal(ExportData)
        End If

        Return ExportData

    End Function

    ' Refresh the list with blueprints before we calculate the data so the user knows what they are calculating
    Private Sub btnManufactureRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call DisplayManufacturingResults(False)
    End Sub

    ' Reads through the manufacturing blueprint list and calculates the isk per hour for all that are selected, then sorts them and displays
    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcCalculate.Click

        btnCalcSaveSettings()

        If btnCalcCalculate.Text = "Cancel" Then
            CancelManufacturingTabCalc = True
        Else
            Call DisplayManufacturingResults(True)
        End If

        'Auto setup shopping list
        If autoShopping.Checked Then
            AutoAddToShoppingList()
        End If

    End Sub

    ' Builds the query for the main grid update
    Private Function BuildManufacturingSelectQuery(ByRef RecordCount As Integer, ByRef InventedBPs As List(Of Long)) As String
        Dim SQL As String = ""
        Dim SQLTemp As String = ""
        Dim WhereClause As String = ""
        Dim ComboType As String = ""

        ' Core Query
        SQL = "SELECT * FROM " & USER_BLUEPRINTS

        WhereClause = BuildManufactureWhereClause(False, InventedBPs)

        ' Don't load if no where clause
        If WhereClause = "" Then
            Return ""
        End If

        ' Get the record count first
        SQLTemp = "SELECT COUNT(*) FROM " & USER_BLUEPRINTS & WhereClause

        Dim CMDCount As New SQLiteCommand(SQLTemp, EVEDB.DBREf)
        CMDCount.Parameters.AddWithValue("@USERBP_USERID", GetBPUserID(SelectedCharacter.ID)) ' need to search for corp ID too
        CMDCount.Parameters.AddWithValue("@USERBP_CORPID", CStr(SelectedCharacter.CharacterCorporation.CorporationID))
        RecordCount = CInt(CMDCount.ExecuteScalar())

        Return SQL & WhereClause & " ORDER BY ITEM_GROUP, ITEM_NAME"

    End Function

    ' Builds the where clause for the calc screen based on Tech and Group selections, by reference will return the list of Invented BPs
    Private Function BuildManufactureWhereClause(LoadingList As Boolean, ByRef InventedBPs As List(Of Long)) As String
        Dim WhereClause As String = ""
        Dim ItemTypes As String = ""
        Dim ComboType As String = ""
        Dim ItemTypeNumbers As String = ""
        Dim T2Selected As Boolean = False ' Whether the user wants to look at T2 blueprints or not - this is used in loading only T2 bps that we can invent
        Dim TempRace As String = ""
        Dim RaceClause As String = ""
        Dim SizesClause As String = ""
        Dim NPCBPOsClause As String = ""

        Dim SQL As String = ""
        Dim T2Query As String = ""
        Dim T3Query As String = ""
        Dim RelicRuns As String = ""

        ItemTypes = ItemTypes & "X.ITEM_CATEGORY = 'Charge' OR "
        ItemTypes = ItemTypes & "X.ITEM_CATEGORY IN ('Drone', 'Fighter') OR "
        ItemTypes = ItemTypes & "(X.ITEM_CATEGORY = 'Module' AND X.ITEM_GROUP NOT LIKE 'Rig%') OR "
        ItemTypes = ItemTypes & "X.ITEM_CATEGORY = 'Ship' OR "
        ItemTypes = ItemTypes & "(X.BLUEPRINT_GROUP = 'Rig Blueprint' OR (X.ITEM_CATEGORY = 'Structure Module' AND X.ITEM_GROUP LIKE '%Rig%')) OR "
        ItemTypes = ItemTypes & "X.ITEM_GROUP IN ('Tool','Data Interfaces','Cyberimplant','Fuel Block') OR "

        ' Take off last OR
        If ItemTypes <> "" Then
            ItemTypes = ItemTypes.Substring(0, ItemTypes.Count - 4)
        Else
            ' Can't run this
            Return ""
        End If

        ' Item Type Definitions - These are set by me based on existing data
        ' 1, 2, 14 are T1, T2, T3
        ' 3 is Storyline
        ' 15 is Pirate Faction
        ' 16 is Navy Faction

        ItemTypeNumbers = ItemTypeNumbers & "1,"

        ' Add Item Type
        If ItemTypeNumbers <> "" Then
            ItemTypeNumbers = "X.ITEM_TYPE IN (" & ItemTypeNumbers.Substring(0, ItemTypeNumbers.Length - 1) & ") "
        Else
            ' They need to have at least one tech. If not, just return nothing
            Return ""
        End If

        ' See if we are looking at User Owned blueprints or item types and add this - only want owned item types
        If rbtnCalcBPOwned.Checked Then
            ItemTypeNumbers = ItemTypeNumbers & " AND OWNED <> 0 "
        End If

        ' Determine what race we are looking at
        TempRace = TempRace & "4,"
        TempRace = TempRace & "1,"
        TempRace = TempRace & "2,"
        TempRace = TempRace & "8,"
        TempRace = TempRace & "15,"
        TempRace = TempRace & "0,"

        If TempRace <> "" Then
            TempRace = "(" & TempRace.Substring(0, Len(TempRace) - 1) & ")"
            RaceClause = "X.RACE_ID IN " & TempRace
        Else
            ' They need to have at least one. If not, just return nothing
            Return ""
        End If

        ' If they select a type of item, set that
        If LoadingList Then
            ComboType = ""
        End If

        SizesClause = ""

        ' Finally add the sizes
        SizesClause = SizesClause & "'S',"
        SizesClause = SizesClause & "'M',"
        SizesClause = SizesClause & "'L',"
        SizesClause = SizesClause & "'XL',"

        If SizesClause <> "" Then
            SizesClause = " AND SIZE_GROUP IN (" & SizesClause.Substring(0, Len(SizesClause) - 1) & ") "
        End If

        NPCBPOsClause = " AND NPC_BPO = 1 AND ITEM_TYPE = 1 " ' only include T1 BPOs

        ' Flag for favorites 
        If rbtnCalcBPFavorites.Checked Then
            WhereClause = "WHERE FAVORITE = 1 AND "
        Else
            WhereClause = "WHERE "
        End If

        ' Add all the items to the where clause
        WhereClause = WhereClause & RaceClause & " AND (" & ItemTypes & ") AND (((" & ItemTypeNumbers & ") " & T2Query & T3Query & "))" & SizesClause & ComboType & NPCBPOsClause & " "

        ' Only bps not ignored - no option for this yet
        WhereClause = WhereClause & " AND IGNORE = 0 "

        Return WhereClause

    End Function

    ' Checks data on different filters to see if we enter the item, and formats colors, etc. after
    Private Sub InsertManufacturingItem(ByVal SentItem As ManufacturingItem, ByVal SVRThreshold As Double,
                                        ByVal InsertBlankSVR As Boolean, ByRef SentList As List(Of ManufacturingItem),
                                        ByRef FormatList As List(Of RowFormat))
        Dim CurrentRowFormat As New RowFormat
        Dim InsertItem As Boolean = True ' Assume we include until the record doesn't pass one condition
        ListIDIterator += 1

        SentItem.ListID = ListIDIterator

        ' If not blank, does it meet the threshold? If nothing, then we want to include it, so skip
        If SentItem.SVR <> "-" And Not IsNothing(SVRThreshold) Then
            ' It's below the threshold, so don't insert
            If CDbl(SentItem.SVR) < SVRThreshold Then
                InsertItem = False
            End If
        End If

        ' If it's empty and you don't want blank svr's, don't insert
        If SentItem.SVR = "-" And Not InsertBlankSVR Then
            InsertItem = False
        End If

        ' Min Build time
        If chkCalcMinBuildTimeFilter.Checked Then
            ' If greater than max threshold, don't include
            If ConvertDHMSTimetoSeconds(SentItem.TotalProductionTime) < ConvertDHMSTimetoSeconds(tpMinBuildTimeFilter.Text) Then
                InsertItem = False
            End If
        End If

        ' Max Build time
        If chkCalcMaxBuildTimeFilter.Checked Then
            ' If greater than max threshold, don't include
            If ConvertDHMSTimetoSeconds(SentItem.TotalProductionTime) > ConvertDHMSTimetoSeconds(tpMaxBuildTimeFilter.Text) Then
                InsertItem = False
            End If
        End If

        ' Now determine the format of the item and save it for drawing the list - only if we add it
        If InsertItem Then
            ' Add the record
            SentList.Add(CType(SentItem.Clone, ManufacturingItem))

            CurrentRowFormat.ListID = ListIDIterator

            'Set the row format for background and foreground colors
            'All columns need to be colored properly
            ' Color owned BP's
            If SentItem.Owned = Yes Then
                If SentItem.Scanned = 1 Or SentItem.Scanned = 0 Then
                    CurrentRowFormat.BackColor = Brushes.BlanchedAlmond
                ElseIf SentItem.Scanned = 2 Then
                    ' Corp owned
                    CurrentRowFormat.BackColor = Brushes.LightGreen
                End If
            ElseIf UserInventedBPs.Contains(SentItem.BPID) Then
                ' It's an invented BP that we own the T1 BP for
                CurrentRowFormat.BackColor = Brushes.LightSkyBlue
            Else
                CurrentRowFormat.BackColor = Brushes.White
            End If

            ' Set default and change if needed
            CurrentRowFormat.ForeColor = Brushes.Black

            ' Highlight those we can't build, RE or Invent
            If Not SentItem.CanBuildBP Then
                CurrentRowFormat.ForeColor = Brushes.DarkRed
            End If

            If Not SentItem.CanInvent And SentItem.TechLevel = "T2" And SentItem.BlueprintType = BPType.InventedBPC Then
                CurrentRowFormat.ForeColor = Brushes.DarkOrange
            End If

            If Not SentItem.CanRE And SentItem.TechLevel = "T3" And SentItem.BlueprintType = BPType.InventedBPC Then
                CurrentRowFormat.ForeColor = Brushes.DarkGreen
            End If

            ' Insert the format
            FormatList.Add(CurrentRowFormat)

        End If

    End Sub

    ' Reads optimal decryptor list and removes only but the most optimal decryptor from the item list
    Private Function SetOptimalDecryptorList(ByVal ItemList As List(Of ManufacturingItem), OptimalItemList As List(Of OptimalDecryptorItem)) As List(Of ManufacturingItem)
        Dim TempDecryptorItem As New OptimalDecryptorItem
        Dim TempList As New List(Of OptimalDecryptorItem)
        Dim CompareValue As Double = 0
        Dim OptimalLocationID As Integer = 0
        Dim RemoveLocations As New List(Of Integer)

        If OptimalItemList.Count <> 0 Then
            For i = 0 To ItemList.Count - 1
                ' Get all the items in the decryptor list (if they exist)
                DecryptorItemToFind.CalcType = ItemList(i).CalcType
                DecryptorItemToFind.ItemTypeID = ItemList(i).ItemTypeID
                ' Find all the items
                TempList = OptimalItemList.FindAll(AddressOf FindDecryptorItem)
                If TempList IsNot Nothing Then
                    ' Loop through each one and get the Location ID for the most optimal item
                    For j = 0 To TempList.Count - 1
                        If CompareValue = 0 Or CompareValue <= TempList(j).CompareValue Then
                            CompareValue = TempList(j).CompareValue
                            ' Save/reset the location for the optimal
                            OptimalLocationID = TempList(j).ListLocationID
                        End If
                    Next

                    ' Reset
                    CompareValue = 0

                    ' Insert the location ID into the list to remove later
                    For j = 0 To TempList.Count - 1
                        If TempList(j).ListLocationID <> OptimalLocationID Then
                            ' Remove this one
                            RemoveLocations.Add(TempList(j).ListLocationID)
                        End If
                    Next

                End If
            Next

            ' Finally, remove all the ID's in the remove list
            For i = 0 To RemoveLocations.Count - 1
                ManufacturingRecordIDToFind = RemoveLocations(i)
                ItemList.Remove(ItemList.Find(AddressOf FindManufacturingItem))
            Next
        End If

        Return ItemList

    End Function

    Private DecryptorItemToFind As OptimalDecryptorItem

    ' Predicate for finding an in the list of decryptors
    Private Function FindDecryptorItem(ByVal Item As OptimalDecryptorItem) As Boolean
        If Item.CalcType = DecryptorItemToFind.CalcType And Item.ItemTypeID = DecryptorItemToFind.ItemTypeID Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub lstManufacturing_ColumnWidthChanging(sender As Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs)
        If e.ColumnIndex = 0 Then
            e.Cancel = True
            e.NewWidth = lstPricesView.Columns(e.ColumnIndex).Width
        End If
    End Sub

    ' On double click of the item, it will open up the bp window with the item 
    Private Sub lstManufacturing_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim FoundItem As New ManufacturingItem
        Dim CompareType As String

        ' Find the item clicked in the list of items then just send those values over
        ManufacturingRecordIDToFind = CLng(lstManufacturing.SelectedItems(0).SubItems(0).Text)
        FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItem)

        SelectedBlueprint = FoundItem.Blueprint

        UpdateBPPriceLabels()

        lblBPCanMakeBP.Visible = True

        ' Set the build facility we are sending to the proper facility type for this item. 
        If FoundItem IsNot Nothing Then
            ' We found it, so load the current bp
            With FoundItem
                CompareType = "Components"

                Dim T2T3Type As BuildMatType
                T2T3Type = Nothing

                Call LoadBPfromEvent(.BPID, .CalcType, .Inputs, SentFromLocation.ManufacturingTab,
                                     .ManufacturingFacility, .ComponentManufacturingFacility, .CapComponentManufacturingFacility,
                                     .InventionFacility, .CopyFacility,
                                     True, GetBrokerFeeData(),
                                     CStr(.BPME), CStr(.BPTE), txtCalcRuns.Text, txtCalcProdLines.Text, txtCalcLabLines.Text,
                                     txtCalcNumBPs.Text, FormatNumber(.AddlCosts, 2), False, CompareType, T2T3Type)
            End With
        End If

    End Sub

    ' The manufacturing item to load the grid
    Public Class ManufacturingItem
        Implements ICloneable

        Public ListID As Integer ' Unique record id

        Public Blueprint As Blueprint ' The blueprint we used to make this item - for shopping list references

        Public BPID As Long
        Public ItemGroup As String
        Public ItemGroupID As Integer
        Public ItemCategory As String
        Public ItemCategoryID As Integer
        Public ItemTypeID As Long
        Public ItemName As String
        Public TechLevel As String
        Public Owned As String
        Public Scanned As Integer
        Public BPME As Integer
        Public BPTE As Integer
        Public Inputs As String
        Public AddlCosts As Double
        Public Profit As Double
        Public ProfitPercent As Double
        Public IPH As Double
        Public TotalCost As Double
        Public TotalRiskCost As Double
        Public CalcType As String ' Type of calculation to get the profit - either Components, Raw Mats or Build/Buy
        Public BlueprintType As BPType

        Public Runs As Integer
        Public SingleInventedBPCRunsperBPC As Integer
        Public ProductionLines As Integer
        Public LaboratoryLines As Integer

        ' Inputs
        Public Decryptor As New Decryptor
        Public Relic As String
        Public SavedBPRuns As Integer ' The number of runs on the bp that they have, helpful for determing decryptor and relics

        ' Can do variables
        Public CanBuildBP As Boolean
        Public CanInvent As Boolean
        Public CanRE As Boolean

        Public SVR As String ' Sales volume ratio
        Public SVRxIPH As String
        Public PriceTrend As Double
        Public Score As Double
        Public RiskProfit As Double
        Public RiskIPH As Double
        Public RiskPrice As Double
        Public Volatility As Double
        Public TotalItemsSold As Long
        Public TotalOrdersFilled As Long
        Public AvgItemsperOrder As Double
        Public CurrentSellOrders As Long
        Public CurrentBuyOrders As Long
        Public ItemsinStock As Integer
        Public ItemsinProduction As Integer

        Public ManufacturingFacility As IndustryFacility
        Public ManufacturingFacilityUsage As Double
        Public ComponentManufacturingFacility As IndustryFacility
        Public ComponentManufacturingFacilityUsage As Double
        Public CapComponentManufacturingFacility As IndustryFacility
        Public CapComponentManufacturingFacilityUsage As Double
        Public ReactionFacility As IndustryFacility
        Public ReactionFacilityUsage As Double

        Public CopyCost As Double
        Public CopyFacilityUsage As Double
        Public CopyFacility As IndustryFacility

        Public InventionCost As Double
        Public InventionFacilityUsage As Double
        Public InventionFacility As IndustryFacility

        Public BPProductionTime As String
        Public TotalProductionTime As String
        Public CopyTime As String
        Public InventionTime As String

        Public ItemMarketPrice As Double

        Public BrokerFees As Double
        Public Taxes As Double

        Public BaseJobCost As Double
        Public NumBPs As Integer
        Public InventionChance As Double
        Public Race As String
        Public VolumeperItem As Double
        Public TotalVolume As Double
        Public PortionSize As Integer
        Public DivideUnits As Integer

        Public JobFee As Double

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim CopyofMe As New ManufacturingItem

            CopyofMe.ListID = ListID
            CopyofMe.Blueprint = Blueprint
            CopyofMe.BPID = BPID
            CopyofMe.ItemGroup = ItemGroup
            CopyofMe.ItemGroupID = ItemGroupID
            CopyofMe.ItemCategory = ItemCategory
            CopyofMe.ItemCategoryID = ItemCategoryID
            CopyofMe.ItemTypeID = ItemTypeID
            CopyofMe.ItemName = ItemName
            CopyofMe.TechLevel = TechLevel
            CopyofMe.Owned = Owned
            CopyofMe.Scanned = Scanned
            CopyofMe.BPME = BPME
            CopyofMe.BPTE = BPTE
            CopyofMe.Inputs = Inputs
            CopyofMe.AddlCosts = AddlCosts
            CopyofMe.Profit = Profit
            CopyofMe.ProfitPercent = ProfitPercent
            CopyofMe.IPH = IPH
            CopyofMe.TotalCost = TotalCost
            CopyofMe.TotalRiskCost = TotalRiskCost
            CopyofMe.CalcType = CalcType
            CopyofMe.BlueprintType = BlueprintType

            CopyofMe.Runs = Runs
            CopyofMe.SingleInventedBPCRunsperBPC = SingleInventedBPCRunsperBPC
            CopyofMe.ProductionLines = ProductionLines
            CopyofMe.LaboratoryLines = LaboratoryLines

            CopyofMe.CopyTime = CopyTime
            CopyofMe.InventionTime = InventionTime

            CopyofMe.Inputs = Inputs
            CopyofMe.Decryptor = Decryptor
            CopyofMe.Relic = Relic
            CopyofMe.SavedBPRuns = SavedBPRuns

            CopyofMe.CanBuildBP = CanBuildBP
            CopyofMe.CanInvent = CanInvent
            CopyofMe.CanRE = CanRE

            CopyofMe.SVR = SVR
            CopyofMe.SVRxIPH = SVRxIPH
            CopyofMe.PriceTrend = PriceTrend
            CopyofMe.Score = Score
            CopyofMe.RiskProfit = RiskProfit
            CopyofMe.RiskIPH = RiskIPH
            CopyofMe.RiskPrice = RiskPrice
            CopyofMe.Volatility = Volatility
            CopyofMe.TotalItemsSold = TotalItemsSold
            CopyofMe.TotalOrdersFilled = TotalOrdersFilled
            CopyofMe.AvgItemsperOrder = AvgItemsperOrder
            CopyofMe.CurrentSellOrders = CurrentSellOrders
            CopyofMe.CurrentBuyOrders = CurrentBuyOrders
            CopyofMe.ItemsinStock = ItemsinStock
            CopyofMe.ItemsinProduction = ItemsinProduction

            CopyofMe.CopyCost = CopyCost
            CopyofMe.InventionCost = InventionCost

            CopyofMe.ManufacturingFacility = ManufacturingFacility
            CopyofMe.ComponentManufacturingFacility = ComponentManufacturingFacility
            CopyofMe.CapComponentManufacturingFacility = CapComponentManufacturingFacility
            CopyofMe.ReactionFacility = ReactionFacility
            CopyofMe.InventionFacility = InventionFacility
            CopyofMe.CopyFacility = CopyFacility

            CopyofMe.BPProductionTime = BPProductionTime
            CopyofMe.TotalProductionTime = TotalProductionTime
            CopyofMe.ItemMarketPrice = ItemMarketPrice
            CopyofMe.BrokerFees = BrokerFees
            CopyofMe.Taxes = Taxes
            CopyofMe.BaseJobCost = BaseJobCost

            CopyofMe.NumBPs = NumBPs
            CopyofMe.InventionChance = InventionChance
            CopyofMe.BlueprintType = BlueprintType
            CopyofMe.Race = Race
            CopyofMe.VolumeperItem = VolumeperItem
            CopyofMe.TotalVolume = TotalVolume
            CopyofMe.PortionSize = PortionSize
            CopyofMe.DivideUnits = DivideUnits

            CopyofMe.JobFee = JobFee

            CopyofMe.ManufacturingFacilityUsage = ManufacturingFacilityUsage
            CopyofMe.ComponentManufacturingFacilityUsage = ComponentManufacturingFacilityUsage
            CopyofMe.CapComponentManufacturingFacilityUsage = CapComponentManufacturingFacilityUsage
            CopyofMe.ReactionFacilityUsage = ReactionFacilityUsage
            CopyofMe.CopyFacilityUsage = CopyFacilityUsage
            CopyofMe.InventionFacilityUsage = InventionFacilityUsage

            Return CopyofMe

        End Function

    End Class

    ' Predicate for finding an item in a list EVE Market Data of items
    Private Function FindManufacturingItem(ByVal Item As ManufacturingItem) As Boolean
        If Item.ListID = ManufacturingRecordIDToFind Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Predicate for finding an item in a list EVE Market Data of items
    Private Function FindManufacturingItembyName(ByVal Item As ManufacturingItem) As Boolean
        If Item.ItemName = ManufacturingNameToFind Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Calculates the slope of the trend line for the market history for the sent type id for the last x days sent
    ' Formula and logic from here: http://classroom.synonym.com/calculate-trendline-2709.html
    Private Function CalculatePriceTrend(ByVal TypeID As Long, ByVal RegionID As Long, DaysfromToday As Integer) As Double
        Dim SQL As String
        Dim rsMarketHistory As SQLiteDataReader
        Dim GraphData As New List(Of EVEIPHPricePoint)
        Dim counter As Integer = 0

        Dim n_value As Double = 0 ' Let n = the number of data points, in this case 3
        Dim a_value As Double = 0
        Dim b_value As Double = 0
        Dim c_value As Double = 0
        Dim d_value As Double = 0
        Dim e_value As Double = 0
        Dim f_value As Double = 0

        Dim x_sum As Double = 0
        Dim x_squared As Double = 0
        Dim y_sum As Double = 0

        Dim slope As Double = 0
        Dim y_intercept As Double = 0

        Dim AdjustPrice As Double = 0

        ' Average price is the Y values, dates (or just days) is the x value

        ' Now get all the prices for the time period
        SQL = "SELECT PRICE_HISTORY_DATE, AVG_PRICE FROM MARKET_HISTORY WHERE TYPE_ID = " & CStr(TypeID) & " AND REGION_ID = " & CStr(RegionID) & " "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) >= " & " DateTime('" & Format(DateAdd(DateInterval.Day, -(DaysfromToday + 1), Date.UtcNow.Date), SQLiteDateFormat) & "') "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) < " & " DateTime('" & Format(Date.UtcNow.Date, SQLiteDateFormat) & "') "
        SQL = SQL & "ORDER BY PRICE_HISTORY_DATE ASC"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsMarketHistory = DBCommand.ExecuteReader

        While rsMarketHistory.Read
            Dim TempPoint As EVEIPHPricePoint
            counter += 1
            TempPoint.PointDate = rsMarketHistory.GetDateTime(0)
            TempPoint.X_Date_Marker = counter
            If counter = 1 Then
                ' Save the base value and then reduce from all other prices
                AdjustPrice = rsMarketHistory.GetDouble(1)
                TempPoint.Y_Price = rsMarketHistory.GetDouble(1)
            Else
                TempPoint.Y_Price = rsMarketHistory.GetDouble(1)
            End If

            ' Since we are looping through the data, just do the summation calcs now
            a_value += (counter * TempPoint.Y_Price)
            ' Grab the sum here too
            y_sum += TempPoint.Y_Price
            x_sum += TempPoint.X_Date_Marker
            x_squared += TempPoint.X_Date_Marker ^ 2

            GraphData.Add(TempPoint)
        End While

        ' Set the n_value from the loop
        If counter <= 1 Then
            ' If it's 0 or 1, then we can't do a slope calculation 
            Return 0
        Else
            n_value = counter
        End If

        ' Now we have all the data to do the calculations

        ' Calculate a
        ' Let a equal n times the summation of all x-values multiplied by their corresponding y-values, like so: a = 3 x {(1 x 3) +( 2 x 5) + (3 x 6.5)} = 97.5
        ' Use previous calc value and multiply by n
        a_value = a_value * n_value

        ' Calculate b
        ' Let b equal the sum of all x-values times the sum of all y-values, like so: b = (1 + 2 + 3) x (3 + 5 + 6.5) = 87
        ' Use x_sum and y_sum from earlier and calculate b
        b_value = x_sum * y_sum

        ' Calculate c
        ' Let c equal n times the sum of all squared x-values, like so: c = 3 x (1^2 + 2^2 + 3^2) = 42
        c_value = n_value * x_squared

        ' Calculate d
        ' Let d equal the squared sum of all x-values, like so: d = (1 + 2 + 3)^2 = 36
        d_value = x_sum ^ 2

        ' Calculate the slope
        ' Plug the values that you calculated for a, b, c, and d into the following equation to calculate the slope, m, of the regression line: 
        ' slope = m = (a - b) / (c - d) = (97.5 - 87) / (42 - 36) = 10.5 / 6 = 1.75
        slope = (a_value - b_value) / (c_value - d_value)

        ' Now find the intercepts so we can normalize the slope value
        ' Consider the same data set. Let e equal the sum of all y-values, like so: e = (3 + 5 + 6.5) = 14.5
        e_value = y_sum

        ' Let f equal the slope times the sum of all x-values, like so: f = 1.75 x (1 + 2 + 3) = 10.5
        f_value = slope * x_sum

        ' Calculate the y-intercept
        ' Plug the values you have calculated for e and f into the following equation for the y-intercept, b, of the trendline: 
        ' y-intercept = b = (e - f) / n = (14.5 - 10.5) / 3 = 1.3)
        y_intercept = (e_value - f_value) / n_value

        ' Now that we have all the parts of y = mx + b, normalize the trendline to a percentage change value
        ' First figure out the value today (the start value is the y-intercept)
        Dim TodaysTrendLinePrice As Double = slope * n_value + y_intercept
        'y = 50,098.90x - 1,518,343.83
        Dim trend As Double = (TodaysTrendLinePrice - y_intercept) / TodaysTrendLinePrice
        Return trend

    End Function

    ' Calculates the slope of the trend line for the market history for the sent type id for the last x days sent
    Private Function CalculatePriceAverage(ByVal TypeID As Long, ByVal RegionID As Long, DaysfromToday As Integer) As Double
        Dim SQL As String
        Dim rsMarketHistory As SQLiteDataReader
        Dim counter As Integer = 0

        Dim y_sum As Double = 0

        ' Average price is the Y values, dates (or just days) is the x value

        ' Now get all the prices for the time period
        SQL = "SELECT PRICE_HISTORY_DATE, AVG_PRICE FROM MARKET_HISTORY WHERE TYPE_ID = " & CStr(TypeID) & " AND REGION_ID = " & CStr(RegionID) & " "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) >= " & " DateTime('" & Format(DateAdd(DateInterval.Day, -(DaysfromToday + 1), Date.UtcNow.Date), SQLiteDateFormat) & "') "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) < " & " DateTime('" & Format(Date.UtcNow.Date, SQLiteDateFormat) & "') "
        SQL = SQL & "ORDER BY PRICE_HISTORY_DATE ASC"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsMarketHistory = DBCommand.ExecuteReader

        While rsMarketHistory.Read
            Dim TempPoint As EVEIPHPricePoint
            counter += 1
            TempPoint.Y_Price = rsMarketHistory.GetDouble(1)
            y_sum += TempPoint.Y_Price
        End While

        ' Set the n_value from the loop
        If counter <= 1 Then
            ' If it's 0 or 1, then we can't do a slope calculation 
            Return 0
        End If

        Dim average As Double = y_sum / counter
        Return average

    End Function

    ' Calculates price volatility
    ' Formula and logic from here: https://www.investopedia.com/ask/answers/021015/how-can-you-calculate-volatility-excel.asp
    Private Function CalculateVolatility(ByVal TypeID As Long, ByVal RegionID As Long, DaysfromToday As Integer) As Double
        Dim SQL As String
        Dim rsMarketHistory As SQLiteDataReader
        Dim GraphData As New List(Of EVEIPHPricePoint)
        Dim counter As Integer = 0
        Dim n_value As Double = 0 ' Let n = the number of data points, in this case 3

        ' Now get all the prices for the time period
        SQL = "SELECT PRICE_HISTORY_DATE, AVG_PRICE FROM MARKET_HISTORY WHERE TYPE_ID = " & CStr(TypeID) & " AND REGION_ID = " & CStr(RegionID) & " "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) >= " & " DateTime('" & Format(DateAdd(DateInterval.Day, -(DaysfromToday + 1), Date.UtcNow.Date), SQLiteDateFormat) & "') "
        SQL = SQL & "AND DATETIME(PRICE_HISTORY_DATE) < " & " DateTime('" & Format(Date.UtcNow.Date, SQLiteDateFormat) & "') "
        SQL = SQL & "ORDER BY PRICE_HISTORY_DATE ASC"
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsMarketHistory = DBCommand.ExecuteReader

        While rsMarketHistory.Read
            Dim TempPoint As EVEIPHPricePoint
            counter += 1
            TempPoint.PointDate = rsMarketHistory.GetDateTime(0)
            TempPoint.X_Date_Marker = counter
            If counter = 1 Then
                TempPoint.Y_Price = rsMarketHistory.GetDouble(1)
            Else
                TempPoint.Y_Price = rsMarketHistory.GetDouble(1)
            End If

            GraphData.Add(TempPoint)
        End While

        ' Set the n_value from the loop
        If counter <= 1 Or GraphData.Count < DaysfromToday Then
            ' If it's 0 or 1, then we can't do a calculation 
            Return 0
        End If

        ' Now we have all the data to do the calculations
        Dim interdayReturn(DaysfromToday - 2) As Single
        For i = 0 To interdayReturn.Count - 1
            interdayReturn(i) = CSng((GraphData(i + 1).Y_Price / GraphData(i).Y_Price) - 1)
        Next
        Dim volatility As Single = StdDev(interdayReturn)
        Dim volatilityAnnualized As Single = CSng((365 ^ 0.5) * volatility)

        Return volatilityAnnualized

    End Function

    ' Calculates Easy-IPH Score (TM)
    Private Sub CalculateScore(ByRef ManufacturingList As List(Of ManufacturingItem))

        Dim Score As Double = 0
        Dim FirstQuartile As Double
        Dim ThirdQuartile As Double
        Dim IQR As Double
        Dim SVR As Double

        'If there are less than 5 items in the list it may be hard to find outliers, use the simple score calculator
        If ManufacturingList.Count < 5 Then
            Dim ScoreNormal(ManufacturingList.Count) As Double
            For i = 0 To ManufacturingList.Count - 1
                If ManufacturingList(i).SVR IsNot "-" Then
                    SVR = CDbl(ManufacturingList(i).SVR)
                Else
                    SVR = 0
                End If
                ScoreNormal(i) = (ManufacturingList(i).IPH + ManufacturingList(i).RiskIPH) * SVR * ManufacturingList(i).PriceTrend * ManufacturingList(i).Volatility
            Next
            'Normalize the score
            For i = 0 To ManufacturingList.Count - 1
                ManufacturingList(i).Score = ScoreNormal(i) / ScoreNormal.Max()
            Next
            Return
        End If

        '-----------------------------
        'Setup Normal values for the full score
        '-----------------------------

        '-IPH-------------------------
        'Eliminate negative IPH and low IPH before IQR
        Dim IPHExcludingNegatives(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            'See below note regarding 60k IPH
            If ManufacturingList(i).IPH > 60000 Then
                IPHExcludingNegatives(i) = ManufacturingList(i).IPH
            Else
                IPHExcludingNegatives(i) = 0
            End If
        Next
        'Eliminate outliers via IQR
        Dim IPHIqr(ManufacturingList.Count) As Double
        Array.Copy(IPHExcludingNegatives, 0, IPHIqr, 0, ManufacturingList.Count)
        Array.Sort(IPHIqr)
        FirstQuartile = Percentile(RemoveZeros(IPHIqr), 25.0)
        ThirdQuartile = Percentile(RemoveZeros(IPHIqr), 75.0)
        IQR = ThirdQuartile - FirstQuartile
        For i = 0 To ManufacturingList.Count - 1
            If IPHExcludingNegatives(i) > 0 Then
                If IPHExcludingNegatives(i) > ThirdQuartile + 1.5 * IQR Then
                    IPHExcludingNegatives(i) = ThirdQuartile + 1.5 * IQR
                ElseIf IPHExcludingNegatives(i) < FirstQuartile - 1.5 * IQR Then
                    IPHExcludingNegatives(i) = FirstQuartile - 1.5 * IQR
                End If
            End If
        Next
        'Normalize the IPH without the outliers
        Dim IPHNormal(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            IPHNormal(i) = IPHExcludingNegatives(i) / IPHExcludingNegatives.Max()
        Next

        '-SVR-------------------------
        'Convert text SVR to double
        Dim SVRDouble(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            If ManufacturingList(i).SVR IsNot "-" Then
                SVRDouble(i) = CDbl(ManufacturingList(i).SVR)
            Else
                SVRDouble(i) = 0
            End If
        Next
        'Eliminate outliers via IQR
        Dim SVRIqr(ManufacturingList.Count) As Double
        Array.Copy(SVRDouble, 0, SVRIqr, 0, ManufacturingList.Count)
        Array.Sort(SVRIqr)
        FirstQuartile = Percentile(RemoveZeros(SVRIqr), 25.0)
        ThirdQuartile = Percentile(RemoveZeros(SVRIqr), 75.0)
        IQR = ThirdQuartile - FirstQuartile
        For i = 0 To ManufacturingList.Count - 1
            If SVRDouble(i) > 0 Then
                If SVRDouble(i) > ThirdQuartile + 1.5 * IQR Then
                    SVRDouble(i) = ThirdQuartile + 1.5 * IQR
                ElseIf SVRDouble(i) < FirstQuartile - 1.5 * IQR Then
                    SVRDouble(i) = FirstQuartile - 1.5 * IQR
                End If
            End If
        Next
        'Normalize the without the outliers
        Dim SVRNormal(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            SVRNormal(i) = SVRDouble(i) / SVRDouble.Max()
        Next

        '-Price Trend-----------------
        Dim PriceTrendDouble(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            PriceTrendDouble(i) = ManufacturingList(i).PriceTrend
        Next
        'Eliminate outliers via IQR
        Dim PriceTrendIqr(ManufacturingList.Count) As Double
        Array.Copy(PriceTrendDouble, 0, PriceTrendIqr, 0, ManufacturingList.Count)
        Array.Sort(PriceTrendIqr)
        FirstQuartile = Percentile(RemoveZeros(PriceTrendIqr), 25.0)
        ThirdQuartile = Percentile(RemoveZeros(PriceTrendIqr), 75.0)
        IQR = ThirdQuartile - FirstQuartile
        For i = 0 To ManufacturingList.Count - 1
            If PriceTrendDouble(i) > 0 Then
                If PriceTrendDouble(i) > ThirdQuartile + 1.5 * IQR Then
                    PriceTrendDouble(i) = ThirdQuartile + 1.5 * IQR
                ElseIf PriceTrendDouble(i) < FirstQuartile - 1.5 * IQR Then
                    PriceTrendDouble(i) = FirstQuartile - 1.5 * IQR
                End If
            End If
        Next
        'Normalize the without the outliers
        Dim PriceTrendNormal(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            If PriceTrendDouble(i) < 0 Then
                PriceTrendNormal(i) = -PriceTrendDouble(i) / PriceTrendDouble.Min()
            Else
                PriceTrendNormal(i) = PriceTrendDouble(i) / PriceTrendDouble.Max()
            End If
        Next

        '-Volatility------------------
        Dim VolatilityDouble(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            VolatilityDouble(i) = ManufacturingList(i).Volatility
        Next
        'Eliminate outliers via IQR
        Dim VolatilityIqr(ManufacturingList.Count) As Double
        Array.Copy(VolatilityDouble, 0, VolatilityIqr, 0, ManufacturingList.Count)
        Array.Sort(VolatilityIqr)
        FirstQuartile = Percentile(RemoveZeros(VolatilityIqr), 25.0)
        ThirdQuartile = Percentile(RemoveZeros(VolatilityIqr), 75.0)
        IQR = ThirdQuartile - FirstQuartile
        For i = 0 To ManufacturingList.Count - 1
            If SVRDouble(i) > 0 Then
                If VolatilityDouble(i) > ThirdQuartile + 1.5 * IQR Then
                    VolatilityDouble(i) = ThirdQuartile + 1.5 * IQR
                ElseIf VolatilityDouble(i) < FirstQuartile - 1.5 * IQR Then
                    VolatilityDouble(i) = FirstQuartile - 1.5 * IQR
                End If
            End If
        Next
        'Normalize the without the outliers
        Dim VolatilityNormal(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            VolatilityNormal(i) = VolatilityDouble(i) / VolatilityDouble.Max()
        Next

        '-Risk------------------------
        Dim RiskDouble(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            If ManufacturingList(i).IPH > 0 Then
                RiskDouble(i) = ManufacturingList(i).IPH - ManufacturingList(i).RiskIPH
            Else
                RiskDouble(i) = 0
            End If
        Next
        'Eliminate outliers via IQR
        Dim RiskIqr(ManufacturingList.Count) As Double
        Array.Copy(RiskDouble, 0, RiskIqr, 0, ManufacturingList.Count)
        Array.Sort(RiskIqr)
        FirstQuartile = Percentile(RemoveZeros(RiskIqr), 25.0)
        ThirdQuartile = Percentile(RemoveZeros(RiskIqr), 75.0)
        IQR = ThirdQuartile - FirstQuartile
        For i = 0 To ManufacturingList.Count - 1
            If RiskDouble(i) > 0 Then
                If RiskDouble(i) > ThirdQuartile + 1.5 * IQR Then
                    RiskDouble(i) = ThirdQuartile + 1.5 * IQR
                ElseIf RiskDouble(i) < FirstQuartile - 1.5 * IQR Then
                    RiskDouble(i) = FirstQuartile - 1.5 * IQR
                End If
            End If
        Next
        'Normalize the without the outliers
        Dim RiskNormal(ManufacturingList.Count) As Double
        For i = 0 To ManufacturingList.Count - 1
            RiskNormal(i) = RiskDouble(i) / RiskDouble.Max()
        Next

        '-----------------------------
        'Calculate Score
        '-----------------------------
        For i = 0 To ManufacturingList.Count - 1
            If ManufacturingList(i).SVR IsNot "-" Then
                SVR = CDbl(ManufacturingList(i).SVR)
            Else
                SVR = 0
            End If

            'Give a score of zero to anything that is missing market history or won't result in any profit
            'The 60kIPH represents the transition point where mining high security belts or running missions would be less profitable than 
            'running a small number of low skill, low IPH jobs
            If ManufacturingList(i).IPH > 60000 And SVR > 0 And ManufacturingList(i).Volatility > 0 And ManufacturingList(i).PriceTrend <> 0 Then
                'SVR and trend are not as important as volatility and risk
                ManufacturingList(i).Score = IPHNormal(i) * 1.5 + SVRNormal(i) + PriceTrendNormal(i) * 0.5 - VolatilityNormal(i) - RiskNormal(i)

                'Bonus points for rigs since they are small and easier for new players to concentrate value in smaller transport ships
                Dim RiskPrices As SQLiteDataReader
                Dim RiskSQL As String = ""
                Dim RiskPrice As String = ""
                RiskSQL = "SELECT BLUEPRINT_GROUP FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID = " & CStr(ManufacturingList(i).BPID)
                DBCommand = New SQLiteCommand(RiskSQL, EVEDB.DBREf)
                RiskPrices = DBCommand.ExecuteReader
                If RiskPrices.Read Then
                    If Not IsDBNull(RiskPrices.GetValue(0)) Then
                        ' Modify the price depending on modifier
                        RiskPrice = RiskPrices.GetString(0)
                    End If
                    RiskPrices.Close()
                    RiskPrices = Nothing
                    DBCommand = Nothing
                End If
                If RiskPrice = "Rig Blueprint" Then
                    ManufacturingList(i).Score = ManufacturingList(i).Score + 0.15
                End If

            Else
                ManufacturingList(i).Score = -2.0
            End If

        Next

    End Sub

    'Generate a new array without any zeros
    Private Function RemoveZeros(ByVal Data As Double()) As Double()
        Dim targetIndex As Integer = 0

        For sourceIndex As Integer = 0 To Data.Length - 1
            If Data(sourceIndex) <> 0 Then
                Data(Math.Min(System.Threading.Interlocked.Increment(targetIndex), targetIndex - 1)) = Data(sourceIndex)
            End If
        Next

        Dim newArray As Double() = New Double(targetIndex - 1) {}
        Array.Copy(Data, 0, newArray, 0, targetIndex)
        Return newArray
    End Function

    'Find the Percentile of a sorted array
    Private Function Percentile(ByVal sortedData As Double(), ByVal p As Double) As Double
        If p >= 100.0R Then Return sortedData(sortedData.Length - 1)
        ' If the list is empty, return nothing
        If sortedData.Length = 0 Then Return 0
        ' If the list only has one item, return it
        If sortedData.Length = 1 Then Return sortedData(sortedData.Length - 1)
        Dim position As Double = (sortedData.Length + 1) * p / 100.0
        Dim leftNumber As Double = 0.0R, rightNumber As Double = 0.0R
        Dim n As Double = p / 100.0R * (sortedData.Length - 1) + 1.0R

        If position >= 1 Then
            leftNumber = sortedData(CInt(Math.Floor(n)) - 1)
            rightNumber = sortedData(CInt(Math.Floor(n)))
        Else
            leftNumber = sortedData(0)
            rightNumber = sortedData(1)
        End If

        If Equals(leftNumber, rightNumber) Then Return leftNumber
        Dim part As Double = n - Math.Floor(n)
        Return leftNumber + part * (rightNumber - leftNumber)
    End Function

    'Calulate mean
    Private Function Mean(k As Long, Arr() As Single) As Single
        Dim Sum As Single = 0

        For i As Integer = 0 To Arr.Count - 1
            Sum = Sum + Arr(i)
        Next i

        Return Sum / Arr.Count

    End Function

    'Calculate Standard Deviation
    Private Function StdDev(Arr() As Single) As Single
        Dim avg As Single, SumSq As Single

        avg = Mean(Arr.Count, Arr)
        For i As Integer = 0 To Arr.Count - 1
            SumSq = CSng(SumSq + (Arr(i) - avg) ^ 2)
        Next i

        Return CSng((SumSq / (Arr.Count - 1)) ^ (0.5))

    End Function

    Public Structure EVEIPHPricePoint
        Dim PointDate As Date
        Dim X_Date_Marker As Integer ' simplifies code for dates
        Dim Y_Price As Double ' price value
    End Structure

#Region "List Options Menu"

    ' Allows users to ignore one or more blueprints from the manufacturing tab
    Private Sub IgnoreBlueprintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IgnoreBlueprintToolStripMenuItem.Click

        If lstManufacturing.Items.Count > 0 Then
            Dim FoundItem As New ManufacturingItem
            Dim SQL As String
            Dim RemovedIDs As New List(Of Integer)

            ' Find the each item selected in the list of items then remove each one from the list
            For i = 0 To lstManufacturing.SelectedItems.Count - 1
                ManufacturingRecordIDToFind = CLng(lstManufacturing.SelectedItems(i).SubItems(0).Text)
                FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItem)

                If FoundItem IsNot Nothing Then
                    Dim ListIDstoRemove As New List(Of Integer)

                    ' We found it, so set the bp to ignore
                    With FoundItem
                        SQL = "UPDATE ALL_BLUEPRINTS_FACT SET IGNORE = 1 WHERE BLUEPRINT_ID = " & CStr(FoundItem.BPID)
                        Call EVEDB.ExecuteNonQuerySQL(SQL)

                        ' Remove the item from the list in all it's forms plus from the manufacturing list
                        ' Get all the items with the name to remove
                        ManufacturingNameToFind = FoundItem.ItemName
                        FoundItem = Nothing

                        Do
                            FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItembyName)
                            If FoundItem IsNot Nothing Then
                                ' Remove it
                                FinalManufacturingItemList.Remove(FoundItem)
                                RemovedIDs.Add(FoundItem.ListID)
                            End If
                        Loop Until FoundItem Is Nothing

                    End With
                End If
            Next

            ' Now remove all BPs we got rid of from the list
            lstManufacturing.BeginUpdate()
            Dim ListCount As Integer = lstManufacturing.Items.Count
            Dim j As Integer = 0
            While j < ListCount
                If RemovedIDs.Contains(CInt(lstManufacturing.Items(j).SubItems(0).Text)) Then
                    ' Add the indicies to remove
                    lstManufacturing.Items(j).Remove()
                    ListCount -= 1
                    j -= 1 ' make sure we reset since we just removed a line
                End If
                j += 1
            End While

            lstManufacturing.EndUpdate()

            Call PlayNotifySound()
        End If
    End Sub

    Private Sub FavoriteBlueprintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FavoriteBlueprintToolStripMenuItem.Click

        If lstManufacturing.Items.Count > 0 Then
            Dim FoundItem As New ManufacturingItem
            Dim SQL As String

            ' Find the each item selected in the list of items then remove each one from the list
            For i = 0 To lstManufacturing.SelectedItems.Count - 1
                ManufacturingRecordIDToFind = CLng(lstManufacturing.SelectedItems(i).SubItems(0).Text)
                FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItem)

                If FoundItem IsNot Nothing Then
                    ' We found it, so set the bp to a favorite in all_blueprints
                    SQL = "UPDATE ALL_BLUEPRINTS_FACT SET FAVORITE = 1 WHERE BLUEPRINT_ID = " & CStr(FoundItem.BPID)
                    Call EVEDB.ExecuteNonQuerySQL(SQL)

                    ' Assume they want to update owned blueprints too if they own it
                    SQL = "UPDATE OWNED_BLUEPRINTS SET FAVORITE = 1 WHERE BLUEPRINT_ID = " & CStr(FoundItem.BPID) & " AND USER_ID = " & CStr(SelectedCharacter.ID)
                    Call EVEDB.ExecuteNonQuerySQL(SQL)

                End If
            Next

            Call PlayNotifySound()

        End If

    End Sub

    ' Automatically add the top items to the shopping list as a function of the player's max number of jobs
    Private Sub AutoAddToShoppingList()

        Dim ESIData As New ESI
        Dim TempWalletData As Double

        'Load the character's wallet as well if a non dummy character is selected
        Dim CacheDate As Date
        If SelectedCharacter.ID = DummyCharacterID Then
            TempWalletData = 500000000 'Default for dummy character, 500m
        Else
            TempWalletData = ESIData.GetCharacterWallet(SelectedCharacter.ID, SelectedCharacter.CharacterTokenData, CacheDate)
        End If

        If lstManufacturing.Items.Count > 0 Then
            Dim FoundItem As New ManufacturingItem

            'Get player's max jobs
            Dim maxJobs As Integer = SelectedCharacter.Skills.GetSkillLevel(3387) + SelectedCharacter.Skills.GetSkillLevel(24625)


            'Sort the list by Score
            Call ListViewColumnSorter(3, CType(lstManufacturing, ListView), ManufacturingColumnClicked, SortOrder.Ascending)

            ' Find the top items
            For i = 0 To maxJobs

                ' Find the item clicked in the list of items then just send those values over
                ManufacturingRecordIDToFind = CLng(lstManufacturing.Items(i).SubItems(0).Text)
                FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItem)

                ' Add it to shopping list
                If FoundItem IsNot Nothing Then
                    Dim BuildBuy As Boolean
                    Dim CopyRaw As Boolean

                    If FoundItem.CalcType = "Build/Buy" Then
                        BuildBuy = True
                    End If

                    If FoundItem.CalcType = "Raw Materials" Or BuildBuy = True Then
                        CopyRaw = True
                    Else
                        CopyRaw = False
                    End If

                    ' Get the BP variable and send the other settings to shopping list
                    With FoundItem
                        If Not IsNothing(.Blueprint) Then
                            Call AddToShoppingList(.Blueprint, BuildBuy, CopyRaw, CalcBaseFacility.GetFacility(CalcBaseFacility.GetCurrentFacilityProductionType()),
                                False, False, False, False)
                        Else
                            MsgBox("You must calculate an item before adding it to the shopping list.", MsgBoxStyle.Information, Application.ProductName)
                            Exit Sub
                        End If
                    End With
                End If
            Next
        End If

        If TotalShoppingList.GetNumShoppingItems > 0 Then
            ' Add the final item and mark as items in list
            pnlShoppingList.Text = "Items in Shopping List"
            pnlShoppingList.ForeColor = Color.Red
        Else
            pnlShoppingList.Text = "No Items in Shopping List"
            pnlShoppingList.ForeColor = Color.Black
        End If

        ' Refresh the data if it's open
        If frmShop.Visible Then
            Call frmShop.RefreshLists()
        End If

    End Sub

    ' Adds one or multiple items to the shopping list from the manufacturing tab
    Private Sub AddToShoppingListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToShoppingListToolStripMenuItem.Click

        If lstManufacturing.Items.Count > 0 Then
            Dim FoundItem As New ManufacturingItem

            ' Find the each item selected in the list of items then remove each one from the list
            For i = 0 To lstManufacturing.SelectedItems.Count - 1

                ' Find the item clicked in the list of items then just send those values over
                ManufacturingRecordIDToFind = CLng(lstManufacturing.SelectedItems(i).SubItems(0).Text)
                FoundItem = FinalManufacturingItemList.Find(AddressOf FindManufacturingItem)

                ' Add it to shopping list
                If FoundItem IsNot Nothing Then
                    Dim BuildBuy As Boolean
                    Dim CopyRaw As Boolean

                    If FoundItem.CalcType = "Build/Buy" Then
                        BuildBuy = True
                    End If

                    If FoundItem.CalcType = "Raw Materials" Or BuildBuy = True Then
                        CopyRaw = True
                    Else
                        CopyRaw = False
                    End If

                    ' Get the BP variable and send the other settings to shopping list
                    With FoundItem
                        If Not IsNothing(.Blueprint) Then
                            Call AddToShoppingList(.Blueprint, BuildBuy, CopyRaw, CalcBaseFacility.GetFacility(CalcBaseFacility.GetCurrentFacilityProductionType()),
                               False, False, False, False)
                        Else
                            MsgBox("You must calculate an item before adding it to the shopping list.", MsgBoxStyle.Information, Application.ProductName)
                            Exit Sub
                        End If
                    End With
                End If
            Next
        End If

        If TotalShoppingList.GetNumShoppingItems > 0 Then
            ' Add the final item and mark as items in list
            pnlShoppingList.Text = "Items in Shopping List"
            pnlShoppingList.ForeColor = Color.Red
        Else
            pnlShoppingList.Text = "No Items in Shopping List"
            pnlShoppingList.ForeColor = Color.Black
        End If

        ' Refresh the data if it's open
        If frmShop.Visible Then
            Call frmShop.RefreshLists()
        End If

    End Sub

    Private Sub autoShopping_CheckedChanged(sender As Object, e As EventArgs) Handles autoShopping.CheckedChanged
        If autoShopping.Checked = True Then
            chkCalcCanBuild.Checked = True
            rbtnCalcBPOwned.Checked = True
            rbtnCalcAllBPs.Checked = False
            rbtnCalcBPFavorites.Checked = False
        End If
    End Sub

#End Region

#End Region

End Class
