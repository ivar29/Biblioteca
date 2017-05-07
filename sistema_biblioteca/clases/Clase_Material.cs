using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema_Biblioteca.Clases.Conexion;
namespace Sistema_Biblioteca.Clases
{
    class Clase_Material
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        private string tipo_item;

        public string Tipo_item
        {
            get { return tipo_item; }
            set { tipo_item = value; }
        }
        public Clase_Material(string nombre, string estado, int stock, string tipo_item)
        {
            this.Nombre = nombre;
            this.Estado = estado;
            this.Stock = stock;
            this.Tipo_item = tipo_item;
        }
        public static List<Clase_Material> listaMaterial = new List<Clase_Material>();

        public static DataTable listaDeMaterial()
        {
            Clase_Datos datos = new Clase_Datos();

            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTablaMaterial("Libro_Revista");
            return dataTable;
        }



        public static void agregarMaterial(Clase_Material elMaterial)
        {
            if (elMaterial != null)
            {
                listaMaterial.Add(elMaterial);
            }
            Clase_Datos datos = new Clase_Datos();

            string sql = "insert into Libro_Revista (titulo , estado , stock, tipo_item) values('" + elMaterial.Nombre + "', '" + elMaterial.Estado + "', '" + elMaterial.Stock + "', '" + elMaterial.Tipo_item + "')";
            datos.insertar(sql);

        }
    }
}

