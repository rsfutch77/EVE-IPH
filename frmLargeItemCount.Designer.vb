<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLargeItemCount
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
        Me.largeItemOk = New MetroFramework.Controls.MetroButton()
        Me.largeItemCancel = New MetroFramework.Controls.MetroButton()
        Me.largeItemLabel = New MetroFramework.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'largeItemOk
        '
        Me.largeItemOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.largeItemOk.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.largeItemOk.Location = New System.Drawing.Point(31, 222)
        Me.largeItemOk.Margin = New System.Windows.Forms.Padding(4)
        Me.largeItemOk.Name = "largeItemOk"
        Me.largeItemOk.Size = New System.Drawing.Size(256, 75)
        Me.largeItemOk.TabIndex = 0
        Me.largeItemOk.Text = "Continue"
        Me.largeItemOk.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.largeItemOk.UseSelectable = True
        '
        'largeItemCancel
        '
        Me.largeItemCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.largeItemCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.largeItemCancel.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.largeItemCancel.Location = New System.Drawing.Point(295, 222)
        Me.largeItemCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.largeItemCancel.Name = "largeItemCancel"
        Me.largeItemCancel.Size = New System.Drawing.Size(254, 75)
        Me.largeItemCancel.TabIndex = 1
        Me.largeItemCancel.Text = "Cancel"
        Me.largeItemCancel.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.largeItemCancel.UseSelectable = True
        '
        'largeItemLabel
        '
        Me.largeItemLabel.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.largeItemLabel.Location = New System.Drawing.Point(30, 74)
        Me.largeItemLabel.MinimumSize = New System.Drawing.Size(0, 100)
        Me.largeItemLabel.Name = "largeItemLabel"
        Me.largeItemLabel.Size = New System.Drawing.Size(519, 135)
        Me.largeItemLabel.TabIndex = 3
        Me.largeItemLabel.Text = "You have selected a large number of blueprints. This calculation may take a few m" &
    "inutes."
        Me.largeItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.largeItemLabel.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.largeItemLabel.UseWaitCursor = True
        Me.largeItemLabel.WrapToLine = True
        '
        'frmLargeItemCount
        '
        Me.AcceptButton = Me.largeItemOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.largeItemCancel
        Me.ClientSize = New System.Drawing.Size(577, 319)
        Me.Controls.Add(Me.largeItemLabel)
        Me.Controls.Add(Me.largeItemCancel)
        Me.Controls.Add(Me.largeItemOk)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLargeItemCount"
        Me.Padding = New System.Windows.Forms.Padding(27, 74, 27, 25)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Large number of Blueprints selected"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents largeItemOk As MetroFramework.Controls.MetroButton
    Friend WithEvents largeItemCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents largeItemLabel As MetroFramework.Controls.MetroLabel
End Class
