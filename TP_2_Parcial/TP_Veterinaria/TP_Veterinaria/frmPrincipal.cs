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
    public partial class frmPrincipal : Form
    {
        frmProducto abmProd = null;
        frmMascota abmMascota = null;
        frmRptProductos rptProd = null;
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Veterinaria.mdb");
        public frmPrincipal()
        {            
            InitializeComponent();
        }

        public AccesoDato pODato
        {
            get { return oDato; }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abmProd == null)
            {
                abmProd = new frmProducto();
                abmProd.MdiParent = this;
                abmProd.FormClosed += new FormClosedEventHandler(abmProd_FormClosed);
                abmProd.Show();
            }
            else
            {
                abmProd.Activate();
            }
        }

        void abmProd_FormClosed(object sender, FormClosedEventArgs e)
        {
            abmProd = null;
        }

        private void mascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abmMascota == null)
            {
                abmMascota = new frmMascota();
                abmMascota.MdiParent = this;
                abmMascota.FormClosed += new FormClosedEventHandler(abmMascota_FormClosed);
                abmMascota.Show();
            }
            else
            {
                abmMascota.Activate();
            }
        }

        void abmMascota_FormClosed(object sender, FormClosedEventArgs e)
        {
            abmMascota = null;
        }

        private void listadoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rptProd == null)
            {
                rptProd = new frmRptProductos();
                rptProd.MdiParent = this;
                rptProd.FormClosed += new FormClosedEventHandler(rptProd_FormClosed);
                rptProd.Show();
            }
            else
            {
                rptProd.Activate();
            }
        }

        void rptProd_FormClosed(object sender, FormClosedEventArgs e)
        {
            rptProd = null;
        }
        









        //private void cargarLista(ListBox lista, string nombreTabla)
        //{
        //    int c = 0;

        //    oDato.leerTabla(nombreTabla);
        //    while(oDato.pLector.Read())
        //    {
        //        switch(nombreTabla)
        //        {
        //            case "Producto":

        //        }
        //    }
        //}
    }
}
