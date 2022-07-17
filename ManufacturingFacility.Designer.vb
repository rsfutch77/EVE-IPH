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
        Me.cmbFacility = New MetroFramework.Controls.MetroComboBox()
        Me.cmbFacilitySystem = New MetroFramework.Controls.MetroComboBox()
        Me.cmbFacilityRegion = New MetroFramework.Controls.MetroComboBox()
        Me.mainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'cmbFacility
        '
        Me.cmbFacility.FormattingEnabled = True
        Me.cmbFacility.ItemHeight = 24
        Me.cmbFacility.Location = New System.Drawing.Point(398, 13)
        Me.cmbFacility.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacility.Name = "cmbFacility"
        Me.cmbFacility.Size = New System.Drawing.Size(387, 30)
        Me.cmbFacility.TabIndex = 14
        Me.cmbFacility.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.cmbFacility.UseSelectable = True
        '
        'cmbFacilitySystem
        '
        Me.cmbFacilitySystem.FormattingEnabled = True
        Me.cmbFacilitySystem.ItemHeight = 24
        Me.cmbFacilitySystem.Location = New System.Drawing.Point(182, 13)
        Me.cmbFacilitySystem.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilitySystem.Name = "cmbFacilitySystem"
        Me.cmbFacilitySystem.Size = New System.Drawing.Size(208, 30)
        Me.cmbFacilitySystem.TabIndex = 13
        Me.cmbFacilitySystem.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.cmbFacilitySystem.UseSelectable = True
        '
        'cmbFacilityRegion
        '
        Me.cmbFacilityRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFacilityRegion.FormattingEnabled = True
        Me.cmbFacilityRegion.ItemHeight = 24
        Me.cmbFacilityRegion.Location = New System.Drawing.Point(4, 13)
        Me.cmbFacilityRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilityRegion.Name = "cmbFacilityRegion"
        Me.cmbFacilityRegion.Size = New System.Drawing.Size(172, 30)
        Me.cmbFacilityRegion.TabIndex = 12
        Me.cmbFacilityRegion.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.cmbFacilityRegion.UseSelectable = True
        '
        'ManufacturingFacility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 51)
        Me.Controls.Add(Me.cmbFacility)
        Me.Controls.Add(Me.cmbFacilitySystem)
        Me.Controls.Add(Me.cmbFacilityRegion)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ManufacturingFacility"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbFacility As MetroFramework.Controls.MetroComboBox
    Friend WithEvents cmbFacilitySystem As MetroFramework.Controls.MetroComboBox
    Friend WithEvents cmbFacilityRegion As MetroFramework.Controls.MetroComboBox
    Friend WithEvents mainToolTip As ToolTip
End Class
