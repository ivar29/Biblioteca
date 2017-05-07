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

namespace Sistema_Biblioteca.UC_Revista
{
    /// <summary>
    /// Lógica de interacción para UC_revista_ingresar.xaml
    /// </summary>
    public partial class UC_revista_ingresar : UserControl
    {
        public UC_revista_ingresar()
        {
            InitializeComponent();
            fecha_fundacion.DisplayDateEnd = DateTime.Today;
        }

        private void button_Guardar(object sender, RoutedEventArgs e)
        {

            int seguir = 0;
            int seguir2 = 0;

                if (txt_nombre_revista.Text.Equals("") || string.IsNullOrWhiteSpace(txt_nombre_revista.Text))
                {

                    mensajeerror.Content = "*";
                    seguir = 0;




                }
                else
                {
                    mensajeerror.Content = "";
                    seguir = 1;
                }

                if (txt_stock_revista.Text.Equals("") || string.IsNullOrWhiteSpace(txt_stock_revista.Text))
                {

                    mensajeerror1.Content = "*";
                    seguir2 = 0;


                }
                else
                {
                    mensajeerror1.Content = "";
                    seguir2 = 1;
                }

                if (seguir == 1 && seguir2 == 1)
                {
                    string sqlFormattedDate = null;
                    DateTime? saber_fecha = fecha_fundacion.SelectedDate;
                    if (saber_fecha != null)
                    {
                        DateTime fecha_fund = Convert.ToDateTime(fecha_fundacion.SelectedDate.Value.Date.ToShortDateString());
                        sqlFormattedDate = fecha_fund.Date.ToString("yyyy-MM-dd");
                    }
                    int stock1 = Convert.ToInt16(txt_stock_revista.Text);
                    for (int i = 0; i < stock1; i++)
                    {
                        Clase_Revista.agregarRevista(new Clase_Revista("Revista", txt_nombre_revista.Text, txt_contenido_revista.Text, "Activo", 1, sqlFormattedDate, txt_issn.Text));
                    }
                    MessageBox.Show("REVISTA INGRESADA CORRECTAMENTE");
                    txt_nombre_revista.Text = "";
                    txt_contenido_revista.Text = "";
                    txt_stock_revista.Text = "";
                    txt_issn.Text = "";
                    fecha_fundacion.SelectedDate = null;
                }
        }

        private void txt_stock_revista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
            {

                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Cancelar_Ingreso_Revista(object sender, RoutedEventArgs e)
        {
            txt_nombre_revista.Text = "";
            txt_contenido_revista.Text = "";
            txt_stock_revista.Text = "";
            txt_issn.Text = "No tiene";
            fecha_fundacion.SelectedDate = null;
            mensajeerror.Content = "";
            mensajeerror1.Content = "";
        }

        private void txt_issn_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_issn.Text == "No tiene")
            {
                txt_issn.Clear();
            }
        }

        private void txt_issn_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_issn.Text.Equals("") || string.IsNullOrWhiteSpace(txt_issn.Text))
            {

                txt_issn.Text = "No tiene";

            }
        }

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
