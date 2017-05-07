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

namespace Sistema_Biblioteca.UC_Material
{
    /// <summary>
    /// Lógica de interacción para UC_material_bajar.xaml
    /// </summary>
    public partial class UC_material_bajar : UserControl
    {
        public UC_material_bajar()
        {
            InitializeComponent();
           dataGrid_Material.DataContext = Clase_Material.listaDeMaterial();
           contador.IsEnabled = false;
           lbl_Dar_Baja_Razon.IsEnabled = false;
           txt_razon_Copy.IsEnabled = false;
           btn_Bajar.IsEnabled = false;
           btn_Cancelar.IsEnabled = false;
          
        }

        private void Doble_Click_Material_Bajar(object sender, MouseButtonEventArgs e)
        {
            object item = dataGrid_Material.SelectedItem;
            cb_Estado.Text = (dataGrid_Material.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            txt_id.Text = (dataGrid_Material.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            txt_nombre.Text = (dataGrid_Material.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

            if (cb_Estado.Text != "Baja")
            {

                txt_id.IsEnabled = false;
                txt_nombre.IsEnabled = false;
                cb_Estado.IsEnabled = false;
                btn_Bajar.IsEnabled = true;
                btn_Cancelar.IsEnabled = true;
                lbl_Dar_Baja_Razon.IsEnabled = true;
                txt_razon_Copy.IsEnabled = true;


                dataGrid_Material.Visibility = System.Windows.Visibility.Hidden;
                txt_Id_Buscar.Visibility = System.Windows.Visibility.Hidden;
                lbl_darBaja.Visibility = System.Windows.Visibility.Hidden;
                grp_buscar.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("El Material seleccionado ya esta dado de baja");
                txt_Id_Buscar.Text = "";
                txt_id.Text = "";
                txt_nombre.Text = "";
                txt_razon_Copy.Text = "";
                cb_Estado.Text = "";
            }
       }

        DataView mifiltro;

        private void Buscar_Material(object sender, KeyEventArgs e)
        {
            //dataGrid_Material.DataContext = Clase_Material.listaDeMaterialBusqueda(txt_Id_Buscar.Text);
            DataSet resultados1 = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID , titulo AS Titulo ,estado AS Estado FROM Libro_Revista WHERE tipo_item = 'Material'", ref resultados1, "Libro_Revista");
            this.mifiltro = ((DataTable)resultados1.Tables["Libro_Revista"]).DefaultView;
            this.dataGrid_Material.DataContext = mifiltro;

            dataGrid_Material.Visibility = System.Windows.Visibility.Visible;
            string salida_datos = "";
            string[] palabras_busqueda = this.txt_Id_Buscar.Text.Split(' ');

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

        private void Cancelar_Baja_Material(object sender, RoutedEventArgs e)
        {
            txt_Id_Buscar.Text = "";
            txt_id.Text = "";
            txt_nombre.Text = "";
            txt_razon_Copy.Text = "";
            cb_Estado.Text = "";
            lbl_Dar_Baja_Razon.IsEnabled = false;
            txt_razon_Copy.IsEnabled = false;
            btn_Bajar.IsEnabled = false;
            btn_Cancelar.IsEnabled = false;
            dataGrid_Material.Visibility = System.Windows.Visibility.Visible;
            txt_Id_Buscar.Visibility = System.Windows.Visibility.Visible;
            lbl_darBaja.Visibility = System.Windows.Visibility.Visible;
            grp_buscar.Visibility = System.Windows.Visibility.Visible;
            lb_baja.Content = "";
            

        }

        private void btn_Bajar_Click(object sender, RoutedEventArgs e)
        {
            bool pasar = true;


            if (string.IsNullOrEmpty(cb_Estado.Text) || string.IsNullOrWhiteSpace(txt_razon_Copy.Text))
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
                
                Clase_Baja.agregarBaja(new Clase_Baja(DateTime.Now.ToString(), txt_razon_Copy.Text, Convert.ToInt32(txt_id.Text)));

                MessageBox.Show("El Material se a dado de baja Correctamente");

                dataGrid_Material.DataContext = null;
                dataGrid_Material.DataContext = Clase_Material.listaDeMaterial();
                txt_Id_Buscar.Text = "";
                txt_id.Text = "";
                txt_nombre.Text = "";
                txt_razon_Copy.Text = "";
                cb_Estado.Text = "";
                lbl_Dar_Baja_Razon.IsEnabled = false;
                txt_razon_Copy.IsEnabled = false;
                btn_Bajar.IsEnabled = false;
                btn_Cancelar.IsEnabled = false;
                dataGrid_Material.Visibility = System.Windows.Visibility.Visible;
                txt_Id_Buscar.Visibility = System.Windows.Visibility.Visible;
                lbl_darBaja.Visibility = System.Windows.Visibility.Visible;
                grp_buscar.Visibility = System.Windows.Visibility.Visible;
                
            }
        }
    }
}
