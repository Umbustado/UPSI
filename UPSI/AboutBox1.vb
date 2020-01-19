Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtDescription.Text = "For those people who don't want to use SideQuest or .bat files." & vbCrLf & "Always have the latest build" & vbCrLf & "Set your name easily" & vbCrLf & "Set the permissions" & vbCrLf & "Automatically update to the latest build" & vbCrLf & "Everything a budding Pavlovian could need !!!!! :D"

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
