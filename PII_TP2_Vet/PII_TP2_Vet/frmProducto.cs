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
    public partial class frmProducto : Form
    {
        AccesoDato oDato = new AccesoDato(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrador\Escritorio\TUP\Prog 2\PII_TP2_Vet\Veterinaria.mdb");
        const int tam = 100;
        int cont;
        bool esNuevo;
        
        Producto[] aProd = new Producto[tam];

        public frmProducto()
        {            
            InitializeComponent();
            cont = 0;
            for (int i = 0; i < tam; i++)
            {
                aProd[i] = null;
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarLista(lstProductos, "Productos");
            cargarCombo(cboMarca, "Marcas");            
            habilitar(false);
        }
                

        #region Recuperacion de Datos
        private void cargarLista(ListBox lista, string nombreTabla)
        {
            lstProductos.Items.Clear();
            cont = 0;            
            oDato.leerTabla("Producto");
            //SE LEE EL OBJETO DATAREADER PARA CARGAR EN EL ARREGLO
            while (oDato.pLector.Read())
            {
                aProd[cont] = new Producto();
                if (!oDato.pLector.IsDBNull(0))
                    aProd[cont].pIdProducto = oDato.pLector.GetInt32(0);
                if (!oDato.pLector.IsDBNull(1))
                    aProd[cont].pIdMarca = oDato.pLector.GetInt32(1);
                if (!oDato.pLector.IsDBNull(2))
                    aProd[cont].pNomProducto = oDato.pLector.GetString(2);
                if (!oDato.pLector.IsDBNull(3))
                    aProd[cont].pPrecio_unitario = oDato.pLector.GetDouble(3);
                if (!oDato.pLector.IsDBNull(4))
                    aProd[cont].pStock = oDato.pLector.GetInt32(4);
                if (!oDato.pLector.IsDBNull(5))
                    aProd[cont].pActivo = oDato.pLector.GetBoolean(5);                
                cont++;
            }
            //MUY IMPORTANTE!! CERRAR LA CONEXION QUE EL DATA READER MANTUVO ABIERTA
            oDato.pLector.Close();
            oDato.desconectar();

            //CARGAMOS LISTA CON LOS OBJETOS DEL ARREGLO
            for (int i = 0; i < cont; i++)
            {
                lstProductos.Items.Add(aProd[i].ToString());
            }
        }

        //CARGA LOS DATOS DEL COMBO ESPECIFICADO
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

        //RECUPERA EL IDPRODUCTO MAS ALTO PARA SUGERIRLO COMO NUEVO CODIGO
        private void ultimoCodigo()
        {
            DataTable t = new DataTable();
            string conSQL = "SELECT TOP 1 idProducto from Producto ORDER BY 1 DESC";
            t = oDato.consultarBD(conSQL);
            int ultCod = Convert.ToInt32(t.Rows[0][0]) + 1;
            lblSugerido.Text += ultCod.ToString();
            lblSugerido.Visible = true;
        }
        #endregion

        #region Manejo de controles
        private void habilitar(bool h)
        {
            txtCod.Enabled = h;
            txtProducto.Enabled = h;
            cboMarca.Enabled = h;
            txtPrecio.Enabled = h;
            txtStock.Enabled = h;
            btnGrabar.Enabled = h;
            btnCancelar.Enabled = h;            

            lstProductos.Enabled = !h;
            btnNuevo.Enabled = !h;
            btnEditar.Enabled = !h;
            btnBorrar.Enabled = !h;
            btnSalir.Enabled = !h;
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCampos(lstProductos.SelectedIndex);
        }

        private void actualizarCampos(int pos)
        {
            txtCod.Text = aProd[pos].pIdProducto.ToString();
            txtProducto.Text = aProd[pos].pNomProducto;
            cboMarca.SelectedValue = aProd[pos].pIdMarca;
            txtPrecio.Text = aProd[pos].pPrecio_unitario.ToString();
            txtStock.Text = aProd[pos].pStock.ToString();
            chkActivo.Checked = aProd[pos].pActivo;
            btnEditar.Enabled = aProd[pos].pActivo;
            btnBorrar.Enabled = aProd[pos].pActivo;            
        }

        private void limpiarCampos()
        {            
            txtCod.Text = "";
            txtProducto.Text = "";
            cboMarca.SelectedIndex = -1;
            txtPrecio.Text = "";
            txtStock.Text = "";
            lblSugerido.Text = "Sugerido: ";
            lblSugerido.Visible = false;
        }
        #endregion

        #region Validación de datos
        private bool validar()
        {
            try
            {
                Int32.Parse(txtCod.Text);                
            }
            catch
            {                
                MessageBox.Show("El código debe ser numérico", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);                
                txtCod.SelectAll();
                txtCod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                MessageBox.Show("Debe especificar Nombre del Producto", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtProducto.SelectAll();
                txtProducto.Focus();
                return false;
            }
            if (cboMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir la Marca", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cboMarca.Focus();
                return false;
            }
            try
            {
                double.Parse(txtPrecio.Text);
            }
            catch            
            {
                MessageBox.Show("El precio no es válido. Ingrese números", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPrecio.SelectAll();
                txtPrecio.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtStock.Text);
            }
            catch
            {
                MessageBox.Show("El valor debe ser numérico", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtStock.SelectAll();
                txtStock.Focus();
                return false;
            }
            return true;
        }

        private bool existe(int pk)
        {
            //PARA CHEQUEAR CODIGOS REPETIDOS
            for (int i = 0; i < cont; i++)
            {
                if (aProd[i].pIdProducto == pk)
                {
                    MessageBox.Show("El código que intenta cargar ya existe. Intente uno diferente","Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    txtCod.SelectAll();
                    return true;
                }
            }
            return false;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar.Equals(',') || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        } 
        
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lstProductos.SelectedIndex = -1;
            esNuevo = true;
            limpiarCampos();
            habilitar(true);
            ultimoCodigo();
            txtStock.Text = "0";
            chkActivo.Checked = true;
            txtCod.Focus();
            
        }
                
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstProductos.SelectedIndex >= 0)
            {
                if (aProd[lstProductos.SelectedIndex].pActivo)
                {
                    habilitar(true);
                    txtCod.Enabled = false;
                    txtProducto.Focus();
                }
                else
                {
                    MessageBox.Show("Este Producto fue marcado como borrado."
                        + "\nNo puede editar su información", "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    lstProductos.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lstProductos.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            limpiarCampos();
            habilitar(false);
            esNuevo = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {                
                //string comandoSQL = "";
                Producto p = new Producto();
                p.pIdProducto = Convert.ToInt32(txtCod.Text);
                p.pIdMarca = Convert.ToInt32(cboMarca.SelectedValue);
                p.pNomProducto = txtProducto.Text;
                p.pPrecio_unitario = Convert.ToDouble(txtPrecio.Text);
                p.pStock = Convert.ToInt32(txtStock.Text);
                p.pActivo = chkActivo.Checked;
                DialogResult opcion = MessageBox.Show("¿Desea grabar el Producto?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    if (esNuevo)
                    {
                        if (!existe(Convert.ToInt32(txtCod.Text)))
                        {
                            //INSERT DEL NUEVO PRODUCTO                            

                            //comandoSQL = "INSERT INTO Producto VALUES("
                            //            + p.pIdProducto + ","
                            //            + p.pIdMarca + ",'"
                            //            + p.pNomProducto + "',"
                            //            + Convert.ToString(p.pPrecio_unitario) + ","
                            //            + p.pStock + ","
                            //            + p.pActivo + ")";

                            //oDato.actualizarBD(comandoSQL);
                            oDato.conectar();
                            oDato.pComando.CommandText = "INSERT INTO Producto VALUES(?,?,?,?,?,?)";
                            oDato.pComando.Parameters.Clear();
                            oDato.pComando.Parameters.AddWithValue("idProd", p.pIdProducto);
                            oDato.pComando.Parameters.AddWithValue("idMarca", p.pIdMarca);
                            oDato.pComando.Parameters.AddWithValue("descripcion", p.pNomProducto);
                            oDato.pComando.Parameters.AddWithValue("precio", p.pPrecio_unitario);
                            oDato.pComando.Parameters.AddWithValue("stock", p.pStock);
                            oDato.pComando.Parameters.AddWithValue("activo", p.pActivo);
                            oDato.pComando.ExecuteNonQuery();
                            oDato.desconectar();
                            esNuevo = false;
                            limpiarCampos();
                            cargarLista(lstProductos, "Producto");
                            habilitar(false);
                            lstProductos.SelectedIndex = (cont - 1);
                        }
                        else
                        {
                            txtCod.SelectAll();
                            txtCod.Focus();
                        }
                    }
                    else
                    {
                        //UPDATE DEL PRODUCTO SELECCIONADO
                        //comandoSQL = "UPDATE Producto SET idMarca=" + p.pIdMarca + ","
                        //                            + "descripcion='" + p.pNomProducto + "',"
                        //                            + "precio=" + p.pPrecio_unitario + ","
                        //                            + "stock=" + p.pStock + " "
                        //                            + "WHERE idProducto=" + p.pIdProducto;
                        //oDato.actualizarBD(comandoSQL);
                        int pos = lstProductos.SelectedIndex;
                        oDato.conectar();
                        oDato.pComando.CommandText = "UPDATE Producto SET idMarca=?,descripcion=?,precio=?,stock=? "
                                                    + "WHERE idProducto=?";
                        oDato.pComando.Parameters.Clear();
                        oDato.pComando.Parameters.AddWithValue("idMarca", p.pIdMarca);
                        oDato.pComando.Parameters.AddWithValue("descripcion", p.pNomProducto);
                        oDato.pComando.Parameters.AddWithValue("precio", p.pPrecio_unitario);
                        oDato.pComando.Parameters.AddWithValue("stock", p.pStock);
                        oDato.pComando.Parameters.AddWithValue("idProd", p.pIdProducto);                        
                        oDato.pComando.ExecuteNonQuery();
                        oDato.desconectar();
                        limpiarCampos();
                        cargarLista(lstProductos, "Producto");
                        habilitar(false);
                        lstProductos.SelectedIndex = pos;
                    }                    
                    
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstProductos.SelectedIndex >= 0)
            {
                if (aProd[lstProductos.SelectedIndex].pActivo)
                {
                    DialogResult opcion = MessageBox.Show("¿Realmente desea borrar el Producto?", "Confirme",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        //REALIZAMOS UN "BORRADO LOGICO". SOLO MARCAMOS EL ESTADO
                        //DEL PRODUCTO COMO INACTIVO, SIN BORRARLO DE LA TABLA                        
                        string borrar = "UPDATE Producto SET estado=false" +
                                        " WHERE idProducto=" + 
                                        aProd[lstProductos.SelectedIndex].pIdProducto;
                        oDato.actualizarBD(borrar);
                        limpiarCampos();
                        cargarLista(lstProductos, "Producto");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lstProductos.Focus();
            }
        }

               
    }
}