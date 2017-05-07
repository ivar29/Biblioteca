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

namespace Sistema_Biblioteca.UC_Autor
{
    /// <summary>
    /// Lógica de interacción para UC_autor_ingresar.xaml
    /// </summary>
    public partial class UC_autor_ingresar : UserControl
    {
        public UC_autor_ingresar()
        {
            InitializeComponent();
            fecha_nacimiento.DisplayDateEnd = DateTime.Today;
            fecha_muerte.DisplayDateEnd = DateTime.Today;
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            //string sqlFormattedDate=null;
            //string sqlFormattedDate2=null;
            //DateTime? saber_nac = fecha_nacimiento.SelectedDate;
            //DateTime? saber_muert = fecha_muerte.SelectedDate;
            //if (saber_nac != null)
            //{
            //    DateTime fecha_nac = Convert.ToDateTime(fecha_nacimiento.SelectedDate.Value.Date.ToShortDateString());
            //    DateTime fecha_muert = Convert.ToDateTime(fecha_nacimiento.SelectedDate.Value.Date.ToShortDateString());
            //    sqlFormattedDate = fecha_nac.Date.ToString("yyyy-MM-dd");
            //    sqlFormattedDate2 = fecha_nac.Date.ToString("yyyy-MM-dd");

            //}
            //Clase_Autor.agregar_autor(new Clase_Autor(txt_nombre.Text, sqlFormattedDate, sqlFormattedDate2, txt_nacionalidad.Text));

            //txt_nombre.Text = "";
            //txt_nacionalidad.Text = "";
            int seguir = 0;
            string sqlFormattedDate = null;
            string sqlFormattedDate2 = null;
            DateTime? saber_nac = fecha_nacimiento.SelectedDate;
            DateTime? saber_muert = fecha_muerte.SelectedDate;
            if (saber_nac != null)
            {
                DateTime fecha_nac = Convert.ToDateTime(fecha_nacimiento.SelectedDate.Value.Date.ToShortDateString());
                sqlFormattedDate = fecha_nac.Date.ToString("yyyy-MM-dd");
            }

            if (saber_muert != null)
            {
                DateTime fecha_muert = Convert.ToDateTime(fecha_muerte.SelectedDate.Value.Date.ToShortDateString());
                sqlFormattedDate2 = fecha_muert.Date.ToString("yyyy-MM-dd");
            }


            if (string.IsNullOrWhiteSpace(txt_nombre.Text) || txt_nombre.Text.Equals(""))
            {

                mensajeerror.Content = "*Ingrese un nombre ";
                seguir = 1;

            }
            else
            {
                mensajeerror.Content = "";
                seguir = 0;
            }





            if (seguir == 0)
            {




                Clase_Autor.agregar_autor(new Clase_Autor(txt_nombre.Text, sqlFormattedDate, sqlFormattedDate2, txt_nacionalidad.Text));

                MessageBox.Show("AUTOR INGRESADO CORRECTAMENTE");
                mensajeerror.Content = "";

                txt_nombre.Text = "";
                txt_nacionalidad.Text = "";
                fecha_nacimiento.SelectedDate = null;
                fecha_muerte.SelectedDate = null;
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            mensajeerror.Content = "";
            txt_nombre.Text = "";
            txt_nacionalidad.Text = "";
            fecha_nacimiento.SelectedDate = null;
            fecha_muerte.SelectedDate = null;
            }
        }
    }





