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
        btnSave.Text = "Save"
    End Sub

    Private Sub chkBrokerCorpStanding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBrokerCorpStanding.CheckedChanged
        If chkBrokerCorpStanding.Checked = True Then
            txtBrokerCorpStanding.Enabled = True
            txtBrokerCorpStanding.Focus()
        Else
            txtBrokerCorpStanding.Enabled = False
            txtBrokerCorpStanding.Text = FormatNumber(Defaults.DefaultBrokerCorpStanding, 2)
        End If
        btnSave.Text = "Save"
    End Sub

    Private Sub chkBrokerFactionStanding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBrokerFactionStanding.CheckedChanged
        If chkBrokerFactionStanding.Checked = True Then
            txtBrokerFactionStanding.Enabled = True
            txtBrokerFactionStanding.Focus()
        Else
            txtBrokerFactionStanding.Enabled = False
            txtBrokerFactionStanding.Text = FormatNumber(Defaults.DefaultBrokerFactionStanding, 2)
        End If
        btnSave.Text = "Save"
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
        btnSave.Text = "Save"
    End Sub

    Private Sub chkDefaultME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDefaultME.CheckedChanged
        If chkDefaultME.Checked = True Then
            txtDefaultME.Enabled = True
            txtDefaultME.Focus()
        Else
            txtDefaultME.Enabled = False
            txtDefaultME.Text = FormatNumber(Defaults.DefaultSettingME, 0)
        End If
        btnSave.Text = "Save"
    End Sub

    Private Sub chkDefaultPE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDefaultTE.CheckedChanged
        If chkDefaultTE.Checked = True Then
            txtDefaultTE.Enabled = True
            txtDefaultTE.Focus()
        Else
            txtDefaultTE.Enabled = False
            txtDefaultTE.Text = FormatNumber(Defaults.DefaultSettingTE, 0)
        End If
        btnSave.Text = "Save"
    End Sub

    Private Sub rbtnExportDefault_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtnExportDefault.CheckedChanged
        btnSave.Text = "Save"
    End Sub

    Private Sub rbtnExportCSV_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtnExportCSV.CheckedChanged
        btnSave.Text = "Save"
    End Sub

    Private Sub rbtnExportSSV_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtnExportSSV.CheckedChanged
        btnSave.Text = "Save"
    End Sub

    Private Sub cmbSVRAvgPriceDuration_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSVRThreshold_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSVRThreshold.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedDecimalChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub

    Private Sub cmbSVRRegion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSVRRegion.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDefaultME_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefaultME.KeyPress
        ' Only allow numbers or backspace
        If e.KeyChar <> ControlChars.Back Then
            If allowedRunschars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDefaultTE_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefaultTE.KeyPress
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
        btnSave.Text = "Save"
        FirstLoad = True
        SelectedReset = False
        SVRComboLoaded = False
        ReloadSkills = False

        With ToolTip1
            ' General
            .SetToolTip(rbtnExportCSV, "Exports data in Common Separated Values with periods for decimals")
            .SetToolTip(chkDisableTracking, "When checked, IPH will not send anonymous useage data to Google Analytics")

            ' SVR Settings
            .SetToolTip(lblSVRThreshold, "When set, this will be the default threshold for Sales to Volume Ratio on the BP and Manufacturing tabs")
            .SetToolTip(lblSVRRegion, "When set, this will be the default region for Sales to Volume Ratio calcuations on the BP and Manufacturing tabs")
            .SetToolTip(chkAutoUpdateSVRBPTab, "When set, the Sales to Volume Ratio will be updated on the BP tab when a Blueprint is selected")

            ' Export Data
            .SetToolTip(rbtnExportSSV, "Exports data in SemiColon Separated Values with commas for decimals")
            .SetToolTip(rbtnExportDefault, "Exports data in basic space or dashes to separate data for easy readability")
            .SetToolTip(rbtnExportCSV, "Exports data in Comma Separated Values")

            ' Character Options
            .SetToolTip(chkAlphaAccount, "When checked, IPH will calculate costs adding the 2% industry tax on industry and science jobs")

            ' Tips by Group box
            .SetToolTip(gbDefaultMEPE, "On the BP and Manufacturing tabs, these default ME and TE values will be used for non-owned blueprints")
            .SetToolTip(gbStationStandings, "Station standings affect broker fees and some other industry related fees based on standing. These values here will be used in those calculations.")

        End With

        Call LoadFormSettings()

    End Sub

    Private Sub LoadFormSettings()

        UserApplicationSettings = AllSettings.LoadApplicationSettings()

        With UserApplicationSettings
            If rbtnExportCSV.Text = .DataExportFormat Then
                rbtnExportCSV.Checked = True
            ElseIf rbtnExportSSV.Text = .DataExportFormat Then
                rbtnExportSSV.Checked = True
            ElseIf rbtnExportDefault.Text = .DataExportFormat Then
                rbtnExportDefault.Checked = True
            End If

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

            If .DefaultBPME = 0 Then
                txtDefaultME.Text = CStr(Defaults.DefaultSettingME)
                chkDefaultME.Checked = False
                txtDefaultME.Enabled = False
            Else
                txtDefaultME.Text = CStr(.DefaultBPME)
                chkDefaultME.Checked = True
                txtDefaultME.Enabled = True
            End If

            If .DefaultBPTE = 0 Then
                txtDefaultTE.Text = CStr(Defaults.DefaultSettingTE)
                chkDefaultTE.Checked = False
                txtDefaultTE.Enabled = False
            Else
                txtDefaultTE.Text = CStr(.DefaultBPTE)
                chkDefaultTE.Checked = True
                txtDefaultTE.Enabled = True
            End If

            txtSVRThreshold.Text = CStr(.IgnoreSVRThresholdValue)
            chkAutoUpdateSVRBPTab.Checked = .AutoUpdateSVRonBPTab

        End With

        FirstLoad = False

        btnSave.Focus()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim TempSettings As ApplicationSettings = Nothing

        ' Default values are 0 for implants in settings, since the value stored will get added later. This is the value bonus of the implant
        Dim RefineImplantValue As Double = 0
        Dim ManufacturingImplantValue As Double = 0
        Dim CopyImplantValue As Double = 0

        Dim Settings As New ProgramSettings
        Dim ReloadFacilties As Boolean = False

        If btnSave.Text = "Save" Then

            ' Make sure accurate data is entered
            If Not CheckEntries() Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            ' Get the implant values if set
            If chkBeanCounterManufacturing.Checked Then
                ManufacturingImplantValue = -1 * GetAttribute("manufacturingTimeBonus", cmbBeanCounterManufacturing.Text) / 100
            End If

            With TempSettings

                If rbtnExportDefault.Checked Then
                    .DataExportFormat = rbtnExportDefault.Text
                ElseIf rbtnExportCSV.Checked Then
                    .DataExportFormat = rbtnExportCSV.Text
                ElseIf rbtnExportSSV.Checked Then
                    .DataExportFormat = rbtnExportSSV.Text
                End If

                ' Standings
                .BrokerCorpStanding = CDbl(txtBrokerCorpStanding.Text)
                .BrokerFactionStanding = CDbl(txtBrokerFactionStanding.Text)

                ' Default build/buy
                .CheckBuildBuy = CBool(chkBuildBuyDefault.Checked)

                .DefaultBPME = CInt(txtDefaultME.Text)
                .DefaultBPTE = CInt(txtDefaultTE.Text)

                .DisableGATracking = chkDisableTracking.Checked

                .SuggestBuildBPNotOwned = chkSuggestBuildwhenBPnotOwned.Checked

                .AlphaAccount = chkAlphaAccount.Checked
                ' SVR
                .IgnoreSVRThresholdValue = CDbl(txtSVRThreshold.Text)
                .AutoUpdateSVRonBPTab = chkAutoUpdateSVRBPTab.Checked

            End With

            ' Save the data in the XML file
            Call Settings.SaveApplicationSettings(TempSettings)

            ' Save the data to the local variable
            UserApplicationSettings = TempSettings

            ' They changed the active skill levels, update skills now with new application settings
            If ReloadSkills Then
                ' Set the flag first
                Call SelectedCharacter.Skills.LoadCharacterSkills(SelectedCharacter.ID, SelectedCharacter.CharacterTokenData)
            End If

            ' If they changed what the original value was for the shared facilities, reload them
            If ReloadFacilties Then
                ' Load all the forms' facilities 
                Call frmMain.LoadFacilities()
            End If

            ' Re-init any tabs that have settings changes before displaying dialog
            Call frmMain.ResetTabs(False)
            Call frmMain.ResetRefresh()

            MsgBox("Settings Saved", vbInformation, Application.ProductName)

            btnSave.Text = "OK"
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        Else
            ' Just exit
            Me.Hide()
        End If

        btnSave.Focus()

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

        ' ME/TE
        If (Not IsNumeric(txtDefaultME.Text) Or Trim(txtDefaultME.Text) = "") And chkDefaultME.Checked Then
            TempTextBox = txtDefaultME
            TempCheckBox = chkDefaultME
            GoTo InvalidData
        End If

        If (Not IsNumeric(txtDefaultTE.Text) Or Trim(txtDefaultTE.Text) = "") And chkDefaultTE.Checked Then
            TempTextBox = txtDefaultTE
            TempCheckBox = chkDefaultTE
            GoTo InvalidData
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If SelectedReset Then
            ' If we hit reset, then we need to get the current list of settings, not just what is loaded (might be defaults)
            ' So just reload the settings
            UserApplicationSettings = AllSettings.LoadApplicationSettings()
        End If
        Me.Hide()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        SelectedReset = True
        ' Load default settings
        UserApplicationSettings = AllSettings.SetDefaultApplicationSettings()
        ' Reload the form
        Call LoadFormSettings()

    End Sub

    Private Sub chkUseActiveSkills_CheckedChanged(sender As Object, e As EventArgs)
        ' They changed active skills, so reload character skills on exit
        ReloadSkills = True
    End Sub

End Class