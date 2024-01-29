using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using Negocio;


namespace Presentacion
{
    public partial class frmCatalogo : Form
    {
        private List<Articulo> listaArticulo;
        public frmCatalogo()
        {
            InitializeComponent();
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            cargar();
            cbxCampo.Items.Add("Codigo");
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Descripcion");
            cbxCampo.Items.Add("Precio");          
        }
        
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    Helper.cargarImagen(seleccionado.UrlImagen, pbxArticulo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo Alta = new frmAltaArticulo();
            try
            {
                Alta.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        public void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.Listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.Columns["UrlImagen"].Visible = false;
                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["Codigo"].Visible = false;
                dgvArticulos.Columns["Descripcion"].Visible = false;
                if (dgvArticulos.CurrentRow != null ) 
                { 
                    Helper.cargarImagen(listaArticulo[0].UrlImagen, pbxArticulo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;

            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    seleccionado = (Articulo) dgvArticulos.CurrentRow.DataBoundItem;

                    frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                    modificar.ShowDialog();
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                if(dgvArticulos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad quieres eliminar este Articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        articuloNegocio.eliminarArticulo(seleccionado.Id);
                        cargar();

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxCampo.SelectedItem.ToString();

            if( opcion == "Precio")
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Mayor a...");
                cbxCriterio.Items.Add("Menor a...");
                cbxCriterio.Items.Add("Igual a...");
            }
            else
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Empieza con...");
                cbxCriterio.Items.Add("Termina con...");
                cbxCriterio.Items.Add("Contiene...");
            }
        }
        private bool validarFiltro()
        {
            if (cbxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el Campo para filtrar.");
                return true;
            }
            if (cbxCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el Criterio para filtrar.");
                return true;
            }
            if (cbxCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty (tbxFiltro.Text))
                {
                    MessageBox.Show("Debe cargar el filtro numerico");
                    return true;
                }
                if (!(soloNumeros(tbxFiltro.Text)))
                {
                    MessageBox.Show("Ingrese solo numeros");
                    return true;
                }

            }

            return false;
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }


        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cbxCampo.SelectedItem.ToString();
                string criterio = cbxCriterio.SelectedItem.ToString();
                string filtro = tbxFiltro.Text;
                dgvArticulos.DataSource = negocio.filtrarArticulo(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
       
        private void btnMarca_Click(object sender, EventArgs e)
        {
            FrmMarcaCategoria marca = new FrmMarcaCategoria();

            try
            {
                marca.marcaocategoria = true;
                marca.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmMarcaCategoria categoria = new FrmMarcaCategoria();

            try
            {
                categoria.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

       
    }
}
