﻿Public Class folha_repar
    Public cliente_data As New DataTable
    Public artigodata As New DataTable
    Public n_repar As Integer
    Private Sub folha_repar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Participações'. Você pode movê-la ou removê-la conforme necessário.
        Me.ParticipaçõesTableAdapter.Fill(Me.SQLToReportConnection.Participações, n_repar)
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Hardware'. Você pode movê-la ou removê-la conforme necessário.
        Me.HardwareTableAdapter.Fill(Me.SQLToReportConnection.Hardware, n_repar)
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Software'. Você pode movê-la ou removê-la conforme necessário.
        Me.SoftwareTableAdapter.Fill(Me.SQLToReportConnection.Software, n_repar)
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Artigos'. Você pode movê-la ou removê-la conforme necessário.
        Me.ArtigosTableAdapter.Fill(Me.SQLToReportConnection.Artigos, artigodata.Rows(0).Item("NºArtigo").ToString())
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Clientes'. Você pode movê-la ou removê-la conforme necessário.
        Me.ClientesTableAdapter.Fill(Me.SQLToReportConnection.Clientes, cliente_data.Rows(0).Item("NºCliente").ToString())
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Empresas'. Você pode movê-la ou removê-la conforme necessário.
        Me.EmpresasTableAdapter.Fill(Me.SQLToReportConnection.Empresas, BLL.n_empresa)
        'TODO: esta linha de código carrega dados na tabela 'SQLToReportConnection.Reparações'. Você pode movê-la ou removê-la conforme necessário.
        Me.ReparaçõesTableAdapter.Fill(Me.SQLToReportConnection.Reparações, n_repar)
        Try
            ''TODO: esta linha de código carrega dados na tabela '_BD_C_IDataSet.Clientes'. Você pode movê-la ou removê-la conforme necessário.
            'Me.ClientesTableAdapter.Fill(Me._BD_C_IDataSet.Clientes, cliente_data.Rows(0).Item("NºCliente").ToString())
            ''TODO: esta linha de código carrega dados na tabela '_BD_C_IDataSet.Componentes'. Você pode movê-la ou removê-la conforme necessário.
            'Me.ComponentesTableAdapter.Fill(Me._BD_C_IDataSet.Componentes, artigodata.Rows(0).Item("NºArtigo").ToString())
            ''TODO: esta linha de código carrega dados na tabela '_BD_C_IDataSet.Reparações'. Você pode movê-la ou removê-la conforme necessário.
            'Me.ReparaçõesTableAdapter.Fill(Me._BD_C_IDataSet.Reparações, n_repar)
            ''TODO: esta linha de código carrega dados na tabela '_BD_C_IDataSet.Empresas'. Você pode movê-la ou removê-la conforme necessário.
            'Me.EmpresasTableAdapter.Fill(Me._BD_C_IDataSet.Empresas, BLL.n_empresa)
            'TODO: esta linha de código carrega dados na tabela '_BD_C_IDataSet.Clientes'. Você pode movê-la ou removê-la conforme necessário.
        Catch ex As Exception
            MsgBox("Erro ao gerar Relatório: " & ex.Message)
            'Me.ReportViewer1.RefreshReport()
        End Try
        'Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub ClientesBindingSource_CurrentChanged(sender As Object, e As EventArgs)

    End Sub

    
End Class