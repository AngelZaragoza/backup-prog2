using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace PII_TP2_Vet
{
    public partial class frmRptProductos : Form
    {
        string consultaSQL;
        ReportDataSource repDS;
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrador\Escritorio\TUP\Prog 2\PII_TP2_Vet\Veterinaria.mdb");
        
        public frmRptProductos()
        {
            InitializeComponent();
            consultaSQL = "SELECT  P.idProducto AS Cod, M.marca AS Marca, P.descripcion AS [Nombre Producto],"
                            + " P.precio AS Precio, P.stock AS Stock, P.estado AS Estado "
                            + "FROM (Producto P INNER JOIN Marcas M ON P.idMarca = M.idMarca)";            
        }

        private void frmRptProductos_Load(object sender, EventArgs e)
        {
            
            //this.rptvProds.RefreshReport();
            cboOrden.Items.Add("Código");
            cboOrden.Items.Add("Marca");
            cboOrden.Items.Add("Nombre Producto");
            cboOrden.Items.Add("Precio");
            cboOrden.Items.Add("Stock");
            cboOrden.Items.Add("Activo");

            recargaReporte(consultaSQL, "", -1);

        }

        private void recargaReporte(string cnSQL, string param, int orden)
        {
            oDato.conectar();
            if (param != "")            
                cnSQL += " WHERE P.descripcion LIKE '%" + param + "%'";
            if (orden >= 0)
                cnSQL += " ORDER BY " + (orden+1);
            
            OleDbDataAdapter da = new OleDbDataAdapter(cnSQL, oDato.pConexion);
            DataSet ds = new DataSet();
            da.Fill(ds);

            repDS = new ReportDataSource("dsetProducto_dtProductos", ds.Tables[0]);

            rptvProds.LocalReport.DataSources.Clear();
            rptvProds.LocalReport.DataSources.Add(repDS);
            rptvProds.LocalReport.ReportEmbeddedResource = "PII_TP2_Vet.rptProductos.rdlc";

            rptvProds.LocalReport.Refresh();
            rptvProds.Refresh();
            rptvProds.RefreshReport();
            oDato.desconectar();
        }

        private void btnCargarRep_Click(object sender, EventArgs e)
        {            
            //REPORTE DE TODOS LOS PRODUCTOS
            txtFiltro.Text = "";
            cboOrden.SelectedIndex = -1;
            recargaReporte(consultaSQL,"",-1);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //REPORTE CON FILTROS APLICADOS
            recargaReporte(consultaSQL, txtFiltro.Text, cboOrden.SelectedIndex);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
