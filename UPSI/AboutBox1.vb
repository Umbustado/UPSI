Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName & " v" & Application.ProductVersion
        Me.lblVersion.Text = "v" & Application.ProductVersion()
        Me.txtDescription.Text = "  ● For people who don't want to use SideQuest or .bat files." & vbCrLf & "  ● Always have the latest build" & vbCrLf & "  ● Set your name easily" & vbCrLf & "  ● Set the permissions easily" & vbCrLf & "  ● Automatically update to the latest build"

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://discord.gg/n98qD5n")
    End Sub
End Class
