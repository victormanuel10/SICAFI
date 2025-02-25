using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JEJ.ImprimirFicha.Modelo.sqlite
{
    public class Conexion
    {
        /*private string strCadenaConexion;
        private System.Data.SQLite.SQLiteConnection cn;
        private System.Data.SQLite.SQLiteCommand command;
        public Conexion(string strArchivo)
        {
            strCadenaConexion = "Data Source = "+strArchivo+"";
        }

        protected System.Data.SQLite.SQLiteDataReader EjecutarConsulta(string sql)
        {
            System.Data.SQLite.SQLiteDataReader Reader;
            try
            {
                cn = new System.Data.SQLite.SQLiteConnection(strCadenaConexion);
                cn.Open();
                command = new System.Data.SQLite.SQLiteCommand(sql, cn);
                Reader = command.ExecuteReader();
                return Reader;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null; 
            }
        }

        protected bool EjecutarQuery(string sql)
        {
            try
            {
                cn = new System.Data.SQLite.SQLiteConnection(strCadenaConexion);
                cn.Open();
                command = new System.Data.SQLite.SQLiteCommand(sql, cn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        protected void CerrarConxion(){
            if (command != null)
            {
                command.Dispose();
            }
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
        }*/
    }
}
