Imports System.Data.SQLite

Public Class frmAddCharacter

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Always check all
        ESIScopesString = ""
        Call UpdateScopesString("esi-industry.read_character_jobs.v1", True)
        Call UpdateScopesString("esi-assets.read_assets.v1", True)
        Call UpdateScopesString("esi-characters.read_blueprints.v1", True)
        Call UpdateScopesString("esi-universe.read_structures.v1", True)
        Call UpdateScopesString("esi-markets.structure_markets.v1", True)
        Call UpdateScopesString("esi-wallet.read_character_wallet.v1", True)
        Call UpdateScopesString("esi-characters.read_standings.v1", True)

    End Sub

    Private Sub btnEVESSOLogin_Click(sender As Object, e As EventArgs) Handles btnEVESSOLogin.Click
        Dim ESIConnection As New ESI
        Dim CharacterData As New SavedTokenData

        Me.Cursor = Cursors.WaitCursor
        Call EnableDisableForm(False) ' Disable until we return
        Application.DoEvents()

        ' Strip the last space
        ESIScopesString = ESIScopesString.Substring(0, Len(ESIScopesString) - 1)

        '  Set the final scopes string - always needs skills
        ESIScopesString = "esi-skills.read_skills.v1 " & ESIScopesString

        ' Set the new character data first. This will load the data in the table or update it if they choose a character already loaded
        If ESIConnection.SetCharacterData(CharacterData, "", False, True) Then

            ' Refresh the token data to get new scopes list if they added/removed
            Cursor.Current = Cursors.WaitCursor
            If SelectedCharacter.ID <> DummyCharacterID And SelectedCharacter.ID > 0 Then
                Call SelectedCharacter.RefreshTokenData()
            End If
            Cursor.Current = Cursors.Default
            If SelectedCharacter.ID <> DummyCharacterID And SelectedCharacter.ID > 0 Then
                Call SelectedCharacter.RefreshTokenData()
            End If

            ' If they loaded a character for the first time, set it from Dummy to this character as the default
            If SelectedCharacter.ID = DummyCharacterID Then
                ' See if only one other character exists in db (the one we just added)
                Dim rsCheck As SQLiteDataReader
                DBCommand = New SQLiteCommand("SELECT COUNT(*) FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " & DummyCharacterID, EVEDB.DBREf)
                rsCheck = DBCommand.ExecuteReader
                rsCheck.Read()

                If rsCheck.GetInt32(0) = 1 Then
                    ' They only have one other character in the db and the selected is dummy, so set this to the default
                    rsCheck.Close()
                    DBCommand = New SQLiteCommand("SELECT CHARACTER_NAME FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " & DummyCharacterID, EVEDB.DBREf)
                    rsCheck = DBCommand.ExecuteReader
                    rsCheck.Read()
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()
                    Call SetDefaultCharacter(rsCheck.GetString(0))
            		Cursor.Current = Cursors.Default
                    Application.DoEvents()
                End If
            Else
                MsgBox("Character successfully added to IPH", vbInformation, Application.ProductName)
            End If
        Else
            ' Didn't load, so show the re-enter info button
            If Not CancelESISSOLogin Then
                MsgBox("The Character failed to load. Please check application registration information.")
            End If
        End If

        Cursor.Current = Cursors.Default
        Call EnableDisableForm(True)
        Application.DoEvents()

        ' Close the form - users will have to select what one to set as default
        Me.Hide()

    End Sub

    Private Sub UpdateScopesString(AppendString As String, AddString As Boolean)
        If AddString Then
            ESIScopesString &= AppendString & " "
        Else
            ' Need to remove the string, parse and remove, then rebuild
            Dim Scopes As String()

            Scopes = ESIScopesString.Split(New Char() {" "c})
            ESIScopesString = "" ' Reset

            For i = 0 To Scopes.Count - 1
                If Scopes(i) <> AppendString And Trim(Scopes(i)) <> "" Then
                    ESIScopesString &= Scopes(i) & " "
                End If
            Next
        End If

    End Sub

    Private Sub EnableDisableForm(Setting As Boolean)
        btnEVESSOLogin.Enabled = False
    End Sub
End Class
