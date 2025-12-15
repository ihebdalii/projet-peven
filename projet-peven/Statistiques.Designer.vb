<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Statistiques
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        lblMembresInactifs = New Label()
        lblMembresActifs = New Label()
        lblTotalMembres = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        GroupBox2 = New GroupBox()
        lblPersonnelInactif = New Label()
        lblPersonnelActif = New Label()
        lblTotalPersonnel = New Label()
        Label6 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        GroupBox3 = New GroupBox()
        lblTauxRemplissage = New Label()
        Label16 = New Label()
        lblSeancesCompletes = New Label()
        lblSeancesOuvertes = New Label()
        lblTotalSeances = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        GroupBox4 = New GroupBox()
        lblActivitesIndisponibles = New Label()
        lblActivitesDisponibles = New Label()
        lblTotalActivites = New Label()
        Label15 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        GroupBox5 = New GroupBox()
        lblRevenuAnnuel = New Label()
        Label24 = New Label()
        lblRevenuTrimestriel = New Label()
        Label22 = New Label()
        lblRevenuMensuel = New Label()
        Label20 = New Label()
        lblRevenuTotal = New Label()
        Label17 = New Label()
        lblAbonnementsImpayes = New Label()
        lblAbonnementsPayes = New Label()
        lblTotalAbonnements = New Label()
        Label7 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        btnRefresh = New Button()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox5.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Bahnschrift Condensed", 36.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Gold
        Label1.Location = New Point(330, 15)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(217, 58)
        Label1.TabIndex = 2
        Label1.Text = "Statistiques"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(lblMembresInactifs)
        GroupBox1.Controls.Add(lblMembresActifs)
        GroupBox1.Controls.Add(lblTotalMembres)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Font = New Font("Bahnschrift", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.ForeColor = Color.Gold
        GroupBox1.Location = New Point(30, 85)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(280, 130)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Membres"
        ' 
        ' lblMembresInactifs
        ' 
        lblMembresInactifs.AutoSize = True
        lblMembresInactifs.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMembresInactifs.ForeColor = Color.FromArgb(CByte(220), CByte(20), CByte(60))
        lblMembresInactifs.Location = New Point(180, 95)
        lblMembresInactifs.Name = "lblMembresInactifs"
        lblMembresInactifs.Size = New Size(16, 18)
        lblMembresInactifs.TabIndex = 5
        lblMembresInactifs.Text = "0"
        ' 
        ' lblMembresActifs
        ' 
        lblMembresActifs.AutoSize = True
        lblMembresActifs.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMembresActifs.ForeColor = Color.FromArgb(CByte(34), CByte(139), CByte(34))
        lblMembresActifs.Location = New Point(180, 65)
        lblMembresActifs.Name = "lblMembresActifs"
        lblMembresActifs.Size = New Size(16, 18)
        lblMembresActifs.TabIndex = 4
        lblMembresActifs.Text = "0"
        ' 
        ' lblTotalMembres
        ' 
        lblTotalMembres.AutoSize = True
        lblTotalMembres.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalMembres.ForeColor = Color.White
        lblTotalMembres.Location = New Point(180, 30)
        lblTotalMembres.Name = "lblTotalMembres"
        lblTotalMembres.Size = New Size(20, 23)
        lblTotalMembres.TabIndex = 3
        lblTotalMembres.Text = "0"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(20, 95)
        Label5.Name = "Label5"
        Label5.Size = New Size(57, 17)
        Label5.TabIndex = 2
        Label5.Text = "Inactifs:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(20, 65)
        Label4.Name = "Label4"
        Label4.Size = New Size(47, 17)
        Label4.TabIndex = 1
        Label4.Text = "Actifs:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(20, 33)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 18)
        Label3.TabIndex = 0
        Label3.Text = "Total:"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.Transparent
        GroupBox2.Controls.Add(lblPersonnelInactif)
        GroupBox2.Controls.Add(lblPersonnelActif)
        GroupBox2.Controls.Add(lblTotalPersonnel)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Font = New Font("Bahnschrift", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox2.ForeColor = Color.Gold
        GroupBox2.Location = New Point(330, 85)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(280, 130)
        GroupBox2.TabIndex = 6
        GroupBox2.TabStop = False
        GroupBox2.Text = "Personnel"
        ' 
        ' lblPersonnelInactif
        ' 
        lblPersonnelInactif.AutoSize = True
        lblPersonnelInactif.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPersonnelInactif.ForeColor = Color.FromArgb(CByte(220), CByte(20), CByte(60))
        lblPersonnelInactif.Location = New Point(180, 95)
        lblPersonnelInactif.Name = "lblPersonnelInactif"
        lblPersonnelInactif.Size = New Size(16, 18)
        lblPersonnelInactif.TabIndex = 5
        lblPersonnelInactif.Text = "0"
        ' 
        ' lblPersonnelActif
        ' 
        lblPersonnelActif.AutoSize = True
        lblPersonnelActif.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPersonnelActif.ForeColor = Color.FromArgb(CByte(34), CByte(139), CByte(34))
        lblPersonnelActif.Location = New Point(180, 65)
        lblPersonnelActif.Name = "lblPersonnelActif"
        lblPersonnelActif.Size = New Size(16, 18)
        lblPersonnelActif.TabIndex = 4
        lblPersonnelActif.Text = "0"
        ' 
        ' lblTotalPersonnel
        ' 
        lblTotalPersonnel.AutoSize = True
        lblTotalPersonnel.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalPersonnel.ForeColor = Color.White
        lblTotalPersonnel.Location = New Point(180, 30)
        lblTotalPersonnel.Name = "lblTotalPersonnel"
        lblTotalPersonnel.Size = New Size(20, 23)
        lblTotalPersonnel.TabIndex = 3
        lblTotalPersonnel.Text = "0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.White
        Label6.Location = New Point(20, 95)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 17)
        Label6.TabIndex = 2
        Label6.Text = "Inactifs:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.White
        Label8.Location = New Point(20, 65)
        Label8.Name = "Label8"
        Label8.Size = New Size(47, 17)
        Label8.TabIndex = 1
        Label8.Text = "Actifs:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.White
        Label9.Location = New Point(20, 33)
        Label9.Name = "Label9"
        Label9.Size = New Size(42, 18)
        Label9.TabIndex = 0
        Label9.Text = "Total:"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = Color.Transparent
        GroupBox3.Controls.Add(lblTauxRemplissage)
        GroupBox3.Controls.Add(Label16)
        GroupBox3.Controls.Add(lblSeancesCompletes)
        GroupBox3.Controls.Add(lblSeancesOuvertes)
        GroupBox3.Controls.Add(lblTotalSeances)
        GroupBox3.Controls.Add(Label12)
        GroupBox3.Controls.Add(Label13)
        GroupBox3.Controls.Add(Label14)
        GroupBox3.Font = New Font("Bahnschrift", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox3.ForeColor = Color.Gold
        GroupBox3.Location = New Point(630, 85)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(280, 160)
        GroupBox3.TabIndex = 7
        GroupBox3.TabStop = False
        GroupBox3.Text = "Plannings"
        ' 
        ' lblTauxRemplissage
        ' 
        lblTauxRemplissage.AutoSize = True
        lblTauxRemplissage.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTauxRemplissage.ForeColor = Color.Gold
        lblTauxRemplissage.Location = New Point(180, 125)
        lblTauxRemplissage.Name = "lblTauxRemplissage"
        lblTauxRemplissage.Size = New Size(26, 18)
        lblTauxRemplissage.TabIndex = 7
        lblTauxRemplissage.Text = "0%"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = Color.White
        Label16.Location = New Point(20, 125)
        Label16.Name = "Label16"
        Label16.Size = New Size(122, 17)
        Label16.TabIndex = 6
        Label16.Text = "Taux remplissage:"
        ' 
        ' lblSeancesCompletes
        ' 
        lblSeancesCompletes.AutoSize = True
        lblSeancesCompletes.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSeancesCompletes.ForeColor = Color.FromArgb(CByte(255), CByte(140), CByte(0))
        lblSeancesCompletes.Location = New Point(180, 95)
        lblSeancesCompletes.Name = "lblSeancesCompletes"
        lblSeancesCompletes.Size = New Size(16, 18)
        lblSeancesCompletes.TabIndex = 5
        lblSeancesCompletes.Text = "0"
        ' 
        ' lblSeancesOuvertes
        ' 
        lblSeancesOuvertes.AutoSize = True
        lblSeancesOuvertes.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSeancesOuvertes.ForeColor = Color.FromArgb(CByte(34), CByte(139), CByte(34))
        lblSeancesOuvertes.Location = New Point(180, 65)
        lblSeancesOuvertes.Name = "lblSeancesOuvertes"
        lblSeancesOuvertes.Size = New Size(16, 18)
        lblSeancesOuvertes.TabIndex = 4
        lblSeancesOuvertes.Text = "0"
        ' 
        ' lblTotalSeances
        ' 
        lblTotalSeances.AutoSize = True
        lblTotalSeances.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalSeances.ForeColor = Color.White
        lblTotalSeances.Location = New Point(180, 30)
        lblTotalSeances.Name = "lblTotalSeances"
        lblTotalSeances.Size = New Size(20, 23)
        lblTotalSeances.TabIndex = 3
        lblTotalSeances.Text = "0"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.White
        Label12.Location = New Point(20, 95)
        Label12.Name = "Label12"
        Label12.Size = New Size(80, 17)
        Label12.TabIndex = 2
        Label12.Text = "Complètes:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.White
        Label13.Location = New Point(20, 65)
        Label13.Name = "Label13"
        Label13.Size = New Size(69, 17)
        Label13.TabIndex = 1
        Label13.Text = "Ouvertes:"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.White
        Label14.Location = New Point(20, 33)
        Label14.Name = "Label14"
        Label14.Size = New Size(42, 18)
        Label14.TabIndex = 0
        Label14.Text = "Total:"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.BackColor = Color.Transparent
        GroupBox4.Controls.Add(lblActivitesIndisponibles)
        GroupBox4.Controls.Add(lblActivitesDisponibles)
        GroupBox4.Controls.Add(lblTotalActivites)
        GroupBox4.Controls.Add(Label15)
        GroupBox4.Controls.Add(Label18)
        GroupBox4.Controls.Add(Label19)
        GroupBox4.Font = New Font("Bahnschrift", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox4.ForeColor = Color.Gold
        GroupBox4.Location = New Point(30, 230)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(280, 130)
        GroupBox4.TabIndex = 7
        GroupBox4.TabStop = False
        GroupBox4.Text = "Activités Sportives"
        ' 
        ' lblActivitesIndisponibles
        ' 
        lblActivitesIndisponibles.AutoSize = True
        lblActivitesIndisponibles.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActivitesIndisponibles.ForeColor = Color.FromArgb(CByte(220), CByte(20), CByte(60))
        lblActivitesIndisponibles.Location = New Point(180, 95)
        lblActivitesIndisponibles.Name = "lblActivitesIndisponibles"
        lblActivitesIndisponibles.Size = New Size(16, 18)
        lblActivitesIndisponibles.TabIndex = 5
        lblActivitesIndisponibles.Text = "0"
        ' 
        ' lblActivitesDisponibles
        ' 
        lblActivitesDisponibles.AutoSize = True
        lblActivitesDisponibles.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActivitesDisponibles.ForeColor = Color.FromArgb(CByte(34), CByte(139), CByte(34))
        lblActivitesDisponibles.Location = New Point(180, 65)
        lblActivitesDisponibles.Name = "lblActivitesDisponibles"
        lblActivitesDisponibles.Size = New Size(16, 18)
        lblActivitesDisponibles.TabIndex = 4
        lblActivitesDisponibles.Text = "0"
        ' 
        ' lblTotalActivites
        ' 
        lblTotalActivites.AutoSize = True
        lblTotalActivites.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalActivites.ForeColor = Color.White
        lblTotalActivites.Location = New Point(180, 30)
        lblTotalActivites.Name = "lblTotalActivites"
        lblTotalActivites.Size = New Size(20, 23)
        lblTotalActivites.TabIndex = 3
        lblTotalActivites.Text = "0"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.White
        Label15.Location = New Point(20, 65)
        Label15.Name = "Label15"
        Label15.Size = New Size(86, 17)
        Label15.TabIndex = 1
        Label15.Text = "Disponibles:"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.White
        Label18.Location = New Point(20, 95)
        Label18.Name = "Label18"
        Label18.Size = New Size(97, 17)
        Label18.TabIndex = 2
        Label18.Text = "Indisponibles:"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.White
        Label19.Location = New Point(20, 33)
        Label19.Name = "Label19"
        Label19.Size = New Size(42, 18)
        Label19.TabIndex = 0
        Label19.Text = "Total:"
        ' 
        ' GroupBox5
        ' 
        GroupBox5.BackColor = Color.Transparent
        GroupBox5.Controls.Add(lblRevenuAnnuel)
        GroupBox5.Controls.Add(Label24)
        GroupBox5.Controls.Add(lblRevenuTrimestriel)
        GroupBox5.Controls.Add(Label22)
        GroupBox5.Controls.Add(lblRevenuMensuel)
        GroupBox5.Controls.Add(Label20)
        GroupBox5.Controls.Add(lblRevenuTotal)
        GroupBox5.Controls.Add(Label17)
        GroupBox5.Controls.Add(lblAbonnementsImpayes)
        GroupBox5.Controls.Add(lblAbonnementsPayes)
        GroupBox5.Controls.Add(lblTotalAbonnements)
        GroupBox5.Controls.Add(Label7)
        GroupBox5.Controls.Add(Label10)
        GroupBox5.Controls.Add(Label11)
        GroupBox5.Font = New Font("Bahnschrift", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox5.ForeColor = Color.Gold
        GroupBox5.Location = New Point(330, 230)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(580, 160)
        GroupBox5.TabIndex = 8
        GroupBox5.TabStop = False
        GroupBox5.Text = "Abonnements et Paiements"
        ' 
        ' lblRevenuAnnuel
        ' 
        lblRevenuAnnuel.AutoSize = True
        lblRevenuAnnuel.Font = New Font("Bahnschrift", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRevenuAnnuel.ForeColor = Color.Gold
        lblRevenuAnnuel.Location = New Point(480, 125)
        lblRevenuAnnuel.Name = "lblRevenuAnnuel"
        lblRevenuAnnuel.Size = New Size(16, 17)
        lblRevenuAnnuel.TabIndex = 13
        lblRevenuAnnuel.Text = "0"
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label24.ForeColor = Color.White
        Label24.Location = New Point(305, 125)
        Label24.Name = "Label24"
        Label24.Size = New Size(56, 17)
        Label24.TabIndex = 12
        Label24.Text = "Annuel:"
        ' 
        ' lblRevenuTrimestriel
        ' 
        lblRevenuTrimestriel.AutoSize = True
        lblRevenuTrimestriel.Font = New Font("Bahnschrift", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRevenuTrimestriel.ForeColor = Color.Gold
        lblRevenuTrimestriel.Location = New Point(480, 95)
        lblRevenuTrimestriel.Name = "lblRevenuTrimestriel"
        lblRevenuTrimestriel.Size = New Size(16, 17)
        lblRevenuTrimestriel.TabIndex = 11
        lblRevenuTrimestriel.Text = "0"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label22.ForeColor = Color.White
        Label22.Location = New Point(305, 95)
        Label22.Name = "Label22"
        Label22.Size = New Size(81, 17)
        Label22.TabIndex = 10
        Label22.Text = "Trimestriel:"
        ' 
        ' lblRevenuMensuel
        ' 
        lblRevenuMensuel.AutoSize = True
        lblRevenuMensuel.Font = New Font("Bahnschrift", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRevenuMensuel.ForeColor = Color.Gold
        lblRevenuMensuel.Location = New Point(480, 65)
        lblRevenuMensuel.Name = "lblRevenuMensuel"
        lblRevenuMensuel.Size = New Size(16, 17)
        lblRevenuMensuel.TabIndex = 9
        lblRevenuMensuel.Text = "0"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = Color.White
        Label20.Location = New Point(305, 65)
        Label20.Name = "Label20"
        Label20.Size = New Size(65, 17)
        Label20.TabIndex = 8
        Label20.Text = "Mensuel:"
        ' 
        ' lblRevenuTotal
        ' 
        lblRevenuTotal.AutoSize = True
        lblRevenuTotal.Font = New Font("Bahnschrift", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRevenuTotal.ForeColor = Color.Gold
        lblRevenuTotal.Location = New Point(480, 30)
        lblRevenuTotal.Name = "lblRevenuTotal"
        lblRevenuTotal.Size = New Size(40, 19)
        lblRevenuTotal.TabIndex = 7
        lblRevenuTotal.Text = "0.00"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(305, 30)
        Label17.Name = "Label17"
        Label17.Size = New Size(96, 18)
        Label17.TabIndex = 6
        Label17.Text = "Revenu Total:"
        ' 
        ' lblAbonnementsImpayes
        ' 
        lblAbonnementsImpayes.AutoSize = True
        lblAbonnementsImpayes.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAbonnementsImpayes.ForeColor = Color.FromArgb(CByte(220), CByte(20), CByte(60))
        lblAbonnementsImpayes.Location = New Point(180, 95)
        lblAbonnementsImpayes.Name = "lblAbonnementsImpayes"
        lblAbonnementsImpayes.Size = New Size(16, 18)
        lblAbonnementsImpayes.TabIndex = 5
        lblAbonnementsImpayes.Text = "0"
        ' 
        ' lblAbonnementsPayes
        ' 
        lblAbonnementsPayes.AutoSize = True
        lblAbonnementsPayes.Font = New Font("Bahnschrift", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAbonnementsPayes.ForeColor = Color.FromArgb(CByte(34), CByte(139), CByte(34))
        lblAbonnementsPayes.Location = New Point(180, 65)
        lblAbonnementsPayes.Name = "lblAbonnementsPayes"
        lblAbonnementsPayes.Size = New Size(16, 18)
        lblAbonnementsPayes.TabIndex = 4
        lblAbonnementsPayes.Text = "0"
        ' 
        ' lblTotalAbonnements
        ' 
        lblTotalAbonnements.AutoSize = True
        lblTotalAbonnements.Font = New Font("Bahnschrift", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalAbonnements.ForeColor = Color.White
        lblTotalAbonnements.Location = New Point(180, 30)
        lblTotalAbonnements.Name = "lblTotalAbonnements"
        lblTotalAbonnements.Size = New Size(20, 23)
        lblTotalAbonnements.TabIndex = 3
        lblTotalAbonnements.Text = "0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.White
        Label7.Location = New Point(20, 95)
        Label7.Name = "Label7"
        Label7.Size = New Size(64, 17)
        Label7.TabIndex = 2
        Label7.Text = "Impayés:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Bahnschrift", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(20, 65)
        Label10.Name = "Label10"
        Label10.Size = New Size(49, 17)
        Label10.TabIndex = 1
        Label10.Text = "Payés:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(20, 33)
        Label11.Name = "Label11"
        Label11.Size = New Size(42, 18)
        Label11.TabIndex = 0
        Label11.Text = "Total:"
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.Transparent
        btnRefresh.FlatAppearance.BorderColor = Color.Gold
        btnRefresh.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnRefresh.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Bahnschrift", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRefresh.ForeColor = Color.Snow
        btnRefresh.Location = New Point(395, 400)
        btnRefresh.Margin = New Padding(2, 1, 2, 1)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(150, 40)
        btnRefresh.TabIndex = 9
        btnRefresh.Text = "Actualiser"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' Statistiques
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        BackgroundImage = My.Resources.Resources._834264
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(950, 450)
        Controls.Add(btnRefresh)
        Controls.Add(GroupBox5)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        Margin = New Padding(2, 1, 2, 1)
        Name = "Statistiques"
        Text = "Statistiques"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblMembresInactifs As Label
    Friend WithEvents lblMembresActifs As Label
    Friend WithEvents lblTotalMembres As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblPersonnelInactif As Label
    Friend WithEvents lblPersonnelActif As Label
    Friend WithEvents lblTotalPersonnel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblSeancesCompletes As Label
    Friend WithEvents lblSeancesOuvertes As Label
    Friend WithEvents lblTotalSeances As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblActivitesIndisponibles As Label
    Friend WithEvents lblActivitesDisponibles As Label
    Friend WithEvents lblTotalActivites As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lblAbonnementsImpayes As Label
    Friend WithEvents lblAbonnementsPayes As Label
    Friend WithEvents lblTotalAbonnements As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblRevenuTotal As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblTauxRemplissage As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblRevenuMensuel As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lblRevenuAnnuel As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblRevenuTrimestriel As Label
    Friend WithEvents Label22 As Label
End Class
