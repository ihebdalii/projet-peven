Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Abonnes As New Abonnes()
        Abonnes.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Personnel As New Personnel()
        Personnel.ShowDialog()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Planning As New Planning()
        Planning.ShowDialog()
    End Sub
End Class
