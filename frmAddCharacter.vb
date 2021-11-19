
Public Class frmAddCharacter

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Always check all
        ESIScopesString = ""
        chkReadAssets.Checked = True
        chkReadWallet.Checked = True
        chkReadBlueprints.Checked = True
        chkReadCharacterJobs.Checked = True
        chkReadStructures.Checked = True
        chkStructureMarkets.Checked = True
        'chkManagePlanets.Checked = True

        ' Set the tool tips for api
        With ttAPI
            .SetToolTip(chkReadAssets, "Reads a list of the character's assets")
            .SetToolTip(chkReadWallet, "Reads the total value of the character's wallet")
            .SetToolTip(chkReadBlueprints, "Reads a list of blueprints the character owns")
            .SetToolTip(chkReadCharacterJobs, "Reads a list of the character's industry jobs")

            .SetToolTip(chkReadStructures, "Reads information about specific structures")
            .SetToolTip(chkStructureMarkets, "Reads market orders from a specific structure")

        End With

    End Sub

    Private Sub btnEVESSOLogin_Click(sender As Object, e As EventArgs) Handles btnEVESSOLogin.Click
        Dim ESIConnection As New ESI

        btnEVESSOLogin.Enabled = False ' Disable until we return

        ' Strip the last space
        ESIScopesString = ESIScopesString.Substring(0, Len(ESIScopesString) - 1)

        '  Set the final scopes string - always needs skills
        ESIScopesString = "esi-skills.read_skills.v1 " & ESIScopesString

        ' Set the new character data first. This will load the data in the table or update it if they choose a character already loaded
        If ESIConnection.SetCharacterData() Then

            ' Refresh the token data to get new scopes list if they added/removed
            Cursor.Current = Cursors.WaitCursor
            If SelectedCharacter.ID <> DummyCharacterID And SelectedCharacter.ID > 0 Then
                Call SelectedCharacter.RefreshTokenData()
            End If
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        Else
            ' Didn't load, so show the re-enter info button
            If Not CancelESISSOLogin Then
                MsgBox("The Character failed to load. Please check application registration information.")
            End If
        End If

        btnEVESSOLogin.Enabled = True ' Enable for another try if they want

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

    Private Sub chkReadCharacterJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadCharacterJobs.CheckedChanged
        With chkReadCharacterJobs
            Call UpdateScopesString(.Text, .Checked)
        End With
    End Sub

    Private Sub chkReadAssets_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadAssets.CheckedChanged
        With chkReadAssets
            Call UpdateScopesString(.Text, .Checked)
        End With
    End Sub

    Private Sub chkReadBlueprints_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadBlueprints.CheckedChanged
        With chkReadBlueprints
            Call UpdateScopesString(.Text, .Checked)
        End With
    End Sub

    Private Sub chkReadStructures_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadStructures.CheckedChanged
        With chkReadStructures
            Call UpdateScopesString(.Text, .Checked)
        End With
    End Sub

    Private Sub chkStructureMarkets_CheckedChanged(sender As Object, e As EventArgs) Handles chkStructureMarkets.CheckedChanged
        With chkStructureMarkets
            Call UpdateScopesString(.Text, .Checked)
        End With
    End Sub

    Private Sub chkReadWallet_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadWallet.CheckedChanged
        With chkReadWallet
            Call UpdateScopesString(.Text, .Checked)
        End With
    End Sub
End Class