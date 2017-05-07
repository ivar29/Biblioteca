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
using Sistema_Biblioteca.Clases.Conexion;

namespace Sistema_Biblioteca.UC_Informe
{
    /// <summary>
    /// Lógica de interacción para UC_Informes.xaml
    /// </summary>
    public partial class UC_Informes : UserControl
    {
        public UC_Informes()
        {
            InitializeComponent();
            datagrid_informes.DataContext = Clase_Datos.LibrosEspanol();
        }

        private void combo_informes_DropDownClosed(object sender, EventArgs e)
        {
            if (combo_informes.Text == "Libros en Español")
            {
                datagrid_informes.DataContext = Clase_Datos.LibrosEspanol();
            }

            if (combo_informes.Text == "Libros en Inglés")
            {
                datagrid_informes.DataContext = Clase_Datos.LibrosIngles();
            }

            if (combo_informes.Text == "Cantidad de Libros en Inglés para Profesores")
            {
                datagrid_informes.DataContext = Clase_Datos.libroinglesProfesor();
            }

            if (combo_informes.Text == "Cantidad de Libros en Español para Profesores")
            {
                datagrid_informes.DataContext = Clase_Datos.libroespanolProfesor();
            }

            if (combo_informes.Text == "Cantidad de Libros en Inglés para Alumnos")
            {
                datagrid_informes.DataContext = Clase_Datos.libroinglesAlumno();
            }

            if (combo_informes.Text == "Cantidad de Libros en Español para Alumnos")
            {
                datagrid_informes.DataContext = Clase_Datos.libroespanolAlumno();
            }

            if (combo_informes.Text == "Ítems activos")
            {
                datagrid_informes.DataContext = Clase_Datos.todoActivoPorNombre();
            }

            if (combo_informes.Text == "Ítems dados de baja")
            {
                datagrid_informes.DataContext = Clase_Datos.todoBajoPorNombre();
            }

            if (combo_informes.Text == "Cantidad de Revistas fundadas despues de año 2000")
            {
                datagrid_informes.DataContext = Clase_Datos.revistasMas2000();
            }

            if (combo_informes.Text == "Cantidad de Revistas fundadas antes de año 2000")
            {
                datagrid_informes.DataContext = Clase_Datos.revistasMenos2000();
            }

            if (combo_informes.Text == "Cantidad de Libros por Autor")
            {
                datagrid_informes.DataContext = Clase_Datos.cantidadLibrosAutor();
            }

            if (combo_informes.Text == "Libros Chilenos")
            {
                datagrid_informes.DataContext = Clase_Datos.librosChilenos();
            }
        }
    }
}

