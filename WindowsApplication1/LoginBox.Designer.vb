﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: O procedimento a seguir é exigido pelo Windows Form Designer
    'Ele pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Usernamelabel = New System.Windows.Forms.Label()
        Me.passwordlabel = New System.Windows.Forms.Label()
        Me.loginbutton = New System.Windows.Forms.Button()
        Me.exitbutton = New System.Windows.Forms.Button()
        Me.buttonhelp = New System.Windows.Forms.Button()
        Me.languagelabel = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Companybox = New System.Windows.Forms.ComboBox()
        Me.Companylabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Titlelabel2 = New System.Windows.Forms.Label()
        Me.Titlelabel1 = New System.Windows.Forms.Label()
        Me.Passwordbox = New ClinicaInformatica.WaterMarkTextBox()
        Me.UsernameBox = New ClinicaInformatica.WaterMarkTextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Usernamelabel
        '
        Me.Usernamelabel.AutoSize = True
        Me.Usernamelabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Usernamelabel.Location = New System.Drawing.Point(7, 104)
        Me.Usernamelabel.Name = "Usernamelabel"
        Me.Usernamelabel.Size = New System.Drawing.Size(148, 21)
        Me.Usernamelabel.TabIndex = 2
        Me.Usernamelabel.Text = "Nome de Utilizador:"
        '
        'passwordlabel
        '
        Me.passwordlabel.AutoSize = True
        Me.passwordlabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordlabel.Location = New System.Drawing.Point(7, 156)
        Me.passwordlabel.Name = "passwordlabel"
        Me.passwordlabel.Size = New System.Drawing.Size(77, 21)
        Me.passwordlabel.TabIndex = 4
        Me.passwordlabel.Text = "Password"
        '
        'loginbutton
        '
        Me.loginbutton.Location = New System.Drawing.Point(466, 283)
        Me.loginbutton.Name = "loginbutton"
        Me.loginbutton.Size = New System.Drawing.Size(58, 60)
        Me.loginbutton.TabIndex = 5
        Me.loginbutton.UseVisualStyleBackColor = True
        '
        'exitbutton
        '
        Me.exitbutton.Location = New System.Drawing.Point(402, 283)
        Me.exitbutton.Name = "exitbutton"
        Me.exitbutton.Size = New System.Drawing.Size(58, 60)
        Me.exitbutton.TabIndex = 6
        Me.exitbutton.UseVisualStyleBackColor = True
        '
        'buttonhelp
        '
        Me.buttonhelp.Location = New System.Drawing.Point(12, 283)
        Me.buttonhelp.Name = "buttonhelp"
        Me.buttonhelp.Size = New System.Drawing.Size(58, 60)
        Me.buttonhelp.TabIndex = 7
        Me.buttonhelp.UseVisualStyleBackColor = True
        '
        'languagelabel
        '
        Me.languagelabel.AutoSize = True
        Me.languagelabel.Location = New System.Drawing.Point(400, 9)
        Me.languagelabel.Name = "languagelabel"
        Me.languagelabel.Size = New System.Drawing.Size(62, 13)
        Me.languagelabel.TabIndex = 8
        Me.languagelabel.Text = "Linguagem:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Português", "English", "Français", "Español"})
        Me.ComboBox1.Location = New System.Drawing.Point(403, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'Companybox
        '
        Me.Companybox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Companybox.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Companybox.FormattingEnabled = True
        Me.Companybox.Items.AddRange(New Object() {"Português", "English", "Français", "Español"})
        Me.Companybox.Location = New System.Drawing.Point(12, 244)
        Me.Companybox.Name = "Companybox"
        Me.Companybox.Size = New System.Drawing.Size(213, 25)
        Me.Companybox.TabIndex = 11
        '
        'Companylabel
        '
        Me.Companylabel.AutoSize = True
        Me.Companylabel.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Companylabel.Location = New System.Drawing.Point(8, 224)
        Me.Companylabel.Name = "Companylabel"
        Me.Companylabel.Size = New System.Drawing.Size(62, 17)
        Me.Companylabel.TabIndex = 10
        Me.Companylabel.Text = "Empresa:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ClinicaInformatica.My.Resources.Resources.icone_programa
        Me.PictureBox1.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Titlelabel2
        '
        Me.Titlelabel2.AutoSize = True
        Me.Titlelabel2.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titlelabel2.Location = New System.Drawing.Point(71, 34)
        Me.Titlelabel2.Name = "Titlelabel2"
        Me.Titlelabel2.Size = New System.Drawing.Size(283, 45)
        Me.Titlelabel2.TabIndex = 13
        Me.Titlelabel2.Text = "Clínica Informática"
        '
        'Titlelabel1
        '
        Me.Titlelabel1.AutoSize = True
        Me.Titlelabel1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titlelabel1.Location = New System.Drawing.Point(71, -1)
        Me.Titlelabel1.Name = "Titlelabel1"
        Me.Titlelabel1.Size = New System.Drawing.Size(119, 45)
        Me.Titlelabel1.TabIndex = 14
        Me.Titlelabel1.Text = "Gestão"
        '
        'Passwordbox
        '
        Me.Passwordbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Passwordbox.Location = New System.Drawing.Point(11, 180)
        Me.Passwordbox.Name = "Passwordbox"
        Me.Passwordbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Passwordbox.Size = New System.Drawing.Size(213, 25)
        Me.Passwordbox.TabIndex = 3
        Me.Passwordbox.WaterMarkColor = System.Drawing.Color.Gray
        Me.Passwordbox.WaterMarkText = "Password"
        '
        'UsernameBox
        '
        Me.UsernameBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameBox.Location = New System.Drawing.Point(12, 128)
        Me.UsernameBox.Name = "UsernameBox"
        Me.UsernameBox.Size = New System.Drawing.Size(213, 25)
        Me.UsernameBox.TabIndex = 1
        Me.UsernameBox.WaterMarkColor = System.Drawing.Color.Gray
        Me.UsernameBox.WaterMarkText = "Nome de Utilizador"
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 355)
        Me.Controls.Add(Me.Titlelabel1)
        Me.Controls.Add(Me.Titlelabel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Companybox)
        Me.Controls.Add(Me.Companylabel)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.languagelabel)
        Me.Controls.Add(Me.buttonhelp)
        Me.Controls.Add(Me.exitbutton)
        Me.Controls.Add(Me.loginbutton)
        Me.Controls.Add(Me.passwordlabel)
        Me.Controls.Add(Me.Passwordbox)
        Me.Controls.Add(Me.Usernamelabel)
        Me.Controls.Add(Me.UsernameBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "LoginForm"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsernameBox As ClinicaInformatica.WaterMarkTextBox
    Friend WithEvents Usernamelabel As System.Windows.Forms.Label
    Friend WithEvents passwordlabel As System.Windows.Forms.Label
    Friend WithEvents Passwordbox As ClinicaInformatica.WaterMarkTextBox
    Friend WithEvents loginbutton As System.Windows.Forms.Button
    Friend WithEvents exitbutton As System.Windows.Forms.Button
    Friend WithEvents buttonhelp As System.Windows.Forms.Button
    Friend WithEvents languagelabel As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Companybox As System.Windows.Forms.ComboBox
    Friend WithEvents Companylabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Titlelabel2 As System.Windows.Forms.Label
    Friend WithEvents Titlelabel1 As System.Windows.Forms.Label

End Class
