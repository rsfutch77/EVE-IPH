Imports System.Data.SQLite

Public Class frmSettings

    Private SSLoaded As Boolean
    Private RegionLoaded As Boolean
    Private FirstLoad As Boolean
    Private SelectedReset As Boolean
    Private SVRComboLoaded As Boolean

    Private ReloadSkills As Boolean

    Private Defaults As New ProgramSettings ' For default constants

#Region "Click object Functions"


    Private Sub AutoSave()
        Dim TempSettings As ApplicationSettings = Nothing

        With TempSettings

            .DisableGATracking = chkDisableTracking.Checked

        End With

        ' Save the data in the XML file
        'SaveApplicationSettings(TempSettings)

        ' Save the data to the local variable
        UserApplicationSettings = TempSettings

    End Sub

    Private Sub txtBrokerFactionStandings_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBrokerCorpStandings_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chkBuildBuyDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AutoSave()
    End Sub

    Private Sub rbtnExportDefault_CheckedChanged(sender As System.Object, e As System.EventArgs)
        AutoSave()
    End Sub

    Private Sub rbtnExportCSV_CheckedChanged(sender As System.Object, e As System.EventArgs)
        AutoSave()
    End Sub

    Private Sub rbtnExportSSV_CheckedChanged(sender As System.Object, e As System.EventArgs)
        AutoSave()
    End Sub

    Private Sub txtDefaultTE_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SSLoaded = False
        RegionLoaded = False
        AutoSave()
        FirstLoad = True
        SelectedReset = False
        SVRComboLoaded = False
        ReloadSkills = False

        With ToolTip1
            ' General
            .SetToolTip(chkDisableTracking, "When checked, IPH will not send anonymous useage data to Google Analytics")

        End With

        Call LoadFormSettings()

    End Sub

    Private Sub LoadFormSettings()

        UserApplicationSettings = AllSettings.LoadApplicationSettings()

        With UserApplicationSettings

            chkDisableTracking.Checked = .DisableGATracking

        End With

        FirstLoad = False

        'btnSave.Focus()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TempSettings As ApplicationSettings = Nothing

        Dim Settings As New ProgramSettings

        With TempSettings

            .DisableGATracking = chkDisableTracking.Checked

        End With

        ' Save the data in the XML file
        Call Settings.SaveApplicationSettings(TempSettings)

        ' Save the data to the local variable
        UserApplicationSettings = TempSettings

        ' Re-init any tabs that have settings changes before displaying dialog
        Call frmMain.ResetTabs(False)
        Call frmMain.ResetRefresh()

    End Sub

    Private Sub chkUseActiveSkills_CheckedChanged(sender As Object, e As EventArgs)
        ' They changed active skills, so reload character skills on exit
        ReloadSkills = True
    End Sub

End Class