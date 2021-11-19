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
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManageBlueprintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectionShoppingList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCharacterSkills = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCurrentResearchAgents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCurrentIndustryJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.MetroProgressBar = New MetroFramework.Controls.MetroProgressBar()
        Me.mnuChar = New MetroFramework.Controls.MetroComboBox()
        Me.chkCalcCanBuild = New MetroFramework.Controls.MetroCheckBox()
        Me.autoShopping = New MetroFramework.Controls.MetroCheckBox()
        Me.gbCalcBPSelect = New System.Windows.Forms.GroupBox()
        Me.rbtnCalcBPFavorites = New MetroFramework.Controls.MetroRadioButton()
        Me.rbtnCalcAllBPs = New MetroFramework.Controls.MetroRadioButton()
        Me.rbtnCalcBPOwned = New MetroFramework.Controls.MetroRadioButton()
        Me.pnlShoppingList = New MetroFramework.Controls.MetroLabel()
        Me.pnlStatus = New MetroFramework.Controls.MetroLabel()
        Me.facilityPicker = New MetroFramework.Controls.MetroLabel()
        Me.lblCharacterData = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.lblRecommendation = New MetroFramework.Controls.MetroLabel()
        Me.gbCalcTextColors = New System.Windows.Forms.GroupBox()
        Me.lblCalcColorCode6 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode3 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode4 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode5 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode2 = New System.Windows.Forms.Label()
        Me.lblCalcColorCode1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnAddChar = New MetroFramework.Controls.MetroButton()
        Me.CalcBaseFacility = New EVE_Isk_per_Hour.ManufacturingFacility()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstManufacturing = New EVE_Isk_per_Hour.ManufacturingListView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.FrmAbout2 = New EVE_Isk_per_Hour.frmAbout()
        Me.FrmSettings2 = New EVE_Isk_per_Hour.frmSettings()
        Me.btnResetAll = New MetroFramework.Controls.MetroButton()
        Me.btnManageChar = New MetroFramework.Controls.MetroButton()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.FrmAbout1 = New EVE_Isk_per_Hour.frmAbout()
        Me.FrmSettings1 = New EVE_Isk_per_Hour.frmSettings()
        Me.mnuStripMain.SuspendLayout()
        Me.ListOptionsMenu.SuspendLayout()
        Me.gbCalcBPSelect.SuspendLayout()
        Me.gbCalcTextColors.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuStripMain
        '
        Me.mnuStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit, Me.ViewToolStripMenuItem})
        Me.mnuStripMain.Location = New System.Drawing.Point(20, 60)
        Me.mnuStripMain.Name = "mnuStripMain"
        Me.mnuStripMain.Size = New System.Drawing.Size(1664, 28)
        Me.mnuStripMain.TabIndex = 0
        Me.mnuStripMain.Text = "MainMenu"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManageBlueprintsToolStripMenuItem})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(49, 24)
        Me.mnuEdit.Text = "Edit"
        '
        'mnuManageBlueprintsToolStripMenuItem
        '
        Me.mnuManageBlueprintsToolStripMenuItem.Name = "mnuManageBlueprintsToolStripMenuItem"
        Me.mnuManageBlueprintsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.mnuManageBlueprintsToolStripMenuItem.Text = "Manage Blueprints"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectionShoppingList, Me.mnuCharacterSkills, Me.ToolStripSeparator5, Me.mnuCurrentResearchAgents, Me.mnuCurrentIndustryJobs, Me.ToolStripSeparator3})
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
        Me.btnCancelUpdate.Location = New System.Drawing.Point(183, 565)
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
        Me.btnDownloadPrices.Location = New System.Drawing.Point(56, 489)
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
        Me.btnCalcCalculate.Location = New System.Drawing.Point(295, 505)
        Me.btnCalcCalculate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCalcCalculate.Name = "btnCalcCalculate"
        Me.btnCalcCalculate.Size = New System.Drawing.Size(120, 36)
        Me.btnCalcCalculate.TabIndex = 21
        Me.btnCalcCalculate.Text = "Calculate"
        Me.btnCalcCalculate.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnCalcCalculate.UseSelectable = True
        '
        'MetroProgressBar
        '
        Me.MetroProgressBar.Location = New System.Drawing.Point(35, 647)
        Me.MetroProgressBar.Name = "MetroProgressBar"
        Me.MetroProgressBar.Size = New System.Drawing.Size(380, 66)
        Me.MetroProgressBar.TabIndex = 76
        Me.MetroProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'mnuChar
        '
        Me.mnuChar.FormattingEnabled = True
        Me.mnuChar.ItemHeight = 24
        Me.mnuChar.Location = New System.Drawing.Point(35, 168)
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
        Me.chkCalcCanBuild.Location = New System.Drawing.Point(282, 404)
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
        Me.autoShopping.Location = New System.Drawing.Point(295, 456)
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
        Me.gbCalcBPSelect.Location = New System.Drawing.Point(78, 359)
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
        'pnlShoppingList
        '
        Me.pnlShoppingList.Location = New System.Drawing.Point(512, 518)
        Me.pnlShoppingList.Name = "pnlShoppingList"
        Me.pnlShoppingList.Size = New System.Drawing.Size(289, 58)
        Me.pnlShoppingList.TabIndex = 84
        Me.pnlShoppingList.Text = "Shopping List"
        Me.pnlShoppingList.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.pnlShoppingList.WrapToLine = True
        '
        'pnlStatus
        '
        Me.pnlStatus.AutoSize = True
        Me.pnlStatus.BackColor = System.Drawing.Color.Transparent
        Me.pnlStatus.Location = New System.Drawing.Point(226, 756)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(45, 20)
        Me.pnlStatus.TabIndex = 86
        Me.pnlStatus.Text = "Status"
        Me.pnlStatus.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'facilityPicker
        '
        Me.facilityPicker.Location = New System.Drawing.Point(35, 225)
        Me.facilityPicker.Name = "facilityPicker"
        Me.facilityPicker.Size = New System.Drawing.Size(423, 34)
        Me.facilityPicker.TabIndex = 89
        Me.facilityPicker.Text = "Pick a nearby system to manufacture in (lower taxes is better)"
        Me.facilityPicker.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'lblCharacterData
        '
        Me.lblCharacterData.Location = New System.Drawing.Point(512, 437)
        Me.lblCharacterData.Name = "lblCharacterData"
        Me.lblCharacterData.Size = New System.Drawing.Size(289, 58)
        Me.lblCharacterData.TabIndex = 90
        Me.lblCharacterData.Text = "Character Data"
        Me.lblCharacterData.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.lblCharacterData.WrapToLine = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.Location = New System.Drawing.Point(35, 100)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(423, 34)
        Me.MetroLabel1.TabIndex = 91
        Me.MetroLabel1.Text = "Pick a character or add one"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'lblRecommendation
        '
        Me.lblRecommendation.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.lblRecommendation.Location = New System.Drawing.Point(441, 602)
        Me.lblRecommendation.Name = "lblRecommendation"
        Me.lblRecommendation.Size = New System.Drawing.Size(409, 174)
        Me.lblRecommendation.TabIndex = 88
        Me.lblRecommendation.Text = "Recommendations will appear here"
        Me.lblRecommendation.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.lblRecommendation.WrapToLine = True
        '
        'gbCalcTextColors
        '
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode6)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode3)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode4)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode5)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode2)
        Me.gbCalcTextColors.Controls.Add(Me.lblCalcColorCode1)
        Me.gbCalcTextColors.Location = New System.Drawing.Point(18, 22)
        Me.gbCalcTextColors.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCalcTextColors.Name = "gbCalcTextColors"
        Me.gbCalcTextColors.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCalcTextColors.Size = New System.Drawing.Size(185, 38)
        Me.gbCalcTextColors.TabIndex = 93
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(44, 124)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1625, 846)
        Me.TabControl1.TabIndex = 95
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.btnAddChar)
        Me.TabPage1.Controls.Add(Me.lblRecommendation)
        Me.TabPage1.Controls.Add(Me.btnCancelUpdate)
        Me.TabPage1.Controls.Add(Me.MetroLabel1)
        Me.TabPage1.Controls.Add(Me.autoShopping)
        Me.TabPage1.Controls.Add(Me.mnuChar)
        Me.TabPage1.Controls.Add(Me.MetroProgressBar)
        Me.TabPage1.Controls.Add(Me.facilityPicker)
        Me.TabPage1.Controls.Add(Me.gbCalcBPSelect)
        Me.TabPage1.Controls.Add(Me.CalcBaseFacility)
        Me.TabPage1.Controls.Add(Me.chkCalcCanBuild)
        Me.TabPage1.Controls.Add(Me.pnlStatus)
        Me.TabPage1.Controls.Add(Me.btnCalcCalculate)
        Me.TabPage1.Controls.Add(Me.btnDownloadPrices)
        Me.TabPage1.Controls.Add(Me.pnlShoppingList)
        Me.TabPage1.Controls.Add(Me.lblCharacterData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1617, 817)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'btnAddChar
        '
        Me.btnAddChar.Location = New System.Drawing.Point(338, 168)
        Me.btnAddChar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddChar.Name = "btnAddChar"
        Me.btnAddChar.Size = New System.Drawing.Size(120, 36)
        Me.btnAddChar.TabIndex = 92
        Me.btnAddChar.Text = "Add Character"
        Me.btnAddChar.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnAddChar.UseSelectable = True
        '
        'CalcBaseFacility
        '
        Me.CalcBaseFacility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CalcBaseFacility.Location = New System.Drawing.Point(35, 277)
        Me.CalcBaseFacility.Margin = New System.Windows.Forms.Padding(5)
        Me.CalcBaseFacility.Name = "CalcBaseFacility"
        Me.CalcBaseFacility.Size = New System.Drawing.Size(1065, 58)
        Me.CalcBaseFacility.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.Controls.Add(Me.gbCalcTextColors)
        Me.TabPage2.Controls.Add(Me.lstManufacturing)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1617, 817)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'lstManufacturing
        '
        Me.lstManufacturing.AllowColumnReorder = True
        Me.lstManufacturing.BackColor = System.Drawing.Color.Gray
        Me.lstManufacturing.ContextMenuStrip = Me.ListOptionsMenu
        Me.lstManufacturing.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lstManufacturing.FullRowSelect = True
        Me.lstManufacturing.GridLines = True
        Me.lstManufacturing.HideSelection = False
        Me.lstManufacturing.Location = New System.Drawing.Point(18, 82)
        Me.lstManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.lstManufacturing.Name = "lstManufacturing"
        Me.lstManufacturing.OwnerDraw = True
        Me.lstManufacturing.Size = New System.Drawing.Size(1581, 717)
        Me.lstManufacturing.TabIndex = 94
        Me.lstManufacturing.UseCompatibleStateImageBehavior = False
        Me.lstManufacturing.UseSelectable = True
        Me.lstManufacturing.View = System.Windows.Forms.View.Details
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Gray
        Me.TabPage3.Controls.Add(Me.FrmAbout2)
        Me.TabPage3.Controls.Add(Me.FrmSettings2)
        Me.TabPage3.Controls.Add(Me.btnResetAll)
        Me.TabPage3.Controls.Add(Me.btnManageChar)
        Me.TabPage3.Controls.Add(Me.btnUpdate)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1617, 817)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        '
        'FrmAbout2
        '
        Me.FrmAbout2.AutoSize = True
        Me.FrmAbout2.Location = New System.Drawing.Point(88, 147)
        Me.FrmAbout2.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmAbout2.Name = "FrmAbout2"
        Me.FrmAbout2.Padding = New System.Windows.Forms.Padding(11)
        Me.FrmAbout2.Size = New System.Drawing.Size(489, 425)
        Me.FrmAbout2.TabIndex = 26
        '
        'FrmSettings2
        '
        Me.FrmSettings2.AutoSize = True
        Me.FrmSettings2.Location = New System.Drawing.Point(744, 78)
        Me.FrmSettings2.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmSettings2.Name = "FrmSettings2"
        Me.FrmSettings2.Size = New System.Drawing.Size(828, 566)
        Me.FrmSettings2.TabIndex = 25
        '
        'btnResetAll
        '
        Me.btnResetAll.BackColor = System.Drawing.Color.Red
        Me.btnResetAll.ForeColor = System.Drawing.Color.DarkRed
        Me.btnResetAll.Location = New System.Drawing.Point(1233, 748)
        Me.btnResetAll.Margin = New System.Windows.Forms.Padding(4)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(120, 36)
        Me.btnResetAll.TabIndex = 24
        Me.btnResetAll.Text = "Reset All Data"
        Me.btnResetAll.UseSelectable = True
        '
        'btnManageChar
        '
        Me.btnManageChar.Location = New System.Drawing.Point(1019, 748)
        Me.btnManageChar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnManageChar.Name = "btnManageChar"
        Me.btnManageChar.Size = New System.Drawing.Size(120, 36)
        Me.btnManageChar.TabIndex = 23
        Me.btnManageChar.Text = "Manage Characters"
        Me.btnManageChar.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnManageChar.UseSelectable = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(785, 748)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(120, 36)
        Me.btnUpdate.TabIndex = 22
        Me.btnUpdate.Text = "Check for Updates"
        Me.btnUpdate.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnUpdate.UseSelectable = True
        '
        'FrmAbout1
        '
        Me.FrmAbout1.AutoSize = True
        Me.FrmAbout1.Location = New System.Drawing.Point(224, 224)
        Me.FrmAbout1.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmAbout1.Name = "FrmAbout1"
        Me.FrmAbout1.Padding = New System.Windows.Forms.Padding(11)
        Me.FrmAbout1.Size = New System.Drawing.Size(536, 448)
        Me.FrmAbout1.TabIndex = 0
        Me.FrmAbout1.Visible = False
        '
        'FrmSettings1
        '
        Me.FrmSettings1.AutoSize = True
        Me.FrmSettings1.Location = New System.Drawing.Point(1295, 389)
        Me.FrmSettings1.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmSettings1.Name = "FrmSettings1"
        Me.FrmSettings1.Size = New System.Drawing.Size(849, 613)
        Me.FrmSettings1.TabIndex = 0
        Me.FrmSettings1.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1704, 1034)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmbEdit)
        Me.Controls.Add(Me.txtListEdit)
        Me.Controls.Add(Me.mnuStripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuStripMain
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EasyIPH"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.TransparencyKey = System.Drawing.Color.LightBlue
        Me.mnuStripMain.ResumeLayout(False)
        Me.mnuStripMain.PerformLayout()
        Me.ListOptionsMenu.ResumeLayout(False)
        Me.gbCalcBPSelect.ResumeLayout(False)
        Me.gbCalcBPSelect.PerformLayout()
        Me.gbCalcTextColors.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuManageBlueprintsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbSystems As System.Windows.Forms.GroupBox
    Friend WithEvents ttBP As System.Windows.Forms.ToolTip
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectionShoppingList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCharacterSkills As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCurrentResearchAgents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuCurrentIndustryJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListOptionsMenu As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents IgnoreBlueprintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttUpdatePrices As System.Windows.Forms.ToolTip
    Friend WithEvents ttManufacturing As System.Windows.Forms.ToolTip
    Friend WithEvents ttDatacores As System.Windows.Forms.ToolTip
    Friend WithEvents ttReactions As System.Windows.Forms.ToolTip
    Friend WithEvents ttMining As System.Windows.Forms.ToolTip
    Friend WithEvents ttPI As System.Windows.Forms.ToolTip
    Friend WithEvents CalcImageList As System.Windows.Forms.ImageList
    Friend WithEvents AddToShoppingListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents FavoriteBlueprintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtListEdit As System.Windows.Forms.TextBox
    Friend WithEvents cmbEdit As ComboBox
    Friend WithEvents CalcBaseFacility As ManufacturingFacility
    Friend WithEvents btnCancelUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDownloadPrices As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCalcCalculate As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroProgressBar As MetroFramework.Controls.MetroProgressBar
    Friend WithEvents gbCalcBPSelect As GroupBox
    Friend WithEvents rbtnCalcBPFavorites As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rbtnCalcAllBPs As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rbtnCalcBPOwned As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents pnlShoppingList As MetroFramework.Controls.MetroLabel
    Friend WithEvents pnlStatus As MetroFramework.Controls.MetroLabel
    Friend WithEvents mnuChar As MetroFramework.Controls.MetroComboBox
    Friend WithEvents autoShopping As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents chkCalcCanBuild As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents facilityPicker As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblCharacterData As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblRecommendation As MetroFramework.Controls.MetroLabel
    Friend WithEvents gbCalcTextColors As GroupBox
    Friend WithEvents lblCalcColorCode6 As Label
    Friend WithEvents lblCalcColorCode3 As Label
    Friend WithEvents lblCalcColorCode4 As Label
    Friend WithEvents lblCalcColorCode5 As Label
    Friend WithEvents lblCalcColorCode2 As Label
    Friend WithEvents lblCalcColorCode1 As Label
    Friend WithEvents lstManufacturing As ManufacturingListView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents FrmAbout1 As frmAbout
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnAddChar As MetroFramework.Controls.MetroButton
    Friend WithEvents btnManageChar As MetroFramework.Controls.MetroButton
    Friend WithEvents btnResetAll As MetroFramework.Controls.MetroButton
    Friend WithEvents FrmSettings1 As frmSettings
    Friend WithEvents FrmAbout2 As frmAbout
    Friend WithEvents FrmSettings2 As frmSettings
End Class
