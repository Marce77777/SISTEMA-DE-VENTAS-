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
    public partial class frmVistaMarca_Articulo : Form
    {
        public frmVistaMarca_Articulo()
        {
            InitializeComponent();
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
        private void frmVistaMarca_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo form = frmArticulo.GetInstancia();
            string para1, par2;
            para1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id_marca"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_marca"].Value);
            form.setMarca(para1, par2);
            this.Hide();
        }
    }
}