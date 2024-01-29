using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmMarcaCategoria : Form
    {
        private List<Marca> listaMarca;
        private List<Categoria> listaCategorias;
        public bool marcaocategoria = false;
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        public FrmMarcaCategoria()
        {
            InitializeComponent();
        }

        private void FrmMarcaCategoria_Load(object sender, EventArgs e)
        {

            try
            {
                if (marcaocategoria == true)
                {
                    CargarMarca();               
                }
                else
                {
                    CargarCategoria();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarMC_Click(object sender, EventArgs e)
        {
            try
            {
                if (marcaocategoria == true)
                {
                    if (tbxMarCat.Text != "")
                    {
                        Marca marca = new Marca();
                        marca.Descripcion = tbxMarCat.Text;
                        marcaNegocio.AgregarMarca(marca);
                        MessageBox.Show("¡Marca agregada exitosamente!");
                        CargarMarca();
                        tbxMarCat.Text = "";
                    }
                    else
                        MessageBox.Show("Por favor, ingrese una Marca");

                }
                else
                {
                    if(tbxMarCat.Text != "")
                    {
                        Categoria categoria = new Categoria();
                        categoria.Descripcion = tbxMarCat.Text;
                        categoriaNegocio.AgregarCategoria(categoria);
                        MessageBox.Show("¡Categoria agregada exitosamente!");
                        CargarCategoria();
                        tbxMarCat.Text = "";
                    }
                    else
                        MessageBox.Show("Por favor, ingrese una Categoria.");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnEliminarMC_Click(object sender, EventArgs e)
        {
            Marca marcSelec;
            Categoria catSelec;
            try
            {
                if (marcaocategoria == true)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad quieres eliminar este Item?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (dgvMarcaCategoria.CurrentRow != null)
                        {
                            marcSelec = (Marca)dgvMarcaCategoria.CurrentRow.DataBoundItem;
                            marcaNegocio.EliminarMarca(marcSelec.Id);
                            CargarMarca();
                        }
                    }
                    else
                        return;

                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad quieres eliminar este Item?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (dgvMarcaCategoria.CurrentRow != null)
                        {
                            catSelec = (Categoria)dgvMarcaCategoria.CurrentRow.DataBoundItem;
                            categoriaNegocio.EliminarCategoria(catSelec.Id);
                            CargarCategoria();
                        }

                    }
                    else
                        return;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void CargarMarca()
        {
           
            listaMarca = marcaNegocio.listar();
            dgvMarcaCategoria.DataSource = listaMarca;
            dgvMarcaCategoria.Columns["Id"].Visible = false;
        }
        private void CargarCategoria()
        {
            listaCategorias = categoriaNegocio.listar();
            dgvMarcaCategoria.DataSource = listaCategorias;
            dgvMarcaCategoria.Columns["Id"].Visible = false;
        }

        private void btnModificarMC_Click(object sender, EventArgs e)
        {
            Marca marcSelec;
            string mc;
            Categoria cateSele;
            try
            {
                if(marcaocategoria == true)
                {
                    if (!(string.IsNullOrEmpty(tbxMarCat.Text)))
                    {
                        marcSelec = (Marca)dgvMarcaCategoria.CurrentRow.DataBoundItem;
                        mc = tbxMarCat.Text;
                        marcaNegocio.ModificarMarca(marcSelec.Id, mc);
                        MessageBox.Show("¡Modificado exitosamente!");
                        CargarMarca();
                    }
                    else
                        MessageBox.Show("Ingrese la palabra por la cual quiere modificar");
                }
                else
                {
                    if (!(string.IsNullOrEmpty(tbxMarCat.Text)))
                    {
                        cateSele = (Categoria)dgvMarcaCategoria.CurrentRow.DataBoundItem;
                        mc = tbxMarCat.Text;
                        categoriaNegocio.ModificarCategoria(cateSele.Id, mc);
                        MessageBox.Show("¡Modificado exitosamente!");
                        CargarCategoria();
                    }
                    else
                        MessageBox.Show("Ingrese la palabra por la cual quiere modificar");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltrarMC_Click(object sender, EventArgs e)
        {
            List<Marca> listaMFiltrada;
            List<Categoria> listaCFiltrada;
            string filtro = txbFiltroMC.Text;
            try
            {
                if(marcaocategoria == true)
                {
                    if(filtro != "")
                    {
                        listaMFiltrada = listaMarca.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper())); 
                    }
                    else
                    {
                        listaMFiltrada = listaMarca;
                    }
                   
                    dgvMarcaCategoria.DataSource = null;
                    dgvMarcaCategoria.DataSource = listaMFiltrada;
                }
                else
                {
                    if (filtro != "")
                    {
                        listaCFiltrada = listaCategorias.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                    }
                    else
                    {
                        listaCFiltrada = listaCategorias;
                    }
                    
                    dgvMarcaCategoria.DataSource = null;
                    dgvMarcaCategoria.DataSource = listaCFiltrada;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

    }
}
