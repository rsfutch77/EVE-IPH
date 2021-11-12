<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmJobsNearCompletion
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
        Me.makeNow = New MetroFramework.Controls.MetroButton()
        Me.justPlanning = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'makeNow
        '
        Me.makeNow.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.makeNow.Location = New System.Drawing.Point(31, 222)
        Me.makeNow.Margin = New System.Windows.Forms.Padding(4)
        Me.makeNow.Name = "makeNow"
        Me.makeNow.Size = New System.Drawing.Size(256, 75)
        Me.makeNow.TabIndex = 0
        Me.makeNow.Text = "I need to make stuff now"
        Me.makeNow.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.makeNow.UseSelectable = True
        '
        'justPlanning
        '
        Me.justPlanning.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.justPlanning.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.justPlanning.Location = New System.Drawing.Point(295, 222)
        Me.justPlanning.Margin = New System.Windows.Forms.Padding(4)
        Me.justPlanning.Name = "justPlanning"
        Me.justPlanning.Size = New System.Drawing.Size(254, 75)
        Me.justPlanning.TabIndex = 1
        Me.justPlanning.Text = "Just planning ahead"
        Me.justPlanning.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.justPlanning.UseSelectable = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.MetroLabel1.Location = New System.Drawing.Point(30, 74)
        Me.MetroLabel1.MinimumSize = New System.Drawing.Size(0, 100)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(519, 135)
        Me.MetroLabel1.TabIndex = 3
        Me.MetroLabel1.Text = "Autoshop will subtract these jobs from your maximum possible jobs if you are look" &
    "ing for things to manufacture now. If you are just planning ahead, it will not s" &
    "ubtract these jobs."
        Me.MetroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroLabel1.UseWaitCursor = True
        Me.MetroLabel1.WrapToLine = True
        '
        'frmJobsNearCompletion
        '
        Me.AcceptButton = Me.makeNow
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.justPlanning
        Me.ClientSize = New System.Drawing.Size(577, 319)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.justPlanning)
        Me.Controls.Add(Me.makeNow)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJobsNearCompletion"
        Me.Padding = New System.Windows.Forms.Padding(27, 74, 27, 25)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "You have active jobs..."
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents makeNow As MetroFramework.Controls.MetroButton
    Friend WithEvents justPlanning As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
End Class
