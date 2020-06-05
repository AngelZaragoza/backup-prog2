using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PII_TP2_Vet
{
    public partial class frmPrincipal : Form
    {
        frmProducto abmProd = null;
        frmMascotas abmMascota = null;        
        frmRptProductos rptProd = null;
        frmRptMascotas rptMasc = null;
        frmRptClientes rptClien = null;
        frmCliente abmClie = null;        
        public frmPrincipal()
        {            
            InitializeComponent();
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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Desea Salir del Programa?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)                                            
                Close();
        }

        private void aBMMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abmMascota == null)
            {
                abmMascota = new frmMascotas();
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

        private void aBMProductosToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Desea Salir del Programa?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
                Close();
        }

        private void listadoMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rptMasc == null)
            {
                rptMasc = new frmRptMascotas();
                rptMasc.MdiParent = this;
                rptMasc.FormClosed += new FormClosedEventHandler(rptMasc_FormClosed);
                rptMasc.Show();
            }
            else
            {
                rptMasc.Activate();
            }
        }

        void rptMasc_FormClosed(object sender, FormClosedEventArgs e)
        {
            rptMasc = null;
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abmClie == null)
            {
                abmClie = new frmCliente();
                abmClie.MdiParent = this;
                abmClie.FormClosed += new FormClosedEventHandler(abmClie_FormClosed);
                abmClie.Show();
            }
            else
            {
                abmClie.Activate();
            }
        }

        void abmClie_FormClosed(object sender, FormClosedEventArgs e)
        {
            abmClie = null;
        }

        private void listadoCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rptClien == null)
            {
                rptClien = new frmRptClientes();
                rptClien.MdiParent = this;
                rptClien.FormClosed += new FormClosedEventHandler(rptClien_FormClosed);
                rptClien.Show();
            }
            else
            {
                rptClien.Activate();
            }
        }

        void rptClien_FormClosed(object sender, FormClosedEventArgs e)
        {
            rptClien = null;
        }
    }
}
