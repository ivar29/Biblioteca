using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema_Biblioteca.Clases.Conexion;

namespace Sistema_Biblioteca.Clases
{
    class Clase_Autor
    {
        private string nombre;  

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string fecha_nac;

        public string Fecha_nac
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }
        private string fecha_muerte;

        public string Fecha_muerte
        {
            get { return fecha_muerte; }
            set { fecha_muerte = value; }
        }
        private string nacionalidad;

        public string Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public Clase_Autor(string nombre, string fecha_nac, string fecha_muerte, string nacionalidad)
        {
            this.Nombre = nombre;
            this.Fecha_nac = fecha_nac;
            this.Fecha_muerte = fecha_muerte;
            this.Nacionalidad = nacionalidad;
         }

        public Clase_Autor()
        {

        }

        public static void agregar_autor(Clase_Autor el_autor)
        {
            Clase_Datos datos = new Clase_Datos();
            string sql = "insert into Autor (nombre_autor, fecha_nacimiento, fecha_muerte, nacionalidad ) values('" + el_autor.nombre + "', '" + el_autor.fecha_nac + "', '" + el_autor.fecha_muerte + "', '"+el_autor.nacionalidad+ "')";
            datos.insertar(sql);
        }

        public static DataTable lista_autores()
        {
            Clase_Datos datos = new Clase_Datos();

            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_autorTodo("Autor");
            return dataTable;
        }

       
        public static void EliminarAutor(string ID)
        {
            
            Clase_Datos datos = new Clase_Datos();
            string sql = "Delete From Autor where id_autor = '" + ID + "'";

            datos.insertar(sql);

        }


    }
}
