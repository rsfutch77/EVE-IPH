<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectManufacturingTabColumns
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectManufacturingTabColumns))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.lblTip = New System.Windows.Forms.Label()
        Me.chkLstBoxColumns = New System.Windows.Forms.CheckedListBox()
        Me.btnDefaults = New System.Windows.Forms.Button()
        Me.btnToggleAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(200, 669)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 31)
        Me.btnCancel.TabIndex = 67
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(51, 669)
        Me.btnSaveSettings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(121, 31)
        Me.btnSaveSettings.TabIndex = 69
        Me.btnSaveSettings.Text = "Save"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'lblInstruction
        '
        Me.lblInstruction.Location = New System.Drawing.Point(15, 11)
        Me.lblInstruction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(341, 24)
        Me.lblInstruction.TabIndex = 70
        Me.lblInstruction.Text = "Select the Columns you want to view:"
        '
        'lblTip
        '
        Me.lblTip.Location = New System.Drawing.Point(22, 591)
        Me.lblTip.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Size = New System.Drawing.Size(325, 38)
        Me.lblTip.TabIndex = 71
        Me.lblTip.Text = "Change the order of the columns by dragging them to desired location on the Manuf" &
    "acturing Tab list."
        Me.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkLstBoxColumns
        '
        Me.chkLstBoxColumns.FormattingEnabled = True
        Me.chkLstBoxColumns.Items.AddRange(New Object() {"Item Category", "Item Group", "Item Name", "Owned", "Tech", "ME", "TE", "Inputs", "Compared", "Total Runs", "Single Invented BPC Runs", "Production Lines", "Laboratory Lines", "Total Invention Cost", "Total Copy Cost", "Taxes", "Broker Fees", "BP Production Time", "Total Production Time", "Copy Time", "Invention Time", "Item Market Price", "Profit", "Profit Percentage", "Isk per Hour", "SVR", "SVR * IPH", "Price Trend", "Total Items Sold", "Total Orders Filled", "Average Items Per Order", "Current Sell Orders", "Current Buy Orders", "Items in Production", "Items in Stock", "Total Cost", "Base Job Cost", "Num BPs", "Invention Chance", "BP Type", "Race", "Volume per Item", "Total Volume", "Portion Size", "Manufacturing Job Fee", "Manufacturing Facility Name", "Manufacturing Facility System", "Manufacturing Facility Region", "Manufacturing Facility System Index", "Manufacturing Facility Tax", "Manufacturing Facility ME Bonus", "Manufacturing Facility TE Bonus", "Manufacturing Facility Usage", "Manufacturing Facility FW System Level", "Component Facility Name", "Component Facility System", "Component Facility Region", "Component Facility System Index", "Component Facility Tax", "Component Facility ME Bonus", "Component Facility TE Bonus", "Component Facility Usage", "Component Facility FW System Level", "Capital Component Facility Name", "Capital Component Facility System", "Capital Component Facility Region", "Capital Component Facility SystemIndex", "Capital Component Facility Tax", "Capital Component Facility ME Bonus", "Capital Component Facility TE Bonus", "Capital Component Facility Usage", "Capital Component Facility FW System Level", "Copying Facility Name", "Copying Facility System", "Copying Facility Region", "Copying Facility System Index", "Copying Facility Tax", "Copying Facility ME Bonus", "Copying Facility TE Bonus", "Copying Facility Usage", "Copying Facility FW System Level", "Invention Facility Name", "Invention Facility System", "Invention Facility Region", "Invention Facility SystemIndex", "Invention Facility Tax", "Invention Facility ME Bonus", "Invention Facility TE Bonus", "Invention Facility Usage", "Invention Facility FW System Level", "Reaction Facility Name", "Reaction Facility System", "Reaction Facility Region", "Reaction Facility SystemIndex", "Reaction Facility Tax", "Reaction Facility ME Bonus", "Reaction Facility TE Bonus", "Reaction Facility Usage", "Reaction Facility FW System Level", "Volatility"})
        Me.chkLstBoxColumns.Location = New System.Drawing.Point(19, 39)
        Me.chkLstBoxColumns.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkLstBoxColumns.Name = "chkLstBoxColumns"
        Me.chkLstBoxColumns.Size = New System.Drawing.Size(340, 548)
        Me.chkLstBoxColumns.TabIndex = 72
        '
        'btnDefaults
        '
        Me.btnDefaults.Location = New System.Drawing.Point(51, 630)
        Me.btnDefaults.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDefaults.Name = "btnDefaults"
        Me.btnDefaults.Size = New System.Drawing.Size(121, 31)
        Me.btnDefaults.TabIndex = 73
        Me.btnDefaults.Text = "Reset to Default"
        Me.btnDefaults.UseVisualStyleBackColor = True
        '
        'btnToggleAll
        '
        Me.btnToggleAll.Location = New System.Drawing.Point(200, 630)
        Me.btnToggleAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnToggleAll.Name = "btnToggleAll"
        Me.btnToggleAll.Size = New System.Drawing.Size(121, 31)
        Me.btnToggleAll.TabIndex = 74
        Me.btnToggleAll.Text = "Toggle All"
        Me.btnToggleAll.UseVisualStyleBackColor = True
        '
        'frmSelectManufacturingTabColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(371, 715)
        Me.Controls.Add(Me.btnToggleAll)
        Me.Controls.Add(Me.btnDefaults)
        Me.Controls.Add(Me.chkLstBoxColumns)
        Me.Controls.Add(Me.lblTip)
        Me.Controls.Add(Me.lblInstruction)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectManufacturingTabColumns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Columns"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
    Friend WithEvents lblInstruction As System.Windows.Forms.Label
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents chkLstBoxColumns As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnDefaults As System.Windows.Forms.Button
    Friend WithEvents btnToggleAll As System.Windows.Forms.Button
End Class
