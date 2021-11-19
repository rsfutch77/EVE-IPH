<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuStripMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectionAddChar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectionManageCharacters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSelectionExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemUpdatePrices = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManageBlueprintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClearBPHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdateData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdateIndustryFacilities = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdateESIMarketPrices = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUpdateESIPublicStructures = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuChangeDummyCharacterName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuResetData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetBlueprintData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetIgnoredBPs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetPriceData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetAgents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetIndustryJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetAssets = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetMarketHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetMarketOrders = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetESIPublicStructures = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetESIIndustryFacilities = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetESIMarketPrices = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetESIDates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuResetAllData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectionShoppingList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCharacterSkills = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCurrentResearchAgents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCurrentIndustryJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewESIStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectDefaultChar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPatchNotes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCheckforUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSelectionAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttBP = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.gbSystems = New System.Windows.Forms.GroupBox()
        Me.ListOptionsMenu = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.AddToShoppingListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IgnoreBlueprintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FavoriteBlueprintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttUpdatePrices = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttManufacturing = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttDatacores = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttReactions = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttMining = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttPI = New System.Windows.Forms.ToolTip(Me.components)
        Me.CalcImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.txtListEdit = New System.Windows.Forms.TextBox()
        Me.cmbEdit = New System.Windows.Forms.ComboBox()
        Me.btnCancelUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnDownloadPrices = New MetroFramework.Controls.MetroButton()
        Me.btnCalcCalculate = New MetroFramework.Controls.MetroButton()
        Me.btnCalcSelectColumns = New MetroFramework.Controls.MetroButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MetroProgressBar = New MetroFramework.Controls.MetroProgressBar()
        Me.mnuChar = New MetroFramework.Controls.MetroComboBox()
        Me.chkCalcCanBuild = New MetroFramework.Controls.MetroCheckBox()
        Me.autoShopping = New MetroFramework.Controls.MetroCheckBox()
        Me.gbCalcBPSelect = New System.Windows.Forms.GroupBox()
        Me.rbtnCalcBPFavorites = New MetroFramework.Controls.MetroRadioButton()
        Me.rbtnCalcAllBPs = New MetroFramework.Controls.MetroRadioButton()
        Me.rbtnCalcBPOwned = New MetroFramework.Controls.MetroRadioButton()
        Me.gbCalcTextColors = New System.Windows.Forms.GroupBox()
        Me.lblCalcColorCode6 = New System.Windows.Forms.Label()
        Me.lblCalcText = New System.Windows.Forms.Label()
        Me.lblCalcColorCode3 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode4 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode5 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode2 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode1 = New System.Windows.Forms.Label()
        Me.lblRecommendation = New MetroFramework.Controls.MetroLabel()
        Me.pnlShoppingList = New MetroFramework.Controls.MetroLabel()
        Me.pnlSkills = New MetroFramework.Controls.MetroLabel()
        Me.pnlStatus = New MetroFramework.Controls.MetroLabel()
        Me.facilityPicker = New MetroFramework.Controls.MetroLabel()
        Me.lblCharacterData = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.lstManufacturing = New EVE_Isk_per_Hour.ManufacturingListView()
        Me.CalcBaseFacility = New EVE_Isk_per_Hour.ManufacturingFacility()
        Me.mnuStripMain.SuspendLayout()
        Me.ListOptionsMenu.SuspendLayout()
        Me.gbCalcBPSelect.SuspendLayout()
        Me.gbCalcTextColors.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuStripMain
        '
        Me.mnuStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuUpdateData, Me.ViewToolStripMenuItem, Me.mnuSettings, Me.mnuAbout})
        Me.mnuStripMain.Location = New System.Drawing.Point(20, 60)
        Me.mnuStripMain.Name = "mnuStripMain"
        Me.mnuStripMain.Size = New System.Drawing.Size(2061, 28)
        Me.mnuStripMain.TabIndex = 0
        Me.mnuStripMain.Text = "MainMenu"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectionAddChar, Me.mnuSelectionManageCharacters, Me.ToolStripSeparator1, Me.mnuSelectionExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(46, 24)
        Me.mnuFile.Text = "File"
        '
        'mnuSelectionAddChar
        '
        Me.mnuSelectionAddChar.Name = "mnuSelectionAddChar"
        Me.mnuSelectionAddChar.Size = New System.Drawing.Size(210, 26)
        Me.mnuSelectionAddChar.Text = "Add Characters"
        '
        'mnuSelectionManageCharacters
        '
        Me.mnuSelectionManageCharacters.Name = "mnuSelectionManageCharacters"
        Me.mnuSelectionManageCharacters.Size = New System.Drawing.Size(210, 26)
        Me.mnuSelectionManageCharacters.Text = "Manage Accounts"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(207, 6)
        '
        'mnuSelectionExit
        '
        Me.mnuSelectionExit.Name = "mnuSelectionExit"
        Me.mnuSelectionExit.Size = New System.Drawing.Size(210, 26)
        Me.mnuSelectionExit.Text = "Exit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemUpdatePrices, Me.mnuManageBlueprintsToolStripMenuItem, Me.mnuClearBPHistory})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(49, 24)
        Me.mnuEdit.Text = "Edit"
        '
        'mnuItemUpdatePrices
        '
        Me.mnuItemUpdatePrices.Name = "mnuItemUpdatePrices"
        Me.mnuItemUpdatePrices.Size = New System.Drawing.Size(216, 26)
        Me.mnuItemUpdatePrices.Text = "Prices"
        '
        'mnuManageBlueprintsToolStripMenuItem
        '
        Me.mnuManageBlueprintsToolStripMenuItem.Name = "mnuManageBlueprintsToolStripMenuItem"
        Me.mnuManageBlueprintsToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.mnuManageBlueprintsToolStripMenuItem.Text = "Manage Blueprints"
        '
        'mnuClearBPHistory
        '
        Me.mnuClearBPHistory.Name = "mnuClearBPHistory"
        Me.mnuClearBPHistory.Size = New System.Drawing.Size(216, 26)
        Me.mnuClearBPHistory.Text = "Clear BP History"
        '
        'mnuUpdateData
        '
        Me.mnuUpdateData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUpdateIndustryFacilities, Me.mnuUpdateESIMarketPrices, Me.mnuUpdateESIPublicStructures, Me.mnuChangeDummyCharacterName, Me.ToolStripSeparator6, Me.mnuResetData})
        Me.mnuUpdateData.Name = "mnuUpdateData"
        Me.mnuUpdateData.Size = New System.Drawing.Size(55, 24)
        Me.mnuUpdateData.Text = "Data"
        '
        'mnuUpdateIndustryFacilities
        '
        Me.mnuUpdateIndustryFacilities.Name = "mnuUpdateIndustryFacilities"
        Me.mnuUpdateIndustryFacilities.Size = New System.Drawing.Size(309, 26)
        Me.mnuUpdateIndustryFacilities.Text = "Update Industry Facilities"
        '
        'mnuUpdateESIMarketPrices
        '
        Me.mnuUpdateESIMarketPrices.Name = "mnuUpdateESIMarketPrices"
        Me.mnuUpdateESIMarketPrices.Size = New System.Drawing.Size(309, 26)
        Me.mnuUpdateESIMarketPrices.Text = "Update Adjusted Market Prices"
        '
        'mnuUpdateESIPublicStructures
        '
        Me.mnuUpdateESIPublicStructures.Name = "mnuUpdateESIPublicStructures"
        Me.mnuUpdateESIPublicStructures.Size = New System.Drawing.Size(309, 26)
        Me.mnuUpdateESIPublicStructures.Text = "Update Public Structures"
        '
        'mnuChangeDummyCharacterName
        '
        Me.mnuChangeDummyCharacterName.Name = "mnuChangeDummyCharacterName"
        Me.mnuChangeDummyCharacterName.Size = New System.Drawing.Size(309, 26)
        Me.mnuChangeDummyCharacterName.Text = "Change Dummy Character Name"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(306, 6)
        '
        'mnuResetData
        '
        Me.mnuResetData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuResetBlueprintData, Me.mnuResetIgnoredBPs, Me.mnuResetPriceData, Me.mnuResetAgents, Me.mnuResetIndustryJobs, Me.mnuResetAssets, Me.mnuResetMarketHistory, Me.mnuResetMarketOrders, Me.mnuResetESIPublicStructures, Me.mnuResetESIIndustryFacilities, Me.mnuResetESIMarketPrices, Me.mnuResetESIDates, Me.ToolStripSeparator4, Me.mnuResetAllData})
        Me.mnuResetData.Name = "mnuResetData"
        Me.mnuResetData.Size = New System.Drawing.Size(309, 26)
        Me.mnuResetData.Text = "Reset Data"
        '
        'mnuResetBlueprintData
        '
        Me.mnuResetBlueprintData.Name = "mnuResetBlueprintData"
        Me.mnuResetBlueprintData.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetBlueprintData.Text = "Reset Blueprint Data"
        '
        'mnuResetIgnoredBPs
        '
        Me.mnuResetIgnoredBPs.Name = "mnuResetIgnoredBPs"
        Me.mnuResetIgnoredBPs.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetIgnoredBPs.Text = "Reset All Ignored BPs"
        '
        'mnuResetPriceData
        '
        Me.mnuResetPriceData.Name = "mnuResetPriceData"
        Me.mnuResetPriceData.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetPriceData.Text = "Reset Price Data"
        '
        'mnuResetAgents
        '
        Me.mnuResetAgents.Name = "mnuResetAgents"
        Me.mnuResetAgents.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetAgents.Text = "Reset Research Agents"
        '
        'mnuResetIndustryJobs
        '
        Me.mnuResetIndustryJobs.Name = "mnuResetIndustryJobs"
        Me.mnuResetIndustryJobs.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetIndustryJobs.Text = "Reset Industry Jobs"
        '
        'mnuResetAssets
        '
        Me.mnuResetAssets.Name = "mnuResetAssets"
        Me.mnuResetAssets.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetAssets.Text = "Reset Assets"
        '
        'mnuResetMarketHistory
        '
        Me.mnuResetMarketHistory.Name = "mnuResetMarketHistory"
        Me.mnuResetMarketHistory.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetMarketHistory.Text = "Reset Market History"
        '
        'mnuResetMarketOrders
        '
        Me.mnuResetMarketOrders.Name = "mnuResetMarketOrders"
        Me.mnuResetMarketOrders.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetMarketOrders.Text = "Reset Market Orders"
        '
        'mnuResetESIPublicStructures
        '
        Me.mnuResetESIPublicStructures.Name = "mnuResetESIPublicStructures"
        Me.mnuResetESIPublicStructures.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetESIPublicStructures.Text = "Reset Public Structures"
        '
        'mnuResetESIIndustryFacilities
        '
        Me.mnuResetESIIndustryFacilities.Name = "mnuResetESIIndustryFacilities"
        Me.mnuResetESIIndustryFacilities.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetESIIndustryFacilities.Text = "Reset Industry System Indicies (ESI)"
        '
        'mnuResetESIMarketPrices
        '
        Me.mnuResetESIMarketPrices.Name = "mnuResetESIMarketPrices"
        Me.mnuResetESIMarketPrices.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetESIMarketPrices.Text = "Reset Adjusted Market Prices (ESI)"
        '
        'mnuResetESIDates
        '
        Me.mnuResetESIDates.Name = "mnuResetESIDates"
        Me.mnuResetESIDates.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetESIDates.Text = "Reset All ESI Cache Dates"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(320, 6)
        '
        'mnuResetAllData
        '
        Me.mnuResetAllData.Name = "mnuResetAllData"
        Me.mnuResetAllData.Size = New System.Drawing.Size(323, 26)
        Me.mnuResetAllData.Text = "Reset All Data"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectionShoppingList, Me.mnuCharacterSkills, Me.ToolStripSeparator5, Me.mnuCurrentResearchAgents, Me.mnuCurrentIndustryJobs, Me.ToolStripSeparator3, Me.mnuViewESIStatus})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'mnuSelectionShoppingList
        '
        Me.mnuSelectionShoppingList.Name = "mnuSelectionShoppingList"
        Me.mnuSelectionShoppingList.Size = New System.Drawing.Size(253, 26)
        Me.mnuSelectionShoppingList.Text = "Shopping List"
        '
        'mnuCharacterSkills
        '
        Me.mnuCharacterSkills.Name = "mnuCharacterSkills"
        Me.mnuCharacterSkills.Size = New System.Drawing.Size(253, 26)
        Me.mnuCharacterSkills.Text = "Character Skills"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(250, 6)
        '
        'mnuCurrentResearchAgents
        '
        Me.mnuCurrentResearchAgents.Name = "mnuCurrentResearchAgents"
        Me.mnuCurrentResearchAgents.Size = New System.Drawing.Size(253, 26)
        Me.mnuCurrentResearchAgents.Text = "Current Research Agents"
        '
        'mnuCurrentIndustryJobs
        '
        Me.mnuCurrentIndustryJobs.Name = "mnuCurrentIndustryJobs"
        Me.mnuCurrentIndustryJobs.Size = New System.Drawing.Size(253, 26)
        Me.mnuCurrentIndustryJobs.Text = "Current Industry Jobs"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(250, 6)
        '
        'mnuViewESIStatus
        '
        Me.mnuViewESIStatus.Name = "mnuViewESIStatus"
        Me.mnuViewESIStatus.Size = New System.Drawing.Size(253, 26)
        Me.mnuViewESIStatus.Text = "View ESI Status"
        '
        'mnuSettings
        '
        Me.mnuSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUserSettings, Me.mnuSelectDefaultChar})
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(76, 24)
        Me.mnuSettings.Text = "Settings"
        '
        'mnuUserSettings
        '
        Me.mnuUserSettings.Name = "mnuUserSettings"
        Me.mnuUserSettings.Size = New System.Drawing.Size(270, 26)
        Me.mnuUserSettings.Text = "Select Application Settings"
        '
        'mnuSelectDefaultChar
        '
        Me.mnuSelectDefaultChar.Name = "mnuSelectDefaultChar"
        Me.mnuSelectDefaultChar.Size = New System.Drawing.Size(270, 26)
        Me.mnuSelectDefaultChar.Text = "Select Default Character"
        '
        'mnuAbout
        '
        Me.mnuAbout.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPatchNotes, Me.mnuCheckforUpdates, Me.ToolStripSeparator2, Me.mnuSelectionAbout})
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(64, 24)
        Me.mnuAbout.Text = "About"
        '
        'mnuPatchNotes
        '
        Me.mnuPatchNotes.Name = "mnuPatchNotes"
        Me.mnuPatchNotes.Size = New System.Drawing.Size(213, 26)
        Me.mnuPatchNotes.Text = "View Patch Notes"
        '
        'mnuCheckforUpdates
        '
        Me.mnuCheckforUpdates.Name = "mnuCheckforUpdates"
        Me.mnuCheckforUpdates.Size = New System.Drawing.Size(213, 26)
        Me.mnuCheckforUpdates.Text = "Check for Updates"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(210, 6)
        '
        'mnuSelectionAbout
        '
        Me.mnuSelectionAbout.Name = "mnuSelectionAbout"
        Me.mnuSelectionAbout.Size = New System.Drawing.Size(213, 26)
        Me.mnuSelectionAbout.Text = "About IPH"
        '
        'ttBP
        '
        Me.ttBP.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'gbSystems
        '
        Me.gbSystems.Location = New System.Drawing.Point(0, 0)
        Me.gbSystems.Name = "gbSystems"
        Me.gbSystems.Size = New System.Drawing.Size(200, 100)
        Me.gbSystems.TabIndex = 0
        Me.gbSystems.TabStop = False
        '
        'ListOptionsMenu
        '
        Me.ListOptionsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ListOptionsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToShoppingListToolStripMenuItem, Me.IgnoreBlueprintToolStripMenuItem, Me.FavoriteBlueprintToolStripMenuItem})
        Me.ListOptionsMenu.Name = "ListOptionsMenu"
        Me.ListOptionsMenu.Size = New System.Drawing.Size(219, 76)
        Me.ListOptionsMenu.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'AddToShoppingListToolStripMenuItem
        '
        Me.AddToShoppingListToolStripMenuItem.Name = "AddToShoppingListToolStripMenuItem"
        Me.AddToShoppingListToolStripMenuItem.Size = New System.Drawing.Size(218, 24)
        Me.AddToShoppingListToolStripMenuItem.Text = "Add to Shopping List"
        '
        'IgnoreBlueprintToolStripMenuItem
        '
        Me.IgnoreBlueprintToolStripMenuItem.Name = "IgnoreBlueprintToolStripMenuItem"
        Me.IgnoreBlueprintToolStripMenuItem.Size = New System.Drawing.Size(218, 24)
        Me.IgnoreBlueprintToolStripMenuItem.Text = "Ignore Blueprint"
        '
        'FavoriteBlueprintToolStripMenuItem
        '
        Me.FavoriteBlueprintToolStripMenuItem.Name = "FavoriteBlueprintToolStripMenuItem"
        Me.FavoriteBlueprintToolStripMenuItem.Size = New System.Drawing.Size(218, 24)
        Me.FavoriteBlueprintToolStripMenuItem.Text = "Favorite Blueprint"
        '
        'CalcImageList
        '
        Me.CalcImageList.ImageStream = CType(resources.GetObject("CalcImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CalcImageList.TransparentColor = System.Drawing.Color.White
        Me.CalcImageList.Images.SetKeyName(0, "GreenUP.bmp")
        Me.CalcImageList.Images.SetKeyName(1, "RedDown.bmp")
        Me.CalcImageList.Images.SetKeyName(2, "T2.bmp")
        Me.CalcImageList.Images.SetKeyName(3, "T3.bmp")
        Me.CalcImageList.Images.SetKeyName(4, "Storyline.bmp")
        Me.CalcImageList.Images.SetKeyName(5, "Faction.bmp")
        Me.CalcImageList.Images.SetKeyName(6, "Blank.bmp")
        Me.CalcImageList.Images.SetKeyName(7, "Green Up Arrow.bmp")
        Me.CalcImageList.Images.SetKeyName(8, "Red Down Arrow.bmp")
        '
        'txtListEdit
        '
        Me.txtListEdit.Location = New System.Drawing.Point(1300, 4)
        Me.txtListEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtListEdit.Name = "txtListEdit"
        Me.txtListEdit.Size = New System.Drawing.Size(59, 22)
        Me.txtListEdit.TabIndex = 59
        Me.txtListEdit.TabStop = False
        Me.txtListEdit.Visible = False
        '
        'cmbEdit
        '
        Me.cmbEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEdit.FormattingEnabled = True
        Me.cmbEdit.ItemHeight = 16
        Me.cmbEdit.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmbEdit.Location = New System.Drawing.Point(1221, 4)
        Me.cmbEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEdit.Name = "cmbEdit"
        Me.cmbEdit.Size = New System.Drawing.Size(59, 24)
        Me.cmbEdit.TabIndex = 62
        Me.cmbEdit.TabStop = False
        Me.cmbEdit.Visible = False
        '
        'btnCancelUpdate
        '
        Me.btnCancelUpdate.Location = New System.Drawing.Point(507, 824)
        Me.btnCancelUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelUpdate.Name = "btnCancelUpdate"
        Me.btnCancelUpdate.Size = New System.Drawing.Size(141, 66)
        Me.btnCancelUpdate.TabIndex = 13
        Me.btnCancelUpdate.Text = "Cancel Update"
        Me.btnCancelUpdate.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnCancelUpdate.UseSelectable = True
        '
        'btnDownloadPrices
        '
        Me.btnDownloadPrices.Location = New System.Drawing.Point(366, 350)
        Me.btnDownloadPrices.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDownloadPrices.Name = "btnDownloadPrices"
        Me.btnDownloadPrices.Size = New System.Drawing.Size(141, 40)
        Me.btnDownloadPrices.TabIndex = 12
        Me.btnDownloadPrices.Text = "Download Prices"
        Me.btnDownloadPrices.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnDownloadPrices.UseSelectable = True
        '
        'btnCalcCalculate
        '
        Me.btnCalcCalculate.Location = New System.Drawing.Point(523, 350)
        Me.btnCalcCalculate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCalcCalculate.Name = "btnCalcCalculate"
        Me.btnCalcCalculate.Size = New System.Drawing.Size(120, 36)
        Me.btnCalcCalculate.TabIndex = 21
        Me.btnCalcCalculate.Text = "Calculate"
        Me.btnCalcCalculate.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnCalcCalculate.UseSelectable = True
        '
        'btnCalcSelectColumns
        '
        Me.btnCalcSelectColumns.Location = New System.Drawing.Point(1745, 461)
        Me.btnCalcSelectColumns.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCalcSelectColumns.Name = "btnCalcSelectColumns"
        Me.btnCalcSelectColumns.Size = New System.Drawing.Size(120, 36)
        Me.btnCalcSelectColumns.TabIndex = 23
        Me.btnCalcSelectColumns.Text = "Select Columns"
        Me.btnCalcSelectColumns.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnCalcSelectColumns.UseSelectable = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1742, 437)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(222, 17)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "set a default here and then delete"
        '
        'MetroProgressBar
        '
        Me.MetroProgressBar.Location = New System.Drawing.Point(92, 824)
        Me.MetroProgressBar.Name = "MetroProgressBar"
        Me.MetroProgressBar.Size = New System.Drawing.Size(380, 66)
        Me.MetroProgressBar.TabIndex = 76
        Me.MetroProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'mnuChar
        '
        Me.mnuChar.FormattingEnabled = True
        Me.mnuChar.ItemHeight = 24
        Me.mnuChar.Location = New System.Drawing.Point(23, 163)
        Me.mnuChar.Name = "mnuChar"
        Me.mnuChar.Size = New System.Drawing.Size(276, 30)
        Me.mnuChar.TabIndex = 88
        Me.mnuChar.UseSelectable = True
        '
        'chkCalcCanBuild
        '
        Me.chkCalcCanBuild.AutoSize = True
        Me.chkCalcCanBuild.BackColor = System.Drawing.Color.Transparent
        Me.chkCalcCanBuild.ForeColor = System.Drawing.Color.White
        Me.chkCalcCanBuild.Location = New System.Drawing.Point(152, 344)
        Me.chkCalcCanBuild.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCalcCanBuild.Name = "chkCalcCanBuild"
        Me.chkCalcCanBuild.Size = New System.Drawing.Size(206, 17)
        Me.chkCalcCanBuild.TabIndex = 89
        Me.chkCalcCanBuild.Text = "Only Calculate Items I Can Build"
        Me.chkCalcCanBuild.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.chkCalcCanBuild.UseSelectable = True
        '
        'autoShopping
        '
        Me.autoShopping.AutoSize = True
        Me.autoShopping.BackColor = System.Drawing.Color.Transparent
        Me.autoShopping.ForeColor = System.Drawing.Color.White
        Me.autoShopping.Location = New System.Drawing.Point(157, 373)
        Me.autoShopping.Margin = New System.Windows.Forms.Padding(4)
        Me.autoShopping.Name = "autoShopping"
        Me.autoShopping.Size = New System.Drawing.Size(142, 17)
        Me.autoShopping.TabIndex = 88
        Me.autoShopping.Text = "Automatic Shopping"
        Me.autoShopping.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.autoShopping.UseSelectable = True
        '
        'gbCalcBPSelect
        '
        Me.gbCalcBPSelect.BackColor = System.Drawing.Color.Transparent
        Me.gbCalcBPSelect.Controls.Add(Me.rbtnCalcBPFavorites)
        Me.gbCalcBPSelect.Controls.Add(Me.rbtnCalcAllBPs)
        Me.gbCalcBPSelect.Controls.Add(Me.rbtnCalcBPOwned)
        Me.gbCalcBPSelect.ForeColor = System.Drawing.Color.White
        Me.gbCalcBPSelect.Location = New System.Drawing.Point(25, 337)
        Me.gbCalcBPSelect.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCalcBPSelect.Name = "gbCalcBPSelect"
        Me.gbCalcBPSelect.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCalcBPSelect.Size = New System.Drawing.Size(119, 81)
        Me.gbCalcBPSelect.TabIndex = 14
        Me.gbCalcBPSelect.TabStop = False
        Me.gbCalcBPSelect.Text = "Load:"
        '
        'rbtnCalcBPFavorites
        '
        Me.rbtnCalcBPFavorites.AutoSize = True
        Me.rbtnCalcBPFavorites.Location = New System.Drawing.Point(10, 55)
        Me.rbtnCalcBPFavorites.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnCalcBPFavorites.Name = "rbtnCalcBPFavorites"
        Me.rbtnCalcBPFavorites.Size = New System.Drawing.Size(76, 17)
        Me.rbtnCalcBPFavorites.TabIndex = 2
        Me.rbtnCalcBPFavorites.Text = "Favorites"
        Me.rbtnCalcBPFavorites.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.rbtnCalcBPFavorites.UseSelectable = True
        '
        'rbtnCalcAllBPs
        '
        Me.rbtnCalcAllBPs.AutoSize = True
        Me.rbtnCalcAllBPs.Checked = True
        Me.rbtnCalcAllBPs.Location = New System.Drawing.Point(10, 18)
        Me.rbtnCalcAllBPs.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnCalcAllBPs.Name = "rbtnCalcAllBPs"
        Me.rbtnCalcAllBPs.Size = New System.Drawing.Size(99, 17)
        Me.rbtnCalcAllBPs.TabIndex = 0
        Me.rbtnCalcAllBPs.TabStop = True
        Me.rbtnCalcAllBPs.Text = "All Blueprints"
        Me.rbtnCalcAllBPs.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.rbtnCalcAllBPs.UseSelectable = True
        '
        'rbtnCalcBPOwned
        '
        Me.rbtnCalcBPOwned.AutoSize = True
        Me.rbtnCalcBPOwned.Location = New System.Drawing.Point(10, 36)
        Me.rbtnCalcBPOwned.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnCalcBPOwned.Name = "rbtnCalcBPOwned"
        Me.rbtnCalcBPOwned.Size = New System.Drawing.Size(89, 17)
        Me.rbtnCalcBPOwned.TabIndex = 1
        Me.rbtnCalcBPOwned.Text = "Owned BPs"
        Me.rbtnCalcBPOwned.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.rbtnCalcBPOwned.UseSelectable = True
        '
        'gbCalcTextColors
        '
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode6)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcText)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode3)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode4)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode5)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode2)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode1)
        Me.gbCalcTextColors.Location = New System.Drawing.Point(1549, 323)
        Me.gbCalcTextColors.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCalcTextColors.Name = "gbCalcTextColors"
        Me.gbCalcTextColors.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCalcTextColors.Size = New System.Drawing.Size(185, 38)
        Me.gbCalcTextColors.TabIndex = 18
        Me.gbCalcTextColors.TabStop = False
        '
        'lblCalcColorCode6
        '
        Me.lblCalcColorCode6.BackColor = System.Drawing.Color.LightGreen
        Me.lblCalcColorCode6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCalcColorCode6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCalcColorCode6.Location = New System.Drawing.Point(69, 12)
        Me.lblCalcColorCode6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcColorCode6.Name = "lblCalcColorCode6"
        Me.lblCalcColorCode6.Size = New System.Drawing.Size(18, 18)
        Me.lblCalcColorCode6.TabIndex = 5
        Me.lblCalcColorCode6.Text = "T"
        Me.lblCalcColorCode6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalcText
        '
        Me.lblCalcText.AutoSize = True
        Me.lblCalcText.Location = New System.Drawing.Point(8, 14)
        Me.lblCalcText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcText.Name = "lblCalcText"
        Me.lblCalcText.Size = New System.Drawing.Size(39, 17)
        Me.lblCalcText.TabIndex = 0
        Me.lblCalcText.Text = "Text:"
        '
        'lblCalcColorCode3
        '
        Me.lblCalcColorCode3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCalcColorCode3.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblCalcColorCode3.Location = New System.Drawing.Point(159, 12)
        Me.lblCalcColorCode3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcColorCode3.Name = "lblCalcColorCode3"
        Me.lblCalcColorCode3.Size = New System.Drawing.Size(18, 18)
        Me.lblCalcColorCode3.TabIndex = 2
        Me.lblCalcColorCode3.Text = "T"
        Me.lblCalcColorCode3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalcColorCode4
        '
        Me.lblCalcColorCode4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCalcColorCode4.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblCalcColorCode4.Location = New System.Drawing.Point(136, 12)
        Me.lblCalcColorCode4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcColorCode4.Name = "lblCalcColorCode4"
        Me.lblCalcColorCode4.Size = New System.Drawing.Size(18, 18)
        Me.lblCalcColorCode4.TabIndex = 3
        Me.lblCalcColorCode4.Text = "T"
        Me.lblCalcColorCode4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalcColorCode5
        '
        Me.lblCalcColorCode5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCalcColorCode5.ForeColor = System.Drawing.Color.DarkRed
        Me.lblCalcColorCode5.Location = New System.Drawing.Point(114, 12)
        Me.lblCalcColorCode5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcColorCode5.Name = "lblCalcColorCode5"
        Me.lblCalcColorCode5.Size = New System.Drawing.Size(18, 18)
        Me.lblCalcColorCode5.TabIndex = 4
        Me.lblCalcColorCode5.Text = "T"
        Me.lblCalcColorCode5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalcColorCode2
        '
        Me.lblCalcColorCode2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblCalcColorCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCalcColorCode2.ForeColor = System.Drawing.Color.Black
        Me.lblCalcColorCode2.Location = New System.Drawing.Point(91, 12)
        Me.lblCalcColorCode2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcColorCode2.Name = "lblCalcColorCode2"
        Me.lblCalcColorCode2.Size = New System.Drawing.Size(18, 18)
        Me.lblCalcColorCode2.TabIndex = 1
        Me.lblCalcColorCode2.Text = "T"
        Me.lblCalcColorCode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalcColorCode1
        '
        Me.lblCalcColorCode1.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.lblCalcColorCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCalcColorCode1.Location = New System.Drawing.Point(46, 12)
        Me.lblCalcColorCode1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalcColorCode1.Name = "lblCalcColorCode1"
        Me.lblCalcColorCode1.Size = New System.Drawing.Size(18, 18)
        Me.lblCalcColorCode1.TabIndex = 0
        Me.lblCalcColorCode1.Text = "T"
        Me.lblCalcColorCode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecommendation
        '
        Me.lblRecommendation.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.lblRecommendation.Location = New System.Drawing.Point(692, 432)
        Me.lblRecommendation.Name = "lblRecommendation"
        Me.lblRecommendation.Size = New System.Drawing.Size(409, 174)
        Me.lblRecommendation.TabIndex = 88
        Me.lblRecommendation.Text = "Recommendations will appear here"
        Me.lblRecommendation.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.lblRecommendation.WrapToLine = True
        '
        'pnlShoppingList
        '
        Me.pnlShoppingList.Location = New System.Drawing.Point(354, 432)
        Me.pnlShoppingList.Name = "pnlShoppingList"
        Me.pnlShoppingList.Size = New System.Drawing.Size(289, 58)
        Me.pnlShoppingList.TabIndex = 84
        Me.pnlShoppingList.Text = "Shopping List"
        Me.pnlShoppingList.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.pnlShoppingList.WrapToLine = True
        '
        'pnlSkills
        '
        Me.pnlSkills.AutoSize = True
        Me.pnlSkills.Location = New System.Drawing.Point(1097, 437)
        Me.pnlSkills.Name = "pnlSkills"
        Me.pnlSkills.Size = New System.Drawing.Size(38, 20)
        Me.pnlSkills.TabIndex = 85
        Me.pnlSkills.Text = "Skills"
        Me.pnlSkills.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'pnlStatus
        '
        Me.pnlStatus.AutoSize = True
        Me.pnlStatus.BackColor = System.Drawing.Color.Transparent
        Me.pnlStatus.Location = New System.Drawing.Point(268, 927)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(45, 20)
        Me.pnlStatus.TabIndex = 86
        Me.pnlStatus.Text = "Status"
        Me.pnlStatus.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'facilityPicker
        '
        Me.facilityPicker.Location = New System.Drawing.Point(23, 213)
        Me.facilityPicker.Name = "facilityPicker"
        Me.facilityPicker.Size = New System.Drawing.Size(423, 34)
        Me.facilityPicker.TabIndex = 89
        Me.facilityPicker.Text = "Pick a nearby system to manufacture in (lower taxes is better)"
        Me.facilityPicker.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'lblCharacterData
        '
        Me.lblCharacterData.Location = New System.Drawing.Point(24, 437)
        Me.lblCharacterData.Name = "lblCharacterData"
        Me.lblCharacterData.Size = New System.Drawing.Size(289, 58)
        Me.lblCharacterData.TabIndex = 90
        Me.lblCharacterData.Text = "Character Data"
        Me.lblCharacterData.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.lblCharacterData.WrapToLine = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.Location = New System.Drawing.Point(23, 126)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(423, 34)
        Me.MetroLabel1.TabIndex = 91
        Me.MetroLabel1.Text = "Pick a character or add one"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'lstManufacturing
        '
        Me.lstManufacturing.AllowColumnReorder = True
        Me.lstManufacturing.ContextMenuStrip = Me.ListOptionsMenu
        Me.lstManufacturing.FullRowSelect = True
        Me.lstManufacturing.GridLines = True
        Me.lstManufacturing.HideSelection = False
        Me.lstManufacturing.Location = New System.Drawing.Point(827, 581)
        Me.lstManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.lstManufacturing.Name = "lstManufacturing"
        Me.lstManufacturing.OwnerDraw = True
        Me.lstManufacturing.Size = New System.Drawing.Size(453, 434)
        Me.lstManufacturing.TabIndex = 17
        Me.lstManufacturing.UseCompatibleStateImageBehavior = False
        Me.lstManufacturing.View = System.Windows.Forms.View.Details
        '
        'CalcBaseFacility
        '
        Me.CalcBaseFacility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CalcBaseFacility.Location = New System.Drawing.Point(25, 252)
        Me.CalcBaseFacility.Margin = New System.Windows.Forms.Padding(5)
        Me.CalcBaseFacility.Name = "CalcBaseFacility"
        Me.CalcBaseFacility.Size = New System.Drawing.Size(1065, 58)
        Me.CalcBaseFacility.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2101, 1056)
        Me.Controls.Add(Me.lstManufacturing)
        Me.Controls.Add(Me.gbCalcTextColors)
        Me.Controls.Add(Me.autoShopping)
        Me.Controls.Add(Me.chkCalcCanBuild)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.mnuChar)
        Me.Controls.Add(Me.gbCalcBPSelect)
        Me.Controls.Add(Me.lblCharacterData)
        Me.Controls.Add(Me.facilityPicker)
        Me.Controls.Add(Me.lblRecommendation)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlSkills)
        Me.Controls.Add(Me.pnlShoppingList)
        Me.Controls.Add(Me.MetroProgressBar)
        Me.Controls.Add(Me.CalcBaseFacility)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbEdit)
        Me.Controls.Add(Me.btnCalcSelectColumns)
        Me.Controls.Add(Me.txtListEdit)
        Me.Controls.Add(Me.mnuStripMain)
        Me.Controls.Add(Me.btnCalcCalculate)
        Me.Controls.Add(Me.btnCancelUpdate)
        Me.Controls.Add(Me.btnDownloadPrices)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuStripMain
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EasyIPH"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.mnuStripMain.ResumeLayout(False)
        Me.mnuStripMain.PerformLayout()
        Me.ListOptionsMenu.ResumeLayout(False)
        Me.gbCalcBPSelect.ResumeLayout(False)
        Me.gbCalcBPSelect.PerformLayout()
        Me.gbCalcTextColors.ResumeLayout(False)
        Me.gbCalcTextColors.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectionExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectionAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectDefaultChar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemUpdatePrices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectionAddChar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuManageBlueprintsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUserSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbSystems As System.Windows.Forms.GroupBox
    Friend WithEvents ttBP As System.Windows.Forms.ToolTip
    Friend WithEvents mnuCheckforUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectionShoppingList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCharacterSkills As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSelectionManageCharacters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCurrentResearchAgents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuPatchNotes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCurrentIndustryJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUpdateData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateIndustryFacilities As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateESIMarketPrices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuResetData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetBlueprintData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetPriceData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetAgents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetIndustryJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetAssets As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuResetAllData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetESIDates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListOptionsMenu As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents mnuResetESIMarketPrices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetESIIndustryFacilities As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IgnoreBlueprintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetIgnoredBPs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttUpdatePrices As System.Windows.Forms.ToolTip
    Friend WithEvents ttManufacturing As System.Windows.Forms.ToolTip
    Friend WithEvents ttDatacores As System.Windows.Forms.ToolTip
    Friend WithEvents ttReactions As System.Windows.Forms.ToolTip
    Friend WithEvents ttMining As System.Windows.Forms.ToolTip
    Friend WithEvents ttPI As System.Windows.Forms.ToolTip
    Friend WithEvents CalcImageList As System.Windows.Forms.ImageList
    Friend WithEvents AddToShoppingListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClearBPHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetMarketHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetMarketOrders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateESIPublicStructures As ToolStripMenuItem
    Friend WithEvents mnuResetESIPublicStructures As ToolStripMenuItem
    Friend WithEvents mnuChangeDummyCharacterName As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuViewESIStatus As ToolStripMenuItem
    Friend WithEvents FavoriteBlueprintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtListEdit As System.Windows.Forms.TextBox
    Friend WithEvents cmbEdit As ComboBox
    Friend WithEvents CalcBaseFacility As ManufacturingFacility
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDownloadPrices As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCalcCalculate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCalcSelectColumns As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroProgressBar As MetroFramework.Controls.MetroProgressBar
    Friend WithEvents gbCalcBPSelect As GroupBox
    Friend WithEvents rbtnCalcBPFavorites As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rbtnCalcAllBPs As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rbtnCalcBPOwned As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents gbCalcTextColors As GroupBox
    Friend WithEvents lblCalcColorCode6 As Label
    Friend WithEvents lblCalcText As Label
    Friend WithEvents lblCalcColorCode3 As Label
    Friend WithEvents lblCalcColorCode4 As Label
    Friend WithEvents lblCalcColorCode5 As Label
    Friend WithEvents lblCalcColorCode2 As Label
    Friend WithEvents lblCalcColorCode1 As Label
    Friend WithEvents lstManufacturing As ManufacturingListView
    Friend WithEvents pnlShoppingList As MetroFramework.Controls.MetroLabel
    Friend WithEvents pnlSkills As MetroFramework.Controls.MetroLabel
    Friend WithEvents pnlStatus As MetroFramework.Controls.MetroLabel
    Friend WithEvents mnuChar As MetroFramework.Controls.MetroComboBox
    Friend WithEvents autoShopping As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents chkCalcCanBuild As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents lblRecommendation As MetroFramework.Controls.MetroLabel
    Friend WithEvents facilityPicker As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblCharacterData As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
End Class
