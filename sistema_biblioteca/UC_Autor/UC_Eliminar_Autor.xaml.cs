using Sistema_Biblioteca.Clases;
using Sistema_Biblioteca.Clases.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Sistema_Biblioteca.UC_Eliminar
{
    /// <summary>
    /// Lógica de interacción para Eliminar_Autor.xaml
    /// </summary>
    public partial class Eliminar_Autor : UserControl
    {
        public Eliminar_Autor()
        {
            InitializeComponent();
            dataGrid_Autores.DataContext = Clase_Autor.lista_autores();
        }

   
        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            txt_id_Buscar.Visibility = System.Windows.Visibility.Visible;
            dataGrid_Autores.Visibility = System.Windows.Visibility.Visible;
            lb_Selecionar.Visibility = System.Windows.Visibility.Visible;
            btn_cancelar.IsEnabled = false;
            btn_guardar.IsEnabled = false;
    

            fecha_muerte.IsEnabled = false;
            fecha_nacimiento.IsEnabled = false;
            txt_id.IsEnabled = false;
            txt_nacionalidad.IsEnabled = false;
            txt_nombre_Ape.IsEnabled = false;
            fecha_muerte.SelectedDate = null;
            fecha_nacimiento.SelectedDate = null;

            txt_id.Clear();
            txt_nombre_Ape.Clear();
            txt_nacionalidad.Clear();
        }

        private void dataGrid_Autores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dataGrid_Autores.SelectedItem;

                DateTime? saber_fecha_naci = fecha_nacimiento.SelectedDate;
                DateTime? saber_fecha_mue = fecha_muerte.SelectedDate;
                if (saber_fecha_naci != null)
                {
                    fecha_nacimiento.DisplayDate = Convert.ToDateTime((dataGrid_Autores.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                }

                if (saber_fecha_mue != null)
                {
                    fecha_muerte.DisplayDate = Convert.ToDateTime((dataGrid_Autores.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                }
                fecha_muerte.Text = (dataGrid_Autores.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                fecha_nacimiento.Text = (dataGrid_Autores.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txt_id.Text = (dataGrid_Autores.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_nombre_Ape.Text = (dataGrid_Autores.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                txt_nacionalidad.Text = (dataGrid_Autores.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

                txt_id_Buscar.Visibility = System.Windows.Visibility.Hidden;
                dataGrid_Autores.Visibility = System.Windows.Visibility.Hidden;
                lb_Selecionar.Visibility = System.Windows.Visibility.Hidden;
                btn_cancelar.IsEnabled = true;
                btn_guardar.IsEnabled = true;

                fecha_muerte.IsEnabled = true;
                fecha_nacimiento.IsEnabled = true;
                txt_nacionalidad.IsEnabled = true;
                txt_nombre_Ape.IsEnabled = true;

            }
            catch (Exception ex)
            {

            }
        }

        private void busqueda_autor(object sender, KeyEventArgs e)
        {
            try
            {
                object item = dataGrid_Autores.SelectedItem;

                DateTime? saber_fecha_naci = fecha_nacimiento.SelectedDate;
                DateTime? saber_fecha_mue = fecha_muerte.SelectedDate;
                if (saber_fecha_naci != null)
                {
                    fecha_nacimiento.DisplayDate = Convert.ToDateTime((dataGrid_Autores.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                }

                if (saber_fecha_mue != null)
                {
                    fecha_muerte.DisplayDate = Convert.ToDateTime((dataGrid_Autores.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                }
                fecha_muerte.Text = (dataGrid_Autores.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                fecha_nacimiento.Text = (dataGrid_Autores.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txt_id.Text = (dataGrid_Autores.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_nombre_Ape.Text = (dataGrid_Autores.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                txt_nacionalidad.Text = (dataGrid_Autores.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

                txt_id_Buscar.Visibility = System.Windows.Visibility.Hidden;
                dataGrid_Autores.Visibility = System.Windows.Visibility.Hidden;
                lb_Selecionar.Visibility = System.Windows.Visibility.Hidden;
                btn_cancelar.IsEnabled = true;
                btn_guardar.IsEnabled = true;

                fecha_muerte.IsEnabled = true;
                fecha_nacimiento.IsEnabled = true;
                txt_nacionalidad.IsEnabled = true;
                txt_nombre_Ape.IsEnabled = true;

            }
            catch (Exception ex)
            {

            }
        }

        DataView mifiltro;

     

        private void busqueda(object sender, KeyEventArgs e)
        {
            dataGrid_Autores.Visibility = System.Windows.Visibility.Visible;
            DataSet resultados = new DataSet();
            Clase_Busqueda_Sensitiva.Buscar_Sensitiva("SELECT (convert(nvarchar(4), id_autor)) AS ID ,nombre_autor AS Autor,fecha_nacimiento AS Nacimiento, fecha_muerte AS Muerte ,nacionalidad AS Nacionalidad FROM Autor where id_autor<>1 ", ref resultados, "Autor");
            this.mifiltro = ((DataTable)resultados.Tables["Autor"]).DefaultView;
            this.dataGrid_Autores.DataContext = mifiltro;


            string salida_datos = "";
            string[] palabras_busqueda = this.txt_id_Buscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(ID LIKE '%" + palabra + "%' OR Autor LIKE '%" + palabra + "%' OR  Nacimiento LIKE '%" + palabra + "%' OR Muerte LIKE '%" + palabra + "%' OR Nacionalidad LIKE '%" + palabra + "%')";
                }
                else
                {
                    salida_datos += "AND (ID LIKE '%" + palabra + "%' OR Autor LIKE '%" + palabra + "%' OR  Nacimiento LIKE '%" + palabra + "%' OR Muerte LIKE '%" + palabra + "%' OR Nacionalidad LIKE '%" + palabra + "%')";
                }

            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {

            bool pasar = true;

            MessageBoxResult respuesta = System.Windows.MessageBox.Show("¿Eliminar Datos?", "ELIMINAR", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.No)
            {
                pasar = false;
            }
            if (pasar == true)
            {
                Clase_Datos datos = new Clase_Datos();
                if (datos.eliminar("Autor", "id_autor ='" + txt_id.Text + "'"))
                {
                    MessageBox.Show("Autor eliminado");

                    txt_id_Buscar.Visibility = System.Windows.Visibility.Visible;
                    dataGrid_Autores.Visibility = System.Windows.Visibility.Visible;
                    lb_Selecionar.Visibility = System.Windows.Visibility.Visible;
                    btn_cancelar.IsEnabled = false;
                    btn_guardar.IsEnabled = false;


                    fecha_muerte.IsEnabled = false;
                    fecha_nacimiento.IsEnabled = false;
                    txt_id.IsEnabled = false;
                    txt_nacionalidad.IsEnabled = false;
                    txt_nombre_Ape.IsEnabled = false;
                    fecha_muerte.SelectedDate = null;
                    fecha_nacimiento.SelectedDate = null;

                    txt_id.Clear();
                    txt_nombre_Ape.Clear();
                    txt_nacionalidad.Clear();
                    dataGrid_Autores.DataContext = Clase_Autor.lista_autores();
                }

            }

        }
    }
}
