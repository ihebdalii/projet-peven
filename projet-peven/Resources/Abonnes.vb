Imports System.IO

Public Class Abonnes
    Private Sub Abonnes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        Try
            Dim dt As New DataTable()
            Dim lines() As String = System.IO.File.ReadAllLines("C:\Users\iheb\Documents\membres.txt")

            If lines.Length = 0 Then
                MessageBox.Show("Le fichier est vide!")
                Return
            End If

            ' Add columns
            Dim headers() As String = lines(0).Split(","c)
            For Each header As String In headers
                dt.Columns.Add(header.Trim())
            Next

            ' Add data
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    Dim values() As String = lines(i).Split(","c)
                    dt.Rows.Add(values)
                End If
            Next

            DataGridView1.DataSource = dt
            StyleDataGridView()

        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message)
        End Try
    End Sub

    Private Sub StyleDataGridView()
        With DataGridView1
            ' Transparent background
            .BackgroundColor = Color.Black

            ' Black cells with white text
            .DefaultCellStyle.BackColor = Color.Black
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)

            ' Selection colors
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180)
            .DefaultCellStyle.SelectionForeColor = Color.White

            ' Column headers - YELLOW TEXT on dark background
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold
            .ColumnHeadersDefaultCellStyle.Font = New Font("Bahnschrift", 11, FontStyle.Regular)
            .EnableHeadersVisualStyles = False

            ' Borders and grid
            .BorderStyle = BorderStyle.None
            .GridColor = Color.Gold
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(80, 80, 80)

            ' Hide row headers
            .RowHeadersVisible = False

            ' Auto-size columns
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Row height
            .RowTemplate.Height = 35
            .ColumnHeadersHeight = 40
        End With
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso e.ColumnIndex < DataGridView1.Columns.Count Then
            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Statut" Then
                If e.Value IsNot Nothing Then
                    Dim statut As String = e.Value.ToString().Trim().ToLower()

                    If statut = "actif" Then
                        e.CellStyle.BackColor = Color.FromArgb(34, 139, 34)
                        e.CellStyle.ForeColor = Color.White
                        e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    ElseIf statut = "inactif" Then
                        e.CellStyle.BackColor = Color.FromArgb(220, 20, 60)
                        e.CellStyle.ForeColor = Color.White
                        e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
        ' Path to your TXT file
        Dim filePath As String = "C:\Users\iheb\Documents\membres.txt"

        ' Read all lines from the TXT file
        Dim lines As List(Of String) = IO.File.ReadAllLines(filePath).ToList()

        ' Create a new list without the deleted row
        Dim newLines As New List(Of String)

        For Each line As String In lines
            Dim parts() As String = line.Split(","c)

        Next

        ' Rewrite the TXT file
        IO.File.WriteAllLines(filePath, newLines)

        ' Remove row from the DataGridView
        DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))

        MessageBox.Show("Subscriber deleted successfully!")
    End Sub
End Class