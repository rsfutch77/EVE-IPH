
Imports System.Data.SQLite

Public Class Corporation

    Public Name As String 'Corp name
    Public CorporationID As Long ' Corp ID
    Public Ticker As String
    Public FactionID As Integer
    Public AllianceID As Integer
    Public CEOID As Long
    Public CreatorID As Long
    Public HomeStationID As Integer
    Public Shares As Long
    Public MemberCount As Integer
    Public Description As String
    Public TaxRate As Double
    Public DateFounded As Date
    Public URL As String

    Private Assets As EVEAssets
    Public AssetAccess As Boolean
    Private Blueprints As EVEBlueprints
    Public BlueprintsAccess As Boolean
    Private Jobs As EVEIndustryJobs
    Public JobsAccess As Boolean

    Public Sub New()

        AssetAccess = False
        BlueprintsAccess = False
        JobsAccess = False

        Assets = New EVEAssets
        Blueprints = New EVEBlueprints
        Jobs = New EVEIndustryJobs

    End Sub

    ' Loads the dummy corporation into the dummy character
    Public Sub LoadDummyCorporationData()
        Dim SQL As String = ""

        ' Delete the dummy information if in there
        Call EVEDB.ExecuteNonQuerySQL(String.Format("DELETE FROM ESI_CORPORATION_DATA WHERE CORPORATION_ID = {0}", DummyCorporationID))

        ' Load the variables
        CorporationID = DummyCorporationID
        Name = None
        Ticker = None
        MemberCount = 1
        FactionID = 0
        AllianceID = 0
        CEOID = 0
        CreatorID = 0
        HomeStationID = 0
        Shares = 0
        TaxRate = 0
        Description = ""
        DateFounded = NoDate
        URL = ""

        SQL = "INSERT INTO ESI_CORPORATION_DATA VALUES ("
        SQL &= BuildInsertFieldString(CorporationID) & ","
        SQL &= BuildInsertFieldString(Name) & ","
        SQL &= BuildInsertFieldString(Ticker) & ","
        SQL &= BuildInsertFieldString(MemberCount) & ","
        SQL &= BuildInsertFieldString(FactionID) & ","
        SQL &= BuildInsertFieldString(AllianceID) & ","
        SQL &= BuildInsertFieldString(CEOID) & ","
        SQL &= BuildInsertFieldString(CreatorID) & ","
        SQL &= BuildInsertFieldString(HomeStationID) & ","
        SQL &= BuildInsertFieldString(Shares) & ","
        SQL &= BuildInsertFieldString(TaxRate) & ","
        SQL &= BuildInsertFieldString(Description) & ","
        SQL &= BuildInsertFieldString(NoDate) & ","
        SQL &= BuildInsertFieldString(URL) & ","
        SQL &= BuildInsertFieldString(NoExpiry) & "," ' Set this here too to stop calls to update dummy corp through ESI
        SQL &= BuildInsertFieldString(NoExpiry) & ","
        SQL &= BuildInsertFieldString(NoExpiry) & ","
        SQL &= BuildInsertFieldString(NoExpiry) & ","
        SQL &= BuildInsertFieldString(NoExpiry) & ")"

        ' Insert the dummy corp
        Call EVEDB.ExecuteNonQuerySQL(SQL)

    End Sub

    Public Function GetIndustryJobs() As EVEIndustryJobs
        Return Jobs
    End Function

    Public Function GetAssets() As EVEAssets
        Return Assets
    End Function

    Public Function GetBlueprints() As EVEBlueprints
        Return Blueprints
    End Function

End Class
