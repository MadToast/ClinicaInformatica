﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class folha_repar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(folha_repar))
        Me.ArtigosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLToReportConnection = New ClinicaInformatica.SQLToReportConnection()
        Me.ClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmpresasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReparaçõesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParticipaçõesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HardwareBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SoftwareBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ArtigosTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.ArtigosTableAdapter()
        Me.ClientesTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.ClientesTableAdapter()
        Me.EmpresasTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.EmpresasTableAdapter()
        Me.ReparaçõesTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.ReparaçõesTableAdapter()
        Me.ParticipaçõesTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.ParticipaçõesTableAdapter()
        Me.HardwareTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.HardwareTableAdapter()
        Me.SoftwareTableAdapter = New ClinicaInformatica.SQLToReportConnectionTableAdapters.SoftwareTableAdapter()
        CType(Me.ArtigosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLToReportConnection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpresasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReparaçõesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParticipaçõesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HardwareBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoftwareBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ArtigosBindingSource
        '
        Me.ArtigosBindingSource.DataMember = "Artigos"
        Me.ArtigosBindingSource.DataSource = Me.SQLToReportConnection
        '
        'SQLToReportConnection
        '
        Me.SQLToReportConnection.DataSetName = "SQLToReportConnection"
        Me.SQLToReportConnection.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClientesBindingSource
        '
        Me.ClientesBindingSource.DataMember = "Clientes"
        Me.ClientesBindingSource.DataSource = Me.SQLToReportConnection
        '
        'EmpresasBindingSource
        '
        Me.EmpresasBindingSource.DataMember = "Empresas"
        Me.EmpresasBindingSource.DataSource = Me.SQLToReportConnection
        '
        'ReparaçõesBindingSource
        '
        Me.ReparaçõesBindingSource.DataMember = "Reparações"
        Me.ReparaçõesBindingSource.DataSource = Me.SQLToReportConnection
        '
        'ParticipaçõesBindingSource
        '
        Me.ParticipaçõesBindingSource.DataMember = "Participações"
        Me.ParticipaçõesBindingSource.DataSource = Me.SQLToReportConnection
        '
        'HardwareBindingSource
        '
        Me.HardwareBindingSource.DataMember = "Hardware"
        Me.HardwareBindingSource.DataSource = Me.SQLToReportConnection
        '
        'SoftwareBindingSource
        '
        Me.SoftwareBindingSource.DataMember = "Software"
        Me.SoftwareBindingSource.DataSource = Me.SQLToReportConnection
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Artigos"
        ReportDataSource1.Value = Me.ArtigosBindingSource
        ReportDataSource2.Name = "Clientes"
        ReportDataSource2.Value = Me.ClientesBindingSource
        ReportDataSource3.Name = "Empresas"
        ReportDataSource3.Value = Me.EmpresasBindingSource
        ReportDataSource4.Name = "Reparações"
        ReportDataSource4.Value = Me.ReparaçõesBindingSource
        ReportDataSource5.Name = "Participações"
        ReportDataSource5.Value = Me.ParticipaçõesBindingSource
        ReportDataSource6.Name = "Hardware"
        ReportDataSource6.Value = Me.HardwareBindingSource
        ReportDataSource7.Name = "Software"
        ReportDataSource7.Value = Me.SoftwareBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ClinicaInformatica.Report5.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(939, 504)
        Me.ReportViewer1.TabIndex = 0
        '
        'ArtigosTableAdapter
        '
        Me.ArtigosTableAdapter.ClearBeforeFill = True
        '
        'ClientesTableAdapter
        '
        Me.ClientesTableAdapter.ClearBeforeFill = True
        '
        'EmpresasTableAdapter
        '
        Me.EmpresasTableAdapter.ClearBeforeFill = True
        '
        'ReparaçõesTableAdapter
        '
        Me.ReparaçõesTableAdapter.ClearBeforeFill = True
        '
        'ParticipaçõesTableAdapter
        '
        Me.ParticipaçõesTableAdapter.ClearBeforeFill = True
        '
        'HardwareTableAdapter
        '
        Me.HardwareTableAdapter.ClearBeforeFill = True
        '
        'SoftwareTableAdapter
        '
        Me.SoftwareTableAdapter.ClearBeforeFill = True
        '
        'folha_repar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 504)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "folha_repar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folha de Reparação - Entrega ao Cliente"
        CType(Me.ArtigosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLToReportConnection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpresasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReparaçõesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParticipaçõesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HardwareBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoftwareBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ArtigosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQLToReportConnection As ClinicaInformatica.SQLToReportConnection
    Friend WithEvents ClientesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmpresasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReparaçõesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ParticipaçõesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HardwareBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SoftwareBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ArtigosTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.ArtigosTableAdapter
    Friend WithEvents ClientesTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.ClientesTableAdapter
    Friend WithEvents EmpresasTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.EmpresasTableAdapter
    Friend WithEvents ReparaçõesTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.ReparaçõesTableAdapter
    Friend WithEvents ParticipaçõesTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.ParticipaçõesTableAdapter
    Friend WithEvents HardwareTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.HardwareTableAdapter
    Friend WithEvents SoftwareTableAdapter As ClinicaInformatica.SQLToReportConnectionTableAdapters.SoftwareTableAdapter
End Class
