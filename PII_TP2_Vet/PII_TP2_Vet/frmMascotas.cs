using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_TP2_Vet
{ 
    public partial class frmMascotas : Form
    {
        //AccesoDato adm = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Usuario\Desktop\ARCH_PRUEBA\VETERINARIA_TPPII\Veterinaria.mdb");
        AccesoDato adm = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrador\Escritorio\TUP\Prog 2\PII_TP2_Vet\Veterinaria.mdb");
        const int tam = 100;
        Mascota[] masc = new Mascota[tam];
        int c;
        bool nuevo;

        public frmMascotas()
        {
            InitializeComponent();
       
            for (int i = 0; i < tam; i++)
            {
                masc[i] = null;
            }
            nuevo = false;
        }

        private void Mascotas_Load(object sender, EventArgs e)
        {
            cargarCombo(cboTipoMascota,"TipoMascota");
            cargarCombo(cboRaza, "Raza");
            cargarCombo(cboDuenio, "Cliente");
            cargarLista("Mascota");
            habilitar(false);
        }


        private void ultimoCodigo()
        {
            //RECUPERA EL IDMASCOTA MAS ALTO PARA SUGERIRLO COMO NUEVO CODIGO
            DataTable t = new DataTable();
            string conSQL = "SELECT TOP 1 idMascota from Mascota ORDER BY 1 DESC";
            t = adm.consultarBD(conSQL);
            int ultCod = Convert.ToInt32(t.Rows[0][0]) + 1;
            txtCodigo.Text = ultCod.ToString();            
        }

        private bool existe(int Pk)
        {
            //CONTROLA COD REPETIDOS
            for (int i = 0; i < c; i++)
            {
                if (masc[i].pIdMascota == Pk)
                    return true;
            }
            return false;
        }
        
        //RECUPERACION Y CARGA DE DATOS
        public void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable dtm = new DataTable();
            dtm = adm.consultarTabla(nombreTabla);            
            combo.DataSource = dtm;
            combo.ValueMember = dtm.Columns[0].ColumnName;
            if (nombreTabla == "Cliente")
            {   
                combo.DisplayMember = dtm.Columns[2].ColumnName;                
            }
            else
                combo.DisplayMember = dtm.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }
        
        private void cargarLista(string nombreTabla)
        {
            c = 0;
            lstMascotas.Items.Clear();
            adm.leerTabla(nombreTabla);
            while (adm.pLector.Read())
            {
                Mascota m = new Mascota();
                if (!adm.pLector.IsDBNull(0))
                    m.pIdMascota = adm.pLector.GetInt32(0);
                if (!adm.pLector.IsDBNull(1))
                    m.pIdCliente= adm.pLector.GetInt32(1);
                if (!adm.pLector.IsDBNull(2))
                    m.pNombre = adm.pLector.GetString(2);
                if (!adm.pLector.IsDBNull(3))
                    m.pTipoMascota = adm.pLector.GetInt32(3);
                if (!adm.pLector.IsDBNull(4))
                    m.pSexo = adm.pLector.GetBoolean(4);
                if (!adm.pLector.IsDBNull(5))
                    m.pRaza = adm.pLector.GetInt32(5);
                if (!adm.pLector.IsDBNull(6))
                    m.pFechaNac = adm.pLector.GetDateTime(6);
                if (!adm.pLector.IsDBNull(7))
                    m.pPeso = adm.pLector.GetInt32(7);
                if (!adm.pLector.IsDBNull(8))
                    m.pObservacion = adm.pLector.GetString(8);
                if (!adm.pLector.IsDBNull(9))
                    m.pEstado = adm.pLector.GetBoolean(9);
               
                masc[c] = m;
                c++;
            }
            adm.pLector.Close();
            adm.desconectar();

            for (int i = 0; i < c; i++)
            {
                lstMascotas.Items.Add(masc[i].ToString());
            }            
            lstMascotas.SelectedIndex = -1;
        }

        private void actualizarCampos(int posicion)
        {
            txtCodigo.Text = masc[posicion].pIdMascota.ToString();
            txtNombre.Text = masc[posicion].pNombre;
            cboTipoMascota.SelectedValue = masc[posicion].pTipoMascota;
            cboRaza.SelectedValue = masc[posicion].pRaza;
            dtpFechaNac.Value = masc[posicion].pFechaNac;
            if (masc[posicion].pSexo)
                rbtMacho.Checked = true;
            else
                rbtHembra.Checked = true;
            txtObservacion.Text = masc[posicion].pObservacion;            
            cboDuenio.SelectedValue = masc[posicion].pIdCliente;
            txtPeso.Text = masc[posicion].pPeso.ToString();
            if (masc[posicion].pEstado)
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        //MANEJO DE CONTROLES
        private void habilitar(bool opcion)
        {
            txtCodigo.Enabled = opcion;
            txtNombre.Enabled = opcion;
            cboTipoMascota.Enabled = opcion;
            cboRaza.Enabled = opcion;
            dtpFechaNac.Enabled = opcion;
            rbtHembra.Enabled = opcion;
            rbtMacho.Enabled = opcion;
            txtObservacion.Enabled = opcion;
            cboDuenio.Enabled = opcion;
            txtPeso.Enabled = opcion;

            btnCancelar.Enabled = opcion;
            btnGrabar.Enabled = opcion;

            btnNuevo.Enabled = !opcion;
            btnEditar.Enabled = !opcion;
            btnBorrar.Enabled = !opcion;
            btnSalir.Enabled = !opcion;
            lstMascotas.Enabled = !opcion;
        }
        
        private void limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Text = "";
            cboTipoMascota.SelectedIndex = -1;
            cboRaza.SelectedIndex = -1;
            dtpFechaNac.Value = DateTime.Today;
            rbtMacho.Checked = true;
            rbtHembra.Checked = false;
            txtObservacion.Clear();
            cboDuenio.SelectedIndex = -1;
            txtPeso.Clear();
            chkEstado.Checked = true;
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //lstMascotas.SelectedIndex = -1;
            nuevo = true;
            habilitar(true);
            limpiar();
            ultimoCodigo();
            txtCodigo.Focus();
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            BorrarMensajeError();
            limpiar();
            habilitar(false);
            nuevo = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                //string consultaSQL = "";
                Mascota m = new Mascota();
                m.pIdMascota = Convert.ToInt32(txtCodigo.Text);
                m.pNombre = txtNombre.Text;
                m.pTipoMascota = Convert.ToInt32(cboTipoMascota.SelectedValue);
                m.pRaza = Convert.ToInt32(cboRaza.SelectedValue);
                m.pFechaNac = dtpFechaNac.Value;
                if (rbtMacho.Checked)
                    m.pSexo = true;
                else
                    m.pSexo = false;
                m.pObservacion = txtObservacion.Text;
                m.pPeso = Convert.ToInt32(txtPeso.Text);
                if (cboDuenio.SelectedIndex >= 0)
                    m.pIdCliente = Convert.ToInt32(cboDuenio.SelectedValue);
                if (chkEstado.Checked)
                    m.pEstado = true;
                else
                    m.pEstado = false;

                DialogResult opcion = MessageBox.Show("¿Desea grabar la Mascota?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    if (nuevo)
                    {
                        if (!existe(m.pIdMascota))
                        {
                            //consultaSQL = "INSERT INTO Mascota (idMascota,idCliente,nombre,idTipoMascota,sexo,"
                            //                         + "idRaza,fechaNacimiento,peso,observacion,estado) VALUES ("
                            //                         + m.pIdMascota + ","
                            //                         + m.pIdCliente + ",'"
                            //                         + m.pNombre + "',"
                            //                         + m.pTipoMascota + ","
                            //                         + m.pSexo + ","
                            //                         + m.pRaza + ",#"
                            //                         + m.pFechaNac + "#,"
                            //                         + m.pPeso + ",'"                                                  
                            //                         + m.pObservacion + "',"
                            //                         + m.pEstado +")";
                            //adm.actualizarBD(consultaSQL);
                            //cargarLista("Mascota");

                            adm.conectar();
                            adm.pComando.CommandText = "INSERT INTO Mascota (idMascota,idCliente,nombre,idTipoMascota,"
                                                     + "sexo,idRaza,fechaNacimiento,peso,observacion,estado) "
                                                     + "VALUES (?,?,?,?,?,?,?,?,?,?)";
                            adm.pComando.Parameters.Clear();
                            adm.pComando.Parameters.AddWithValue("idMasc", m.pIdMascota);
                            adm.pComando.Parameters.AddWithValue("idClien", m.pIdCliente);
                            adm.pComando.Parameters.AddWithValue("nombre", m.pNombre);
                            adm.pComando.Parameters.AddWithValue("tipoMasc", m.pTipoMascota);
                            adm.pComando.Parameters.AddWithValue("sexo", m.pSexo);
                            adm.pComando.Parameters.AddWithValue("raza", m.pRaza);
                            adm.pComando.Parameters.AddWithValue("fecNac", m.pFechaNac);
                            adm.pComando.Parameters.AddWithValue("peso", m.pPeso);
                            adm.pComando.Parameters.AddWithValue("obs", m.pObservacion);
                            adm.pComando.Parameters.AddWithValue("estado", m.pEstado);
                            adm.pComando.ExecuteNonQuery();
                            adm.desconectar();
                            nuevo = false;
                            limpiar();
                            cargarLista("Mascota");
                            habilitar(false);
                            lstMascotas.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("El código que intenta cargar ya existe. Intente uno diferente", "Atención",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                            txtCodigo.SelectAll();
                        }
                    }
                    else
                    {
                        //consultaSQL = "UPDATE Mascota SET Nombre='" + m.pNombre + "',"
                        //                              + "idCliente=" + m.pIdCliente + ","
                        //                              + "idTipoMascota=" + m.pTipoMascota + ","
                        //                              + "sexo=" + m.pSexo + ","
                        //                              + "idRaza=" + m.pRaza + ","
                        //                              + "fechaNacimiento=#" + m.pFechaNac + "#,"                                                  
                        //                              + "peso=" + m.pPeso + ","
                        //                              + "Observacion='" + m.pObservacion + "', "
                        //                              + "estado="+ m.pEstado
                        //                              + " WHERE idMascota=" + m.pIdMascota;
                        //adm.actualizarBD(consultaSQL); 
                        //cargarLista("Mascota");                 

                        adm.conectar();
                        adm.pComando.CommandText = "UPDATE Mascota SET idCliente=?,nombre=?,idTipoMascota=?,"
                                                            + "sexo=?,idRaza=?,fechaNacimiento=?,peso=?,"
                                                            + "Observacion=?,estado=? "
                                                            + "WHERE idMascota=?";
                        adm.pComando.Parameters.Clear();
                        adm.pComando.Parameters.AddWithValue("idClien", m.pIdCliente);
                        adm.pComando.Parameters.AddWithValue("nombre", m.pNombre);
                        adm.pComando.Parameters.AddWithValue("tipoMasc", m.pTipoMascota);
                        adm.pComando.Parameters.AddWithValue("sexo", m.pSexo);
                        adm.pComando.Parameters.AddWithValue("raza", m.pRaza);
                        adm.pComando.Parameters.AddWithValue("fecNac", m.pFechaNac);
                        adm.pComando.Parameters.AddWithValue("peso", m.pPeso);
                        adm.pComando.Parameters.AddWithValue("obs", m.pObservacion);
                        adm.pComando.Parameters.AddWithValue("estado", m.pEstado);
                        adm.pComando.Parameters.AddWithValue("idMasc", m.pIdMascota);
                        adm.pComando.ExecuteNonQuery();
                        adm.desconectar();
                        limpiar();
                        cargarLista("Mascota");
                        habilitar(false);
                        lstMascotas.SelectedIndex = -1;
                    }
                }
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {            
            if (lstMascotas.SelectedIndex >= 0)
            {
                if (masc[lstMascotas.SelectedIndex].pEstado)
                {
                    habilitar(true);
                    txtCodigo.Enabled = false;
                    txtCodigo.Focus();
                }
                else
                {
                    MessageBox.Show("Esta Mascota fue marcada como Borrada."
                        + "\nNo puede editar su información", "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    lstMascotas.Focus();                   
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una mascota", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstMascotas.SelectedIndex >= 0)
            {
               if (masc[lstMascotas.SelectedIndex].pEstado)
                {
                        DialogResult opcion = MessageBox.Show ("¿Realmente desea borrar la mascota ?","Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (opcion == DialogResult.Yes)
                    {
                       string borrar = "UPDATE Mascota set estado = false " +
                             "WHERE idMascota=" + masc[lstMascotas.SelectedIndex].pIdMascota;
                       adm.actualizarBD (borrar);
                       limpiar();
                       cargarLista("Mascota");
                   }
                }
            }
            else
            {
                MessageBox.Show("Debe selecccionar un elemento","Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                lstMascotas.Focus();
            }
            /*if (MessageBox.Show("Está seguro de eliminar este producto?",
                               "ELIMINANDO",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button2)
                               == DialogResult.Yes)
            {
                string consultaSQL = "DELETE FROM Mascota WHERE idMascota=" +
                                masc[lstMascotas.SelectedIndex].pIdMascota;
                adm.ActualizarBD(consultaSQL);
                cargarLista("Mascota");
            }*/
        }


        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCampos(lstMascotas.SelectedIndex);
        }

        //VALIDACIONES VARIAS
        private bool Validar()
        {
            BorrarMensajeError();
            if (txtCodigo.Text == "")
            {
                errValidacion.SetError(txtCodigo, " Debe ingresar el codigo de la mascota..");
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Text == "")
            {
                errValidacion.SetError(txtNombre, "Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }
            if (cboTipoMascota.SelectedIndex == -1)
            {
                errValidacion.SetError(cboTipoMascota, "Seleccione el Tipo de Mascota");
                cboTipoMascota.Focus();
                return false;
            }
            if (cboRaza.SelectedIndex == -1)
            {
                errValidacion.SetError(cboRaza, "Seleccione la Raza de la Mascota");
                cboRaza.Focus();
                return false;
            }
            if (dtpFechaNac.Value > DateTime.Now)
            {
                errValidacion.SetError(dtpFechaNac, "La fecha no puede estar en el futuro");
                dtpFechaNac.Focus();
                return false;
            }
            if (txtPeso.Text == "")
            {
                errValidacion.SetError(txtPeso, "Ingrese un valor númerico");
                txtPeso.Focus();
                return false;
            }
            return true;
        }

        private void BorrarMensajeError()
        {
            errValidacion.SetError(txtCodigo, "");
            errValidacion.SetError(txtNombre, "");
            errValidacion.SetError(cboRaza, "");
            errValidacion.SetError(cboTipoMascota, "");
            errValidacion.SetError(dtpFechaNac, "");
            errValidacion.SetError(txtPeso, "");
        }
        
        
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}
