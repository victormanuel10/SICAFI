using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEJ.ImprimirFicha.Negocio.Utilidades.TipoDato
{
    public static class tipoImagenes
    {
        #region Metodos Publicos
        public static void ResizeImage
                      (string strArchivo, int queridoHeight, int queridoWidth)
        {
            Bitmap vBitmap;
            using (Image pImagen = Image.FromFile(strArchivo))
            {
                int pAncho = Convert.ToInt32(pImagen.Width);
                int pAlto = Convert.ToInt32(pImagen.Height);
                tipoImagenes.SaberHeightyWidth(pImagen, queridoHeight, queridoWidth, ref pAncho, ref pAlto);
                //creamos un bitmap con el nuevo tamaño
                vBitmap = new Bitmap(pAncho, pAlto);
                //creamos un graphics tomando como base el nuevo Bitmap
                using (Graphics vGraphics = Graphics.FromImage((Image)vBitmap))
                {
                    //especificamos el tipo de transformación, se escoge esta para no perder calidad.
                    vGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //Se dibuja la nueva imagen
                    vGraphics.DrawImage(pImagen, 0, 0, pAncho, pAlto);
                    vGraphics.Dispose();
                }

                pImagen.Dispose();
            }
            if (System.IO.File.Exists(strArchivo))
            {
                System.IO.File.Delete(strArchivo);
            }
           //retornamos la nueva imagen
           ((Image)vBitmap).Save(strArchivo);
            ((Image)vBitmap).Dispose();
        }

        public static void ReziseHeight(string strArchivo, int queridoHeight)
        {
            Bitmap vBitmap;
            using (Image pImagen = Image.FromFile(strArchivo))
            {
                int pAncho = Convert.ToInt32(pImagen.Width);
                int pAlto = Convert.ToInt32(pImagen.Height);
                tipoImagenes.SaberWidth(pImagen, queridoHeight, ref pAncho, ref pAlto);
                //creamos un bitmap con el nuevo tamaño
                vBitmap = new Bitmap(pAncho, pAlto);
                //creamos un graphics tomando como base el nuevo Bitmap
                using (Graphics vGraphics = Graphics.FromImage((Image)vBitmap))
                {
                    //especificamos el tipo de transformación, se escoge esta para no perder calidad.
                    vGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //Se dibuja la nueva imagen
                    vGraphics.DrawImage(pImagen, 0, 0, pAncho, pAlto);
                    vGraphics.Dispose();
                }

                pImagen.Dispose();
            }
            if (System.IO.File.Exists(strArchivo))
            {
                System.IO.File.Delete(strArchivo);
            }
           //retornamos la nueva imagen
           ((Image)vBitmap).Save(strArchivo);
            ((Image)vBitmap).Dispose();

        }
        #endregion

        #region Metodos Privados
        private static void SaberHeightyWidth(Image srcImage
                                            , int queridoHeight
                                            , int queridoWidth
                                            , ref int newWidth
                                            , ref int newHeight)
        {
            newWidth = srcImage.Width;
            newHeight = srcImage.Height;
            int porcentaje;
            if (newWidth > newHeight)
            {
                porcentaje = Convert.ToInt32((queridoWidth * 100) / newWidth);
                int porWidth = Convert.ToInt32((newWidth * porcentaje) / 100);
                newHeight = Convert.ToInt32((newHeight * porWidth) / newWidth);
                newWidth = porWidth;
            }
            else
            {
                porcentaje = Convert.ToInt32((queridoHeight * 100) / newHeight);
                int porHeight = Convert.ToInt32((newHeight * porcentaje) / 100);
                newWidth = Convert.ToInt32((newWidth * porHeight) / newHeight);
                newHeight = porHeight;
            }

        }

        private static void SaberWidth(Image srcImage
                                           , int queridoHeight
                                           , ref int newWidth
                                           , ref int newHeight)
        {
            newWidth = srcImage.Width;
            newHeight = srcImage.Height;
            int porcentaje;
            porcentaje = Convert.ToInt32((queridoHeight * 100) / newHeight);
            int porHeight = Convert.ToInt32((newHeight * porcentaje) / 100);
            newWidth = Convert.ToInt32((newWidth * porHeight) / newHeight);
            newHeight = porHeight;
        }
        #endregion
    }

}
