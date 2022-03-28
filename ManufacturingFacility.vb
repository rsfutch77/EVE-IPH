Imports System.Data.SQLite

Public Class ManufacturingFacility

    Private SelectedFacility As IndustryFacility ' This is the active facility for the control, if not loaded will use the default
    Private SelectedLocation As ProgramLocation
    Private SelectedCharacterID As Long
    Private SelectedProductionType As ProductionType
    Private SelectedControlForm As Form ' Where the control lives

    Private DoneInitialzing As Boolean

    Private SelectedBPTech As Integer
    Private SelectedBPID As Integer
    Private SelectedBPGroupID As Integer
    Private SelectedBPCategoryID As Integer

    ' To check if we are loading and stop click events when changing values
    Private LoadingActivities As Boolean
    Private LoadingFacilityTypes As Boolean
    Private LoadingRegions As Boolean
    Private LoadingSystems As Boolean
    Private LoadingFacilities As Boolean

    ' To save previous values for checking and loading
    Private PreviousProductionType As ProductionType
    Private PreviousFacilityType As FacilityTypes
    Private PreviousRegion As String
    Private PreviousSystem As String
    Private PreviousEquipment As String
    Private PreviousActivity As String

    ' Loaded variables
    Private FacilityRegionsLoaded As Boolean
    Private FacilitySystemsLoaded As Boolean
    Private FacilityorArrayLoaded As Boolean

    ' Save these options here in the facility and allow functions to get the values publically
    Private FacilityIncludeCopyCost As Boolean
    Private FacilityIncludeCopyTime As Boolean
    Private FacilityIncludeInventionCost As Boolean
    Private FacilityIncludeInventionTime As Boolean

    ' All locally saved facility variables will be here
    Private SelectedManufacturingFacility As New IndustryFacility

    Private DefaultManufacturingFacility As New IndustryFacility

    ' Constant activities
    Public Const ActivityManufacturing As String = "Manufacturing"
    Public Const ActivityComponentManufacturing As String = "Component Manufacturing"
    Public Const ActivityCapComponentManufacturing As String = "Cap Component Manufacturing"
    Public Const ActivityCopying As String = "Copying"
    Public Const ActivityInvention As String = "Invention"
    Public Const ActivityReactions As String = "Reactions"
    Public Const ActivityReprocessing As String = "Reprocessing"

    ' For verifying activity and facility type combos selected something
    Private Const InitialTypeComboText = "Select Type"
    Private Const InitialActivityComboText = "Select Activity"
    Private Const InitialRegionComboText = "Select Region"
    Private Const InitialSolarSystemComboText = "Select System"
    Private Const InitialFacilityComboText = "Select Facility"

    Public Const POSFacility As String = "POS"
    Public Const StationFacility As String = "Station"
    Public Const StructureFacility As String = "Structure"

    Private FactionCitadelList As New List(Of Integer)

    Private FacilityLabelDefaultColor As Color = SystemColors.Highlight
    Private FacilityLabelNonDefaultColor As Color = SystemColors.ButtonShadow

    Private Enum StationServices
        ReprocessingPlant = 5
        Factory = 14
        Laboratory = 15
    End Enum

    Public Sub New()
        FirstLoad = True

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Hide everything until constructed with the options sent
        cmbFacility.Visible = False
        cmbFacilitySystem.Visible = False
        cmbFacilityRegion.Visible = False

        ' For checking facilities later - will remove if we can get locations from ESI
        FactionCitadelList.Add(47512) ' Moreau Fortizar
        FactionCitadelList.Add(47513) ' Draccous Fortizar
        FactionCitadelList.Add(47514) ' Horizion Fortizar
        FactionCitadelList.Add(47515) ' Marginis Fortizar
        FactionCitadelList.Add(47516) ' Prometheus Fortizar

        FirstLoad = False

        SelectedFacility = New IndustryFacility

    End Sub

    ' Before any controls are shown, the control needs to be initilaized by sending the view type.
    Public Sub InitializeControl(ByVal SentSelectedCharacterID As Long, FormLocation As ProgramLocation,
                                 ByVal InitialProductionType As ProductionType, ByRef ControlForm As Form)

        Const SolarSystemWidthCalc As Integer = 157

        Const RegionWidthCalc As Integer = 133

        Const FacilityArrayWidthCalc As Integer = 295

        Const LeftObjectLocation As Integer = 3

        ' Save for later
        SelectedLocation = FormLocation
        SelectedProductionType = InitialProductionType
        SelectedCharacterID = SentSelectedCharacterID
        SelectedControlForm = ControlForm

        ' Move and show the selected controls depending on the view sent
        Select Case FormLocation
            Case ProgramLocation.BlueprintTab
                ' Set initial settings to load 
                If SelectedBPID = 0 Then
                    SelectedBPCategoryID = ItemIDs.ShipCategoryID
                    SelectedBPGroupID = ItemIDs.FrigateGroupID
                    SelectedBPTech = BPTechLevel.T1
                Else
                    ' Set based on BP
                    Dim rsBP As SQLiteDataReader
                    DBCommand = New SQLiteCommand(String.Format("SELECT ITEM_GROUP_ID, ITEM_CATEGORY_ID, TECH_LEVEL FROM ALL_BLUEPRINTS_FACT WHERE BLUEPRINT_ID = {0}", SelectedBPID), EVEDB.DBREf)
                    rsBP = DBCommand.ExecuteReader
                    rsBP.Read()
                    SelectedBPGroupID = rsBP.GetInt32(0)
                    SelectedBPCategoryID = rsBP.GetInt32(1)
                    SelectedBPTech = rsBP.GetInt32(2)
                    rsBP.Close()
                End If

            Case ProgramLocation.ManufacturingTab


                cmbFacilityRegion.Text = InitialRegionComboText
                cmbFacilityRegion.Width = RegionWidthCalc
                cmbFacilityRegion.Visible = True

                cmbFacilitySystem.Top = cmbFacilityRegion.Top
                cmbFacilitySystem.Width = SolarSystemWidthCalc
                cmbFacilitySystem.Text = InitialSolarSystemComboText
                cmbFacilitySystem.Visible = True

                cmbFacility.Top = cmbFacilityRegion.Top
                cmbFacility.Left = LeftObjectLocation + RegionWidthCalc + SolarSystemWidthCalc + 1
                cmbFacility.Width = FacilityArrayWidthCalc
                cmbFacility.Text = InitialFacilityComboText
                cmbFacility.Visible = True

                ' Set the initial group/category IDs
                ' also set the activity combo text to show what type of activity this facility is, even if not visible
                Call GetFacilityBPItemData(InitialProductionType, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech, ActivityManufacturing)

                ' Load the defaults
                Call InitializeFacilities(ProgramLocation.ManufacturingTab, InitialProductionType)

            Case Else
                ' Leave, no valid option sent
                Exit Sub
        End Select

        DoneInitialzing = True

    End Sub

    ' Loads all the facilities for the view type sent to include defaults
    Public Sub InitializeFacilities(FacilityLocation As ProgramLocation, Optional InitialProductionType As ProductionType = ProductionType.Manufacturing,
                                    Optional RefreshSelectedOnly As Boolean = False)

        If FacilityLocation = ProgramLocation.BlueprintTab And Not RefreshSelectedOnly Then
            ' Load all the facilities for  tab - always start with manufacturing
            Call SelectedFacility.InitalizeFacility(ProductionType.Manufacturing, FacilityLocation, SelectedControlForm)
            SelectedManufacturingFacility = CType(SelectedFacility.Clone, IndustryFacility)
            DefaultManufacturingFacility = CType(SelectedFacility.Clone, IndustryFacility)
        ElseIf FacilityLocation = ProgramLocation.ManufacturingTab Or RefreshSelectedOnly Then

            ' Select what facility to load based on the industry type
            Call SelectedFacility.InitalizeFacility(InitialProductionType, FacilityLocation, SelectedControlForm)

            Call SetSelectedFacility(InitialProductionType, FacilityLocation)

        Else
            ' Leave, no valid option sent
            Exit Sub
        End If

        ' Reset these
        ' To save previous values for checking and loading
        PreviousProductionType = ProductionType.None
        PreviousFacilityType = FacilityTypes.None
        PreviousRegion = ""
        PreviousSystem = ""
        PreviousEquipment = ""
        PreviousActivity = ""

        ' Loaded variables
        FacilityRegionsLoaded = False
        FacilitySystemsLoaded = False
        FacilityorArrayLoaded = False

        LoadingActivities = False
        LoadingFacilityTypes = False
        LoadingRegions = False
        LoadingSystems = False
        LoadingFacilities = False

        ' Load the selected facility with set bp
        Call LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech, True)

    End Sub

    Public Sub SetSelectedFacility(BuildType As ProductionType, FacilityLocation As ProgramLocation, Optional LoadDualFacilities As Boolean = True)

        'Now save the default and selected facility to the appropriate variable
        SelectedManufacturingFacility = CType(SelectedFacility.Clone, IndustryFacility)
        DefaultManufacturingFacility = CType(SelectedFacility.Clone, IndustryFacility)

    End Sub

    ' Loads the class facility and objects
    Public Sub LoadFacility(ByVal ItemBPID As Integer, ByVal ItemGroupID As Integer, ByVal ItemCategoryID As Integer, ByVal BlueprintTech As Integer,
                            Optional ByVal LoadDefault As Boolean = False, Optional ByVal ActivityComboSelect As Boolean = False, Optional RefreshBP As Boolean = True)

        ' Save these for later use
        SelectedBPID = ItemBPID
        SelectedBPCategoryID = ItemCategoryID
        SelectedBPGroupID = ItemGroupID
        SelectedBPTech = BlueprintTech

        ' Process the activities combo if showing full controls
        If SelectedLocation = ProgramLocation.BlueprintTab Then
            If Not ActivityComboSelect Then ' only load if from the activities combo
                Call LoadFacilityActivities(ItemGroupID, ItemCategoryID, BlueprintTech, SelectedBPID)
            End If
        End If

        ' Get the production type, based on activity selected
        SelectedProductionType = GetProductionType(ItemGroupID, ItemCategoryID, ActivityManufacturing)
        Application.DoEvents()

        ' Look up Facility - activity set to facility inside
        SelectedFacility = SelectFacility(SelectedProductionType, LoadDefault)

        ' Facility Type combo, load it if they want to change
        Call LoadFacilityTypes(SelectedProductionType, SelectedFacility.Activity)

        ' Enable the type of facility and set
        LoadingFacilityTypes = True
        LoadingFacilityTypes = False

        If SelectedFacility.FacilityType = FacilityTypes.None Then
            ' Just hide the boxes and exit
            SelectedFacility.FullyLoaded = True ' Even with none, it's loaded
            Call SetNoFacility()
            Exit Sub ' Leave, all loaded
        End If

        ' Region name Combo
        LoadingRegions = True
        cmbFacilityRegion.Enabled = True
        cmbFacilityRegion.Text = SelectedFacility.RegionName
        LoadingRegions = False

        ' Systems combo
        LoadingSystems = True
        cmbFacilitySystem.Enabled = True
        cmbFacilitySystem.Text = SelectedFacility.SolarSystemName
        LoadingSystems = False

        ' Facility/Array combo
        LoadingFacilities = True
        cmbFacility.Enabled = True
        Dim AutoLoad As Boolean = False
        Call LoadFacilities(False, SelectedFacility.Activity, AutoLoad, SelectedFacility.FacilityName)
        LoadingFacilities = False

        ' Finally show the results and save the facility locally
        If Not AutoLoad Then
            LoadingFacilities = True
            With SelectedFacility
                cmbFacility.Text = .FacilityName
                Call DisplayFacilityBonus(.FacilityProductionType, ItemGroupID, ItemCategoryID, SelectedFacility.Activity,
                                          GetFacilityTypeCode("Station"), cmbFacility.Text)
            End With
            LoadingFacilities = False
        End If

        Call ResetComboLoadVariables(False, False, False)

        ' All data loaded
        SelectedFacility.FullyLoaded = True

        ' Facility is loaded, so save it to default and dynamic variable
        If LoadDefault Then
            Call SetSelectedFacility(SelectedProductionType, SelectedLocation, False)
        End If
        Call SetFacility(SelectedFacility, SelectedProductionType, False, False)

    End Sub

    ' Loads the facility activity combo - checks group and category ID's if it has components to set component activities
    Public Sub LoadFacilityActivities(BPGroupID As Long, BPCategoryID As Long, BlueprintTech As Integer, BPID As Integer)

        LoadingActivities = True
        Dim HasComponents As Boolean = False

        Dim SQL As String
        Dim readerBP As SQLiteDataReader

        ' See if this has buildable components
        SQL = "SELECT DISTINCT 'X' FROM ALL_BLUEPRINTS "
        SQL &= "WHERE ITEM_ID IN (SELECT MATERIAL_ID FROM ALL_BLUEPRINT_MATERIALS WHERE BLUEPRINT_ID = {0})"
        DBCommand = New SQLiteCommand(String.Format(SQL, BPID), EVEDB.DBREf)
        readerBP = DBCommand.ExecuteReader

        If readerBP.Read Then
            HasComponents = True
        Else
            HasComponents = False
        End If

        readerBP.Close()

        ' Add components as a manufacturing facility option if this bp has any
        If HasComponents Then

            SQL = ""
            If UserManufacturingTabSettings.BuildT2T3Materials = BuildMatType.ProcessedMaterials Then
                SQL = "SELECT DISTINCT 'X' FROM ALL_BLUEPRINT_MATERIALS WHERE PRODUCT_ID IN "
                SQL &= "(SELECT ITEM_ID FROM ALL_BLUEPRINTS "
                SQL &= "WHERE ITEM_ID IN (SELECT MATERIAL_ID FROM ALL_BLUEPRINT_MATERIALS WHERE BLUEPRINT_ID = {0} "
                SQL &= "AND MATERIAL_GROUP IN ('Composite')))"
            ElseIf UserManufacturingTabSettings.BuildT2T3Materials = BuildMatType.RawMaterials Then
                SQL = "SELECT DISTINCT 'X' FROM ALL_BLUEPRINT_MATERIALS WHERE PRODUCT_ID IN "
                SQL &= "(SELECT ITEM_ID FROM ALL_BLUEPRINTS WHERE ITEM_ID IN "
                SQL &= "(SELECT MATERIAL_ID FROM ALL_BLUEPRINT_MATERIALS WHERE BLUEPRINT_ID = {0} "
                SQL &= "AND MATERIAL_GROUP IN ('Composite','Hybrid Polymers','Intermediate Materials','Biochemical Material','Harvestable Cloud'))"
            End If

            If SQL <> "" Then
                DBCommand = New SQLiteCommand(String.Format(SQL, BPID), EVEDB.DBREf)
                readerBP = DBCommand.ExecuteReader

                readerBP.Close()
            End If
        End If

        LoadingActivities = False

    End Sub
    Private Sub cmbFacilityActivities_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        If Not LoadingActivities And Not FirstLoad Then
            SelectedProductionType = GetProductionType(SelectedBPGroupID, SelectedBPCategoryID, ActivityManufacturing)

            ' If they switch the activity and it changed from the previous, then load the selected facility for this activity
            If SelectedProductionType <> PreviousProductionType Then
                PreviousProductionType = SelectedProductionType

                ' Load the facility for this activity and flag that it was loaded from this combo
                Call LoadFacility(SelectedBPID, SelectedBPGroupID, SelectedBPCategoryID, SelectedBPTech, False, True)

                ' Reset all previous to current list, since all the combos should be loaded
                PreviousFacilityType = GetFacilityTypeCode("Station")
                PreviousEquipment = cmbFacility.Text
                PreviousRegion = cmbFacilityRegion.Text
                PreviousSystem = cmbFacilitySystem.Text
            End If

            ' Make sure the usage is updated
            Call frmMain.UpdateBPPriceLabels()

        End If
    End Sub

    Private Sub cmbFacilityActivities_DropDown(sender As Object, e As System.EventArgs)
        PreviousActivity = ActivityManufacturing
    End Sub

    Private Sub cmbFacilityActivities_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    ' Loads the facility types in the sent combo
    Public Sub LoadFacilityTypes(FacilityProductionType As ProductionType, FacilityActivity As String)
        Dim Station As String = GetFacilityNamefromCode(FacilityTypes.Station)
        Dim NoneFacility As String = GetFacilityNamefromCode(FacilityTypes.None)

        LoadingFacilityTypes = True
        LoadingRegions = True
        LoadingSystems = True
        LoadingFacilities = True

        ' Only reset if they changed it
        If FacilityProductionType <> PreviousProductionType Or FacilityActivity <> PreviousActivity Then
            ' Reset all other dropdowns
            cmbFacilityRegion.Items.Clear()
            cmbFacilityRegion.Text = InitialRegionComboText
            cmbFacilityRegion.Enabled = False
            cmbFacilitySystem.Items.Clear()
            cmbFacilitySystem.Text = InitialSolarSystemComboText
            cmbFacilitySystem.Enabled = False
            cmbFacility.Items.Clear()
            cmbFacility.Text = InitialFacilityComboText
            ' Reset the facility so it can load later
            PreviousEquipment = InitialFacilityComboText
            cmbFacility.Enabled = False

            PreviousProductionType = FacilityProductionType
            PreviousActivity = FacilityActivity

        End If

        LoadingFacilityTypes = False
        LoadingRegions = False
        LoadingSystems = False
        LoadingFacilities = False

        Call ResetComboLoadVariables(False, False, False)

    End Sub
    Private Sub cmbFacilityType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        ' Don't do anything if it's the same as the old type
        If PreviousFacilityType <> GetFacilityTypeCode("Station") Then
            ' Might not want to set a facility for copy or invention - "None" is an option for these two activities
            If Not LoadingFacilityTypes And Not FirstLoad And GetFacilityTypeCode("Station") <> FacilityTypes.None Then

                Call LoadFacilityRegions(SelectedBPGroupID, SelectedBPCategoryID, True, ActivityManufacturing)
                Call cmbFacilityRegion.Focus()

            ElseIf GetFacilityTypeCode("Station") = FacilityTypes.None Then ' Invention or Copy facility - set to none

                Call SetNoFacility()

                ' Save the facility locally
                Call DisplayFacilityBonus(SelectedProductionType, SelectedBPGroupID, SelectedBPCategoryID, ActivityManufacturing,
                                          GetFacilityTypeCode("Station"), cmbFacility.Text)
            End If

            ' Anytime this changes, set all the other ME/TE boxes to not viewed
            SelectedFacility.FullyLoaded = False
            PreviousFacilityType = GetFacilityTypeCode("Station")
            ' Reset the previous records
            PreviousEquipment = ""
            PreviousRegion = ""
            PreviousSystem = ""

        End If

        Call SetResetRefresh()

    End Sub

    Private Sub cmbFacilityType_DropDown(sender As Object, e As System.EventArgs)
        PreviousFacilityType = GetFacilityTypeCode("Station")
    End Sub

    Private Sub cmbFacilityType_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub


    ' Based on the selections, load the region combo
    Public Sub LoadFacilityRegions(ItemGroupID As Integer, ItemCategoryID As Integer, NewFacility As Boolean, ByRef FacilityActivity As String)
        Dim SQL As String = ""

        LoadingRegions = True
        LoadingSystems = True
        LoadingFacilities = True

        cmbFacilityRegion.Items.Clear()

        ' Load regions from the facilities table - only load regions for our activity type and item group/category
        Select Case StationFacility

            Case StationFacility

                ' Load the Stations in system for the activity we are doing
                SQL = "SELECT DISTINCT regionName AS REGION_NAME FROM STATIONS, STATION_SERVICES, REGIONS "
                SQL &= "WHERE STATIONS.STATION_ID = STATION_SERVICES.STATION_ID "
                SQL &= "AND STATIONS.REGION_ID = REGIONS.regionID "
                SQL &= "AND regionName NOT IN ('A821-A','J7HZ-F','PR-01','UUA-F4') AND regionName NOT LIKE 'ADR%' "

                Select Case FacilityActivity
                    Case ActivityManufacturing, ActivityComponentManufacturing, ActivityCapComponentManufacturing
                        SQL = SQL & "AND SERVICE_ID = " & CStr(StationServices.Factory)
                    Case ActivityCopying, ActivityInvention
                        SQL = SQL & "AND SERVICE_ID = " & CStr(StationServices.Laboratory)
                    Case ActivityReprocessing
                        SQL = SQL & "AND SERVICE_ID = " & CStr(StationServices.ReprocessingPlant)
                End Select

            Case StructureFacility
                ' For Upwell Structures, load all regions as options, but adding only one wormhole region option and don't show Jove regions
                SQL = "SELECT DISTINCT CASE WHEN (REGIONS.regionID >=11000000 and REGIONS.regionid <=11000030) THEN 'Wormhole Space' ELSE regionName END AS REGION_NAME "
                SQL = SQL & "FROM REGIONS, SOLAR_SYSTEMS "
                SQL = SQL & "WHERE SOLAR_SYSTEMS.regionID = REGIONS.regionID "
                SQL = SQL & "AND (factionID <> 500005 OR factionID IS NULL) "
                SQL = SQL & "AND regionName NOT IN ('A821-A','J7HZ-F','PR-01','UUA-F4') AND regionName NOT LIKE 'ADR%' "

                ' Make sure the region listed has at least one system not in the disallowed anchoring lists
                ' Upwell Structures can be anchored almost anywhere except starter systems, trade hubs, and shattered wormholes (including Thera)
                ' Check both disallowable anchor tables
                SQL = SQL & "AND (solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_CATEGORIES WHERE CATEGORY_ID = 65) AND "
                SQL = SQL & "solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_GROUPS WHERE GROUP_ID = 65)) "

                ' For supers, only show null regions where you can have sov (no factionID excludes NPC null, etc)
                If ItemGroupID = ItemIDs.SupercarrierGroupID Or ItemGroupID = ItemIDs.TitanGroupID Then
                    SQL = SQL & " AND security <= 0.0 AND factionID IS NULL AND regionName <> 'Wormhole Space' "
                ElseIf ItemGroupID = ItemIDs.DreadnoughtGroupID Or ItemGroupID = ItemIDs.CarrierGroupID Or ItemGroupID = ItemIDs.CapitalIndustrialShipGroupID Or ItemGroupID = ItemIDs.FAXGroupID Or IsReaction(ItemGroupID) Then
                    ' For caps and reactions, only show low sec
                    SQL = SQL & " AND security < .45"
                End If

        End Select

        SQL = SQL & " GROUP BY REGION_NAME "

        Dim rsLoader As SQLiteDataReader

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsLoader = DBCommand.ExecuteReader

        While rsLoader.Read
            cmbFacilityRegion.Items.Add(rsLoader.GetString(0))
        End While

        rsLoader.Close()

        ' Enable the region combo
        cmbFacilityRegion.Enabled = True

        ' Only turn off everything if it's set to select region
        If NewFacility Then
            cmbFacilitySystem.Items.Clear()
            cmbFacilitySystem.Text = InitialSolarSystemComboText
            cmbFacilitySystem.Enabled = False
            cmbFacility.Items.Clear()
            cmbFacility.Text = InitialFacilityComboText
            ' Reset the facility so it can load later
            PreviousEquipment = InitialFacilityComboText
            cmbFacility.Enabled = False
        End If

        ' Only reset the region if the current selected region is not in list, also if it is in list, enable solarsystem
        If Not cmbFacilityRegion.Items.Contains(cmbFacilityRegion.Text) Then
            cmbFacilityRegion.Text = "Select Region"
        Else
            cmbFacilitySystem.Enabled = True
        End If

        LoadingRegions = False
        LoadingSystems = False
        LoadingFacilities = False

        Call ResetComboLoadVariables(True, False, False)

    End Sub

    Private Sub cmbFacilityRegion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFacilityRegion.SelectedIndexChanged
        If Not LoadingRegions And Not FirstLoad And PreviousRegion <> cmbFacilityRegion.Text Then
            Call LoadFacilitySystems(SelectedBPGroupID, SelectedBPCategoryID, True, ActivityManufacturing)
            Call cmbFacilitySystem.Focus()
            SelectedFacility.FullyLoaded = False
            PreviousRegion = cmbFacilityRegion.Text
        End If

        Call SetResetRefresh()

    End Sub
    Private Sub cmbFacilityRegion_DropDown(sender As Object, e As System.EventArgs) Handles cmbFacilityRegion.DropDown
        ' If you drop down, don't show the text window
        cmbFacilityRegion.AutoCompleteMode = AutoCompleteMode.None

        If Not FirstLoad And Not FacilityRegionsLoaded Then
            PreviousRegion = cmbFacilityRegion.Text
            ' Save the current
            PreviousRegion = cmbFacilityRegion.Text

            Call LoadFacilityRegions(SelectedBPGroupID, SelectedBPCategoryID, False, ActivityManufacturing)

        End If
    End Sub
    Private Sub cmbFacilityRegion_GotFocus(sender As Object, e As EventArgs) Handles cmbFacilityRegion.GotFocus
        Call cmbFacilityRegion.SelectAll()
    End Sub
    Private Sub cmbFacilityRegion_LostFocus(sender As Object, e As EventArgs) Handles cmbFacilityRegion.LostFocus
        cmbFacilitySystem.SelectionLength = 0
        If Trim(cmbFacilityRegion.Text) = "" Then
            cmbFacilityRegion.Text = PreviousRegion
        End If
        ' Look up entered item to make sure it's in the list, if not, then auto select
        'If Not cmbFacilityRegion.Items.Contains(cmbFacilityRegion.Text) Then
        '    If SelectedFacility.RegionName <> InitialRegionComboText Then
        '        cmbFacilityRegion.Text = SelectedFacility.RegionName
        '    Else
        '        ' Select the first thing 
        '        cmbFacilityRegion.Text = cmbFacilityRegion.Items(0).ToString
        '    End If
        'Else
        '    If Not LoadingRegions And Not FirstLoad And PreviousRegion <> cmbFacilityRegion.Text Then
        '        ' Need to load up the rest of the combos
        '        Call LoadFacilitySystems(SelectedBPGroupID, SelectedBPCategoryID, True, cmbFacilityActivities.Text)
        '    End If
        'End If
    End Sub
    Private Sub cmbFacilityRegion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbFacilityRegion.KeyPress
        e.Handled = True
    End Sub


    ' Based on the selections, load the systems combo
    Public Sub LoadFacilitySystems(ItemGroupID As Integer, ItemCategoryID As Integer, NewFacility As Boolean, ByRef FacilityActivity As String)
        Dim SQL As String = ""

        LoadingSystems = True
        LoadingFacilities = True

        cmbFacilitySystem.Items.Clear()

        Select Case StationFacility

            Case StationFacility
                If FacilityActivity <> ActivityReprocessing Then
                    Dim ServiceIDSQL As String = ""
                    ' Load the Stations in system for the activity we are doing
                    SQL = "SELECT DISTINCT solarSystemName AS SSN, CASE WHEN COST_INDEX IS NOT NULL THEN COST_INDEX ELSE 0 END AS CI "
                    SQL &= "FROM STATION_SERVICES, SOLAR_SYSTEMS, STATIONS "
                    SQL &= "LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ON INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = STATIONS.SOLAR_SYSTEM_ID "
                    Select Case FacilityActivity
                        Case ActivityManufacturing, ActivityComponentManufacturing, ActivityCapComponentManufacturing
                            SQL &= "AND ACTIVITY_ID = " & CStr(IndustryActivities.Manufacturing)
                            ServiceIDSQL = " AND SERVICE_ID = " & CStr(StationServices.Factory)
                        Case ActivityCopying
                            SQL &= "AND ACTIVITY_ID = " & CStr(IndustryActivities.Copying)
                            ServiceIDSQL = " AND SERVICE_ID = " & CStr(StationServices.Laboratory)
                        Case ActivityInvention
                            SQL &= "AND ACTIVITY_ID = " & CStr(IndustryActivities.Invention)
                            ServiceIDSQL = " AND SERVICE_ID = " & CStr(StationServices.Laboratory)
                        Case ActivityReactions ' Shouldn't return anything until you can do reactions in stations
                            SQL &= "AND ACTIVITY_ID = " & CStr(IndustryActivities.Reactions)
                            ServiceIDSQL = " AND SERVICE_ID = " & CStr(StationServices.Factory)
                    End Select
                    SQL &= " WHERE STATIONS.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID "
                    SQL &= " AND STATIONS.STATION_ID = STATION_SERVICES.STATION_ID "
                    SQL &= " AND REGION_ID = " & CStr(GetRegionID(cmbFacilityRegion.Text)) & " "
                    SQL &= ServiceIDSQL
                Else
                    ' Refining doesn't have a cost index so just build a different query
                    SQL = "SELECT DISTINCT solarSystemName AS SSN, 0 AS CI "
                    SQL &= "FROM STATION_SERVICES, SOLAR_SYSTEMS, STATIONS "
                    SQL &= "WHERE STATIONS.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID "
                    SQL &= "AND STATIONS.STATION_ID = STATION_SERVICES.STATION_ID "
                    SQL &= "AND SERVICE_ID = " & CStr(StationServices.ReprocessingPlant) & " "
                    SQL &= "AND REGION_ID = " & CStr(GetRegionID(cmbFacilityRegion.Text))
                End If

            Case StructureFacility
                If FacilityActivity <> ActivityReprocessing Then
                    SQL = "SELECT DISTINCT solarSystemName AS SSN, CASE WHEN COST_INDEX IS NOT NULL THEN COST_INDEX ELSE 0 END AS CI "
                    SQL = SQL & "FROM REGIONS, SOLAR_SYSTEMS "
                    SQL = SQL & "LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ON solarSystemID = SOLAR_SYSTEM_ID "

                    Select Case FacilityActivity
                        Case ActivityManufacturing, ActivityComponentManufacturing, ActivityCapComponentManufacturing
                            SQL = SQL & "AND ACTIVITY_ID = " & CStr(IndustryActivities.Manufacturing) & " "
                        Case ActivityCopying
                            SQL = SQL & "AND ACTIVITY_ID = " & CStr(IndustryActivities.Copying) & " "
                        Case ActivityInvention
                            SQL = SQL & "AND ACTIVITY_ID = " & CStr(IndustryActivities.Invention) & " "
                        Case ActivityReactions
                            SQL = SQL & "AND ACTIVITY_ID = " & CStr(IndustryActivities.Reactions) & " "
                    End Select
                Else
                    ' Refining doesn't have a cost index so just build a different query
                    SQL = "SELECT DISTINCT solarSystemName AS SSN, 0 AS CI "
                    SQL &= "FROM REGIONS, SOLAR_SYSTEMS "
                End If

                SQL = SQL & "WHERE SOLAR_SYSTEMS.regionID = REGIONS.regionID "

                ' Upwell Structures can be anchored almost anywhere except starter systems, trade hubs, and shattered wormholes (including Thera)
                ' Check both disallowable anchor tables
                SQL = SQL & "AND (solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_CATEGORIES WHERE CATEGORY_ID = 65) AND "
                SQL = SQL & "solarSystemID NOT IN (SELECT SOLAR_SYSTEM_ID FROM MAP_DISALLOWED_ANCHOR_GROUPS WHERE GROUP_ID = 65)) "

                If cmbFacilityRegion.Text = "Wormhole Space" Then
                    SQL = SQL & "AND SOLAR_SYSTEMS.regionID >=11000000 and SOLAR_SYSTEMS.regionid <=11000030 "
                Else
                    ' For an upwell, load all systems that have records linked
                    SQL = SQL & "AND regionName = '" & FormatDBString(cmbFacilityRegion.Text) & "' "
                End If

                ' For supers, only show null regions where you can have sov (no factionID excludes NPC null, etc)
                If ItemGroupID = ItemIDs.SupercarrierGroupID Or ItemGroupID = ItemIDs.TitanGroupID Then
                    SQL = SQL & "AND security <= 0.0 AND factionID IS NULL AND regionName <> 'Wormhole Space' "
                ElseIf (ItemGroupID = ItemIDs.DreadnoughtGroupID Or ItemGroupID = ItemIDs.CarrierGroupID Or
                    ItemGroupID = ItemIDs.CapitalIndustrialShipGroupID Or ItemGroupID = ItemIDs.FAXGroupID Or
                    IsReaction(ItemGroupID)) And FacilityActivity = ActivityManufacturing Or FacilityActivity = ActivityReactions Then
                    ' For caps and reactions, only show low sec
                    SQL = SQL & "AND security < .45 "
                End If

        End Select

        SQL = SQL & " GROUP BY SSN, CI"

        Dim rsLoader As SQLiteDataReader
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsLoader = DBCommand.ExecuteReader

        While rsLoader.Read
            If FacilityActivity <> ActivityReprocessing Then
                cmbFacilitySystem.Items.Add(rsLoader.GetString(0) & " (" & FormatNumber(rsLoader.GetDouble(1), 3) & ")")
            Else
                cmbFacilitySystem.Items.Add(rsLoader.GetString(0))
            End If
        End While

        rsLoader.Close()

        ' Enable the system combo
        cmbFacilitySystem.Enabled = True

        ' Only turn off everything if it's set to select a system
        If NewFacility Then
            cmbFacility.Items.Clear()
            cmbFacility.Text = InitialFacilityComboText
            ' Reset the facility so it can load later
            PreviousEquipment = InitialFacilityComboText
            cmbFacility.Enabled = False
        End If

        ' Only reset the system if the current selected system is not in list, also if it is in list, enable facilty
        If Not cmbFacilitySystem.Items.Contains(cmbFacilitySystem.Text) Then
            cmbFacilitySystem.Text = InitialSolarSystemComboText
        Else
            cmbFacility.Enabled = True
        End If

        LoadingSystems = False
        LoadingFacilities = False

        Call ResetComboLoadVariables(False, True, False)

    End Sub

    Private Sub cmbFacilitySystem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFacilitySystem.SelectedIndexChanged
        Dim OverrideFacilityName As String = ""
        Dim Autoload As Boolean = False

        cmbFacilitySystem.SelectionLength = 0

        If Not LoadingSystems And Not FirstLoad And PreviousSystem <> cmbFacilitySystem.Text Then

            ' Load the facilities
            Call LoadFacilities(False, ActivityManufacturing, Autoload, OverrideFacilityName)

            If Autoload Then
                SelectedFacility.FullyLoaded = True
                ' Facility is loaded, so save it to default and dynamic variable
                Call SetFacility(SelectedFacility, SelectedProductionType, False, False)
            Else
                SelectedFacility.FullyLoaded = False
            End If

            Call cmbFacility.Focus()

            PreviousSystem = cmbFacilitySystem.Text
        End If

        Call SetResetRefresh()

    End Sub
    Private Sub cmbFacilitySystem_DropDown(sender As Object, e As System.EventArgs) Handles cmbFacilitySystem.DropDown
        ' If you drop down, don't show the text window
        cmbFacilitySystem.AutoCompleteMode = AutoCompleteMode.None

        If Not FacilitySystemsLoaded And Not FirstLoad Then
            PreviousSystem = cmbFacilitySystem.Text
            Call LoadFacilitySystems(SelectedBPGroupID, SelectedBPCategoryID, False, ActivityManufacturing)
        End If
    End Sub
    Private Sub cmbFacilitySystem_GotFocus(sender As Object, e As EventArgs) Handles cmbFacilitySystem.GotFocus
        Call cmbFacilitySystem.SelectAll()
    End Sub
    Private Sub cmbFacilitySystem_LostFocus(sender As Object, e As EventArgs) Handles cmbFacilitySystem.LostFocus
        cmbFacilitySystem.SelectionLength = 0
        If Trim(cmbFacilitySystem.Text) = "" Then
            cmbFacilitySystem.Text = PreviousSystem
        End If
    End Sub
    Private Sub cmbFacilitySystem_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbFacilitySystem.KeyPress
        e.Handled = True
    End Sub

    ' Based on the selections, load the facilities/arrays combo - an itemcategory or itemgroup id of -1 means to ignore it when filling arrays
    Private Sub LoadFacilities(NewFacility As Boolean, ByRef FacilityActivity As String,
                                 ByRef AutoLoadFacility As Boolean, Optional OverrideFacilityName As String = "")
        Dim SQL As String = ""
        LoadingFacilities = True

        Dim SystemName As String
        If cmbFacilitySystem.Text.Contains("(") Then
            SystemName = cmbFacilitySystem.Text.Substring(0, InStr(cmbFacilitySystem.Text, "(") - 2)
        Else
            SystemName = cmbFacilitySystem.Text
        End If

        Dim LocalFacilityType As FacilityTypes = GetFacilityTypeCode("Station")

        Select Case LocalFacilityType

            Case FacilityTypes.Station
                ' Load the Stations in system for the activity we are doing
                SQL = "SELECT STATION_NAME AS FACILITY_NAME, STATIONS.STATION_ID FROM STATIONS, STATION_SERVICES "
                SQL &= "WHERE STATIONS.STATION_ID = STATION_SERVICES.STATION_ID "

                Select Case FacilityActivity
                    Case ActivityManufacturing, ActivityComponentManufacturing, ActivityCapComponentManufacturing
                        SQL = SQL & "AND SERVICE_ID = " & CStr(StationServices.Factory)
                End Select

                SQL = SQL & " AND REGION_ID = " & CStr(GetRegionID(cmbFacilityRegion.Text))
                SQL = SQL & " AND SOLAR_SYSTEM_ID = " & CStr(GetSolarSystemID(SystemName))

        End Select

        ' This is helpful if we auto-load (Capital array before super capital, equipment array before rapid equipment) to choose the one more likely
        SQL = SQL & " ORDER BY FACILITY_NAME"

        Dim rsLoader As SQLiteDataReader
        Dim rsCheck As SQLiteDataReader
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsLoader = DBCommand.ExecuteReader

        cmbFacility.Enabled = True
        cmbFacility.Items.Clear()

        Dim AutoLoadName As String = ""
        Dim i As Integer = 0

        While rsLoader.Read
            If rsLoader.GetString(0).Contains("Thukker") And GetFacilityTypeCode("Station") = FacilityTypes.POS Then
                ' Need to make sure it's a low sec system selected
                Dim security As Double = GetSolarSystemSecurityLevel(SystemName)

                If security <> -1 Then
                    If security < 0.45 Then
                        ' Thukker is only low sec - no easy way to weed this out
                        cmbFacility.Items.Add(rsLoader.GetString(0))
                    End If
                Else
                    ' Allow it
                    cmbFacility.Items.Add(rsLoader.GetString(0))
                End If
            ElseIf FactionCitadelList.Contains(rsLoader.GetInt32(1)) Then
                ' These are only in nullsec space (if we can look up in ESI then later maybe)
                SQL = "SELECT security, factionID FROM REGIONS, SOLAR_SYSTEMS WHERE REGIONS.regionID = SOLAR_SYSTEMS.regionID "
                SQL &= "AND factionID IS NULL AND regionName NOT LIKE '%-R%' " ' -R region names are wormhole regions
                SQL &= "AND security <= 0.0 AND SOLAR_SYSTEMS.solarSystemName = '" & SystemName & "'"

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsCheck = DBCommand.ExecuteReader

                If rsCheck.Read Then
                    ' no sov and it's nullsec, so add it
                    cmbFacility.Items.Add(rsLoader.GetString(0))
                End If
                rsCheck.Close()
            Else
                cmbFacility.Items.Add(rsLoader.GetString(0))
            End If

            i += 1 ' get the count
            ' Load the first one - auto choose subsystem array over advanced medium array unless already selected
            If AutoLoadName = "" Or (rsLoader.GetString(0) = "Subsystem Assembly Array" And OverrideFacilityName = "") Then
                AutoLoadName = rsLoader.GetString(0)
            End If
        End While

        rsLoader.Close()

        ' Always load the facility if there is only one and we have a reference to auto load or we are loading a specific facility
        If (i = 1 And Not IsNothing(AutoLoadFacility)) Or cmbFacility.Items.Contains(OverrideFacilityName) _
            Or cmbFacility.Items.Contains(cmbFacility.Text) Or OverrideFacilityName = "CalcBase" Then
            ' Check the override, if they want to use a rapid assembly it will override here, otherwise the other facility types should handle it (e.g. super, cap, etc)
            If OverrideFacilityName <> "" And cmbFacility.Items.Contains(OverrideFacilityName) Then
                cmbFacility.Text = OverrideFacilityName
            ElseIf cmbFacility.Items.Contains(cmbFacility.Text) Then
                ' Leave it as is
                Application.DoEvents()
            Else
                cmbFacility.Text = AutoLoadName
            End If

            AutoLoadFacility = True
            ' Display bonuses - Need to load everything since the array won't change to cause it to reload
            Call DisplayFacilityBonus(SelectedProductionType, SelectedBPGroupID, SelectedBPCategoryID, ActivityManufacturing,
                                      GetFacilityTypeCode("Station"), cmbFacility.Text)
        Else
            If Not cmbFacility.Items.Contains(cmbFacility.Text) Then
                ' Only load if the item isn't in the combo
                Select Case GetFacilityTypeCode("Station")
                    Case FacilityTypes.Station
                        cmbFacility.Text = "Select Station"
                End Select

            End If

            AutoLoadFacility = False

        End If

        ' Users might select the facility drop down first, so reload all others
        Call ResetComboLoadVariables(False, False, True)

        LoadingFacilities = False

        rsLoader.Close()
        rsLoader = Nothing
        DBCommand = Nothing

    End Sub
    Private Sub cmbFacilityorArray_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFacility.SelectedIndexChanged

        If Not LoadingFacilities And Not FirstLoad And PreviousEquipment <> cmbFacility.Text Then
            Call DisplayFacilityBonus(SelectedProductionType, SelectedBPGroupID, SelectedBPCategoryID, ActivityManufacturing,
                                          GetFacilityTypeCode("Station"), cmbFacility.Text)

            PreviousEquipment = cmbFacility.Text
        End If

        Call SetResetRefresh()

    End Sub
    Private Sub cmbFacilityorArray_DropDown(sender As Object, e As System.EventArgs) Handles cmbFacility.DropDown
        ' If you drop down, don't show the text window
        cmbFacility.AutoCompleteMode = AutoCompleteMode.None

        If Not FacilityorArrayLoaded And Not FirstLoad Then
            PreviousEquipment = cmbFacility.Text
            Call LoadFacilities(False, ActivityManufacturing, False, "")
        End If
    End Sub
    Private Sub cmbFacilityorArray_GotFocus(sender As Object, e As EventArgs) Handles cmbFacility.GotFocus
        Call cmbFacility.SelectAll()
    End Sub
    Private Sub cmbFacilityorArray_LostFocus(sender As Object, e As EventArgs) Handles cmbFacility.LostFocus
        cmbFacility.SelectionLength = 0
        If Trim(cmbFacility.Text) = "" Then
            cmbFacility.Text = PreviousEquipment
        End If
    End Sub
    Private Sub cmbFacilityorArray_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbFacility.KeyPress
        e.Handled = True
    End Sub
    Private Sub loadDefaultFacility()
        ' Load the default facility for the selected activity if it's not already the default
        LoadingActivities = True ' Don't trigger a combo load yet
        Dim SelectedFacility As New IndustryFacility
        Dim SelectedActivity As String = ""
        Dim BPID As Integer = 0
        Dim ItemGroupID As Integer = 0
        Dim ItemCategoryID As Integer = 0
        Dim TechLevel As Integer = 0
        Dim Activity As String = ""
        Dim OriginalProductionType As ProductionType = SelectedProductionType

        SelectedFacility = SelectFacility(OriginalProductionType, True)

        If Not IsNothing(SelectedBlueprint) Then
            With SelectedBlueprint
                BPID = .GetBPID
                ItemGroupID = .GetItemGroupID
                ItemCategoryID = .GetItemCategoryID
                TechLevel = .GetTechLevel
            End With
        ElseIf SelectedLocation = ProgramLocation.ManufacturingTab Then
            BPID = 0 ' this only matters for the activity combo
            ' For the manufacturing tab, we manually put in the IDs, so get the data first
            Call GetFacilityBPItemData(OriginalProductionType, ItemGroupID, ItemCategoryID, TechLevel, Activity)
        End If

        ' Load up the default based on the BPID - assume we selected from combo to bypass loading activities again
        Call LoadFacility(BPID, ItemGroupID, ItemCategoryID, TechLevel, True, True)

        ' Set the default based on the checkbox 
        Call SetFacility(SelectedFacility, OriginalProductionType, False, False)

        LoadingActivities = False
    End Sub

    ' Displays the bonus for the facility selected in the facility or array combo
    Private Sub DisplayFacilityBonus(BuildType As ProductionType, ItemGroupID As Integer, ItemCategoryID As Integer, Activity As String,
                                    FacilityType As FacilityTypes, FacilityName As String)
        Dim SQL As String = ""
        Dim rsLoader As SQLiteDataReader

        Dim FacilityID As Long
        Dim DFMaterialMultiplier As Double = 0
        Dim DFTimeMultiplier As Double = 0
        Dim DFCostMultiplier As Double = 0
        Dim DFTax As Double = 0
        Dim SavedMaterialMultiplier As Double = -1
        Dim SavedTimeMultiplier As Double = -1
        Dim SavedCostMultiplier As Double = -1
        Dim SavedTax As Double = -1

        Dim StructureModifier As Double = 0
        Dim TempDefaultFacility As New IndustryFacility

        Dim CostText As String
        Dim TaxText As String
        Dim MMText As String
        Dim TMText As String

        ' Get the facility ID first
        ' Not in there for either character or default, so use the defaults
        If FacilityType = FacilityTypes.Station Then
            ' Load the Stations in system for the activity we are doing
            SQL = "SELECT STATION_ID FROM STATIONS WHERE STATION_NAME ='" & FormatDBString(FacilityName) & "' "
        ElseIf FacilityType = FacilityTypes.UpwellStructure Then
            SQL = "SELECT UPWELL_STRUCTURE_TYPE_ID FROM UPWELL_STRUCTURES WHERE UPWELL_STRUCTURE_NAME = '" & FormatDBString(FacilityName) & "' "
        End If

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsLoader = DBCommand.ExecuteReader
        rsLoader.Read()

        If rsLoader.HasRows Then
            FacilityID = rsLoader.GetInt64(0)
        Else
            FacilityID = -1
        End If

        rsLoader.Close()

        Dim CharID As String = ""

        ' See what type of character ID
        CharID = CStr(SelectedCharacter.ID)

        ' Process system if needed
        Dim SystemName As String
        If cmbFacilitySystem.Text.Contains("(") Then
            SystemName = cmbFacilitySystem.Text.Substring(0, InStr(cmbFacilitySystem.Text, "(") - 2)
        Else
            SystemName = cmbFacilitySystem.Text
        End If

        Dim SystemID As Long = GetSolarSystemID(SystemName)

        If FacilityType <> FacilityTypes.None Then

            ' First, see if this facility is a saved facility, and use the values saved in the table
            SQL = "SELECT FACILITY_ID, FACILITY_TAX, MATERIAL_MULTIPLIER, TIME_MULTIPLIER, COST_MULTIPLIER "
            SQL &= "FROM SAVED_FACILITIES "
            SQL &= "WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND FACILITY_TYPE = {2} AND FACILITY_VIEW = {3} "
            SQL &= "AND REGION_ID = " & CStr(GetRegionID(cmbFacilityRegion.Text)) & " "
            SQL &= "AND SOLAR_SYSTEM_ID = " & CStr(SystemID) & " "
            SQL &= "AND FACILITY_ID = {4}"

            ' First look up the character to see if it's saved there first (initially only do one set of facilities then allow by character via a setting)
            DBCommand = New SQLiteCommand(String.Format(SQL, CharID, CStr(BuildType), CStr(FacilityType), CStr(SelectedLocation), CStr(FacilityID)), EVEDB.DBREf)
            rsLoader = DBCommand.ExecuteReader
            rsLoader.Read()

            If Not rsLoader.HasRows Then
                ' Need to look up the default - CharID = 0
                rsLoader.Close()
                DBCommand = New SQLiteCommand(String.Format(SQL, "0", CStr(BuildType), CStr(FacilityType), CStr(SelectedLocation), CStr(FacilityID)), EVEDB.DBREf)
                rsLoader = DBCommand.ExecuteReader
                rsLoader.Read()
            End If

            '  Load values from the saved facility
            If rsLoader.HasRows Then

                ' Save the values from the saved information - saved facility values
                If Not IsDBNull(rsLoader.GetValue(1)) Then
                    SavedTax = rsLoader.GetDouble(1)
                End If

                If Not IsDBNull(rsLoader.GetValue(2)) Then
                    SavedMaterialMultiplier = rsLoader.GetDouble(2)
                End If

                If Not IsDBNull(rsLoader.GetValue(3)) Then
                    SavedTimeMultiplier = rsLoader.GetDouble(3)
                End If

                If Not IsDBNull(rsLoader.GetValue(4)) Then
                    SavedCostMultiplier = rsLoader.GetDouble(4)
                End If
            End If

            rsLoader.Close()

            If FacilityID <> -1 Then
                ' Pull default data for ME/TE/CE
                Select Case FacilityType
                    Case FacilityTypes.Station
                        SelectedFacility.BaseTax = DefaultStationTaxRate
                        ' For production in stations, they are always 1
                        SelectedFacility.BaseME = 1
                        SelectedFacility.BaseTE = 1
                        SelectedFacility.BaseCost = 1
                End Select
            Else
                ' Set the facility to none if not found
                FacilityType = FacilityTypes.None
            End If

        End If

        ' None selected or not found
        If FacilityType = FacilityTypes.None Then
            Dim Defaults As New ProgramSettings
            FacilityName = None
            FacilityID = 0
            SelectedFacility.BaseME = Defaults.FacilityDefaultMM
            SelectedFacility.BaseTE = Defaults.FacilityDefaultTM
            SelectedFacility.BaseCost = Defaults.FacilityDefaultCM
            SelectedFacility.BaseTax = Defaults.FacilityDefaultTax
        End If

        ' Now that we have everything, load the full facility into the appropriate selected facility to use later
        With SelectedFacility

            DFMaterialMultiplier = .BaseME
            DFTimeMultiplier = .BaseTE
            DFCostMultiplier = .BaseCost
            DFTax = .BaseTax

            .ActivityCostPerSecond = 0
            Select Case Activity
                Case ActivityManufacturing, ActivityComponentManufacturing, ActivityCapComponentManufacturing
                    .ActivityID = IndustryActivities.Manufacturing
            End Select

            .Activity = Activity
            .FacilityID = FacilityID
            .FacilityName = FacilityName
            .FacilityType = FacilityType
            .RegionName = cmbFacilityRegion.Text
            .SolarSystemName = cmbFacilitySystem.Text
            .SolarSystemID = SystemID
            .FacilityProductionType = BuildType

            ' Set the final rates on what we calculated or saved
            If SavedTax = -1 Then
                .TaxRate = DFTax
            Else
                .TaxRate = SavedTax
            End If

            If SavedMaterialMultiplier = -1 Then
                .MaterialMultiplier = DFMaterialMultiplier
            Else
                .MaterialMultiplier = SavedMaterialMultiplier
            End If

            If SavedTimeMultiplier = -1 Then
                .TimeMultiplier = DFTimeMultiplier
            Else
                .TimeMultiplier = SavedTimeMultiplier
            End If

            If SavedCostMultiplier = -1 Then
                .CostMultiplier = DFCostMultiplier
            Else
                .CostMultiplier = SavedCostMultiplier
            End If

            If FacilityType <> FacilityTypes.None Then
                ' Quick look up for the solarsystemid and region id
                SQL = "SELECT security, regionID FROM SOLAR_SYSTEMS WHERE solarSystemID = " & CStr(SystemID)

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsLoader = DBCommand.ExecuteReader
                rsLoader.Read()

                .SolarSystemID = SystemID
                .SolarSystemSecurity = rsLoader.GetDouble(0)
                .RegionID = rsLoader.GetInt64(1)
                rsLoader.Close()

                ' Now look up the cost index 
                SQL = "SELECT COST_INDEX FROM INDUSTRY_SYSTEMS_COST_INDICIES "
                SQL &= "WHERE INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = " & .SolarSystemID & " "
                SQL &= "AND INDUSTRY_SYSTEMS_COST_INDICIES.ACTIVITY_ID = " & .ActivityID & " "

                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsLoader = DBCommand.ExecuteReader

                If rsLoader.Read() Then
                    .CostIndex = rsLoader.GetDouble(0)
                Else
                    .CostIndex = 0
                End If

                rsLoader.Close()
            Else
                .SolarSystemID = 0
                .RegionID = 0
                .CostIndex = 0
            End If

            MMText = FormatPercent(1 - SelectedFacility.MaterialMultiplier, 2)
            TMText = FormatPercent(1 - SelectedFacility.TimeMultiplier, 2)

            CostText = FormatPercent(1 - SelectedFacility.CostMultiplier, 2)
            TaxText = FormatPercent(SelectedFacility.TaxRate, 1)
        End With

        ' Fully loaded
        SelectedFacility.FullyLoaded = True

        ' Facility is loaded, so save it to default and dynamic variable
        Call SetFacility(SelectedFacility, BuildType, False, False)

        Application.DoEvents()

    End Sub
    Private Function GetSystemSecurityAttribute(SystemName As String) As ItemAttributes
        ' Get the system security first
        Dim security As Double = GetSolarSystemSecurityLevel(SystemName)

        If Not IsNothing(security) Then
            If security <= 0.0 Then
                Return ItemAttributes.nullSecModifier
            ElseIf security < 0.45 Then
                Return ItemAttributes.lowSecModifier
            Else
                Return ItemAttributes.hiSecModifier
            End If
        Else
            ' Just assume null
            Return ItemAttributes.nullSecModifier
        End If
    End Function

    ' Returns an array of rigs installed on the facility for info sent
    Private Function GetInstalledModules(ByVal Activity As String, ByVal FacilityID As Long, ByVal ItemGroupID As Integer,
                                         ByVal ItemCategoryID As Integer, ByVal SystemID As Long) As List(Of Integer)
        Dim SQL As String = ""
        Dim rsLoader As SQLiteDataReader
        Dim InstalledModules As New List(Of Integer)

        ' Save the current data - this will work for reactions since the groupID is the same for the item being made for lookup
        Dim TempBPGroupID As Integer = ItemGroupID
        Dim TempBPCategoryID As Integer = ItemCategoryID

        SQL = "SELECT INSTALLED_MODULE_ID FROM UPWELL_STRUCTURES_INSTALLED_MODULES, ENGINEERING_RIG_BONUSES "
        SQL &= "WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND PROGRAM_LOCATION = {3} AND FACILITY_ID = {4} "
        SQL &= "AND UPWELL_STRUCTURES_INSTALLED_MODULES.INSTALLED_MODULE_ID = ENGINEERING_RIG_BONUSES.typeID AND activityId = {7} "
        SQL &= "AND ((categoryID = {5} AND groupID IS NULL) OR (categoryID IS NULL AND groupID = {6}))"
        DBCommand = New SQLiteCommand(String.Format(SQL, SelectedCharacterID, CStr(SelectedProductionType), CStr(SystemID), CStr(SelectedLocation),
                                      CStr(FacilityID), CStr(TempBPCategoryID), CStr(TempBPGroupID), CStr(GetActivityID(Activity))), EVEDB.DBREf)
        rsLoader = DBCommand.ExecuteReader

        While rsLoader.Read()
            InstalledModules.Add(rsLoader.GetInt32(0))
        End While
        rsLoader.Close()

        Return InstalledModules

    End Function

    ' Returns the attribute and bonus for the rig ID and system security sent by reference
    Private Sub GetRigBonus(ByVal RigID As Integer, ByVal SecurityAttribute As Integer, ByRef Attribute As Integer, ByRef Bonus As Double)
        Dim SQL As String = ""
        Dim rsLoader As SQLiteDataReader

        ' Look up the bonus while adjusting for the type of space we are in
        SQL = "SELECT attributeID, ABS(value * (SELECT value FROM TYPE_ATTRIBUTES WHERE TYPEID = {0} AND ATTRIBUTEID = {1})/100) AS BONUS "
        SQL &= "FROM TYPE_ATTRIBUTES WHERE ATTRIBUTEID IN (2593,2594,2595,2713,2714,2653,717) "
        SQL &= "AND value <> 0 AND TYPEID = {0}"
        SQL = String.Format(SQL, RigID, CInt(SecurityAttribute))
        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsLoader = DBCommand.ExecuteReader

        If rsLoader.Read() Then
            Attribute = rsLoader.GetInt32(0)
            Bonus = rsLoader.GetDouble(1)
        Else
            Attribute = 0
            Bonus = 0
        End If

    End Sub

    ' Sets the sent facility To the one we are selecting And sets the Default 
    Private Sub SetFacility(ByVal SentFacility As IndustryFacility, BuildType As ProductionType,
                           ByVal CompareIncludeCostCheck As Boolean, ByVal CompareIncludeTimeCheck As Boolean)

        ' For checking change from stations to pos on  tab
        Dim PreviousFacility As New IndustryFacility

        Select Case BuildType
            Case ProductionType.Manufacturing
                PreviousFacility = CType(SelectedManufacturingFacility.Clone, IndustryFacility)
                SelectedManufacturingFacility = CType(SentFacility.Clone, IndustryFacility)
                If SelectedManufacturingFacility.IsEqual(DefaultManufacturingFacility) Then
                    SelectedManufacturingFacility.IsDefault = True
                    SentFacility.IsDefault = True
                Else
                    SelectedManufacturingFacility.IsDefault = False
                    SentFacility.IsDefault = False
                End If
            Case Else
                PreviousFacility = CType(SelectedManufacturingFacility.Clone, IndustryFacility)
                SelectedManufacturingFacility = SentFacility
                If SelectedManufacturingFacility.IsEqual(DefaultManufacturingFacility) Then
                    SelectedManufacturingFacility.IsDefault = True
                    SentFacility.IsDefault = True
                Else
                    SelectedManufacturingFacility.IsDefault = False
                    SentFacility.IsDefault = False
                End If
        End Select

        ' Save the selected facility locally
        SelectedFacility = CType(SentFacility.Clone, IndustryFacility)

    End Sub

#Region "Support Functions"

    ' Returns references to the GroupID, CategoryID, TechLevel, and Activity Combo Text when sent the production type
    Private Sub GetFacilityBPItemData(ByVal SentProductionType As ProductionType, ByRef GroupID As Integer,
                                      ByRef CategoryID As Integer, ByRef TechLevel As Integer, ByRef ActivityComboText As String)
        Select Case SentProductionType
            Case ProductionType.Manufacturing
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.FrigateGroupID
                TechLevel = BPTechLevel.T2
                ActivityComboText = ActivityManufacturing
            Case ProductionType.CapitalComponentManufacturing
                CategoryID = ItemIDs.CapitalComponentGroupID
                GroupID = ItemIDs.None
                TechLevel = BPTechLevel.T1
                ActivityComboText = ActivityCapComponentManufacturing
            Case ProductionType.ComponentManufacturing
                CategoryID = ItemIDs.ComponentCategoryID
                GroupID = ItemIDs.None
                TechLevel = BPTechLevel.T1
                ActivityComboText = ActivityComponentManufacturing
            Case ProductionType.CapitalManufacturing
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.CarrierGroupID
                TechLevel = BPTechLevel.T1
                ActivityComboText = ActivityManufacturing
            Case ProductionType.SuperManufacturing
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.SupercarrierGroupID
                TechLevel = BPTechLevel.T1
                ActivityComboText = ActivityManufacturing
            Case ProductionType.T3CruiserManufacturing
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.StrategicCruiserGroupID
                TechLevel = BPTechLevel.T3
                ActivityComboText = ActivityManufacturing
            Case ProductionType.SubsystemManufacturing
                CategoryID = ItemIDs.SubsystemCategoryID
                GroupID = ItemIDs.None
                TechLevel = BPTechLevel.T3
                ActivityComboText = ActivityManufacturing
            Case ProductionType.BoosterManufacturing
                CategoryID = ItemIDs.BoosterCategoryID
                GroupID = ItemIDs.BoosterGroupID
                TechLevel = BPTechLevel.T1
                ActivityComboText = ActivityManufacturing
            Case ProductionType.Copying
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.FrigateGroupID
                TechLevel = BPTechLevel.T2
                ActivityComboText = ActivityCopying
            Case ProductionType.Invention
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.FrigateGroupID
                TechLevel = BPTechLevel.T2
                ActivityComboText = ActivityInvention
            Case ProductionType.Reactions
                CategoryID = ItemIDs.None
                GroupID = ItemIDs.ReactionPolymersGroupID
                TechLevel = BPTechLevel.T1
                ActivityComboText = ActivityReactions
            Case ProductionType.T3Invention
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.TacticalDestroyerGroupID
                TechLevel = BPTechLevel.T3
                ActivityComboText = ActivityInvention
            Case ProductionType.T3DestroyerManufacturing
                CategoryID = ItemIDs.ShipCategoryID
                GroupID = ItemIDs.TacticalDestroyerGroupID
                TechLevel = BPTechLevel.T3
                ActivityComboText = ActivityManufacturing
        End Select

    End Sub

    ' Selects the facility and returns it and sets the activity on the facility found
    Private Function SelectFacility(ByVal BuildType As ProductionType, ByVal IsDefault As Boolean) As IndustryFacility

        Dim FacilityActivity As String = ""
        Dim ReturnFacility As New IndustryFacility

        If IsDefault Then
            ReturnFacility = CType(DefaultManufacturingFacility.Clone, IndustryFacility)
            FacilityActivity = ActivityManufacturing
        Else
            ReturnFacility = CType(SelectedManufacturingFacility.Clone, IndustryFacility)
            FacilityActivity = ActivityManufacturing
        End If

        ' Set the activity text here
        ReturnFacility.Activity = FacilityActivity

        Return ReturnFacility

    End Function

    ' Get the SQL based on activity and BP's
    Private Function GetBPGroupCategoryIDSQL(Activity As String, ItemCategoryID As Integer, ItemGroupID As Integer) As String
        Dim SQL As String = ""

        Select Case Activity
            Case ActivityManufacturing
                SQL = SQL & "ACTIVITY_ID = " & CStr(IndustryActivities.Manufacturing) & " "
                SQL = SQL & GetFacilityCatGroupIDSQL(ItemCategoryID, ItemGroupID, IndustryActivities.Manufacturing)
            Case ActivityComponentManufacturing, ActivityCapComponentManufacturing
                SQL = SQL & "ACTIVITY_ID = " & CStr(IndustryActivities.Manufacturing) & " "
                ' Add category for component
                Select Case ItemGroupID
                    Case ItemIDs.TitanGroupID, ItemIDs.SupercarrierGroupID, ItemIDs.DreadnoughtGroupID, ItemIDs.CarrierGroupID,
                ItemIDs.CapitalIndustrialShipGroupID, ItemIDs.IndustrialCommandShipGroupID, ItemIDs.FreighterGroupID, ItemIDs.JumpFreighterGroupID,
                    ItemIDs.AdvCapitalComponentGroupID, ItemIDs.CapitalComponentGroupID, ItemIDs.FAXGroupID
                        SQL = SQL & GetFacilityCatGroupIDSQL(ItemIDs.ComponentCategoryID, ItemIDs.CapitalComponentGroupID, IndustryActivities.Manufacturing) ' These all use cap components
                    Case Else
                        SQL = SQL & GetFacilityCatGroupIDSQL(ItemIDs.ComponentCategoryID, ItemIDs.ConstructionComponentsGroupID, IndustryActivities.Manufacturing)
                End Select
            Case ActivityCopying
                SQL = SQL & "ACTIVITY_ID = " & CStr(IndustryActivities.Copying) & " "
                SQL = SQL & GetFacilityCatGroupIDSQL(ItemCategoryID, ItemGroupID, IndustryActivities.Copying)
            Case ActivityInvention
                SQL = SQL & "ACTIVITY_ID = " & CStr(IndustryActivities.Invention) & " "
                SQL = SQL & GetFacilityCatGroupIDSQL(ItemCategoryID, ItemGroupID, IndustryActivities.Invention)
            Case ActivityReactions
                SQL = SQL & "ACTIVITY_ID = " & CStr(IndustryActivities.Reactions) & " "
                SQL = SQL & GetFacilityCatGroupIDSQL(ItemCategoryID, ItemGroupID, IndustryActivities.Reactions)
        End Select

        Return SQL

    End Function

    ' Returns the SQL string for querying by category or group id's 
    Public Function GetFacilityCatGroupIDSQL(ByVal CategoryID As Integer, ByVal GroupID As Integer, ByVal Activity As IndustryActivities) As String
        Dim SQL As String = ""
        Dim TempGroupID As Integer
        Dim TempCategoryID As Integer

        ' If the categoryID or groupID is for T3 invention, then switch the item ID's to the blueprint groupID for that item to match CCP's logic in table
        If Activity = IndustryActivities.Invention Then
            If CategoryID = ItemIDs.SubsystemCategoryID Then
                TempGroupID = ItemIDs.SubsystemBPGroupID
                TempCategoryID = 0
            ElseIf GroupID = ItemIDs.StrategicCruiserGroupID Then
                TempGroupID = ItemIDs.StrategicCruiserBPGroupID
                TempCategoryID = 0
            ElseIf GroupID = ItemIDs.TacticalDestroyerGroupID Then
                TempGroupID = ItemIDs.TacticalDestroyerBPGroupID
                TempCategoryID = 0
            Else
                TempGroupID = GroupID
                TempCategoryID = CategoryID
            End If
        Else
            TempGroupID = GroupID
            TempCategoryID = CategoryID
        End If

        SQL = "AND (GROUP_ID = " & CStr(TempGroupID) & " OR (GROUP_ID = 0 AND CATEGORY_ID = " & CStr(TempCategoryID) & ")) "

        Return SQL

    End Function

    ' Sets all the combos to unenabled and base text to show no facility for stuff like Invention, Copy and RE where they might buy the item
    Private Sub SetNoFacility()
        cmbFacilityRegion.Items.Clear()
        cmbFacilityRegion.Text = "Select Region"
        cmbFacilityRegion.Enabled = False
        cmbFacilitySystem.Items.Clear()
        cmbFacilitySystem.Text = InitialSolarSystemComboText
        cmbFacilitySystem.Enabled = False
        cmbFacility.Items.Clear()
        cmbFacility.Text = InitialFacilityComboText

    End Sub

    ' Translates the string facility type into the enum code
    Private Function GetFacilityTypeCode(FacilityType As String) As FacilityTypes
        Dim rsLookup As SQLiteDataReader
        Dim ReturnType As FacilityTypes = FacilityTypes.None

        DBCommand = New SQLiteCommand("SELECT FACILITY_TYPE_ID FROM FACILITY_TYPES WHERE FACILITY_TYPE_NAME = '" & FacilityType & "'", EVEDB.DBREf)
        rsLookup = DBCommand.ExecuteReader
        If rsLookup.Read() Then
            ReturnType = CType(rsLookup.GetInt32(0), FacilityTypes)
        End If

        rsLookup.Close()

        Return ReturnType

    End Function

    ' Translates facility code into name
    Private Function GetFacilityNamefromCode(FacilityType As FacilityTypes) As String
        Dim rsLookup As SQLiteDataReader
        Dim ReturnName As String = ""

        DBCommand = New SQLiteCommand("SELECT FACILITY_TYPE_NAME FROM FACILITY_TYPES WHERE FACILITY_TYPE_ID = " & CInt(FacilityType), EVEDB.DBREf)
        rsLookup = DBCommand.ExecuteReader
        If rsLookup.Read() Then
            ReturnName = rsLookup.GetString(0)
        End If

        rsLookup.Close()

        Return ReturnName

    End Function

    ' Resets all combo boxes toggles that might need to be updated 
    Private Sub ResetComboLoadVariables(RegionsValue As Boolean, SystemsValue As Boolean, FacilitiesValue As Boolean)

        FacilityRegionsLoaded = RegionsValue
        FacilitySystemsLoaded = SystemsValue
        FacilityorArrayLoaded = FacilitiesValue

    End Sub

    ' Returns the type of production done for the activity and bp data sent
    Public Function GetProductionType(BPGroupID As Integer, BPCategoryID As Integer, SelectedActivity As String) As ProductionType
        Dim SelectedIndyType As ProductionType

        Dim FacilityType As FacilityTypes
        Dim BaseActivity As String

        FacilityType = FacilityTypes.Station

        ' Select the activity type from combo or default
        If SelectedActivity = InitialActivityComboText Then
            ' Use the manufacturing activity for these
            BaseActivity = ActivityManufacturing
        Else
            BaseActivity = SelectedActivity
        End If

        SelectedIndyType = ProductionType.Manufacturing

        If BPCategoryID = ItemIDs.SubsystemCategoryID Then
            SelectedIndyType = ProductionType.SubsystemManufacturing
        ElseIf BPCategoryID = ItemIDs.ComponentCategoryID Then
            ' Add category for component
            If BPGroupID = ItemIDs.CapitalComponentGroupID Or BPGroupID = ItemIDs.AdvCapitalComponentGroupID Then
                SelectedIndyType = ProductionType.CapitalComponentManufacturing ' These all use cap components
            Else
                SelectedIndyType = ProductionType.ComponentManufacturing
            End If
        End If

        Return SelectedIndyType

    End Function

    Private Sub SetResetRefresh()
        If SelectedLocation = ProgramLocation.ManufacturingTab And Not FirstLoad Then
            Call frmMain.ResetRefresh()
        End If
    End Sub

#End Region

#Region "Public Functions"

    ' Resets the char id of the facility
    Public Sub ResetSelectedCharacterID(NewCharacterID As Long)
        SelectedCharacterID = NewCharacterID
    End Sub

    ' Loads the facility sent into the type of the facility
    Public Sub UpdateFacility(UpdatedFacility As IndustryFacility)

        SelectedManufacturingFacility = CType(UpdatedFacility.Clone, IndustryFacility)

    End Sub

    ' Returns the facilty for the production type sent
    Public Function GetFacility(BuildType As ProductionType) As IndustryFacility

        'Always include usage in EasyIPH
        SelectedFacility.IncludeActivityUsage = True
        ' Facility is loaded, so save it to default and dynamic variable
        Call SetFacility(SelectedFacility, SelectedProductionType, False, False)
        Call SetResetRefresh()

        ' Select based on input type. If not fully loaded, then load the default and also load the default facility in the facility controls
        Select Case BuildType
            Case ProductionType.Manufacturing
                If SelectedManufacturingFacility.FullyLoaded Then
                    Return SelectedManufacturingFacility
                Else
                    Return DefaultManufacturingFacility
                End If
            Case Else
                MsgBox("Error in ManufacturingFacility.VB, GetFacility()", vbInformation, "Error")
                End
                Return Nothing
        End Select

        Return Nothing

    End Function

    ' Gets the facility for manufacturing based on the bp data on initialization or sent bp data
    Public Function GetSelectedManufacturingFacility(BPGroupID As Integer, BPCategoryID As Integer,
                                                     Optional OverrideActivity As String = "") As IndustryFacility
        Dim TempGroupID As Integer
        Dim TempCategoryID As Integer
        Dim SelectedActivity As String

        ' If either one of the numbers are 0, then use the init data
        If BPGroupID = 0 Or BPCategoryID = 0 Then
            TempGroupID = SelectedBPGroupID
            TempCategoryID = SelectedBPCategoryID
        Else
            TempGroupID = BPGroupID
            TempCategoryID = BPCategoryID
        End If

        If OverrideActivity <> "" Then
            SelectedActivity = OverrideActivity
        Else
            ' default setting, if the bp is a reaction, then return the reaction facility not manufacturing
            SelectedActivity = ActivityManufacturing

            'Look up the groups for reactions
            If SelectedActivity = ActivityManufacturing Then
                Dim rsCheck As SQLiteDataReader
                DBCommand = New SQLiteCommand("SELECT DISTINCT ITEM_GROUP_ID FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID IN (SELECT typeID FROM INVENTORY_TYPES WHERE typeName LIKE '%Reaction Formula%')", EVEDB.DBREf)
                rsCheck = DBCommand.ExecuteReader

                While rsCheck.Read
                    If rsCheck.GetInt32(0) = BPGroupID Then
                        SelectedActivity = ActivityReactions
                    End If
                End While
                rsCheck.Close()
            End If
        End If

        ' Determine the production type and then pull the correct facility for manufacturing only based on the category and group id not the activity selected
        Dim PT As ProductionType = GetProductionType(TempGroupID, TempCategoryID, SelectedActivity)

        Return GetFacility(PT)

    End Function

    ' Gets the facility for invention based on the bp data on initialization or sent bp data
    Public Function GetSelectedInventionFacility(Optional BPGroupID As Integer = 0, Optional BPCategoryID As Integer = 0) As IndustryFacility
        Dim TempGroupID As Integer
        Dim TempCategoryID As Integer

        ' If either one of the numbers are 0, then use the init data
        If BPGroupID = 0 Or BPCategoryID = 0 Then
            TempGroupID = SelectedBPGroupID
            TempCategoryID = SelectedBPCategoryID
        Else
            TempGroupID = BPGroupID
            TempCategoryID = BPCategoryID
        End If

        ' Determine the production type and then pull the correct facility for manufacturing only based on the category and group id not the activity selected
        Dim PT As ProductionType = GetProductionType(TempGroupID, TempCategoryID, ActivityInvention)

        Return GetFacility(PT)

    End Function

    ' Just return the current facility selected
    Public Function GetSelectedFacility() As IndustryFacility
        Return SelectedFacility
    End Function

    ' Returns if the facility is fully loaded or not
    Public Function FullyLoaded() As Boolean
        Return SelectedFacility.FullyLoaded
    End Function

    ' Returns the current selected facility production type
    Public Function GetCurrentFacilityProductionType() As ProductionType
        Return SelectedFacility.FacilityProductionType
    End Function

    Private Function ProcessKeyPressInput(e As KeyPressEventArgs) As Boolean
        Dim EnableButton As Boolean = True
        Dim ReturnValue As Boolean = False

        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedNegativePercentChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                ReturnValue = True
                EnableButton = False
            End If
        End If

        Call SetResetRefresh()

        Return ReturnValue

    End Function

    Private Sub cmbModules_SelectedIndexChanged(sender As Object, e As EventArgs)

        Call SetResetRefresh()

    End Sub

    Private Sub cmbFuelBlocks_SelectedIndexChanged(sender As Object, e As EventArgs)

        Call SetResetRefresh()

    End Sub

    Private Sub cmbLargeShips_SelectedIndexChanged(sender As Object, e As EventArgs)

        Call SetResetRefresh()

    End Sub

#End Region

End Class

Public Enum ProgramLocation
    None = -1
    BlueprintTab = 0
    ManufacturingTab = 1
    SovBelts = 4
    IceBelts = 5
End Enum

' Types of actual activities that you can conduct in a facility
Public Enum IndustryActivities
    None = 0
    Manufacturing = 1
    ResearchingTechnology = 2
    ResearchingTimeLevel = 3
    ResearchingMaterialLevel = 4
    Copying = 5
    Duplicating = 6
    Invention = 8
    Reactions = 11
End Enum

' These are the different types of industry fuction we will distinguish between facilities since they all have special restrictions
Public Enum ProductionType
    None = 0
    Manufacturing = 1
    ComponentManufacturing = 2
    CapitalComponentManufacturing = 3
    CapitalManufacturing = 4
    SuperManufacturing = 5
    T3CruiserManufacturing = 6
    SubsystemManufacturing = 7
    BoosterManufacturing = 8
    Copying = 9
    Invention = 10
    Reactions = 11
    T3Invention = 12
    T3DestroyerManufacturing = 13

    ' Special POS Arrays
    POSModuleManufacturing = 14
    POSFuelBlockManufacturing = 15
    POSLargeShipManufacturing = 16

End Enum

Public Enum ItemIDs
    None = 0

    ' These are all the capital ships that use capital parts
    CapitalIndustrialShipGroupID = 883
    CarrierGroupID = 547
    DreadnoughtGroupID = 485
    FreighterGroupID = 513
    IndustrialCommandShipGroupID = 941
    JumpFreighterGroupID = 902
    SupercarrierGroupID = 659
    FAXGroupID = 1538
    TitanGroupID = 30
    BoosterGroupID = 303
    BoosterCategoryID = 20

    ' T3 items
    StrategicCruiserGroupID = 963
    TacticalDestroyerGroupID = 1305
    SubsystemCategoryID = 32

    ' T3 Bps for facility updates
    StrategicCruiserBPGroupID = 996
    TacticalDestroyerBPGroupID = 1309
    SubsystemBPGroupID = 973

    ' For looking up pos stuff in facilities
    FuelBlockGroupID = 1136
    BattleshipGroupID = 27
    ModuleCategoryID = 7

    ShipCategoryID = 6 ' for loading invention and copying and basic t1
    FrigateGroupID = 25

    ' Reactions
    ReactionsIntermediateGroupID = 428
    ReactionCompositesGroupID = 429
    ReactionPolymersGroupID = 974
    ReactionBiochmeicalsGroupID = 712

    ConstructionComponentsGroupID = 334 ' Use this for all non-capital components
    ComponentCategoryID = 17
    CapitalComponentGroupID = 873
    AdvCapitalComponentGroupID = 913

    ' Categories (has multiple groups)
    StationEggGroupID = 307 ' This is for loading No POS build items
    SovStructureCategoryID = 3 ' For stations - I don't think this is used anymore (everything can be built at a pos?)
    StationPartsGroupID = 536

    BlueprintCategoryID = 9
    FrigateBlueprintGroupID = 105

End Enum

Public Enum FacilityTypes
    None = -1
    Station = 0
    POS = 1
    UpwellStructure = 3
End Enum

' Industry facility class, move to private use if possible
Public Class IndustryFacility
    Implements ICloneable

    ' For industry Facilities
    Public FacilityID As Long ' ID Of the facility
    Public FacilityName As String ' Station/Outpost Name or the Array name
    Public FacilityType As FacilityTypes ' POS, Station, Outpost, Upwell Structure
    Public FacilityTypeID As Integer ' type ID for facility - type of outpost, etc
    Public FacilityProductionType As ProductionType ' What we are doing at this facility
    Public ActivityID As Integer ' Activity code of the facility
    Public Activity As String ' String value of the activity
    Public RegionName As String ' Region of this facility
    Public RegionID As Long
    Public SolarSystemName As String ' System where this is located
    Public SolarSystemID As Long
    Public SolarSystemSecurity As Double
    Public FWUpgradeLevel As Integer ' Level of the FW upgrade for this system (if applies)
    Public CostIndex As Double ' Cost index for the system and activity from ESI
    Public ActivityCostPerSecond As Double ' The cost to conduct the activity for this facility per second - my setting for POS and ECs
    Public IsDefault As Boolean
    Public IncludeActivityCost As Boolean ' This is the total cost of materials to do the activiy
    Public IncludeActivityTime As Boolean ' This is the time for doing the activity
    Public IncludeActivityUsage As Boolean ' This is the cost of using the facility only

    Public FacilityUsage As Double ' The usage charged by this facility, set after bp has run
    Public UsageToolTipText As String ' The text to display for the usage label

    ' Nullable fields
    Public TaxRate As Double ' The tax rate
    ' Remove these eventually when outposts and pos removed
    Public MaterialMultiplier As Double ' The bonus material percentage for materials used in this facility
    Public TimeMultiplier As Double ' The bonus to time to conduct an activity in this facility
    Public CostMultiplier As Double ' The bonus to cost to conduct an activity in this facility
    Public BaseTax As Double ' Base tax rate from default
    Public BaseME As Double ' The ME bonus from default
    Public BaseTE As Double ' The TE bonus from default
    Public BaseCost As Double ' The Cost bonus from default

    Public FullyLoaded As Boolean ' This facility was fully loaded in all parts

    Private ControlForm As Form  ' Where the control lives

    ' Default multiplier rates if we can't find them
    Public Const DefaultTaxRate As Double = 0
    Public Const DefaultMaterialMultiplier As Double = 1
    Public Const DefaultTimeMultiplier As Double = 1
    Public Const DefaultCostMultiplier As Double = 1

    Public Sub New()

        FacilityID = 0
        FacilityName = None
        FacilityType = FacilityTypes.None
        FacilityTypeID = 0
        FacilityProductionType = ProductionType.None
        ActivityID = 0
        Activity = ""
        RegionName = None
        RegionID = 0
        SolarSystemName = None
        SolarSystemID = 0
        SolarSystemSecurity = 0
        FWUpgradeLevel = -1
        CostIndex = 0
        ActivityCostPerSecond = 0
        IsDefault = False
        IncludeActivityCost = False
        IncludeActivityTime = False
        IncludeActivityUsage = False

        TaxRate = 0
        MaterialMultiplier = 0
        TimeMultiplier = 0
        CostMultiplier = 0
        BaseME = 0
        BaseTE = 0
        BaseCost = 0

        ControlForm = Nothing

        FullyLoaded = False

    End Sub

    ' For doing a deep copy of Materials
    Public Function Clone() As Object Implements ICloneable.Clone
        Dim CopyOfMe = New IndustryFacility

        CopyOfMe.FacilityID = FacilityID
        CopyOfMe.FacilityName = FacilityName
        CopyOfMe.FacilityType = FacilityType
        CopyOfMe.FacilityTypeID = FacilityTypeID
        CopyOfMe.FacilityProductionType = FacilityProductionType
        CopyOfMe.ActivityID = ActivityID
        CopyOfMe.Activity = Activity
        CopyOfMe.RegionName = RegionName
        CopyOfMe.RegionID = RegionID
        CopyOfMe.SolarSystemName = SolarSystemName
        CopyOfMe.SolarSystemID = SolarSystemID
        CopyOfMe.SolarSystemSecurity = SolarSystemSecurity
        CopyOfMe.FWUpgradeLevel = FWUpgradeLevel
        CopyOfMe.CostIndex = CostIndex
        CopyOfMe.ActivityCostPerSecond = ActivityCostPerSecond
        CopyOfMe.IsDefault = IsDefault
        CopyOfMe.IncludeActivityCost = IncludeActivityCost
        CopyOfMe.IncludeActivityTime = IncludeActivityTime
        CopyOfMe.IncludeActivityUsage = IncludeActivityUsage
        CopyOfMe.FacilityUsage = FacilityUsage
        CopyOfMe.UsageToolTipText = UsageToolTipText
        CopyOfMe.TaxRate = TaxRate
        CopyOfMe.MaterialMultiplier = MaterialMultiplier
        CopyOfMe.TimeMultiplier = TimeMultiplier
        CopyOfMe.CostMultiplier = CostMultiplier
        CopyOfMe.BaseME = BaseME
        CopyOfMe.BaseTE = BaseTE
        CopyOfMe.BaseCost = BaseCost
        CopyOfMe.FullyLoaded = FullyLoaded
        CopyOfMe.ControlForm = ControlForm

        Return CopyOfMe

    End Function

    ' Load up the facility data from the table as default
    Public Sub InitalizeFacility(InitialProductionType As ProductionType, FacilityLocation As ProgramLocation, ByRef FacilityForm As Form)
        Dim SQL As String = ""
        Dim rsLoader As SQLiteDataReader

        ' Look up all the data in two queries - first base data and try to get the multipliers and cost data - it should only be there for saved outposts (which are being removed)
        SQL = "SELECT SF.FACILITY_ID, SF.FACILITY_TYPE "
        SQL &= "FACILITY_PRODUCTION_TYPES.ACTIVITY_ID, INDUSTRY_ACTIVITIES.activityName, "
        SQL &= "REGIONS.regionName, REGIONS.regionID, SOLAR_SYSTEMS.solarSystemName, SOLAR_SYSTEMS.solarSystemID, "
        SQL &= "CASE WHEN UPGRADE_LEVEL IS NULL THEN 0 ELSE UPGRADE_LEVEL END AS FW_UPGRADE_LEVEL, SF.ACTIVITY_COST_PER_SECOND, "
        SQL &= "CASE WHEN COST_INDEX IS NULL THEN 0 ELSE COST_INDEX END AS COST_INDEX,"
        SQL &= "SF.INCLUDE_ACTIVITY_COST, SF.INCLUDE_ACTIVITY_TIME, SF.INCLUDE_ACTIVITY_USAGE, "
        SQL &= "SF.FACILITY_TAX, SF.MATERIAL_MULTIPLIER, SF.TIME_MULTIPLIER, SF.COST_MULTIPLIER, security, CONVERT_TO_ORE "
        SQL &= "FROM SAVED_FACILITIES AS SF, FACILITY_PRODUCTION_TYPES, REGIONS, SOLAR_SYSTEMS, FACILITY_TYPES, INDUSTRY_ACTIVITIES "
        SQL &= "LEFT JOIN FW_SYSTEM_UPGRADES ON FW_SYSTEM_UPGRADES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID "
        SQL &= "LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES "
        SQL &= "ON INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID "
        SQL &= "AND INDUSTRY_SYSTEMS_COST_INDICIES.ACTIVITY_ID = FACILITY_PRODUCTION_TYPES.ACTIVITY_ID "
        SQL &= "WHERE SF.PRODUCTION_TYPE = FACILITY_PRODUCTION_TYPES.PRODUCTION_TYPE "
        SQL &= "AND SF.REGION_ID = REGIONS.regionID "
        SQL &= "AND SF.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID "
        SQL &= "AND SF.FACILITY_TYPE = FACILITY_TYPES.FACILITY_TYPE_ID "
        SQL &= "AND FACILITY_PRODUCTION_TYPES.ACTIVITY_ID = INDUSTRY_ACTIVITIES.activityID "
        SQL &= String.Format("AND SF.PRODUCTION_TYPE = {0} AND SF.FACILITY_VIEW = {1} ", CStr(InitialProductionType), CStr(FacilityLocation))

        Dim SQLCharID As String = "AND CHARACTER_ID = {0}"
        Dim CharID As String = ""

        ' See what type of character ID
        CharID = CStr(SelectedCharacter.ID)

        ' First look up the character to see if it's saved there first (initially only do one set of facilities then allow by character via a setting)
        DBCommand = New SQLiteCommand("SELECT SF.FACILITY_ID, SF.FACILITY_TYPE, FACILITY_PRODUCTION_TYPES.ACTIVITY_ID, INDUSTRY_ACTIVITIES.activityName, REGIONS.regionName, REGIONS.regionID, SOLAR_SYSTEMS.solarSystemName, SOLAR_SYSTEMS.solarSystemID, CASE WHEN UPGRADE_LEVEL IS NULL THEN 0 ELSE UPGRADE_LEVEL END AS FW_UPGRADE_LEVEL, SF.ACTIVITY_COST_PER_SECOND, CASE WHEN COST_INDEX IS NULL THEN 0 ELSE COST_INDEX END AS COST_INDEX,SF.INCLUDE_ACTIVITY_COST, SF.INCLUDE_ACTIVITY_TIME, SF.INCLUDE_ACTIVITY_USAGE, SF.FACILITY_TAX, SF.MATERIAL_MULTIPLIER, SF.TIME_MULTIPLIER, SF.COST_MULTIPLIER, security, CONVERT_TO_ORE FROM SAVED_FACILITIES AS SF, FACILITY_PRODUCTION_TYPES, REGIONS, SOLAR_SYSTEMS, FACILITY_TYPES, INDUSTRY_ACTIVITIES LEFT JOIN FW_SYSTEM_UPGRADES ON FW_SYSTEM_UPGRADES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ON INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID AND INDUSTRY_SYSTEMS_COST_INDICIES.ACTIVITY_ID = FACILITY_PRODUCTION_TYPES.ACTIVITY_ID WHERE SF.PRODUCTION_TYPE = FACILITY_PRODUCTION_TYPES.PRODUCTION_TYPE AND SF.REGION_ID = REGIONS.regionID AND SF.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID AND SF.FACILITY_TYPE = FACILITY_TYPES.FACILITY_TYPE_ID AND FACILITY_PRODUCTION_TYPES.ACTIVITY_ID = INDUSTRY_ACTIVITIES.activityID AND SF.PRODUCTION_TYPE = 1 AND SF.FACILITY_VIEW = 1 AND CHARACTER_ID = -1;", EVEDB.DBREf)
        'SQL & String.Format(SQLCharID, CStr(CharID)),

        rsLoader = DBCommand.ExecuteReader
        rsLoader.Read()

        If Not rsLoader.HasRows Then
            ' Need to look up the default
            rsLoader.Close()
            DBCommand = New SQLiteCommand("SELECT SF.FACILITY_ID, SF.FACILITY_TYPE, FACILITY_PRODUCTION_TYPES.ACTIVITY_ID, INDUSTRY_ACTIVITIES.activityName, REGIONS.regionName, REGIONS.regionID, SOLAR_SYSTEMS.solarSystemName, SOLAR_SYSTEMS.solarSystemID, CASE WHEN UPGRADE_LEVEL IS NULL THEN 0 ELSE UPGRADE_LEVEL END AS FW_UPGRADE_LEVEL, SF.ACTIVITY_COST_PER_SECOND, CASE WHEN COST_INDEX IS NULL THEN 0 ELSE COST_INDEX END AS COST_INDEX,SF.INCLUDE_ACTIVITY_COST, SF.INCLUDE_ACTIVITY_TIME, SF.INCLUDE_ACTIVITY_USAGE, SF.FACILITY_TAX, SF.MATERIAL_MULTIPLIER, SF.TIME_MULTIPLIER, SF.COST_MULTIPLIER, security, CONVERT_TO_ORE FROM SAVED_FACILITIES AS SF, FACILITY_PRODUCTION_TYPES, REGIONS, SOLAR_SYSTEMS, FACILITY_TYPES, INDUSTRY_ACTIVITIES LEFT JOIN FW_SYSTEM_UPGRADES ON FW_SYSTEM_UPGRADES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID LEFT JOIN INDUSTRY_SYSTEMS_COST_INDICIES ON INDUSTRY_SYSTEMS_COST_INDICIES.SOLAR_SYSTEM_ID = SF.SOLAR_SYSTEM_ID AND INDUSTRY_SYSTEMS_COST_INDICIES.ACTIVITY_ID = FACILITY_PRODUCTION_TYPES.ACTIVITY_ID WHERE SF.PRODUCTION_TYPE = FACILITY_PRODUCTION_TYPES.PRODUCTION_TYPE AND SF.REGION_ID = REGIONS.regionID AND SF.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID AND SF.FACILITY_TYPE = FACILITY_TYPES.FACILITY_TYPE_ID AND FACILITY_PRODUCTION_TYPES.ACTIVITY_ID = INDUSTRY_ACTIVITIES.activityID AND SF.PRODUCTION_TYPE = 1 AND SF.FACILITY_VIEW = 1 AND CHARACTER_ID = 0;", EVEDB.DBREf)
            rsLoader = DBCommand.ExecuteReader
            rsLoader.Read()
        End If

        ' Should have data one way or another now
        If rsLoader.HasRows Then
            With rsLoader
                FacilityID = .GetInt32(0)
                FacilityType = CType(.GetInt32(1), FacilityTypes) ' Station, Upwell Structure, etc.
                FacilityProductionType = InitialProductionType
                ActivityID = .GetInt32(2)
                Activity = .GetString(3)
                RegionName = .GetString(4)
                RegionID = .GetInt64(5)
                ' Paste the cost index to the solar system name
                CostIndex = .GetFloat(10)
                SolarSystemName = .GetString(6) & " (" & FormatNumber(CostIndex, 4) & ")"
                    SolarSystemID = .GetInt64(7)
                SolarSystemSecurity = .GetDouble(18)
                FWUpgradeLevel = .GetInt32(8)
                ActivityCostPerSecond = .GetFloat(9)

                IncludeActivityCost = CBool(.GetInt32(11))
                IncludeActivityTime = CBool(.GetInt32(12))
                IncludeActivityUsage = CBool(.GetInt32(13))

                ' Save these values for later lookup - use -1 for null indicator - these are what they saved manually
                If IsDBNull(.GetValue(14)) Then
                    TaxRate = -1
                Else
                    TaxRate = .GetDouble(14)
                End If

                If IsDBNull(.GetValue(15)) Then
                    MaterialMultiplier = -1
                Else
                    MaterialMultiplier = .GetDouble(15)
                End If

                If IsDBNull(.GetValue(16)) Then
                    TimeMultiplier = -1
                Else
                    TimeMultiplier = .GetDouble(16)
                End If

                If IsDBNull(.GetValue(17)) Then
                    CostMultiplier = -1
                Else
                    CostMultiplier = .GetDouble(17)
                End If

                ' Now, depending on type, look up the name, cost index, tax, and multipliers from the stations table (this is mainly for speed)
				SQL = "SELECT STATION_NAME," & CStr(DefaultStationTaxRate) & ", 1, 1, 1 "
				SQL = SQL & "FROM STATIONS WHERE STATION_ID = " & CStr(FacilityID) & " "
           
                rsLoader.Close()
                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsLoader = DBCommand.ExecuteReader
                rsLoader.Read()

                If rsLoader.HasRows Then
                    With rsLoader
                        FacilityName = .GetString(0) ' Need to deal with the case of all on calc base facility

                        ' For the remaining values, if they saved a value manually, then use that, else use what was queried and if null, use the default
                        If IsDBNull(.GetValue(1)) And TaxRate = -1 Then
                            ' Nothing in DB and they didn't save anything, so use the default rate
                            TaxRate = DefaultTaxRate
                        ElseIf TaxRate = -1 Then
                            ' use what was in db
                            TaxRate = .GetDouble(1)
                        End If

                        If IsDBNull(.GetValue(2)) And MaterialMultiplier = -1 Then
                            MaterialMultiplier = DefaultMaterialMultiplier
                        ElseIf MaterialMultiplier = -1 Then
                            MaterialMultiplier = .GetDouble(2)
                        End If

                        BaseME = .GetDouble(2)

                        If IsDBNull(.GetValue(3)) And TimeMultiplier = -1 Then
                            TimeMultiplier = DefaultTimeMultiplier
                        ElseIf TimeMultiplier = -1 Then
                            TimeMultiplier = .GetDouble(3)
                        End If

                        BaseTE = .GetDouble(3)

                        If IsDBNull(.GetValue(4)) And CostMultiplier = -1 Then
                            CostMultiplier = DefaultCostMultiplier
                        ElseIf CostMultiplier = -1 Then
                            CostMultiplier = .GetDouble(4)
                        End If

                        BaseCost = .GetDouble(4)

                    End With
                Else
                    ' Something went wrong
                    MsgBox("The facility failed To load", vbCritical, Application.ProductName)
                    GoTo ExitBlock
                End If

                FullyLoaded = True

                IsDefault = True ' Always loading default with initialize

            End With

        Else
            ' Something went wrong
            MsgBox("The facility failed To load", vbCritical, Application.ProductName)
            GoTo ExitBlock
        End If

ExitBlock:
        On Error Resume Next
        rsLoader.Close()
        On Error GoTo 0

    End Sub

    Public Function SaveFacility(CharacterID As Long, Location As ProgramLocation, SupressNotice As Boolean) As Boolean
        Dim SQL As String
        Dim TempSQL As String
        Dim rsCheck As SQLiteDataReader
        Dim ManualEntries As Boolean = False
        Dim LocationList As New List(Of Integer)
        Dim LID As Integer

        Try

            ' Need to get each location for saving
            For Each LID In System.Enum.GetValues(GetType(ProgramLocation))
                Call LocationList.Add(LID)
            Next

            For Each LID In LocationList
                ' See if the record exists - only save one set of facilities for now
                SQL = String.Format("SELECT 'X' FROM SAVED_FACILITIES WHERE PRODUCTION_TYPE = {0} AND FACILITY_VIEW = {1} AND CHARACTER_ID = {2}",
                        CInt(FacilityProductionType), LID, CharacterID)
                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsCheck = DBCommand.ExecuteReader

                If rsCheck.Read() Then
                    ' Need to update
                    TempSQL = "UPDATE SAVED_FACILITIES "
                    TempSQL &= "SET FACILITY_ID = {0}, "
                    TempSQL &= "FACILITY_TYPE = {1}, "
                    TempSQL &= "REGION_ID = {2}, "
                    TempSQL &= "SOLAR_SYSTEM_ID = {3}, "
                    TempSQL &= "ACTIVITY_COST_PER_SECOND = {4}, "
                    TempSQL &= "INCLUDE_ACTIVITY_COST = {5}, "
                    TempSQL &= "INCLUDE_ACTIVITY_TIME = {6}, "
                    TempSQL &= "INCLUDE_ACTIVITY_USAGE = {7}, "
                    TempSQL &= "CONVERT_TO_ORE = {8},"

                    TempSQL &= "MATERIAL_MULTIPLIER = NULL, "
                    TempSQL &= "TIME_MULTIPLIER = NULL, "
                    TempSQL &= "COST_MULTIPLIER = NULL, "
                    TempSQL &= "FACILITY_TAX = NULL "

                    TempSQL &= "WHERE PRODUCTION_TYPE = {9} AND CHARACTER_ID = {10} "
                    TempSQL &= "AND FACILITY_VIEW = " & CStr(LID)

                    SQL = String.Format(TempSQL, FacilityID, CInt(FacilityType), RegionID, SolarSystemID, ActivityCostPerSecond,
                    CInt(IncludeActivityCost), CInt(IncludeActivityTime), CInt(IncludeActivityUsage), 0, CInt(FacilityProductionType), CharacterID)

                Else
                    Dim MEValue As String = "NULL"
                    Dim TEValue As String = "NULL"
                    Dim CostValue As String = "NULL"
                    Dim TaxValue As String = "NULL"

                    ' Insert
                    SQL = String.Format("INSERT INTO SAVED_FACILITIES VALUES ({0},{1},{2},{3},{4},NULL,{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15});",
                                        CharacterID, CInt(FacilityProductionType), LID, FacilityID, CInt(FacilityType), RegionID, SolarSystemID, ActivityCostPerSecond,
                                        CInt(IncludeActivityCost), CInt(IncludeActivityTime), CInt(IncludeActivityUsage), TaxValue, MEValue, TEValue, CostValue, 0)

                End If

                ' Save it
                Call EVEDB.ExecuteNonQuerySQL(SQL)

                rsCheck.Close()

                ' If they save a structure with manual values, then delete any fittings they may have saved for this structure
                If FacilityType = FacilityTypes.UpwellStructure Then
                    If ManualEntries Then
                        SQL = "DELETE FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_VIEW = {3} AND FACILITY_ID = {4}"
                        EVEDB.ExecuteNonQuerySQL(String.Format(SQL, CharacterID, CInt(FacilityProductionType), SolarSystemID, LID, FacilityID))
                    End If
                End If

                ' Update FW upgrade
                If FWUpgradeLevel <> -1 Then
                    ' See if we update or insert
                    SQL = "SELECT * FROM FW_SYSTEM_UPGRADES WHERE SOLAR_SYSTEM_ID = " & CStr(SolarSystemID) & " "

                    DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                    rsCheck = DBCommand.ExecuteReader
                    rsCheck.Read()

                    If rsCheck.HasRows Then
                        SQL = "UPDATE FW_SYSTEM_UPGRADES SET UPGRADE_LEVEL = " & CStr(FWUpgradeLevel)
                        SQL = SQL & " WHERE SOLAR_SYSTEM_ID = " & SolarSystemID
                    Else
                        SQL = "INSERT INTO FW_SYSTEM_UPGRADES VALUES (" & SolarSystemID & "," & CStr(FWUpgradeLevel) & ")"
                    End If

                    Call EVEDB.ExecuteNonQuerySQL(SQL)
                    rsCheck.Close()
                End If
            Next

            ' If this is an upwell, and we are saving multiple structures (shared) then we need to update all the shared structure modules as well
            If FacilityType = FacilityTypes.UpwellStructure Then
                Dim InstalledModules As New List(Of Integer)
                ' Look up all the installed modules for the location sent
                SQL = String.Format("SELECT INSTALLED_MODULE_ID FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE PRODUCTION_TYPE = {0} AND FACILITY_VIEW = {1} AND CHARACTER_ID = {2} AND FACILITY_ID = {3} AND SOLAR_SYSTEM_ID = {4}",
                                    CInt(FacilityProductionType), CStr(Location), CharacterID, FacilityID, SolarSystemID)
                DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
                rsCheck = DBCommand.ExecuteReader

                While rsCheck.Read()
                    InstalledModules.Add(rsCheck.GetInt32(0))
                End While

                rsCheck.Close()

                If InstalledModules.Count > 0 Then
                    ' Delete all in there first for this location ID
                    EVEDB.BeginSQLiteTransaction()
                    SQL = "DELETE FROM UPWELL_STRUCTURES_INSTALLED_MODULES WHERE CHARACTER_ID = {0} AND PRODUCTION_TYPE = {1} AND SOLAR_SYSTEM_ID = {2} AND FACILITY_ID = {3}"
                    EVEDB.ExecuteNonQuerySQL(String.Format(SQL, CharacterID, CStr(FacilityProductionType), SolarSystemID, FacilityID))

                    ' Now insert all the modules installed on this structure for sharing
                    For Each ModID In InstalledModules
                        For Each LID In LocationList
                            SQL = String.Format("INSERT INTO UPWELL_STRUCTURES_INSTALLED_MODULES VALUES({0},{1},{2},{3},{4},{5})",
                                    CharacterID, CStr(FacilityProductionType), SolarSystemID, CStr(LID), FacilityID, ModID)
                            EVEDB.ExecuteNonQuerySQL(SQL)
                        Next
                    Next
                    EVEDB.CommitSQLiteTransaction()
                End If
            End If


            ' Refresh the main facilites if sharing facility saves
            ' Refresh the facilities - except the one I just saved it on

            ' non- reprocessing is just limited to bp and manufacturing tab
            If Location = ProgramLocation.BlueprintTab Then
                    Call frmMain.LoadFacilities(ProgramLocation.ManufacturingTab, FacilityProductionType)
                Else
                    Call frmMain.LoadFacilities(ProgramLocation.BlueprintTab, FacilityProductionType)
                End If

                If Not SupressNotice Then
                Call MsgBox("Facility Saved", vbInformation, Application.ProductName)
            End If

            Return True

        Catch ex As Exception
            Call MsgBox("Facility Failed to Save", vbExclamation, Application.ProductName)
            Return False
        End Try

    End Function
    ' Compares the sent facility To the current one And returns a Boolean On equivlancy
    Public Function IsEqual(CompareFacility As IndustryFacility,
                            Optional CompareCostCheck As Boolean = False,
                            Optional CompareTimeCheck As Boolean = False) As Boolean

        With CompareFacility
            If .FacilityType <> FacilityType Then
                Return False
            ElseIf .FacilityTypeID <> FacilityTypeID Then
                Return False
            ElseIf .FacilityProductionType <> FacilityProductionType Then
                Return False
            ElseIf .FacilityName <> FacilityName And Not (.FacilityType = FacilityTypes.pos And FacilityProductionType = ProductionType.Manufacturing) Then
                Return False
            ElseIf .RegionName <> RegionName Then
                Return False
            ElseIf .RegionID <> RegionID Then
                Return False
            ElseIf .SolarSystemName <> SolarSystemName Then
                Return False
            ElseIf .SolarSystemID <> SolarSystemID Then
                Return False
                'ElseIf .FWUpgradeLevel <> FWUpgradeLevel Then
                '    Return False
            ElseIf .TaxRate <> TaxRate Then
                Return False
            ElseIf .MaterialMultiplier <> MaterialMultiplier And .FacilityType <> FacilityTypes.pos Then ' Only for non-pos
                Return False
            ElseIf .TimeMultiplier <> TimeMultiplier And .FacilityType <> FacilityTypes.pos Then ' Only for non-pos
                Return False
            ElseIf .CostMultiplier <> CostMultiplier And .FacilityType <> FacilityTypes.pos Then ' Only for non-pos
                Return False
            ElseIf .IncludeActivityCost <> IncludeActivityCost And CompareCostCheck Then
                Return False
            ElseIf .IncludeActivityTime <> IncludeActivityTime And CompareTimeCheck Then
                Return False
            ElseIf .IncludeActivityUsage <> IncludeActivityUsage Then
                Return False
            End If
        End With

        Return True

    End Function

    Public Function GetFacilityTypeDescription() As String
        Select Case FacilityType
            Case FacilityTypes.Station
                Return ManufacturingFacility.StationFacility
            Case FacilityTypes.None
                Return None
            Case Else
                Return None
        End Select
    End Function

    ' Refreshes the MM/TM/CM bonuses for all three for the information sent
    Public Sub RefreshMMTMCMBonuses(ItemGroupID As Integer, ItemCategoryID As Integer)

    End Sub

End Class
