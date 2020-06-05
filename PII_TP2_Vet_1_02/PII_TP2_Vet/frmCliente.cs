using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_TP2_Vet
{
    public partial class frmCliente : Form
    {
        //AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\mayco.DESKTOP-B3EKAFO\Downloads\uni\basesDe Dato\Veterinaria.mdb");
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrador\Escritorio\TUP\Prog 2\PII_TP2_Vet\Veterinaria.mdb");
        const int tam = 100;
        Cliente[] ac = new Cliente[tam];
        int c;
        bool nuevo;
        public frmCliente()
        {
            InitializeComponent();
            for (int i = 0; i < tam; i++)
            {
                ac[i] = null;
            }
              nuevo = false;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            cargarLista("Cliente");
            cargarCombo(cboTipoDoc, "TipoDocumento");
            habilitar(false);
        }

        private void ultimoCodigo()
        {
            //RECUPERA EL IDMASCOTA MAS ALTO PARA SUGERIRLO COMO NUEVO CODIGO
            DataTable t = new DataTable();
            string conSQL = "SELECT TOP 1 idCliente from Cliente ORDER BY 1 DESC";
            t = oDato.consultarBD(conSQL);
            int ultCod = Convert.ToInt32(t.Rows[0][0]) + 1;
            txtIdCliente.Text = ultCod.ToString();
        }
        
        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Ingrese Codigo...!!");
                txtIdCliente.SelectAll();
                txtIdCliente.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Ingrese Apellido...!!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtApellido.SelectAll();
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingrese Nombre...!!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtNombre.SelectAll();
                txtNombre.Focus();
                return false;
            }      
            
            if (string.IsNullOrEmpty(txtNroDoc.Text))
            {
                MessageBox.Show("Ingrese Número de Documento...!!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtNroDoc.SelectAll();
                txtNroDoc.Focus();
                return false;
            }
            if (dtpFechaNac.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha no puede estar en el futuro...!!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtpFechaNac.Focus();
                return false;
            }

            return true;
        }
        private bool existe(int Pk)
        {
            for (int i = 0; i < c; i++)
            {
                if (ac[i].pIdCliente == Pk)
                    return true;
            }
            return false;
        }
        private void habilitar(bool x)
        {
            txtIdCliente.Enabled = x;
            txtApellido.Enabled = x;
            txtNombre.Enabled = x;
            txtDireccion.Enabled = x;
            txtTelFijo.Enabled = x;
            txtTelCel.Enabled = x;
            txtCorreo.Enabled = x;
            cboTipoDoc.Enabled = x;
            txtNroDoc.Enabled = x;
            rbtFemenino.Enabled = x;
            rbtMasculino.Enabled = x;
            dtpFechaNac.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnEliminar.Enabled = !x;
            btnSalir.Enabled = !x;
            lstCliente.Enabled = !x;
        }
        private void limpiar()
        {
            txtIdCliente.Clear();
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelFijo.Text = "";
            txtTelCel.Text = "";
            txtCorreo.Text = "";
            cboTipoDoc.SelectedIndex = -1;
            txtNroDoc.Text = "";
            rbtMasculino.Checked = true;
            rbtFemenino.Checked = false;
            dtpFechaNac.Value = DateTime.Today;
        }
        private void cargarLista(string nombreTabla)
        {
            c = 0;
            lstCliente.Items.Clear();
            oDato.leerTabla(nombreTabla);
            while (oDato.pLector.Read())
            {
                Cliente C = new Cliente();
                    if(!oDato.pLector.IsDBNull(0))
                        C.pIdCliente = oDato.pLector.GetInt32(0);
                    if (!oDato.pLector.IsDBNull(1))
                        C.pApellido = oDato.pLector.GetString(1);
                    if (!oDato.pLector.IsDBNull(2))
                        C.pNombre = oDato.pLector.GetString(2);
                    if (!oDato.pLector.IsDBNull(3))
                        C.pDireccion = oDato.pLector.GetString(3);
                    if (!oDato.pLector.IsDBNull(4))
                        C.pTelFijo = oDato.pLector.GetString(4);
                    if (!oDato.pLector.IsDBNull(5))
                        C.pTelCel = oDato.pLector.GetString(5);
                    if (!oDato.pLector.IsDBNull(6))
                        C.pCorreo = oDato.pLector.GetString(6);
                    if (!oDato.pLector.IsDBNull(7))
                        C.pTipoDoc = oDato.pLector.GetInt32(7);
                    if (!oDato.pLector.IsDBNull(8))
                        C.pNroDoc = oDato.pLector.GetString(8);
                    if (!oDato.pLector.IsDBNull(9))
                        C.pSexo = oDato.pLector.GetInt32(9);
                    if (!oDato.pLector.IsDBNull(10))
                        C.pFechaNac = oDato.pLector.GetDateTime(10);
                    if (!oDato.pLector.IsDBNull(11))
                        C.pEstado = oDato.pLector.GetBoolean(11);
                ac[c] = C;
                c++;
            }
            oDato.pLector.Close();
            oDato.desconectar();

            for (int i = 0; i < c; i++)
            {
                lstCliente.Items.Add(ac[i].ToString());
            }
            lstCliente.SelectedIndex = -1;
        }

        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable dt = new DataTable();
            dt = oDato.consultarTabla(nombreTabla);
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void actualizarCampos(int lugar)
        {
            txtIdCliente.Text = ac[lugar].pIdCliente.ToString();
            txtApellido.Text = ac[lugar].pApellido;
            txtNombre.Text = ac[lugar].pNombre;
            txtDireccion.Text = ac[lugar].pDireccion;
            txtTelFijo.Text = ac[lugar].pTelFijo;
            txtTelCel.Text = ac[lugar].pTelCel;
            txtCorreo.Text = ac[lugar].pCorreo;
            cboTipoDoc.SelectedValue = ac[lugar].pTipoDoc;
            txtNroDoc.Text = ac[lugar].pNroDoc;
            if (ac[lugar].pSexo == 1)
                rbtMasculino.Checked = true;
            else
                rbtFemenino.Checked = true;
            dtpFechaNac.Value = ac[lugar].pFechaNac;
            if (ac[lugar].pEstado)
                chkActivo.Checked = true;
            else
                chkActivo.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            habilitar(true);
            limpiar();
            rbtMasculino.Checked = true;
            cboTipoDoc.SelectedIndex = 0;
            ultimoCodigo();
            txtIdCliente.Focus();
        }

        private void lstCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCampos(lstCliente.SelectedIndex);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);
            nuevo = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                //string consultaSQL = "";
                Cliente C = new Cliente();
                C.pIdCliente = Convert.ToInt32(txtIdCliente.Text);
                C.pApellido = txtApellido.Text;
                C.pNombre = txtNombre.Text;
                C.pDireccion = txtDireccion.Text;
                C.pTelFijo = txtTelFijo.Text;
                C.pTelCel = txtTelCel.Text;
                C.pCorreo = txtCorreo.Text;
                C.pTipoDoc = Convert.ToInt32(cboTipoDoc.SelectedValue);
                C.pNroDoc = txtNroDoc.Text;
                if (rbtMasculino.Checked)
                    C.pSexo = 1;
                else
                    C.pSexo = 2;
                C.pFechaNac = dtpFechaNac.Value;
                C.pEstado = chkActivo.Checked;

                DialogResult opcion = MessageBox.Show("¿Desea grabar el Cliente?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    if (nuevo)
                    {
                        if (!existe(C.pIdCliente))
                        {
                            //consultaSQL = "insert into Cliente " +
                            //            " Values("
                            //            + C.pIdCliente + ",'"
                            //            + C.pNombreApellido + "','"
                            //            + C.pDireccion + "',"
                            //            + C.pTelFijo + ","
                            //            + C.pTelCel + ",'"
                            //            + C.pCorreo + "',"
                            //            + C.pNroDoc + ","
                            //            + C.pSexo + ",'"
                            //            + C.pFechaNac + "')";
                            //oDato.actualizarBd(consultaSQL);
                            //cargarLista("Cliente");
                            oDato.conectar();
                            oDato.pComando.CommandText = "INSERT INTO Cliente VALUES("
                                                        + "?,?,?,?,?,?,?,?,?,?,?,?)";
                            oDato.pComando.Parameters.Clear();
                            oDato.pComando.Parameters.AddWithValue("idClie", C.pIdCliente);
                            oDato.pComando.Parameters.AddWithValue("apell", C.pApellido);
                            oDato.pComando.Parameters.AddWithValue("nom", C.pNombre);
                            oDato.pComando.Parameters.AddWithValue("direc", C.pDireccion);
                            oDato.pComando.Parameters.AddWithValue("fijo", C.pTelFijo);
                            oDato.pComando.Parameters.AddWithValue("cel", C.pTelCel);
                            oDato.pComando.Parameters.AddWithValue("correo", C.pCorreo);
                            oDato.pComando.Parameters.AddWithValue("tipoDoc", C.pTipoDoc);
                            oDato.pComando.Parameters.AddWithValue("nroDoc", C.pNroDoc);
                            oDato.pComando.Parameters.AddWithValue("sexo", C.pSexo);
                            oDato.pComando.Parameters.AddWithValue("fNac", C.pFechaNac);
                            oDato.pComando.Parameters.AddWithValue("estado", C.pEstado);
                            oDato.pComando.ExecuteNonQuery();
                            oDato.desconectar();
                            nuevo = false;
                            limpiar();
                            cargarLista("Cliente");
                            habilitar(false);
                            lstCliente.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("El código que intenta cargar ya existe. Intente uno diferente", "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
                            txtIdCliente.SelectAll();
                            txtIdCliente.Focus();
                        }
                    }
                    else
                    {
                        //consultaSQL = "update Cliente set nombreApellido= '" + C.pNombreApellido + "',"
                        //                                + "direccion='" + C.pDireccion + "',"
                        //                                + "telefonoFijo=" + C.pTelFijo + ","
                        //                                + "telefonoCelular=" + C.pTelCel + ","
                        //                                + "correo='" + C.pCorreo + "',"
                        //                                + "numeroDocumento= " + C.pNroDoc + ","
                        //                                + "sexo=" + C.pSexo + ","
                        //                                + "fechaNacimiento=" + C.pFechaNac + ",";
                        ////+ "where codigo=" + C.pIdCliente;
                        //oDato.actualizarBd(consultaSQL);
                        //cargarLista("Cliente");
                        int pos = lstCliente.SelectedIndex;
                        oDato.conectar();
                        oDato.pComando.CommandText = "UPDATE Cliente SET apellido=?,nombre=?,direccion=?,"
                                                    + "telefonoFijo=?,telefonoCelular=?,correo=?,idTipoDocumento=?,"
                                                    + "documento=?,sexo=?,fechaNac=?,estado=? "
                                                    + "WHERE idCliente=?";
                        oDato.pComando.Parameters.Clear();
                        oDato.pComando.Parameters.AddWithValue("apell", C.pApellido);
                        oDato.pComando.Parameters.AddWithValue("nom", C.pNombre);
                        oDato.pComando.Parameters.AddWithValue("direc", C.pDireccion);
                        oDato.pComando.Parameters.AddWithValue("fijo", C.pTelFijo);
                        oDato.pComando.Parameters.AddWithValue("cel", C.pTelCel);
                        oDato.pComando.Parameters.AddWithValue("correo", C.pCorreo);
                        oDato.pComando.Parameters.AddWithValue("tipoDoc", C.pTipoDoc);
                        oDato.pComando.Parameters.AddWithValue("nroDoc", C.pNroDoc);
                        oDato.pComando.Parameters.AddWithValue("sexo", C.pSexo);
                        oDato.pComando.Parameters.AddWithValue("fNac", C.pFechaNac);
                        oDato.pComando.Parameters.AddWithValue("estado", C.pEstado);
                        oDato.pComando.Parameters.AddWithValue("idClie", C.pIdCliente);
                        oDato.pComando.ExecuteNonQuery();
                        oDato.desconectar();
                        limpiar();
                        cargarLista("Cliente");
                        habilitar(false);
                        lstCliente.SelectedIndex = pos;
                    }
                }
            }            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           if (lstCliente.SelectedIndex < 0)
           {
               MessageBox.Show("Debe seleccionar un elemento", "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
               lstCliente.Focus();
           }
           else
           {
               if (ac[lstCliente.SelectedIndex].pEstado)
               {
                   nuevo = false;
                   habilitar(true);
                   txtIdCliente.Enabled = false;
                   txtApellido.Focus();
               }
               else
               {
                   MessageBox.Show("Este Cliente fue marcado como Borrado."
                        + "\nNo puede editar su información", "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
               }
           }
        }        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstCliente.SelectedIndex >= 0)
            {
                if (ac[lstCliente.SelectedIndex].pEstado)
                {
                    DialogResult opcion = MessageBox.Show("¿Realmente desea borrar el Cliente?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        //REALIZAMOS UN "BORRADO LOGICO". SOLO MARCAMOS EL ESTADO
                        //DEL PRODUCTO COMO INACTIVO, SIN BORRARLO DE LA TABLA                        
                        string borrar = "UPDATE Cliente SET estado=false" +
                                        " WHERE idCliente=" +
                                        ac[lstCliente.SelectedIndex].pIdCliente;
                        oDato.actualizarBD(borrar);
                        limpiar();
                        cargarLista("Cliente");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lstCliente.Focus();
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.Equals('-'))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelCel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.Equals('-'))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.Equals('-'))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}
