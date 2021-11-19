﻿Public NotInheritable Class frmAbout

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = "Created by: Zifrian"
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub pbPaypal_Click(sender As Object, e As EventArgs) Handles pbPaypal.Click
        ' Take them to the donation page
        Call Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=HSZKRQYTX5HR6&source=url")
    End Sub

    Private Sub pbPaypal_MouseEnter(sender As Object, e As EventArgs) Handles pbPaypal.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub pbPaypal_MouseLeave(sender As Object, e As EventArgs) Handles pbPaypal.MouseLeave
        Cursor.Current = Cursors.Default
    End Sub
End Class
