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

namespace Sistema_Biblioteca.UC_busqueda_Sensitiva
{
    /// <summary>
    /// Lógica de interacción para UC_Busqueda_Sensitiva.xaml
    /// </summary>
    public partial class UC_Busqueda_Sensitiva : UserControl
    {
        public UC_Busqueda_Sensitiva()
        {
            InitializeComponent();


            this.Grid_Busqueda.DataContext = mifiltro;
            Grid_Busqueda.Visibility = System.Windows.Visibility.Hidden;
        }
        
       
        DataView mifiltro;

        private void LLenar_mi_DataGrid(object sender, KeyEventArgs e)
        {
            

            if (cmb_opciones_busqueda.Text == "REVISTAS")
            {

                DataSet resultados = new DataSet();
                Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID, titulo AS Titulo, fecha_fundacion AS FechaFundacion, issn_revista AS ISSN , estado AS Estado, contenido AS Contenido FROM Libro_Revista WHERE tipo_item = 'Revista'", ref resultados, "Libro_Revista");
                this.mifiltro = ((DataTable)resultados.Tables["Libro_Revista"]).DefaultView;
                this.Grid_Busqueda.DataContext = mifiltro;

                Grid_Busqueda.Visibility = System.Windows.Visibility.Visible;
                string salida_datos = "";
                string[] palabras_busqueda = this.txt_Buscar_sensitiva.Text.Split(' ');

                foreach (string palabra in palabras_busqueda)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "(ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR FechaFundacion LIKE '%" + palabra + "%' OR ISSN LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%')";
                        //   id LIKE '%" + palabra + "%' OR 
                    }
                    else
                    {
                        salida_datos += "AND (ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR FechaFundacion LIKE '%" + palabra + "%' OR ISSN LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%')";
                        // id LIKE '%" + palabra + "%' OR
                    }

                }
                this.mifiltro.RowFilter = salida_datos;
            }

            if (cmb_opciones_busqueda.Text == "LIBROS")
            {

                DataSet resultados = new DataSet();
                Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID, titulo AS Titulo, idioma_libro AS Idioma, isbn AS ISBN, edicion_libro AS Edicion, volumen_libro AS Volumen, tomo_libro AS Tomo, tipo_lector_libro AS TipoLector, autor_libro AS Autor, otro_autor AS OtroAutor, contenido AS Contenido, estado AS Estado ,editorial_libro AS Editorial  FROM Libro_Revista WHERE tipo_item = 'Libro'", ref resultados, "Libro_Revista");
                this.mifiltro = ((DataTable)resultados.Tables["Libro_Revista"]).DefaultView;
                this.Grid_Busqueda.DataContext = mifiltro;

                Grid_Busqueda.Visibility = System.Windows.Visibility.Visible;
                string salida_datos = "";
                string[] palabras_busqueda = this.txt_Buscar_sensitiva.Text.Split(' ');

                foreach (string palabra in palabras_busqueda)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "(ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Idioma LIKE '%" + palabra + "%' OR ISBN LIKE '%" + palabra + "%' OR Edicion LIKE '%" + palabra + "%' OR Volumen LIKE '%" + palabra + "%' OR Tomo LIKE '%" + palabra + "%' OR TipoLector LIKE '%" + palabra + "%' OR Autor LIKE '%" + palabra + "%' OR OtroAutor LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Editorial LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += "AND (ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Idioma LIKE '%" + palabra + "%' OR ISBN LIKE '%" + palabra + "%' OR Edicion LIKE '%" + palabra + "%' OR Volumen LIKE '%" + palabra + "%' OR Tomo LIKE '%" + palabra + "%' OR TipoLector LIKE '%" + palabra + "%' OR Autor LIKE '%" + palabra + "%' OR OtroAutor LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Editorial LIKE '%" + palabra + "%')";
                    }

                }
                this.mifiltro.RowFilter = salida_datos;
            }

            if (cmb_opciones_busqueda.Text == "MATERIAL")
            {

                DataSet resultados1 = new DataSet();
                Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID ,titulo AS Titulo ,estado AS Estado FROM Libro_Revista WHERE tipo_item = 'Material'", ref resultados1, "Libro_Revista");
                this.mifiltro = ((DataTable)resultados1.Tables["Libro_Revista"]).DefaultView;
                this.Grid_Busqueda.DataContext = mifiltro;

                Grid_Busqueda.Visibility = System.Windows.Visibility.Visible;
                string salida_datos = "";
                string[] palabras_busqueda = this.txt_Buscar_sensitiva.Text.Split(' ');

                foreach (string palabra in palabras_busqueda)
                {
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = "(ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%')";
                    }
                    else
                    {
                        salida_datos += "AND (ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%')";
                    }

                }
                this.mifiltro.RowFilter = salida_datos;
            
            
            }
        }

       
    }
}
