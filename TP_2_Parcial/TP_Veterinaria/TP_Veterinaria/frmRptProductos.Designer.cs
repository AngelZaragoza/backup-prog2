namespace TP_Veterinaria
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptwProds = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsetVeterinaria = new TP_Veterinaria.dsetVeterinaria();
            this.dtProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtProductosTableAdapter = new TP_Veterinaria.dsetVeterinariaTableAdapters.dtProductosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsetVeterinaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptwProds
            // 
            reportDataSource1.Name = "dsetVeterinaria_dtProductos";
            reportDataSource1.Value = this.dtProductosBindingSource;
            this.rptwProds.LocalReport.DataSources.Add(reportDataSource1);
            this.rptwProds.LocalReport.ReportEmbeddedResource = "TP_Veterinaria.rptProductos.rdlc";
            this.rptwProds.Location = new System.Drawing.Point(21, 18);
            this.rptwProds.Name = "rptwProds";
            this.rptwProds.Size = new System.Drawing.Size(843, 388);
            this.rptwProds.TabIndex = 0;
            // 
            // dsetVeterinaria
            // 
            this.dsetVeterinaria.DataSetName = "dsetVeterinaria";
            this.dsetVeterinaria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtProductosBindingSource
            // 
            this.dtProductosBindingSource.DataMember = "dtProductos";
            this.dtProductosBindingSource.DataSource = this.dsetVeterinaria;
            // 
            // dtProductosTableAdapter
            // 
            this.dtProductosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRptProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 512);
            this.Controls.Add(this.rptwProds);
            this.Name = "frmRptProductos";
            this.Text = "Listado de Productos";
            this.Load += new System.EventHandler(this.frmRptProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsetVeterinaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptwProds;
        private System.Windows.Forms.BindingSource dtProductosBindingSource;
        private dsetVeterinaria dsetVeterinaria;
        private TP_Veterinaria.dsetVeterinariaTableAdapters.dtProductosTableAdapter dtProductosTableAdapter;

    }
}