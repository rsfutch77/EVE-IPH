﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.mnuStripMain = New System.Windows.Forms.MenuStrip()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManageBlueprintsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCharacterSkills = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.FrmShoppingList1 = New Easy_IPH.frmShoppingList()
        Me.trkTrips = New MetroFramework.Controls.MetroTrackBar()
        Me.btnAddChar = New MetroFramework.Controls.MetroButton()
        Me.CalcBaseFacility = New Easy_IPH.ManufacturingFacility()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstManufacturing = New Easy_IPH.ManufacturingListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelVersion = New MetroFramework.Controls.MetroLabel()
        Me.ReportBugIcon = New System.Windows.Forms.PictureBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.VisitWebIcon = New System.Windows.Forms.PictureBox()
        Me.btnDonate = New MetroFramework.Controls.MetroButton()
        Me.PateronIcon = New System.Windows.Forms.PictureBox()
        Me.btnVisitweb = New MetroFramework.Controls.MetroButton()
        Me.btnReportbug = New MetroFramework.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnResetAll = New MetroFramework.Controls.MetroButton()
        Me.btnManageChar = New MetroFramework.Controls.MetroButton()
        Me.chkDisableTracking = New System.Windows.Forms.CheckBox()
        Me.mnuStripMain.SuspendLayout()
        Me.ListOptionsMenu.SuspendLayout()
        Me.gbCalcBPSelect.SuspendLayout()
        Me.gbCalcTextColors.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ReportBugIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisitWebIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PateronIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuStripMain
        '
        Me.mnuStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit, Me.ViewToolStripMenuItem})
        Me.mnuStripMain.Location = New System.Drawing.Point(20, 60)
        Me.mnuStripMain.Name = "mnuStripMain"
        Me.mnuStripMain.Size = New System.Drawing.Size(1882, 28)
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
        Me.mnuManageBlueprintsToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.mnuManageBlueprintsToolStripMenuItem.Text = "Manage Blueprints"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCharacterSkills, Me.ToolStripSeparator5, Me.mnuCurrentIndustryJobs, Me.ToolStripSeparator3})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'mnuCharacterSkills
        '
        Me.mnuCharacterSkills.Name = "mnuCharacterSkills"
        Me.mnuCharacterSkills.Size = New System.Drawing.Size(229, 26)
        Me.mnuCharacterSkills.Text = "Character Skills"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(226, 6)
        '
        'mnuCurrentIndustryJobs
        '
        Me.mnuCurrentIndustryJobs.Name = "mnuCurrentIndustryJobs"
        Me.mnuCurrentIndustryJobs.Size = New System.Drawing.Size(229, 26)
        Me.mnuCurrentIndustryJobs.Text = "Current Industry Jobs"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(226, 6)
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
        Me.facilityPicker.Location = New System.Drawing.Point(35, 223)
        Me.facilityPicker.Name = "facilityPicker"
        Me.facilityPicker.Size = New System.Drawing.Size(423, 49)
        Me.facilityPicker.TabIndex = 89
        Me.facilityPicker.Text = "Manufacturing Station:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pick a nearby system to manufacture in (lower taxes is be" &
    "tter)"
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
        Me.TabControl1.Location = New System.Drawing.Point(23, 165)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1877, 897)
        Me.TabControl1.TabIndex = 95
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(14, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.FrmShoppingList1)
        Me.TabPage1.Controls.Add(Me.trkTrips)
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
        Me.TabPage1.Controls.Add(Me.lblCharacterData)
        Me.TabPage1.ForeColor = System.Drawing.Color.DimGray
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1869, 868)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'FrmShoppingList1
        '
        Me.FrmShoppingList1.AutoSize = True
        Me.FrmShoppingList1.Location = New System.Drawing.Point(857, 30)
        Me.FrmShoppingList1.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmShoppingList1.Name = "FrmShoppingList1"
        Me.FrmShoppingList1.Size = New System.Drawing.Size(927, 814)
        Me.FrmShoppingList1.TabIndex = 95
        '
        'trkTrips
        '
        Me.trkTrips.BackColor = System.Drawing.Color.Transparent
        Me.trkTrips.Location = New System.Drawing.Point(539, 168)
        Me.trkTrips.Maximum = 6
        Me.trkTrips.Minimum = 2
        Me.trkTrips.Name = "trkTrips"
        Me.trkTrips.Size = New System.Drawing.Size(227, 62)
        Me.trkTrips.TabIndex = 94
        Me.trkTrips.Text = "Trips"
        Me.trkTrips.Value = 6
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
        Me.CalcBaseFacility.Size = New System.Drawing.Size(787, 58)
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
        Me.TabPage2.Size = New System.Drawing.Size(1869, 868)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'lstManufacturing
        '
        Me.lstManufacturing.AllowColumnReorder = True
        Me.lstManufacturing.AllowSorting = True
        Me.lstManufacturing.BackColor = System.Drawing.Color.Gray
        Me.lstManufacturing.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstManufacturing.ContextMenuStrip = Me.ListOptionsMenu
        Me.lstManufacturing.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lstManufacturing.FullRowSelect = True
        Me.lstManufacturing.GridLines = True
        Me.lstManufacturing.HideSelection = False
        Me.lstManufacturing.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3, ListViewItem4})
        Me.lstManufacturing.Location = New System.Drawing.Point(18, 82)
        Me.lstManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.lstManufacturing.Name = "lstManufacturing"
        Me.lstManufacturing.OwnerDraw = True
        Me.lstManufacturing.Size = New System.Drawing.Size(1581, 717)
        Me.lstManufacturing.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lstManufacturing.TabIndex = 94
        Me.lstManufacturing.UseCompatibleStateImageBehavior = False
        Me.lstManufacturing.UseSelectable = True
        Me.lstManufacturing.View = System.Windows.Forms.View.Details
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Gray
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.btnResetAll)
        Me.TabPage3.Controls.Add(Me.btnManageChar)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1869, 868)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkDisableTracking)
        Me.Panel1.Controls.Add(Me.LabelVersion)
        Me.Panel1.Controls.Add(Me.ReportBugIcon)
        Me.Panel1.Controls.Add(Me.MetroLabel2)
        Me.Panel1.Controls.Add(Me.VisitWebIcon)
        Me.Panel1.Controls.Add(Me.btnDonate)
        Me.Panel1.Controls.Add(Me.PateronIcon)
        Me.Panel1.Controls.Add(Me.btnVisitweb)
        Me.Panel1.Controls.Add(Me.btnReportbug)
        Me.Panel1.Location = New System.Drawing.Point(55, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(647, 746)
        Me.Panel1.TabIndex = 107
        '
        'LabelVersion
        '
        Me.LabelVersion.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.LabelVersion.Location = New System.Drawing.Point(14, 10)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(181, 35)
        Me.LabelVersion.TabIndex = 103
        Me.LabelVersion.Text = "Version X.X.XXXXXX"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelVersion.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.LabelVersion.WrapToLine = True
        '
        'ReportBugIcon
        '
        Me.ReportBugIcon.ErrorImage = Nothing
        Me.ReportBugIcon.Image = CType(resources.GetObject("ReportBugIcon.Image"), System.Drawing.Image)
        Me.ReportBugIcon.Location = New System.Drawing.Point(17, 380)
        Me.ReportBugIcon.Name = "ReportBugIcon"
        Me.ReportBugIcon.Size = New System.Drawing.Size(57, 65)
        Me.ReportBugIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ReportBugIcon.TabIndex = 106
        Me.ReportBugIcon.TabStop = False
        '
        'MetroLabel2
        '
        Me.MetroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.MetroLabel2.Location = New System.Drawing.Point(14, 50)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(409, 174)
        Me.MetroLabel2.TabIndex = 102
        Me.MetroLabel2.Text = resources.GetString("MetroLabel2.Text")
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroLabel2.WrapToLine = True
        '
        'VisitWebIcon
        '
        Me.VisitWebIcon.ErrorImage = Nothing
        Me.VisitWebIcon.Image = CType(resources.GetObject("VisitWebIcon.Image"), System.Drawing.Image)
        Me.VisitWebIcon.Location = New System.Drawing.Point(17, 306)
        Me.VisitWebIcon.Name = "VisitWebIcon"
        Me.VisitWebIcon.Size = New System.Drawing.Size(57, 65)
        Me.VisitWebIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.VisitWebIcon.TabIndex = 105
        Me.VisitWebIcon.TabStop = False
        '
        'btnDonate
        '
        Me.btnDonate.Location = New System.Drawing.Point(81, 246)
        Me.btnDonate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDonate.Name = "btnDonate"
        Me.btnDonate.Size = New System.Drawing.Size(266, 52)
        Me.btnDonate.TabIndex = 96
        Me.btnDonate.Text = "Donate to the original creator of EVEIPH"
        Me.btnDonate.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnDonate.UseSelectable = True
        '
        'PateronIcon
        '
        Me.PateronIcon.ErrorImage = Nothing
        Me.PateronIcon.Image = CType(resources.GetObject("PateronIcon.Image"), System.Drawing.Image)
        Me.PateronIcon.Location = New System.Drawing.Point(17, 233)
        Me.PateronIcon.Name = "PateronIcon"
        Me.PateronIcon.Size = New System.Drawing.Size(57, 65)
        Me.PateronIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PateronIcon.TabIndex = 104
        Me.PateronIcon.TabStop = False
        '
        'btnVisitweb
        '
        Me.btnVisitweb.Location = New System.Drawing.Point(81, 306)
        Me.btnVisitweb.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVisitweb.Name = "btnVisitweb"
        Me.btnVisitweb.Size = New System.Drawing.Size(266, 52)
        Me.btnVisitweb.TabIndex = 100
        Me.btnVisitweb.Text = "Visit EasyIPH.com for Tips and Tricks"
        Me.btnVisitweb.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnVisitweb.UseSelectable = True
        '
        'btnReportbug
        '
        Me.btnReportbug.Location = New System.Drawing.Point(81, 380)
        Me.btnReportbug.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReportbug.Name = "btnReportbug"
        Me.btnReportbug.Size = New System.Drawing.Size(266, 52)
        Me.btnReportbug.TabIndex = 101
        Me.btnReportbug.Text = "Report a Bug or Suggest a Feature"
        Me.btnReportbug.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnReportbug.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(133, 284)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.Label1.MaximumSize = New System.Drawing.Size(0, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 21)
        Me.Label1.TabIndex = 98
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'chkDisableTracking
        '
        Me.chkDisableTracking.AutoSize = True
        Me.chkDisableTracking.Location = New System.Drawing.Point(17, 452)
        Me.chkDisableTracking.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDisableTracking.Name = "chkDisableTracking"
        Me.chkDisableTracking.Size = New System.Drawing.Size(251, 20)
        Me.chkDisableTracking.TabIndex = 108
        Me.chkDisableTracking.Text = "Disable Anonomous Usage Tracking"
        Me.chkDisableTracking.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1922, 1094)
        Me.Controls.Add(Me.TabControl1)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ReportBugIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisitWebIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PateronIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuManageBlueprintsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbSystems As System.Windows.Forms.GroupBox
    Friend WithEvents ttBP As System.Windows.Forms.ToolTip
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCharacterSkills As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents CalcBaseFacility As ManufacturingFacility
    Friend WithEvents btnCancelUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDownloadPrices As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCalcCalculate As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroProgressBar As MetroFramework.Controls.MetroProgressBar
    Friend WithEvents gbCalcBPSelect As GroupBox
    Friend WithEvents rbtnCalcBPFavorites As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rbtnCalcAllBPs As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents rbtnCalcBPOwned As MetroFramework.Controls.MetroRadioButton
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
    Friend WithEvents btnAddChar As MetroFramework.Controls.MetroButton
    Friend WithEvents btnManageChar As MetroFramework.Controls.MetroButton
    Friend WithEvents btnResetAll As MetroFramework.Controls.MetroButton
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelVersion As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents btnReportbug As MetroFramework.Controls.MetroButton
    Friend WithEvents btnVisitweb As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDonate As MetroFramework.Controls.MetroButton
    Friend WithEvents PateronIcon As PictureBox
    Friend WithEvents VisitWebIcon As PictureBox
    Friend WithEvents ReportBugIcon As PictureBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents trkTrips As MetroFramework.Controls.MetroTrackBar
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents FrmShoppingList1 As frmShoppingList
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkDisableTracking As CheckBox
End Class
