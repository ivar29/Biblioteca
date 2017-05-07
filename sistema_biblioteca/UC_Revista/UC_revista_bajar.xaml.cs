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
using System.Data;
using Sistema_Biblioteca.Clases.Conexion;

namespace Sistema_Biblioteca.UC_Revista
{
    /// <summary>
    /// Lógica de interacción para UC_revista_bajar.xaml
    /// </summary>
    public partial class UC_revista_bajar : UserControl
    {
        public UC_revista_bajar()
        {
            InitializeComponent();
            dataGrid_Revistas.DataContext = Clase_Revista.listaDeRevista();
            fecha_Fundacion.DisplayDateEnd = DateTime.Today;
            contenedor.IsEnabled = false;
            btn_Bajar.IsEnabled = false;
            btn_Limpiar.IsEnabled = false;
            txt_razon.IsEnabled = false;
        }

        private void Doble_Click_Revista_Bajar(object sender, MouseButtonEventArgs e)
        {
            object item = dataGrid_Revistas.SelectedItem;
            cb_estado.Text = (dataGrid_Revistas.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

            if (cb_estado.Text != "Baja")
            {

                DateTime? saber_fecha = fecha_Fundacion.SelectedDate;
                if (saber_fecha != null)
                {
                    fecha_Fundacion.DisplayDate = Convert.ToDateTime((dataGrid_Revistas.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);

                }
            

               
                txt_id.Text = (dataGrid_Revistas.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_nombre.Text = (dataGrid_Revistas.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                fecha_Fundacion.Text = (dataGrid_Revistas.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txt_issn.Text = (dataGrid_Revistas.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                txt_contenido.Text = (dataGrid_Revistas.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                dataGrid_Revistas.Visibility = System.Windows.Visibility.Hidden;
                txt_id_Buscar.Visibility = System.Windows.Visibility.Hidden;
                lbl_buscar.Visibility = System.Windows.Visibility.Hidden;
                btn_Bajar.IsEnabled = true;
                btn_Limpiar.IsEnabled = true;
                txt_razon.IsEnabled = true;
                cb_estado.Text = "Baja";


                contenedor.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("La revista seleccionada ya esta dado de baja.");
            }
        }

        DataView mifiltro;

        private void Buscar_revista(object sender, KeyEventArgs e)
        {
           // dataGrid_Revistas.DataContext = Clase_Revista.listaDeRevistaBusqueda(txt_id_Buscar.Text);
            DataSet resultados = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID, titulo AS Titulo, fecha_fundacion AS FechaFundacion, issn_revista AS ISSN , estado AS Estado, contenido AS Contenido FROM Libro_Revista WHERE tipo_item = 'Revista'", ref resultados, "Libro_Revista");
            this.mifiltro = ((DataTable)resultados.Tables["Libro_Revista"]).DefaultView;
            this.dataGrid_Revistas.DataContext = mifiltro;

            dataGrid_Revistas.Visibility = System.Windows.Visibility.Visible;
            string salida_datos = "";
            string[] palabras_busqueda = this.txt_id_Buscar.Text.Split(' ');

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

        private void Limpiar_Form_Bajar_Revista(object sender, RoutedEventArgs e)
        {
            lb_baja.Content = "";
            txt_contenido.Text = "";
            txt_id.Text = "";
            txt_issn.Text = "";
            txt_nombre.Text = "";
            txt_razon.Text = "";
            btn_Bajar.IsEnabled = false;
            btn_Limpiar.IsEnabled = false;
            txt_razon.IsEnabled = false;
            dataGrid_Revistas.Visibility = System.Windows.Visibility.Visible;
            txt_id_Buscar.Visibility = System.Windows.Visibility.Visible;
            lbl_buscar.Visibility = System.Windows.Visibility.Visible;

        }

        private void btn_Bajar_Click(object sender, RoutedEventArgs e)
        {
            bool pasar = true;


            if (string.IsNullOrEmpty(txt_razon.Text) || string.IsNullOrWhiteSpace(txt_razon.Text))
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
                string camposrevista = " estado = '" + "Baja" + "'";
                datos.actualizarEditar("Libro_Revista", camposrevista, " id= '" + Convert.ToInt32(txt_id.Text) + "'");


                Clase_Baja.agregarBaja(new Clase_Baja(DateTime.Now.ToString(), txt_razon.Text, Convert.ToInt32(txt_id.Text)));
                MessageBox.Show("El libro se a dado de baja Correctamente");

                dataGrid_Revistas.DataContext = null;
                dataGrid_Revistas.DataContext = Clase_Revista.listaDeRevista();
                txt_contenido.Text = "";
                txt_id_Buscar.Clear();
                txt_id.Text = "";
                txt_issn.Text = "";
                txt_nombre.Text = "";
                txt_razon.Text = "";
                btn_Bajar.IsEnabled = false;
                btn_Limpiar.IsEnabled = false;
                txt_razon.IsEnabled = false;
                dataGrid_Revistas.Visibility = System.Windows.Visibility.Visible;
                txt_id_Buscar.Visibility = System.Windows.Visibility.Visible;
                lbl_buscar.Visibility = System.Windows.Visibility.Visible;
            }
        }

        
    }
}
