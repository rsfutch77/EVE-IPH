﻿Imports System.Data.SQLite

Public Class frmManageAccounts

    Private ListColumnClicked As Integer
    Private ListColumnSortOrder As SortOrder

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListColumnClicked = 0
        ListColumnSortOrder = SortOrder.None

        If AppRegistered() Then
            btnAddCharacter.Enabled = True
            btnSelectDefaultChar.Enabled = True
        Else
            'Disable until they register
            btnAddCharacter.Enabled = False
            btnSelectDefaultChar.Enabled = False
        End If

    End Sub

    Private Sub lstAccounts_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstAccounts.ColumnClick
        Call ListViewColumnSorter(e.Column, lstAccounts, ListColumnClicked, ListColumnSortOrder)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub frmManageAccounts_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call LoadAccountGrid()
    End Sub

    Private Sub LoadAccountGrid()
        Dim rsAccounts As SQLiteDataReader
        Dim SQL As String
        Dim lstViewRow As ListViewItem
        Dim CharList As String = ""

        ' Until there is a key able to set a default to, don't enable the select default button
        btnSelectDefaultChar.Enabled = False

        Application.UseWaitCursor = True

        SQL = "SELECT CHARACTER_ID, CHARACTER_NAME, CORPORATION_NAME, IS_DEFAULT, SCOPES "
        SQL &= "FROM ESI_CHARACTER_DATA AS ECHD, ESI_CORPORATION_DATA AS ECRPD "
        SQL &= "WHERE ECHD.CORPORATION_ID = ECRPD.CORPORATION_ID "
        SQL &= "AND CHARACTER_ID <> " & CStr(DummyCharacterID)

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsAccounts = DBCommand.ExecuteReader

        lstAccounts.Items.Clear()
        lstAccounts.BeginUpdate()

        While rsAccounts.Read

            ' Insert into table
            lstViewRow = New ListViewItem(CStr(rsAccounts.GetInt32(0))) ' CHAR ID (Hidden)
            'The remaining columns are subitems  
            lstViewRow.SubItems.Add(rsAccounts.GetString(1)) ' NAME
            lstViewRow.SubItems.Add(rsAccounts.GetString(2)) ' CORP NAME

            If rsAccounts.GetInt32(3) <> 0 Then
                lstViewRow.SubItems.Add("True")
            Else
                lstViewRow.SubItems.Add("False")
            End If

            lstViewRow.SubItems.Add(rsAccounts.GetString(4)) ' SCOPES (Hidden)

            Call lstAccounts.Items.Add(lstViewRow)

            CharList = ""

        End While

        rsAccounts.Close()

        lstAccounts.EndUpdate()

        SQL = "SELECT COUNT(*) FROM ESI_CHARACTER_DATA"

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        rsAccounts = DBCommand.ExecuteReader

        rsAccounts.Read()

        ' Don't enable default setting if there aren't any new api keys
        If CInt(rsAccounts.GetValue(0)) = 0 Or Not AppRegistered() Then
            btnSelectDefaultChar.Enabled = False
        Else
            btnSelectDefaultChar.Enabled = True
        End If

        Application.UseWaitCursor = False

    End Sub

    Private Sub lstAccounts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lstAccounts.SelectedIndexChanged
        If lstAccounts.SelectedItems.Count > 0 Then
            ' Load the scopes for the character (hidden in the list of the account)
            Dim ScopeList As String = lstAccounts.SelectedItems.Item(0).SubItems(4).Text

            Call LoadScopes(ScopeList)

            btnDeleteCharacter.Enabled = True

        End If
    End Sub

    Private Sub LoadScopes(ScopeList As String)
        ' Parse it for entry
        Dim ParsedScopes As String()

        ParsedScopes = ScopeList.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        ' Clear the list
        lstScopes.Items.Clear()

        For Each Scope In ParsedScopes
            lstScopes.Items.Add(Scope)
        Next
    End Sub

    Private Sub btnDeleteKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCharacter.Click
        Dim SQL As String

        If lstAccounts.SelectedItems.Count > 0 Then
            Dim CharacterID As Integer = CInt(lstAccounts.SelectedItems.Item(0).SubItems(0).Text)

            Call EVEDB.BeginSQLiteTransaction()

            ' Delete all the information associated with this key FIX (SKILLS, STANDINGS, ASSETS, JOBS, AGENTS)
            SQL = "DELETE FROM CHARACTER_SKILLS WHERE CHARACTER_ID = " & CStr(CharacterID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM CHARACTER_STANDINGS WHERE CHARACTER_ID = " & CStr(CharacterID)

            SQL = "DELETE FROM CURRENT_RESEARCH_AGENTS WHERE CHARACTER_ID = " & CStr(CharacterID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM ASSETS WHERE ID = " & CStr(CharacterID)
            EVEDB.ExecuteNonQuerySQL(SQL)


            SQL = "DELETE FROM INDUSTRY_JOBS WHERE installerID = " & CStr(CharacterID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM OWNED_BLUEPRINTS WHERE USER_ID = " & CStr(CharacterID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            SQL = "DELETE FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = " & CStr(CharacterID)
            EVEDB.ExecuteNonQuerySQL(SQL)

            Call EVEDB.CommitSQLiteTransaction()

            ' Reload the characters - this will do the default selection, etc
            Call LoadCharacter(UserApplicationSettings.LoadAssetsonStartup, UserApplicationSettings.LoadBPsonStartup)

            MsgBox("Character Deleted", vbInformation, Application.ProductName)

        End If

        ' Reload accounts
        Call LoadAccountGrid()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCharacter.Click
        Dim fLoadAPI As New frmSetCharacterDefault
        fLoadAPI.ShowDialog()

        lstAccounts.Items.Clear()

        ' Reload accounts
        Call LoadAccountGrid()

    End Sub

    Private Sub btnSelectDefaultChar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectDefaultChar.Click
        Dim fDefault As New frmSetCharacterDefault

        fDefault.ShowDialog()

        Call LoadAccountGrid()

    End Sub

    Private Sub lstAccounts_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lstAccounts.ItemSelectionChanged
        If lstAccounts.SelectedItems.Count = 0 Then
            btnDeleteCharacter.Enabled = False
        Else
            btnDeleteCharacter.Enabled = True
        End If
    End Sub

    Private Sub btnRegisterProgram_Click(sender As Object, e As EventArgs) Handles btnRegisterProgram.Click
        Dim f1 As New frmLoadESIAuthorization
        f1.ShowDialog()
        f1.Close()

        Dim ApplicationSettings As AppRegistrationInformationSettings = AllSettings.LoadAppRegistrationInformationSettings

        ' If they registered the program, let them add characters now
        If AppRegistered() Then
            Dim f2 As New frmSetCharacterDefault
            f2.ShowDialog()
            btnSelectDefaultChar.Enabled = True
            btnAddCharacter.Enabled = True
        End If

        Call LoadAccountGrid()

    End Sub

End Class