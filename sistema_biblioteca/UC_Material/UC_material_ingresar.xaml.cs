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

namespace Sistema_Biblioteca.UC_Material
{
    /// <summary>
    /// Lógica de interacción para UC_material_ingresar.xaml
    /// </summary>
    public partial class UC_material_ingresar : UserControl
    {
        public UC_material_ingresar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (txt_nombre.Text.Equals("") || string.IsNullOrWhiteSpace(txt_nombre.Text))
            {

                mensajeerror.Content = "*Ingrese nombre de material";





            }
            else
            {
                Clase_Material.agregarMaterial(new Clase_Material(txt_nombre.Text, "Activo", 1, "Material"));
                MessageBox.Show("Material Ingresado Correctamente");
                txt_nombre.Text = "";
                mensajeerror.Content = "";
            }
        }

        private void Cancelar_Material(object sender, RoutedEventArgs e)
        {
            txt_nombre.Text = "";
            mensajeerror.Content = "";
        }
    }
}
