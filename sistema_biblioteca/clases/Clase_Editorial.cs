using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Biblioteca.Clases.Conexion;
using System.Data;

namespace Sistema_Biblioteca.Clases
{
    class Clase_Editorial
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Clase_Editorial(string nombre)
        {
            this.Nombre = nombre;
        }

        public static void agregar_editorial(Clase_Editorial la_editorial)
        {
            Clase_Datos datos = new Clase_Datos();
            string sql = "insert into Editorial (nombre_editorial) values('" + la_editorial.nombre + "')";
            datos.insertar(sql);
        }

        public static DataTable lista_editorial()
        {
            Clase_Datos datos = new Clase_Datos();

            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_editorialTodo("Editorial");
            return dataTable;
        }

       
    }
}
