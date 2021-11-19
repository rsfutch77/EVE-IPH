<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageAccounts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageAccounts))
        Me.lstAccounts = New System.Windows.Forms.ListView()
        Me.colCharacterID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCharacterName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCorporationName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIsDefault = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAccountScopes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAccessToken = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRefreshToken = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAccessTokenExpireDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTokenType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDeleteCharacter = New System.Windows.Forms.Button()
        Me.btnAddCharacter = New System.Windows.Forms.Button()
        Me.lstScopes = New System.Windows.Forms.ListView()
        Me.colScopes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbAccountData = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.lblRefreshToken = New System.Windows.Forms.Label()
        Me.lblAccessToken = New System.Windows.Forms.Label()
        Me.txtRefreshToken = New System.Windows.Forms.TextBox()
        Me.txtAccessTokenExpDate = New System.Windows.Forms.TextBox()
        Me.txtAccessToken = New System.Windows.Forms.TextBox()
        Me.btnRefreshToken = New System.Windows.Forms.Button()
        Me.gbAccountData.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstAccounts
        '
        Me.lstAccounts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCharacterID, Me.colCharacterName, Me.colCorporationName, Me.colIsDefault, Me.colAccountScopes, Me.colAccessToken, Me.colRefreshToken, Me.colAccessTokenExpireDate, Me.colTokenType})
        Me.lstAccounts.FullRowSelect = True
        Me.lstAccounts.GridLines = True
        Me.lstAccounts.HideSelection = False
        Me.lstAccounts.Location = New System.Drawing.Point(15, 15)
        Me.lstAccounts.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstAccounts.MultiSelect = False
        Me.lstAccounts.Name = "lstAccounts"
        Me.lstAccounts.Size = New System.Drawing.Size(742, 462)
        Me.lstAccounts.TabIndex = 3
        Me.lstAccounts.UseCompatibleStateImageBehavior = False
        Me.lstAccounts.View = System.Windows.Forms.View.Details
        '
        'colCharacterID
        '
        Me.colCharacterID.Text = "Character ID"
        Me.colCharacterID.Width = 0
        '
        'colCharacterName
        '
        Me.colCharacterName.Text = "Character Name"
        Me.colCharacterName.Width = 238
        '
        'colCorporationName
        '
        Me.colCorporationName.Text = "Corporation Name"
        Me.colCorporationName.Width = 275
        '
        'colIsDefault
        '
        Me.colIsDefault.Text = "Is Default"
        '
        'colAccountScopes
        '
        Me.colAccountScopes.Text = "Scopes"
        Me.colAccountScopes.Width = 0
        '
        'colAccessToken
        '
        Me.colAccessToken.Width = 0
        '
        'colRefreshToken
        '
        Me.colRefreshToken.Width = 0
        '
        'colAccessTokenExpireDate
        '
        Me.colAccessTokenExpireDate.Width = 0
        '
        'colTokenType
        '
        Me.colTokenType.Width = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(952, 489)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(152, 38)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDeleteCharacter
        '
        Me.btnDeleteCharacter.Enabled = False
        Me.btnDeleteCharacter.Location = New System.Drawing.Point(472, 489)
        Me.btnDeleteCharacter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDeleteCharacter.Name = "btnDeleteCharacter"
        Me.btnDeleteCharacter.Size = New System.Drawing.Size(152, 38)
        Me.btnDeleteCharacter.TabIndex = 6
        Me.btnDeleteCharacter.Text = "Delete Character"
        Me.btnDeleteCharacter.UseVisualStyleBackColor = True
        '
        'btnAddCharacter
        '
        Me.btnAddCharacter.Location = New System.Drawing.Point(312, 489)
        Me.btnAddCharacter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddCharacter.Name = "btnAddCharacter"
        Me.btnAddCharacter.Size = New System.Drawing.Size(152, 38)
        Me.btnAddCharacter.TabIndex = 7
        Me.btnAddCharacter.Text = "Add Character"
        Me.btnAddCharacter.UseVisualStyleBackColor = True
        '
        'lstScopes
        '
        Me.lstScopes.CausesValidation = False
        Me.lstScopes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colScopes})
        Me.lstScopes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstScopes.HideSelection = False
        Me.lstScopes.Location = New System.Drawing.Point(765, 15)
        Me.lstScopes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstScopes.MultiSelect = False
        Me.lstScopes.Name = "lstScopes"
        Me.lstScopes.Size = New System.Drawing.Size(644, 288)
        Me.lstScopes.TabIndex = 9
        Me.lstScopes.UseCompatibleStateImageBehavior = False
        Me.lstScopes.View = System.Windows.Forms.View.Details
        '
        'colScopes
        '
        Me.colScopes.Text = "Scopes"
        Me.colScopes.Width = 345
        '
        'gbAccountData
        '
        Me.gbAccountData.Controls.Add(Me.Label1)
        Me.gbAccountData.Controls.Add(Me.btnCopyAll)
        Me.gbAccountData.Controls.Add(Me.lblRefreshToken)
        Me.gbAccountData.Controls.Add(Me.lblAccessToken)
        Me.gbAccountData.Controls.Add(Me.txtRefreshToken)
        Me.gbAccountData.Controls.Add(Me.txtAccessTokenExpDate)
        Me.gbAccountData.Controls.Add(Me.txtAccessToken)
        Me.gbAccountData.Location = New System.Drawing.Point(765, 311)
        Me.gbAccountData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbAccountData.Name = "gbAccountData"
        Me.gbAccountData.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbAccountData.Size = New System.Drawing.Size(645, 166)
        Me.gbAccountData.TabIndex = 11
        Me.gbAccountData.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 132)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Access Token Expiration Date:"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.Location = New System.Drawing.Point(502, 129)
        Me.btnCopyAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(135, 26)
        Me.btnCopyAll.TabIndex = 12
        Me.btnCopyAll.Text = "Copy Token Data"
        Me.btnCopyAll.UseVisualStyleBackColor = True
        '
        'lblRefreshToken
        '
        Me.lblRefreshToken.AutoSize = True
        Me.lblRefreshToken.Location = New System.Drawing.Point(4, 76)
        Me.lblRefreshToken.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRefreshToken.Name = "lblRefreshToken"
        Me.lblRefreshToken.Size = New System.Drawing.Size(106, 17)
        Me.lblRefreshToken.TabIndex = 4
        Me.lblRefreshToken.Text = "Refresh Token:"
        '
        'lblAccessToken
        '
        Me.lblAccessToken.AutoSize = True
        Me.lblAccessToken.Location = New System.Drawing.Point(4, 20)
        Me.lblAccessToken.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAccessToken.Name = "lblAccessToken"
        Me.lblAccessToken.Size = New System.Drawing.Size(101, 17)
        Me.lblAccessToken.TabIndex = 3
        Me.lblAccessToken.Text = "Access Token:"
        '
        'txtRefreshToken
        '
        Me.txtRefreshToken.Location = New System.Drawing.Point(8, 96)
        Me.txtRefreshToken.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRefreshToken.Name = "txtRefreshToken"
        Me.txtRefreshToken.ReadOnly = True
        Me.txtRefreshToken.Size = New System.Drawing.Size(629, 22)
        Me.txtRefreshToken.TabIndex = 2
        '
        'txtAccessTokenExpDate
        '
        Me.txtAccessTokenExpDate.Location = New System.Drawing.Point(204, 129)
        Me.txtAccessTokenExpDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAccessTokenExpDate.Name = "txtAccessTokenExpDate"
        Me.txtAccessTokenExpDate.ReadOnly = True
        Me.txtAccessTokenExpDate.Size = New System.Drawing.Size(152, 22)
        Me.txtAccessTokenExpDate.TabIndex = 1
        '
        'txtAccessToken
        '
        Me.txtAccessToken.Location = New System.Drawing.Point(8, 42)
        Me.txtAccessToken.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAccessToken.Name = "txtAccessToken"
        Me.txtAccessToken.ReadOnly = True
        Me.txtAccessToken.Size = New System.Drawing.Size(629, 22)
        Me.txtAccessToken.TabIndex = 0
        '
        'btnRefreshToken
        '
        Me.btnRefreshToken.Location = New System.Drawing.Point(792, 489)
        Me.btnRefreshToken.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRefreshToken.Name = "btnRefreshToken"
        Me.btnRefreshToken.Size = New System.Drawing.Size(152, 38)
        Me.btnRefreshToken.TabIndex = 12
        Me.btnRefreshToken.Text = "Refresh Token Data"
        Me.btnRefreshToken.UseVisualStyleBackColor = True
        '
        'frmManageAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1418, 538)
        Me.Controls.Add(Me.btnRefreshToken)
        Me.Controls.Add(Me.gbAccountData)
        Me.Controls.Add(Me.lstScopes)
        Me.Controls.Add(Me.btnAddCharacter)
        Me.Controls.Add(Me.btnDeleteCharacter)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lstAccounts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Accounts"
        Me.gbAccountData.ResumeLayout(False)
        Me.gbAccountData.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstAccounts As System.Windows.Forms.ListView
    Friend WithEvents colCharacterName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDeleteCharacter As System.Windows.Forms.Button
    Friend WithEvents btnAddCharacter As System.Windows.Forms.Button
    Friend WithEvents colCorporationName As ColumnHeader
    Friend WithEvents lstScopes As ListView
    Friend WithEvents colScopes As ColumnHeader
    Friend WithEvents colIsDefault As ColumnHeader
    Friend WithEvents colAccountScopes As ColumnHeader
    Friend WithEvents colCharacterID As ColumnHeader
    Friend WithEvents gbAccountData As GroupBox
    Friend WithEvents txtRefreshToken As TextBox
    Friend WithEvents txtAccessTokenExpDate As TextBox
    Friend WithEvents txtAccessToken As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCopyAll As Button
    Friend WithEvents lblRefreshToken As Label
    Friend WithEvents lblAccessToken As Label
    Friend WithEvents colAccessToken As ColumnHeader
    Friend WithEvents colRefreshToken As ColumnHeader
    Friend WithEvents colAccessTokenExpireDate As ColumnHeader
    Friend WithEvents btnRefreshToken As Button
    Friend WithEvents colTokenType As ColumnHeader
End Class
