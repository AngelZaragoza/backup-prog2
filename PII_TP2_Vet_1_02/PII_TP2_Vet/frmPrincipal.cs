using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

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
        AccesoDato oDato = null;
        string cadenaBD = "";

        
        public frmPrincipal()
        {            
            InitializeComponent();            
        }

        //Inicialización de la cadena de conexión que se pasará como parámetro a cada formulario
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                //Cadena de conexión... modificarla según en qué carpeta esté el proyecto
                cadenaBD = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\GIT\backup-prog2\PII_TP2_Vet_1_02\Veterinaria.mdb";
                
                //Esta cadena de abajo podría funcionar en arquitecturas x64, pero por el momento no logré hacerlo funcionar
                //cadenaBD = @"Provider=Microsoft.ACE.OLEDB.14.0;Data Source=D:\GIT\backup-prog2\PII_TP2_Vet_1_02\Veterinaria.mdb";
                
                //Creamos el objeto que manejará la Base de Datos (sólo usado en uno de los form)
                oDato = new AccesoDato(cadenaBD);
            }
            catch
            {
                MessageBox.Show("No se puede leer BD");
                Close();
            }
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
               

        private void aBMMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abmMascota == null)
            {
                //A este form le mandamos como parámetro un objeto de AccesoDato en vez de sólo la cadena de conexión
                abmMascota = new frmMascotas(oDato);
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
                //Enviamos la cadena de conexión como parámetro (string)
                abmProd = new frmProducto(cadenaBD);
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
                //Enviamos la cadena de conexión como parámetro (string)
                abmClie = new frmCliente(cadenaBD);
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


        //Opción Salir: Llama un cuadro de mensaje, si el usuario elige Sí, cierra el programa
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Desea Salir del Programa?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
                Close();
        }


    }
}
