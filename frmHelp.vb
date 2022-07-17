Imports System.Windows.Forms

Public Class frmHelp

    Private Sub btnDonate_Click(sender As Object, e As EventArgs) Handles btnDonate.Click
        Call Process.Start("http://eveiph.github.io/")
    End Sub

    Private Sub btnVisitweb_Click(sender As Object, e As EventArgs) Handles btnVisitweb.Click
        Call Process.Start("https://www.easyiph.org/")
    End Sub

    Private Sub btnReportbug_Click(sender As Object, e As EventArgs) Handles btnReportbug.Click
        Call Process.Start("https://github.com/rsfutch77/EasyIPH/issues")
    End Sub

    Private Sub btnResetAll_Click(sender As Object, e As EventArgs) Handles btnResetAll.Click
        Dim Response As MsgBoxResult

        Response = MsgBox("This will reset all data for the program including ESI Tokens, Blueprints, Assets, Industry Jobs, and Price data." & Environment.NewLine & "Are you sure you want to do this?", vbYesNo, Application.ProductName)

        If Response = vbYes Then
            Application.UseWaitCursor = True
            Application.DoEvents()

            EVEDB.ExecuteNonQuerySQL("DELETE FROM ESI_CHARACTER_DATA")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM ESI_CORPORATION_DATA")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM CHARACTER_STANDINGS")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM CHARACTER_SKILLS")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM OWNED_BLUEPRINTS")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM ITEM_PRICES_CACHE")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM ASSETS")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM INDUSTRY_JOBS")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM CURRENT_RESEARCH_AGENTS")


            EVEDB.ExecuteNonQuerySQL("UPDATE ITEM_PRICES_FACT SET PRICE = 0")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM MARKET_HISTORY")


            EVEDB.ExecuteNonQuerySQL("DELETE FROM MARKET_HISTORY_UPDATE_CACHE")

            Call EVEDB.ExecuteNonQuerySQL("DELETE FROM SAVED_FACILTIES WHERE CHARACTER_ID <> 0")

            ' Load the dummy char
            Call SelectedCharacter.LoadDummyCharacter(True)

            ' Re-load all the forms' facilities
            Call frmMain.LoadFacilities()

            ' Reset all the cache dates
            Call frmMain.ResetESIDates()

            ' Reset ESI data
            Call frmMain.ResetESIIndustrySystemIndicies()
            Call frmMain.ResetESIAdjustedMarketPrices()

            FirstLoad = True ' Temporarily just to get screen to show correctly

            Application.UseWaitCursor = False
            Application.DoEvents()

            ' Reset the tabs
            Call frmMain.ResetTabs()

            FirstLoad = False

            MsgBox("All Data Reset", vbInformation, Application.ProductName)

            Call frmMain.LoadCharacterNamesinMenu()

            ' Reset the tabs
            Call frmMain.ResetTabs()

            FirstLoad = False

        End If

    End Sub

    Private Sub chkDisableTracking_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisableTracking.CheckedChanged
        frmMain.AutoSave()
    End Sub

End Class
