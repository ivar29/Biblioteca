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
using Sistema_Biblioteca.Clases;
using Sistema_Biblioteca.Clases.Conexion;
using System.Data;

namespace Sistema_Biblioteca.UC_Libro
{
    /// <summary>
    /// Lógica de interacción para UC_libro_editar.xaml
    /// </summary>
    public partial class UC_libro_editar : UserControl
    {
        public UC_libro_editar()
        {
            InitializeComponent();
            datagrid_libro.DataContext = Clase_Libro.listaDeLibro();
            Clase_Datos datos = new Clase_Datos();
            datos.llenar_combobox_editorial("Editorial", "id_editorial, nombre_editorial", combobox_editoriales);
            datos.llenar_combobox_autor("Autor", "id_autor, nombre_autor", combobox_autores);
            txt_ID.IsEnabled = false;
            combobox_autores.SelectedIndex = 0;
            combobox_editoriales.SelectedIndex = 0;
            contenedor.IsEnabled = false;

        }

        DataView mifiltro;

        private void busqueda_libro(object sender, KeyEventArgs e)
        {
            //datagrid_libro.DataContext = Clase_Libro.listaDeLibroBusqueda(txt_Buscar.Text);


            DataSet resultados = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID, titulo AS Titulo, idioma_libro AS Idioma, isbn AS ISBN, edicion_libro AS Edicion, volumen_libro AS Volumen, tomo_libro AS Tomo, tipo_lector_libro AS TipoLector, autor_libro AS Autor, otro_autor AS OtroAutor, contenido AS Contenido, estado AS Estado ,editorial_libro AS Editorial  FROM Libro_Revista WHERE tipo_item = 'Libro'", ref resultados, "Libro_Revista");
            this.mifiltro = ((DataTable)resultados.Tables["Libro_Revista"]).DefaultView;
            this.datagrid_libro.DataContext = mifiltro;

            string salida_datos = "";
            string[] palabras_busqueda = this.txt_Buscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Idioma LIKE '%" + palabra + "%' OR ISBN LIKE '%" + palabra + "%' OR Edicion LIKE '%" + palabra + "%' OR Volumen LIKE '%" + palabra + "%' OR Tomo LIKE '%" + palabra + "%' OR TipoLector LIKE '%" + palabra + "%' OR Autor LIKE '%" + palabra + "%' OR OtroAutor LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Editorial LIKE '%" + palabra + "%')";
                    //id LIKE  '%" + palabra + "%' OR 
                }
                else
                {
                    salida_datos += "AND (ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Idioma LIKE '%" + palabra + "%' OR ISBN LIKE '%" + palabra + "%' OR Edicion LIKE '%" + palabra + "%' OR Volumen LIKE '%" + palabra + "%' OR Tomo LIKE '%" + palabra + "%' OR TipoLector LIKE '%" + palabra + "%' Autor LIKE '%" + palabra + "%' OR OtroAutor LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Editorial LIKE '%" + palabra + "%' )";
                    //id LIKE  '%" + palabra + "%' OR 
                }

            }
            this.mifiltro.RowFilter = salida_datos;

        }

        private void Doble_Click_Editar_Libro(object sender, MouseButtonEventArgs e)
        {


            try
            {


                object item = datagrid_libro.SelectedItem;
                txt_ID.Text = (datagrid_libro.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_titulo_libro.Text = (datagrid_libro.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                combobox_idioma.Text = (datagrid_libro.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txt_isbn.Text = (datagrid_libro.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                txt_edicion_libro.Text = (datagrid_libro.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                txt_volumen_libro.Text = (datagrid_libro.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                txt_tomo_libro.Text = (datagrid_libro.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                combobox_tipolector.Text = (datagrid_libro.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                combobox_autores.Text = (datagrid_libro.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                txt_otro_autor1.Text = (datagrid_libro.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                txt_notas.Text = (datagrid_libro.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                cb_estado_libro.Text = (datagrid_libro.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
                combobox_editoriales.Text = (datagrid_libro.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text;
                datagrid_libro.Visibility = System.Windows.Visibility.Hidden;
                lbl_Libro_Buscar.Visibility = System.Windows.Visibility.Hidden;
                txt_Buscar.Visibility = System.Windows.Visibility.Hidden;
                contenedor.IsEnabled = true;

            }
            catch (Exception ex)
            {

            }
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            lb_nombre.Content = "";
            txt_titulo_libro.Text = "";
            combobox_idioma.Text = "Español";
            txt_isbn.Text = "No tiene";
            txt_edicion_libro.Text = "No tiene";
            txt_volumen_libro.Text = "No tiene";
            txt_tomo_libro.Text = "No tiene";
            combobox_tipolector.Text = "Alumno";
            combobox_autores.Text = "*Anonimo";
            combobox_editoriales.Text = "*Anonimo";
            txt_otro_autor1.Text = "No tiene";
            txt_notas.Text = "";
            txt_ID.Text = "";
            contenedor.IsEnabled = false;
            
            datagrid_libro.Visibility = System.Windows.Visibility.Visible;
            lbl_Libro_Buscar.Visibility = System.Windows.Visibility.Visible;
            txt_Buscar.Visibility = System.Windows.Visibility.Visible;
           
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            bool pasar = true;


            if (string.IsNullOrEmpty(txt_titulo_libro.Text) || string.IsNullOrWhiteSpace(txt_titulo_libro.Text))
            {
                lb_nombre.Content = "*";
                pasar = false;
            }
            else
            {
                lb_nombre.Content = "";
                pasar = true;
            }


            if (pasar == true)
            {
                Clase_Datos datos = new Clase_Datos();
                string campos = "titulo = '" + txt_titulo_libro.Text + "', idioma_libro = '" + combobox_idioma.Text + "', isbn = '" + txt_isbn.Text + "' , edicion_libro = '" + txt_edicion_libro.Text + "' , volumen_libro = '" + txt_volumen_libro.Text + "'  , tomo_libro = '" + txt_tomo_libro.Text + "' , tipo_lector_libro = '" + combobox_tipolector.Text + "' , autor_libro = '" + combobox_autores.Text + "' , otro_autor = '" + txt_otro_autor1.Text + "' , contenido = '" + txt_notas.Text + "' , estado = '" + cb_estado_libro.Text + "' , editorial_libro = '" + combobox_editoriales.Text + "'";
                datos.actualizarEditar("Libro_Revista", campos, " id= '" + Convert.ToInt32(txt_ID.Text) + "'");
                MessageBox.Show("Datos Editados Correctamente");

                txt_titulo_libro.Text = "";
             
                txt_edicion_libro.Text = "";
                txt_volumen_libro.Text = "";
                txt_tomo_libro.Text = "";
                txt_isbn.Text = "No tiene";
                txt_edicion_libro.Text = "No tiene";
                txt_volumen_libro.Text = "No tiene";
                txt_tomo_libro.Text = "No tiene";
                combobox_autores.Text = "*Anonimo";
                combobox_editoriales.Text = "*Anonimo";
                txt_otro_autor1.Text = "No tiene";
                combobox_tipolector.Text = "Alumno";
                txt_notas.Text = "";
                txt_ID.Text = "";
                contenedor.IsEnabled = false;
                combobox_idioma.Text = "Español";

                txt_Buscar.Clear();
                datagrid_libro.DataContext = null;
                datagrid_libro.DataContext = Clase_Libro.listaDeLibro();
                datagrid_libro.Visibility = System.Windows.Visibility.Visible;
                lbl_Libro_Buscar.Visibility = System.Windows.Visibility.Visible;
                txt_Buscar.Visibility = System.Windows.Visibility.Visible;
            }



        }

        private void txt_otro_autor_KeyDown(object sender, KeyEventArgs e)
        {

            if (txt_otro_autor1.Text == "No tiene")
            {
                txt_otro_autor1.Clear();
            }
           
        }

        private void txt_otro_autor_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            if (txt_otro_autor1.Text.Equals("") || string.IsNullOrWhiteSpace(txt_otro_autor1.Text))
            {

                txt_otro_autor1.Text = "No tiene";

            }
        }

        private void txt_isbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_isbn.Text == "No tiene")
            {
                txt_isbn.Clear();
            }
        }

        private void txt_isbn_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_isbn.Text.Equals("") || string.IsNullOrWhiteSpace(txt_isbn.Text))
            {

                txt_isbn.Text = "No tiene";

            }
        }

        private void txt_edicion_libro_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_edicion_libro.Text == "No tiene")
            {
                txt_edicion_libro.Clear();
            }
        }

        private void txt_edicion_libro_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_edicion_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_edicion_libro.Text))
            {

                txt_edicion_libro.Text = "No tiene";

            }
        }

        private void txt_tomo_libro_KeyDown(object sender, KeyEventArgs e)
        {

            if (txt_tomo_libro.Text == "No tiene")
            {
                txt_tomo_libro.Clear();
            }

        }

        private void txt_tomo_libro_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            if (txt_tomo_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_tomo_libro.Text))
            {

                txt_tomo_libro.Text = "No tiene";

            }

        }

        private void txt_volumen_libro_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_volumen_libro.Text == "No tiene")
            {
                txt_volumen_libro.Clear();
            }
        }

        private void txt_volumen_libro_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_volumen_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_volumen_libro.Text))
            {

                txt_volumen_libro.Text = "No tiene";

            }
        }

        


    }
}
