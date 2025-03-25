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
    public partial class FrmMarca : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;


        public FrmMarca()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre_marca, "Ingrese el Nombre de la Categoria");

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
            this.txtNombre_marca.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdmarca.Text = string.Empty;
        }

        //habilitar los controles del formualrio
        private void Habilitar(bool valor)
        {
            this.txtNombre_marca.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdmarca.ReadOnly = !valor;
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
                this.btnCanselar.Enabled = true;
            }

            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCanselar.Enabled = false;
            }
        }

       
        //metodo ocultar columnas
        /*  private void OcultarColumnas(DataGridView dataListado)
          {
              this.dataListado.Columns[0].Visible = false;
             this.dataListado.Columns[1].Visible = false;
          }*/

       
        private void OcultarColumnas()
         {
             if (this.dataListado.Columns.Count > 0)
                 this.dataListado.Columns[0].Visible = false;

             if (this.dataListado.Columns.Count > 1)
                 this.dataListado.Columns[1].Visible = false;
         }
        //metodo mostrar todos los registros de todas las categorias
        private void Mostrar()
        {
            this.dataListado.DataSource = NMarca.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }


        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NMarca.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);

        }



        private void FrmMarca_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

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
            this.IsNuevo=true;
            this.IsEditar=false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre_marca.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre_marca.Text==string.Empty)
                {
                    MensajeError("Fallta ingresar algunos datos, seran remarcado");
                    errorIcono.SetError(txtNombre_marca, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NMarca.Insertar(this.txtNombre_marca.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = NMarca.Editar(Convert.ToInt32(this.txtIdmarca.Text),
                               this.txtNombre_marca.Text.Trim().ToUpper(),
                               this.txtDescripcion.Text.Trim());
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdmarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_marca"].Value);
            this.txtNombre_marca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_marca"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            this.tabControl1.SelectedIndex = 1;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           if(!this.txtIdmarca.Text.Equals(""))
             {
                 this.IsEditar=true;
                 this.Botones();
                 this.Habilitar(true);
             }
          
            else
            {
                this.MensajeError("Debe de selecionar primero el registro a modificar");
            }

        }

        private void btnCanselar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar= false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkElimimnar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkElimimnar.Value = !Convert.ToBoolean(chkElimimnar.Value);
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
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo =Convert.ToString( row.Cells[1].Value);
                            Rpta = NMarca.Eliminar(Convert.ToInt32(Codigo));
                            if(Rpta.Equals("OK"))
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
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }





    }
}
