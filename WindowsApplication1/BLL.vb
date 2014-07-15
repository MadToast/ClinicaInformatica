﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class BLL
    Public Shared n_empresa As String

    Public Class Admin_only
        Shared Sub eliminar_empresa(ByVal nempresa As Integer)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", nempresa))
            DAL.ExecuteNonQuery("Delete FROM Utilizadores where NºEmpresa=@n_empresa", p)
            DAL.ExecuteNonQuery("Delete FROM Técnicos where NºEmpresa=@n_empresa", p)
            DAL.ExecuteNonQuery("Delete FROM Clientes where NºEmpresa=@n_empresa", p)
            DAL.ExecuteNonQuery("Delete FROM Artigos where NºEmpresa=@n_empresa", p)
            DAL.ExecuteNonQuery("Delete FROM Reparações where NºEmpresa=@n_empresa", p)
            DAL.ExecuteNonQuery("Delete FROM Empresas where NºEmpresa=@n_empresa", p)
        End Sub
        
        Public Class Login
            Shared Function return_p_r(ByVal nome_de_utilizador As String) As ArrayList
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", nome_de_utilizador))
                Return DAL.ExecuteQuery("Select Pergunta_S, Resposta_S,Password from utilizadores where convert(varbinary,Nome_Util) = convert(varbinary,@user)", p)
            End Function
            Shared Sub remove_login(ByVal id As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", id))
                DAL.ExecuteNonQuery("Update Utilizadores set Ativo=0 where Cod_Utilizador=@user", p)
            End Sub
            Shared Sub restore_login(ByVal id As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", id))
                DAL.ExecuteNonQuery("Update Utilizadores set Ativo=1 where Cod_Utilizador=@user", p)
            End Sub
            Shared Function check_exist(ByVal nome As String) As Object
                Dim check As Integer
                Dim p As New ArrayList
                p.Add(New SqlParameter("@nome", nome))
                check = DAL.ExecuteScalar("Select Cod_Utilizador FROM Utilizadores where Nome_util=@Nome", p)
                If check <> 0 Then
                    Return 1
                Else
                    Return 0
                End If
            End Function
            Shared Function check_admin_geral() As Object
                Return DAL.ExecuteScalar("Select COUNT(Cod_Utilizador) FROM Utilizadores WHERE Admin_Geral=1", Nothing)
            End Function
            Shared Function procura_dados_nutilizador_desativados(ByRef Nome_Util As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome_Util", Nome_Util))
                If Nome_Util = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Nome_Util like @Nome_Util AND Ativo=0", p)
                End If
            End Function
            Shared Function procura_dados_nutilizador_ativados(ByRef Nome_Util As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome_Util", Nome_Util))
                If Nome_Util = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Nome_Util like @Nome_Util AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_codutilizador_desativados(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador like @Cod_Utilizador AND Ativo=0", p)
                End If
            End Function
            Shared Function procura_dados_codutilizador_ativados(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador like @Cod_Utilizador AND Ativo=1", p)
                End If
            End Function
            Shared Function carregar_dados_codutilizador_desativados(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,Password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,Password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador like @Cod_Utilizador AND Ativo=0", p)
                End If
            End Function
            Shared Function carregar_dados_codutilizador_ativados(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,Password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,Password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador like @Cod_Utilizador AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_ntecnico(ByVal id As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", id))
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,admin,admin_geral FROM Utilizadores where NºTécnico like @user AND Ativo=1", p)
            End Function
            Shared Function procura_dados_tecnico_desativados(ByVal id As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", id))
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,admin,admin_geral FROM Utilizadores where NºTécnico like @user AND Ativo=0", p)
            End Function
            Shared Function procura_dados_nutilizador_ativados_empresa(ByRef Nome_Util As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome_Util", Nome_Util))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If Nome_Util = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=1 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Nome_Util like @Nome_Util AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_nutilizador_desativados_empresa(ByRef Nome_Util As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome_Util", Nome_Util))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If Nome_Util = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Nome_Util like @Nome_Util AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function carregar_utilizador_ativados_empresa(ByRef user As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", user))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If user = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,Password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=1 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador = @user AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function carregar_utilizador_desativados_empresa(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util,password,Pergunta_S,Resposta_S, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador= @Cod_Utilizador AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_codutilizador_ativados_empresa(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=1 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador like @Cod_Utilizador AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_codutilizador_desativados_empresa(ByRef Cod_Utilizador As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Cod_Utilizador", Cod_Utilizador))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If Cod_Utilizador = "" Then
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores Where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador, NºTécnico, Nome_Util, Admin, Admin_Geral, Ativo, NºEmpresa FROM Utilizadores where Cod_Utilizador like @Cod_Utilizador AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_ntecnico_empresa(ByVal id As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", id))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,admin,admin_geral FROM Utilizadores where Nºtécnico like @user AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End Function
            Shared Function procura_dados_tecnico_desativados_empresa(ByVal id As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", id))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,admin,admin_geral FROM Utilizadores where Nºtécnico like @user AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End Function
            Shared Function carregar_users() As DataTable
                Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador,NºTécnico,Nome_Util,Admin,NºEmpresa FROM Utilizadores where Ativo=1", Nothing)
            End Function
            Shared Function carregar_users_eliminados() As DataTable
                Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador,NºTécnico,Nome_Util,Admin,NºEmpresa FROM Utilizadores where Ativo=0", Nothing)
            End Function
            Shared Function carregar_users_empresa(ByRef empresa As Integer) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("n_empresa", empresa))
                Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador,NºTécnico,Nome_Util,admin FROM Utilizadores where Ativo=1 AND NºEmpresa=@n_empresa", p)
            End Function
            Shared Function carregar_users_eliminados_empresa(ByRef empresa As Integer) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("n_empresa", empresa))
                Return DAL.ExecuteQueryDT("SELECT Cod_Utilizador,NºTécnico,Nome_Util,admin FROM Utilizadores where Ativo=0 AND NºEmpresa=@n_empresa", p)
            End Function
            Shared Function Add_login_tecnico(ByVal pergunta_s As String, ByVal resposta_s As String, ByVal empresa As String, ByVal n_tecnico As String, ByVal admin_geral As Boolean, ByVal admin As Boolean, ByRef user As String, ByRef pass As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", user))
                p.Add(New SqlParameter("@password", pass))
                p.Add(New SqlParameter("@tecnico", n_tecnico))
                p.Add(New SqlParameter("@empresa", empresa))
                p.Add(New SqlParameter("@pergunta_s", pergunta_s))
                p.Add(New SqlParameter("@resposta_s", resposta_s))
                p.Add(New SqlParameter("@admin", admin))
                p.Add(New SqlParameter("@admin_geral", admin_geral))
                Return DAL.ExecuteNonQuery("Insert into Utilizadores(NºTécnico,Nome_Util,Password,Pergunta_S,Resposta_S,Admin_Geral,Admin,NºEmpresa,Ativo) VALUES (@tecnico,@user,@password,@pergunta_s,@resposta_s,@Admin_Geral,@admin,@empresa,1)", p)
            End Function
            Shared Function Add_login_non_student_noadmin(ByVal pergunta_s As String, ByVal resposta_s As String, ByVal admin As Boolean, ByRef user As String, ByRef pass As String, ByVal empresa As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", user))
                p.Add(New SqlParameter("@password", pass))
                p.Add(New SqlParameter("@pergunta_s", pergunta_s))
                p.Add(New SqlParameter("@resposta_s", resposta_s))
                p.Add(New SqlParameter("@admin", admin))
                p.Add(New SqlParameter("@admin_geral", False))
                p.Add(New SqlParameter("@n_empresa", empresa))
                Return DAL.ExecuteNonQuery("Insert into Utilizadores(Nome_Util,Password,Pergunta_S,Resposta_S,Admin_Geral,Admin,Ativo,NºEmpresa) VALUES (@user,@password,@pergunta_s,@resposta_s,@Admin_Geral,@admin,1,@n_empresa)", p)
            End Function
            Shared Function Add_login_non_student_admin(ByVal pergunta_s As String, ByVal resposta_s As String, ByVal admin As Boolean, ByRef user As String, ByRef pass As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@user", user))
                p.Add(New SqlParameter("@password", pass))
                p.Add(New SqlParameter("@pergunta_s", pergunta_s))
                p.Add(New SqlParameter("@resposta_s", resposta_s))
                p.Add(New SqlParameter("@admin", False))
                p.Add(New SqlParameter("@admin_geral", True))
                Return DAL.ExecuteNonQuery("Insert into Utilizadores(Nome_Util,Password,Pergunta_S,Resposta_S,Admin_Geral,Admin,Ativo) VALUES (@user,@password,@pergunta_s,@resposta_s,@Admin_Geral,@admin,1)", p)
            End Function
            Shared Function alterar_login_tecnico(ByVal pergunta_s As String, ByVal resposta_s As String, ByVal id As String, ByVal n_tecnico As String, ByVal admin_geral As Boolean, ByVal admin As Boolean, ByRef user As String, ByRef pass As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@id", id))
                p.Add(New SqlParameter("@user", user))
                p.Add(New SqlParameter("@password", pass))
                p.Add(New SqlParameter("@tecnico", n_tecnico))
                p.Add(New SqlParameter("@pergunta_s", pergunta_s))
                p.Add(New SqlParameter("@resposta_s", resposta_s))
                p.Add(New SqlParameter("@admin", admin))
                p.Add(New SqlParameter("@admin_geral", admin_geral))
                Return DAL.ExecuteNonQuery("Update Utilizadores set Pergunta_S=@pergunta_s, Resposta_S=@resposta_s, NºTécnico=@tecnico , Nome_Util=@user , Password=@password , Admin_Geral=@admin_geral , Admin = @admin where Cod_Utilizador=@id", p)
            End Function
            Shared Function alterar_login_non_student(ByVal pergunta_s As String, ByVal resposta_s As String, ByVal id As String, ByVal admin As Boolean, ByVal admin_geral As Boolean, ByRef user As String, ByRef pass As String, ByVal empresa As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@id", id))
                p.Add(New SqlParameter("@user", user))
                p.Add(New SqlParameter("@password", pass))
                p.Add(New SqlParameter("@pergunta_s", pergunta_s))
                p.Add(New SqlParameter("@resposta_s", resposta_s))
                p.Add(New SqlParameter("@admin", admin))
                p.Add(New SqlParameter("@admin_geral", admin_geral))
                If empresa <> 0 Then
                    p.Add(New SqlParameter("@n_empresa", empresa))
                    Return DAL.ExecuteNonQuery("Update Utilizadores set Pergunta_S=@pergunta_s, Resposta_S=@resposta_s, Nome_Util=@user, NºEmpresa=@n_empresa , Password=@password , Admin_Geral=@admin_geral , Admin = @admin where Cod_Utilizador=@id", p)
                Else
                    Return DAL.ExecuteNonQuery("Update Utilizadores set Nome_Util=@user , Password=@password , Admin_Geral=@admin_geral , Admin = @admin where Cod_Utilizador=@id", p)
                End If
            End Function
            Shared Function remove_login_empresa(ByVal empresa As String)
                Dim p As New ArrayList
                p.Add(New SqlParameter("n_empresa", empresa))
                Return DAL.ExecuteNonQuery("Delete From Utilizadores where NºEmpresa=@n_empresa", p)
            End Function
            Shared Function Verificar_Login_admin(ByRef user As String, ByRef pass As String) As Integer
                Dim sqlparams As New ArrayList
                sqlparams.Add(New SqlParameter("@user", user))
                sqlparams.Add(New SqlParameter("@password", pass))
                Return DAL.ExecuteScalar("select Cod_Utilizador from Utilizadores where convert(varbinary,Nome_Util) = convert(varbinary,@user) AND convert(varbinary,password) = convert(varbinary,@password) AND Admin_Geral=1", sqlparams)
            End Function
        End Class

        Public Class Empresas
            Shared Function check_name(ByVal id As Integer) As String
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", id))
                Return DAL.ExecuteScalar("Select Nome FROM Empresas where NºEmpresa=@n_empresa", p)
            End Function
            Shared Function check_exist(ByVal nome As String) As Object
                Dim check As Integer
                Dim p As New ArrayList
                p.Add(New SqlParameter("@nome", nome))
                check = DAL.ExecuteScalar("Select NºEmpresa FROM Empresas where Nome=@Nome", p)
                If check <> 0 Then
                    Return 1
                Else
                    Return 0
                End If
            End Function
            Shared Function carregar_pic() As Object

                Dim p As New ArrayList
                p.Add(New SqlParameter("@NºEmpresa", n_empresa))
                Dim bitPic() As Byte = DAL.ExecuteScalar("Select Logo from Empresas where NºEmpresa=@NºEmpresa", p)
                Dim mStream As MemoryStream = New MemoryStream(bitPic)
                Dim img As Image = Image.FromStream(mStream)
                Return img
            End Function
            Shared Function carregar_max() As Integer
                Return DAL.ExecuteScalar("Select Max(NºEmpresa) FROM Empresas", Nothing)
            End Function
            Shared Function carregar() As DataTable
                Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=1", Nothing)
            End Function
            Shared Function carregar_eliminados() As DataTable
                Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=0", Nothing)
            End Function
            Shared Function procura_dados_Nome_desativados(ByRef Nome As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome", Nome))
                If Nome = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Nome like @Nome AND Ativo=0", p)
                End If
            End Function
            Shared Function procura_dados_Nome_ativados(ByRef Nome As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome", Nome))
                If Nome = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Nome like @Nome AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_nif_desativados(ByRef NIF As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@NIF", NIF))
                If NIF = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where NIF like @NIF AND Ativo=0", p)
                End If
            End Function
            Shared Function procura_dados_nif_ativados(ByRef NIF As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@NIF", NIF))
                If NIF = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where NIF like @NIF AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_numempresa_desativados(ByRef n_empresa As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where NºEmpresa like @n_empresa AND Ativo=0", p)
                End If
            End Function
            Shared Function procura_dados_numempresa(ByRef n_empresa As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade FROM Empresas where NºEmpresa like @n_empresa AND Ativo=1", p)
                End If
            End Function
            Shared Function carregar_dados_numempresa_desativados(ByRef n_empresa As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where Ativo=0", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade,Alunos FROM Empresas where NºEmpresa=@n_empresa AND Ativo=0", p)
                End If
            End Function
            Shared Function carregar_dados_numempresa(ByRef n_empresa As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome,Morada,NIF,Cod_Postal,Localidade FROM Empresas where NºEmpresa=@n_empresa AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_Nome_mini(ByRef Nome As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome", Nome))
                If Nome = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome FROM Empresas where Nome like @Nome AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_nif_mini(ByRef NIF As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@NIF", NIF))
                If NIF = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome FROM Empresas where NIF like @NIF AND Ativo=1", p)
                End If
            End Function
            Shared Function procura_dados_mini(ByRef n_empresa As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome FROM Empresas where Ativo=1", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºEmpresa,Nome FROM Empresas where NºEmpresa like @n_empresa AND Ativo=1", p)
                End If
            End Function
            Shared Sub inserir(ByVal alunos As Boolean, ByVal Nome As String, ByVal Morada As String, ByVal NIF As String, ByVal Cod_Postal As String, ByVal Localidade As String, ByVal Logo As Image, ByVal Ativo As Boolean)
                Dim p As New ArrayList
                Dim img_save As New SqlParameter("@img", SqlDbType.Image)
                p.Add(New SqlParameter("@Nome", Nome))
                p.Add(New SqlParameter("@Morada", Morada))
                p.Add(New SqlParameter("@NIF", NIF))
                p.Add(New SqlParameter("@Cod_Postal", Cod_Postal))
                p.Add(New SqlParameter("@Localidade", Localidade))
                p.Add(New SqlParameter("@Alunos", alunos))
                Dim mStream As MemoryStream = New MemoryStream()
                Logo.Save(mStream, ImageFormat.Png)
                img_save.SqlValue = mStream.GetBuffer
                p.Add(img_save)
                p.Add(New SqlParameter("@Ativo", Ativo))
                DAL.ExecuteNonQuery("Insert into Empresas(Nome,Morada,NIF,Cod_Postal,Localidade,Logo,Alunos,Ativo) VALUES (@nome, @morada, @NIF, @cod_postal,@Localidade,@img,@Alunos,1)", p)
            End Sub
            Shared Sub alterar(ByVal NºEmpresa As Integer, ByVal Nome As String, ByVal Morada As String, ByVal NIF As String, ByVal Cod_Postal As String, ByVal Localidade As String, ByVal Logo As Image, ByVal ativo As Boolean)
                Dim p As New ArrayList
                Dim img_save As New SqlParameter("@Logo", SqlDbType.Image)
                p.Add(New SqlParameter("@Nome", Nome))
                p.Add(New SqlParameter("@Morada", Morada))
                p.Add(New SqlParameter("@NIF", NIF))
                p.Add(New SqlParameter("@Cod_Postal", Cod_Postal))
                p.Add(New SqlParameter("@Localidade", Localidade))
                Dim mStream As MemoryStream = New MemoryStream()
                Logo.Save(mStream, ImageFormat.Png)
                img_save.SqlValue = mStream.GetBuffer
                p.Add(img_save)
                p.Add(New SqlParameter("@Ativo", ativo))
                Try
                    DAL.ExecuteNonQuery("Update Empresas set Nome = @Nome, Norada = @Norada, NIF= @NIF, Cod_Postal= @Cod_Postal, Localidade= @Localidade, Logo= @Logo, Ativo= @Ativo where NºEmpresa=@NºEmpresa", p)
                Catch e As Exception
                    MsgBox("Erro ao editar os dados: " & e.Message)
                Finally
                    MsgBox("Empresa editada com sucesso")
                End Try
            End Sub
            Shared Sub apagar(ByVal NºEmpresa As String, ByVal NIF As String)
                Dim p As New ArrayList
                Dim data As String = ""
                p.Add(New SqlParameter("@NIF", NIF))
                p.Add(New SqlParameter("@NºEmpresa", NºEmpresa))

                If NºEmpresa <> "" Then
                    DAL.ExecuteNonQuery("Update Empresas set Ativo=0 where NºEmpresa = @NºEmpresa", p)
                    'BLL.Login.remover_empresas(NºEmpresa)
                    'BLL.Clientes.remover_empresas(NºEmpresa)
                    'BLL.Artigos.remover_empresas(NºEmpresa)
                    'BLL.Reparacoes.remover_empresas(NºEmpresa)
                    'BLL.Tecnicos.remover_empresas(NºEmpresa)
                ElseIf NIF <> "" Then
                    DAL.ExecuteNonQuery("Update Empresas set Ativo=0 where NIF = @NIF", p)
                    'data = DAL.ExecuteScalar("Select NºEmpresa from empresas where NIF=@NIF", p)
                    'BLL.Login.remover_empresas(data)
                    'BLL.Clientes.remover_empresas(data)
                    'BLL.Artigos.remover_empresas(data)
                    'BLL.Reparacoes.remover_empresas(data)
                    'BLL.Tecnicos.remover_empresas(data)
                End If
            End Sub
            Shared Sub restaurar(ByVal nºempresa As String, ByVal nif As String)
                Dim p As New ArrayList
                Dim data As String
                p.Add(New SqlParameter("@NIF", nif))
                p.Add(New SqlParameter("@NºEmpresa", nºempresa))

                If nºempresa <> "" Then
                    DAL.ExecuteNonQuery("Update Empresas set Ativo=1 where NºEmpresa = @NºEmpresa", p)
                ElseIf nif <> "" Then
                    DAL.ExecuteNonQuery("Update Empresas set Ativo=1 where NIF = @NIF", p)
                    data = DAL.ExecuteScalar("Select NºEmpresa from empresas where NIF=@NIF", p)
                End If
            End Sub
        End Class
        
    End Class
    Public Class Login
        'Shared Function remover_empresas(ByVal empresa As String)
        '    Dim p As New ArrayList
        '    p.Add(New SqlParameter("@empresa", empresa))
        '    DAL.ExecuteNonQuery("UPDATE Utilizadores set ativo=0 where nºempresa=@empresa", p)
        'End Function
        Shared Function check_exist(ByVal nome As String) As Object
            Dim check As Integer
            Dim p As New ArrayList
            p.Add(New SqlParameter("@nome", nome))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            check = DAL.ExecuteScalar("Select Cod_Utilizador FROM Utilizadores where Nome_util=@Nome AND NºEmpresa=@n_empresa", p)
            If check <> 0 Then
                Return 1
            Else
                Return 0
            End If
        End Function
        Shared Function verificar_admin(ByVal id As Integer) As Boolean
            Dim p As New ArrayList
            p.Add(New SqlParameter("@user", id))
            Return DAL.ExecuteScalar("Select Admin FROM Utilizadores where Cod_Utilizador=@user AND Ativo=1", p)
        End Function
        Shared Function verificar_aluno(ByVal id As Integer) As Boolean
            Dim p As New ArrayList
            p.Add(New SqlParameter("@user", id))
            Return DAL.ExecuteScalar("Select Alunos FROM Empresas where NºEmpresa=@user AND Ativo=1", p)
        End Function
        Shared Function procura_dados_ntecnico(ByVal id As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@user", id))
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            If id <> "" Then
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,password,admin,admin_geral FROM Utilizadores where NºEmpresa=@n_empresa AND Nºtécnico like @user AND Ativo=1", p)
            Else
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,password,admin,admin_geral FROM Utilizadores where NºEmpresa=@n_empresa AND Ativo=1", p)
            End If
        End Function
        Shared Function carregar_dados_ntecnico(ByVal id As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@user", id))
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            If id <> "" Then
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,password,admin,admin_geral FROM Utilizadores where NºEmpresa=@n_empresa AND Nºtécnico=@user AND Ativo=1", p)
            Else
                Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,password,admin,admin_geral FROM Utilizadores where NºEmpresa=@n_empresa AND Ativo=1", p)
            End If
        End Function
        Shared Function procura_dados_nome(ByVal id As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@user", id))
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            Return DAL.ExecuteQueryDT("Select Cod_Utilizador,nome_util,password,admin,admin_geral FROM Utilizadores where NºEmpresa=@n_empresa AND Nome_util like @user AND Ativo=1", p)
        End Function
        Shared Function Carregar_empresas() As ArrayList
            Return DAL.ExecuteQuery("Select Nome From empresas where Ativo=1", Nothing)
        End Function
        Shared Function return_n_empresa(ByVal nome As String) As Object
            Dim p As New ArrayList
            p.Add(New SqlParameter("@Nome", nome))
            Dim returnint As Integer
            returnint = DAL.ExecuteScalar("Select NºEmpresa FROM Empresas where Nome=@Nome", p)
            Return returnint
        End Function
        Shared Sub alterar(ByVal Cod_Utilizador As Integer, ByVal NºTécnico As Integer, ByVal Nome_Util As String, ByVal Password As String, ByVal Admin As Boolean, ByVal Admin_Geral As Boolean, ByVal Ativo As Boolean, ByVal NºEmpresa As Integer)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºTécnico", NºTécnico))
            p.Add(New SqlParameter("@Nome_Util", Nome_Util))
            p.Add(New SqlParameter("@Password", Password))
            p.Add(New SqlParameter("@Admin", Admin))
            p.Add(New SqlParameter("@Admin_Geral", Admin_Geral))
            p.Add(New SqlParameter("@Ativo", Ativo))
            p.Add(New SqlParameter("@NºEmpresa", NºEmpresa))
            DAL.ExecuteNonQuery("Update Utilizadores set NºTécnico = @NºTécnico, Nome_Util= @Nome_Util, Password= @Password. Admin= @Admin, Admin_Geral= @Admin_Geral, Ativo= @Ativo, NºEmpresa= @NºEmpresa where Cod_Utilizador=@Cod_Utilizador", p)
        End Sub
        Shared Function Verificar_Login(ByRef user As String, ByRef pass As String, ByRef empresa As String) As Integer
            Dim sqlparams As New ArrayList
            sqlparams.Add(New SqlParameter("@user", user))
            sqlparams.Add(New SqlParameter("@password", pass))
            sqlparams.Add(New SqlParameter("@n_empresa", empresa))
            Dim resultado As Integer
            resultado = DAL.ExecuteScalar("select Cod_Utilizador from Utilizadores where convert(varbinary,Nome_Util) = convert(varbinary,@user) AND convert(varbinary,password) = convert(varbinary,@password) AND NºEmpresa = @n_empresa AND Ativo=1", sqlparams)
            Return resultado
        End Function

    End Class
    Public Class Clientes
        Shared Function carregar_percentagem() As Integer
            Dim total, por, alunos As Integer
            total = DAL.ExecuteScalar("SELECT Count(NºCliente) From Clientes", Nothing)
            alunos = DAL.ExecuteScalar("SELECT Count(NºCliente) From Clientes inner join TipoAluno On Clientes.NºCliente = TipoAluno.N_Cliente where NºAluno <> 0", Nothing)
            por = alunos * 100 / total
            Return por
        End Function
        'Shared Sub remover_empresas(ByVal empresa As String)
        '    Dim p As New ArrayList
        '    p.Add(New SqlParameter("@empresa", empresa))
        '    DAL.ExecuteNonQuery("UPDATE Clientes set ativo=0 where nºempresa=@empresa", p)
        'End Sub
        Shared Function carregar_clientes()
            Dim p As New ArrayList
            p.Add(New SqlParameter("@num_empresa", n_empresa))
            Return DAL.ExecuteQuery("Select NºCliente,Nome from clientes where NºEmpresa=@num_empresa and ativo=1", p)
        End Function
        Shared Function carregar_max() As Integer
            Dim p As New ArrayList
            p.Add(New SqlParameter("@num_empresa", n_empresa))
            Return DAL.ExecuteScalar("Select MAX(NºCliente) from clientes where NºEmpresa=@num_empresa and ativo=1", p)
        End Function

        Shared Function check_exist(ByVal nome As String) As Object
            Dim check As Integer
            Dim p As New ArrayList
            p.Add(New SqlParameter("@nome", nome))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            check = DAL.ExecuteScalar("Select NºCliente FROM Cliente where Nome=@Nome and NºEmpresa=@n_empresa", p)
            If check <> 0 Then
                Return 1
            Else
                Return 0
            End If
        End Function
        Shared Function carregar_alunos() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=1 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function carregar_eliminados_alunos() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=0 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function procura_dados_nome_alunos(ByRef nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@Nome", nome))
            If nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where nome like @nome AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nome_desativados_alunos(ByRef nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@Nome", nome))
            If nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where nome like @nome AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nif_alunos(ByRef NIF As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NIF", NIF))
            If NIF = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where NIF like @NIF AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nif_desativados_alunos(ByRef NIF As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NIF", NIF))
            If NIF = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where NIF like @NIF AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente_alunos(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where NºCliente like @NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente_desativados_alunos(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where NºCliente like @NºCliente AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_numcliente_alunos(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where NºCliente=@NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_numcliente_desativados_alunos(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F,NºAluno,NºTurma FROM Clientes INNER JOIN TipoAluno ON Clientes.NºCliente=TipoAluno.N_Cliente where NºCliente=@NºCliente AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nome_mini(ByRef nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@Nome", nome))
            If nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome FROM Clientes where nome like @nome AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nif_mini(ByRef NIF As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NIF", NIF))
            If NIF = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome FROM Clientes where NIF like @NIF AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function

        Shared Function procura_dados_numcliente_mini(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome FROM Clientes where NºCliente like @NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function inserir_aluno(ByVal n_aluno As String, ByVal turma As String, ByVal NIF As String, ByVal localidade As String, ByVal nome As String, ByVal morada As String, ByVal cod_postal As String, ByVal email As String, ByVal ativo As Boolean, ByVal contacto_mov As String, ByVal contacto_fix As String)
            Dim p As New ArrayList
            Dim c As New ArrayList
            Dim a As New ArrayList
            Dim check(1) As Integer
            p.Add(New SqlParameter("@Nome", nome))
            p.Add(New SqlParameter("@Morada", morada))
            p.Add(New SqlParameter("@NIF", NIF))
            p.Add(New SqlParameter("@Cod_Postal", cod_postal))
            p.Add(New SqlParameter("@Localidade", localidade))
            p.Add(New SqlParameter("@Email", email))
            p.Add(New SqlParameter("@Ativo", ativo))
            a.Add(New SqlParameter("@naluno", n_aluno))
            a.Add(New SqlParameter("@turma", turma))
            p.Add(New SqlParameter("@contacto_m", contacto_mov))
            p.Add(New SqlParameter("@contacto_f", contacto_fix))
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            c.Add(New SqlParameter("@company", BLL.n_empresa))
            check(0) = DAL.ExecuteNonQuery("Insert into Clientes(Nome,Morada,NIF,Localidade,Cod_Postal,Email,Ativo,NºEmpresa,Contacto_M,Contacto_F) VALUES (@nome, @morada, @NIF,@Localidade, @cod_postal,@email,@ativo,@n_empresa,@contacto_m,@contacto_f)", p)
            check(1) = DAL.ExecuteScalar("Select MAX(NºCliente) from Clientes where NºEmpresa=@company", c)
            a.Add(New SqlParameter("@NºCliente", check(1)))
            DAL.ExecuteNonQuery("Insert into TipoAluno(N_Cliente,NºAluno,NºTurma) VALUES (@NºCliente,@naluno,@turma)", a)
            Return check
        End Function
        Shared Function alterar_aluno(ByVal n_aluno As String, ByVal turma As String, ByVal numcliente As Integer, ByVal localidade As String, ByVal NIF As String, ByVal nome As String, ByVal morada As String, ByVal cod_postal As String, ByVal email As String, ByVal ativo As Boolean, ByVal contacto_m As String, ByVal contacto_f As String)
            Dim p As New ArrayList
            Dim c As New ArrayList
            Dim check(1) As Integer
            p.Add(New SqlParameter("@numcliente", numcliente))
            p.Add(New SqlParameter("@Nome", nome))
            p.Add(New SqlParameter("@Morada", morada))
            p.Add(New SqlParameter("@NIF", NIF))
            p.Add(New SqlParameter("@Localidade", localidade))
            p.Add(New SqlParameter("@Cod_Postal", cod_postal))
            p.Add(New SqlParameter("@Email", email))
            c.Add(New SqlParameter("@N_Aluno", n_aluno))
            c.Add(New SqlParameter("@turma", turma))
            c.Add(New SqlParameter("@n_cliente", numcliente))
            p.Add(New SqlParameter("@Ativo", ativo))
            p.Add(New SqlParameter("@Contacto_m", contacto_m))
            p.Add(New SqlParameter("@Contacto_f", contacto_f))
            check(0) = DAL.ExecuteNonQuery("Update Clientes set Localidade=@Localidade, Contacto_M = @contacto_m, Contacto_F = @contacto_f, nome = @nome, morada = @morada, NIF= @NIF, Cod_Postal= @cod_postal, Email= @email, Ativo=@Ativo where NºCliente=@numcliente", p)
            DAL.ExecuteNonQuery("Update TipoAluno set NºAluno=@N_Aluno,NºTurma=@turma where N_Cliente=@n_cliente", c)
            Return check
        End Function
        Shared Function carregar() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function carregar_eliminados() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F FROM Clientes where Ativo=0 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function procura_dados_nome(ByRef nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@Nome", nome))
            If nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F FROM Clientes where nome like @nome AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nome_desativados(ByRef nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@Nome", nome))
            If nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F FROM Clientes where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,Localidade,Cod_Postal,Email,NIF,Contacto_M,Contacto_F FROM Clientes where nome like @nome AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nif(ByRef NIF As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NIF", NIF))
            If NIF = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where NIF like @NIF AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_nif_desativados(ByRef NIF As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NIF", NIF))
            If NIF = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where NIF like @NIF AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where NºCliente like @NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente_desativados(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where NºCliente like @NºCliente AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_numcliente(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where NºCliente=@NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_numcliente_desativados(ByRef num_cliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            p.Add(New SqlParameter("@NºCliente", num_cliente))
            If num_cliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºCliente,Nome,Morada,NIF,Localidade,Cod_Postal,Email,Contacto_M,Contacto_F FROM Clientes where NºCliente=@NºCliente AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function inserir(ByVal NIF As String, ByVal localidade As String, ByVal nome As String, ByVal morada As String, ByVal cod_postal As String, ByVal email As String, ByVal ativo As Boolean, ByVal contacto_mov As String, ByVal contacto_fix As String)
            Dim p As New ArrayList
            Dim c As New ArrayList
            Dim check(1) As Integer
            p.Add(New SqlParameter("@Nome", nome))
            p.Add(New SqlParameter("@Morada", morada))
            p.Add(New SqlParameter("@NIF", NIF))
            p.Add(New SqlParameter("@Cod_Postal", cod_postal))
            p.Add(New SqlParameter("@Localidade", localidade))
            p.Add(New SqlParameter("@Email", email))
            p.Add(New SqlParameter("@Ativo", ativo))
            p.Add(New SqlParameter("@contacto_m", contacto_mov))
            p.Add(New SqlParameter("@contacto_f", contacto_fix))
            p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
            check(0) = DAL.ExecuteNonQuery("Insert into Clientes(Nome,Morada,NIF,Localidade,Cod_Postal,Email,Ativo,NºEmpresa,Contacto_M,Contacto_F) VALUES (@nome, @morada, @NIF,@Localidade, @cod_postal,@email,1,@n_empresa,@contacto_m,@contacto_f)", p)
            Return check
        End Function
        Shared Function alterar(ByVal numcliente As Integer, ByVal localidade As String, ByVal NIF As String, ByVal nome As String, ByVal morada As String, ByVal cod_postal As String, ByVal email As String, ByVal ativo As Boolean, ByVal contacto_m As String, ByVal contacto_f As String)
            Dim p As New ArrayList
            Dim c As New ArrayList
            Dim check(1) As Integer
            p.Add(New SqlParameter("@numcliente", numcliente))
            p.Add(New SqlParameter("@Nome", nome))
            p.Add(New SqlParameter("@Morada", morada))
            p.Add(New SqlParameter("@NIF", NIF))
            p.Add(New SqlParameter("@Localidade", localidade))
            p.Add(New SqlParameter("@Cod_Postal", cod_postal))
            p.Add(New SqlParameter("@Email", email))
            p.Add(New SqlParameter("@Ativo", ativo))
            p.Add(New SqlParameter("@Contacto_m", contacto_m))
            p.Add(New SqlParameter("@Contacto_f", contacto_f))
            check(0) = DAL.ExecuteNonQuery("Update Clientes set Localidade=@Localidade, Contacto_M = @contacto_m, Contacto_F = @contacto_f, nome = @nome, morada = @morada, NIF= @NIF, Cod_Postal= @cod_postal, Email= @email, Ativo=@Ativo where NºCliente=@numcliente", p)
            Return check
        End Function
        Shared Sub apagar(ByVal N_Cliente As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºCliente", N_Cliente))
            If N_Cliente <> Nothing Or N_Cliente <> "" Then
                DAL.ExecuteNonQuery("Update Clientes set Ativo=0 where NºCliente = @NºCliente", p)
                DAL.ExecuteNonQuery("Update Artigos set Ativo=0 where NºCliente=@NºCliente", p)
            End If
        End Sub
        Shared Function reativar_cliente(ByVal N_Cliente As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_cliente", N_Cliente))
            Return DAL.ExecuteNonQuery("Update Clientes set Ativo=1 where NºCliente = @n_Cliente", p)
        End Function
    End Class
    Public Class Artigos
        'Shared Sub remover_empresas(ByVal empresa As String)
        '    Dim p As New ArrayList
        '    p.Add(New SqlParameter("@empresa", empresa))
        '    DAL.ExecuteNonQuery("UPDATE Artigos set ativo=0 where nºempresa=@empresa", p)
        'End Sub
        Shared Function check_exist(ByVal numartigo As Integer) As Boolean
            Dim p As New ArrayList
            p.Add(New SqlParameter("@num_empresa", n_empresa))
            p.Add(New SqlParameter("@num_artigo", numartigo))
            Dim check As String = DAL.ExecuteScalar("Select Marca from Artigos where NºEmpresa=@num_empresa and NºArtigo=@num_artigo", p)
            If check <> "" Then
                Return True
            Else
                Return False
            End If
        End Function
        Shared Function carregar_artigos() As ArrayList
            Dim p As New ArrayList
            p.Add(New SqlParameter("@num_empresa", n_empresa))
            Return DAL.ExecuteQuery("Select NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo from Artigos where NºEmpresa=@num_empresa", p)
        End Function
        Shared Function carregar() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie, Observações, Tipo_Artigo FROM Artigos where Ativo=1 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function carregar_desativos() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie, Observações,Tipo_Artigo FROM Artigos where Ativo=0 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function procura_dados_numartigo_desativo(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where NºArtigo like @n_artigo AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numartigo(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where NºArtigo like @n_artigo AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_numartigo_desativo(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where NºArtigo=@n_artigo AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_numartigo(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where NºArtigo=@n_artigo AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente(ByRef NºCliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºCliente", NºCliente))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºCliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where NºCliente like @NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numartigo_mini(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Tipo_Artigo FROM Artigos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Tipo_Artigo FROM Artigos where NºArtigo like @n_artigo AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente_mini(ByRef NºCliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºCliente", NºCliente))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºCliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Tipo_Artigo FROM Artigos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Tipo_Artigo FROM Artigos where NºCliente like @NºCliente AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_numcliente_desativo(ByRef NºCliente As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºCliente", NºCliente))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºCliente = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºArtigo,NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo FROM Artigos where NºCliente like @NºCliente AND Ativo=0", p)
            End If
        End Function
        Shared Function inserir(ByVal NºCliente As String, ByVal Marca As String, ByVal Modelo As String, ByVal NºSérie As String, ByVal Observações As String, ByVal Tipo_Artigo As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºCliente", NºCliente))
            p.Add(New SqlParameter("@Marca", Marca))
            p.Add(New SqlParameter("@Modelo", Modelo))
            p.Add(New SqlParameter("@NºSérie", NºSérie))
            p.Add(New SqlParameter("@Observações", Observações))
            p.Add(New SqlParameter("@Tipo_Artigo", Tipo_Artigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteNonQuery("Insert into Artigos(NºCliente,Marca,Modelo,NºSérie,Observações,Tipo_Artigo,NºEmpresa,Ativo) VALUES (@NºCliente, @Marca, @Modelo, @NºSérie,@Observações,@Tipo_Artigo,@n_empresa,1)", p)
        End Function
        Shared Function alterar(ByVal NºArtigo As String, ByVal n_cliente As String, ByVal Marca As String, ByVal Modelo As String, ByVal NºSérie As String, ByVal Observações As String, ByVal Tipo_Artigo As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_cliente", n_cliente))
            p.Add(New SqlParameter("@Marca", Marca))
            p.Add(New SqlParameter("@Modelo", Modelo))
            p.Add(New SqlParameter("@NºSérie", NºSérie))
            p.Add(New SqlParameter("@Observações", Observações))
            p.Add(New SqlParameter("@Tipo_Artigo", Tipo_Artigo))
            Return DAL.ExecuteNonQuery("Update Artigos set NºCliente = @n_cliente, Marca = @Marca, Modelo= @Modelo, NºSérie= @NºSérie, Observações= @Observações, Tipo_Artigo = @Tipo_Artigo where NºArtigo=@n_artigo", p)
        End Function
        Shared Function apagar(ByVal NºArtigo As String, ByVal NºCliente As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºArtigo", NºArtigo))
            p.Add(New SqlParameter("@NºCliente", NºCliente))
            If NºArtigo <> "" Then
                Return DAL.ExecuteNonQuery("Update Artigos set Ativo=0 where NºArtigo = @NºArtigo", p)
            ElseIf NºCliente <> "" Then
                Return DAL.ExecuteNonQuery("Update Artigos set Ativo=0 where NºCliente = @NºCliente", p)
            Else
                Return -1
            End If
        End Function
        Shared Function restaurar(ByVal NºArtigo As String, ByVal NºCliente As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºArtigo", NºArtigo))
            p.Add(New SqlParameter("@NºCliente", NºCliente))
            If NºArtigo <> "" Then
                Return DAL.ExecuteNonQuery("Update Artigos set Ativo=1 where NºArtigo = @NºArtigo", p)
            ElseIf NºCliente <> "" Then
                Return DAL.ExecuteNonQuery("Update Artigos set Ativo=1 where NºCliente = @NºCliente", p)
            Else
                Return -1
            End If
        End Function
    End Class
    Public Class Reparacoes
        'Shared Sub remover_empresas(ByVal empresa As String)
        '    Dim p As New ArrayList
        '    p.Add(New SqlParameter("@empresa", empresa))
        '    DAL.ExecuteNonQuery("UPDATE Reparações set ativo=0 where nºempresa=@empresa", p)
        'End Sub
        Shared Function carregar() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=1", p)
        End Function
        Shared Function carregar_desativos() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=0", p)
        End Function
        Shared Function procura_dados_numartigo(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=1", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºArtigo like @n_artigo AND NºEmpresa=@n_empresa AND Ativo=1", p)
            End If
        End Function
        Shared Function procura_dados_numartigo_desativo(ByRef NºArtigo As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºArtigo = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=0", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºArtigo like @n_artigo AND NºEmpresa=@n_empresa AND Ativo=0", p)
            End If
        End Function
        Shared Function procura_dados_numreparação(ByRef NºReparação As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparação", NºReparação))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºReparação = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=1", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºReparação like @n_reparação AND NºEmpresa=@n_empresa AND Ativo=1", p)
            End If
        End Function
        Shared Function procura_dados_numreparação_desativo(ByRef NºReparação As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparação", NºReparação))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºReparação = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=0", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºReparação like @n_reparação AND NºEmpresa=@n_empresa AND Ativo=0", p)
            End If
        End Function
        Shared Function carregar_dados_numreparação(ByRef NºReparação As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparação", NºReparação))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºReparação = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=1", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºReparação=@n_reparação AND NºEmpresa=@n_empresa AND Ativo=1", p)
            End If
        End Function
        Shared Function carregar_dados_numreparação_desativo(ByRef NºReparação As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparação", NºReparação))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If NºReparação = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºEmpresa=@n_empresa AND Ativo=0", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºReparação,NºArtigo,TemporealReparação,DescAvaria,DIRepar,DFRepar,Preço From Reparações where NºReparação=@n_reparação AND NºEmpresa=@n_empresa AND Ativo=0", p)
            End If
        End Function
        Shared Sub inserir(ByVal NºArtigo As Integer, ByVal DescAvaria As String, ByVal DIRepar As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_artigo", NºArtigo))
            p.Add(New SqlParameter("@DescAvaria", DescAvaria))
            p.Add(New SqlParameter("@DIRepar", DIRepar))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            DAL.ExecuteNonQuery("Insert into Reparações(NºArtigo,DescAvaria,DIRepar,NºEmpresa,Ativo) VALUES (@n_artigo,@DescAvaria,@DIRepar,@n_empresa,1)", p)
        End Sub
        Shared Sub alterar_datafim(ByVal NºReparação As Integer, ByVal NºArtigo As Integer, ByVal TempoRealReparação As String, ByVal DescAvaria As String, ByVal DIRepar As DateTime, ByVal DFRepar As DateTime, ByVal Preço As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºReparação", NºReparação))
            p.Add(New SqlParameter("@NºArtigo", NºArtigo))
            p.Add(New SqlParameter("@TempoRealReparação", TempoRealReparação))
            p.Add(New SqlParameter("@DescAvaria", DescAvaria))
            p.Add(New SqlParameter("@DIRepar", DIRepar))
            p.Add(New SqlParameter("@DFRepar", DFRepar))
            p.Add(New SqlParameter("@Preço", Preço))

            DAL.ExecuteNonQuery("Update Reparações set NºArtigo = @NºArtigo, TempoRealReparação= @TempoRealReparação, DescAvaria= @DescAvaria, DIRepar = @DIRepar, DFRepar = @DFRepar, Preço = @Preço where NºReparação=@NºReparação", p)
        End Sub
        Shared Function apagar(ByVal id As Integer, ByVal modo As Integer) As String
            Dim p As New ArrayList
            p.Add(New SqlParameter("@id", id))
            If modo = 1 Then
                DAL.ExecuteNonQuery("Update Reparações set Ativo=0 where NºReparação = @id", p)
                Return 1
            ElseIf modo = 2 Then
                DAL.ExecuteNonQuery("Update Reparações set Ativo=0 where NºArtigo = @id", p)
                Return 1
            End If
            Return "Erro ao Apagar da Base-de-Dados"
        End Function
        Shared Function restaurar(ByVal id As Integer, ByVal modo As Integer) As String
            Dim p As New ArrayList
            p.Add(New SqlParameter("@id", id))
            If modo = 1 Then
                DAL.ExecuteNonQuery("Update Reparações set Ativo=1 where NºReparação = @id", p)
                Return 1
            ElseIf modo = 2 Then
                DAL.ExecuteNonQuery("Update Reparações set Ativo=1 where NºArtigo = @id", p)
                Return 1
            End If
            Return "Erro ao Apagar da Base-de-Dados"
        End Function
        Shared Function add_datafim(ByVal DFRepar As String, ByVal Temporeal As String, ByVal n_repar As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@DFRepar", DFRepar))
            p.Add(New SqlParameter("@Temporeal", Temporeal))
            p.Add(New SqlParameter("@n_repar", n_repar))
            Return DAL.ExecuteNonQuery("Update Reparações set DFRepar=@DFRepar, TempoRealReparação=@Temporeal where NºReparação=@n_repar", p)
        End Function
    End Class
    Public Class Tecnicos
        'Shared Sub remover_empresas(ByVal empresa As String)
        '    Dim p As New ArrayList
        '    p.Add(New SqlParameter("@empresa", empresa))
        '    DAL.ExecuteNonQuery("UPDATE Técnicos set ativo=0 where nºempresa=@empresa", p)
        'End Sub
        Shared Function check_exist(ByVal nome As String) As Object
            Dim check As Integer
            Dim p As New ArrayList
            p.Add(New SqlParameter("@nome", nome))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            check = DAL.ExecuteScalar("Select NºTécnico FROM Técnicos where Nome=@Nome AND NºEmpresa=@n_empresa", p)
            If check <> 0 Then
                Return 1
            Else
                Return 0
            End If
        End Function
        Public Class Alunos
            Shared Function carregar() As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            End Function
            Shared Function carregar_eliminados() As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            End Function
            Shared Function procura_dados_Nome_desativados(ByRef Nome As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome", Nome))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If Nome = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Nome like @Nome AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_Nome_ativados(ByRef Nome As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@Nome", Nome))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If Nome = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicoswhere Nome like @Nome AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_naluno_desativados(ByRef n_aluno As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_aluno", n_aluno))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_aluno = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where NºAluno like @n_aluno AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_naluno_ativados(ByRef n_aluno As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_aluno", n_aluno))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_aluno = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where NºAluno like @n_aluno AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_turma_desativados(ByRef turma As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                p.Add(New SqlParameter("@turma", turma))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where NºEmpresa=@n_empresa AND Ativo=0 AND Turma like @turma", p)
                End If
            End Function
            Shared Function procura_dados_turma(ByRef turma As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                p.Add(New SqlParameter("@turma", turma))
                If n_empresa = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno,Fotografia FROM Técnicos where NºEmpresa=@n_empresa AND Ativo=1 AND Turma like @turma", p)
                End If
            End Function
            Shared Function procura_dados_ntecnico_desativados(ByRef n_tecnico As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_tecnico = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where NºTécnico like @n_tecnico AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function procura_dados_ntecnico_ativados(ByRef n_tecnico As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_tecnico = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where NºTécnico like @n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function carregar_dados_ntecnico_desativados(ByRef n_tecnico As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_tecnico = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where NºTécnico = @n_tecnico AND Ativo=0 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function carregar_dados_ntecnico_ativados(ByRef n_tecnico As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                If n_tecnico = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal,Turma,NºAluno FROM Técnicos where NºTécnico = @n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Function carregar_dados_ntecnico_ativados_mini(ByRef n_tecnico As String) As DataTable
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Add(New SqlParameter("@n_empresa", BLL.n_empresa))
                If n_tecnico = "" Then
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
                Else
                    Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where NºTécnico = @n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
                End If
            End Function
            Shared Sub inserir(ByVal localidade As String, ByVal cod_postal As String, ByVal contacto_m As String, ByVal contacto_f As String, ByVal Nome As String, ByRef img As Image, ByVal n_aluno As Integer, ByVal turma As String)
                Dim p As New ArrayList
                Dim img_save As New SqlParameter("@fotografia", SqlDbType.Image)
                p.Add(New SqlParameter("@nome", Nome))
                p.Add(New SqlParameter("@localidade", localidade))
                p.Add(New SqlParameter("@cod_postal", cod_postal))
                p.Add(New SqlParameter("@contacto_m", contacto_m))
                p.Add(New SqlParameter("@contacto_f", contacto_f))
                p.Add(New SqlParameter("@turma", turma))
                p.Add(New SqlParameter("@n_aluno", n_aluno))
                Dim mStream As MemoryStream = New MemoryStream()
                img.Save(mStream, ImageFormat.Png)
                img_save.SqlValue = mStream.GetBuffer
                p.Add(img_save)
                p.Add(New SqlParameter("@n_empresa", n_empresa))
                DAL.ExecuteNonQuery("Insert into Técnicos(Nome,Localidade,Cod_Postal,Contacto_M,Contacto_F,Turma,Fotografia,NºAluno,Ativo,NºEmpresa) VALUES (@nome,@localidade,@cod_postal,@contacto_m,@contacto_f,@turma,@fotografia,@n_aluno,1,@n_empresa)", p)
            End Sub
            Shared Sub alterar(ByVal localidade As String, ByVal cod_postal As String, ByVal contacto_m As String, ByVal contacto_f As String, ByVal Nome As String, ByVal n_aluno As Integer, ByVal turma As String, ByVal n_tecnico As Integer)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@nome", Nome))
                p.Add(New SqlParameter("@localidade", localidade))
                p.Add(New SqlParameter("@cod_postal", cod_postal))
                p.Add(New SqlParameter("@contacto_m", contacto_m))
                p.Add(New SqlParameter("@contacto_f", contacto_f))
                p.Add(New SqlParameter("@turma", turma))
                p.Add(New SqlParameter("@n_aluno", n_aluno))
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                DAL.ExecuteNonQuery("Update Técnicos set Localidade=@localidade, Cod_Postal=@cod_postal, Contacto_M=@contacto_m, Contacto_F=@contacto_f, Nome = @Nome, Turma=@turma, NºAluno=@n_aluno where NºTécnico=@n_tecnico", p)
            End Sub
            Shared Sub apagar(ByVal n_aluno As String, ByVal n_tecnico As Integer)
                Dim p As New ArrayList
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Add(New SqlParameter("@n_aluno", n_aluno))
                If n_tecnico <> "" Then
                    DAL.ExecuteNonQuery("Update Técnicos set Ativo=0 where NºTécnico = @n_tecnico", p)
                ElseIf n_aluno <> "" Then
                    DAL.ExecuteNonQuery("Update Técnicos set Ativo=0 where NºAluno = @n_aluno", p)
                End If
            End Sub
        End Class
        Shared Function carregar_tecnico() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where NºEmpresa=@n_empresa", p)
        End Function
        Shared Function carregar_max()
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteScalar("SELECT MAX(NºTécnico) FROM Técnicos where NºEmpresa=@n_empresa", p)
        End Function
        Shared Function carregar() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function carregar_eliminados() As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
        End Function
        Shared Function procura_dados_Nome_desativados(ByRef Nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@Nome", Nome))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If Nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Nome like @Nome AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_Nome_ativados(ByRef Nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@Nome", Nome))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If Nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Nome like @Nome AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_ntecnico_desativados(ByRef n_tecnico As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If n_tecnico = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where NºTécnico like @n_tecnico AND Ativo=0 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_Nome_mini(ByRef Nome As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@Nome", Nome))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If Nome = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where Nome like @Nome AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_ntecnico_mini(ByRef n_tecnico As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If n_tecnico = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Técnicos where NºTécnico like @n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function procura_dados_ntecnico_ativados(ByRef n_tecnico As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If n_tecnico = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where NºTécnico like @n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_ntecnico_ativados(ByRef n_tecnico As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If n_tecnico = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=1 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where NºTécnico=@n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Function carregar_dados_ntecnico_desativados(ByRef n_tecnico As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            If n_tecnico = "" Then
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where Ativo=0 AND NºEmpresa=@n_empresa", p)
            Else
                Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome,Contacto_M,Contacto_F,Localidade,Cod_Postal FROM Técnicos where NºTécnico = @n_tecnico AND Ativo=1 AND NºEmpresa=@n_empresa", p)
            End If
        End Function
        Shared Sub inserir(ByVal localidade As String, ByVal cod_postal As String, ByVal contacto_m As String, ByVal contacto_f As String, ByVal Nome As String, ByRef img As Image)
            Dim p As New ArrayList
            Dim img_save As New SqlParameter("@fotografia", SqlDbType.Image)
            p.Add(New SqlParameter("@nome", Nome))
            p.Add(New SqlParameter("@localidade", localidade))
            p.Add(New SqlParameter("@cod_postal", cod_postal))
            p.Add(New SqlParameter("@contacto_m", contacto_m))
            p.Add(New SqlParameter("@contacto_f", contacto_f))
            Dim mStream As MemoryStream = New MemoryStream()
            img.Save(mStream, ImageFormat.Png)
            img_save.SqlValue = mStream.GetBuffer
            p.Add(img_save)
            p.Add(New SqlParameter("@n_empresa", n_empresa))
            DAL.ExecuteNonQuery("Insert into Técnicos(Nome,Localidade,Cod_Postal,Contacto_M,Contacto_F,Fotografia,Ativo,NºEmpresa) VALUES (@nome,@localidade,@cod_postal,@contacto_m,@contacto_f,@fotografia,1,@n_empresa)", p)
        End Sub
        Shared Sub alterar(ByVal localidade As String, ByVal cod_postal As String, ByVal contacto_m As String, ByVal contacto_f As String, ByVal Nome As String, ByVal img As Image, ByVal n_tecnico As Integer)
            Dim p As New ArrayList
            Dim img_save As New SqlParameter("@Fotografia", SqlDbType.Image)
            p.Add(New SqlParameter("@nome", Nome))
            p.Add(New SqlParameter("@localidade", localidade))
            p.Add(New SqlParameter("@cod_postal", cod_postal))
            p.Add(New SqlParameter("@contacto_m", contacto_m))
            p.Add(New SqlParameter("@contacto_f", contacto_f))
            Dim mStream As MemoryStream = New MemoryStream()
            img.Save(mStream, ImageFormat.Png)
            img_save.SqlValue = mStream.GetBuffer
            p.Add(img_save)
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            DAL.ExecuteNonQuery("Update Técnicos set Localidade=@localidade, Cod_Postal=@cod_postal, Contacto_M=,@contacto_m, Contacto_F=@contacto_f, Nome = @Nome, Fotografia=@Fotografia where NºTécnico=@n_tecnico", p)
        End Sub
        Shared Function apagar(ByVal n_tecnico As String)
            Dim p As New ArrayList
            Dim C As New ArrayList
            Dim D As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            C.Add(New SqlParameter("@ntecnico", n_tecnico))
            D.Add(New SqlParameter("@tecnico", n_tecnico))
            If n_tecnico <> "" Then
                If DAL.ExecuteScalar("Select Cod_Utilizador from Utilizadores where NºTécnico=@n_tecnico", p) <> Workspace.user Then
                    DAL.ExecuteNonQuery("Update Utilizadores set Ativo=0 where NºTécnico=@ntecnico", C)
                Else
                    MsgBox("Não foi possível desativar este Utilizador dado que é o que está currentemente em Sessão, mas removemos o seu estado como Técnico", vbOKOnly, "Erro!")
                End If
                Return DAL.ExecuteNonQuery("Update Técnicos set Ativo=0 where NºTécnico = @tecnico", D)
            Else
                MsgBox("Insira o ID do Técnico a Eliminar")
                Return -1
            End If
        End Function
        Shared Function restaurar(ByVal n_tecnico As String)
            Dim p As New ArrayList
            Dim c As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            c.Add(New SqlParameter("@ntecnico", n_tecnico))
            If n_tecnico <> "" Then
                DAL.ExecuteNonQuery("Update Utilizadores set Ativo=1 where NºTécnico=@ntecnico", c)
                MsgBox("O Utilizador deste técnico foi também ativado com o Técnico!", vbOKOnly, "Aviso!")
                Return DAL.ExecuteNonQuery("Update Técnicos set Ativo=1 where NºTécnico = @n_tecnico", p)
            Else
                MsgBox("Insira o ID do Técnico a Eliminar")
                Return -1
            End If
        End Function
    End Class
    Public Class Participacoes
        Shared Sub adicionar_part(ByVal n_tecnico As Integer, ByVal n_reparacao As Integer, ByVal nome As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_tecnico", n_tecnico))
            p.Add(New SqlParameter("@nome", nome))
            p.Add(New SqlParameter("@n_reparacao", n_reparacao))
            DAL.ExecuteNonQuery("Insert into Participações(NºReparação,NºTécnico,Nome) VALUES (@n_reparacao,@n_tecnico,@Nome)", p)
        End Sub
        Shared Sub remover_part(ByVal n_tecnico As Integer, ByVal n_reparacao As Integer)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparacao", n_reparacao))
            If n_reparacao <> 0 Then
                DAL.ExecuteNonQuery("Delete FROM Participações where NºReparação=@n_reparacao", p)
            Else
                p.Add(New SqlParameter("@n_tecnico", n_tecnico))
                p.Remove(New SqlParameter("@n_reparacao", n_reparacao))
                DAL.ExecuteNonQuery("Delete FROM Participações where NºTécnico=@n_tecnico", p)
            End If
        End Sub
        Shared Function return_all()
            Return DAL.ExecuteScalar("SELECT Count(NºParticipação) FROM Participações", Nothing)
        End Function
        Shared Function procurar_part(ByVal n_repar As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºReparação", n_repar))
            Return DAL.ExecuteQueryDT("SELECT NºTécnico,Nome FROM Participações where NºReparação=@NºReparação", p)
        End Function
    End Class
    Public Class Hardware
        Shared Sub adicionar_hardware(ByVal n_reparacao As String, tipo As String, preço As String, qtd As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparacao", n_reparacao))
            p.Add(New SqlParameter("@tipo", tipo))
            p.Add(New SqlParameter("@preço", preço))
            p.Add(New SqlParameter("@qtd", qtd))
            DAL.ExecuteNonQuery("Insert into Hardware(NºReparação,Tipo,preço,qtd) values (@n_reparacao,@tipo,@preço,@qtd)", p)
        End Sub
        Shared Function return_hardware(ByVal n_reparacao As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºReparação", n_reparacao))
            Return DAL.ExecuteQueryDT("Select Tipo,Qtd,Preço FROM Hardware where NºReparação=@NºReparação", p)
        End Function
        Shared Function delete_hardware(ByVal n_reparacao As String) As String
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºReparação", n_reparacao))
            Return DAL.ExecuteNonQuery("Delete from Hardware where NºReparação=@NºReparação", p)
        End Function
        Shared Function return_all()
            Return DAL.ExecuteScalar("SELECT Count(NºHardware) FROM Hardware", Nothing)
        End Function
    End Class
    Public Class Software
        Shared Sub adicionar_software(ByVal n_reparacao As String, tipo As String, preço As String)
            Dim p As New ArrayList
            p.Add(New SqlParameter("@n_reparacao", n_reparacao))
            p.Add(New SqlParameter("@tipo", tipo))
            p.Add(New SqlParameter("@preço", preço))
            DAL.ExecuteNonQuery("Insert into Software(NºReparação,Tipo,preço) values (@n_reparacao,@tipo,@preço)", p)
        End Sub
        Shared Function return_software(ByVal n_reparacao As String) As DataTable
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºReparação", n_reparacao))
            Return DAL.ExecuteQueryDT("Select Tipo, Preço FROM Software where NºReparação=@NºReparação", p)
        End Function
        Shared Function delete_software(ByVal n_reparacao As String) As String
            Dim p As New ArrayList
            p.Add(New SqlParameter("@NºReparação", n_reparacao))
            Return DAL.ExecuteNonQuery("Delete from Software where NºReparação=@NºReparação", p)
        End Function
        Shared Function return_all()
            Return DAL.ExecuteScalar("SELECT Count(NºSoftware) FROM Software", Nothing)
        End Function
    End Class
End Class


