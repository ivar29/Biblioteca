using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using Sistema_Biblioteca.Clases;
using Sistema_Biblioteca.UC_Autor;
using Sistema_Biblioteca.UC_Editorial;
using Sistema_Biblioteca.Clases.Conexion;

namespace Sistema_Biblioteca.UC_Libro
{
    /// <summary>
    /// Lógica de interacción para UC_libro_ingresar.xaml
    /// </summary>
    public partial class UC_libro_ingresar : UserControl
    {
        public UC_libro_ingresar()
        {
            InitializeComponent();
            Clase_Datos datos = new Clase_Datos();
            datos.llenar_combobox_editorial("Editorial", "id_editorial, nombre_editorial", combobox_editorial);
            datos.llenar_combobox_autor("Autor", "id_autor, nombre_autor", combobox_autor);
            combobox_autor.SelectedIndex = 0;
            combobox_editorial.SelectedIndex = 0;
            user_control.Visibility = System.Windows.Visibility.Hidden;
            user_control_autor.Visibility = System.Windows.Visibility.Hidden;
            fecha_nacimiento.DisplayDateEnd = DateTime.Today;
            fecha_muerte.DisplayDateEnd = DateTime.Today;
            combobox_idioma.Text = "Español";
            combobox_tipolector.Text = "Alumno";
            txt_otro_autor.IsEnabled = false;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            user_control.Visibility = System.Windows.Visibility.Hidden;
            user_control_autor.Visibility = System.Windows.Visibility.Visible;
            contenedor1.IsEnabled = false;
            btn_Nueva_Editorial.IsEnabled = false;
            btn_Nuevo_Autor.IsEnabled = false;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            user_control.Visibility = System.Windows.Visibility.Visible;
            user_control_autor.Visibility = System.Windows.Visibility.Hidden;



            contenedor1.IsEnabled = false;
            btn_Nueva_Editorial.IsEnabled = false;
            btn_Nuevo_Autor.IsEnabled = false;
          
            user_control_autor.Visibility = System.Windows.Visibility.Hidden;
                
            
        }

        private void recarga_combobox_editorial(object sender, EventArgs e)
        {
            int index = combobox_editorial.Items.IndexOf(combobox_editorial.SelectedItem);
            Clase_Datos datos = new Clase_Datos();
            datos.llenar_combobox_editorial("Editorial", "id_editorial, nombre_editorial", combobox_editorial);
           combobox_editorial.SelectedIndex = index;

        }

        private void recarga_combobox_autor(object sender, EventArgs e)
        {
            
            int index = combobox_autor.Items.IndexOf(combobox_autor.SelectedItem);
            //int indice = combobox_autor.SelectedIndex;
            Clase_Datos datos = new Clase_Datos();
            datos.llenar_combobox_autor("Autor", "id_autor, nombre_autor", combobox_autor);
            //combobox_autor.SelectedIndex = indice;

            combobox_autor.SelectedIndex = index;
        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            //Clase_Libro.agregarLibro(new Clase_Libro("Libro",txt_titulo_libro.Text,txt_idioma_libro.Text, txt_isbn.Text, txt_edicion_libro.Text, txt_volumen_libro.Text, txt_tomo_libro.Text, txt_tipo_lector.Text, combobox_autor.Text, txt_contenido_libro.Text, "Activo", combobox_editorial.Text));
            int seguir;

            if (txt_titulo_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_titulo_libro.Text))
            {

                mensajeerror.Content = "*";
                seguir = 0;




            }
            else
            {
                mensajeerror.Content = "";
                seguir = 1;
            }

            if (txt_sotck_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_sotck_libro.Text))
            {

                mensajeerror1.Content = "*";
                seguir = 0;


            }
            else
            {
                mensajeerror1.Content = "";
                seguir = 1;
            }

            if (seguir == 1)
            {



                int stock1 = Convert.ToInt16(txt_sotck_libro.Text);
                for (int i = 0; i < stock1; i++)
                {
                    Clase_Libro.agregarLibro(new Clase_Libro("Libro", txt_titulo_libro.Text, combobox_idioma.Text, txt_isbn.Text, txt_edicion_libro.Text, txt_volumen_libro.Text, txt_tomo_libro.Text, combobox_tipolector.Text, combobox_autor.Text, txt_otro_autor.Text, txt_contenido_libro.Text, 1, combobox_editorial.Text, "Activo"));

                }
                MessageBox.Show("Libro/s ingresados correctamente");
                txt_titulo_libro.Text = "";
                combobox_autor.Text = "";
                txt_otro_autor.Text = "No tiene";
                txt_isbn.Text = "No tiene";
                txt_edicion_libro.Text = "No tiene";
                txt_volumen_libro.Text = "No tiene";
                txt_tomo_libro.Text = "No tiene";
                combobox_idioma.Text = "Español";
                combobox_tipolector.Text = "Alumno";
                combobox_autor.Text = "*Anonimo";
                combobox_editorial.Text = "*Anonimo";
                
                txt_contenido_libro.Text = "";
                txt_sotck_libro.Text = "";

            }

        }


        private void txt_sotck_libro_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_guardar2_Click(object sender, RoutedEventArgs e)
        {
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

                mensajeerror3.Content = "*Ingrese un nombre ";
                seguir = 1;

            }
            else
            {
                mensajeerror3.Content = "";
                seguir = 0;
            }





            if (seguir == 0)
            {




                Clase_Autor.agregar_autor(new Clase_Autor(txt_nombre.Text, sqlFormattedDate, sqlFormattedDate2, txt_nacionalidad.Text));

                MessageBox.Show("AUTOR INGRESADO CORRECTAMENTE");
                mensajeerror.Content = "";

                txt_nombre.Text = "";
                txt_nacionalidad.Text = "";

                contenedor1.IsEnabled = true;
                btn_Nuevo_Autor.IsEnabled = true;
                btn_Nueva_Editorial.IsEnabled = true;
                
                user_control_autor.Visibility = System.Windows.Visibility.Hidden;
            }
                



            }

        private void Guardar_Editorial(object sender, RoutedEventArgs e)
        {
            if (txt_editorial.Text.Equals("") || string.IsNullOrWhiteSpace(txt_editorial.Text))
            {

                mensajeerror2.Content = "*Ingrese nombre editorial";




            }
            else
            {
                

                Clase_Editorial.agregar_editorial(new Clase_Editorial(txt_editorial.Text));
                MessageBox.Show("EDITORIAL INGRESADA CORRECTAMENTE");
                mensajeerror2.Content = "";
                txt_editorial.Text = "";
                contenedor1.IsEnabled = true;
                btn_Nuevo_Autor.IsEnabled = true;
                btn_Nueva_Editorial.IsEnabled = true;

                user_control_autor.Visibility = System.Windows.Visibility.Hidden;
                user_control.Visibility = System.Windows.Visibility.Hidden;
        }
            
        }

        private void Limpiar_Form_ingreso(object sender, RoutedEventArgs e)
        {
            txt_titulo_libro.Text = "";

            txt_otro_autor.Text = "No tiene";
            txt_isbn.Text = "No tiene";
            txt_edicion_libro.Text = "No tiene";
            txt_volumen_libro.Text = "No tiene";
            txt_tomo_libro.Text = "No tiene";
   
            combobox_idioma.Text = "Español";
            combobox_tipolector.Text = "Alumno";
            combobox_autor.Text = "*Anonimo";
            combobox_editorial.Text = "*Anonimo";
           
            txt_contenido_libro.Text = "";
            txt_sotck_libro.Text = "";
            mensajeerror.Content = "";
            mensajeerror1.Content = "";
        }

        private void Cancelar_Form_Autor_Libro(object sender, RoutedEventArgs e)
        {
            mensajeerror2.Content = "";
            mensajeerror3.Content = "";
            txt_nombre.Text = "";
            txt_nacionalidad.Text = "";
            fecha_muerte.SelectedDate = null;
            fecha_nacimiento.SelectedDate = null;
            contenedor1.IsEnabled = true;
            btn_Nuevo_Autor.IsEnabled = true;
            btn_Nueva_Editorial.IsEnabled = true;
            user_control_autor.Visibility = System.Windows.Visibility.Hidden;
            user_control.Visibility = System.Windows.Visibility.Hidden;
            
        }

        private void Cancelar_Form_Editorial(object sender, RoutedEventArgs e){

            mensajeerror2.Content = "";
            mensajeerror3.Content = "";
     
        
            
            txt_editorial.Text="";
            contenedor1.IsEnabled = true;
            btn_Nuevo_Autor.IsEnabled = true;
            btn_Nueva_Editorial.IsEnabled = true;
            user_control_autor.Visibility = System.Windows.Visibility.Hidden;
            user_control.Visibility = System.Windows.Visibility.Hidden;



        }

        private void txt_isbn_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (txt_isbn.Text == "No tiene")
            {
                txt_isbn.Clear();
            }
            
        }

        private void txt_isbn_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //if (txt_isbn.Text == "")
            //{
            //    txt_isbn.Text = "No tiene";
            //}
            if (txt_isbn.Text.Equals("") || string.IsNullOrWhiteSpace(txt_isbn.Text))
            {

                txt_isbn.Text = "No tiene";

            }

           


        }

        private void txt_otro_autor_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            if (txt_otro_autor.Text.Equals("") || string.IsNullOrWhiteSpace(txt_otro_autor.Text))
            {

                txt_otro_autor.Text = "No tiene";


            }

        }

        private void txt_otro_autor_KeyDown(object sender, KeyEventArgs e)
        {

            if (txt_otro_autor.Text == "No tiene")
            {
                txt_otro_autor.Clear();
            }
           
        }

        private void txt_edicion_libro_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_edicion_libro.Text == "No tiene")
            {
                txt_edicion_libro.Clear();
            }
        }

        private void txt_edicion_libro_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            if (txt_edicion_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_edicion_libro.Text))
            {

                txt_edicion_libro.Text = "No tiene";


            }
        }

        private void txt_tomo_libro_KeyDown(object sender, KeyEventArgs e)
        {

            if (txt_tomo_libro.Text == "No tiene")
            {
                txt_tomo_libro.Clear();
            }
        }

        private void txt_tomo_libro_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_tomo_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_tomo_libro.Text))
            {

                txt_tomo_libro.Text = "No tiene";


            }
        }

        private void txt_volumen_libro_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_volumen_libro.Text == "No tiene")
            {
                txt_volumen_libro.Clear();
            }
        }

        private void txt_volumen_libro_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_volumen_libro.Text.Equals("") || string.IsNullOrWhiteSpace(txt_volumen_libro.Text))
            {

                txt_volumen_libro.Text = "No tiene";

            }
        }

        private void combobox_autor_DropDownClosed(object sender, EventArgs e)
        {
            //No deberia poder rellenarse el campo "otro autor" si el autor es Anonimo... por ende:
            if (combobox_autor.Text == "*Anonimo")
            {
                txt_otro_autor.IsEnabled = false;
            }
            else
            {
                txt_otro_autor.IsEnabled = true;
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



        //private void btn_guardar_Click_1(object sender, RoutedEventArgs e)
        //{

        //        int añopublic = Convert.ToInt32(txt_ano_publicacion.Text);
        //        int cantPag = Convert.ToInt32(txt_cant_pag.Text);
        //        int stock = Convert.ToInt32(txt_sotck_libro.Text);

        //        Clase_Libro.agregarLibro(new Clase_Libro(txt_titulo_libro.Text, txt_pais_edicion.Text, añopublic, cantPag, txt_isbn.Text, txt_indice_libro.Text, txt_edicion_libro.Text, txt_volumen_libro.Text, txt_tomo_libro.Text, txt_clasificacion_libro.Text, txt_autor_libro.Text, txt_otro_autor.Text, txt_notas.Text, txt_estado_libro.Text, stock, txt_tipo_libro.Text));

        //        txt_titulo_libro.Clear();
        //        txt_pais_edicion.Clear();
        //        txt_ano_publicacion.Clear();
        //        txt_cant_pag.Clear();
        //        txt_isbn.Clear();

        //        txt_indice_libro.Clear();
        //        txt_edicion_libro.Clear();
        //        txt_volumen_libro.Clear();
        //        txt_tomo_libro.Clear();
        //        txt_clasificacion_libro.Clear();

        //        txt_otro_autor.Clear();
        //        txt_estado_libro.Clear();
        //        txt_sotck_libro.Clear();
        //        txt_tipo_libro.Clear();
        //        txt_notas.Clear();
        //        txt_tipo_libro.Clear();
        //        txt_autor_libro.Clear();


        //}
    }
}
