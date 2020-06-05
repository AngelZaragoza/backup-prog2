namespace PII_TP2_Vet
{
    partial class frmRptClientes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptClientes));
            this.rptvClientes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsetProducto = new PII_TP2_Vet.dsetProducto();
            this.dtClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cboOrden = new System.Windows.Forms.ComboBox();
            this.lblOrden = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarRep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsetProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientesBindingSource)).BeginInit();
            this.grpControles.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptvClientes
            // 
            reportDataSource1.Name = "dsetProducto_dtClientes";
            reportDataSource1.Value = this.dtClientesBindingSource;
            this.rptvClientes.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvClientes.LocalReport.ReportEmbeddedResource = "PII_TP2_Vet.rptClientes.rdlc";
            this.rptvClientes.Location = new System.Drawing.Point(12, 12);
            this.rptvClientes.Name = "rptvClientes";
            this.rptvClientes.ShowToolBar = false;
            this.rptvClientes.Size = new System.Drawing.Size(928, 403);
            this.rptvClientes.TabIndex = 0;
            // 
            // dsetProducto
            // 
            this.dsetProducto.DataSetName = "dsetProducto";
            this.dsetProducto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtClientesBindingSource
            // 
            this.dtClientesBindingSource.DataMember = "dtClientes";
            this.dtClientesBindingSource.DataSource = this.dsetProducto;
            // 
            // grpControles
            // 
            this.grpControles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grpControles.BackgroundImage")));
            this.grpControles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grpControles.Controls.Add(this.grpFiltros);
            this.grpControles.Controls.Add(this.btnCerrar);
            this.grpControles.Controls.Add(this.btnFiltrar);
            this.grpControles.Controls.Add(this.btnCargarRep);
            this.grpControles.Location = new System.Drawing.Point(12, 421);
            this.grpControles.Name = "grpControles";
            this.grpControles.Size = new System.Drawing.Size(928, 129);
            this.grpControles.TabIndex = 3;
            this.grpControles.TabStop = false;
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.Transparent;
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.chkFechas);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.cboOrden);
            this.grpFiltros.Controls.Add(this.lblOrden);
            this.grpFiltros.Controls.Add(this.lblFiltro);
            this.grpFiltros.Controls.Add(this.txtFiltro);
            this.grpFiltros.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(149, 0);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(537, 129);
            this.grpFiltros.TabIndex = 5;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Location = new System.Drawing.Point(329, 77);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(190, 22);
            this.dtpHasta.TabIndex = 16;
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechas.Location = new System.Drawing.Point(329, 16);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(186, 18);
            this.chkFechas.TabIndex = 15;
            this.chkFechas.Text = "Fecha Nac. desde / hasta";
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Location = new System.Drawing.Point(329, 44);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(190, 22);
            this.dtpDesde.TabIndex = 14;
            this.dtpDesde.Value = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            // 
            // cboOrden
            // 
            this.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrden.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrden.FormattingEnabled = true;
            this.cboOrden.Location = new System.Drawing.Point(164, 77);
            this.cboOrden.Name = "cboOrden";
            this.cboOrden.Size = new System.Drawing.Size(135, 22);
            this.cboOrden.TabIndex = 11;
            // 
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrden.Location = new System.Drawing.Point(59, 80);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(96, 14);
            this.lblOrden.TabIndex = 13;
            this.lblOrden.Text = "Ordenar por...";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(29, 47);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(126, 14);
            this.lblFiltro.TabIndex = 12;
            this.lblFiltro.Text = "Nombre contiene...";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(164, 44);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(135, 22);
            this.txtFiltro.TabIndex = 10;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(805, 24);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 88);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(691, 24);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(108, 88);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCargarRep
            // 
            this.btnCargarRep.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarRep.Location = new System.Drawing.Point(16, 24);
            this.btnCargarRep.Name = "btnCargarRep";
            this.btnCargarRep.Size = new System.Drawing.Size(108, 88);
            this.btnCargarRep.TabIndex = 0;
            this.btnCargarRep.Text = "Listado Completo";
            this.btnCargarRep.UseVisualStyleBackColor = true;
            this.btnCargarRep.Click += new System.EventHandler(this.btnCargarRep_Click);
            // 
            // frmRptClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 562);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.rptvClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRptClientes";
            this.Text = "Listado de Clientes";
            this.Load += new System.EventHandler(this.frmRptClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsetProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientesBindingSource)).EndInit();
            this.grpControles.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvClientes;
        private System.Windows.Forms.BindingSource dtClientesBindingSource;
        private dsetProducto dsetProducto;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.CheckBox chkFechas;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ComboBox cboOrden;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarRep;
    }
}