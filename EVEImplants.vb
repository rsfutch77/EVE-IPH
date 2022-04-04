
Imports System.Data.SQLite

Public Class EVEImplants

    Private Implants As List(Of Implant)
    Private IDtoFind As Long

    Public Class Implant
        Public Implant As Double
    End Class

    Public Sub New()
        Implants = New List(Of Implant)
    End Sub

    ' Returns the Implant of a sent NPC ID
    Public Function GetImplant(ByVal ImplantID As Long) As Double
        'TODO #7: Implant detection crashes
        ' Find the Industry Skill level
        'If Implants.Count <> 0 Then
        '    For i = 0 To Implants.Count - 1
        '        If Implants(i).ImplantID = ImplantID Then
        '            Return Implants(i).Implant
        '            Exit Function
        '        End If
        '    Next
        'End If

        ' Got this far we didn't find it in the list
        Return 0

    End Function

    ' Returns the list of Implants
    Public Function GetImplantsList() As List(Of Implant)
        Return Implants
    End Function

    ' Returns the number of standings in the list
    Public Function NumImplants() As Integer
        If Implants.Count <> 0 Then
            Return Implants.Count
        Else
            Return 0
        End If
    End Function

    ' Inserts Implant with each value
    Public Sub InsertImplant(ByVal sentImplantID As Long, ByVal sentNPCType As String, ByVal sentNPCName As String, ByVal sentImplant As Double)
        Dim TempImplant As New Implant

        TempImplant.Implant = sentImplant
        'TODO #7: Implant detection crashes
        'Call InsertImplant(TempImplant)

    End Sub

    ' Predicate for finding the Implant
    Private Function FindImplant(ByVal SImplant As Implant) As Boolean
        'TODO #7: Implant detection crashes
        'If SImplant.ImplantID = ImplantToFind.ImplantID And SImplant.NPCType = ImplantToFind.NPCType And SImplant.NPCName = ImplantToFind.NPCName Then
        '    Return True
        'Else
        '    Return False
        'End If

    End Function

    ' Updates and Loads the character's Implants from DB
    Public Sub LoadCharacterImplants(ByVal CharacterID As Long, ByVal CharacterTokenData As SavedTokenData)
        Dim SQL As String
        Dim readerImplants As SQLiteDataReader
        Dim TempImplants As New EVEImplants

        ' Don't try to update/load dummy Implants
        If CharacterID = 0 Then
            Exit Sub
        End If

        'First update the Implants
        Call UpdateCharacterImplants(CharacterID, CharacterTokenData)

        ' Load the Implants
        SQL = "SELECT IMPLANT FROM CHARACTER_IMPLANTS WHERE CHARACTER_ID = " & CharacterID

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerImplants = DBCommand.ExecuteReader

        While readerImplants.Read
            ' Insert Implant
            InsertImplant(readerImplants.GetInt64(0), readerImplants.GetString(1), readerImplants.GetString(2), readerImplants.GetDouble(3))
        End While

        readerImplants.Close()
        DBCommand = Nothing
        readerImplants = Nothing

    End Sub

    ' Updates the Character Implants from ESI for the sent character and inserts them into the Database for later queries
    Private Sub UpdateCharacterImplants(ByVal ID As Long, ByVal CharacterTokenData As SavedTokenData)
        Dim SQL As String
        Dim i As Integer
        Dim TempImplants As EVEImplants = Nothing
        Dim NonFactionIDs As New List(Of Long)
        Dim ReturnNameData As New List(Of ESINameData)
        Dim ReturnFactionData As New List(Of ESIFactionData)
        Dim TempImplant As Implant

        Dim ESIData As New ESI
        Dim CB As New CacheBox
        Dim CacheDate As Date

        ' Get updated Implants
        If CB.DataUpdateable(CacheDateType.Implants, ID) Then
            TempImplants = ESIData.GetCharacterImplants(ID, CharacterTokenData, CacheDate)

            If Not IsNothing(TempImplants) Then

                Call EVEDB.BeginSQLiteTransaction()

                ' Delete the old Implants data
                SQL = "DELETE FROM CHARACTER_IMPLANTS WHERE CHARACTER_ID = " & ID
                Call EVEDB.ExecuteNonQuerySQL(SQL)

                ' Insert new Implants data
                For i = 0 To TempImplants.NumImplants - 1
                    'TODO #7: Implant detection crashes
                    'SQL = "INSERT INTO CHARACTER_IMPLANTS (CHARACTER_ID, IMPLANT) "
                    'SQL = SQL & " VALUES (" & ID & "," & TempImplants.GetImplantsList(i).ImplantID
                    'SQL = SQL & "'," & TempImplants.GetImplantsList(i).Implant & ")"
                    'Call EVEDB.ExecuteNonQuerySQL(SQL)
                Next

                DBCommand = Nothing

                Call EVEDB.CommitSQLiteTransaction()

            End If
            ' Update cache date now that it's all set
            Call CB.UpdateCacheDate(CacheDateType.Implants, CacheDate, ID)
        End If
        'End If
    End Sub

End Class

