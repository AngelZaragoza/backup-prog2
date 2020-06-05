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
    public partial class frmRptMascotas : Form
    {
        string consultaSQL;
        ReportDataSource repDS;
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrador\Escritorio\TUP\Prog 2\PII_TP2_Vet\Veterinaria.mdb");
        
        public frmRptMascotas()
        {
            InitializeComponent();
            consultaSQL = "SELECT M.idMascota AS Cod, M.nombre AS Nombre, C.apellido+' '+C.nombre AS Duenio, TM.descripcion AS Tipo, "
                        + "R.nombreRaza AS Raza, M.sexo, M.fechaNacimiento AS FechaNac, M.peso, M.observacion, M.estado "
                        + "FROM (TipoMascota AS TM INNER JOIN (Raza AS R INNER JOIN Mascota AS M ON R.idRaza = M.idRaza) "
                        + "ON TM.idTipoMascota = M.idTipoMascota) INNER JOIN Cliente AS C ON M.idCliente = C.idCliente";

        }

        private void frmRptMascotas_Load(object sender, EventArgs e)
        {
            cboOrden.Items.Add("Código");
            cboOrden.Items.Add("Nombre");            
            cboOrden.Items.Add("Dueño");
            cboOrden.Items.Add("Tipo");
            cboOrden.Items.Add("Raza");
            cboOrden.Items.Add("Sexo");
            cboOrden.Items.Add("Fecha de Nacimiento");
            cboOrden.Items.Add("Peso");
            cboOrden.Items.Add("Observaciones");
            cboOrden.Items.Add("Activo");
            
            recargaReporte(consultaSQL, "", -1,false);
            //this.reportViewer1.RefreshReport();            
        }

        private void recargaReporte(string cnSQL, string param, int orden, bool fechas)
        {
            oDato.conectar();
            //if (param != "")
                cnSQL += " WHERE M.nombre LIKE '%" + param + "%'";
            if (fechas)
            {
                cnSQL += " AND M.fechaNacimiento BETWEEN #" + dtpDesde.Value.ToShortDateString()
                    + "# AND #" + dtpHasta.Value.ToShortDateString() + "#";
            }
            
            if (orden >= 0)
                cnSQL += " ORDER BY " + (orden + 1);

            

            OleDbDataAdapter da = new OleDbDataAdapter(cnSQL, oDato.pConexion);
            DataSet ds = new DataSet();
            da.Fill(ds);

            repDS = new ReportDataSource("dsetProducto_dtMascotas", ds.Tables[0]);

            rptvMasc.LocalReport.DataSources.Clear();
            rptvMasc.LocalReport.DataSources.Add(repDS);
            rptvMasc.LocalReport.ReportEmbeddedResource = "PII_TP2_Vet.rptMascotas.rdlc";

            rptvMasc.LocalReport.Refresh();
            rptvMasc.Refresh();
            rptvMasc.RefreshReport();
            oDato.desconectar();
        }

        private void btnCargarRep_Click(object sender, EventArgs e)
        {
            //REPORTE DE TODOS LOS PRODUCTOS
            txtFiltro.Text = "";
            cboOrden.SelectedIndex = -1;
            chkFechas.Checked = false;
            recargaReporte(consultaSQL, "", -1,false);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //REPORTE CON FILTROS APLICADOS
            recargaReporte(consultaSQL, txtFiltro.Text, cboOrden.SelectedIndex,chkFechas.Checked);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFechas.Checked;
            dtpHasta.Enabled = chkFechas.Checked;
        }
    }
}
