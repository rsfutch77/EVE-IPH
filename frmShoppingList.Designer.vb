<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmShoppingList
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
        Me.btnCopy = New MetroFramework.Controls.MetroButton()
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
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lstBuy = New Easy_IPH.MyListView()
        Me.lstItems = New Easy_IPH.MyListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMonthlyProfit = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DeleteBuildStrip.SuspendLayout()
        Me.DeleteItemStrip.SuspendLayout()
        Me.DeleteMaterialStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCopy
        '
        Me.btnCopy.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnCopy.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.btnCopy.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCopy.Location = New System.Drawing.Point(9, 423)
        Me.btnCopy.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(726, 61)
        Me.btnCopy.TabIndex = 0
        Me.btnCopy.Text = "Copy Buy List"
        Me.btnCopy.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.btnCopy.UseSelectable = True
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
        Me.lblTotalProfit1.Font = New System.Drawing.Font("Impact", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalProfit1.Location = New System.Drawing.Point(419, 581)
        Me.lblTotalProfit1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalProfit1.Name = "lblTotalProfit1"
        Me.lblTotalProfit1.Size = New System.Drawing.Size(213, 32)
        Me.lblTotalProfit1.TabIndex = 34
        Me.lblTotalProfit1.Text = "Approx. Total Profit:"
        Me.lblTotalProfit1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalProfit
        '
        Me.lblTotalProfit.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalProfit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalProfit.Font = New System.Drawing.Font("Impact", 20.0!)
        Me.lblTotalProfit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalProfit.Location = New System.Drawing.Point(422, 613)
        Me.lblTotalProfit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalProfit.Name = "lblTotalProfit"
        Me.lblTotalProfit.Size = New System.Drawing.Size(310, 56)
        Me.lblTotalProfit.TabIndex = 35
        Me.lblTotalProfit.Text = "250,000,000 ISK"
        Me.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAvgIPH
        '
        Me.lblAvgIPH.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAvgIPH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAvgIPH.Font = New System.Drawing.Font("Impact", 20.0!)
        Me.lblAvgIPH.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblAvgIPH.Location = New System.Drawing.Point(422, 528)
        Me.lblAvgIPH.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvgIPH.Name = "lblAvgIPH"
        Me.lblAvgIPH.Size = New System.Drawing.Size(310, 56)
        Me.lblAvgIPH.TabIndex = 33
        Me.lblAvgIPH.Text = "2,000,000 ISK"
        Me.lblAvgIPH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAvgIPH1
        '
        Me.lblAvgIPH1.AutoSize = True
        Me.lblAvgIPH1.Font = New System.Drawing.Font("Impact", 15.0!)
        Me.lblAvgIPH1.Location = New System.Drawing.Point(419, 495)
        Me.lblAvgIPH1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvgIPH1.Name = "lblAvgIPH1"
        Me.lblAvgIPH1.Size = New System.Drawing.Size(177, 32)
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
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'lstBuy
        '
        Me.lstBuy.ContextMenuStrip = Me.DeleteMaterialStrip
        Me.lstBuy.FullRowSelect = True
        Me.lstBuy.GridLines = True
        Me.lstBuy.HideSelection = False
        Me.lstBuy.Location = New System.Drawing.Point(9, 35)
        Me.lstBuy.Margin = New System.Windows.Forms.Padding(4)
        Me.lstBuy.Name = "lstBuy"
        Me.lstBuy.Size = New System.Drawing.Size(726, 380)
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
        Me.lstItems.Location = New System.Drawing.Point(8, 517)
        Me.lstItems.Margin = New System.Windows.Forms.Padding(4)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(397, 237)
        Me.lstItems.TabIndex = 38
        Me.lstItems.TabStop = False
        Me.lstItems.UseCompatibleStateImageBehavior = False
        Me.lstItems.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Impact", 15.0!)
        Me.Label1.Location = New System.Drawing.Point(419, 670)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 32)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Monthly Profit:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMonthlyProfit
        '
        Me.lblMonthlyProfit.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMonthlyProfit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMonthlyProfit.Font = New System.Drawing.Font("Impact", 20.0!)
        Me.lblMonthlyProfit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblMonthlyProfit.Location = New System.Drawing.Point(422, 699)
        Me.lblMonthlyProfit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonthlyProfit.Name = "lblMonthlyProfit"
        Me.lblMonthlyProfit.Size = New System.Drawing.Size(310, 56)
        Me.lblMonthlyProfit.TabIndex = 74
        Me.lblMonthlyProfit.Text = "1,250,000,000 ISK"
        Me.lblMonthlyProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Impact", 15.0!)
        Me.Label2.Location = New System.Drawing.Point(130, 485)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 32)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Items To Build"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Impact", 15.0!)
        Me.Label3.Location = New System.Drawing.Point(278, 1)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 32)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Items To Buy"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmShoppingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMonthlyProfit)
        Me.Controls.Add(Me.txtListEdit)
        Me.Controls.Add(Me.lstBuy)
        Me.Controls.Add(Me.lblAvgIPH)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.lblTotalProfit)
        Me.Controls.Add(Me.lblTotalProfit1)
        Me.Controls.Add(Me.lblAvgIPH1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmShoppingList"
        Me.Size = New System.Drawing.Size(750, 765)
        Me.DeleteBuildStrip.ResumeLayout(False)
        Me.DeleteItemStrip.ResumeLayout(False)
        Me.DeleteMaterialStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCopy As MetroFramework.Controls.MetroButton
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
    Friend WithEvents lstBuy As Easy_IPH.MyListView
    Friend WithEvents lstItems As Easy_IPH.MyListView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMonthlyProfit As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
