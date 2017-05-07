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
using System.Windows.Controls.Ribbon;
using Sistema_Biblioteca.UC_Libro;
using Sistema_Biblioteca.UC_Revista;
using Sistema_Biblioteca.UC_Autor;
using Sistema_Biblioteca.UC_Editorial;
using Sistema_Biblioteca.UC_Material;
using Sistema_Biblioteca.UC_Eliminar;
using Sistema_Biblioteca.UC_busqueda_Sensitiva;
using Sistema_Biblioteca.Clases.Conexion;
using Sistema_Biblioteca.UC_Informe;

namespace Sistema_Biblioteca
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Clase_Datos con = new Clase_Datos();
            con.cn.Open();
            con.cn.Close();
              
        }

        private void Ingresar_libro(object sender, RoutedEventArgs e)
        {
            //Ingresar Libro
            canvas_contenedor.Children.Clear();


            UC_libro_ingresar Form_Libro_Ingreso = new UC_libro_ingresar();
            canvas_contenedor.Children.Add(Form_Libro_Ingreso);


        }

        private void Ingresar_revista(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_revista_ingresar Form_Revista_Ingreso = new UC_revista_ingresar();
            canvas_contenedor.Children.Add(Form_Revista_Ingreso);
            //Ingresar Revista
        }

        private void Editar_libro(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_libro_editar Form_Libro_Editar = new UC_libro_editar();
            canvas_contenedor.Children.Add(Form_Libro_Editar);
            //Editar Libro
        }

        private void Bajar_Libro(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_libro_baja Form_Libro_baja = new UC_libro_baja();
            canvas_contenedor.Children.Add(Form_Libro_baja);
        }

        private void Editar_Revista(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_revista_editar Form_Revista_Editar = new UC_revista_editar();
            canvas_contenedor.Children.Add(Form_Revista_Editar);
        }

        private void Ingresar_Autor(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_autor_ingresar Form_autor_ingresar = new UC_autor_ingresar();
            canvas_contenedor.Children.Add(Form_autor_ingresar);

        }

        private void Editar_Autor(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_autor_editar Form_autor_editar = new UC_autor_editar();
            canvas_contenedor.Children.Add(Form_autor_editar);

        }
        
        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_libro_ingresar Form_libro_ingresar = new UC_libro_ingresar();
            canvas_contenedor.Children.Add(Form_libro_ingresar);

        }
        private void button_Ingresar_Material(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_material_ingresar Form_material_ingresar = new UC_material_ingresar();
            canvas_contenedor.Children.Add(Form_material_ingresar);
        }

        private void button_Editar_Material(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_material_editar Form_material_editar = new UC_material_editar();
            canvas_contenedor.Children.Add(Form_material_editar);
        }

        private void buttton_Baja_Material(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_material_bajar Form_material_bajar = new UC_material_bajar();
            canvas_contenedor.Children.Add(Form_material_bajar);
        }

        private void button_Ingresar_Autor(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_autor_ingresar Form_autor_ingresar = new UC_autor_ingresar();
            canvas_contenedor.Children.Add(Form_autor_ingresar);
        }

        private void button_Editar_Autor(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_autor_editar Form_autor_editar = new UC_autor_editar();
            canvas_contenedor.Children.Add(Form_autor_editar);
        }

        private void button_Ingresar_Editorial(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_editorial_ingresar form_editorial_igresar = new UC_editorial_ingresar();
            canvas_contenedor.Children.Add(form_editorial_igresar);
        }

        private void button_Editar_Editorial(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_editorial_editar form_editorial_editar = new UC_editorial_editar();
            canvas_contenedor.Children.Add(form_editorial_editar);
        }

        private void button_Revista_Bajar(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_revista_bajar form_revista_bajar = new UC_revista_bajar();
            canvas_contenedor.Children.Add(form_revista_bajar);
        }

        private void button_listar(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_Busqueda_Sensitiva form_Sensitiva = new UC_Busqueda_Sensitiva();
            canvas_contenedor.Children.Add(form_Sensitiva);
            //canvas_contenedor.Children.Clear();
            //UC_libros_listar form_libro_listar = new UC_libros_listar();
            //canvas_contenedor.Children.Add(form_libro_listar);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult respuesta = System.Windows.MessageBox.Show("¿Está seguro que desea Salir?", "Salir", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

        }

        private void button_Eliminar(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            Eliminar_Autor FormEliminar = new Eliminar_Autor();
            canvas_contenedor.Children.Add(FormEliminar);
        }

        private void button_Eliminar_Editorial(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            Eliminar_Editorial FormEliminar = new Eliminar_Editorial();
            canvas_contenedor.Children.Add(FormEliminar);
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_Informe_Bajas form_Listar_bajas = new UC_Informe_Bajas();
            canvas_contenedor.Children.Add(form_Listar_bajas);
        }

        private void RibbonApplicationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void RibbonButton_Click_2(object sender, RoutedEventArgs e)
        {
            canvas_contenedor.Children.Clear();
            UC_Informes formInformes = new UC_Informes();
            canvas_contenedor.Children.Add(formInformes);
        }
    }
}

