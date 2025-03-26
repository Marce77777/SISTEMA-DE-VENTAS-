using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmUsuario : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmUsuario()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre,"Ingrese Nombre de Usuario");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese Apellidos del Usuario");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese  Usuario para ingresar al sistema");
            this.ttMensaje.SetToolTip(this.txtPassword, "Ingrese Password del Usuario");
            this.ttMensaje.SetToolTip(this.cbAcceso, "Seleccio");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pxImagen_Click(object sender, EventArgs e)
        {
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
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtIdusuario.Text = string.Empty;
        }
        //habilitar los controles del formualario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.cbAcceso.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
            this.txtIdusuario.ReadOnly = !valor;
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
            this.dataListado.DataSource = NUsuario.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo BuscarNombre
        private void BuscarApellido()
        {
            dataListado.DataSource = NUsuario.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // if(txtBuscar.Value)
            this.BuscarApellido();
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
                            Rpta = NUsuario.Eliminar(Convert.ToInt32(Codigo));
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkElimimnar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkElimimnar.Value = !Convert.ToBoolean(chkElimimnar.Value);
            }
        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdusuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_usuario"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

            this.tabControl1.SelectedIndex = 1;
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

                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtDireccion.Text == string.Empty
                    || this.txtUsuario.Text ==string.Empty || this.txtPassword.Text == string.Empty)
                {
                    MensajeError("Fallta ingresar algunos datos, seran remarcado");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellido, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");
                    errorIcono.SetError(txtPassword, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NUsuario.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(),
                              this.txtDireccion.Text.Trim(),this.txtTelefono.Text, this.cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text );
                    }
                    else
                    {
                        rpta = NUsuario.Editar(Convert.ToInt32(this.txtIdusuario.Text),
                             this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(), 
                               this.txtDireccion.Text.Trim(),this.txtTelefono.Text, this.cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text);
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
                    this.txtIdusuario.Text = "";
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtIdusuario.Text = string.Empty;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdusuario.Text.Equals(""))
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarApellido();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdusuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_usuario"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
