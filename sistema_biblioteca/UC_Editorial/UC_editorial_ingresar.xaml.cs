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

namespace Sistema_Biblioteca.UC_Editorial
{
    /// <summary>
    /// Lógica de interacción para UC_editorial_ingresar.xaml
    /// </summary>
    public partial class UC_editorial_ingresar : UserControl
    {
        public UC_editorial_ingresar()
        {
            InitializeComponent();
        }

        private void button_guardar_editorial(object sender, RoutedEventArgs e)
        {
            if (txt_editorial.Text.Equals("") || string.IsNullOrWhiteSpace(txt_editorial.Text))
            {

                mensajeerror.Content = "*Ingrese nombre editorial";




            }
            else
            {


                Clase_Editorial.agregar_editorial(new Clase_Editorial(txt_editorial.Text));
                MessageBox.Show("EDITORIAL INGRESADA CORRECTAMENTE");
                mensajeerror.Content = "";
                txt_editorial.Text = "";


            }

        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            mensajeerror.Content = "";
            txt_editorial.Text = "";
        }
    }
}
