<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManufacturingFacility
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cmbFacility = New System.Windows.Forms.ComboBox()
        Me.cmbFacilitySystem = New System.Windows.Forms.ComboBox()
        Me.cmbFacilityRegion = New System.Windows.Forms.ComboBox()
        Me.mainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblRegion = New MetroFramework.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'cmbFacility
        '
        Me.cmbFacility.BackColor = System.Drawing.Color.Black
        Me.cmbFacility.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cmbFacility.ForeColor = System.Drawing.Color.DarkGray
        Me.cmbFacility.FormattingEnabled = True
        Me.cmbFacility.ItemHeight = 20
        Me.cmbFacility.Items.AddRange(New Object() {"default"})
        Me.cmbFacility.Location = New System.Drawing.Point(400, 33)
        Me.cmbFacility.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacility.Name = "cmbFacility"
        Me.cmbFacility.Size = New System.Drawing.Size(387, 28)
        Me.cmbFacility.TabIndex = 14
        '
        'cmbFacilitySystem
        '
        Me.cmbFacilitySystem.BackColor = System.Drawing.Color.Black
        Me.cmbFacilitySystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cmbFacilitySystem.ForeColor = System.Drawing.Color.DarkGray
        Me.cmbFacilitySystem.FormattingEnabled = True
        Me.cmbFacilitySystem.ItemHeight = 20
        Me.cmbFacilitySystem.Location = New System.Drawing.Point(184, 33)
        Me.cmbFacilitySystem.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilitySystem.Name = "cmbFacilitySystem"
        Me.cmbFacilitySystem.Size = New System.Drawing.Size(208, 28)
        Me.cmbFacilitySystem.TabIndex = 13
        '
        'cmbFacilityRegion
        '
        Me.cmbFacilityRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFacilityRegion.BackColor = System.Drawing.Color.Black
        Me.cmbFacilityRegion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cmbFacilityRegion.ForeColor = System.Drawing.Color.DarkGray
        Me.cmbFacilityRegion.FormattingEnabled = True
        Me.cmbFacilityRegion.ItemHeight = 20
        Me.cmbFacilityRegion.Location = New System.Drawing.Point(4, 33)
        Me.cmbFacilityRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilityRegion.Name = "cmbFacilityRegion"
        Me.cmbFacilityRegion.Size = New System.Drawing.Size(172, 28)
        Me.cmbFacilityRegion.TabIndex = 12
        '
        'lblRegion
        '
        Me.lblRegion.Location = New System.Drawing.Point(20, 4)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(759, 26)
        Me.lblRegion.TabIndex = 113
        Me.lblRegion.Text = "Select a Facility to manufacture in (lower taxes is better)"
        Me.lblRegion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblRegion.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.lblRegion.WrapToLine = True
        '
        'ManufacturingFacility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbFacility)
        Me.Controls.Add(Me.cmbFacilitySystem)
        Me.Controls.Add(Me.cmbFacilityRegion)
        Me.Controls.Add(Me.lblRegion)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ManufacturingFacility"
        Me.Size = New System.Drawing.Size(798, 70)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbFacility As ComboBox
    Friend WithEvents cmbFacilitySystem As ComboBox
    Friend WithEvents cmbFacilityRegion As ComboBox
    Friend WithEvents mainToolTip As ToolTip
    Friend WithEvents lblRegion As MetroFramework.Controls.MetroLabel
End Class
