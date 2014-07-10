﻿
Option Explicit On

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security

Public Class Passo3emeio
    
    Public Event ColourizationChanged As EventHandler(Of ColorizationChangedEventArgs)

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_DWMCOLORIZATIONCOLORCHANGED As Integer = 800
        If m.Msg = WM_DWMCOLORIZATIONCOLORCHANGED Then
            Dim l As Boolean = (m.LParam.ToInt32 = 0)
            Dim w As Integer = m.WParam.ToInt32
            Dim c As New Colorization(w, l)
            Dim args As New ColorizationChangedEventArgs(c)
            RaiseEvent ColourizationChanged(Me, args)
        End If
        Try
            MyBase.WndProc(m)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Colorization.OsSupportsAero Then SetBackColor(Colorization.GetDwmColorization)
        Label1.Show()
        Timer1.Start()
        MaximizeBox = False
        MinimizeBox = False
        Me.AcceptButton = Button1
    End Sub

    Private Sub Form1_ColourizationChanged(ByVal sender As Object, ByVal e As ColorizationChangedEventArgs) Handles Me.ColourizationChanged
        SetBackColor(e.Colorization)
    End Sub

    Private Sub SetBackColor(ByVal colorization As Colorization)
        If colorization.Color.ToArgb <> Color.FromArgb(0, 0, 0, 0).ToArgb Then
            Me.BackColor = colorization.SolidColor ' alpha is set to 255.
        Else
            Me.BackColor = Color.White
        End If
        Label1.ForeColor = colorization.Inversecolor
        Label2.ForeColor = colorization.Inversecolor
        passlabel.ForeColor = colorization.Inversecolor
        nomelabel.ForeColor = colorization.Inversecolor
        Label3.ForeColor = colorization.Inversecolor
        Label4.ForeColor = colorization.Inversecolor
        Label5.ForeColor = colorization.Inversecolor
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Colorization.OsSupportsAero Then SetBackColor(Colorization.GetDwmColorization)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim check_nome, check_pass, check_pergunta, check_resposta As String
            Try
                check_nome = nomebox.Text
                check_nome.Trim()
                If passbox.Text = verifbox.Text Then
                    check_pass = passbox.Text
                    check_pass.Trim()
                Else
                    check_pass = ""
                End If
                check_pergunta = perguntabox.Text
                check_pergunta.Trim()
                check_resposta = respostabox.Text
                check_resposta.Trim()
            Catch
            End Try
            If Not check_nome = "" And Not check_pass = "" And Not check_pergunta = "" And Not check_resposta = "" Then
                Dim password As String = passbox.Text
                Dim wrapper As New Simple3Des("ODASONSNIAJCNDICAOSJDCNSNCASNDNCJNSAKJCBNKJSBDNJCBASKJDBKJASBKJCBSAKDBCHJBJK")
                Dim passencript As String = wrapper.EncryptData(password)
                Dim perguntastring As String = wrapper.EncryptData(perguntabox.Text)
                Dim respostastring As String = wrapper.EncryptData(respostabox.Text)
                BLL.n_empresa = "1"
                If BLL.Admin_only.Login.check_exist(nomebox.Text) = 0 Then
                    BLL.Admin_only.Login.Add_login_non_student_noadmin(perguntastring, respostastring, True, nomebox.Text, passencript, BLL.n_empresa)
                    Workspace.config4.Show()
                    Me.Close()
                Else
                    MsgBox("O Administrador não pode ter o mesmo nome que o Administrador Geral.")
                End If
            Else
                MsgBox("Preencha todos os dados corretamente!", vbOKOnly, "Erro")
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro na Aplicação: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nomebox.Text = ""
        passbox.Text = ""
        verifbox.Text = ""
        perguntabox.Text = ""
        respostabox.Text = ""
    End Sub
End Class