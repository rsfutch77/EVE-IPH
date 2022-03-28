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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.chkDisableTracking = New System.Windows.Forms.CheckBox()
        Me.chkBeanCounterManufacturing = New System.Windows.Forms.CheckBox()
        Me.cmbBeanCounterManufacturing = New System.Windows.Forms.ComboBox()
        Me.gbStationStandings = New System.Windows.Forms.GroupBox()
        Me.txtBrokerCorpStanding = New System.Windows.Forms.TextBox()
        Me.chkBrokerCorpStanding = New System.Windows.Forms.CheckBox()
        Me.txtBrokerFactionStanding = New System.Windows.Forms.TextBox()
        Me.chkBrokerFactionStanding = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.chkBuildBuyDefault = New System.Windows.Forms.CheckBox()
        Me.chkSuggestBuildwhenBPnotOwned = New System.Windows.Forms.CheckBox()
        Me.gbDefaultMEPE = New System.Windows.Forms.GroupBox()
        Me.txtDefaultTE = New System.Windows.Forms.TextBox()
        Me.chkDefaultTE = New System.Windows.Forms.CheckBox()
        Me.txtDefaultME = New System.Windows.Forms.TextBox()
        Me.chkDefaultME = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbStartupOptions = New System.Windows.Forms.GroupBox()
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
        Me.chkAlphaAccount = New System.Windows.Forms.CheckBox()
        Me.gbGeneral.SuspendLayout()
        Me.gbStationStandings.SuspendLayout()
        Me.gbDefaultMEPE.SuspendLayout()
        Me.gbExportOptions.SuspendLayout()
        Me.gbCalcAvgPrice.SuspendLayout()
        Me.SuspendLayout()
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
        Me.gbGeneral.Controls.Add(Me.chkDisableTracking)
        Me.gbGeneral.Location = New System.Drawing.Point(6, 15)
        Me.gbGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.gbGeneral.Size = New System.Drawing.Size(294, 232)
        Me.gbGeneral.TabIndex = 4
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "General:"
        '
        'chkDisableTracking
        '
        Me.chkDisableTracking.AutoSize = True
        Me.chkDisableTracking.Location = New System.Drawing.Point(21, 199)
        Me.chkDisableTracking.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDisableTracking.Name = "chkDisableTracking"
        Me.chkDisableTracking.Size = New System.Drawing.Size(251, 20)
        Me.chkDisableTracking.TabIndex = 41
        Me.chkDisableTracking.Text = "Disable Anonomous Usage Tracking"
        Me.chkDisableTracking.UseVisualStyleBackColor = True
        '
        'chkBeanCounterManufacturing
        '
        Me.chkBeanCounterManufacturing.AutoSize = True
        Me.chkBeanCounterManufacturing.Location = New System.Drawing.Point(435, 447)
        Me.chkBeanCounterManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBeanCounterManufacturing.Name = "chkBeanCounterManufacturing"
        Me.chkBeanCounterManufacturing.Size = New System.Drawing.Size(237, 20)
        Me.chkBeanCounterManufacturing.TabIndex = 3
        Me.chkBeanCounterManufacturing.Text = "Manufacturing Beancounter Implant"
        Me.chkBeanCounterManufacturing.UseVisualStyleBackColor = True
        '
        'cmbBeanCounterManufacturing
        '
        Me.cmbBeanCounterManufacturing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeanCounterManufacturing.FormattingEnabled = True
        Me.cmbBeanCounterManufacturing.Items.AddRange(New Object() {"Zainou 'Beancounter' Industry BX-801", "Zainou 'Beancounter' Industry BX-802", "Zainou 'Beancounter' Industry BX-804"})
        Me.cmbBeanCounterManufacturing.Location = New System.Drawing.Point(435, 475)
        Me.cmbBeanCounterManufacturing.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBeanCounterManufacturing.Name = "cmbBeanCounterManufacturing"
        Me.cmbBeanCounterManufacturing.Size = New System.Drawing.Size(293, 24)
        Me.cmbBeanCounterManufacturing.TabIndex = 4
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
        'chkBuildBuyDefault
        '
        Me.chkBuildBuyDefault.AutoSize = True
        Me.chkBuildBuyDefault.Location = New System.Drawing.Point(566, 98)
        Me.chkBuildBuyDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBuildBuyDefault.Name = "chkBuildBuyDefault"
        Me.chkBuildBuyDefault.Size = New System.Drawing.Size(131, 20)
        Me.chkBuildBuyDefault.TabIndex = 32
        Me.chkBuildBuyDefault.Text = "Default Build/Buy"
        Me.chkBuildBuyDefault.UseVisualStyleBackColor = True
        '
        'chkSuggestBuildwhenBPnotOwned
        '
        Me.chkSuggestBuildwhenBPnotOwned.AutoSize = True
        Me.chkSuggestBuildwhenBPnotOwned.Checked = True
        Me.chkSuggestBuildwhenBPnotOwned.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSuggestBuildwhenBPnotOwned.Location = New System.Drawing.Point(553, 139)
        Me.chkSuggestBuildwhenBPnotOwned.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSuggestBuildwhenBPnotOwned.Name = "chkSuggestBuildwhenBPnotOwned"
        Me.chkSuggestBuildwhenBPnotOwned.Size = New System.Drawing.Size(271, 20)
        Me.chkSuggestBuildwhenBPnotOwned.TabIndex = 37
        Me.chkSuggestBuildwhenBPnotOwned.Text = "Suggest Build option when BP not owned"
        Me.chkSuggestBuildwhenBPnotOwned.UseVisualStyleBackColor = True
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
        'gbStartupOptions
        '
        Me.gbStartupOptions.Location = New System.Drawing.Point(6, 250)
        Me.gbStartupOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.gbStartupOptions.Name = "gbStartupOptions"
        Me.gbStartupOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.gbStartupOptions.Size = New System.Drawing.Size(294, 202)
        Me.gbStartupOptions.TabIndex = 39
        Me.gbStartupOptions.TabStop = False
        Me.gbStartupOptions.Text = "Startup Options"
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
        Me.rbtnExportSSV.Size = New System.Drawing.Size(55, 20)
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
        Me.rbtnExportCSV.Size = New System.Drawing.Size(55, 20)
        Me.rbtnExportCSV.TabIndex = 1
        Me.rbtnExportCSV.TabStop = True
        Me.rbtnExportCSV.Text = "CSV"
        Me.rbtnExportCSV.UseVisualStyleBackColor = True
        '
        'rbtnExportDefault
        '
        Me.rbtnExportDefault.AutoSize = True
        Me.rbtnExportDefault.Checked = True
        Me.rbtnExportDefault.Location = New System.Drawing.Point(11, 31)
        Me.rbtnExportDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportDefault.Name = "rbtnExportDefault"
        Me.rbtnExportDefault.Size = New System.Drawing.Size(70, 20)
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
        Me.chkAutoUpdateSVRBPTab.Size = New System.Drawing.Size(252, 20)
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
        Me.lblSVRRegion.Size = New System.Drawing.Size(54, 16)
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
        Me.lblSVRThreshold.Size = New System.Drawing.Size(71, 16)
        Me.lblSVRThreshold.TabIndex = 0
        Me.lblSVRThreshold.Text = "Threshold:"
        '
        'chkAlphaAccount
        '
        Me.chkAlphaAccount.AutoSize = True
        Me.chkAlphaAccount.Location = New System.Drawing.Point(331, 164)
        Me.chkAlphaAccount.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAlphaAccount.Name = "chkAlphaAccount"
        Me.chkAlphaAccount.Size = New System.Drawing.Size(165, 20)
        Me.chkAlphaAccount.TabIndex = 31
        Me.chkAlphaAccount.Text = "Alpha Account (2% tax)"
        Me.chkAlphaAccount.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.Controls.Add(Me.chkBuildBuyDefault)
        Me.Controls.Add(Me.chkAlphaAccount)
        Me.Controls.Add(Me.chkSuggestBuildwhenBPnotOwned)
        Me.Controls.Add(Me.chkBeanCounterManufacturing)
        Me.Controls.Add(Me.cmbBeanCounterManufacturing)
        Me.Controls.Add(Me.gbCalcAvgPrice)
        Me.Controls.Add(Me.gbExportOptions)
        Me.Controls.Add(Me.gbStartupOptions)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbStationStandings)
        Me.Controls.Add(Me.gbGeneral)
        Me.Controls.Add(Me.gbDefaultMEPE)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSettings"
        Me.Size = New System.Drawing.Size(831, 566)
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        Me.gbStationStandings.ResumeLayout(False)
        Me.gbStationStandings.PerformLayout()
        Me.gbDefaultMEPE.ResumeLayout(False)
        Me.gbDefaultMEPE.PerformLayout()
        Me.gbExportOptions.ResumeLayout(False)
        Me.gbExportOptions.PerformLayout()
        Me.gbCalcAvgPrice.ResumeLayout(False)
        Me.gbCalcAvgPrice.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents chkBeanCounterManufacturing As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBeanCounterManufacturing As System.Windows.Forms.ComboBox
    Friend WithEvents gbStationStandings As System.Windows.Forms.GroupBox
    Friend WithEvents txtBrokerCorpStanding As System.Windows.Forms.TextBox
    Friend WithEvents chkBrokerCorpStanding As System.Windows.Forms.CheckBox
    Friend WithEvents txtBrokerFactionStanding As System.Windows.Forms.TextBox
    Friend WithEvents chkBrokerFactionStanding As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents chkBuildBuyDefault As System.Windows.Forms.CheckBox
    Friend WithEvents gbDefaultMEPE As System.Windows.Forms.GroupBox
    Friend WithEvents txtDefaultTE As System.Windows.Forms.TextBox
    Friend WithEvents chkDefaultTE As System.Windows.Forms.CheckBox
    Friend WithEvents txtDefaultME As System.Windows.Forms.TextBox
    Friend WithEvents chkDefaultME As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkSuggestBuildwhenBPnotOwned As System.Windows.Forms.CheckBox
    Friend WithEvents gbStartupOptions As System.Windows.Forms.GroupBox
    Friend WithEvents gbExportOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnExportDefault As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnExportSSV As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnExportCSV As System.Windows.Forms.RadioButton
    Friend WithEvents gbCalcAvgPrice As System.Windows.Forms.GroupBox
    Friend WithEvents lblSVRRegion As System.Windows.Forms.Label
    Friend WithEvents lblSVRAvgPrice As System.Windows.Forms.Label
    Friend WithEvents cmbSVRRegion As System.Windows.Forms.ComboBox
    Friend WithEvents txtSVRThreshold As System.Windows.Forms.TextBox
    Friend WithEvents lblSVRThreshold As System.Windows.Forms.Label
    Friend WithEvents cmbSVRAvgPriceDuration As System.Windows.Forms.ComboBox
    Friend WithEvents chkAutoUpdateSVRBPTab As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisableTracking As CheckBox
    Friend WithEvents chkAlphaAccount As CheckBox
End Class
