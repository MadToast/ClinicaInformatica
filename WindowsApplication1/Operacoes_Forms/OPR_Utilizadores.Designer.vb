﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPR_Utilizadores
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
        Me.RadButton4 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton5 = New Telerik.WinControls.UI.RadButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nomeutilizadorbox = New System.Windows.Forms.TextBox()
        Me.passwordbox = New System.Windows.Forms.TextBox()
        Me.numalunobox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tecnicobox = New System.Windows.Forms.ComboBox()
        Me.addtecnicobox = New Telerik.WinControls.UI.RadButton()
        Me.empresabox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.simcheck = New System.Windows.Forms.RadioButton()
        Me.naocheck = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.admincheck = New System.Windows.Forms.CheckBox()
        Me.admgeralcheck = New System.Windows.Forms.CheckBox()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.addtecnicobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadButton4
        '
        Me.RadButton4.Location = New System.Drawing.Point(629, 537)
        Me.RadButton4.Name = "RadButton4"
        Me.RadButton4.Size = New System.Drawing.Size(75, 63)
        Me.RadButton4.TabIndex = 78
        Me.RadButton4.Text = "Cancelar"
        '
        'RadButton3
        '
        Me.RadButton3.Location = New System.Drawing.Point(487, 537)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(75, 63)
        Me.RadButton3.TabIndex = 77
        Me.RadButton3.Text = "Restaurar Dados Originais"
        Me.RadButton3.TextWrap = True
        '
        'RadButton2
        '
        Me.RadButton2.Location = New System.Drawing.Point(350, 537)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(75, 63)
        Me.RadButton2.TabIndex = 76
        Me.RadButton2.Text = "Remover"
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(201, 537)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(75, 63)
        Me.RadButton1.TabIndex = 75
        Me.RadButton1.Text = "Editar"
        '
        'RadButton5
        '
        Me.RadButton5.Location = New System.Drawing.Point(51, 537)
        Me.RadButton5.Name = "RadButton5"
        Me.RadButton5.Size = New System.Drawing.Size(75, 63)
        Me.RadButton5.TabIndex = 74
        Me.RadButton5.Text = "Adicionar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(54, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(371, 86)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Utilizadores"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.Label3.Location = New System.Drawing.Point(18, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 23)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Nome de Utilizador"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 25)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Técnico"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 25)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "NºAluno"
        '
        'nomeutilizadorbox
        '
        Me.nomeutilizadorbox.Location = New System.Drawing.Point(22, 71)
        Me.nomeutilizadorbox.Name = "nomeutilizadorbox"
        Me.nomeutilizadorbox.Size = New System.Drawing.Size(275, 33)
        Me.nomeutilizadorbox.TabIndex = 69
        '
        'passwordbox
        '
        Me.passwordbox.Location = New System.Drawing.Point(22, 146)
        Me.passwordbox.Name = "passwordbox"
        Me.passwordbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordbox.Size = New System.Drawing.Size(275, 33)
        Me.passwordbox.TabIndex = 68
        '
        'numalunobox
        '
        Me.numalunobox.Location = New System.Drawing.Point(130, 129)
        Me.numalunobox.Name = "numalunobox"
        Me.numalunobox.Size = New System.Drawing.Size(136, 20)
        Me.numalunobox.TabIndex = 66
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.Label4.Location = New System.Drawing.Point(18, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 23)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Password"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.admgeralcheck)
        Me.GroupBox1.Controls.Add(Me.admincheck)
        Me.GroupBox1.Controls.Add(Me.nomeutilizadorbox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.passwordbox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(229, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 250)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informações da Conta"
        '
        'tecnicobox
        '
        Me.tecnicobox.FormattingEnabled = True
        Me.tecnicobox.Location = New System.Drawing.Point(130, 208)
        Me.tecnicobox.Name = "tecnicobox"
        Me.tecnicobox.Size = New System.Drawing.Size(168, 21)
        Me.tecnicobox.TabIndex = 84
        '
        'addtecnicobox
        '
        Me.addtecnicobox.Location = New System.Drawing.Point(314, 208)
        Me.addtecnicobox.Name = "addtecnicobox"
        Me.addtecnicobox.Size = New System.Drawing.Size(111, 21)
        Me.addtecnicobox.TabIndex = 85
        Me.addtecnicobox.Text = "Adicionar técnico"
        '
        'empresabox
        '
        Me.empresabox.FormattingEnabled = True
        Me.empresabox.Location = New System.Drawing.Point(553, 206)
        Me.empresabox.Name = "empresabox"
        Me.empresabox.Size = New System.Drawing.Size(121, 21)
        Me.empresabox.TabIndex = 87
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(460, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 25)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Empresa"
        '
        'simcheck
        '
        Me.simcheck.AutoSize = True
        Me.simcheck.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.simcheck.Location = New System.Drawing.Point(296, 172)
        Me.simcheck.Name = "simcheck"
        Me.simcheck.Size = New System.Drawing.Size(49, 21)
        Me.simcheck.TabIndex = 88
        Me.simcheck.TabStop = True
        Me.simcheck.Text = "Sim"
        Me.simcheck.UseVisualStyleBackColor = True
        '
        'naocheck
        '
        Me.naocheck.AutoSize = True
        Me.naocheck.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.naocheck.Location = New System.Drawing.Point(239, 172)
        Me.naocheck.Name = "naocheck"
        Me.naocheck.Size = New System.Drawing.Size(51, 21)
        Me.naocheck.TabIndex = 89
        Me.naocheck.TabStop = True
        Me.naocheck.Text = "Não"
        Me.naocheck.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(212, 25)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "O Utilizador é Técnico?"
        '
        'admincheck
        '
        Me.admincheck.AutoSize = True
        Me.admincheck.Location = New System.Drawing.Point(22, 197)
        Me.admincheck.Name = "admincheck"
        Me.admincheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.admincheck.Size = New System.Drawing.Size(90, 29)
        Me.admincheck.TabIndex = 73
        Me.admincheck.Text = "Admin"
        Me.admincheck.UseVisualStyleBackColor = True
        '
        'admgeralcheck
        '
        Me.admgeralcheck.AutoSize = True
        Me.admgeralcheck.Location = New System.Drawing.Point(155, 197)
        Me.admgeralcheck.Name = "admgeralcheck"
        Me.admgeralcheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.admgeralcheck.Size = New System.Drawing.Size(142, 29)
        Me.admgeralcheck.TabIndex = 74
        Me.admgeralcheck.Text = "Admin Geral"
        Me.admgeralcheck.UseVisualStyleBackColor = True
        '
        'OPR_Utilizadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(719, 620)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.naocheck)
        Me.Controls.Add(Me.simcheck)
        Me.Controls.Add(Me.empresabox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.addtecnicobox)
        Me.Controls.Add(Me.tecnicobox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RadButton4)
        Me.Controls.Add(Me.RadButton3)
        Me.Controls.Add(Me.RadButton2)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.RadButton5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numalunobox)
        Me.Name = "OPR_Utilizadores"
        Me.Text = "Operações Utilizadores"
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.addtecnicobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadButton4 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton5 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nomeutilizadorbox As System.Windows.Forms.TextBox
    Friend WithEvents passwordbox As System.Windows.Forms.TextBox
    Friend WithEvents numalunobox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tecnicobox As System.Windows.Forms.ComboBox
    Friend WithEvents addtecnicobox As Telerik.WinControls.UI.RadButton
    Friend WithEvents empresabox As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents simcheck As System.Windows.Forms.RadioButton
    Friend WithEvents naocheck As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents admgeralcheck As System.Windows.Forms.CheckBox
    Friend WithEvents admincheck As System.Windows.Forms.CheckBox
End Class
