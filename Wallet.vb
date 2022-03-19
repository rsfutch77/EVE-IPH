
Imports System.Data.SQLite

Public Class EVEWallet

    Public Wallet As Double

    Public Sub New()

        Wallet = New Double

    End Sub

    ' Loads all the Industry Assets from the DB for the ID sent - I'm not using this locally so don't load anything
    Public Sub LoadWallet(ByVal ID As Long, ByVal TokenData As SavedTokenData)

        Dim SQL As String
        Dim readerWallet As SQLiteDataReader
        Dim TempWallet As Double

        ' Update Industry jobs first
        TempWallet = UpdateWallet(ID, TokenData)

        ' See what ID we use
        Dim CharID As Long = 0
        If UserApplicationSettings.LoadBPsbyChar Then
            ' Use the ID sent
            CharID = SelectedCharacter.ID
        Else
            CharID = CommonLoadBPsID
        End If

        ' Load
        SQL = "SELECT WALLET "
        SQL = SQL & "FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = " & CharID

        DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
        readerWallet = DBCommand.ExecuteReader

        While readerWallet.Read
            TempWallet = readerWallet.GetDouble(0)
        End While

        readerWallet.Close()
        DBCommand = Nothing
        readerWallet = Nothing

        Wallet = TempWallet

    End Sub

    'Get's ESI wallet data this character and returns it
    Private Function UpdateWallet(ByVal ID As Long, ByVal CharacterTokenData As SavedTokenData) As Double
        Dim TempWallet As Double
        Dim ESIData As New ESI
        Dim CB As New CacheBox
        Dim SQL As String

        Dim CacheDate As Date
        Dim CDType As CacheDateType = CacheDateType.Wallet

        ' Look up the assets cache date first      
        If CB.DataUpdateable(CDType, ID) Then
            TempWallet = ESIData.GetCharacterWallet(ID, CharacterTokenData, CacheDate)

            SQL = "UPDATE ESI_CHARACTER_DATA SET WALLET = {0} WHERE CHARACTER_ID = {1}"
            Call EVEDB.ExecuteNonQuerySQL(String.Format(SQL, CStr(TempWallet), CStr(CharacterTokenData.CharacterID)))

            ' Update cache date since it's all set now
            Call CB.UpdateCacheDate(CDType, CacheDate, ID)
        End If

        Return Wallet

    End Function

End Class