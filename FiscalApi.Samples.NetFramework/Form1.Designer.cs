﻿namespace FiscalApi.Samples.NetFramework
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ObtenerFacturaById = new System.Windows.Forms.Button();
            this.FacturaIngresoPorValores = new System.Windows.Forms.Button();
            this.FacturaIngresoPorRefs = new System.Windows.Forms.Button();
            this.NotaCreditoValores = new System.Windows.Forms.Button();
            this.NotaCreditoRefs = new System.Windows.Forms.Button();
            this.CfdiPagoRefs = new System.Windows.Forms.Button();
            this.CfdiPagoValores = new System.Windows.Forms.Button();
            this.GenerarPDFValores = new System.Windows.Forms.Button();
            this.CancelByValues = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GenerarPDFRefs = new System.Windows.Forms.Button();
            this.ObtenerFacturaXMLById = new System.Windows.Forms.Button();
            this.EnviarPorValores = new System.Windows.Forms.Button();
            this.EnviarPorReferencia = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ObtenerListaPaginadaInvoices = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ObtenerListaPaginada = new System.Windows.Forms.Button();
            this.BorrarPersona = new System.Windows.Forms.Button();
            this.ActualizarPersona = new System.Windows.Forms.Button();
            this.CrearPersona = new System.Windows.Forms.Button();
            this.ObtenerPersonaPorID = new System.Windows.Forms.Button();
            this.ObtenerUltimosCertficadosValidos = new System.Windows.Forms.Button();
            this.EliEliminaCertificado = new System.Windows.Forms.Button();
            this.ObtenerCertificadoById = new System.Windows.Forms.Button();
            this.CargarCertificados = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ActualizarImpuestosProducto = new System.Windows.Forms.Button();
            this.ObtenerImpuestosProducto = new System.Windows.Forms.Button();
            this.ObtenerProductosPagedList = new System.Windows.Forms.Button();
            this.BorrarProducto = new System.Windows.Forms.Button();
            this.ActualizarProducto = new System.Windows.Forms.Button();
            this.CrearProducto = new System.Windows.Forms.Button();
            this.ObtenerProductoById = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UpdateApiKey = new System.Windows.Forms.Button();
            this.ObtenerPagedListApikeys = new System.Windows.Forms.Button();
            this.RevocaApikey = new System.Windows.Forms.Button();
            this.CrearApikey = new System.Windows.Forms.Button();
            this.ObtenerApikeyByID = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ObtenerCatalogosDisponibles = new System.Windows.Forms.Button();
            this.BuscarCatalogo = new System.Windows.Forms.Button();
            this.BuscarCodigoUnidad = new System.Windows.Forms.Button();
            this.BuscarCodigoProductoServicio = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CertDefaultRefs = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ObtenerCatalogRecordPorId = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObtenerFacturaById
            // 
            this.ObtenerFacturaById.Location = new System.Drawing.Point(16, 23);
            this.ObtenerFacturaById.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerFacturaById.Name = "ObtenerFacturaById";
            this.ObtenerFacturaById.Size = new System.Drawing.Size(147, 60);
            this.ObtenerFacturaById.TabIndex = 0;
            this.ObtenerFacturaById.Text = "Obtener factura por ID";
            this.ObtenerFacturaById.UseVisualStyleBackColor = true;
            this.ObtenerFacturaById.Click += new System.EventHandler(this.ObtenerFacturaById_Click);
            // 
            // FacturaIngresoPorValores
            // 
            this.FacturaIngresoPorValores.Location = new System.Drawing.Point(171, 23);
            this.FacturaIngresoPorValores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FacturaIngresoPorValores.Name = "FacturaIngresoPorValores";
            this.FacturaIngresoPorValores.Size = new System.Drawing.Size(147, 60);
            this.FacturaIngresoPorValores.TabIndex = 1;
            this.FacturaIngresoPorValores.Text = "Crear factura de ingreso por valores";
            this.FacturaIngresoPorValores.UseVisualStyleBackColor = true;
            this.FacturaIngresoPorValores.Click += new System.EventHandler(this.FacturaIngresoPorValores_Click);
            // 
            // FacturaIngresoPorRefs
            // 
            this.FacturaIngresoPorRefs.Location = new System.Drawing.Point(325, 23);
            this.FacturaIngresoPorRefs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FacturaIngresoPorRefs.Name = "FacturaIngresoPorRefs";
            this.FacturaIngresoPorRefs.Size = new System.Drawing.Size(147, 60);
            this.FacturaIngresoPorRefs.TabIndex = 2;
            this.FacturaIngresoPorRefs.Text = "Crear factura de ingreso por referencias";
            this.FacturaIngresoPorRefs.UseVisualStyleBackColor = true;
            this.FacturaIngresoPorRefs.Click += new System.EventHandler(this.FacturaIngresoPorRefs_Click);
            // 
            // NotaCreditoValores
            // 
            this.NotaCreditoValores.Location = new System.Drawing.Point(171, 91);
            this.NotaCreditoValores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NotaCreditoValores.Name = "NotaCreditoValores";
            this.NotaCreditoValores.Size = new System.Drawing.Size(147, 60);
            this.NotaCreditoValores.TabIndex = 3;
            this.NotaCreditoValores.Text = "Crear nota de credito por valores";
            this.NotaCreditoValores.UseVisualStyleBackColor = true;
            this.NotaCreditoValores.Click += new System.EventHandler(this.NotaCreditoValores_Click);
            // 
            // NotaCreditoRefs
            // 
            this.NotaCreditoRefs.Location = new System.Drawing.Point(325, 91);
            this.NotaCreditoRefs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NotaCreditoRefs.Name = "NotaCreditoRefs";
            this.NotaCreditoRefs.Size = new System.Drawing.Size(147, 60);
            this.NotaCreditoRefs.TabIndex = 4;
            this.NotaCreditoRefs.Text = "Crear nota de credito por referencias";
            this.NotaCreditoRefs.UseVisualStyleBackColor = true;
            this.NotaCreditoRefs.Click += new System.EventHandler(this.NotaCreditoRefs_Click);
            // 
            // CfdiPagoRefs
            // 
            this.CfdiPagoRefs.Location = new System.Drawing.Point(325, 159);
            this.CfdiPagoRefs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CfdiPagoRefs.Name = "CfdiPagoRefs";
            this.CfdiPagoRefs.Size = new System.Drawing.Size(147, 60);
            this.CfdiPagoRefs.TabIndex = 6;
            this.CfdiPagoRefs.Text = "Crear complemento de pago  por referencias";
            this.CfdiPagoRefs.UseVisualStyleBackColor = true;
            this.CfdiPagoRefs.Click += new System.EventHandler(this.FacturaComplementoPagoRefs_Click);
            // 
            // CfdiPagoValores
            // 
            this.CfdiPagoValores.Location = new System.Drawing.Point(171, 159);
            this.CfdiPagoValores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CfdiPagoValores.Name = "CfdiPagoValores";
            this.CfdiPagoValores.Size = new System.Drawing.Size(147, 60);
            this.CfdiPagoValores.TabIndex = 5;
            this.CfdiPagoValores.Text = "Crear complemento de pago  por valores";
            this.CfdiPagoValores.UseVisualStyleBackColor = true;
            this.CfdiPagoValores.Click += new System.EventHandler(this.FacturaComplementoValores_Click);
            // 
            // GenerarPDFValores
            // 
            this.GenerarPDFValores.Location = new System.Drawing.Point(16, 91);
            this.GenerarPDFValores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerarPDFValores.Name = "GenerarPDFValores";
            this.GenerarPDFValores.Size = new System.Drawing.Size(147, 60);
            this.GenerarPDFValores.TabIndex = 7;
            this.GenerarPDFValores.Text = "Generar PDF por valores";
            this.GenerarPDFValores.UseVisualStyleBackColor = true;
            this.GenerarPDFValores.Click += new System.EventHandler(this.GenerarPDFValores_Click);
            // 
            // CancelByValues
            // 
            this.CancelByValues.Location = new System.Drawing.Point(171, 234);
            this.CancelByValues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelByValues.Name = "CancelByValues";
            this.CancelByValues.Size = new System.Drawing.Size(147, 60);
            this.CancelByValues.TabIndex = 8;
            this.CancelByValues.Text = "Cancelar factua por valores";
            this.CancelByValues.UseVisualStyleBackColor = true;
            this.CancelByValues.Click += new System.EventHandler(this.CancelByValues_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 234);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancelar factua por referencias";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CancelByRefs_Click);
            // 
            // GenerarPDFRefs
            // 
            this.GenerarPDFRefs.Location = new System.Drawing.Point(16, 159);
            this.GenerarPDFRefs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerarPDFRefs.Name = "GenerarPDFRefs";
            this.GenerarPDFRefs.Size = new System.Drawing.Size(147, 60);
            this.GenerarPDFRefs.TabIndex = 10;
            this.GenerarPDFRefs.Text = "Generar PDF por referencia";
            this.GenerarPDFRefs.UseVisualStyleBackColor = true;
            this.GenerarPDFRefs.Click += new System.EventHandler(this.GenerarPDFRefs_Click);
            // 
            // ObtenerFacturaXMLById
            // 
            this.ObtenerFacturaXMLById.Location = new System.Drawing.Point(16, 234);
            this.ObtenerFacturaXMLById.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerFacturaXMLById.Name = "ObtenerFacturaXMLById";
            this.ObtenerFacturaXMLById.Size = new System.Drawing.Size(147, 60);
            this.ObtenerFacturaXMLById.TabIndex = 11;
            this.ObtenerFacturaXMLById.Text = "Obtener Factura XML By Id";
            this.ObtenerFacturaXMLById.UseVisualStyleBackColor = true;
            this.ObtenerFacturaXMLById.Click += new System.EventHandler(this.ObtenerFacturaXMLById_Click);
            // 
            // EnviarPorValores
            // 
            this.EnviarPorValores.Location = new System.Drawing.Point(325, 302);
            this.EnviarPorValores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnviarPorValores.Name = "EnviarPorValores";
            this.EnviarPorValores.Size = new System.Drawing.Size(147, 60);
            this.EnviarPorValores.TabIndex = 12;
            this.EnviarPorValores.Text = "Enviar factura por Email por valores";
            this.EnviarPorValores.UseVisualStyleBackColor = true;
            this.EnviarPorValores.Click += new System.EventHandler(this.EnviarPorValores_Click);
            // 
            // EnviarPorReferencia
            // 
            this.EnviarPorReferencia.Location = new System.Drawing.Point(171, 302);
            this.EnviarPorReferencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnviarPorReferencia.Name = "EnviarPorReferencia";
            this.EnviarPorReferencia.Size = new System.Drawing.Size(147, 60);
            this.EnviarPorReferencia.TabIndex = 13;
            this.EnviarPorReferencia.Text = "Enviar factura por Email por referencia";
            this.EnviarPorReferencia.UseVisualStyleBackColor = true;
            this.EnviarPorReferencia.Click += new System.EventHandler(this.EnviarPorReferencia_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ObtenerListaPaginadaInvoices);
            this.groupBox2.Controls.Add(this.FacturaIngresoPorRefs);
            this.groupBox2.Controls.Add(this.EnviarPorReferencia);
            this.groupBox2.Controls.Add(this.ObtenerFacturaById);
            this.groupBox2.Controls.Add(this.EnviarPorValores);
            this.groupBox2.Controls.Add(this.FacturaIngresoPorValores);
            this.groupBox2.Controls.Add(this.ObtenerFacturaXMLById);
            this.groupBox2.Controls.Add(this.NotaCreditoValores);
            this.groupBox2.Controls.Add(this.GenerarPDFRefs);
            this.groupBox2.Controls.Add(this.NotaCreditoRefs);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.CfdiPagoValores);
            this.groupBox2.Controls.Add(this.CancelByValues);
            this.groupBox2.Controls.Add(this.CfdiPagoRefs);
            this.groupBox2.Controls.Add(this.GenerarPDFValores);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(489, 384);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FACTURACION";
            // 
            // ObtenerListaPaginadaInvoices
            // 
            this.ObtenerListaPaginadaInvoices.Location = new System.Drawing.Point(16, 302);
            this.ObtenerListaPaginadaInvoices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerListaPaginadaInvoices.Name = "ObtenerListaPaginadaInvoices";
            this.ObtenerListaPaginadaInvoices.Size = new System.Drawing.Size(147, 60);
            this.ObtenerListaPaginadaInvoices.TabIndex = 14;
            this.ObtenerListaPaginadaInvoices.Text = "Obtener Lista Paginada";
            this.ObtenerListaPaginadaInvoices.UseVisualStyleBackColor = true;
            this.ObtenerListaPaginadaInvoices.Click += new System.EventHandler(this.ObtenerListaPaginadaInvoices_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ObtenerListaPaginada);
            this.groupBox1.Controls.Add(this.BorrarPersona);
            this.groupBox1.Controls.Add(this.ActualizarPersona);
            this.groupBox1.Controls.Add(this.CrearPersona);
            this.groupBox1.Controls.Add(this.ObtenerPersonaPorID);
            this.groupBox1.Location = new System.Drawing.Point(513, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(441, 384);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PERSONAS (Emisores, receptores, usuarios, clientes etc)";
            // 
            // ObtenerListaPaginada
            // 
            this.ObtenerListaPaginada.Location = new System.Drawing.Point(8, 175);
            this.ObtenerListaPaginada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerListaPaginada.Name = "ObtenerListaPaginada";
            this.ObtenerListaPaginada.Size = new System.Drawing.Size(192, 62);
            this.ObtenerListaPaginada.TabIndex = 5;
            this.ObtenerListaPaginada.Text = "Obtener lista paginada";
            this.ObtenerListaPaginada.UseVisualStyleBackColor = true;
            this.ObtenerListaPaginada.Click += new System.EventHandler(this.ObtenerListaPaginada_Click);
            // 
            // BorrarPersona
            // 
            this.BorrarPersona.Location = new System.Drawing.Point(241, 106);
            this.BorrarPersona.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BorrarPersona.Name = "BorrarPersona";
            this.BorrarPersona.Size = new System.Drawing.Size(192, 62);
            this.BorrarPersona.TabIndex = 4;
            this.BorrarPersona.Text = "Borrar persona";
            this.BorrarPersona.UseVisualStyleBackColor = true;
            this.BorrarPersona.Click += new System.EventHandler(this.BorrarPersona_Click);
            // 
            // ActualizarPersona
            // 
            this.ActualizarPersona.Location = new System.Drawing.Point(241, 37);
            this.ActualizarPersona.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ActualizarPersona.Name = "ActualizarPersona";
            this.ActualizarPersona.Size = new System.Drawing.Size(192, 62);
            this.ActualizarPersona.TabIndex = 3;
            this.ActualizarPersona.Text = "Actualizar persona";
            this.ActualizarPersona.UseVisualStyleBackColor = true;
            this.ActualizarPersona.Click += new System.EventHandler(this.ActualizarPersona_Click);
            // 
            // CrearPersona
            // 
            this.CrearPersona.Location = new System.Drawing.Point(8, 37);
            this.CrearPersona.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CrearPersona.Name = "CrearPersona";
            this.CrearPersona.Size = new System.Drawing.Size(192, 62);
            this.CrearPersona.TabIndex = 2;
            this.CrearPersona.Text = "Crear Persona";
            this.CrearPersona.UseVisualStyleBackColor = true;
            this.CrearPersona.Click += new System.EventHandler(this.CrearPersona_Click);
            // 
            // ObtenerPersonaPorID
            // 
            this.ObtenerPersonaPorID.Location = new System.Drawing.Point(8, 106);
            this.ObtenerPersonaPorID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerPersonaPorID.Name = "ObtenerPersonaPorID";
            this.ObtenerPersonaPorID.Size = new System.Drawing.Size(192, 62);
            this.ObtenerPersonaPorID.TabIndex = 1;
            this.ObtenerPersonaPorID.Text = "Obtener persona por ID";
            this.ObtenerPersonaPorID.UseVisualStyleBackColor = true;
            this.ObtenerPersonaPorID.Click += new System.EventHandler(this.ObtenerPersonaPorID_Click);
            // 
            // ObtenerUltimosCertficadosValidos
            // 
            this.ObtenerUltimosCertficadosValidos.Location = new System.Drawing.Point(241, 23);
            this.ObtenerUltimosCertficadosValidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerUltimosCertficadosValidos.Name = "ObtenerUltimosCertficadosValidos";
            this.ObtenerUltimosCertficadosValidos.Size = new System.Drawing.Size(192, 62);
            this.ObtenerUltimosCertficadosValidos.TabIndex = 9;
            this.ObtenerUltimosCertficadosValidos.Text = "Obtener ultimos certficados validos de una persona";
            this.ObtenerUltimosCertficadosValidos.UseVisualStyleBackColor = true;
            this.ObtenerUltimosCertficadosValidos.Click += new System.EventHandler(this.ObtenerUltimosCertficadosValidos_Click);
            // 
            // EliEliminaCertificado
            // 
            this.EliEliminaCertificado.Location = new System.Drawing.Point(241, 161);
            this.EliEliminaCertificado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EliEliminaCertificado.Name = "EliEliminaCertificado";
            this.EliEliminaCertificado.Size = new System.Drawing.Size(192, 62);
            this.EliEliminaCertificado.TabIndex = 8;
            this.EliEliminaCertificado.Text = "Elimina Certificado de una persona";
            this.EliEliminaCertificado.UseVisualStyleBackColor = true;
            this.EliEliminaCertificado.Click += new System.EventHandler(this.EliEliminaCertificado_Click);
            // 
            // ObtenerCertificadoById
            // 
            this.ObtenerCertificadoById.Location = new System.Drawing.Point(8, 92);
            this.ObtenerCertificadoById.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerCertificadoById.Name = "ObtenerCertificadoById";
            this.ObtenerCertificadoById.Size = new System.Drawing.Size(192, 62);
            this.ObtenerCertificadoById.TabIndex = 7;
            this.ObtenerCertificadoById.Text = "Obtener Certificado by Id";
            this.ObtenerCertificadoById.UseVisualStyleBackColor = true;
            this.ObtenerCertificadoById.Click += new System.EventHandler(this.ObtenerCertificadoById_Click);
            // 
            // CargarCertificados
            // 
            this.CargarCertificados.Location = new System.Drawing.Point(8, 23);
            this.CargarCertificados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CargarCertificados.Name = "CargarCertificados";
            this.CargarCertificados.Size = new System.Drawing.Size(192, 62);
            this.CargarCertificados.TabIndex = 6;
            this.CargarCertificados.Text = "Crear certificado (cargar cert a una persona)";
            this.CargarCertificados.UseVisualStyleBackColor = true;
            this.CargarCertificados.Click += new System.EventHandler(this.CargarCertificados_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ActualizarImpuestosProducto);
            this.groupBox3.Controls.Add(this.ObtenerImpuestosProducto);
            this.groupBox3.Controls.Add(this.ObtenerProductosPagedList);
            this.groupBox3.Controls.Add(this.BorrarProducto);
            this.groupBox3.Controls.Add(this.ActualizarProducto);
            this.groupBox3.Controls.Add(this.CrearProducto);
            this.groupBox3.Controls.Add(this.ObtenerProductoById);
            this.groupBox3.Location = new System.Drawing.Point(963, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(472, 384);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Productos";
            // 
            // ActualizarImpuestosProducto
            // 
            this.ActualizarImpuestosProducto.Location = new System.Drawing.Point(208, 92);
            this.ActualizarImpuestosProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ActualizarImpuestosProducto.Name = "ActualizarImpuestosProducto";
            this.ActualizarImpuestosProducto.Size = new System.Drawing.Size(192, 62);
            this.ActualizarImpuestosProducto.TabIndex = 12;
            this.ActualizarImpuestosProducto.Text = "Actualizar impuestos";
            this.ActualizarImpuestosProducto.UseVisualStyleBackColor = true;
            this.ActualizarImpuestosProducto.Click += new System.EventHandler(this.ActualizarImpuestosProducto_Click);
            // 
            // ObtenerImpuestosProducto
            // 
            this.ObtenerImpuestosProducto.Location = new System.Drawing.Point(208, 23);
            this.ObtenerImpuestosProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerImpuestosProducto.Name = "ObtenerImpuestosProducto";
            this.ObtenerImpuestosProducto.Size = new System.Drawing.Size(192, 62);
            this.ObtenerImpuestosProducto.TabIndex = 11;
            this.ObtenerImpuestosProducto.Text = "Obtener impuestos";
            this.ObtenerImpuestosProducto.UseVisualStyleBackColor = true;
            this.ObtenerImpuestosProducto.Click += new System.EventHandler(this.ObtenerImpuestosProducto_Click);
            // 
            // ObtenerProductosPagedList
            // 
            this.ObtenerProductosPagedList.Location = new System.Drawing.Point(8, 92);
            this.ObtenerProductosPagedList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerProductosPagedList.Name = "ObtenerProductosPagedList";
            this.ObtenerProductosPagedList.Size = new System.Drawing.Size(192, 62);
            this.ObtenerProductosPagedList.TabIndex = 10;
            this.ObtenerProductosPagedList.Text = "Obtener lista paginada";
            this.ObtenerProductosPagedList.UseVisualStyleBackColor = true;
            this.ObtenerProductosPagedList.Click += new System.EventHandler(this.ObtenerProductosPagedList_Click);
            // 
            // BorrarProducto
            // 
            this.BorrarProducto.Location = new System.Drawing.Point(208, 161);
            this.BorrarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BorrarProducto.Name = "BorrarProducto";
            this.BorrarProducto.Size = new System.Drawing.Size(192, 62);
            this.BorrarProducto.TabIndex = 9;
            this.BorrarProducto.Text = "Borrar producto";
            this.BorrarProducto.UseVisualStyleBackColor = true;
            this.BorrarProducto.Click += new System.EventHandler(this.BorrarProducto_Click);
            // 
            // ActualizarProducto
            // 
            this.ActualizarProducto.Location = new System.Drawing.Point(8, 226);
            this.ActualizarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ActualizarProducto.Name = "ActualizarProducto";
            this.ActualizarProducto.Size = new System.Drawing.Size(192, 62);
            this.ActualizarProducto.TabIndex = 8;
            this.ActualizarProducto.Text = "Actualizar producto";
            this.ActualizarProducto.UseVisualStyleBackColor = true;
            this.ActualizarProducto.Click += new System.EventHandler(this.ActualizarProducto_Click);
            // 
            // CrearProducto
            // 
            this.CrearProducto.Location = new System.Drawing.Point(8, 158);
            this.CrearProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CrearProducto.Name = "CrearProducto";
            this.CrearProducto.Size = new System.Drawing.Size(192, 62);
            this.CrearProducto.TabIndex = 7;
            this.CrearProducto.Text = "Crear producto";
            this.CrearProducto.UseVisualStyleBackColor = true;
            this.CrearProducto.Click += new System.EventHandler(this.CrearProducto_Click);
            // 
            // ObtenerProductoById
            // 
            this.ObtenerProductoById.Location = new System.Drawing.Point(8, 23);
            this.ObtenerProductoById.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerProductoById.Name = "ObtenerProductoById";
            this.ObtenerProductoById.Size = new System.Drawing.Size(192, 62);
            this.ObtenerProductoById.TabIndex = 6;
            this.ObtenerProductoById.Text = "Obtener producto por ID";
            this.ObtenerProductoById.UseVisualStyleBackColor = true;
            this.ObtenerProductoById.Click += new System.EventHandler(this.ObtenerProductoById_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.UpdateApiKey);
            this.groupBox4.Controls.Add(this.ObtenerPagedListApikeys);
            this.groupBox4.Controls.Add(this.RevocaApikey);
            this.groupBox4.Controls.Add(this.CrearApikey);
            this.groupBox4.Controls.Add(this.ObtenerApikeyByID);
            this.groupBox4.Location = new System.Drawing.Point(16, 406);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(489, 236);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Api Keys";
            // 
            // UpdateApiKey
            // 
            this.UpdateApiKey.Location = new System.Drawing.Point(215, 92);
            this.UpdateApiKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateApiKey.Name = "UpdateApiKey";
            this.UpdateApiKey.Size = new System.Drawing.Size(192, 62);
            this.UpdateApiKey.TabIndex = 18;
            this.UpdateApiKey.Text = "Obtener api-key por ID";
            this.UpdateApiKey.UseVisualStyleBackColor = true;
            this.UpdateApiKey.Click += new System.EventHandler(this.UpdateApiKey_Click);
            // 
            // ObtenerPagedListApikeys
            // 
            this.ObtenerPagedListApikeys.Location = new System.Drawing.Point(15, 92);
            this.ObtenerPagedListApikeys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerPagedListApikeys.Name = "ObtenerPagedListApikeys";
            this.ObtenerPagedListApikeys.Size = new System.Drawing.Size(192, 62);
            this.ObtenerPagedListApikeys.TabIndex = 17;
            this.ObtenerPagedListApikeys.Text = "Obtener lista paginada";
            this.ObtenerPagedListApikeys.UseVisualStyleBackColor = true;
            this.ObtenerPagedListApikeys.Click += new System.EventHandler(this.ObtenerPagedListApikeys_Click);
            // 
            // RevocaApikey
            // 
            this.RevocaApikey.Location = new System.Drawing.Point(16, 161);
            this.RevocaApikey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevocaApikey.Name = "RevocaApikey";
            this.RevocaApikey.Size = new System.Drawing.Size(192, 62);
            this.RevocaApikey.TabIndex = 15;
            this.RevocaApikey.Text = "Revocar ApiKey";
            this.RevocaApikey.UseVisualStyleBackColor = true;
            this.RevocaApikey.Click += new System.EventHandler(this.RevocaApikey_Click);
            // 
            // CrearApikey
            // 
            this.CrearApikey.Location = new System.Drawing.Point(215, 23);
            this.CrearApikey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CrearApikey.Name = "CrearApikey";
            this.CrearApikey.Size = new System.Drawing.Size(192, 62);
            this.CrearApikey.TabIndex = 14;
            this.CrearApikey.Text = "Crear ApiKey";
            this.CrearApikey.UseVisualStyleBackColor = true;
            this.CrearApikey.Click += new System.EventHandler(this.CrearApikey_Click);
            // 
            // ObtenerApikeyByID
            // 
            this.ObtenerApikeyByID.Location = new System.Drawing.Point(15, 23);
            this.ObtenerApikeyByID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerApikeyByID.Name = "ObtenerApikeyByID";
            this.ObtenerApikeyByID.Size = new System.Drawing.Size(192, 62);
            this.ObtenerApikeyByID.TabIndex = 13;
            this.ObtenerApikeyByID.Text = "Obtener api-key por ID";
            this.ObtenerApikeyByID.UseVisualStyleBackColor = true;
            this.ObtenerApikeyByID.Click += new System.EventHandler(this.ObtenerApikeyByID_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ObtenerCatalogRecordPorId);
            this.groupBox5.Controls.Add(this.ObtenerCatalogosDisponibles);
            this.groupBox5.Controls.Add(this.BuscarCatalogo);
            this.groupBox5.Controls.Add(this.BuscarCodigoUnidad);
            this.groupBox5.Controls.Add(this.BuscarCodigoProductoServicio);
            this.groupBox5.Location = new System.Drawing.Point(963, 406);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(472, 236);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Catalogos";
            // 
            // ObtenerCatalogosDisponibles
            // 
            this.ObtenerCatalogosDisponibles.Location = new System.Drawing.Point(15, 23);
            this.ObtenerCatalogosDisponibles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ObtenerCatalogosDisponibles.Name = "ObtenerCatalogosDisponibles";
            this.ObtenerCatalogosDisponibles.Size = new System.Drawing.Size(192, 62);
            this.ObtenerCatalogosDisponibles.TabIndex = 18;
            this.ObtenerCatalogosDisponibles.Text = "Obtener Catalogos disponibles";
            this.ObtenerCatalogosDisponibles.UseVisualStyleBackColor = true;
            this.ObtenerCatalogosDisponibles.Click += new System.EventHandler(this.ObtenerCatalogosDisponibles_Click);
            // 
            // BuscarCatalogo
            // 
            this.BuscarCatalogo.Location = new System.Drawing.Point(215, 161);
            this.BuscarCatalogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BuscarCatalogo.Name = "BuscarCatalogo";
            this.BuscarCatalogo.Size = new System.Drawing.Size(192, 62);
            this.BuscarCatalogo.TabIndex = 17;
            this.BuscarCatalogo.Text = "Buscar en cualquier catalogo SAT";
            this.BuscarCatalogo.UseVisualStyleBackColor = true;
            this.BuscarCatalogo.Click += new System.EventHandler(this.BuscarCatalogo_Click);
            // 
            // BuscarCodigoUnidad
            // 
            this.BuscarCodigoUnidad.Location = new System.Drawing.Point(215, 92);
            this.BuscarCodigoUnidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BuscarCodigoUnidad.Name = "BuscarCodigoUnidad";
            this.BuscarCodigoUnidad.Size = new System.Drawing.Size(192, 62);
            this.BuscarCodigoUnidad.TabIndex = 14;
            this.BuscarCodigoUnidad.Text = "Buscar Codigo Unidad";
            this.BuscarCodigoUnidad.UseVisualStyleBackColor = true;
            this.BuscarCodigoUnidad.Click += new System.EventHandler(this.BuscarCodigoUnidad_Click);
            // 
            // BuscarCodigoProductoServicio
            // 
            this.BuscarCodigoProductoServicio.Location = new System.Drawing.Point(215, 23);
            this.BuscarCodigoProductoServicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BuscarCodigoProductoServicio.Name = "BuscarCodigoProductoServicio";
            this.BuscarCodigoProductoServicio.Size = new System.Drawing.Size(192, 62);
            this.BuscarCodigoProductoServicio.TabIndex = 13;
            this.BuscarCodigoProductoServicio.Text = "Buscar Codigo Producto Servicio";
            this.BuscarCodigoProductoServicio.UseVisualStyleBackColor = true;
            this.BuscarCodigoProductoServicio.Click += new System.EventHandler(this.BuscarCodigoProductoServicio_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CertDefaultRefs);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.CargarCertificados);
            this.groupBox6.Controls.Add(this.ObtenerCertificadoById);
            this.groupBox6.Controls.Add(this.EliEliminaCertificado);
            this.groupBox6.Controls.Add(this.ObtenerUltimosCertficadosValidos);
            this.groupBox6.Location = new System.Drawing.Point(513, 406);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(441, 236);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Certificados (sellos)";
            // 
            // CertDefaultRefs
            // 
            this.CertDefaultRefs.Location = new System.Drawing.Point(241, 92);
            this.CertDefaultRefs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CertDefaultRefs.Name = "CertDefaultRefs";
            this.CertDefaultRefs.Size = new System.Drawing.Size(192, 62);
            this.CertDefaultRefs.TabIndex = 11;
            this.CertDefaultRefs.Text = "Obtener ultimos id de certficados validos de una persona";
            this.CertDefaultRefs.UseVisualStyleBackColor = true;
            this.CertDefaultRefs.Click += new System.EventHandler(this.CertDefaultRefs_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 161);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 62);
            this.button2.TabIndex = 10;
            this.button2.Text = "Obtener lista paginada";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.listarCertificados_Click);
            // 
            // ObtenerCatalogRecordPorId
            // 
            this.ObtenerCatalogRecordPorId.Location = new System.Drawing.Point(15, 93);
            this.ObtenerCatalogRecordPorId.Margin = new System.Windows.Forms.Padding(4);
            this.ObtenerCatalogRecordPorId.Name = "ObtenerCatalogRecordPorId";
            this.ObtenerCatalogRecordPorId.Size = new System.Drawing.Size(192, 62);
            this.ObtenerCatalogRecordPorId.TabIndex = 19;
            this.ObtenerCatalogRecordPorId.Text = "Obtener registro por Id";
            this.ObtenerCatalogRecordPorId.UseVisualStyleBackColor = true;
            this.ObtenerCatalogRecordPorId.Click += new System.EventHandler(this.ObtenerCatalogRecordPorId_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 802);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ObtenerFacturaById;
        private System.Windows.Forms.Button FacturaIngresoPorValores;
        private System.Windows.Forms.Button FacturaIngresoPorRefs;
        private System.Windows.Forms.Button NotaCreditoValores;
        private System.Windows.Forms.Button NotaCreditoRefs;
        private System.Windows.Forms.Button CfdiPagoRefs;
        private System.Windows.Forms.Button CfdiPagoValores;
        private System.Windows.Forms.Button GenerarPDFValores;
        private System.Windows.Forms.Button CancelByValues;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button GenerarPDFRefs;
        private System.Windows.Forms.Button ObtenerFacturaXMLById;
        private System.Windows.Forms.Button EnviarPorValores;
        private System.Windows.Forms.Button EnviarPorReferencia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ObtenerPersonaPorID;
        private System.Windows.Forms.Button CrearPersona;
        private System.Windows.Forms.Button ActualizarPersona;
        private System.Windows.Forms.Button BorrarPersona;
        private System.Windows.Forms.Button ObtenerListaPaginada;
        private System.Windows.Forms.Button ObtenerListaPaginadaInvoices;
        private System.Windows.Forms.Button CargarCertificados;
        private System.Windows.Forms.Button ObtenerCertificadoById;
        private System.Windows.Forms.Button EliEliminaCertificado;
        private System.Windows.Forms.Button ObtenerUltimosCertficadosValidos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ActualizarImpuestosProducto;
        private System.Windows.Forms.Button ObtenerImpuestosProducto;
        private System.Windows.Forms.Button ObtenerProductosPagedList;
        private System.Windows.Forms.Button BorrarProducto;
        private System.Windows.Forms.Button ActualizarProducto;
        private System.Windows.Forms.Button CrearProducto;
        private System.Windows.Forms.Button ObtenerProductoById;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ObtenerPagedListApikeys;
        private System.Windows.Forms.Button RevocaApikey;
        private System.Windows.Forms.Button CrearApikey;
        private System.Windows.Forms.Button ObtenerApikeyByID;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BuscarCatalogo;
        private System.Windows.Forms.Button BuscarCodigoUnidad;
        private System.Windows.Forms.Button BuscarCodigoProductoServicio;
        private System.Windows.Forms.Button ObtenerCatalogosDisponibles;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CertDefaultRefs;
        private System.Windows.Forms.Button UpdateApiKey;
        private System.Windows.Forms.Button ObtenerCatalogRecordPorId;
    }
}

