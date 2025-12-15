Imports System.IO

Public Class Statistiques
    Private ReadOnly membresPath As String = Path.Combine(Application.StartupPath, "..", "..", "..", "membres.txt")
    Private ReadOnly personnelPath As String = Path.Combine(Application.StartupPath, "..", "..", "..", "personnel.txt")
    Private ReadOnly planningsPath As String = Path.Combine(Application.StartupPath, "..", "..", "..", "plannings.txt")
    Private ReadOnly activitesPath As String = Path.Combine(Application.StartupPath, "..", "..", "..", "activites.txt")
    Private ReadOnly abonnementsPath As String = Path.Combine(Application.StartupPath, "..", "..", "..", "abonnements.txt")

    Private Sub Statistiques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStatistics()
    End Sub

    Private Sub LoadStatistics()
        Try
            ' Membres Statistics
            Dim membresStats = GetMembresStatistics()
            lblTotalMembres.Text = membresStats.Total.ToString()
            lblMembresActifs.Text = membresStats.Actifs.ToString()
            lblMembresInactifs.Text = membresStats.Inactifs.ToString()

            ' Personnel Statistics
            Dim personnelStats = GetPersonnelStatistics()
            lblTotalPersonnel.Text = personnelStats.Total.ToString()
            lblPersonnelActif.Text = personnelStats.Actifs.ToString()
            lblPersonnelInactif.Text = personnelStats.Inactifs.ToString()

            ' Planning Statistics
            Dim planningStats = GetPlanningStatistics()
            lblTotalSeances.Text = planningStats.TotalSeances.ToString()
            lblSeancesOuvertes.Text = planningStats.Ouvertes.ToString()
            lblSeancesCompletes.Text = planningStats.Completes.ToString()
            lblTauxRemplissage.Text = planningStats.TauxRemplissage.ToString("F1") & "%"

            ' Activités Statistics
            Dim activitesStats = GetActivitesStatistics()
            lblTotalActivites.Text = activitesStats.Total.ToString()
            lblActivitesDisponibles.Text = activitesStats.Disponibles.ToString()
            lblActivitesIndisponibles.Text = activitesStats.Indisponibles.ToString()

            ' Abonnements Statistics
            Dim abonnementsStats = GetAbonnementsStatistics()
            lblTotalAbonnements.Text = abonnementsStats.Total.ToString()
            lblAbonnementsPayes.Text = abonnementsStats.Payes.ToString()
            lblAbonnementsImpayes.Text = abonnementsStats.Impayes.ToString()
            lblRevenuTotal.Text = abonnementsStats.RevenuTotal.ToString("F2") & " DT"
            lblRevenuMensuel.Text = abonnementsStats.RevenuMensuel.ToString("F2") & " DT"
            lblRevenuTrimestriel.Text = abonnementsStats.RevenuTrimestriel.ToString("F2") & " DT"
            lblRevenuAnnuel.Text = abonnementsStats.RevenuAnnuel.ToString("F2") & " DT"

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des statistiques: " & ex.Message)
        End Try
    End Sub

    Private Function GetMembresStatistics() As (Total As Integer, Actifs As Integer, Inactifs As Integer)
        Dim total As Integer = 0
        Dim actifs As Integer = 0
        Dim inactifs As Integer = 0

        If File.Exists(membresPath) Then
            Dim lines() As String = File.ReadAllLines(membresPath)
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    total += 1
                    Dim values() As String = lines(i).Split(","c)
                    If values.Length > 6 Then
                        Dim statut As String = values(6).Trim().ToLower()
                        If statut = "actif" Then
                            actifs += 1
                        Else
                            inactifs += 1
                        End If
                    End If
                End If
            Next
        End If

        Return (total, actifs, inactifs)
    End Function

    Private Function GetPersonnelStatistics() As (Total As Integer, Actifs As Integer, Inactifs As Integer)
        Dim total As Integer = 0
        Dim actifs As Integer = 0
        Dim inactifs As Integer = 0

        If File.Exists(personnelPath) Then
            Dim lines() As String = File.ReadAllLines(personnelPath)
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    total += 1
                    Dim values() As String = lines(i).Split(","c)
                    If values.Length > 6 Then
                        Dim statut As String = values(6).Trim().ToLower()
                        If statut = "actif" Then
                            actifs += 1
                        Else
                            inactifs += 1
                        End If
                    End If
                End If
            Next
        End If

        Return (total, actifs, inactifs)
    End Function

    Private Function GetPlanningStatistics() As (TotalSeances As Integer, Ouvertes As Integer, Completes As Integer, TauxRemplissage As Double)
        Dim totalSeances As Integer = 0
        Dim ouvertes As Integer = 0
        Dim completes As Integer = 0
        Dim totalInscrits As Integer = 0
        Dim totalCapacite As Integer = 0

        If File.Exists(planningsPath) Then
            Dim lines() As String = File.ReadAllLines(planningsPath)
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    totalSeances += 1
                    Dim values() As String = lines(i).Split(","c)

                    ' Check status (index 7)
                    If values.Length > 7 Then
                        Dim statut As String = values(7).Trim().ToLower()
                        If statut = "ouvert" Then
                            ouvertes += 1
                        ElseIf statut = "complet" Then
                            completes += 1
                        End If

                        ' Calculate capacity rate (index 5: Capacite, index 6: Inscrits)
                        If values.Length > 6 Then
                            Dim capacite As Integer
                            Dim inscrits As Integer
                            If Integer.TryParse(values(5).Trim(), capacite) AndAlso Integer.TryParse(values(6).Trim(), inscrits) Then
                                totalCapacite += capacite
                                totalInscrits += inscrits
                            End If
                        End If
                    End If
                End If
            Next
        End If

        Dim tauxRemplissage As Double = 0
        If totalCapacite > 0 Then
            tauxRemplissage = (totalInscrits / totalCapacite) * 100
        End If

        Return (totalSeances, ouvertes, completes, tauxRemplissage)
    End Function

    Private Function GetActivitesStatistics() As (Total As Integer, Disponibles As Integer, Indisponibles As Integer)
        Dim total As Integer = 0
        Dim disponibles As Integer = 0
        Dim indisponibles As Integer = 0

        If File.Exists(activitesPath) Then
            Dim lines() As String = File.ReadAllLines(activitesPath)
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    total += 1
                    Dim values() As String = lines(i).Split(","c)
                    If values.Length > 7 Then
                        Dim statut As String = values(7).Trim().ToLower()
                        If statut = "disponible" Then
                            disponibles += 1
                        Else
                            indisponibles += 1
                        End If
                    End If
                End If
            Next
        End If

        Return (total, disponibles, indisponibles)
    End Function

    Private Function GetAbonnementsStatistics() As (Total As Integer, Payes As Integer, Impayes As Integer, RevenuTotal As Double, RevenuMensuel As Double, RevenuTrimestriel As Double, RevenuAnnuel As Double)
        Dim total As Integer = 0
        Dim payes As Integer = 0
        Dim impayes As Integer = 0
        Dim revenuTotal As Double = 0
        Dim revenuMensuel As Double = 0
        Dim revenuTrimestriel As Double = 0
        Dim revenuAnnuel As Double = 0

        If File.Exists(abonnementsPath) Then
            Dim lines() As String = File.ReadAllLines(abonnementsPath)
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    total += 1
                    Dim values() As String = lines(i).Split(","c)

                    ' Status check (index 7)
                    If values.Length > 7 Then
                        Dim statut As String = values(7).Trim().ToLower()
                        If statut = "paye" Then
                            payes += 1

                            ' Add to revenue by type (index 4: Montant, index 1: TypeAbonnement)
                            If values.Length > 4 AndAlso values.Length > 1 Then
                                Dim montant As Double
                                If Double.TryParse(values(4).Trim(), montant) Then
                                    revenuTotal += montant

                                    ' Add to specific type revenue - Use exact match to avoid substring issues
                                    Dim typeAbo As String = values(1).Trim().ToLower()

                                    ' Check exact type (not using Contains to avoid "annuel" matching "mensuel")
                                    If typeAbo = "annuel" Then
                                        revenuAnnuel += montant
                                    ElseIf typeAbo = "trimestriel" Then
                                        revenuTrimestriel += montant
                                    ElseIf typeAbo = "mensuel" Then
                                        revenuMensuel += montant
                                    End If
                                End If
                            End If
                        ElseIf statut = "impaye" OrElse statut = "expire" Then
                            impayes += 1
                        End If
                    End If
                End If
            Next
        End If

        Return (total, payes, impayes, revenuTotal, revenuMensuel, revenuTrimestriel, revenuAnnuel)
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStatistics()
        MessageBox.Show("Statistiques actualisées!", "Actualisation", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
