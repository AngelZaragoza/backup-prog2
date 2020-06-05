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
    public partial class frmRptClientes : Form
    {
        string consultaSQL;
        ReportDataSource repDS;
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrador\Escritorio\TUP\Prog 2\PII_TP2_Vet\Veterinaria.mdb");

        public frmRptClientes()
        {
            InitializeComponent();
            consultaSQL = "SELECT C.idCliente AS Cod, C.apellido+' '+C.nombre AS ApeNombre, C.direccion AS Direccion, "
                        + "C.telefonoFijo AS Fijo, C.telefonoCelular AS Cel, C.correo AS Correo, C.documento AS nDoc, "
                        + "C.sexo AS Sexo, C.fechaNac AS FecNac, C.estado AS Estado "
                        + "FROM Cliente AS C";

        }

        private void frmRptClientes_Load(object sender, EventArgs e)
        {
            cboOrden.Items.Add("Código");
            cboOrden.Items.Add("Apellido y Nombre");
            cboOrden.Items.Add("Dirección");
            cboOrden.Items.Add("Tel.Fijo");
            cboOrden.Items.Add("Tel.Celular");
            cboOrden.Items.Add("Correo");
            cboOrden.Items.Add("Nro.Doc");
            cboOrden.Items.Add("Sexo");
            cboOrden.Items.Add("Fecha de Nacimiento");
            cboOrden.Items.Add("Activo");

            recargaReporte(consultaSQL, "", -1, false);
         //   this.rptvClientes.RefreshReport();
        }

        private void recargaReporte(string cnSQL, string param, int orden, bool fechas)
        {
            oDato.conectar();
            //if (param != "")            
            cnSQL += " WHERE (((C.apellido+' '+C.nombre) Like '%" + param + "%'))";
            if (fechas)
            {
                cnSQL += " AND C.fechaNac BETWEEN #" + dtpDesde.Value.ToShortDateString()
                    + "# AND #" + dtpHasta.Value.ToShortDateString() + "#";
            }

            if (orden >= 0)
                cnSQL += " ORDER BY " + (orden + 1);



            OleDbDataAdapter da = new OleDbDataAdapter(cnSQL, oDato.pConexion);
            DataSet ds = new DataSet();
            da.Fill(ds);

            repDS = new ReportDataSource("dsetProducto_dtClientes", ds.Tables[0]);

            rptvClientes.LocalReport.DataSources.Clear();
            rptvClientes.LocalReport.DataSources.Add(repDS);
            rptvClientes.LocalReport.ReportEmbeddedResource = "PII_TP2_Vet.rptClientes.rdlc";

            rptvClientes.LocalReport.Refresh();
            rptvClientes.Refresh();
            rptvClientes.RefreshReport();
            oDato.desconectar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //REPORTE CON FILTROS APLICADOS
            recargaReporte(consultaSQL, txtFiltro.Text, cboOrden.SelectedIndex, chkFechas.Checked);
        }

        private void btnCargarRep_Click(object sender, EventArgs e)
        {
            //REPORTE DE TODOS LOS PRODUCTOS
            txtFiltro.Text = "";
            cboOrden.SelectedIndex = -1;
            chkFechas.Checked = false;
            recargaReporte(consultaSQL, "", -1, false);
        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFechas.Checked;
            dtpHasta.Enabled = chkFechas.Checked;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
