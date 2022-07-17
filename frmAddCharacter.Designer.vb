<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddCharacter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddCharacter))
        Me.lblKeyType = New System.Windows.Forms.Label()
        Me.btnEVESSOLogin = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'lblKeyType
        '
        Me.lblKeyType.ForeColor = System.Drawing.Color.DarkGray
        Me.lblKeyType.Location = New System.Drawing.Point(9, 74)
        Me.lblKeyType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKeyType.Name = "lblKeyType"
        Me.lblKeyType.Size = New System.Drawing.Size(703, 113)
        Me.lblKeyType.TabIndex = 15
        Me.lblKeyType.Text = resources.GetString("lblKeyType.Text")
        '
        'btnEVESSOLogin
        '
        Me.btnEVESSOLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEVESSOLogin.BackgroundImage = CType(resources.GetObject("btnEVESSOLogin.BackgroundImage"), System.Drawing.Image)
        Me.btnEVESSOLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEVESSOLogin.Location = New System.Drawing.Point(144, 191)
        Me.btnEVESSOLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEVESSOLogin.Name = "btnEVESSOLogin"
        Me.btnEVESSOLogin.Size = New System.Drawing.Size(382, 76)
        Me.btnEVESSOLogin.TabIndex = 14
        Me.btnEVESSOLogin.UseSelectable = True
        '
        'frmAddCharacter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 279)
        Me.Controls.Add(Me.btnEVESSOLogin)
        Me.Controls.Add(Me.lblKeyType)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddCharacter"
        Me.Padding = New System.Windows.Forms.Padding(27, 74, 27, 25)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Character"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblKeyType As Label
    Friend WithEvents btnEVESSOLogin As MetroFramework.Controls.MetroButton
End Class
