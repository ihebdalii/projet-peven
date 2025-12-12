Imports System.IO

Public Class Planning
    Private ReadOnly filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "plannings.txt")

    Private Sub Planning_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False

        ' Create file if it doesn't exist
        If Not File.Exists(filePath) Then
            CreateDefaultPlanningFile()
        End If

        LoadPlanningData()
    End Sub

    Private Sub CreateDefaultPlanningFile()
        Dim defaultContent As New List(Of String) From {
            "Jour,Horaire,Activite,Coach,Duree,Capacite,Inscrits,Statut"
        }
        File.WriteAllLines(filePath, defaultContent)
    End Sub

    Private Sub LoadPlanningData()
        Try
            Dim dt As New DataTable()
            Dim lines() As String = File.ReadAllLines(filePath)

            If lines.Length = 0 Then
                MessageBox.Show("Le fichier plannings est vide!")
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
            .BackgroundColor = Color.Black
            .DefaultCellStyle.BackColor = Color.Black
            .DefaultCellStyle.ForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Arial", 10)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold
            .ColumnHeadersDefaultCellStyle.Font = New Font("Bahnschrift", 11, FontStyle.Regular)
            .EnableHeadersVisualStyles = False
            .BorderStyle = BorderStyle.None
            .GridColor = Color.FromArgb(80, 80, 80)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowTemplate.Height = 35
            .ColumnHeadersHeight = 40
        End With
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim columnName As String = DataGridView1.Columns(e.ColumnIndex).HeaderText.ToLower()

            ' Color code status
            If columnName = "statut" AndAlso e.Value IsNot Nothing Then
                Dim statut As String = e.Value.ToString().Trim().ToLower()
                If statut = "ouvert" Then
                    e.CellStyle.BackColor = Color.FromArgb(34, 139, 34)
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                ElseIf statut = "complet" Then
                    e.CellStyle.BackColor = Color.FromArgb(255, 140, 0)
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                ElseIf statut = "annule" Then
                    e.CellStyle.BackColor = Color.FromArgb(220, 20, 60)
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                End If
            End If

            ' Highlight capacity warnings
            If DataGridView1.Rows(e.RowIndex).Cells.Count > 0 Then
                Dim capaciteCol As Integer = -1
                Dim inscritsCol As Integer = -1

                For i As Integer = 0 To DataGridView1.Columns.Count - 1
                    If DataGridView1.Columns(i).HeaderText.ToLower() = "capacite" Then capaciteCol = i
                    If DataGridView1.Columns(i).HeaderText.ToLower() = "inscrits" Then inscritsCol = i
                Next

                If capaciteCol >= 0 AndAlso inscritsCol >= 0 Then
                    Dim capaciteVal = DataGridView1.Rows(e.RowIndex).Cells(capaciteCol).Value
                    Dim inscritsVal = DataGridView1.Rows(e.RowIndex).Cells(inscritsCol).Value

                    If capaciteVal IsNot Nothing AndAlso inscritsVal IsNot Nothing Then
                        Dim capacite As Integer
                        Dim inscrits As Integer
                        If Integer.TryParse(capaciteVal.ToString(), capacite) AndAlso Integer.TryParse(inscritsVal.ToString(), inscrits) Then
                            If inscrits >= capacite AndAlso (columnName = "inscrits" OrElse columnName = "capacite") Then
                                e.CellStyle.BackColor = Color.FromArgb(255, 69, 0)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Add new planning
        Try
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim newValues As New List(Of String)

            For Each column As DataColumn In dt.Columns
                Dim input As String = ""
                Dim prompt As String = $"Entrez {column.ColumnName}:"

                Select Case column.ColumnName.ToLower()
                    Case "jour"
                        prompt &= vbCrLf & "(Ex: Lundi, Mardi, Mercredi, Jeudi, Vendredi, Samedi, Dimanche)"
                    Case "horaire"
                        prompt &= vbCrLf & "(Ex: 08:00-09:00)"
                    Case "activite"
                        prompt &= vbCrLf & "(Ex: Yoga, Musculation, Cardio, CrossFit, Pilates)"
                    Case "duree"
                        prompt &= vbCrLf & "(En minutes, ex: 60)"
                    Case "capacite", "inscrits"
                        prompt &= vbCrLf & "(Nombre de personnes)"
                    Case "statut"
                        prompt &= vbCrLf & "(Ouvert/Complet/Annule)"
                End Select

                input = InputBox(prompt, "Nouveau Planning")

                If String.IsNullOrEmpty(input) Then
                    MessageBox.Show("Ajout annulé!")
                    Return
                End If

                newValues.Add(input)
            Next

            dt.Rows.Add(newValues.ToArray())
            SaveDataToFile(dt)
            MessageBox.Show("Planning ajouté avec succès!")
            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ajout : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Delete planning
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez le planning à supprimer")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce planning?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
                Dim selectedIndex As Integer = DataGridView1.SelectedRows(0).Index
                dt.Rows(selectedIndex).Delete()
                SaveDataToFile(dt)
                MessageBox.Show("Planning supprimé!")
            Catch ex As Exception
                MessageBox.Show("Erreur : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Save modifications
        Try
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            SaveDataToFile(dt)
            MessageBox.Show("Modifications enregistrées avec succès!")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement : " & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Ouvert button - Change status to Ouvert
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez le planning à modifier")
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
                ' Change status to Ouvert
                dt.Rows(selectedRowIndex)(statutColumnIndex) = "Ouvert"

                ' Save to file
                SaveDataToFile(dt)

                ' Refresh the display to update colors
                DataGridView1.Refresh()

                MessageBox.Show("Statut changé à Ouvert!")
            Else
                MessageBox.Show("Colonne Statut introuvable!")
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Annulé button - Change status to Annulé
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez le planning à modifier")
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
                ' Change status to Annulé
                dt.Rows(selectedRowIndex)(statutColumnIndex) = "Annule"

                ' Save to file
                SaveDataToFile(dt)

                ' Refresh the display to update colors
                DataGridView1.Refresh()

                MessageBox.Show("Statut changé à Annulé!")
            Else
                MessageBox.Show("Colonne Statut introuvable!")
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub SaveDataToFile(dt As DataTable)
        Dim lines As New List(Of String)

        ' Add header
        Dim headers As New List(Of String)
        For Each column As DataColumn In dt.Columns
            headers.Add(column.ColumnName)
        Next
        lines.Add(String.Join(",", headers))

        ' Add data
        For Each row As DataRow In dt.Rows
            If row.RowState <> DataRowState.Deleted Then
                Dim values As New List(Of String)
                For Each item In row.ItemArray
                    values.Add(item.ToString())
                Next
                lines.Add(String.Join(",", values))
            End If
        Next

        File.WriteAllLines(filePath, lines)
    End Sub
End Class