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

            ' Standings
            .BrokerCorpStanding = CDbl(txtBrokerCorpStanding.Text)
            .BrokerFactionStanding = CDbl(txtBrokerFactionStanding.Text)

            ' Default build/buy
            .CheckBuildBuy = CBool(chkBuildBuyDefault.Checked)

            .DisableGATracking = chkDisableTracking.Checked

            .SuggestBuildBPNotOwned = chkSuggestBuildwhenBPnotOwned.Checked

            .AlphaAccount = chkAlphaAccount.Checked
            ' SVR
            .AutoUpdateSVRonBPTab = chkAutoUpdateSVRBPTab.Checked

        End With

        ' Save the data in the XML file
        'SaveApplicationSettings(TempSettings)

        ' Save the data to the local variable
        UserApplicationSettings = TempSettings

    End Sub

    Private Sub chkBeanCounterManufacturing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBeanCounterManufacturing.CheckedChanged
        If Not FirstLoad Then
            If chkBeanCounterManufacturing.Checked Then
                cmbBeanCounterManufacturing.Enabled = True
                cmbBeanCounterManufacturing.Text = "Zainou 'Beancounter' Industry BX-802"
            Else
                cmbBeanCounterManufacturing.Enabled = False
                cmbBeanCounterManufacturing.Text = ""
            End If
        End If
        AutoSave()
    End Sub

    Private Sub chkBrokerCorpStanding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBrokerCorpStanding.CheckedChanged
        If chkBrokerCorpStanding.Checked = True Then
            txtBrokerCorpStanding.Enabled = True
            txtBrokerCorpStanding.Focus()
        Else
            txtBrokerCorpStanding.Enabled = False
            txtBrokerCorpStanding.Text = FormatNumber(Defaults.DefaultBrokerCorpStanding, 2)
        End If
        AutoSave()
    End Sub

    Private Sub chkBrokerFactionStanding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBrokerFactionStanding.CheckedChanged
        If chkBrokerFactionStanding.Checked = True Then
            txtBrokerFactionStanding.Enabled = True
            txtBrokerFactionStanding.Focus()
        Else
            txtBrokerFactionStanding.Enabled = False
            txtBrokerFactionStanding.Text = FormatNumber(Defaults.DefaultBrokerFactionStanding, 2)
        End If
        AutoSave()
    End Sub

    Private Sub txtBrokerFactionStandings_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrokerFactionStanding.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtBrokerCorpStandings_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrokerCorpStanding.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chkBuildBuyDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBuildBuyDefault.CheckedChanged
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

            ' SVR Settings
            .SetToolTip(chkAutoUpdateSVRBPTab, "When set, the Sales to Volume Ratio will be updated on the BP tab when a Blueprint is selected")

            ' Character Options
            .SetToolTip(chkAlphaAccount, "When checked, IPH will calculate costs adding the 2% industry tax on industry and science jobs")

            ' Tips by Group box
            .SetToolTip(gbStationStandings, "Station standings affect broker fees and some other industry related fees based on standing. These values here will be used in those calculations.")

        End With

        Call LoadFormSettings()

    End Sub

    Private Sub LoadFormSettings()

        UserApplicationSettings = AllSettings.LoadApplicationSettings()

        With UserApplicationSettings
            If .BrokerCorpStanding = Defaults.DefaultBrokerCorpStanding Then
                ' Default
                chkBrokerCorpStanding.Checked = False
                txtBrokerCorpStanding.Enabled = False
                txtBrokerCorpStanding.Text = FormatNumber(Defaults.DefaultBrokerCorpStanding, 2)
            Else
                ' User
                chkBrokerCorpStanding.Checked = True
                txtBrokerCorpStanding.Enabled = True
                txtBrokerCorpStanding.Text = FormatNumber(.BrokerCorpStanding, 2)
            End If

            If .BrokerFactionStanding = Defaults.DefaultBrokerFactionStanding Then
                ' Default
                chkBrokerFactionStanding.Checked = False
                txtBrokerFactionStanding.Enabled = False
                txtBrokerFactionStanding.Text = FormatNumber(Defaults.DefaultBrokerFactionStanding, 2)
            Else
                ' User
                chkBrokerFactionStanding.Checked = True
                txtBrokerFactionStanding.Enabled = True
                txtBrokerFactionStanding.Text = FormatNumber(.BrokerFactionStanding, 2)
            End If

            ' Implants
            If .ManufacturingImplantValue > 0 Then
                chkBeanCounterManufacturing.Checked = True
                Select Case .ManufacturingImplantValue
                    Case (-1 * GetAttribute("manufacturingTimeBonus", Defaults.MBeanCounterName & "1") / 100)
                        cmbBeanCounterManufacturing.Text = Defaults.MBeanCounterName & "1"
                    Case (-1 * GetAttribute("manufacturingTimeBonus", Defaults.MBeanCounterName & "2") / 100)
                        cmbBeanCounterManufacturing.Text = Defaults.MBeanCounterName & "2"
                    Case (-1 * GetAttribute("manufacturingTimeBonus", Defaults.MBeanCounterName & "4") / 100)
                        cmbBeanCounterManufacturing.Text = Defaults.MBeanCounterName & "4"
                End Select
            Else
                cmbBeanCounterManufacturing.Enabled = False
            End If

            ' For Build/Buy
            chkBuildBuyDefault.Checked = .CheckBuildBuy
            chkSuggestBuildwhenBPnotOwned.Checked = .SuggestBuildBPNotOwned

            chkDisableTracking.Checked = .DisableGATracking

            chkAlphaAccount.Checked = .AlphaAccount

            chkAutoUpdateSVRBPTab.Checked = .AutoUpdateSVRonBPTab

        End With

        FirstLoad = False

        'btnSave.Focus()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TempSettings As ApplicationSettings = Nothing

        Dim Settings As New ProgramSettings

        With TempSettings

            ' Standings
            .BrokerCorpStanding = CDbl(txtBrokerCorpStanding.Text)
            .BrokerFactionStanding = CDbl(txtBrokerFactionStanding.Text)

            ' Default build/buy
            .CheckBuildBuy = CBool(chkBuildBuyDefault.Checked)

            .DisableGATracking = chkDisableTracking.Checked

            .SuggestBuildBPNotOwned = chkSuggestBuildwhenBPnotOwned.Checked

            .AlphaAccount = chkAlphaAccount.Checked
            ' SVR
            .AutoUpdateSVRonBPTab = chkAutoUpdateSVRBPTab.Checked

        End With

        ' Save the data in the XML file
        Call Settings.SaveApplicationSettings(TempSettings)

        ' Save the data to the local variable
        UserApplicationSettings = TempSettings

        ' Re-init any tabs that have settings changes before displaying dialog
        Call frmMain.ResetTabs(False)
        Call frmMain.ResetRefresh()

    End Sub

    Private Function CheckEntries() As Boolean
        Dim TempTextBox As TextBox = Nothing
        Dim TempCheckBox As CheckBox = Nothing
        Dim TempComboBox As ComboBox = Nothing

        If (Not IsNumeric(txtBrokerCorpStanding.Text) Or Trim(txtBrokerCorpStanding.Text) = "") And chkBrokerCorpStanding.Checked Then
            TempTextBox = txtBrokerCorpStanding
            TempCheckBox = chkBrokerCorpStanding
            GoTo InvalidData
        ElseIf CDbl(txtBrokerCorpStanding.Text) > 10 Then
            txtBrokerCorpStanding.Text = "10.0"
        End If

        If (Not IsNumeric(txtBrokerFactionStanding.Text) Or Trim(txtBrokerFactionStanding.Text) = "") And chkBrokerFactionStanding.Checked Then
            TempTextBox = txtBrokerFactionStanding
            TempCheckBox = chkBrokerFactionStanding
            GoTo InvalidData
        ElseIf CDbl(txtBrokerFactionStanding.Text) > 10 Then
            txtBrokerFactionStanding.Text = "10.0"
        End If

        Return True

InvalidData:

        If Not IsNothing(TempComboBox) Then
            MsgBox("Invalid " & TempComboBox.Name & " Value", vbExclamation, Application.ProductName)
            TempComboBox.Focus()
            Call TempComboBox.SelectAll()
        Else
            MsgBox("Invalid " & TempCheckBox.Name & " Value", vbExclamation, Application.ProductName)
            TempTextBox.Focus()
            Call TempTextBox.SelectAll()
        End If

        Return False

    End Function

    Private Sub chkUseActiveSkills_CheckedChanged(sender As Object, e As EventArgs)
        ' They changed active skills, so reload character skills on exit
        ReloadSkills = True
    End Sub

End Class