<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.chkCheckUpdatesStartup = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.chkShareFacilities = New System.Windows.Forms.CheckBox()
        Me.chkDisableTracking = New System.Windows.Forms.CheckBox()
        Me.chkLoadBPsbyChar = New System.Windows.Forms.CheckBox()
        Me.chkSaveFacilitiesbyChar = New System.Windows.Forms.CheckBox()
        Me.chkLinksInCopyText = New System.Windows.Forms.CheckBox()
        Me.chkDisableSound = New System.Windows.Forms.CheckBox()
        Me.chkDisableSVR = New System.Windows.Forms.CheckBox()
        Me.chkShowToolTips = New System.Windows.Forms.CheckBox()
        Me.chkRefreshBPsonStartup = New System.Windows.Forms.CheckBox()
        Me.chkRefreshAssetsonStartup = New System.Windows.Forms.CheckBox()
        Me.chkBeanCounterManufacturing = New System.Windows.Forms.CheckBox()
        Me.cmbBeanCounterRefining = New System.Windows.Forms.ComboBox()
        Me.cmbBeanCounterManufacturing = New System.Windows.Forms.ComboBox()
        Me.chkBeanCounterRefining = New System.Windows.Forms.CheckBox()
        Me.gbStationStandings = New System.Windows.Forms.GroupBox()
        Me.txtBrokerCorpStanding = New System.Windows.Forms.TextBox()
        Me.chkBrokerCorpStanding = New System.Windows.Forms.CheckBox()
        Me.txtBrokerFactionStanding = New System.Windows.Forms.TextBox()
        Me.chkBrokerFactionStanding = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.gbBuildBuySettings = New System.Windows.Forms.GroupBox()
        Me.chkSaveBPRelicsDecryptors = New System.Windows.Forms.CheckBox()
        Me.chkBuildBuyDefault = New System.Windows.Forms.CheckBox()
        Me.chkSuggestBuildwhenBPnotOwned = New System.Windows.Forms.CheckBox()
        Me.chkBeanCounterCopy = New System.Windows.Forms.CheckBox()
        Me.cmbBeanCounterCopy = New System.Windows.Forms.ComboBox()
        Me.gbDefaultMEPE = New System.Windows.Forms.GroupBox()
        Me.txtDefaultTE = New System.Windows.Forms.TextBox()
        Me.chkDefaultTE = New System.Windows.Forms.CheckBox()
        Me.txtDefaultME = New System.Windows.Forms.TextBox()
        Me.chkDefaultME = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbShoppingList = New System.Windows.Forms.GroupBox()
        Me.chkIncludeShopListInventMats = New System.Windows.Forms.CheckBox()
        Me.chkIncludeShopListCopyMats = New System.Windows.Forms.CheckBox()
        Me.gbEVEMarketer = New System.Windows.Forms.GroupBox()
        Me.txtEVEMarketerInterval = New System.Windows.Forms.TextBox()
        Me.chkEVEMarketerInterval = New System.Windows.Forms.CheckBox()
        Me.gbImplants = New System.Windows.Forms.GroupBox()
        Me.gbStartupOptions = New System.Windows.Forms.GroupBox()
        Me.chkSupressESImsgs = New System.Windows.Forms.CheckBox()
        Me.chkRefreshPublicStructureDataonStartup = New System.Windows.Forms.CheckBox()
        Me.chkRefreshSystemCostIndiciesDataonStartup = New System.Windows.Forms.CheckBox()
        Me.chkRefreshMarketDataonStartup = New System.Windows.Forms.CheckBox()
        Me.gbExportOptions = New System.Windows.Forms.GroupBox()
        Me.rbtnExportSSV = New System.Windows.Forms.RadioButton()
        Me.rbtnExportCSV = New System.Windows.Forms.RadioButton()
        Me.rbtnExportDefault = New System.Windows.Forms.RadioButton()
        Me.gbCalcAvgPrice = New System.Windows.Forms.GroupBox()
        Me.cmbSVRAvgPriceDuration = New System.Windows.Forms.ComboBox()
        Me.chkAutoUpdateSVRBPTab = New System.Windows.Forms.CheckBox()
        Me.lblSVRRegion = New System.Windows.Forms.Label()
        Me.lblSVRAvgPrice = New System.Windows.Forms.Label()
        Me.cmbSVRRegion = New System.Windows.Forms.ComboBox()
        Me.txtSVRThreshold = New System.Windows.Forms.TextBox()
        Me.lblSVRThreshold = New System.Windows.Forms.Label()
        Me.gbProxySettings = New System.Windows.Forms.GroupBox()
        Me.txtProxyAddress = New System.Windows.Forms.TextBox()
        Me.lblProxyAddress = New System.Windows.Forms.Label()
        Me.txtProxyPort = New System.Windows.Forms.TextBox()
        Me.lblProxyPort = New System.Windows.Forms.Label()
        Me.gbCharacterOptions = New System.Windows.Forms.GroupBox()
        Me.chkLoadMaxAlphaSkills = New System.Windows.Forms.CheckBox()
        Me.chkUseActiveSkills = New System.Windows.Forms.CheckBox()
        Me.chkAlphaAccount = New System.Windows.Forms.CheckBox()
        Me.gbGeneral.SuspendLayout()
        Me.gbStationStandings.SuspendLayout()
        Me.gbBuildBuySettings.SuspendLayout()
        Me.gbDefaultMEPE.SuspendLayout()
        Me.gbShoppingList.SuspendLayout()
        Me.gbEVEMarketer.SuspendLayout()
        Me.gbImplants.SuspendLayout()
        Me.gbStartupOptions.SuspendLayout()
        Me.gbExportOptions.SuspendLayout()
        Me.gbCalcAvgPrice.SuspendLayout()
        Me.gbProxySettings.SuspendLayout()
        Me.gbCharacterOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkCheckUpdatesStartup
        '
        Me.chkCheckUpdatesStartup.AutoSize = True
        Me.chkCheckUpdatesStartup.Location = New System.Drawing.Point(21, 24)
        Me.chkCheckUpdatesStartup.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCheckUpdatesStartup.Name = "chkCheckUpdatesStartup"
        Me.chkCheckUpdatesStartup.Size = New System.Drawing.Size(205, 21)
        Me.chkCheckUpdatesStartup.TabIndex = 0
        Me.chkCheckUpdatesStartup.Text = "Check for Program Updates"
        Me.chkCheckUpdatesStartup.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(435, 516)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(126, 38)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(698, 516)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(126, 38)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.chkShareFacilities)
        Me.gbGeneral.Controls.Add(Me.chkDisableTracking)
        Me.gbGeneral.Controls.Add(Me.chkLoadBPsbyChar)
        Me.gbGeneral.Controls.Add(Me.chkSaveFacilitiesbyChar)
        Me.gbGeneral.Controls.Add(Me.chkLinksInCopyText)
        Me.gbGeneral.Controls.Add(Me.chkDisableSound)
        Me.gbGeneral.Controls.Add(Me.chkDisableSVR)
        Me.gbGeneral.Controls.Add(Me.chkShowToolTips)
        Me.gbGeneral.Location = New System.Drawing.Point(6, 15)
        Me.gbGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.gbGeneral.Size = New System.Drawing.Size(294, 232)
        Me.gbGeneral.TabIndex = 4
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "General:"
        '
        'chkShareFacilities
        '
        Me.chkShareFacilities.AutoSize = True
        Me.chkShareFacilities.Location = New System.Drawing.Point(21, 174)
        Me.chkShareFacilities.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShareFacilities.Name = "chkShareFacilities"
        Me.chkShareFacilities.Size = New System.Drawing.Size(170, 21)
        Me.chkShareFacilities.TabIndex = 42
        Me.chkShareFacilities.Text = "Share Saved Facilities"
        Me.chkShareFacilities.UseVisualStyleBackColor = True
        '
        'chkDisableTracking
        '
        Me.chkDisableTracking.AutoSize = True
        Me.chkDisableTracking.Location = New System.Drawing.Point(21, 199)
        Me.chkDisableTracking.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDisableTracking.Name = "chkDisableTracking"
        Me.chkDisableTracking.Size = New System.Drawing.Size(260, 21)
        Me.chkDisableTracking.TabIndex = 41
        Me.chkDisableTracking.Text = "Disable Anonomous Usage Tracking"
        Me.chkDisableTracking.UseVisualStyleBackColor = True
        '
        'chkLoadBPsbyChar
        '
        Me.chkLoadBPsbyChar.AutoSize = True
        Me.chkLoadBPsbyChar.Location = New System.Drawing.Point(21, 149)
        Me.chkLoadBPsbyChar.Margin = New System.Windows.Forms.Padding(4)
        Me.chkLoadBPsbyChar.Name = "chkLoadBPsbyChar"
        Me.chkLoadBPsbyChar.Size = New System.Drawing.Size(214, 21)
        Me.chkLoadBPsbyChar.TabIndex = 40
        Me.chkLoadBPsbyChar.Text = "Load Blueprints by Character"
        Me.chkLoadBPsbyChar.UseVisualStyleBackColor = True
        '
        'chkSaveFacilitiesbyChar
        '
        Me.chkSaveFacilitiesbyChar.AutoSize = True
        Me.chkSaveFacilitiesbyChar.Location = New System.Drawing.Point(21, 124)
        Me.chkSaveFacilitiesbyChar.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSaveFacilitiesbyChar.Name = "chkSaveFacilitiesbyChar"
        Me.chkSaveFacilitiesbyChar.Size = New System.Drawing.Size(242, 21)
        Me.chkSaveFacilitiesbyChar.TabIndex = 39
        Me.chkSaveFacilitiesbyChar.Text = "Save Facilities for each Character"
        Me.chkSaveFacilitiesbyChar.UseVisualStyleBackColor = True
        '
        'chkLinksInCopyText
        '
        Me.chkLinksInCopyText.Location = New System.Drawing.Point(21, 49)
        Me.chkLinksInCopyText.Margin = New System.Windows.Forms.Padding(4)
        Me.chkLinksInCopyText.Name = "chkLinksInCopyText"
        Me.chkLinksInCopyText.Size = New System.Drawing.Size(268, 21)
        Me.chkLinksInCopyText.TabIndex = 38
        Me.chkLinksInCopyText.Text = "Include InGame Links in Copy Text"
        Me.chkLinksInCopyText.UseVisualStyleBackColor = True
        '
        'chkDisableSound
        '
        Me.chkDisableSound.AutoSize = True
        Me.chkDisableSound.Location = New System.Drawing.Point(21, 99)
        Me.chkDisableSound.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDisableSound.Name = "chkDisableSound"
        Me.chkDisableSound.Size = New System.Drawing.Size(122, 21)
        Me.chkDisableSound.TabIndex = 24
        Me.chkDisableSound.Text = "Disable Sound"
        Me.chkDisableSound.UseVisualStyleBackColor = True
        '
        'chkDisableSVR
        '
        Me.chkDisableSVR.AutoSize = True
        Me.chkDisableSVR.Location = New System.Drawing.Point(21, 74)
        Me.chkDisableSVR.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDisableSVR.Name = "chkDisableSVR"
        Me.chkDisableSVR.Size = New System.Drawing.Size(166, 21)
        Me.chkDisableSVR.TabIndex = 0
        Me.chkDisableSVR.Text = "Disable SVR Updates"
        Me.chkDisableSVR.UseVisualStyleBackColor = True
        '
        'chkShowToolTips
        '
        Me.chkShowToolTips.AutoSize = True
        Me.chkShowToolTips.Location = New System.Drawing.Point(21, 24)
        Me.chkShowToolTips.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShowToolTips.Name = "chkShowToolTips"
        Me.chkShowToolTips.Size = New System.Drawing.Size(127, 21)
        Me.chkShowToolTips.TabIndex = 2
        Me.chkShowToolTips.Text = "Show Tool Tips"
        Me.chkShowToolTips.UseVisualStyleBackColor = True
        '
        'chkRefreshBPsonStartup
        '
        Me.chkRefreshBPsonStartup.AutoSize = True
        Me.chkRefreshBPsonStartup.Location = New System.Drawing.Point(21, 74)
        Me.chkRefreshBPsonStartup.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRefreshBPsonStartup.Name = "chkRefreshBPsonStartup"
        Me.chkRefreshBPsonStartup.Size = New System.Drawing.Size(109, 21)
        Me.chkRefreshBPsonStartup.TabIndex = 26
        Me.chkRefreshBPsonStartup.Text = "Refresh BPs"
        Me.chkRefreshBPsonStartup.UseVisualStyleBackColor = True
        '
        'chkRefreshAssetsonStartup
        '
        Me.chkRefreshAssetsonStartup.AutoSize = True
        Me.chkRefreshAssetsonStartup.Location = New System.Drawing.Point(21, 49)
        Me.chkRefreshAssetsonStartup.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRefreshAssetsonStartup.Name = "chkRefreshAssetsonStartup"
        Me.chkRefreshAssetsonStartup.Size = New System.Drawing.Size(126, 21)
        Me.chkRefreshAssetsonStartup.TabIndex = 23
        Me.chkRefreshAssetsonStartup.Text = "Refresh Assets"
        Me.chkRefreshAssetsonStartup.UseVisualStyleBackColor = True
        '
        'chkBeanCounterManufacturing
        '
        Me.chkBeanCounterManufacturing.AutoSize = True
        Me.chkBeanCounterManufacturing.Location = New System.Drawing.Point(11, 24)
        Me.chkBeanCounterManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBeanCounterManufacturing.Name = "chkBeanCounterManufacturing"
        Me.chkBeanCounterManufacturing.Size = New System.Drawing.Size(254, 21)
        Me.chkBeanCounterManufacturing.TabIndex = 3
        Me.chkBeanCounterManufacturing.Text = "Manufacturing Beancounter Implant"
        Me.chkBeanCounterManufacturing.UseVisualStyleBackColor = True
        '
        'cmbBeanCounterRefining
        '
        Me.cmbBeanCounterRefining.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeanCounterRefining.FormattingEnabled = True
        Me.cmbBeanCounterRefining.Items.AddRange(New Object() {"Zainou 'Beancounter' Reprocessing RX-801", "Zainou 'Beancounter' Reprocessing RX-802", "Zainou 'Beancounter' Reprocessing RX-804"})
        Me.cmbBeanCounterRefining.Location = New System.Drawing.Point(11, 104)
        Me.cmbBeanCounterRefining.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBeanCounterRefining.Name = "cmbBeanCounterRefining"
        Me.cmbBeanCounterRefining.Size = New System.Drawing.Size(293, 24)
        Me.cmbBeanCounterRefining.TabIndex = 5
        '
        'cmbBeanCounterManufacturing
        '
        Me.cmbBeanCounterManufacturing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeanCounterManufacturing.FormattingEnabled = True
        Me.cmbBeanCounterManufacturing.Items.AddRange(New Object() {"Zainou 'Beancounter' Industry BX-801", "Zainou 'Beancounter' Industry BX-802", "Zainou 'Beancounter' Industry BX-804"})
        Me.cmbBeanCounterManufacturing.Location = New System.Drawing.Point(11, 48)
        Me.cmbBeanCounterManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBeanCounterManufacturing.Name = "cmbBeanCounterManufacturing"
        Me.cmbBeanCounterManufacturing.Size = New System.Drawing.Size(293, 24)
        Me.cmbBeanCounterManufacturing.TabIndex = 4
        '
        'chkBeanCounterRefining
        '
        Me.chkBeanCounterRefining.AutoSize = True
        Me.chkBeanCounterRefining.Location = New System.Drawing.Point(11, 80)
        Me.chkBeanCounterRefining.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBeanCounterRefining.Name = "chkBeanCounterRefining"
        Me.chkBeanCounterRefining.Size = New System.Drawing.Size(251, 21)
        Me.chkBeanCounterRefining.TabIndex = 5
        Me.chkBeanCounterRefining.Text = "Reprocessing Beancounter Implant"
        Me.chkBeanCounterRefining.UseVisualStyleBackColor = True
        '
        'gbStationStandings
        '
        Me.gbStationStandings.Controls.Add(Me.txtBrokerCorpStanding)
        Me.gbStationStandings.Controls.Add(Me.chkBrokerCorpStanding)
        Me.gbStationStandings.Controls.Add(Me.txtBrokerFactionStanding)
        Me.gbStationStandings.Controls.Add(Me.chkBrokerFactionStanding)
        Me.gbStationStandings.Location = New System.Drawing.Point(308, 250)
        Me.gbStationStandings.Margin = New System.Windows.Forms.Padding(4)
        Me.gbStationStandings.Name = "gbStationStandings"
        Me.gbStationStandings.Padding = New System.Windows.Forms.Padding(4)
        Me.gbStationStandings.Size = New System.Drawing.Size(200, 79)
        Me.gbStationStandings.TabIndex = 7
        Me.gbStationStandings.TabStop = False
        Me.gbStationStandings.Text = "Station (base) Standings:"
        '
        'txtBrokerCorpStanding
        '
        Me.txtBrokerCorpStanding.Location = New System.Drawing.Point(138, 19)
        Me.txtBrokerCorpStanding.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBrokerCorpStanding.MaxLength = 5
        Me.txtBrokerCorpStanding.Name = "txtBrokerCorpStanding"
        Me.txtBrokerCorpStanding.Size = New System.Drawing.Size(50, 22)
        Me.txtBrokerCorpStanding.TabIndex = 26
        Me.txtBrokerCorpStanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkBrokerCorpStanding
        '
        Me.chkBrokerCorpStanding.Location = New System.Drawing.Point(11, 21)
        Me.chkBrokerCorpStanding.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBrokerCorpStanding.Name = "chkBrokerCorpStanding"
        Me.chkBrokerCorpStanding.Size = New System.Drawing.Size(106, 21)
        Me.chkBrokerCorpStanding.TabIndex = 25
        Me.chkBrokerCorpStanding.Text = "Broker Corp:"
        Me.chkBrokerCorpStanding.UseVisualStyleBackColor = True
        '
        'txtBrokerFactionStanding
        '
        Me.txtBrokerFactionStanding.Location = New System.Drawing.Point(138, 46)
        Me.txtBrokerFactionStanding.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBrokerFactionStanding.MaxLength = 5
        Me.txtBrokerFactionStanding.Name = "txtBrokerFactionStanding"
        Me.txtBrokerFactionStanding.Size = New System.Drawing.Size(50, 22)
        Me.txtBrokerFactionStanding.TabIndex = 28
        Me.txtBrokerFactionStanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkBrokerFactionStanding
        '
        Me.chkBrokerFactionStanding.Location = New System.Drawing.Point(11, 49)
        Me.chkBrokerFactionStanding.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBrokerFactionStanding.Name = "chkBrokerFactionStanding"
        Me.chkBrokerFactionStanding.Size = New System.Drawing.Size(122, 21)
        Me.chkBrokerFactionStanding.TabIndex = 27
        Me.chkBrokerFactionStanding.Text = "Broker Faction:"
        Me.chkBrokerFactionStanding.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(566, 516)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(126, 38)
        Me.btnReset.TabIndex = 30
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'gbBuildBuySettings
        '
        Me.gbBuildBuySettings.Controls.Add(Me.chkSaveBPRelicsDecryptors)
        Me.gbBuildBuySettings.Controls.Add(Me.chkBuildBuyDefault)
        Me.gbBuildBuySettings.Controls.Add(Me.chkSuggestBuildwhenBPnotOwned)
        Me.gbBuildBuySettings.Location = New System.Drawing.Point(512, 214)
        Me.gbBuildBuySettings.Margin = New System.Windows.Forms.Padding(4)
        Me.gbBuildBuySettings.Name = "gbBuildBuySettings"
        Me.gbBuildBuySettings.Padding = New System.Windows.Forms.Padding(4)
        Me.gbBuildBuySettings.Size = New System.Drawing.Size(312, 218)
        Me.gbBuildBuySettings.TabIndex = 9
        Me.gbBuildBuySettings.TabStop = False
        Me.gbBuildBuySettings.Text = "Build Settings:"
        '
        'chkSaveBPRelicsDecryptors
        '
        Me.chkSaveBPRelicsDecryptors.AutoSize = True
        Me.chkSaveBPRelicsDecryptors.Location = New System.Drawing.Point(11, 72)
        Me.chkSaveBPRelicsDecryptors.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSaveBPRelicsDecryptors.Name = "chkSaveBPRelicsDecryptors"
        Me.chkSaveBPRelicsDecryptors.Size = New System.Drawing.Size(276, 21)
        Me.chkSaveBPRelicsDecryptors.TabIndex = 38
        Me.chkSaveBPRelicsDecryptors.Text = "Save Relics and Decryptors on BP Tab"
        Me.chkSaveBPRelicsDecryptors.UseVisualStyleBackColor = True
        '
        'chkBuildBuyDefault
        '
        Me.chkBuildBuyDefault.AutoSize = True
        Me.chkBuildBuyDefault.Location = New System.Drawing.Point(11, 22)
        Me.chkBuildBuyDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBuildBuyDefault.Name = "chkBuildBuyDefault"
        Me.chkBuildBuyDefault.Size = New System.Drawing.Size(138, 21)
        Me.chkBuildBuyDefault.TabIndex = 32
        Me.chkBuildBuyDefault.Text = "Default Build/Buy"
        Me.chkBuildBuyDefault.UseVisualStyleBackColor = True
        '
        'chkSuggestBuildwhenBPnotOwned
        '
        Me.chkSuggestBuildwhenBPnotOwned.AutoSize = True
        Me.chkSuggestBuildwhenBPnotOwned.Location = New System.Drawing.Point(11, 48)
        Me.chkSuggestBuildwhenBPnotOwned.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSuggestBuildwhenBPnotOwned.Name = "chkSuggestBuildwhenBPnotOwned"
        Me.chkSuggestBuildwhenBPnotOwned.Size = New System.Drawing.Size(288, 21)
        Me.chkSuggestBuildwhenBPnotOwned.TabIndex = 37
        Me.chkSuggestBuildwhenBPnotOwned.Text = "Suggest Build option when BP not owned"
        Me.chkSuggestBuildwhenBPnotOwned.UseVisualStyleBackColor = True
        '
        'chkBeanCounterCopy
        '
        Me.chkBeanCounterCopy.AutoSize = True
        Me.chkBeanCounterCopy.Location = New System.Drawing.Point(11, 136)
        Me.chkBeanCounterCopy.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBeanCounterCopy.Name = "chkBeanCounterCopy"
        Me.chkBeanCounterCopy.Size = New System.Drawing.Size(196, 21)
        Me.chkBeanCounterCopy.TabIndex = 35
        Me.chkBeanCounterCopy.Text = "Copy Beancounter Implant"
        Me.chkBeanCounterCopy.UseVisualStyleBackColor = True
        '
        'cmbBeanCounterCopy
        '
        Me.cmbBeanCounterCopy.DisplayMember = "Zainou 'Beancounter' Science SC-805"
        Me.cmbBeanCounterCopy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeanCounterCopy.FormattingEnabled = True
        Me.cmbBeanCounterCopy.Items.AddRange(New Object() {"Zainou 'Beancounter' Science SC-801", "Zainou 'Beancounter' Science SC-803", "Zainou 'Beancounter' Science SC-805"})
        Me.cmbBeanCounterCopy.Location = New System.Drawing.Point(11, 158)
        Me.cmbBeanCounterCopy.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBeanCounterCopy.Name = "cmbBeanCounterCopy"
        Me.cmbBeanCounterCopy.Size = New System.Drawing.Size(293, 24)
        Me.cmbBeanCounterCopy.TabIndex = 36
        '
        'gbDefaultMEPE
        '
        Me.gbDefaultMEPE.Controls.Add(Me.txtDefaultTE)
        Me.gbDefaultMEPE.Controls.Add(Me.chkDefaultTE)
        Me.gbDefaultMEPE.Controls.Add(Me.txtDefaultME)
        Me.gbDefaultMEPE.Controls.Add(Me.chkDefaultME)
        Me.gbDefaultMEPE.Location = New System.Drawing.Point(308, 15)
        Me.gbDefaultMEPE.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDefaultMEPE.Name = "gbDefaultMEPE"
        Me.gbDefaultMEPE.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDefaultMEPE.Size = New System.Drawing.Size(200, 79)
        Me.gbDefaultMEPE.TabIndex = 34
        Me.gbDefaultMEPE.TabStop = False
        Me.gbDefaultMEPE.Text = "Default ME/TE:"
        '
        'txtDefaultTE
        '
        Me.txtDefaultTE.Location = New System.Drawing.Point(138, 46)
        Me.txtDefaultTE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDefaultTE.Name = "txtDefaultTE"
        Me.txtDefaultTE.Size = New System.Drawing.Size(50, 22)
        Me.txtDefaultTE.TabIndex = 26
        Me.txtDefaultTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkDefaultTE
        '
        Me.chkDefaultTE.Location = New System.Drawing.Point(11, 49)
        Me.chkDefaultTE.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDefaultTE.Name = "chkDefaultTE"
        Me.chkDefaultTE.Size = New System.Drawing.Size(106, 21)
        Me.chkDefaultTE.TabIndex = 25
        Me.chkDefaultTE.Text = "Default TE:"
        Me.chkDefaultTE.UseVisualStyleBackColor = True
        '
        'txtDefaultME
        '
        Me.txtDefaultME.Location = New System.Drawing.Point(138, 19)
        Me.txtDefaultME.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDefaultME.Name = "txtDefaultME"
        Me.txtDefaultME.Size = New System.Drawing.Size(50, 22)
        Me.txtDefaultME.TabIndex = 22
        Me.txtDefaultME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkDefaultME
        '
        Me.chkDefaultME.Location = New System.Drawing.Point(11, 20)
        Me.chkDefaultME.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDefaultME.Name = "chkDefaultME"
        Me.chkDefaultME.Size = New System.Drawing.Size(106, 21)
        Me.chkDefaultME.TabIndex = 21
        Me.chkDefaultME.Text = "Default ME:"
        Me.chkDefaultME.UseVisualStyleBackColor = True
        '
        'gbShoppingList
        '
        Me.gbShoppingList.Controls.Add(Me.chkIncludeShopListInventMats)
        Me.gbShoppingList.Controls.Add(Me.chkIncludeShopListCopyMats)
        Me.gbShoppingList.Location = New System.Drawing.Point(308, 96)
        Me.gbShoppingList.Margin = New System.Windows.Forms.Padding(4)
        Me.gbShoppingList.Name = "gbShoppingList"
        Me.gbShoppingList.Padding = New System.Windows.Forms.Padding(4)
        Me.gbShoppingList.Size = New System.Drawing.Size(200, 79)
        Me.gbShoppingList.TabIndex = 37
        Me.gbShoppingList.TabStop = False
        Me.gbShoppingList.Text = "Shopping List:"
        '
        'chkIncludeShopListInventMats
        '
        Me.chkIncludeShopListInventMats.AutoSize = True
        Me.chkIncludeShopListInventMats.Location = New System.Drawing.Point(11, 24)
        Me.chkIncludeShopListInventMats.Margin = New System.Windows.Forms.Padding(4)
        Me.chkIncludeShopListInventMats.Name = "chkIncludeShopListInventMats"
        Me.chkIncludeShopListInventMats.Size = New System.Drawing.Size(170, 21)
        Me.chkIncludeShopListInventMats.TabIndex = 0
        Me.chkIncludeShopListInventMats.Text = "Include Invention Mats"
        Me.chkIncludeShopListInventMats.UseVisualStyleBackColor = True
        '
        'chkIncludeShopListCopyMats
        '
        Me.chkIncludeShopListCopyMats.AutoSize = True
        Me.chkIncludeShopListCopyMats.Location = New System.Drawing.Point(11, 50)
        Me.chkIncludeShopListCopyMats.Margin = New System.Windows.Forms.Padding(4)
        Me.chkIncludeShopListCopyMats.Name = "chkIncludeShopListCopyMats"
        Me.chkIncludeShopListCopyMats.Size = New System.Drawing.Size(145, 21)
        Me.chkIncludeShopListCopyMats.TabIndex = 1
        Me.chkIncludeShopListCopyMats.Text = "Include Copy Mats"
        Me.chkIncludeShopListCopyMats.UseVisualStyleBackColor = True
        '
        'gbEVEMarketer
        '
        Me.gbEVEMarketer.Controls.Add(Me.txtEVEMarketerInterval)
        Me.gbEVEMarketer.Controls.Add(Me.chkEVEMarketerInterval)
        Me.gbEVEMarketer.Location = New System.Drawing.Point(308, 178)
        Me.gbEVEMarketer.Margin = New System.Windows.Forms.Padding(4)
        Me.gbEVEMarketer.Name = "gbEVEMarketer"
        Me.gbEVEMarketer.Padding = New System.Windows.Forms.Padding(4)
        Me.gbEVEMarketer.Size = New System.Drawing.Size(200, 70)
        Me.gbEVEMarketer.TabIndex = 38
        Me.gbEVEMarketer.TabStop = False
        Me.gbEVEMarketer.Text = "EVE Marketer Price Updates:"
        '
        'txtEVEMarketerInterval
        '
        Me.txtEVEMarketerInterval.Location = New System.Drawing.Point(138, 31)
        Me.txtEVEMarketerInterval.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEVEMarketerInterval.Name = "txtEVEMarketerInterval"
        Me.txtEVEMarketerInterval.Size = New System.Drawing.Size(50, 22)
        Me.txtEVEMarketerInterval.TabIndex = 24
        Me.txtEVEMarketerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkEVEMarketerInterval
        '
        Me.chkEVEMarketerInterval.Location = New System.Drawing.Point(11, 22)
        Me.chkEVEMarketerInterval.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEVEMarketerInterval.Name = "chkEVEMarketerInterval"
        Me.chkEVEMarketerInterval.Size = New System.Drawing.Size(131, 42)
        Me.chkEVEMarketerInterval.TabIndex = 23
        Me.chkEVEMarketerInterval.Text = "Refresh Interval (Hours):"
        Me.chkEVEMarketerInterval.UseVisualStyleBackColor = True
        '
        'gbImplants
        '
        Me.gbImplants.Controls.Add(Me.chkBeanCounterManufacturing)
        Me.gbImplants.Controls.Add(Me.chkBeanCounterCopy)
        Me.gbImplants.Controls.Add(Me.cmbBeanCounterManufacturing)
        Me.gbImplants.Controls.Add(Me.chkBeanCounterRefining)
        Me.gbImplants.Controls.Add(Me.cmbBeanCounterCopy)
        Me.gbImplants.Controls.Add(Me.cmbBeanCounterRefining)
        Me.gbImplants.Location = New System.Drawing.Point(512, 15)
        Me.gbImplants.Margin = New System.Windows.Forms.Padding(4)
        Me.gbImplants.Name = "gbImplants"
        Me.gbImplants.Padding = New System.Windows.Forms.Padding(4)
        Me.gbImplants.Size = New System.Drawing.Size(312, 196)
        Me.gbImplants.TabIndex = 36
        Me.gbImplants.TabStop = False
        Me.gbImplants.Text = "Implants:"
        '
        'gbStartupOptions
        '
        Me.gbStartupOptions.Controls.Add(Me.chkSupressESImsgs)
        Me.gbStartupOptions.Controls.Add(Me.chkRefreshPublicStructureDataonStartup)
        Me.gbStartupOptions.Controls.Add(Me.chkRefreshSystemCostIndiciesDataonStartup)
        Me.gbStartupOptions.Controls.Add(Me.chkRefreshMarketDataonStartup)
        Me.gbStartupOptions.Controls.Add(Me.chkRefreshBPsonStartup)
        Me.gbStartupOptions.Controls.Add(Me.chkCheckUpdatesStartup)
        Me.gbStartupOptions.Controls.Add(Me.chkRefreshAssetsonStartup)
        Me.gbStartupOptions.Location = New System.Drawing.Point(6, 250)
        Me.gbStartupOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.gbStartupOptions.Name = "gbStartupOptions"
        Me.gbStartupOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.gbStartupOptions.Size = New System.Drawing.Size(294, 202)
        Me.gbStartupOptions.TabIndex = 39
        Me.gbStartupOptions.TabStop = False
        Me.gbStartupOptions.Text = "Startup Options"
        '
        'chkSupressESImsgs
        '
        Me.chkSupressESImsgs.AutoSize = True
        Me.chkSupressESImsgs.Location = New System.Drawing.Point(21, 174)
        Me.chkSupressESImsgs.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSupressESImsgs.Name = "chkSupressESImsgs"
        Me.chkSupressESImsgs.Size = New System.Drawing.Size(219, 21)
        Me.chkSupressESImsgs.TabIndex = 31
        Me.chkSupressESImsgs.Text = "Supress ESI Status Messages"
        Me.chkSupressESImsgs.UseVisualStyleBackColor = True
        '
        'chkRefreshPublicStructureDataonStartup
        '
        Me.chkRefreshPublicStructureDataonStartup.AutoSize = True
        Me.chkRefreshPublicStructureDataonStartup.Location = New System.Drawing.Point(21, 149)
        Me.chkRefreshPublicStructureDataonStartup.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRefreshPublicStructureDataonStartup.Name = "chkRefreshPublicStructureDataonStartup"
        Me.chkRefreshPublicStructureDataonStartup.Size = New System.Drawing.Size(218, 21)
        Me.chkRefreshPublicStructureDataonStartup.TabIndex = 30
        Me.chkRefreshPublicStructureDataonStartup.Text = "Refresh Public Structure Data"
        Me.chkRefreshPublicStructureDataonStartup.UseVisualStyleBackColor = True
        '
        'chkRefreshSystemCostIndiciesDataonStartup
        '
        Me.chkRefreshSystemCostIndiciesDataonStartup.AutoSize = True
        Me.chkRefreshSystemCostIndiciesDataonStartup.Location = New System.Drawing.Point(21, 124)
        Me.chkRefreshSystemCostIndiciesDataonStartup.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRefreshSystemCostIndiciesDataonStartup.Name = "chkRefreshSystemCostIndiciesDataonStartup"
        Me.chkRefreshSystemCostIndiciesDataonStartup.Size = New System.Drawing.Size(235, 21)
        Me.chkRefreshSystemCostIndiciesDataonStartup.TabIndex = 29
        Me.chkRefreshSystemCostIndiciesDataonStartup.Text = "Refresh System Industry Indicies"
        Me.chkRefreshSystemCostIndiciesDataonStartup.UseVisualStyleBackColor = True
        '
        'chkRefreshMarketDataonStartup
        '
        Me.chkRefreshMarketDataonStartup.AutoSize = True
        Me.chkRefreshMarketDataonStartup.Location = New System.Drawing.Point(21, 99)
        Me.chkRefreshMarketDataonStartup.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRefreshMarketDataonStartup.Name = "chkRefreshMarketDataonStartup"
        Me.chkRefreshMarketDataonStartup.Size = New System.Drawing.Size(161, 21)
        Me.chkRefreshMarketDataonStartup.TabIndex = 28
        Me.chkRefreshMarketDataonStartup.Text = "Refresh Market Data"
        Me.chkRefreshMarketDataonStartup.UseVisualStyleBackColor = True
        '
        'gbExportOptions
        '
        Me.gbExportOptions.Controls.Add(Me.rbtnExportSSV)
        Me.gbExportOptions.Controls.Add(Me.rbtnExportCSV)
        Me.gbExportOptions.Controls.Add(Me.rbtnExportDefault)
        Me.gbExportOptions.Location = New System.Drawing.Point(308, 434)
        Me.gbExportOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.gbExportOptions.Name = "gbExportOptions"
        Me.gbExportOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.gbExportOptions.Size = New System.Drawing.Size(119, 128)
        Me.gbExportOptions.TabIndex = 38
        Me.gbExportOptions.TabStop = False
        Me.gbExportOptions.Text = "Export Data in:"
        '
        'rbtnExportSSV
        '
        Me.rbtnExportSSV.AutoSize = True
        Me.rbtnExportSSV.Location = New System.Drawing.Point(11, 98)
        Me.rbtnExportSSV.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportSSV.Name = "rbtnExportSSV"
        Me.rbtnExportSSV.Size = New System.Drawing.Size(56, 21)
        Me.rbtnExportSSV.TabIndex = 2
        Me.rbtnExportSSV.TabStop = True
        Me.rbtnExportSSV.Text = "SSV"
        Me.rbtnExportSSV.UseVisualStyleBackColor = True
        '
        'rbtnExportCSV
        '
        Me.rbtnExportCSV.AutoSize = True
        Me.rbtnExportCSV.Location = New System.Drawing.Point(11, 66)
        Me.rbtnExportCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportCSV.Name = "rbtnExportCSV"
        Me.rbtnExportCSV.Size = New System.Drawing.Size(56, 21)
        Me.rbtnExportCSV.TabIndex = 1
        Me.rbtnExportCSV.TabStop = True
        Me.rbtnExportCSV.Text = "CSV"
        Me.rbtnExportCSV.UseVisualStyleBackColor = True
        '
        'rbtnExportDefault
        '
        Me.rbtnExportDefault.AutoSize = True
        Me.rbtnExportDefault.Location = New System.Drawing.Point(11, 31)
        Me.rbtnExportDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportDefault.Name = "rbtnExportDefault"
        Me.rbtnExportDefault.Size = New System.Drawing.Size(74, 21)
        Me.rbtnExportDefault.TabIndex = 0
        Me.rbtnExportDefault.TabStop = True
        Me.rbtnExportDefault.Text = "Default"
        Me.rbtnExportDefault.UseVisualStyleBackColor = True
        '
        'gbCalcAvgPrice
        '
        Me.gbCalcAvgPrice.Controls.Add(Me.cmbSVRAvgPriceDuration)
        Me.gbCalcAvgPrice.Controls.Add(Me.chkAutoUpdateSVRBPTab)
        Me.gbCalcAvgPrice.Controls.Add(Me.lblSVRRegion)
        Me.gbCalcAvgPrice.Controls.Add(Me.lblSVRAvgPrice)
        Me.gbCalcAvgPrice.Controls.Add(Me.cmbSVRRegion)
        Me.gbCalcAvgPrice.Controls.Add(Me.txtSVRThreshold)
        Me.gbCalcAvgPrice.Controls.Add(Me.lblSVRThreshold)
        Me.gbCalcAvgPrice.Location = New System.Drawing.Point(6, 452)
        Me.gbCalcAvgPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCalcAvgPrice.Name = "gbCalcAvgPrice"
        Me.gbCalcAvgPrice.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCalcAvgPrice.Size = New System.Drawing.Size(294, 109)
        Me.gbCalcAvgPrice.TabIndex = 40
        Me.gbCalcAvgPrice.TabStop = False
        Me.gbCalcAvgPrice.Text = "SVR Settings:"
        '
        'cmbSVRAvgPriceDuration
        '
        Me.cmbSVRAvgPriceDuration.FormattingEnabled = True
        Me.cmbSVRAvgPriceDuration.Items.AddRange(New Object() {"7", "15", "30", "60", "90", "180", "365"})
        Me.cmbSVRAvgPriceDuration.Location = New System.Drawing.Point(235, 18)
        Me.cmbSVRAvgPriceDuration.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSVRAvgPriceDuration.MaxLength = 3
        Me.cmbSVRAvgPriceDuration.Name = "cmbSVRAvgPriceDuration"
        Me.cmbSVRAvgPriceDuration.Size = New System.Drawing.Size(50, 24)
        Me.cmbSVRAvgPriceDuration.TabIndex = 3
        '
        'chkAutoUpdateSVRBPTab
        '
        Me.chkAutoUpdateSVRBPTab.AutoSize = True
        Me.chkAutoUpdateSVRBPTab.Location = New System.Drawing.Point(21, 80)
        Me.chkAutoUpdateSVRBPTab.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoUpdateSVRBPTab.Name = "chkAutoUpdateSVRBPTab"
        Me.chkAutoUpdateSVRBPTab.Size = New System.Drawing.Size(264, 21)
        Me.chkAutoUpdateSVRBPTab.TabIndex = 39
        Me.chkAutoUpdateSVRBPTab.Text = "Automatically update SVR on BP Tab"
        Me.chkAutoUpdateSVRBPTab.UseVisualStyleBackColor = True
        '
        'lblSVRRegion
        '
        Me.lblSVRRegion.AutoSize = True
        Me.lblSVRRegion.Location = New System.Drawing.Point(21, 52)
        Me.lblSVRRegion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSVRRegion.Name = "lblSVRRegion"
        Me.lblSVRRegion.Size = New System.Drawing.Size(57, 17)
        Me.lblSVRRegion.TabIndex = 4
        Me.lblSVRRegion.Text = "Region:"
        '
        'lblSVRAvgPrice
        '
        Me.lblSVRAvgPrice.Location = New System.Drawing.Point(139, 12)
        Me.lblSVRAvgPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSVRAvgPrice.Name = "lblSVRAvgPrice"
        Me.lblSVRAvgPrice.Size = New System.Drawing.Size(98, 35)
        Me.lblSVRAvgPrice.TabIndex = 2
        Me.lblSVRAvgPrice.Text = "Average Days:"
        Me.lblSVRAvgPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSVRRegion
        '
        Me.cmbSVRRegion.FormattingEnabled = True
        Me.cmbSVRRegion.Location = New System.Drawing.Point(76, 49)
        Me.cmbSVRRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSVRRegion.Name = "cmbSVRRegion"
        Me.cmbSVRRegion.Size = New System.Drawing.Size(209, 24)
        Me.cmbSVRRegion.TabIndex = 5
        '
        'txtSVRThreshold
        '
        Me.txtSVRThreshold.Location = New System.Drawing.Point(76, 19)
        Me.txtSVRThreshold.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSVRThreshold.MaxLength = 10
        Me.txtSVRThreshold.Name = "txtSVRThreshold"
        Me.txtSVRThreshold.Size = New System.Drawing.Size(55, 22)
        Me.txtSVRThreshold.TabIndex = 1
        Me.txtSVRThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSVRThreshold
        '
        Me.lblSVRThreshold.AutoSize = True
        Me.lblSVRThreshold.Location = New System.Drawing.Point(5, 22)
        Me.lblSVRThreshold.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSVRThreshold.Name = "lblSVRThreshold"
        Me.lblSVRThreshold.Size = New System.Drawing.Size(76, 17)
        Me.lblSVRThreshold.TabIndex = 0
        Me.lblSVRThreshold.Text = "Threshold:"
        '
        'gbProxySettings
        '
        Me.gbProxySettings.Controls.Add(Me.txtProxyAddress)
        Me.gbProxySettings.Controls.Add(Me.lblProxyAddress)
        Me.gbProxySettings.Controls.Add(Me.txtProxyPort)
        Me.gbProxySettings.Controls.Add(Me.lblProxyPort)
        Me.gbProxySettings.Location = New System.Drawing.Point(434, 434)
        Me.gbProxySettings.Margin = New System.Windows.Forms.Padding(4)
        Me.gbProxySettings.Name = "gbProxySettings"
        Me.gbProxySettings.Padding = New System.Windows.Forms.Padding(4)
        Me.gbProxySettings.Size = New System.Drawing.Size(389, 75)
        Me.gbProxySettings.TabIndex = 41
        Me.gbProxySettings.TabStop = False
        Me.gbProxySettings.Text = "Proxy Settings:"
        '
        'txtProxyAddress
        '
        Me.txtProxyAddress.Location = New System.Drawing.Point(11, 36)
        Me.txtProxyAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProxyAddress.MaxLength = 0
        Me.txtProxyAddress.Name = "txtProxyAddress"
        Me.txtProxyAddress.Size = New System.Drawing.Size(305, 22)
        Me.txtProxyAddress.TabIndex = 5
        '
        'lblProxyAddress
        '
        Me.lblProxyAddress.AutoSize = True
        Me.lblProxyAddress.Location = New System.Drawing.Point(8, 19)
        Me.lblProxyAddress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProxyAddress.Name = "lblProxyAddress"
        Me.lblProxyAddress.Size = New System.Drawing.Size(64, 17)
        Me.lblProxyAddress.TabIndex = 4
        Me.lblProxyAddress.Text = "Address:"
        '
        'txtProxyPort
        '
        Me.txtProxyPort.Location = New System.Drawing.Point(325, 36)
        Me.txtProxyPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProxyPort.MaxLength = 0
        Me.txtProxyPort.Name = "txtProxyPort"
        Me.txtProxyPort.Size = New System.Drawing.Size(55, 22)
        Me.txtProxyPort.TabIndex = 3
        '
        'lblProxyPort
        '
        Me.lblProxyPort.AutoSize = True
        Me.lblProxyPort.Location = New System.Drawing.Point(321, 19)
        Me.lblProxyPort.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProxyPort.Name = "lblProxyPort"
        Me.lblProxyPort.Size = New System.Drawing.Size(38, 17)
        Me.lblProxyPort.TabIndex = 2
        Me.lblProxyPort.Text = "Port:"
        '
        'gbCharacterOptions
        '
        Me.gbCharacterOptions.Controls.Add(Me.chkLoadMaxAlphaSkills)
        Me.gbCharacterOptions.Controls.Add(Me.chkUseActiveSkills)
        Me.gbCharacterOptions.Controls.Add(Me.chkAlphaAccount)
        Me.gbCharacterOptions.Location = New System.Drawing.Point(308, 331)
        Me.gbCharacterOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCharacterOptions.Name = "gbCharacterOptions"
        Me.gbCharacterOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCharacterOptions.Size = New System.Drawing.Size(200, 100)
        Me.gbCharacterOptions.TabIndex = 39
        Me.gbCharacterOptions.TabStop = False
        Me.gbCharacterOptions.Text = "Character Options:"
        '
        'chkLoadMaxAlphaSkills
        '
        Me.chkLoadMaxAlphaSkills.AutoSize = True
        Me.chkLoadMaxAlphaSkills.Location = New System.Drawing.Point(11, 46)
        Me.chkLoadMaxAlphaSkills.Margin = New System.Windows.Forms.Padding(4)
        Me.chkLoadMaxAlphaSkills.Name = "chkLoadMaxAlphaSkills"
        Me.chkLoadMaxAlphaSkills.Size = New System.Drawing.Size(192, 21)
        Me.chkLoadMaxAlphaSkills.TabIndex = 33
        Me.chkLoadMaxAlphaSkills.Text = "Max Alpha Skills (Dummy)"
        Me.chkLoadMaxAlphaSkills.UseVisualStyleBackColor = True
        '
        'chkUseActiveSkills
        '
        Me.chkUseActiveSkills.AutoSize = True
        Me.chkUseActiveSkills.Location = New System.Drawing.Point(11, 71)
        Me.chkUseActiveSkills.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUseActiveSkills.Name = "chkUseActiveSkills"
        Me.chkUseActiveSkills.Size = New System.Drawing.Size(133, 21)
        Me.chkUseActiveSkills.TabIndex = 32
        Me.chkUseActiveSkills.Text = "Use Active Skills"
        Me.chkUseActiveSkills.UseVisualStyleBackColor = True
        '
        'chkAlphaAccount
        '
        Me.chkAlphaAccount.AutoSize = True
        Me.chkAlphaAccount.Location = New System.Drawing.Point(11, 21)
        Me.chkAlphaAccount.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAlphaAccount.Name = "chkAlphaAccount"
        Me.chkAlphaAccount.Size = New System.Drawing.Size(177, 21)
        Me.chkAlphaAccount.TabIndex = 31
        Me.chkAlphaAccount.Text = "Alpha Account (2% tax)"
        Me.chkAlphaAccount.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(831, 565)
        Me.Controls.Add(Me.gbCharacterOptions)
        Me.Controls.Add(Me.gbBuildBuySettings)
        Me.Controls.Add(Me.gbProxySettings)
        Me.Controls.Add(Me.gbCalcAvgPrice)
        Me.Controls.Add(Me.gbExportOptions)
        Me.Controls.Add(Me.gbStartupOptions)
        Me.Controls.Add(Me.gbImplants)
        Me.Controls.Add(Me.gbEVEMarketer)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbStationStandings)
        Me.Controls.Add(Me.gbGeneral)
        Me.Controls.Add(Me.gbDefaultMEPE)
        Me.Controls.Add(Me.gbShoppingList)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSettings"
        Me.Text = "Application Settings"
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        Me.gbStationStandings.ResumeLayout(False)
        Me.gbStationStandings.PerformLayout()
        Me.gbBuildBuySettings.ResumeLayout(False)
        Me.gbBuildBuySettings.PerformLayout()
        Me.gbDefaultMEPE.ResumeLayout(False)
        Me.gbDefaultMEPE.PerformLayout()
        Me.gbShoppingList.ResumeLayout(False)
        Me.gbShoppingList.PerformLayout()
        Me.gbEVEMarketer.ResumeLayout(False)
        Me.gbEVEMarketer.PerformLayout()
        Me.gbImplants.ResumeLayout(False)
        Me.gbImplants.PerformLayout()
        Me.gbStartupOptions.ResumeLayout(False)
        Me.gbStartupOptions.PerformLayout()
        Me.gbExportOptions.ResumeLayout(False)
        Me.gbExportOptions.PerformLayout()
        Me.gbCalcAvgPrice.ResumeLayout(False)
        Me.gbCalcAvgPrice.PerformLayout()
        Me.gbProxySettings.ResumeLayout(False)
        Me.gbProxySettings.PerformLayout()
        Me.gbCharacterOptions.ResumeLayout(False)
        Me.gbCharacterOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkCheckUpdatesStartup As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowToolTips As System.Windows.Forms.CheckBox
    Friend WithEvents chkBeanCounterRefining As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBeanCounterRefining As System.Windows.Forms.ComboBox
    Friend WithEvents chkBeanCounterManufacturing As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBeanCounterManufacturing As System.Windows.Forms.ComboBox
    Friend WithEvents gbStationStandings As System.Windows.Forms.GroupBox
    Friend WithEvents txtBrokerCorpStanding As System.Windows.Forms.TextBox
    Friend WithEvents chkBrokerCorpStanding As System.Windows.Forms.CheckBox
    Friend WithEvents txtBrokerFactionStanding As System.Windows.Forms.TextBox
    Friend WithEvents chkBrokerFactionStanding As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents gbBuildBuySettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkBuildBuyDefault As System.Windows.Forms.CheckBox
    Friend WithEvents chkBeanCounterCopy As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBeanCounterCopy As System.Windows.Forms.ComboBox
    Friend WithEvents gbDefaultMEPE As System.Windows.Forms.GroupBox
    Friend WithEvents txtDefaultTE As System.Windows.Forms.TextBox
    Friend WithEvents chkDefaultTE As System.Windows.Forms.CheckBox
    Friend WithEvents txtDefaultME As System.Windows.Forms.TextBox
    Friend WithEvents chkDefaultME As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisableSVR As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gbShoppingList As System.Windows.Forms.GroupBox
    Friend WithEvents chkIncludeShopListCopyMats As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeShopListInventMats As System.Windows.Forms.CheckBox
    Friend WithEvents chkSuggestBuildwhenBPnotOwned As System.Windows.Forms.CheckBox
    Friend WithEvents gbEVEMarketer As System.Windows.Forms.GroupBox
    Friend WithEvents txtEVEMarketerInterval As System.Windows.Forms.TextBox
    Friend WithEvents chkEVEMarketerInterval As System.Windows.Forms.CheckBox
    Friend WithEvents chkRefreshAssetsonStartup As System.Windows.Forms.CheckBox
    Friend WithEvents gbImplants As System.Windows.Forms.GroupBox
    Friend WithEvents chkDisableSound As System.Windows.Forms.CheckBox
    Friend WithEvents chkRefreshBPsonStartup As System.Windows.Forms.CheckBox
    Friend WithEvents gbStartupOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkRefreshSystemCostIndiciesDataonStartup As System.Windows.Forms.CheckBox
    Friend WithEvents chkRefreshMarketDataonStartup As System.Windows.Forms.CheckBox
    Friend WithEvents gbExportOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnExportDefault As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnExportSSV As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnExportCSV As System.Windows.Forms.RadioButton
    Friend WithEvents chkSaveBPRelicsDecryptors As System.Windows.Forms.CheckBox
    Friend WithEvents chkLinksInCopyText As System.Windows.Forms.CheckBox
    Friend WithEvents gbCalcAvgPrice As System.Windows.Forms.GroupBox
    Friend WithEvents lblSVRRegion As System.Windows.Forms.Label
    Friend WithEvents lblSVRAvgPrice As System.Windows.Forms.Label
    Friend WithEvents cmbSVRRegion As System.Windows.Forms.ComboBox
    Friend WithEvents txtSVRThreshold As System.Windows.Forms.TextBox
    Friend WithEvents lblSVRThreshold As System.Windows.Forms.Label
    Friend WithEvents cmbSVRAvgPriceDuration As System.Windows.Forms.ComboBox
    Friend WithEvents chkAutoUpdateSVRBPTab As System.Windows.Forms.CheckBox
    Friend WithEvents gbProxySettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtProxyAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblProxyAddress As System.Windows.Forms.Label
    Friend WithEvents txtProxyPort As System.Windows.Forms.TextBox
    Friend WithEvents lblProxyPort As System.Windows.Forms.Label
    Friend WithEvents chkLoadBPsbyChar As CheckBox
    Friend WithEvents chkSaveFacilitiesbyChar As CheckBox
    Friend WithEvents chkRefreshPublicStructureDataonStartup As CheckBox
    Friend WithEvents chkDisableTracking As CheckBox
    Friend WithEvents gbCharacterOptions As GroupBox
    Friend WithEvents chkUseActiveSkills As CheckBox
    Friend WithEvents chkAlphaAccount As CheckBox
    Friend WithEvents chkSupressESImsgs As CheckBox
    Friend WithEvents chkLoadMaxAlphaSkills As CheckBox
    Friend WithEvents chkShareFacilities As CheckBox
End Class
