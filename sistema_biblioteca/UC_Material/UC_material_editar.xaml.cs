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
    /// Lógica de interacción para UC_material_editar.xaml
    /// </summary>
    public partial class UC_material_editar : UserControl
    {
        public UC_material_editar()
        {
            InitializeComponent();
            datagrid_material.DataContext = Clase_Material.listaDeMaterial();
            contenedor.IsEnabled = false;
            btn_cancelar.IsEnabled = false;
            btn_editar.IsEnabled = false;
        }
        DataView mifiltro;
        private void buscar_material(object sender, KeyEventArgs e)
        {
            //datagrid_material.DataContext = Clase_Material.listaDeMaterialBusqueda(txt_id_Buscar.Text);

            DataSet resultados1 = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id)) AS ID ,titulo AS Titulo ,estado AS Estado FROM Libro_Revista WHERE tipo_item = 'Material'", ref resultados1, "Libro_Revista");
            this.mifiltro = ((DataTable)resultados1.Tables["Libro_Revista"]).DefaultView;
            this.datagrid_material.DataContext = mifiltro;

            datagrid_material.Visibility = System.Windows.Visibility.Visible;
            string salida_datos = "";
            string[] palabras_busqueda = this.txt_id_Buscar.Text.Split(' ');

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

        private void Doble_Click_Material(object sender, MouseButtonEventArgs e)
        {

            try
            {
                object item = datagrid_material.SelectedItem;
                txt_id.Text = (datagrid_material.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_nombre.Text = (datagrid_material.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                combo_estado_material.Text = (datagrid_material.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                datagrid_material.Visibility = System.Windows.Visibility.Hidden;
                lbl_id.Visibility = System.Windows.Visibility.Hidden;
                txt_id_Buscar.Visibility = System.Windows.Visibility.Hidden;
                contenedor.IsEnabled = true;
                btn_cancelar.IsEnabled = true;
                btn_editar.IsEnabled = true;
                txt_id.IsEnabled = false;
            }
            catch (Exception ex)
            {

            }


        }

        private void Cancelar_Editar_Material(object sender, RoutedEventArgs e)
        {
            txt_id.Text = "";
            txt_id_Buscar.Text = "";
            txt_nombre.Text = "";
            contenedor.IsEnabled = false;
            datagrid_material.Visibility = System.Windows.Visibility.Visible;
            lbl_id.Visibility = System.Windows.Visibility.Visible;
            txt_id_Buscar.Visibility = System.Windows.Visibility.Visible;
            btn_cancelar.IsEnabled = false;
            btn_editar.IsEnabled = false;
            combo_estado_material.Text = "";
            lb_baja.Content = "";

        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            bool pasar = true;


            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_nombre.Text))
            {
                lb_baja.Content = "*";
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
                string camposrevista = " estado = '" + combo_estado_material.Text + "', titulo = '" + txt_nombre.Text + "'";
                datos.actualizarEditar("Libro_Revista", camposrevista, " id= '" + Convert.ToInt32(txt_id.Text) + "'");

                MessageBox.Show("El Material se a editado Correctamente");

                datagrid_material.DataContext = null;
                datagrid_material.DataContext = Clase_Material.listaDeMaterial();
                txt_id.Text = "";
                txt_id.Text = "";
                txt_id_Buscar.Text = "";
                txt_nombre.Text = "";
                contenedor.IsEnabled = false;
                datagrid_material.Visibility = System.Windows.Visibility.Visible;
                lbl_id.Visibility = System.Windows.Visibility.Visible;
                txt_id_Buscar.Visibility = System.Windows.Visibility.Visible;
                btn_cancelar.IsEnabled = false;
                btn_editar.IsEnabled = false;
                combo_estado_material.Text = "";
                lb_baja.Content = "";

            }


        }
    }
}
