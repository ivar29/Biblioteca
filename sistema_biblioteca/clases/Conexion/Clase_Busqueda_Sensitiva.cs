using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sistema_Biblioteca.Clases.Conexion;
using Sistema_Biblioteca.Clases;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace Sistema_Biblioteca.Clases.Conexion
{
    class Clase_Busqueda_Sensitiva
    {
        public static void Buscar_Sensitiva(string query, ref DataSet dstprincipal, string tabla)
        {
            try
            {
                string cadena = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\bd_Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection cn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dstprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

    }
}
