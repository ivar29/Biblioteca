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
    /// Lógica de interacción para UC_libro_baja.xaml
    /// </summary>
    public partial class UC_libro_baja : UserControl
    {
        public UC_libro_baja()
        {
            InitializeComponent();
            datagrid_libro.DataContext = Clase_Libro.listaDeLibro();
            Clase_Datos datos = new Clase_Datos();
            datos.llenar_combobox_editorial("Editorial", "id_editorial, nombre_editorial", combobox_editoriales);
            datos.llenar_combobox_autor("Autor", "id_autor, nombre_autor", combobox_autores);
            contenedor.IsEnabled = false;
            txt_ID.IsEnabled = false;
        }

        private void Doble_Click_Bajar_Libro(object sender, MouseButtonEventArgs e)
        {
            object item = datagrid_libro.SelectedItem;
            cb_estado_libro.Text = (datagrid_libro.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;

            if (cb_estado_libro.Text != "Baja")
            {

            
            txt_ID.Text = (datagrid_libro.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            txt_titulo_libro.Text = (datagrid_libro.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            txt_idioma_libro.Text = (datagrid_libro.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            txt_isbn_libro.Text = (datagrid_libro.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            txt_edicion_libro.Text = (datagrid_libro.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            txt_volumen_libro.Text = (datagrid_libro.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            txt_tomo_libro.Text = (datagrid_libro.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            txt_tipo_lector.Text = (datagrid_libro.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            combobox_autores.Text = (datagrid_libro.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
            txt_otro_autor.Text = (datagrid_libro.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
            txt_notas.Text = (datagrid_libro.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
            cb_estado_libro.Text = (datagrid_libro.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
            combobox_editoriales.Text = (datagrid_libro.SelectedCells[12].Column.GetCellContent(item) as TextBlock).Text;
            

            btn_guardar.IsEnabled = true;
            btn_limpiar.IsEnabled = true;
            txt_ID.IsEnabled=false;
            txt_titulo_libro.IsEnabled=false;
            txt_idioma_libro.IsEnabled=false;
            txt_isbn_libro.IsEnabled=false;
            txt_edicion_libro.IsEnabled=false;
            txt_volumen_libro.IsEnabled=false;
            txt_tomo_libro.IsEnabled=false;
            txt_tipo_lector.IsEnabled=false;
            combobox_autores.IsEnabled=false;
            txt_otro_autor.IsEnabled=false;
            txt_notas.IsEnabled=false;
            txt_notas.IsEnabled=false;
            cb_estado_libro.IsEnabled=false;
            combobox_editoriales.IsEnabled = false;
            txt_Razon.IsEnabled = true;
            datagrid_libro.Visibility = System.Windows.Visibility.Hidden;
            lbl_buscar.Visibility = System.Windows.Visibility.Hidden;
            txt_Buscar.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("El libro ya esta dado de baja");
                
            }
            

        }

        DataView mifiltro;

        private void busqueda_libro(object sender, KeyEventArgs e)
        {
           // datagrid_libro.DataContext = Clase_Libro.listaDeLibroBusqueda(txt_Buscar.Text);
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
                    salida_datos += "AND (ID LIKE '%" + palabra + "%' OR Titulo LIKE '%" + palabra + "%' OR Idioma LIKE '%" + palabra + "%' OR ISBN LIKE '%" + palabra + "%' OR Edicion LIKE '%" + palabra + "%' OR Volumen LIKE '%" + palabra + "%' OR Tomo LIKE '%" + palabra + "%' OR TipoLector LIKE '%" + palabra + "%' OR Autor LIKE '%" + palabra + "%' OR OtroAutor LIKE '%" + palabra + "%' OR Contenido LIKE '%" + palabra + "%' OR Estado LIKE '%" + palabra + "%' OR Editorial LIKE '%" + palabra + "%')";
                    //id LIKE  '%" + palabra + "%' OR 
                }

            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void Limpiar_Form_Baja(object sender, RoutedEventArgs e)
        {
            txt_Razon.Clear();
            txt_titulo_libro.Text = "";
            txt_idioma_libro.Text = "";
            txt_isbn_libro.Text = "";
            txt_edicion_libro.Text = "";
            txt_volumen_libro.Text = "";
            txt_tomo_libro.Text = "";
            txt_tipo_lector.Text = "";
            combobox_autores.Text = "*Anonimo";
            combobox_editoriales.Text = "*Anonimo";
            txt_otro_autor.Text = "";
            txt_notas.Text = "";
            txt_ID.Text = "";
            btn_guardar.IsEnabled = false;
            btn_limpiar.IsEnabled = false;
            txt_Razon.IsEnabled = false;
            
            datagrid_libro.Visibility = System.Windows.Visibility.Visible;
            lbl_buscar.Visibility = System.Windows.Visibility.Visible;
            txt_Buscar.Visibility = System.Windows.Visibility.Visible;
            lb_baja.Content = "";
            txt_Razon.IsEnabled = false;

        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            
            

            bool pasar = true;


            if (string.IsNullOrEmpty(txt_Razon.Text) || string.IsNullOrWhiteSpace(txt_Razon.Text))
            {
                lb_baja.Content = "Escriba la razon de la baja";
                pasar = false;
            }
            else
            {
                lb_baja.Content = "";
                pasar = true;
            }


            if (pasar == true)
            {

                Clase_Datos datos = new Clase_Datos();
                string camposlibro = " estado = '" + "Baja" + "'";
                datos.actualizarEditar("Libro_Revista", camposlibro, " id= '" + Convert.ToInt32(txt_ID.Text) + "'");
                Clase_Baja.agregarBaja(new Clase_Baja(DateTime.Now.ToString(), txt_Razon.Text, Convert.ToInt32(txt_ID.Text)));
                MessageBox.Show("El libro se a dado de baja Correctamente");

                lb_baja.Content = "";
                datagrid_libro.DataContext = null;
                datagrid_libro.DataContext = Clase_Libro.listaDeLibro();
                txt_Razon.Clear();
                txt_titulo_libro.Text = "";
                txt_idioma_libro.Text = "";
                txt_isbn_libro.Text = "";
                txt_edicion_libro.Text = "";
                txt_volumen_libro.Text = "";
                txt_tomo_libro.Text = "";
                txt_tipo_lector.Text = "";
                combobox_autores.Text = "*Anonimo";
                combobox_editoriales.Text = "*Anonimo";
                txt_otro_autor.Text = "";
                txt_notas.Text = "";
                txt_ID.Text = "";
                datagrid_libro.Visibility = System.Windows.Visibility.Visible;
                lbl_buscar.Visibility = System.Windows.Visibility.Visible;
                txt_Buscar.Visibility = System.Windows.Visibility.Visible;

                btn_guardar.IsEnabled = false;
                btn_limpiar.IsEnabled = false;

                txt_Razon.IsEnabled = false;
            }
        }
    }
}
