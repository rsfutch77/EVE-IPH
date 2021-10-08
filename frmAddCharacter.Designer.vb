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
        Me.chkReadStandings = New System.Windows.Forms.CheckBox()
        Me.chkReadCharacterJobs = New System.Windows.Forms.CheckBox()
        Me.chkReadAgentsResearch = New System.Windows.Forms.CheckBox()
        Me.chkReadAssets = New System.Windows.Forms.CheckBox()
        Me.chkReadBlueprints = New System.Windows.Forms.CheckBox()
        Me.chkManagePlanets = New System.Windows.Forms.CheckBox()
        Me.chkReadCorporationMembership = New System.Windows.Forms.CheckBox()
        Me.chkReadCorporationJobs = New System.Windows.Forms.CheckBox()
        Me.chkReadCorporationAssets = New System.Windows.Forms.CheckBox()
        Me.chkReadCorporationBlueprints = New System.Windows.Forms.CheckBox()
        Me.gbCorp = New System.Windows.Forms.GroupBox()
        Me.gbCharacter = New System.Windows.Forms.GroupBox()
        Me.gbStructures = New System.Windows.Forms.GroupBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.ttAPI = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkReadWallet = New System.Windows.Forms.CheckBox()
        Me.gbCorp.SuspendLayout()
        Me.gbCharacter.SuspendLayout()
        Me.gbStructures.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEVESSOLogin
        '
        Me.btnEVESSOLogin.BackgroundImage = CType(resources.GetObject("btnEVESSOLogin.BackgroundImage"), System.Drawing.Image)
        Me.btnEVESSOLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEVESSOLogin.Location = New System.Drawing.Point(188, 293)
        Me.btnEVESSOLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.chkReadStructures.Location = New System.Drawing.Point(15, 23)
        Me.chkReadStructures.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadStructures.Name = "chkReadStructures"
        Me.chkReadStructures.Size = New System.Drawing.Size(230, 21)
        Me.chkReadStructures.TabIndex = 14
        Me.chkReadStructures.Text = "esi-universe.read_structures.v1"
        Me.chkReadStructures.UseVisualStyleBackColor = True
        '
        'chkStructureMarkets
        '
        Me.chkStructureMarkets.AutoSize = True
        Me.chkStructureMarkets.Location = New System.Drawing.Point(15, 52)
        Me.chkStructureMarkets.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkStructureMarkets.Name = "chkStructureMarkets"
        Me.chkStructureMarkets.Size = New System.Drawing.Size(240, 21)
        Me.chkStructureMarkets.TabIndex = 15
        Me.chkStructureMarkets.Text = "esi-markets.structure_markets.v1"
        Me.chkStructureMarkets.UseVisualStyleBackColor = True
        '
        'chkReadStandings
        '
        Me.chkReadStandings.AutoSize = True
        Me.chkReadStandings.Location = New System.Drawing.Point(15, 25)
        Me.chkReadStandings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadStandings.Name = "chkReadStandings"
        Me.chkReadStandings.Size = New System.Drawing.Size(241, 21)
        Me.chkReadStandings.TabIndex = 16
        Me.chkReadStandings.Text = "esi-characters.read_standings.v1"
        Me.chkReadStandings.UseVisualStyleBackColor = True
        '
        'chkReadCharacterJobs
        '
        Me.chkReadCharacterJobs.AutoSize = True
        Me.chkReadCharacterJobs.Location = New System.Drawing.Point(15, 81)
        Me.chkReadCharacterJobs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadCharacterJobs.Name = "chkReadCharacterJobs"
        Me.chkReadCharacterJobs.Size = New System.Drawing.Size(257, 21)
        Me.chkReadCharacterJobs.TabIndex = 17
        Me.chkReadCharacterJobs.Text = "esi-industry.read_character_jobs.v1"
        Me.chkReadCharacterJobs.UseVisualStyleBackColor = True
        '
        'chkReadAgentsResearch
        '
        Me.chkReadAgentsResearch.AutoSize = True
        Me.chkReadAgentsResearch.Location = New System.Drawing.Point(15, 53)
        Me.chkReadAgentsResearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadAgentsResearch.Name = "chkReadAgentsResearch"
        Me.chkReadAgentsResearch.Size = New System.Drawing.Size(287, 21)
        Me.chkReadAgentsResearch.TabIndex = 18
        Me.chkReadAgentsResearch.Text = "esi-characters.read_agents_research.v1"
        Me.chkReadAgentsResearch.UseVisualStyleBackColor = True
        '
        'chkReadAssets
        '
        Me.chkReadAssets.AutoSize = True
        Me.chkReadAssets.Location = New System.Drawing.Point(15, 110)
        Me.chkReadAssets.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadAssets.Name = "chkReadAssets"
        Me.chkReadAssets.Size = New System.Drawing.Size(195, 21)
        Me.chkReadAssets.TabIndex = 19
        Me.chkReadAssets.Text = "esi-assets.read_assets.v1"
        Me.chkReadAssets.UseVisualStyleBackColor = True
        '
        'chkReadBlueprints
        '
        Me.chkReadBlueprints.AutoSize = True
        Me.chkReadBlueprints.Location = New System.Drawing.Point(15, 138)
        Me.chkReadBlueprints.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadBlueprints.Name = "chkReadBlueprints"
        Me.chkReadBlueprints.Size = New System.Drawing.Size(242, 21)
        Me.chkReadBlueprints.TabIndex = 20
        Me.chkReadBlueprints.Text = "esi-characters.read_blueprints.v1"
        Me.chkReadBlueprints.UseVisualStyleBackColor = True
        '
        'chkManagePlanets
        '
        Me.chkManagePlanets.AutoSize = True
        Me.chkManagePlanets.Location = New System.Drawing.Point(15, 198)
        Me.chkManagePlanets.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkManagePlanets.Name = "chkManagePlanets"
        Me.chkManagePlanets.Size = New System.Drawing.Size(227, 21)
        Me.chkManagePlanets.TabIndex = 21
        Me.chkManagePlanets.Text = "esi-planets.manage_planets.v1"
        Me.chkManagePlanets.UseVisualStyleBackColor = True
        '
        'chkReadCorporationMembership
        '
        Me.chkReadCorporationMembership.AutoSize = True
        Me.chkReadCorporationMembership.Location = New System.Drawing.Point(15, 25)
        Me.chkReadCorporationMembership.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadCorporationMembership.Name = "chkReadCorporationMembership"
        Me.chkReadCorporationMembership.Size = New System.Drawing.Size(349, 21)
        Me.chkReadCorporationMembership.TabIndex = 22
        Me.chkReadCorporationMembership.Text = "esi-corporations.read_corporation_membership.v1"
        Me.chkReadCorporationMembership.UseVisualStyleBackColor = True
        '
        'chkReadCorporationJobs
        '
        Me.chkReadCorporationJobs.AutoSize = True
        Me.chkReadCorporationJobs.Location = New System.Drawing.Point(15, 53)
        Me.chkReadCorporationJobs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadCorporationJobs.Name = "chkReadCorporationJobs"
        Me.chkReadCorporationJobs.Size = New System.Drawing.Size(269, 21)
        Me.chkReadCorporationJobs.TabIndex = 23
        Me.chkReadCorporationJobs.Text = "esi-industry.read_corporation_jobs.v1"
        Me.chkReadCorporationJobs.UseVisualStyleBackColor = True
        '
        'chkReadCorporationAssets
        '
        Me.chkReadCorporationAssets.AutoSize = True
        Me.chkReadCorporationAssets.Location = New System.Drawing.Point(15, 81)
        Me.chkReadCorporationAssets.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadCorporationAssets.Name = "chkReadCorporationAssets"
        Me.chkReadCorporationAssets.Size = New System.Drawing.Size(275, 21)
        Me.chkReadCorporationAssets.TabIndex = 24
        Me.chkReadCorporationAssets.Text = "esi-assets.read_corporation_assets.v1"
        Me.chkReadCorporationAssets.UseVisualStyleBackColor = True
        '
        'chkReadCorporationBlueprints
        '
        Me.chkReadCorporationBlueprints.AutoSize = True
        Me.chkReadCorporationBlueprints.Location = New System.Drawing.Point(15, 110)
        Me.chkReadCorporationBlueprints.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkReadCorporationBlueprints.Name = "chkReadCorporationBlueprints"
        Me.chkReadCorporationBlueprints.Size = New System.Drawing.Size(254, 21)
        Me.chkReadCorporationBlueprints.TabIndex = 25
        Me.chkReadCorporationBlueprints.Text = "esi-corporations.read_blueprints.v1"
        Me.chkReadCorporationBlueprints.UseVisualStyleBackColor = True
        '
        'gbCorp
        '
        Me.gbCorp.Controls.Add(Me.chkReadCorporationMembership)
        Me.gbCorp.Controls.Add(Me.chkReadCorporationJobs)
        Me.gbCorp.Controls.Add(Me.chkReadCorporationAssets)
        Me.gbCorp.Controls.Add(Me.chkReadCorporationBlueprints)
        Me.gbCorp.Location = New System.Drawing.Point(344, 54)
        Me.gbCorp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCorp.Name = "gbCorp"
        Me.gbCorp.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCorp.Size = New System.Drawing.Size(375, 139)
        Me.gbCorp.TabIndex = 26
        Me.gbCorp.TabStop = False
        Me.gbCorp.Text = "Corporation"
        '
        'gbCharacter
        '
        Me.gbCharacter.Controls.Add(Me.chkReadWallet)
        Me.gbCharacter.Controls.Add(Me.chkReadCharacterJobs)
        Me.gbCharacter.Controls.Add(Me.chkReadStandings)
        Me.gbCharacter.Controls.Add(Me.chkReadAgentsResearch)
        Me.gbCharacter.Controls.Add(Me.chkManagePlanets)
        Me.gbCharacter.Controls.Add(Me.chkReadAssets)
        Me.gbCharacter.Controls.Add(Me.chkReadBlueprints)
        Me.gbCharacter.Location = New System.Drawing.Point(20, 54)
        Me.gbCharacter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCharacter.Name = "gbCharacter"
        Me.gbCharacter.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCharacter.Size = New System.Drawing.Size(316, 231)
        Me.gbCharacter.TabIndex = 27
        Me.gbCharacter.TabStop = False
        Me.gbCharacter.Text = "Character"
        '
        'gbStructures
        '
        Me.gbStructures.Controls.Add(Me.CheckBox5)
        Me.gbStructures.Controls.Add(Me.CheckBox4)
        Me.gbStructures.Controls.Add(Me.chkReadStructures)
        Me.gbStructures.Controls.Add(Me.CheckBox3)
        Me.gbStructures.Controls.Add(Me.chkStructureMarkets)
        Me.gbStructures.Controls.Add(Me.CheckBox1)
        Me.gbStructures.Controls.Add(Me.CheckBox2)
        Me.gbStructures.Location = New System.Drawing.Point(344, 201)
        Me.gbStructures.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbStructures.Name = "gbStructures"
        Me.gbStructures.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbStructures.Size = New System.Drawing.Size(375, 85)
        Me.gbStructures.TabIndex = 28
        Me.gbStructures.TabStop = False
        Me.gbStructures.Text = "Structures"
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(-309, -65)
        Me.CheckBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(257, 21)
        Me.CheckBox5.TabIndex = 17
        Me.CheckBox5.Text = "esi-industry.read_character_jobs.v1"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(-309, -122)
        Me.CheckBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(241, 21)
        Me.CheckBox4.TabIndex = 16
        Me.CheckBox4.Text = "esi-characters.read_standings.v1"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(-309, -94)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(287, 21)
        Me.CheckBox3.TabIndex = 18
        Me.CheckBox3.Text = "esi-characters.read_agents_research.v1"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(-309, -9)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(242, 21)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "esi-characters.read_blueprints.v1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(-309, -37)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(195, 21)
        Me.CheckBox2.TabIndex = 19
        Me.CheckBox2.Text = "esi-assets.read_assets.v1"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'chkReadWallet
        '
        Me.chkReadWallet.AutoSize = True
        Me.chkReadWallet.Location = New System.Drawing.Point(15, 166)
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
        Me.Controls.Add(Me.gbStructures)
        Me.Controls.Add(Me.gbCharacter)
        Me.Controls.Add(Me.gbCorp)
        Me.Controls.Add(Me.lblKeyType)
        Me.Controls.Add(Me.btnEVESSOLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddCharacter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Character"
        Me.gbCorp.ResumeLayout(False)
        Me.gbCorp.PerformLayout()
        Me.gbCharacter.ResumeLayout(False)
        Me.gbCharacter.PerformLayout()
        Me.gbStructures.ResumeLayout(False)
        Me.gbStructures.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEVESSOLogin As Button
    Friend WithEvents lblKeyType As Label
    Friend WithEvents chkReadStructures As CheckBox
    Friend WithEvents chkStructureMarkets As CheckBox
    Friend WithEvents chkReadStandings As CheckBox
    Friend WithEvents chkReadCharacterJobs As CheckBox
    Friend WithEvents chkReadAgentsResearch As CheckBox
    Friend WithEvents chkReadAssets As CheckBox
    Friend WithEvents chkReadBlueprints As CheckBox
    Friend WithEvents chkManagePlanets As CheckBox
    Friend WithEvents chkReadCorporationMembership As CheckBox
    Friend WithEvents chkReadCorporationJobs As CheckBox
    Friend WithEvents chkReadCorporationAssets As CheckBox
    Friend WithEvents chkReadCorporationBlueprints As CheckBox
    Friend WithEvents gbCorp As GroupBox
    Friend WithEvents gbCharacter As GroupBox
    Friend WithEvents gbStructures As GroupBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents ttAPI As ToolTip
    Friend WithEvents chkReadWallet As CheckBox
End Class
