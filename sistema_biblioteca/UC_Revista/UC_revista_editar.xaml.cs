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
    /// Lógica de interacción para UC_revista_editar.xaml
    /// </summary>
    public partial class UC_revista_editar : UserControl
    {
        public UC_revista_editar()
        {
            InitializeComponent();
            datagrid_revista.DataContext = Clase_Revista.listaDeRevista();
            fecha_Fundacion.DisplayDateEnd = DateTime.Today;
            contenedor.IsEnabled = false;
            

        }
        DataView mifiltro;

        private void busqueda_revista(object sender, KeyEventArgs e)
        {
            //datagrid_revista.DataContext = Clase_Revista.listaDeRevistaBusqueda(txt_id_revista_buscar.Text);

            DataSet resultados = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID, titulo AS Titulo, fecha_fundacion AS FechaFundacion, issn_revista AS ISSN , estado AS Estado, contenido AS Contenido FROM Libro_Revista WHERE tipo_item = 'Revista'", ref resultados, "Libro_Revista");
            this.mifiltro = ((DataTable)resultados.Tables["Libro_Revista"]).DefaultView;
            this.datagrid_revista.DataContext = mifiltro;

            datagrid_revista.Visibility = System.Windows.Visibility.Visible;
            string salida_datos = "";
            string[] palabras_busqueda = this.txt_id_revista_buscar.Text.Split(' ');

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

        private void Doble_Click_Revista(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = datagrid_revista.SelectedItem;
                DateTime? saber_fecha = fecha_Fundacion.SelectedDate;
                if (saber_fecha != null)
                {
                    fecha_Fundacion.DisplayDate = Convert.ToDateTime((datagrid_revista.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);

                }

                txt_id.Text = (datagrid_revista.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_nombre_editar.Text = (datagrid_revista.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                fecha_Fundacion.Text = (datagrid_revista.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txt_issn_editar.Text = (datagrid_revista.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                cb_estado_revista.Text = (datagrid_revista.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                txt_contenido_editar_Copy.Text = (datagrid_revista.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                datagrid_revista.Visibility = System.Windows.Visibility.Hidden;
                grb_id.Visibility = System.Windows.Visibility.Hidden;
                lbl_Revista.Visibility = System.Windows.Visibility.Hidden;
                txt_id_revista_buscar.Visibility = System.Windows.Visibility.Hidden;
                contenedor.IsEnabled = true;

            }
            catch (Exception ex)
            {

            }
        }

        private void Cancelar_Form_Editar_Revist(object sender, RoutedEventArgs e)
        {
            txt_contenido_editar_Copy.Text = "";
            txt_id.Text = "";
            txt_id_revista_buscar.Text = "";
            txt_issn_editar.Text = "";
            txt_nombre_editar.Text = "";
            fecha_Fundacion.SelectedDate = null;
            cb_estado_revista.Text = "";
            datagrid_revista.Visibility = System.Windows.Visibility.Visible;
            grb_id.Visibility = System.Windows.Visibility.Visible;
            lbl_Revista.Visibility = System.Windows.Visibility.Visible;
            txt_id_revista_buscar.Visibility = System.Windows.Visibility.Visible;
            contenedor.IsEnabled = false;
            mensajeerror.Content = "";

        }


        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            bool pasar = true;


            if (string.IsNullOrEmpty(txt_nombre_editar.Text) || string.IsNullOrWhiteSpace(txt_nombre_editar.Text))
            {
                mensajeerror.Content = "*";
                pasar = false;
            }
            else
            {
                mensajeerror.Content = "";
                pasar = true;
            }


            if (pasar == true)
            {

                Clase_Datos datos = new Clase_Datos();
                string sqlFormattedDate = null;

                DateTime? saber_fecha = fecha_Fundacion.SelectedDate;
                if (saber_fecha != null)
                {
                    DateTime fecha_fund = Convert.ToDateTime(fecha_Fundacion.SelectedDate.Value.Date.ToShortDateString());
                    sqlFormattedDate = fecha_fund.Date.ToString("yyyy-MM-dd");
                }

                string campos = "titulo = '" + txt_nombre_editar.Text + "', fecha_fundacion = '" + sqlFormattedDate + "', issn_revista = '" + txt_issn_editar.Text + "' , estado = '" + cb_estado_revista.Text + "', contenido = '" + txt_contenido_editar_Copy.Text + "'";
                datos.actualizarEditar("Libro_Revista", campos, " id='" + Convert.ToInt32(txt_id.Text) + "'");
                MessageBox.Show("Datos Editados Correctamente");

                datagrid_revista.DataContext = null;
                datagrid_revista.DataContext = Clase_Revista.listaDeRevista();
                txt_contenido_editar_Copy.Text = "";
                txt_id.Text = "";
                txt_id_revista_buscar.Text = "";
                txt_issn_editar.Text = "";
                txt_nombre_editar.Text = "";
                fecha_Fundacion.SelectedDate = null;
                cb_estado_revista.Text = "";
                datagrid_revista.Visibility = System.Windows.Visibility.Visible;
                grb_id.Visibility = System.Windows.Visibility.Visible;
                lbl_Revista.Visibility = System.Windows.Visibility.Visible;
                txt_id_revista_buscar.Visibility = System.Windows.Visibility.Visible;
                contenedor.IsEnabled = false;
                mensajeerror.Content = "";

            }

        }


        private void txt_issn_editar_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_issn_editar.Text == "No tiene")
            {
                txt_issn_editar.Clear();
            }
        }

        private void txt_issn_editar_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_issn_editar.Text.Equals("") || string.IsNullOrWhiteSpace(txt_issn_editar.Text))
            {

                txt_issn_editar.Text = "No tiene";

            }
        }

      
    }
}
