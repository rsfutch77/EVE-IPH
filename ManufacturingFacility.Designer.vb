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
        Me.chkFacilityIncludeUsage = New System.Windows.Forms.CheckBox()
        Me.cmbFacilityorArray = New System.Windows.Forms.ComboBox()
        Me.cmbFacilitySystem = New System.Windows.Forms.ComboBox()
        Me.cmbFacilityRegion = New System.Windows.Forms.ComboBox()
        Me.lblFacilityLocation = New System.Windows.Forms.Label()
        Me.lblFacilityType = New System.Windows.Forms.Label()
        Me.cmbFacilityType = New System.Windows.Forms.ComboBox()
        Me.btnFacilityFitting = New System.Windows.Forms.Button()
        Me.txtFacilityManualTax = New System.Windows.Forms.TextBox()
        Me.lblFacilityManualTax = New System.Windows.Forms.Label()
        Me.btnFacilitySave = New System.Windows.Forms.Button()
        Me.txtFacilityManualTE = New System.Windows.Forms.TextBox()
        Me.txtFacilityManualME = New System.Windows.Forms.TextBox()
        Me.lblFacilityManualTE = New System.Windows.Forms.Label()
        Me.lblFacilityManualME = New System.Windows.Forms.Label()
        Me.lblFacilityManualCost = New System.Windows.Forms.Label()
        Me.txtFacilityManualCost = New System.Windows.Forms.TextBox()
        Me.mainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'chkFacilityIncludeUsage
        '
        Me.chkFacilityIncludeUsage.AutoSize = True
        Me.chkFacilityIncludeUsage.Location = New System.Drawing.Point(185, 25)
        Me.chkFacilityIncludeUsage.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFacilityIncludeUsage.Name = "chkFacilityIncludeUsage"
        Me.chkFacilityIncludeUsage.Size = New System.Drawing.Size(71, 21)
        Me.chkFacilityIncludeUsage.TabIndex = 7
        Me.chkFacilityIncludeUsage.Text = "Usage"
        Me.chkFacilityIncludeUsage.UseVisualStyleBackColor = True
        '
        'cmbFacilityorArray
        '
        Me.cmbFacilityorArray.FormattingEnabled = True
        Me.cmbFacilityorArray.ItemHeight = 16
        Me.cmbFacilityorArray.Location = New System.Drawing.Point(5, 78)
        Me.cmbFacilityorArray.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilityorArray.Name = "cmbFacilityorArray"
        Me.cmbFacilityorArray.Size = New System.Drawing.Size(387, 24)
        Me.cmbFacilityorArray.TabIndex = 14
        Me.cmbFacilityorArray.Text = "Select Facility / Array"
        '
        'cmbFacilitySystem
        '
        Me.cmbFacilitySystem.FormattingEnabled = True
        Me.cmbFacilitySystem.Location = New System.Drawing.Point(185, 46)
        Me.cmbFacilitySystem.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilitySystem.Name = "cmbFacilitySystem"
        Me.cmbFacilitySystem.Size = New System.Drawing.Size(208, 24)
        Me.cmbFacilitySystem.TabIndex = 13
        Me.cmbFacilitySystem.Text = "Select System"
        '
        'cmbFacilityRegion
        '
        Me.cmbFacilityRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFacilityRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFacilityRegion.FormattingEnabled = True
        Me.cmbFacilityRegion.Location = New System.Drawing.Point(7, 46)
        Me.cmbFacilityRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilityRegion.Name = "cmbFacilityRegion"
        Me.cmbFacilityRegion.Size = New System.Drawing.Size(172, 24)
        Me.cmbFacilityRegion.TabIndex = 12
        Me.cmbFacilityRegion.Text = "Select Region"
        '
        'lblFacilityLocation
        '
        Me.lblFacilityLocation.AutoSize = True
        Me.lblFacilityLocation.Location = New System.Drawing.Point(4, 27)
        Me.lblFacilityLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacilityLocation.Name = "lblFacilityLocation"
        Me.lblFacilityLocation.Size = New System.Drawing.Size(66, 17)
        Me.lblFacilityLocation.TabIndex = 11
        Me.lblFacilityLocation.Text = "Location:"
        '
        'lblFacilityType
        '
        Me.lblFacilityType.AutoSize = True
        Me.lblFacilityType.Location = New System.Drawing.Point(1, 5)
        Me.lblFacilityType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacilityType.Name = "lblFacilityType"
        Me.lblFacilityType.Size = New System.Drawing.Size(91, 17)
        Me.lblFacilityType.TabIndex = 2
        Me.lblFacilityType.Text = "Facility Type:"
        '
        'cmbFacilityType
        '
        Me.cmbFacilityType.FormattingEnabled = True
        Me.cmbFacilityType.ItemHeight = 16
        Me.cmbFacilityType.Location = New System.Drawing.Point(91, 1)
        Me.cmbFacilityType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFacilityType.Name = "cmbFacilityType"
        Me.cmbFacilityType.Size = New System.Drawing.Size(85, 24)
        Me.cmbFacilityType.TabIndex = 3
        '
        'btnFacilityFitting
        '
        Me.btnFacilityFitting.Location = New System.Drawing.Point(279, 105)
        Me.btnFacilityFitting.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFacilityFitting.Name = "btnFacilityFitting"
        Me.btnFacilityFitting.Size = New System.Drawing.Size(57, 27)
        Me.btnFacilityFitting.TabIndex = 23
        Me.btnFacilityFitting.Text = "Fitting"
        Me.btnFacilityFitting.UseVisualStyleBackColor = True
        '
        'txtFacilityManualTax
        '
        Me.txtFacilityManualTax.Location = New System.Drawing.Point(177, 129)
        Me.txtFacilityManualTax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacilityManualTax.MaxLength = 7
        Me.txtFacilityManualTax.Name = "txtFacilityManualTax"
        Me.txtFacilityManualTax.Size = New System.Drawing.Size(65, 22)
        Me.txtFacilityManualTax.TabIndex = 22
        Me.txtFacilityManualTax.Text = "100.00%"
        Me.txtFacilityManualTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFacilityManualTax
        '
        Me.lblFacilityManualTax.AutoSize = True
        Me.lblFacilityManualTax.Location = New System.Drawing.Point(132, 134)
        Me.lblFacilityManualTax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacilityManualTax.Name = "lblFacilityManualTax"
        Me.lblFacilityManualTax.Size = New System.Drawing.Size(35, 17)
        Me.lblFacilityManualTax.TabIndex = 21
        Me.lblFacilityManualTax.Text = "Tax:"
        '
        'btnFacilitySave
        '
        Me.btnFacilitySave.Location = New System.Drawing.Point(340, 105)
        Me.btnFacilitySave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFacilitySave.Name = "btnFacilitySave"
        Me.btnFacilitySave.Size = New System.Drawing.Size(53, 27)
        Me.btnFacilitySave.TabIndex = 24
        Me.btnFacilitySave.Text = "Save"
        Me.btnFacilitySave.UseVisualStyleBackColor = True
        '
        'txtFacilityManualTE
        '
        Me.txtFacilityManualTE.Location = New System.Drawing.Point(177, 103)
        Me.txtFacilityManualTE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacilityManualTE.MaxLength = 7
        Me.txtFacilityManualTE.Name = "txtFacilityManualTE"
        Me.txtFacilityManualTE.Size = New System.Drawing.Size(65, 22)
        Me.txtFacilityManualTE.TabIndex = 20
        Me.txtFacilityManualTE.Text = "100.00%"
        Me.txtFacilityManualTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFacilityManualME
        '
        Me.txtFacilityManualME.Location = New System.Drawing.Point(51, 103)
        Me.txtFacilityManualME.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacilityManualME.MaxLength = 7
        Me.txtFacilityManualME.Name = "txtFacilityManualME"
        Me.txtFacilityManualME.Size = New System.Drawing.Size(65, 22)
        Me.txtFacilityManualME.TabIndex = 16
        Me.txtFacilityManualME.Text = "100.00%"
        Me.txtFacilityManualME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFacilityManualTE
        '
        Me.lblFacilityManualTE.AutoSize = True
        Me.lblFacilityManualTE.Location = New System.Drawing.Point(137, 108)
        Me.lblFacilityManualTE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacilityManualTE.Name = "lblFacilityManualTE"
        Me.lblFacilityManualTE.Size = New System.Drawing.Size(30, 17)
        Me.lblFacilityManualTE.TabIndex = 19
        Me.lblFacilityManualTE.Text = "TE:"
        '
        'lblFacilityManualME
        '
        Me.lblFacilityManualME.AutoSize = True
        Me.lblFacilityManualME.Location = New System.Drawing.Point(8, 108)
        Me.lblFacilityManualME.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacilityManualME.Name = "lblFacilityManualME"
        Me.lblFacilityManualME.Size = New System.Drawing.Size(32, 17)
        Me.lblFacilityManualME.TabIndex = 15
        Me.lblFacilityManualME.Text = "ME:"
        '
        'lblFacilityManualCost
        '
        Me.lblFacilityManualCost.AutoSize = True
        Me.lblFacilityManualCost.Location = New System.Drawing.Point(8, 134)
        Me.lblFacilityManualCost.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacilityManualCost.Name = "lblFacilityManualCost"
        Me.lblFacilityManualCost.Size = New System.Drawing.Size(40, 17)
        Me.lblFacilityManualCost.TabIndex = 17
        Me.lblFacilityManualCost.Text = "Cost:"
        '
        'txtFacilityManualCost
        '
        Me.txtFacilityManualCost.Location = New System.Drawing.Point(51, 129)
        Me.txtFacilityManualCost.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacilityManualCost.MaxLength = 7
        Me.txtFacilityManualCost.Name = "txtFacilityManualCost"
        Me.txtFacilityManualCost.Size = New System.Drawing.Size(65, 22)
        Me.txtFacilityManualCost.TabIndex = 18
        Me.txtFacilityManualCost.Text = "100.00%"
        Me.txtFacilityManualCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ManufacturingFacility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbFacilityType)
        Me.Controls.Add(Me.txtFacilityManualCost)
        Me.Controls.Add(Me.lblFacilityManualCost)
        Me.Controls.Add(Me.btnFacilityFitting)
        Me.Controls.Add(Me.txtFacilityManualTax)
        Me.Controls.Add(Me.lblFacilityManualTax)
        Me.Controls.Add(Me.btnFacilitySave)
        Me.Controls.Add(Me.txtFacilityManualTE)
        Me.Controls.Add(Me.txtFacilityManualME)
        Me.Controls.Add(Me.lblFacilityManualTE)
        Me.Controls.Add(Me.lblFacilityManualME)
        Me.Controls.Add(Me.chkFacilityIncludeUsage)
        Me.Controls.Add(Me.cmbFacilityorArray)
        Me.Controls.Add(Me.cmbFacilitySystem)
        Me.Controls.Add(Me.cmbFacilityRegion)
        Me.Controls.Add(Me.lblFacilityLocation)
        Me.Controls.Add(Me.lblFacilityType)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ManufacturingFacility"
        Me.Size = New System.Drawing.Size(549, 422)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkFacilityIncludeUsage As CheckBox
    Friend WithEvents cmbFacilityorArray As ComboBox
    Friend WithEvents cmbFacilitySystem As ComboBox
    Friend WithEvents cmbFacilityRegion As ComboBox
    Friend WithEvents lblFacilityLocation As Label
    Friend WithEvents lblFacilityType As Label
    Friend WithEvents cmbFacilityType As ComboBox
    Friend WithEvents btnFacilityFitting As Button
    Friend WithEvents txtFacilityManualTax As TextBox
    Friend WithEvents lblFacilityManualTax As Label
    Friend WithEvents btnFacilitySave As Button
    Friend WithEvents txtFacilityManualTE As TextBox
    Friend WithEvents txtFacilityManualME As TextBox
    Friend WithEvents lblFacilityManualTE As Label
    Friend WithEvents lblFacilityManualME As Label
    Friend WithEvents lblFacilityManualCost As Label
    Friend WithEvents txtFacilityManualCost As TextBox
    Friend WithEvents mainToolTip As ToolTip
End Class
