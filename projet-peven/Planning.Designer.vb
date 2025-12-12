<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Planning
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
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Bahnschrift Condensed", 36.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Gold
        Label1.Location = New Point(265, 18)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(376, 58)
        Label1.TabIndex = 2
        Label1.Text = "Gestion des Plannings"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Transparent
        Button2.FlatAppearance.BorderColor = Color.Gold
        Button2.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button2.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Bahnschrift", 10.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.Snow
        Button2.Location = New Point(167, 74)
        Button2.Margin = New Padding(2, 1, 2, 1)
        Button2.Name = "Button2"
        Button2.Size = New Size(191, 44)
        Button2.TabIndex = 5
        Button2.Text = "Ajouter Planning"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = SystemColors.ActiveCaptionText
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(46, 135)
        DataGridView1.Margin = New Padding(2, 1, 2, 1)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 82
        DataGridView1.Size = New Size(873, 211)
        DataGridView1.TabIndex = 6
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.FlatAppearance.BorderColor = Color.Gold
        Button1.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button1.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Bahnschrift", 10.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.Snow
        Button1.Location = New Point(401, 74)
        Button1.Margin = New Padding(2, 1, 2, 1)
        Button1.Name = "Button1"
        Button1.Size = New Size(191, 44)
        Button1.TabIndex = 7
        Button1.Text = "Supprimer"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Transparent
        Button3.FlatAppearance.BorderColor = Color.Gold
        Button3.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button3.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Bahnschrift", 10.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.Snow
        Button3.Location = New Point(633, 74)
        Button3.Margin = New Padding(2, 1, 2, 1)
        Button3.Name = "Button3"
        Button3.Size = New Size(191, 44)
        Button3.TabIndex = 8
        Button3.Text = "Sauvegarder"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Transparent
        Button4.FlatAppearance.BorderColor = Color.Gold
        Button4.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button4.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Bahnschrift", 10.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.Snow
        Button4.Location = New Point(271, 358)
        Button4.Margin = New Padding(2, 1, 2, 1)
        Button4.Name = "Button4"
        Button4.Size = New Size(191, 44)
        Button4.TabIndex = 9
        Button4.Text = "Ouvert"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.Transparent
        Button5.FlatAppearance.BorderColor = Color.Gold
        Button5.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button5.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Bahnschrift", 10.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = Color.Snow
        Button5.Location = New Point(500, 358)
        Button5.Margin = New Padding(2, 1, 2, 1)
        Button5.Name = "Button5"
        Button5.Size = New Size(191, 44)
        Button5.TabIndex = 10
        Button5.Text = "Annulé"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Planning
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources._834264
        ClientSize = New Size(967, 418)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Margin = New Padding(2, 1, 2, 1)
        Name = "Planning"
        Text = "Planning"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
