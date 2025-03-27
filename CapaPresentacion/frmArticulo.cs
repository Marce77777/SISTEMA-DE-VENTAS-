using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
   
    public partial class frmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        //PARA ENVIAR DATOS DE MARCA AL ARTICULO
        private static frmArticulo _Instancia;
        public static frmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmArticulo();

            }
            return _Instancia;
        }
        //ESTO MODIFIQUE
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
        //ENVIAR VALORES RECIBIDOOS A LA CAJA DE TEXTO
        public void setMarca(string id_marca, string nombre_marca)
        {
            this.txtIdmarca.Text = id_marca;
            this.txtMarca.Text = nombre_marca;
        }
        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCodigo, "Ingrese el Codigo del Articulo");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Selecciona la Imagen  del Articulo");
            this.ttMensaje.SetToolTip(this.txtMarca, "Seleccione la Marca  del Articulo");
            this.ttMensaje.SetToolTip(this.cbIdmarca, "Seleccione la Marca del Articulo");

            this.txtIdmarca.Visible = false;
            this.txtMarca.ReadOnly = true;
            this.LlenarComboMarca();
        }
        //Mostrar Mensjae de Confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text =string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdmarca.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
           //this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;//FALTA CARPETA RESOURCES
            this.pxImagen.Image = ByteArrayToImage(global::CapaPresentacion.Properties.Resources.file);
          //  this.pxImagen.Image = global::CapaPresentacion.recursos.file;

            //this.pxImagen.Image = Properties.Resources.file;


        }

       /* private Image ByteArrayToImage(byte[] file)
        {
            throw new NotImplementedException();
        }*/

        //habilitar los controles del formualario
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscar_marca.Enabled = valor;
            this.cbIdmarca.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdmarca.ReadOnly = !valor;
         //   this.txtxIdarticulo.ReadOnly = !valor;REVIAR NO ENGO ESE CAMPO EN EL FORMULARIO
        }
        //habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }

            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }


        //metodo ocultar columnas
         private void OcultarColumnas(DataGridView dataListado)
          {
              this.dataListado.Columns[0].Visible = false;
             this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;

        }


        private void OcultarColumnas()
        {
            if (this.dataListado.Columns.Count > 0)
                this.dataListado.Columns[0].Visible = false;

            if (this.dataListado.Columns.Count > 6)
                this.dataListado.Columns[6].Visible = false;//REVISAR
        }
        //metodo mostrar todos los registros de todas las categorias
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }
        private void LlenarComboMarca()
        {
            cbIdmarca.DataSource = NMarca.Mostrar();
            cbIdmarca.ValueMember = "id_marca";
            cbIdmarca.DisplayMember = "nombre_marca";

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) 
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode=PictureBoxSizeMode.StretchImage;
            //this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;//NO HAY CARPETA RESOURCES
            this.pxImagen.Image = ByteArrayToImage(global::CapaPresentacion.Properties.Resources.file);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty || this.txtIdmarca.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Fallta ingresar algunos datos, seran remarcado");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");
                    errorIcono.SetError(txtMarca, "Ingrese un Valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();
                    if (this.IsNuevo)
                    {
                        /*rpta = NArticulo.Insertar(this.txtCodigo.Text.Trim().ToUpper(),this.txtNombre.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim(),imagen, Convert.ToInt32(this.txtIdmarca.Text), Convert.ToInt32(cbIdmarca.SelectedValue));*/
                        rpta = NArticulo.Insertar(this.txtCodigo.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),
                              this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdmarca.Text));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text),
                             this.txtCodigo.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdmarca.Text), Convert.ToInt32(cbIdmarca.SelectedValue));
                    }
                    //si recibe un "Ok"
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizó de forma correcta el registro");
                        }
                    }
                    //si no recibe un "OK"
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdmarca.Text = "";
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdarticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }

            else
            {
                this.MensajeError("Debe de selecionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkElimimnar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkElimimnar.Value = !Convert.ToBoolean(chkElimimnar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_articulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            byte[] imagenBuffer = (byte[]) this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdmarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_marca"].Value);
            this.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Marca"].Value); //revisar Marca

            this.cbIdmarca.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_marca"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desesa eliminar los registros",
                                         "SISTEMA DE VENTAS", MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se elimino correctamente el regitro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_marca_Click(object sender, EventArgs e)
        {
            frmVistaMarca_Articulo form = new frmVistaMarca_Articulo();
            form.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
