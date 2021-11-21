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
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.lblTC = New System.Windows.Forms.Label()
        Me.lblTV = New System.Windows.Forms.Label()
        Me.lblTotalVolume = New System.Windows.Forms.Label()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.DeleteBuildStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteBuildItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteItemStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTotalProfit1 = New System.Windows.Forms.Label()
        Me.lblTotalProfit = New System.Windows.Forms.Label()
        Me.lblAvgIPH = New System.Windows.Forms.Label()
        Me.lblAvgIPH1 = New System.Windows.Forms.Label()
        Me.lblTotalBuiltVolume = New System.Windows.Forms.Label()
        Me.lblTotalBuiltVolume1 = New System.Windows.Forms.Label()
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkUpdateAssetsWhenUsed = New System.Windows.Forms.CheckBox()
        Me.txtListEdit = New System.Windows.Forms.TextBox()
        Me.DeleteMaterialStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMaterial = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbOptions = New System.Windows.Forms.GroupBox()
        Me.lblFeeRate = New System.Windows.Forms.Label()
        Me.chkBuyorBuyOrder = New System.Windows.Forms.CheckBox()
        Me.txtBrokerFeeRate = New MetroFramework.Controls.MetroTextBox()
        Me.lblUsage = New System.Windows.Forms.Label()
        Me.chkUsage = New System.Windows.Forms.CheckBox()
        Me.lblFees = New System.Windows.Forms.Label()
        Me.gbExportOptions = New System.Windows.Forms.GroupBox()
        Me.rbtnExportMulitBuy = New System.Windows.Forms.RadioButton()
        Me.rbtnExportDefault = New System.Windows.Forms.RadioButton()
        Me.txtAddlCosts = New System.Windows.Forms.TextBox()
        Me.chkFees = New System.Windows.Forms.CheckBox()
        Me.lblAddlCosts = New System.Windows.Forms.Label()
        Me.chkRebuildItemsfromList = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblItemstoBuy = New System.Windows.Forms.Label()
        Me.lblItemstoBuild = New System.Windows.Forms.Label()
        Me.lstBuy = New EVE_Isk_per_Hour.MyListView()
        Me.lstItems = New EVE_Isk_per_Hour.MyListView()
        Me.DeleteBuildStrip.SuspendLayout()
        Me.DeleteItemStrip.SuspendLayout()
        Me.DeleteMaterialStrip.SuspendLayout()
        Me.gbOptions.SuspendLayout()
        Me.gbExportOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTotalCost
        '
        Me.lblTotalCost.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCost.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalCost.Location = New System.Drawing.Point(1156, 684)
        Me.lblTotalCost.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(204, 20)
        Me.lblTotalCost.TabIndex = 23
        Me.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTC
        '
        Me.lblTC.AutoSize = True
        Me.lblTC.Location = New System.Drawing.Point(1082, 686)
        Me.lblTC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTC.Name = "lblTC"
        Me.lblTC.Size = New System.Drawing.Size(76, 17)
        Me.lblTC.TabIndex = 22
        Me.lblTC.Text = "Total Cost:"
        Me.lblTC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTV
        '
        Me.lblTV.AutoSize = True
        Me.lblTV.Location = New System.Drawing.Point(1065, 758)
        Me.lblTV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTV.Name = "lblTV"
        Me.lblTV.Size = New System.Drawing.Size(95, 17)
        Me.lblTV.TabIndex = 28
        Me.lblTV.Text = "Total Volume:"
        Me.lblTV.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalVolume
        '
        Me.lblTotalVolume.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalVolume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalVolume.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalVolume.Location = New System.Drawing.Point(1156, 755)
        Me.lblTotalVolume.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalVolume.Name = "lblTotalVolume"
        Me.lblTotalVolume.Size = New System.Drawing.Size(204, 20)
        Me.lblTotalVolume.TabIndex = 29
        Me.lblTotalVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.lblTotalProfit1.Location = New System.Drawing.Point(1030, 829)
        Me.lblTotalProfit1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalProfit1.Name = "lblTotalProfit1"
        Me.lblTotalProfit1.Size = New System.Drawing.Size(133, 17)
        Me.lblTotalProfit1.TabIndex = 34
        Me.lblTotalProfit1.Text = "Approx. Total Profit:"
        Me.lblTotalProfit1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalProfit
        '
        Me.lblTotalProfit.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalProfit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalProfit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalProfit.Location = New System.Drawing.Point(1156, 826)
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
        Me.lblAvgIPH.Location = New System.Drawing.Point(1156, 802)
        Me.lblAvgIPH.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvgIPH.Name = "lblAvgIPH"
        Me.lblAvgIPH.Size = New System.Drawing.Size(204, 20)
        Me.lblAvgIPH.TabIndex = 33
        Me.lblAvgIPH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAvgIPH1
        '
        Me.lblAvgIPH1.AutoSize = True
        Me.lblAvgIPH1.Location = New System.Drawing.Point(1040, 805)
        Me.lblAvgIPH1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvgIPH1.Name = "lblAvgIPH1"
        Me.lblAvgIPH1.Size = New System.Drawing.Size(118, 17)
        Me.lblAvgIPH1.TabIndex = 32
        Me.lblAvgIPH1.Text = "Approx. Avg. IPH:"
        Me.lblAvgIPH1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalBuiltVolume
        '
        Me.lblTotalBuiltVolume.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalBuiltVolume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalBuiltVolume.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalBuiltVolume.Location = New System.Drawing.Point(1156, 779)
        Me.lblTotalBuiltVolume.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalBuiltVolume.Name = "lblTotalBuiltVolume"
        Me.lblTotalBuiltVolume.Size = New System.Drawing.Size(204, 20)
        Me.lblTotalBuiltVolume.TabIndex = 31
        Me.lblTotalBuiltVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalBuiltVolume1
        '
        Me.lblTotalBuiltVolume1.AutoSize = True
        Me.lblTotalBuiltVolume1.Location = New System.Drawing.Point(994, 781)
        Me.lblTotalBuiltVolume1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalBuiltVolume1.Name = "lblTotalBuiltVolume1"
        Me.lblTotalBuiltVolume1.Size = New System.Drawing.Size(173, 17)
        Me.lblTotalBuiltVolume1.TabIndex = 30
        Me.lblTotalBuiltVolume1.Text = "Total Built Item(s) Volume:"
        Me.lblTotalBuiltVolume1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ttMain
        '
        Me.ttMain.IsBalloon = True
        '
        'chkUpdateAssetsWhenUsed
        '
        Me.chkUpdateAssetsWhenUsed.AutoSize = True
        Me.chkUpdateAssetsWhenUsed.Checked = True
        Me.chkUpdateAssetsWhenUsed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdateAssetsWhenUsed.Location = New System.Drawing.Point(8, 124)
        Me.chkUpdateAssetsWhenUsed.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUpdateAssetsWhenUsed.Name = "chkUpdateAssetsWhenUsed"
        Me.chkUpdateAssetsWhenUsed.Size = New System.Drawing.Size(200, 21)
        Me.chkUpdateAssetsWhenUsed.TabIndex = 10
        Me.chkUpdateAssetsWhenUsed.Text = "Update Assets When Used"
        Me.chkUpdateAssetsWhenUsed.UseVisualStyleBackColor = True
        '
        'txtListEdit
        '
        Me.txtListEdit.Location = New System.Drawing.Point(1008, -1)
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
        'gbOptions
        '
        Me.gbOptions.Controls.Add(Me.lblFeeRate)
        Me.gbOptions.Controls.Add(Me.chkBuyorBuyOrder)
        Me.gbOptions.Controls.Add(Me.txtBrokerFeeRate)
        Me.gbOptions.Controls.Add(Me.lblUsage)
        Me.gbOptions.Controls.Add(Me.chkUsage)
        Me.gbOptions.Controls.Add(Me.lblFees)
        Me.gbOptions.Controls.Add(Me.gbExportOptions)
        Me.gbOptions.Controls.Add(Me.txtAddlCosts)
        Me.gbOptions.Controls.Add(Me.chkFees)
        Me.gbOptions.Controls.Add(Me.chkUpdateAssetsWhenUsed)
        Me.gbOptions.Controls.Add(Me.lblAddlCosts)
        Me.gbOptions.Location = New System.Drawing.Point(268, 672)
        Me.gbOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.gbOptions.Name = "gbOptions"
        Me.gbOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.gbOptions.Size = New System.Drawing.Size(401, 176)
        Me.gbOptions.TabIndex = 8
        Me.gbOptions.TabStop = False
        Me.gbOptions.Text = "Options:"
        '
        'lblFeeRate
        '
        Me.lblFeeRate.AutoSize = True
        Me.lblFeeRate.Location = New System.Drawing.Point(236, 21)
        Me.lblFeeRate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFeeRate.Name = "lblFeeRate"
        Me.lblFeeRate.Size = New System.Drawing.Size(70, 17)
        Me.lblFeeRate.TabIndex = 80
        Me.lblFeeRate.Text = "Fee Rate:"
        Me.lblFeeRate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkBuyorBuyOrder
        '
        Me.chkBuyorBuyOrder.AutoSize = True
        Me.chkBuyorBuyOrder.Checked = True
        Me.chkBuyorBuyOrder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBuyorBuyOrder.Location = New System.Drawing.Point(8, 44)
        Me.chkBuyorBuyOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBuyorBuyOrder.Name = "chkBuyorBuyOrder"
        Me.chkBuyorBuyOrder.Size = New System.Drawing.Size(240, 21)
        Me.chkBuyorBuyOrder.TabIndex = 13
        Me.chkBuyorBuyOrder.Text = "Calculate Buy Order / Buy Market"
        Me.chkBuyorBuyOrder.ThreeState = True
        Me.chkBuyorBuyOrder.UseVisualStyleBackColor = True
        '
        'txtBrokerFeeRate
        '
        '
        '
        '
        Me.txtBrokerFeeRate.CustomButton.Image = Nothing
        Me.txtBrokerFeeRate.CustomButton.Location = New System.Drawing.Point(36, 1)
        Me.txtBrokerFeeRate.CustomButton.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBrokerFeeRate.CustomButton.Name = ""
        Me.txtBrokerFeeRate.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.txtBrokerFeeRate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtBrokerFeeRate.CustomButton.TabIndex = 1
        Me.txtBrokerFeeRate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtBrokerFeeRate.CustomButton.UseSelectable = True
        Me.txtBrokerFeeRate.CustomButton.Visible = False
        Me.txtBrokerFeeRate.Lines = New String(-1) {}
        Me.txtBrokerFeeRate.Location = New System.Drawing.Point(311, 16)
        Me.txtBrokerFeeRate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBrokerFeeRate.MaxLength = 32767
        Me.txtBrokerFeeRate.Name = "txtBrokerFeeRate"
        Me.txtBrokerFeeRate.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBrokerFeeRate.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtBrokerFeeRate.SelectedText = ""
        Me.txtBrokerFeeRate.SelectionLength = 0
        Me.txtBrokerFeeRate.SelectionStart = 0
        Me.txtBrokerFeeRate.ShortcutsEnabled = True
        Me.txtBrokerFeeRate.Size = New System.Drawing.Size(60, 25)
        Me.txtBrokerFeeRate.TabIndex = 79
        Me.txtBrokerFeeRate.TabStop = False
        Me.txtBrokerFeeRate.UseSelectable = True
        Me.txtBrokerFeeRate.Visible = False
        Me.txtBrokerFeeRate.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtBrokerFeeRate.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'lblUsage
        '
        Me.lblUsage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUsage.Location = New System.Drawing.Point(79, 69)
        Me.lblUsage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsage.Name = "lblUsage"
        Me.lblUsage.Size = New System.Drawing.Size(140, 21)
        Me.lblUsage.TabIndex = 15
        Me.lblUsage.Text = "0.00"
        Me.lblUsage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkUsage
        '
        Me.chkUsage.AutoSize = True
        Me.chkUsage.Checked = True
        Me.chkUsage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUsage.Location = New System.Drawing.Point(8, 69)
        Me.chkUsage.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUsage.Name = "chkUsage"
        Me.chkUsage.Size = New System.Drawing.Size(75, 21)
        Me.chkUsage.TabIndex = 14
        Me.chkUsage.Text = "Usage:"
        Me.chkUsage.UseVisualStyleBackColor = True
        '
        'lblFees
        '
        Me.lblFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFees.Location = New System.Drawing.Point(78, 19)
        Me.lblFees.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFees.Name = "lblFees"
        Me.lblFees.Size = New System.Drawing.Size(141, 21)
        Me.lblFees.TabIndex = 12
        Me.lblFees.Text = "0.00"
        Me.lblFees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbExportOptions
        '
        Me.gbExportOptions.Controls.Add(Me.rbtnExportMulitBuy)
        Me.gbExportOptions.Controls.Add(Me.rbtnExportDefault)
        Me.gbExportOptions.Location = New System.Drawing.Point(240, 62)
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
        Me.rbtnExportMulitBuy.Location = New System.Drawing.Point(10, 19)
        Me.rbtnExportMulitBuy.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportMulitBuy.Name = "rbtnExportMulitBuy"
        Me.rbtnExportMulitBuy.Size = New System.Drawing.Size(151, 21)
        Me.rbtnExportMulitBuy.TabIndex = 3
        Me.rbtnExportMulitBuy.TabStop = True
        Me.rbtnExportMulitBuy.Text = "Multi-Buy (Buy List)"
        Me.rbtnExportMulitBuy.UseVisualStyleBackColor = True
        '
        'rbtnExportDefault
        '
        Me.rbtnExportDefault.AutoSize = True
        Me.rbtnExportDefault.Location = New System.Drawing.Point(10, 40)
        Me.rbtnExportDefault.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnExportDefault.Name = "rbtnExportDefault"
        Me.rbtnExportDefault.Size = New System.Drawing.Size(74, 21)
        Me.rbtnExportDefault.TabIndex = 0
        Me.rbtnExportDefault.TabStop = True
        Me.rbtnExportDefault.Text = "Default"
        Me.rbtnExportDefault.UseVisualStyleBackColor = True
        '
        'txtAddlCosts
        '
        Me.txtAddlCosts.Location = New System.Drawing.Point(79, 94)
        Me.txtAddlCosts.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddlCosts.MaxLength = 15
        Me.txtAddlCosts.Name = "txtAddlCosts"
        Me.txtAddlCosts.Size = New System.Drawing.Size(139, 22)
        Me.txtAddlCosts.TabIndex = 17
        Me.txtAddlCosts.Text = "0.00"
        Me.txtAddlCosts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkFees
        '
        Me.chkFees.AutoSize = True
        Me.chkFees.Checked = True
        Me.chkFees.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFees.Location = New System.Drawing.Point(8, 19)
        Me.chkFees.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFees.Name = "chkFees"
        Me.chkFees.Size = New System.Drawing.Size(65, 21)
        Me.chkFees.TabIndex = 11
        Me.chkFees.Text = "Fees:"
        Me.chkFees.ThreeState = True
        Me.chkFees.UseVisualStyleBackColor = True
        '
        'lblAddlCosts
        '
        Me.lblAddlCosts.AutoSize = True
        Me.lblAddlCosts.Location = New System.Drawing.Point(5, 99)
        Me.lblAddlCosts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAddlCosts.Name = "lblAddlCosts"
        Me.lblAddlCosts.Size = New System.Drawing.Size(82, 17)
        Me.lblAddlCosts.TabIndex = 16
        Me.lblAddlCosts.Text = "Add'l Costs:"
        '
        'chkRebuildItemsfromList
        '
        Me.chkRebuildItemsfromList.AutoSize = True
        Me.chkRebuildItemsfromList.Location = New System.Drawing.Point(702, 802)
        Me.chkRebuildItemsfromList.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRebuildItemsfromList.Name = "chkRebuildItemsfromList"
        Me.chkRebuildItemsfromList.Size = New System.Drawing.Size(233, 21)
        Me.chkRebuildItemsfromList.TabIndex = 79
        Me.chkRebuildItemsfromList.Text = "Rebuild Items when Loading List"
        Me.chkRebuildItemsfromList.UseVisualStyleBackColor = True
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
        Me.lblItemstoBuy.Size = New System.Drawing.Size(1351, 16)
        Me.lblItemstoBuy.TabIndex = 71
        Me.lblItemstoBuy.Text = "Items to Buy"
        Me.lblItemstoBuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblItemstoBuild
        '
        Me.lblItemstoBuild.Location = New System.Drawing.Point(8, 402)
        Me.lblItemstoBuild.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemstoBuild.Name = "lblItemstoBuild"
        Me.lblItemstoBuild.Size = New System.Drawing.Size(885, 18)
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
        Me.lstBuy.Size = New System.Drawing.Size(1350, 374)
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
        Me.lstItems.Size = New System.Drawing.Size(888, 246)
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
        Me.ClientSize = New System.Drawing.Size(1368, 852)
        Me.Controls.Add(Me.chkRebuildItemsfromList)
        Me.Controls.Add(Me.txtListEdit)
        Me.Controls.Add(Me.lblItemstoBuild)
        Me.Controls.Add(Me.lblItemstoBuy)
        Me.Controls.Add(Me.lstBuy)
        Me.Controls.Add(Me.lblTV)
        Me.Controls.Add(Me.lblTotalCost)
        Me.Controls.Add(Me.gbOptions)
        Me.Controls.Add(Me.lblTotalVolume)
        Me.Controls.Add(Me.lblTotalBuiltVolume)
        Me.Controls.Add(Me.lblTotalBuiltVolume1)
        Me.Controls.Add(Me.lblAvgIPH)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.lblTC)
        Me.Controls.Add(Me.lblTotalProfit)
        Me.Controls.Add(Me.lblTotalProfit1)
        Me.Controls.Add(Me.lblAvgIPH1)
        Me.Controls.Add(Me.btnCopy)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmShoppingList"
        Me.DeleteBuildStrip.ResumeLayout(False)
        Me.DeleteItemStrip.ResumeLayout(False)
        Me.DeleteMaterialStrip.ResumeLayout(False)
        Me.gbOptions.ResumeLayout(False)
        Me.gbOptions.PerformLayout()
        Me.gbExportOptions.ResumeLayout(False)
        Me.gbExportOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents lblTC As System.Windows.Forms.Label
    Friend WithEvents lblTV As System.Windows.Forms.Label
    Friend WithEvents lblTotalVolume As System.Windows.Forms.Label
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents lblTotalProfit1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalProfit As System.Windows.Forms.Label
    Friend WithEvents lblAvgIPH As System.Windows.Forms.Label
    Friend WithEvents lblAvgIPH1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalBuiltVolume As System.Windows.Forms.Label
    Friend WithEvents lblTotalBuiltVolume1 As System.Windows.Forms.Label
    Friend WithEvents ttMain As System.Windows.Forms.ToolTip
    Friend WithEvents chkUpdateAssetsWhenUsed As System.Windows.Forms.CheckBox
    Friend WithEvents txtListEdit As System.Windows.Forms.TextBox
    Friend WithEvents DeleteItemStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteMaterialStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteMaterial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkFees As System.Windows.Forms.CheckBox
    Friend WithEvents lblFees As System.Windows.Forms.Label
    Friend WithEvents DeleteBuildStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteBuildItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtAddlCosts As System.Windows.Forms.TextBox
    Friend WithEvents lstBuy As EVE_Isk_per_Hour.MyListView
    Friend WithEvents lstItems As EVE_Isk_per_Hour.MyListView
    Friend WithEvents lblItemstoBuy As System.Windows.Forms.Label
    Friend WithEvents lblItemstoBuild As System.Windows.Forms.Label
    Friend WithEvents lblAddlCosts As System.Windows.Forms.Label
    Friend WithEvents lblUsage As System.Windows.Forms.Label
    Friend WithEvents chkUsage As System.Windows.Forms.CheckBox
    Friend WithEvents chkBuyorBuyOrder As System.Windows.Forms.CheckBox
    Friend WithEvents gbExportOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnExportDefault As System.Windows.Forms.RadioButton
    Friend WithEvents chkRebuildItemsfromList As CheckBox
    Friend WithEvents rbtnExportMulitBuy As RadioButton
    Friend WithEvents txtBrokerFeeRate As MetroFramework.Controls.MetroTextBox
    Friend WithEvents lblFeeRate As Label
End Class
