Imports System.IO

Public Class Abonnes
    Private ReadOnly filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "membres.txt")

    Private Function IsValidDate(dateString As String) As Boolean
        ' Check format jj/mm/aaaa
        If String.IsNullOrWhiteSpace(dateString) Then
            Return False
        End If

        Dim parts() As String = dateString.Split("/"c)
        If parts.Length <> 3 Then
            Return False
        End If

        ' Check if parts are numeric
        Dim jour, mois, annee As Integer
        If Not Integer.TryParse(parts(0), jour) OrElse Not Integer.TryParse(parts(1), mois) OrElse Not Integer.TryParse(parts(2), annee) Then
            Return False
        End If

        ' Validate ranges
        If jour < 1 OrElse jour > 31 Then
            Return False
        End If

        If mois < 1 OrElse mois > 12 Then
            Return False
        End If

        If annee < 1900 OrElse annee > 2100 Then
            Return False
        End If

        ' Try to create a valid date
        Try
            Dim testDate As New Date(annee, mois, jour)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function IsValid8Digits(value As String) As Boolean
        ' Check if exactly 8 numeric digits
        If String.IsNullOrWhiteSpace(value) Then
            Return False
        End If

        ' Must be exactly 8 characters and all numeric
        If value.Length <> 8 Then
            Return False
        End If

        ' Check if all characters are digits
        For Each c As Char In value
            If Not Char.IsDigit(c) Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub Abonnes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        Try
            Dim dt As New DataTable()
            Dim lines() As String = System.IO.File.ReadAllLines(filePath)

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim newValues As New List(Of String)

            ' Get input for each column
            For Each column As DataColumn In dt.Columns
                Dim input As String = ""
                Dim isValid As Boolean = False

                ' Check if it's a date column
                Dim isDateColumn As Boolean = column.ColumnName.ToLower().Contains("date") OrElse column.ColumnName.ToLower().Contains("inscription") OrElse column.ColumnName.ToLower().Contains("naissance")

                ' Check if it's a CIN or Telephone column
                Dim is8DigitsColumn As Boolean = column.ColumnName.ToLower().Contains("cin") OrElse column.ColumnName.ToLower().Contains("telephone") OrElse column.ColumnName.ToLower().Contains("tel")

                While Not isValid
                    Dim prompt As String = $"Entrez {column.ColumnName}:"
                    If isDateColumn Then
                        prompt &= vbCrLf & "(Format: jj/mm/aaaa)"
                    ElseIf is8DigitsColumn Then
                        prompt &= vbCrLf & "(8 chiffres exactement)"
                    End If

                    input = InputBox(prompt, "Nouvel Adhérent")

                    ' If user cancels, exit
                    If String.IsNullOrEmpty(input) Then
                        MessageBox.Show("Ajout annulé!")
                        Return
                    End If

                    ' Validate date format if it's a date column
                    If isDateColumn Then
                        If IsValidDate(input) Then
                            isValid = True
                        Else
                            MessageBox.Show("Format de date invalide! Utilisez le format jj/mm/aaaa" & vbCrLf & "Exemple: 15/03/2023", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    ElseIf is8DigitsColumn Then
                        If IsValid8Digits(input) Then
                            isValid = True
                        Else
                            MessageBox.Show("Format invalide! Entrez exactement 8 chiffres" & vbCrLf & "Exemple: 12345678", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        isValid = True
                    End If
                End While

                newValues.Add(input)
            Next

            ' Add the new row to DataTable
            dt.Rows.Add(newValues.ToArray())

            ' Save to file
            SaveDataToFile(dt)

            MessageBox.Show("Adhérent ajouté avec succès!")

            ' Refresh the formatting
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ajout : " & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim lines As New List(Of String)
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)

            ' Add header row
            Dim headers As New List(Of String)
            For Each column As DataColumn In dt.Columns
                headers.Add(column.ColumnName)
            Next
            lines.Add(String.Join(",", headers))

            ' Add data rows
            For Each row As DataRow In dt.Rows
                Dim values As New List(Of String)
                For Each item In row.ItemArray
                    values.Add(item.ToString())
                Next
                lines.Add(String.Join(",", values))
            Next

            ' Write to file
            IO.File.WriteAllLines(filePath, lines)

            MessageBox.Show("Modifications enregistrées avec succès!")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement : " & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Actif button
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Selectionnez l'adherent à modifier")
            Return
        End If

        Try
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim selectedRowIndex As Integer = DataGridView1.SelectedRows(0).Index

            ' Find the Statut column index
            Dim statutColumnIndex As Integer = -1
            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Columns(i).ColumnName.ToLower() = "statut" Then
                    statutColumnIndex = i
                    Exit For
                End If
            Next

            If statutColumnIndex >= 0 Then
                ' Change status to Actif
                dt.Rows(selectedRowIndex)(statutColumnIndex) = "Actif"

                ' Save to file
                SaveDataToFile(dt)

                ' Refresh the display to update colors
                DataGridView1.Refresh()

                MessageBox.Show("Statut changé à Actif!")
            Else
                MessageBox.Show("Colonne Statut introuvable!")
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Inactif button
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Selectionnez l'adherent à modifier")
            Return
        End If

        Try
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim selectedRowIndex As Integer = DataGridView1.SelectedRows(0).Index

            ' Find the Statut column index
            Dim statutColumnIndex As Integer = -1
            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Columns(i).ColumnName.ToLower() = "statut" Then
                    statutColumnIndex = i
                    Exit For
                End If
            Next

            If statutColumnIndex >= 0 Then
                ' Change status to Inactif
                dt.Rows(selectedRowIndex)(statutColumnIndex) = "Inactif"

                ' Save to file
                SaveDataToFile(dt)

                ' Refresh the display to update colors
                DataGridView1.Refresh()

                MessageBox.Show("Statut changé à Inactif!")
            Else
                MessageBox.Show("Colonne Statut introuvable!")
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub SaveDataToFile(dt As DataTable)
        Dim lines As New List(Of String)

        ' Add header row
        Dim headers As New List(Of String)
        For Each column As DataColumn In dt.Columns
            headers.Add(column.ColumnName)
        Next
        lines.Add(String.Join(",", headers))

        ' Add data rows
        For Each row As DataRow In dt.Rows
            Dim values As New List(Of String)
            For Each item In row.ItemArray
                values.Add(item.ToString())
            Next
            lines.Add(String.Join(",", values))
        Next

        ' Write to file
        IO.File.WriteAllLines(filePath, lines)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Selectionnez l'adherent a supprimer")
            Return
        End If

        ' Get the selected row index
        Dim selectedIndex As Integer = DataGridView1.SelectedRows(0).Index

        Try
            ' Read all lines from the TXT file
            Dim lines As List(Of String) = IO.File.ReadAllLines(filePath).ToList()

            ' Remove the selected row (add 1 because line 0 is the header)
            If selectedIndex + 1 < lines.Count Then
                lines.RemoveAt(selectedIndex + 1)
            End If

            ' Rewrite the TXT file
            IO.File.WriteAllLines(filePath, lines)

            ' Remove row from the DataGridView
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))

            MessageBox.Show("Adherent supprime !")
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub
End Class