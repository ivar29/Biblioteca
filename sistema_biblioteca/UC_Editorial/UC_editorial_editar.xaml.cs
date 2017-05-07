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

namespace Sistema_Biblioteca.UC_Editorial
{
    /// <summary>
    /// Lógica de interacción para UC_editorial_editar.xaml
    /// </summary>
    public partial class UC_editorial_editar : UserControl
    {
        public UC_editorial_editar()
        {
            InitializeComponent();
            dataGrid_Editoriales.DataContext = Clase_Editorial.lista_editorial();
            
        }

        private void dataGrid_Editoriales_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dataGrid_Editoriales.SelectedItem;
                txt_ID.Text = (dataGrid_Editoriales.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_nombre.Text = (dataGrid_Editoriales.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                dataGrid_Editoriales.Visibility = System.Windows.Visibility.Hidden;
                lb_buscar.Visibility = System.Windows.Visibility.Hidden;
                txt_buscar.Visibility = System.Windows.Visibility.Hidden;
                lb_id.IsEnabled = true;
                btn_guardar.IsEnabled = true;
                btn_cancelar.IsEnabled = true;
                txt_ID.IsEnabled = false;
                txt_nombre.IsEnabled = true;
            }
            catch (Exception ex)
            {

            }

        }
        DataView mifiltro;
        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            DataSet resultados = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id_editorial)) AS ID ,nombre_editorial AS EDITORIAL FROM Editorial where id_editorial<>1 ", ref resultados, "Editorial");
            this.mifiltro = ((DataTable)resultados.Tables["Editorial"]).DefaultView;
            this.dataGrid_Editoriales.DataContext = mifiltro;

            dataGrid_Editoriales.Visibility = System.Windows.Visibility.Visible;
            string salida_datos = "";
            string[] palabras_busqueda = this.txt_buscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(ID LIKE '%" + palabra + "%' OR EDITORIAL LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += "AND (ID LIKE '%" + palabra + "%' OR EDITORIAL LIKE '%" + palabra + "%')";
                }

            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            lb_id.IsEnabled = false;
            btn_guardar.IsEnabled = false;
            btn_cancelar.IsEnabled = false;
            txt_ID.IsEnabled = false;
            txt_nombre.IsEnabled = false;
            lb_error_nom.Content = "";

            txt_nombre.Clear();
            txt_ID.Clear();

            dataGrid_Editoriales.DataContext = null;
            dataGrid_Editoriales.DataContext = Clase_Editorial.lista_editorial();

            dataGrid_Editoriales.Visibility = System.Windows.Visibility.Visible;
            lb_buscar.Visibility = System.Windows.Visibility.Visible;
            txt_buscar.Visibility = System.Windows.Visibility.Visible;
            txt_buscar.Clear();
            

        }

        private void btn_guardar_Click_2(object sender, RoutedEventArgs e)
        {
            bool pasar = true;


            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_nombre.Text))
            {
                lb_error_nom.Content = "*";
                pasar = false;
            }
            else
            {
                lb_error_nom.Content = "";
                pasar = true;
            }


            if (pasar == true)
            {
                Clase_Datos datos = new Clase_Datos();
                string campos = "nombre_editorial = '" + txt_nombre.Text + "'";
                datos.actualizarEditar("Editorial", campos, " id_editorial= '" + Convert.ToInt32(txt_ID.Text) + "'");
                MessageBox.Show("Datos Editados Correctamente");
                lb_error_nom.Content = "";
                lb_id.IsEnabled = false;
                btn_guardar.IsEnabled = false;
                btn_cancelar.IsEnabled = false;
                txt_ID.IsEnabled = false;
                txt_nombre.IsEnabled = false;

                txt_nombre.Clear();
                txt_ID.Clear();

                dataGrid_Editoriales.DataContext = null;
                dataGrid_Editoriales.DataContext = Clase_Editorial.lista_editorial();

                dataGrid_Editoriales.Visibility = System.Windows.Visibility.Visible;
                lb_buscar.Visibility = System.Windows.Visibility.Visible;
                txt_buscar.Visibility = System.Windows.Visibility.Visible;
                txt_buscar.Clear();

            }
        }


    }
}
