using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS values (@Cod, @Nombre, @Desc, @Marca, @Cat, @ImgUrl, @Precio)");
                datos.setearParametros("@Cod", articulo.Codigo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Desc", articulo.Descripcion);
                datos.setearParametros("@Marca", articulo.Marca.Id);
                datos.setearParametros("@Cat", articulo.Categoria.Id);
                datos.setearParametros("@ImgUrl", articulo.UrlImagen);
                datos.setearParametros("@Precio", articulo.Precio);
                
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
  
        }
        public void modificarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Cod, Nombre = @Nombre, Descripcion = @Desc, IdMarca = @Marca, IdCategoria = @Cate, ImagenUrl = @Img, Precio = @Precio where Id = @Id");
                datos.setearParametros("@Cod", articulo.Codigo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Desc", articulo.Descripcion);
                datos.setearParametros("@Marca", articulo.Marca.Id);
                datos.setearParametros("@Cate", articulo.Categoria.Id);
                datos.setearParametros("@Img", articulo.UrlImagen);
                datos.setearParametros("@Precio", articulo.Precio);
                datos.setearParametros("@Id", articulo.Id);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametros("@Id",id);
                datos.ejecutarAccion();                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Articulo> filtrarArticulo(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria And ";
                switch (campo)
                {
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Empieza con...":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con...":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza con...":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con...":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Empieza con...":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con...":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Mayor a...":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a...":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
