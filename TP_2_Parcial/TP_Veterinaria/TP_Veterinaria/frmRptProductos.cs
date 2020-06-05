using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_Veterinaria
{
    public partial class frmRptProductos : Form
    {
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Veterinaria.mdb");
        DataTable dt;
        string comandoSQL;
        public frmRptProductos()
        {
            InitializeComponent();
            comandoSQL = "SELECT P.idProducto AS Cod,"
                        + "M.marca AS Marca,"
                        + "P.descripcion AS [Nombre Producto],"
                        + "P.precio AS Precio,"
                        + "P.stock AS Stock "
                        + "FROM Producto P INNER JOIN Marcas M ON P.idMarca = M.idMarca";
        }

        private void frmRptProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsetVeterinaria.dtProductos' Puede moverla o quitarla según sea necesario.
            this.dtProductosTableAdapter.todosProductos(this.dsetVeterinaria.dtProductos);            
                      
            this.rptwProds.RefreshReport();
        }

        void cambiarReporte()
        {
            //**********************
            //ESTO NO LO TOQUEN POR AHORA QUE ESTOY TRATANDO DE RESOLVER
            //EL PROBLEMA DE PERSONALIZAR EL REPORTE...
            //
            //dt = new DataTable();
            //dt = oDato.consultarBD(comandoSQL);
            //ProductoBindingSource.DataSource = dt;
            //

        }
    }
}
