using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema_Biblioteca.Clases.Conexion;

namespace Sistema_Biblioteca.Clases
{
    class Clase_Revista
    {

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
 
        private string tipo_item;

        public string Tipo_item
        {
            get { return tipo_item; }
            set { tipo_item = value; }
        }
        private string issn;

        public string Issn
        {
            get { return issn; }
            set { issn = value; }
        }

        private string estado_Revista;

        public string Estado_Revista
        {
            get { return estado_Revista; }
            set { estado_Revista = value; }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        private string fecha_fundacion;

        public string Fecha_fundacion
        {
            get { return fecha_fundacion; }
            set { fecha_fundacion = value; }

        }
        private string contenido;

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }

        }



        //(tipo_item ,titulo ,contenido,estado , stock ,fecha_fundacion ,issn_revista) 
        public Clase_Revista(string tipo_item, string nombre,string contenido, string estado_Revista, int stock,string fecha_fundacion, string issn_revista) 
        {
            this.Nombre= nombre;
            this.Tipo_item = tipo_item;
            this.Issn = issn_revista;
            this.Estado_Revista = estado_Revista;
            this.Stock = stock;
            this.Fecha_fundacion = fecha_fundacion;
            this.Contenido = contenido;

        }
        public static List<Clase_Revista> listaRevista = new List<Clase_Revista>();

        public static DataTable listaDeRevista()
        {
            Clase_Datos datos = new Clase_Datos();

            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTablaRevista("Libro_Revista");
            return dataTable;
        }

     



        public static void agregarRevista(Clase_Revista laRevista)
        {
            if (laRevista != null)
            {
                listaRevista.Add(laRevista);
            }
            Clase_Datos datos = new Clase_Datos();

            string sql = "insert into Libro_Revista (tipo_item ,titulo ,contenido,estado, stock ,fecha_fundacion ,issn_revista) values('" + laRevista.Tipo_item + "', '" + laRevista.Nombre + "', '" + laRevista.Contenido+ "', '" + laRevista.Estado_Revista + "', '" + laRevista.Stock + "', '" + laRevista.Fecha_fundacion +  "', '" + laRevista.Issn+"')";
            datos.insertar(sql);

        }
    }
}
