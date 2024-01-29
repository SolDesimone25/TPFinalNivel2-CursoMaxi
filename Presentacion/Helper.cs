using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace Presentacion
{
     class Helper
    {
        public static void cargarImagen(string imagen, PictureBox picture)
        {
            try
            {
                picture.Load(imagen);
                picture.SizeMode = PictureBoxSizeMode.CenterImage;
                picture.SizeMode = PictureBoxSizeMode.Zoom;

            }
            catch (Exception)
            {

                picture.Load("https://previews.123rf.com/images/kaymosk/kaymosk1804/kaymosk180400005/99776312-error-404-p%C3%A1gina-no-encontrada-error-con-efecto-de-falla-en-la-pantalla-ilustraci%C3%B3n-vectorial.jpg");
                picture.SizeMode = PictureBoxSizeMode.CenterImage;
                picture.SizeMode = PictureBoxSizeMode.Zoom;

            }


        }
       
    }
}
