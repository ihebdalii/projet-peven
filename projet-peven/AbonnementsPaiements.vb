Imports System.IO

Public Class AbonnementsPaiements
    Private ReadOnly filePath As String = Path.Combine(Application.StartupPath, "..", "..", "..", "abonnements.txt")

    Private Sub AbonnementsPaiements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False

        ' Create file if it doesn't exist
        If Not File.Exists(filePath) Then
            CreateDefaultAbonnementsFile()
        End If

        LoadAbonnementsData()
    End Sub

    Private Sub CreateDefaultAbonnementsFile()
        Dim defaultContent As New List(Of String) From {
            "Membre,TypeAbonnement,DateDebut,DateFin,Montant,DatePaiement,ModePaiement,Statut"
        }
        File.WriteAllLines(filePath, defaultContent)
    End Sub

    Private Sub LoadAbonnementsData()
        Try
            Dim dt As New DataTable()
            Dim lines() As String = File.ReadAllLines(filePath)

            If lines.Length = 0 Then
                MessageBox.Show("Le fichier abonnements est vide!")
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
                If statut = "paye" Then
                    e.CellStyle.BackColor = Color.FromArgb(34, 139, 34)
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                ElseIf statut = "impaye" Then
                    e.CellStyle.BackColor = Color.FromArgb(220, 20, 60)
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                ElseIf statut = "expire" Then
                    e.CellStyle.BackColor = Color.FromArgb(255, 140, 0)
                    e.CellStyle.ForeColor = Color.White
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                End If
            End If

            ' Color code subscription type - Annuel subscriptions in gold
            If columnName = "typeabonnement" AndAlso e.Value IsNot Nothing Then
                Dim typeAbo As String = e.Value.ToString().Trim().ToLower()
                If typeAbo.Contains("annuel") Then
                    e.CellStyle.ForeColor = Color.Gold
                    e.CellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                ElseIf typeAbo.Contains("mensuel") Then
                    e.CellStyle.ForeColor = Color.LightBlue
                End If
            End If

            ' Highlight payment dates
            If columnName.Contains("date") AndAlso e.Value IsNot Nothing Then
                Dim dateValue As String = e.Value.ToString().Trim()
                If Not String.IsNullOrEmpty(dateValue) Then
                    Try
                        ' Parse date if it's in dd/MM/yyyy format
                        Dim parts() As String = dateValue.Split("/"c)
                        If parts.Length = 3 Then
                            Dim testDate As New Date(Integer.Parse(parts(2)), Integer.Parse(parts(1)), Integer.Parse(parts(0)))

                            ' Check if date is in the past (for DateFin)
                            If columnName = "datefin" AndAlso testDate < Date.Today Then
                                e.CellStyle.ForeColor = Color.OrangeRed
                            End If
                        End If
                    Catch ex As Exception
                        ' Ignore parsing errors
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Add new subscription
        Try
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim newValues As New List(Of String)

            For Each column As DataColumn In dt.Columns
                Dim input As String = ""
                Dim prompt As String = $"Entrez {column.ColumnName}:"

                Select Case column.ColumnName.ToLower()
                    Case "membre"
                        prompt &= vbCrLf & "(Nom complet du membre)"
                    Case "typeabonnement"
                        prompt &= vbCrLf & "(Mensuel/Trimestriel/Annuel)"
                    Case "datedebut", "datefin", "datepaiement"
                        prompt &= vbCrLf & "(Format: jj/mm/aaaa)"
                    Case "montant"
                        prompt &= vbCrLf & "(Montant en DT)"
                    Case "modepaiement"
                        prompt &= vbCrLf & "(Espèces/Carte/Virement/Chèque)"
                    Case "statut"
                        prompt &= vbCrLf & "(Paye/Impaye/Expire)"
                End Select

                input = InputBox(prompt, "Nouvel Abonnement")

                If String.IsNullOrEmpty(input) Then
                    MessageBox.Show("Ajout annulé!")
                    Return
                End If

                newValues.Add(input)
            Next

            dt.Rows.Add(newValues.ToArray())
            SaveDataToFile(dt)
            MessageBox.Show("Abonnement ajouté avec succès!")
            DataGridView1.Refresh()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ajout : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Delete subscription
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez l'abonnement à supprimer")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet abonnement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
                Dim selectedIndex As Integer = DataGridView1.SelectedRows(0).Index
                dt.Rows(selectedIndex).Delete()
                SaveDataToFile(dt)
                MessageBox.Show("Abonnement supprimé!")
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
        ' Payé button - Change status to Payé
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez l'abonnement à modifier")
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
                ' Change status to Payé
                dt.Rows(selectedRowIndex)(statutColumnIndex) = "Paye"

                ' Save to file
                SaveDataToFile(dt)

                ' Refresh the display to update colors
                DataGridView1.Refresh()

                MessageBox.Show("Statut changé à Payé!")
            Else
                MessageBox.Show("Colonne Statut introuvable!")
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Impayé button - Change status to Impayé
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez l'abonnement à modifier")
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
                ' Change status to Impayé
                dt.Rows(selectedRowIndex)(statutColumnIndex) = "Impaye"

                ' Save to file
                SaveDataToFile(dt)

                ' Refresh the display to update colors
                DataGridView1.Refresh()

                MessageBox.Show("Statut changé à Impayé!")
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
