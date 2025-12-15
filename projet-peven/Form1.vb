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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ActivitesSportives As New ActivitesSportives()
        ActivitesSportives.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim AbonnementsPaiements As New AbonnementsPaiements()
        AbonnementsPaiements.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Statistiques As New Statistiques()
        Statistiques.ShowDialog()
    End Sub
End Class
