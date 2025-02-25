using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JEJ.ImprimirFicha.Utilidades
{
    public static class CopiarArchivos
    {
        public static bool CopiarEjecutables(string strNombreArchivo, string strRutaCarpeta)
        {
            try
            {
                /*if (System.IO.File.Exists(strRutaCarpeta + "\\" + strNombreArchivo + ".pyc"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\" + strNombreArchivo + ".pyc");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\" + strNombreArchivo + ".pyc"
                                            , JEJ.ImprimirFicha.Properties.Resources.Plano);

                if (System.IO.File.Exists(strRutaCarpeta + "\\bd.s3db"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\bd.s3db");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\bd.s3db"
                                            , JEJ.ImprimirFicha.Properties.Resources.bd);
                if (!System.IO.File.Exists(strRutaCarpeta + "\\pypyodbc.pyc"))
                {
                    System.IO.File.WriteAllBytes(strRutaCarpeta + "\\pypyodbc.pyc"
                                             , JEJ.ImprimirFicha.Properties.Resources.pypyodbc);
                }*/
                if (!System.IO.File.Exists(strRutaCarpeta + "\\JEJCatastro.mdb"))
                {
                    
                    System.IO.File.WriteAllBytes(strRutaCarpeta + "\\JEJCatastro.mdb"
                                             , IMPRESION.Properties.Resources.JEJCatastro);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool CopiarMXD( string strRutaCarpeta)
        {
            try
            {
                // Copio con cero construcciones
                if (System.IO.File.Exists(strRutaCarpeta + "\\C0.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\C0.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\C0.mxd"
                                                , IMPRESION.Properties.Resources.C0);
                // Copio con 1 construcciones
                if (System.IO.File.Exists(strRutaCarpeta + "\\C1.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\C1.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\C1.mxd"
                                                , IMPRESION.Properties.Resources.C1);
                // Copio con 2 construcciones
                if (System.IO.File.Exists(strRutaCarpeta + "\\C2.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\C2.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\C2.mxd"
                                                , IMPRESION.Properties.Resources.C2);

                // Copio con 3 construcciones
                if (System.IO.File.Exists(strRutaCarpeta + "\\C3.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\C3.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\C3.mxd"
                                                , IMPRESION.Properties.Resources.C3);
                // Copio con 4 construcciones
                if (System.IO.File.Exists(strRutaCarpeta + "\\C4.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\C4.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\C4.mxd"
                                                , IMPRESION.Properties.Resources.C4);

                // Copio con 1 Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\M1.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\M1.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\M1.mxd"
                                                , IMPRESION.Properties.Resources.M1);

                // Copio con 2 Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\M2.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\M2.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\M2.mxd"
                                                , IMPRESION.Properties.Resources.M2);

                // Copio con 3 Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\M3.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\M3.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\M3.mxd"
                                                , IMPRESION.Properties.Resources.M3);

                // Copio con 4 Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\M4.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\M4.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\M4.mxd"
                                                , IMPRESION.Properties.Resources.M4);

                // Copio con PA Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\PA.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\PA.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\PA.mxd"
                                                , IMPRESION.Properties.Resources.PA);

                // Copio con PU Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\PU.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\PU.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\PU.mxd"
                                                , IMPRESION.Properties.Resources.PU);

                // Copio con PUP Mejora
                if (System.IO.File.Exists(strRutaCarpeta + "\\PUP.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\PUP.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\PUP.mxd"
                                                , IMPRESION.Properties.Resources.UPU);

                // Copio con MC1
                if (System.IO.File.Exists(strRutaCarpeta + "\\MC1.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\MC1.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\MC1.mxd"
                                                , IMPRESION.Properties.Resources.MC1);

                // Copio con MC2
                if (System.IO.File.Exists(strRutaCarpeta + "\\MC2.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\MC2.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\MC2.mxd"
                                                , IMPRESION.Properties.Resources.MC2);

                // Copio con MC3
                if (System.IO.File.Exists(strRutaCarpeta + "\\MC3.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\MC3.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\MC3.mxd"
                                                , IMPRESION.Properties.Resources.MC3);

                // Copio con MC4
                if (System.IO.File.Exists(strRutaCarpeta + "\\MC4.mxd"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\MC4.mxd");
                }
                System.IO.File.WriteAllBytes(strRutaCarpeta + "\\MC4.mxd"
                                                , IMPRESION.Properties.Resources.MC4);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool CopiarArchivosStaticos(string strRutaCarpeta)
        {
            try
            {
                if(System.IO.File.Exists(strRutaCarpeta+ "\\Portada.png"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\Portada.png");
                }
                System.Drawing.Bitmap Portada = IMPRESION.Properties.Resources.Portada;
                Portada.Save(strRutaCarpeta + "\\Portada.png");

                if (System.IO.File.Exists(strRutaCarpeta + "\\FondoBlanco400.png"))
                {
                    System.IO.File.Delete(strRutaCarpeta + "\\FondoBlanco400.png");
                }
                System.Drawing.Bitmap FondoBlanco = IMPRESION.Properties.Resources.FondoBlanco400;
                FondoBlanco.Save(strRutaCarpeta + "\\FondoBlanco400.png");


                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
