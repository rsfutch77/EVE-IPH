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
        Me.chkDisableTracking = New System.Windows.Forms.CheckBox()
        Me.chkBeanCounterManufacturing = New System.Windows.Forms.CheckBox()
        Me.cmbBeanCounterManufacturing = New System.Windows.Forms.ComboBox()
        Me.gbStationStandings = New System.Windows.Forms.GroupBox()
        Me.txtBrokerCorpStanding = New System.Windows.Forms.TextBox()
        Me.chkBrokerCorpStanding = New System.Windows.Forms.CheckBox()
        Me.txtBrokerFactionStanding = New System.Windows.Forms.TextBox()
        Me.chkBrokerFactionStanding = New System.Windows.Forms.CheckBox()
        Me.chkBuildBuyDefault = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkAlphaAccount = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbStationStandings.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkDisableTracking
        '
        Me.chkDisableTracking.AutoSize = True
        Me.chkDisableTracking.Location = New System.Drawing.Point(25, 98)
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
        Me.chkBeanCounterManufacturing.Location = New System.Drawing.Point(553, 423)
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
        Me.cmbBeanCounterManufacturing.Location = New System.Drawing.Point(513, 451)
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
        Me.gbStationStandings.Location = New System.Drawing.Point(578, 254)
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
        Me.txtBrokerCorpStanding.Text = "5"
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
        Me.txtBrokerFactionStanding.Text = "5"
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
        'chkBuildBuyDefault
        '
        Me.chkBuildBuyDefault.AutoSize = True
        Me.chkBuildBuyDefault.Location = New System.Drawing.Point(14, 423)
        Me.chkBuildBuyDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBuildBuyDefault.Name = "chkBuildBuyDefault"
        Me.chkBuildBuyDefault.Size = New System.Drawing.Size(131, 20)
        Me.chkBuildBuyDefault.TabIndex = 32
        Me.chkBuildBuyDefault.Text = "Default Build/Buy"
        Me.chkBuildBuyDefault.UseVisualStyleBackColor = True
        '
        'chkAlphaAccount
        '
        Me.chkAlphaAccount.AutoSize = True
        Me.chkAlphaAccount.Location = New System.Drawing.Point(603, 360)
        Me.chkAlphaAccount.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAlphaAccount.Name = "chkAlphaAccount"
        Me.chkAlphaAccount.Size = New System.Drawing.Size(165, 20)
        Me.chkAlphaAccount.TabIndex = 31
        Me.chkAlphaAccount.Text = "Alpha Account (2% tax)"
        Me.chkAlphaAccount.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Keep"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "pick default"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(586, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "automate"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkDisableTracking)
        Me.Controls.Add(Me.chkBuildBuyDefault)
        Me.Controls.Add(Me.chkAlphaAccount)
        Me.Controls.Add(Me.chkBeanCounterManufacturing)
        Me.Controls.Add(Me.cmbBeanCounterManufacturing)
        Me.Controls.Add(Me.gbStationStandings)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSettings"
        Me.Size = New System.Drawing.Size(831, 566)
        Me.gbStationStandings.ResumeLayout(False)
        Me.gbStationStandings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkBeanCounterManufacturing As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBeanCounterManufacturing As System.Windows.Forms.ComboBox
    Friend WithEvents gbStationStandings As System.Windows.Forms.GroupBox
    Friend WithEvents txtBrokerCorpStanding As System.Windows.Forms.TextBox
    Friend WithEvents chkBrokerCorpStanding As System.Windows.Forms.CheckBox
    Friend WithEvents txtBrokerFactionStanding As System.Windows.Forms.TextBox
    Friend WithEvents chkBrokerFactionStanding As System.Windows.Forms.CheckBox
    Friend WithEvents chkBuildBuyDefault As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkDisableTracking As CheckBox
    Friend WithEvents chkAlphaAccount As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
