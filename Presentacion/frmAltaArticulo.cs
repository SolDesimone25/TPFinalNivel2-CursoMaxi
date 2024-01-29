using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using System.IO;
using System.Configuration;

namespace Presentacion
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio art = new ArticuloNegocio();

            try
            {
                if (tbxCodigo.Text == "")
                {
                    MessageBox.Show("Debe completar los campos antes de ACEPTAR");
                    return;
                }

                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;   
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                articulo.UrlImagen = tbxImagen.Text;
                articulo.Precio = decimal.Parse(tbxPrecio.Text);

                if (cbxCategoria.SelectedIndex < 0 || cbxMarca.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar en los desplegables.");
                    return;
                }

                if (articulo.Id != 0)
                {
                    art.modificarArticulo(articulo);
                    MessageBox.Show("¡Modificado Exitosamente!", "Modificando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    art.agregarArticulo(articulo);
                    MessageBox.Show("¡Agregado Exitosamente!", "Agregando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (archivo != null && !(tbxImagen.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["articulo-app"] + archivo.SafeFileName);
                }

                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
                        
            
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                cbxMarca.DataSource = marca.listar();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";
                cbxCategoria.DataSource = categoria.listar();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";

                if(articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                    cbxCategoria.SelectedValue = articulo.Categoria.Id;
                    cbxMarca.SelectedValue = articulo.Marca.Id;
                    tbxImagen.Text = articulo.UrlImagen;
                    tbxPrecio.Text = articulo.Precio.ToString();
                    Helper.cargarImagen(articulo.UrlImagen, pbxAltaArticulo);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void tbxImagen_Leave(object sender, EventArgs e)
        {
            try
            {
                Helper.cargarImagen(tbxImagen.Text, pbxAltaArticulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnLevantarImg_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg; |png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK )
            {
                tbxImagen.Text = archivo.FileName;
                Helper.cargarImagen(archivo.FileName, pbxAltaArticulo);
            }
            
        }
    }
}
