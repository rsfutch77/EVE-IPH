<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmShoppingList
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.DeleteBuildStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteBuildItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteItemStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTotalProfit1 = New System.Windows.Forms.Label()
        Me.lblTotalProfit = New System.Windows.Forms.Label()
        Me.lblAvgIPH = New System.Windows.Forms.Label()
        Me.lblAvgIPH1 = New System.Windows.Forms.Label()
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtListEdit = New System.Windows.Forms.TextBox()
        Me.DeleteMaterialStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMaterial = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbExportOptions = New System.Windows.Forms.GroupBox()
        Me.rbtnExportMulitBuy = New System.Windows.Forms.RadioButton()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblItemstoBuy = New System.Windows.Forms.Label()
        Me.lblItemstoBuild = New System.Windows.Forms.Label()
        Me.lstBuy = New EVE_Isk_per_Hour.MyListView()
        Me.lstItems = New EVE_Isk_per_Hour.MyListView()
        Me.DeleteBuildStrip.SuspendLayout()
        Me.DeleteItemStrip.SuspendLayout()
        Me.DeleteMaterialStrip.SuspendLayout()
        Me.gbExportOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(9, 679)
        Me.btnCopy.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(118, 40)
        Me.btnCopy.TabIndex = 0
        Me.btnCopy.Text = "Copy List"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'DeleteBuildStrip
        '
        Me.DeleteBuildStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DeleteBuildStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteBuildItem})
        Me.DeleteBuildStrip.Name = "ContextMenuStrip1"
        Me.DeleteBuildStrip.Size = New System.Drawing.Size(195, 28)
        '
        'DeleteBuildItem
        '
        Me.DeleteBuildItem.Name = "DeleteBuildItem"
        Me.DeleteBuildItem.Size = New System.Drawing.Size(194, 24)
        Me.DeleteBuildItem.Text = "Delete Build Item"
        '
        'DeleteItemStrip
        '
        Me.DeleteItemStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DeleteItemStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteItem})
        Me.DeleteItemStrip.Name = "ContextMenuStrip1"
        Me.DeleteItemStrip.Size = New System.Drawing.Size(157, 28)
        '
        'DeleteItem
        '
        Me.DeleteItem.Name = "DeleteItem"
        Me.DeleteItem.Size = New System.Drawing.Size(156, 24)
        Me.DeleteItem.Text = "Delete Item"
        '
        'lblTotalProfit1
        '
        Me.lblTotalProfit1.AutoSize = True
        Me.lblTotalProfit1.Location = New System.Drawing.Point(593, 620)
        Me.lblTotalProfit1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalProfit1.Name = "lblTotalProfit1"
        Me.lblTotalProfit1.Size = New System.Drawing.Size(123, 16)
        Me.lblTotalProfit1.TabIndex = 34
        Me.lblTotalProfit1.Text = "Approx. Total Profit:"
        Me.lblTotalProfit1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalProfit
        '
        Me.lblTotalProfit.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalProfit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalProfit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalProfit.Location = New System.Drawing.Point(719, 617)
        Me.lblTotalProfit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalProfit.Name = "lblTotalProfit"
        Me.lblTotalProfit.Size = New System.Drawing.Size(204, 20)
        Me.lblTotalProfit.TabIndex = 35
        Me.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAvgIPH
        '
        Me.lblAvgIPH.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAvgIPH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAvgIPH.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblAvgIPH.Location = New System.Drawing.Point(719, 593)
        Me.lblAvgIPH.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvgIPH.Name = "lblAvgIPH"
        Me.lblAvgIPH.Size = New System.Drawing.Size(204, 20)
        Me.lblAvgIPH.TabIndex = 33
        Me.lblAvgIPH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAvgIPH1
        '
        Me.lblAvgIPH1.AutoSize = True
        Me.lblAvgIPH1.Location = New System.Drawing.Point(603, 596)
        Me.lblAvgIPH1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvgIPH1.Name = "lblAvgIPH1"
        Me.lblAvgIPH1.Size = New System.Drawing.Size(111, 16)
        Me.lblAvgIPH1.TabIndex = 32
        Me.lblAvgIPH1.Text = "Approx. Avg. IPH:"
        Me.lblAvgIPH1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ttMain
        '
        Me.ttMain.IsBalloon = True
        '
        'txtListEdit
        '
        Me.txtListEdit.Location = New System.Drawing.Point(554, 2)
        Me.txtListEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtListEdit.Name = "txtListEdit"
        Me.txtListEdit.Size = New System.Drawing.Size(59, 22)
        Me.txtListEdit.TabIndex = 40
        Me.txtListEdit.TabStop = False
        Me.txtListEdit.Visible = False
        '
        'DeleteMaterialStrip
        '
        Me.DeleteMaterialStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DeleteMaterialStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteMaterial})
        Me.DeleteMaterialStrip.Name = "ContextMenuStrip1"
        Me.DeleteMaterialStrip.Size = New System.Drawing.Size(182, 28)
        '
        'DeleteMaterial
        '
        Me.DeleteMaterial.Name = "DeleteMaterial"
        Me.DeleteMaterial.Size = New System.Drawing.Size(181, 24)
        Me.DeleteMaterial.Text = "Delete Material"
        '
        'gbExportOptions
        '
        Me.gbExportOptions.Controls.Add(Me.rbtnExportMulitBuy)
        Me.gbExportOptions.Location = New System.Drawing.Point(168, 702)
        Me.gbExportOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.gbExportOptions.Name = "gbExportOptions"
        Me.gbExportOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.gbExportOptions.Size = New System.Drawing.Size(154, 108)
        Me.gbExportOptions.TabIndex = 74
        Me.gbExportOptions.TabStop = False
        Me.gbExportOptions.Text = "Export Data in:"
        '
        'rbtnExportMulitBuy
        '
        Me.rbtnExportMulitBuy.AutoSize = True
        Me.rbtnExportMulitBuy.Checked = True
        Me.rbtnExportMulitBuy.Location = New System.Drawing.Point(10, 19)
        Me.rbtnExportMulitBuy.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportMulitBuy.Name = "rbtnExportMulitBuy"
        Me.rbtnExportMulitBuy.Size = New System.Drawing.Size(139, 20)
        Me.rbtnExportMulitBuy.TabIndex = 3
        Me.rbtnExportMulitBuy.TabStop = True
        Me.rbtnExportMulitBuy.Text = "Multi-Buy (Buy List)"
        Me.rbtnExportMulitBuy.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'lblItemstoBuy
        '
        Me.lblItemstoBuy.Location = New System.Drawing.Point(9, 5)
        Me.lblItemstoBuy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemstoBuy.Name = "lblItemstoBuy"
        Me.lblItemstoBuy.Size = New System.Drawing.Size(537, 19)
        Me.lblItemstoBuy.TabIndex = 71
        Me.lblItemstoBuy.Text = "Items to Buy"
        Me.lblItemstoBuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblItemstoBuild
        '
        Me.lblItemstoBuild.Location = New System.Drawing.Point(8, 402)
        Me.lblItemstoBuild.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemstoBuild.Name = "lblItemstoBuild"
        Me.lblItemstoBuild.Size = New System.Drawing.Size(397, 18)
        Me.lblItemstoBuild.TabIndex = 72
        Me.lblItemstoBuild.Text = "Items to Build"
        Me.lblItemstoBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstBuy
        '
        Me.lstBuy.ContextMenuStrip = Me.DeleteMaterialStrip
        Me.lstBuy.FullRowSelect = True
        Me.lstBuy.GridLines = True
        Me.lstBuy.HideSelection = False
        Me.lstBuy.Location = New System.Drawing.Point(9, 25)
        Me.lstBuy.Margin = New System.Windows.Forms.Padding(4)
        Me.lstBuy.Name = "lstBuy"
        Me.lstBuy.Size = New System.Drawing.Size(884, 374)
        Me.lstBuy.TabIndex = 37
        Me.lstBuy.TabStop = False
        Me.lstBuy.UseCompatibleStateImageBehavior = False
        Me.lstBuy.View = System.Windows.Forms.View.Details
        '
        'lstItems
        '
        Me.lstItems.ContextMenuStrip = Me.DeleteItemStrip
        Me.lstItems.FullRowSelect = True
        Me.lstItems.HideSelection = False
        Me.lstItems.Location = New System.Drawing.Point(8, 424)
        Me.lstItems.Margin = New System.Windows.Forms.Padding(4)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(397, 246)
        Me.lstItems.TabIndex = 38
        Me.lstItems.TabStop = False
        Me.lstItems.UseCompatibleStateImageBehavior = False
        Me.lstItems.View = System.Windows.Forms.View.Details
        '
        'frmShoppingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.Controls.Add(Me.gbExportOptions)
        Me.Controls.Add(Me.txtListEdit)
        Me.Controls.Add(Me.lblItemstoBuild)
        Me.Controls.Add(Me.lblItemstoBuy)
        Me.Controls.Add(Me.lstBuy)
        Me.Controls.Add(Me.lblAvgIPH)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.lblTotalProfit)
        Me.Controls.Add(Me.lblTotalProfit1)
        Me.Controls.Add(Me.lblAvgIPH1)
        Me.Controls.Add(Me.btnCopy)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmShoppingList"
        Me.Size = New System.Drawing.Size(978, 824)
        Me.DeleteBuildStrip.ResumeLayout(False)
        Me.DeleteItemStrip.ResumeLayout(False)
        Me.DeleteMaterialStrip.ResumeLayout(False)
        Me.gbExportOptions.ResumeLayout(False)
        Me.gbExportOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents lblTotalProfit1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalProfit As System.Windows.Forms.Label
    Friend WithEvents lblAvgIPH As System.Windows.Forms.Label
    Friend WithEvents lblAvgIPH1 As System.Windows.Forms.Label
    Friend WithEvents ttMain As System.Windows.Forms.ToolTip
    Friend WithEvents txtListEdit As System.Windows.Forms.TextBox
    Friend WithEvents DeleteItemStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteMaterialStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteMaterial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBuildStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteBuildItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lstBuy As EVE_Isk_per_Hour.MyListView
    Friend WithEvents lstItems As EVE_Isk_per_Hour.MyListView
    Friend WithEvents lblItemstoBuy As System.Windows.Forms.Label
    Friend WithEvents lblItemstoBuild As System.Windows.Forms.Label
    Friend WithEvents gbExportOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnExportMulitBuy As RadioButton
End Class
