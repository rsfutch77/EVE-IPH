<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddCharacter
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddCharacter))
        Me.btnEVESSOLogin = New System.Windows.Forms.Button()
        Me.lblKeyType = New System.Windows.Forms.Label()
        Me.chkReadStructures = New System.Windows.Forms.CheckBox()
        Me.chkStructureMarkets = New System.Windows.Forms.CheckBox()
        Me.chkReadCharacterJobs = New System.Windows.Forms.CheckBox()
        Me.chkReadAssets = New System.Windows.Forms.CheckBox()
        Me.chkReadBlueprints = New System.Windows.Forms.CheckBox()
        Me.chkReadWallet = New System.Windows.Forms.CheckBox()
        Me.ttAPI = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnEVESSOLogin
        '
        Me.btnEVESSOLogin.BackgroundImage = CType(resources.GetObject("btnEVESSOLogin.BackgroundImage"), System.Drawing.Image)
        Me.btnEVESSOLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEVESSOLogin.Location = New System.Drawing.Point(188, 293)
        Me.btnEVESSOLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEVESSOLogin.Name = "btnEVESSOLogin"
        Me.btnEVESSOLogin.Size = New System.Drawing.Size(360, 57)
        Me.btnEVESSOLogin.TabIndex = 2
        Me.btnEVESSOLogin.UseVisualStyleBackColor = True
        '
        'lblKeyType
        '
        Me.lblKeyType.Location = New System.Drawing.Point(16, 11)
        Me.lblKeyType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKeyType.Name = "lblKeyType"
        Me.lblKeyType.Size = New System.Drawing.Size(703, 39)
        Me.lblKeyType.TabIndex = 13
        Me.lblKeyType.Text = "Select the scopes you wish to authorize for this Character and log into EVE to au" &
    "thorize your character for IPH. (Note: esi-skills.read_skills.v1 is required)"
        '
        'chkReadStructures
        '
        Me.chkReadStructures.AutoSize = True
        Me.chkReadStructures.Location = New System.Drawing.Point(359, 109)
        Me.chkReadStructures.Margin = New System.Windows.Forms.Padding(4)
        Me.chkReadStructures.Name = "chkReadStructures"
        Me.chkReadStructures.Size = New System.Drawing.Size(230, 21)
        Me.chkReadStructures.TabIndex = 14
        Me.chkReadStructures.Text = "esi-universe.read_structures.v1"
        Me.chkReadStructures.UseVisualStyleBackColor = True
        '
        'chkStructureMarkets
        '
        Me.chkStructureMarkets.AutoSize = True
        Me.chkStructureMarkets.Location = New System.Drawing.Point(359, 138)
        Me.chkStructureMarkets.Margin = New System.Windows.Forms.Padding(4)
        Me.chkStructureMarkets.Name = "chkStructureMarkets"
        Me.chkStructureMarkets.Size = New System.Drawing.Size(240, 21)
        Me.chkStructureMarkets.TabIndex = 15
        Me.chkStructureMarkets.Text = "esi-markets.structure_markets.v1"
        Me.chkStructureMarkets.UseVisualStyleBackColor = True
        '
        'chkReadCharacterJobs
        '
        Me.chkReadCharacterJobs.AutoSize = True
        Me.chkReadCharacterJobs.Location = New System.Drawing.Point(359, 167)
        Me.chkReadCharacterJobs.Margin = New System.Windows.Forms.Padding(4)
        Me.chkReadCharacterJobs.Name = "chkReadCharacterJobs"
        Me.chkReadCharacterJobs.Size = New System.Drawing.Size(257, 21)
        Me.chkReadCharacterJobs.TabIndex = 17
        Me.chkReadCharacterJobs.Text = "esi-industry.read_character_jobs.v1"
        Me.chkReadCharacterJobs.UseVisualStyleBackColor = True
        '
        'chkReadAssets
        '
        Me.chkReadAssets.AutoSize = True
        Me.chkReadAssets.Location = New System.Drawing.Point(359, 196)
        Me.chkReadAssets.Margin = New System.Windows.Forms.Padding(4)
        Me.chkReadAssets.Name = "chkReadAssets"
        Me.chkReadAssets.Size = New System.Drawing.Size(195, 21)
        Me.chkReadAssets.TabIndex = 19
        Me.chkReadAssets.Text = "esi-assets.read_assets.v1"
        Me.chkReadAssets.UseVisualStyleBackColor = True
        '
        'chkReadBlueprints
        '
        Me.chkReadBlueprints.AutoSize = True
        Me.chkReadBlueprints.Location = New System.Drawing.Point(359, 225)
        Me.chkReadBlueprints.Margin = New System.Windows.Forms.Padding(4)
        Me.chkReadBlueprints.Name = "chkReadBlueprints"
        Me.chkReadBlueprints.Size = New System.Drawing.Size(242, 21)
        Me.chkReadBlueprints.TabIndex = 20
        Me.chkReadBlueprints.Text = "esi-characters.read_blueprints.v1"
        Me.chkReadBlueprints.UseVisualStyleBackColor = True
        '
        'chkReadWallet
        '
        Me.chkReadWallet.AutoSize = True
        Me.chkReadWallet.Location = New System.Drawing.Point(359, 254)
        Me.chkReadWallet.Margin = New System.Windows.Forms.Padding(4)
        Me.chkReadWallet.Name = "chkReadWallet"
        Me.chkReadWallet.Size = New System.Drawing.Size(251, 21)
        Me.chkReadWallet.TabIndex = 22
        Me.chkReadWallet.Text = "esi-wallet.read_character_wallet.v1"
        Me.chkReadWallet.UseVisualStyleBackColor = True
        '
        'frmAddCharacter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 359)
        Me.Controls.Add(Me.chkReadWallet)
        Me.Controls.Add(Me.chkReadBlueprints)
        Me.Controls.Add(Me.chkReadAssets)
        Me.Controls.Add(Me.chkReadCharacterJobs)
        Me.Controls.Add(Me.chkReadStructures)
        Me.Controls.Add(Me.chkStructureMarkets)
        Me.Controls.Add(Me.lblKeyType)
        Me.Controls.Add(Me.btnEVESSOLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddCharacter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Character"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEVESSOLogin As Button
    Friend WithEvents lblKeyType As Label
    Friend WithEvents chkReadStructures As CheckBox
    Friend WithEvents chkStructureMarkets As CheckBox
    Friend WithEvents chkReadCharacterJobs As CheckBox
    Friend WithEvents chkReadAssets As CheckBox
    Friend WithEvents chkReadBlueprints As CheckBox
    Friend WithEvents ttAPI As ToolTip
    Friend WithEvents chkReadWallet As CheckBox
End Class
