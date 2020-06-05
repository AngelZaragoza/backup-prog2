namespace PII_TP2_Vet
{
    partial class frmRptProductos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptProductos));
            this.dtProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsetProducto = new PII_TP2_Vet.dsetProducto();
            this.rptvProds = new Microsoft.Reporting.WinForms.ReportViewer();
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboOrden = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblOrden = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarRep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetProducto)).BeginInit();
            this.grpControles.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtProductosBindingSource
            // 
            this.dtProductosBindingSource.DataMember = "dtProductos";
            this.dtProductosBindingSource.DataSource = this.dsetProducto;
            // 
            // dsetProducto
            // 
            this.dsetProducto.DataSetName = "dsetProducto";
            this.dsetProducto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptvProds
            // 
            reportDataSource2.Name = "dsetProducto_dtProductos";
            reportDataSource2.Value = this.dtProductosBindingSource;
            this.rptvProds.LocalReport.DataSources.Add(reportDataSource2);
            this.rptvProds.LocalReport.ReportEmbeddedResource = "PII_TP2_Vet.rptProductos.rdlc";
            this.rptvProds.Location = new System.Drawing.Point(12, 12);
            this.rptvProds.Name = "rptvProds";
            this.rptvProds.ShowToolBar = false;
            this.rptvProds.Size = new System.Drawing.Size(928, 403);
            this.rptvProds.TabIndex = 0;
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
            this.grpControles.TabIndex = 1;
            this.grpControles.TabStop = false;
            // 
            // grpFiltros
            // 
            this.grpFiltros.BackColor = System.Drawing.Color.Transparent;
            this.grpFiltros.Controls.Add(this.txtFiltro);
            this.grpFiltros.Controls.Add(this.cboOrden);
            this.grpFiltros.Controls.Add(this.lblFiltro);
            this.grpFiltros.Controls.Add(this.lblOrden);
            this.grpFiltros.Location = new System.Drawing.Point(149, 0);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(537, 129);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(168, 33);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(135, 22);
            this.txtFiltro.TabIndex = 0;
            // 
            // cboOrden
            // 
            this.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrden.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrden.FormattingEnabled = true;
            this.cboOrden.Location = new System.Drawing.Point(168, 75);
            this.cboOrden.Name = "cboOrden";
            this.cboOrden.Size = new System.Drawing.Size(135, 22);
            this.cboOrden.TabIndex = 1;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(33, 36);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(126, 14);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Nombre contiene...";
            // 
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrden.Location = new System.Drawing.Point(63, 78);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(96, 14);
            this.lblOrden.TabIndex = 3;
            this.lblOrden.Text = "Ordenar por...";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(806, 24);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 88);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(692, 24);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(108, 88);
            this.btnFiltrar.TabIndex = 2;
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
            // frmRptProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 562);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.rptvProds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Productos";
            this.Load += new System.EventHandler(this.frmRptProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtProductosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsetProducto)).EndInit();
            this.grpControles.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvProds;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.BindingSource dtProductosBindingSource;
        private dsetProducto dsetProducto;
        private System.Windows.Forms.Button btnCargarRep;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cboOrden;
        private System.Windows.Forms.GroupBox grpFiltros;
    }
}