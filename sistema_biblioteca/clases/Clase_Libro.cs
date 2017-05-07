using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema_Biblioteca.Clases.Conexion;

namespace Sistema_Biblioteca.Clases
{
    class Clase_Libro
    {
        private string tipo_item;

        public string Tipo_item
        {
            get { return tipo_item; }
            set { tipo_item = value; }
        }

        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        private string idioma;

        public string Idioma
        {
            get { return idioma; }
            set { idioma = value; }
        }
        private string isbn;

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        private string edicion;

        public string Edicion
        {
            get { return edicion; }
            set { edicion = value; }
        }
        private string volumen;

        public string Volumen
        {
            get { return volumen; }
            set { volumen = value; }
        }
        private string tomo;

        public string Tomo
        {
            get { return tomo; }
            set { tomo = value; }
        }

        private string tipo_lector;

        public string Tipo_lector
        {
            get { return tipo_lector; }
            set { tipo_lector = value; }
        }

        //private string autor_prin;
        private string autor_prin;

        public string Autor_prin
        {
            get { return autor_prin; }
            set { autor_prin = value; }
        }

        private string otro_autor;

        public string Otro_autor
        {
            get { return otro_autor; }
            set { otro_autor = value; }
        }

        private string contenido;

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        ///
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

        private string editorial;

        public string Editorial
        {
            get { return editorial; }
            set { editorial = value; }
        }
        public Clase_Libro(string tipo_item,string titulo,string idioma, string isbn, string edicion, string volumen, string tomo, string tipo_Lector,string autor,string otro_autor, string contenido, int stock, string editorial,string estado)
        {
            this.Tipo_item = tipo_item;
            this.Titulo = titulo;
            this.Idioma = idioma;
            this.Isbn = isbn;
            this.Edicion = edicion;
            this.Volumen = volumen;
            this.Tomo = tomo;
            this.Tipo_lector = tipo_Lector;
            this.Autor_prin = autor;
            this.Otro_autor = otro_autor;
            this.Contenido = contenido;
            this.Stock = stock;
            this.Editorial = editorial;
            this.Estado = estado;
        }

        public static List<Clase_Libro> listaLibro = new List<Clase_Libro>();

        public static DataTable listaDeLibro()
        {
            Clase_Datos datos = new Clase_Datos();

            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTablaLibro("Libro_Revista");
            return dataTable;
        }


        public static void agregarLibro(Clase_Libro elLibro)
        {
            if (elLibro != null)
            {
                listaLibro.Add(elLibro);
            }
            Clase_Datos datos = new Clase_Datos();
                                                                                                                                                                                           //public Clase_Libro(string tipo_item,string titulo,string idioma, string isbn, string                                                      edicion, string volumen, string tomo, string tipo_Lector,string autor,string otro_autor, string contenido, int stock, string editorial)

            string sql = "insert into Libro_Revista (tipo_item,titulo,idioma_libro,isbn,edicion_libro,volumen_libro,tomo_libro,tipo_lector_libro,autor_libro,otro_autor,contenido,stock,editorial_libro,estado) values('" + elLibro.Tipo_item + "', '" + elLibro.Titulo + "', '" + elLibro.Idioma + "', '" + elLibro.Isbn + "', '" + elLibro.Edicion + "', '" + elLibro.Volumen + "', '" + elLibro.Tomo + "', '" + elLibro.Tipo_lector + "', '" + elLibro.Autor_prin + "', '" + elLibro.Otro_autor + "' , '" + elLibro.Contenido + "', '" + elLibro.Stock + "', '" + elLibro.Editorial + "', '" + elLibro.Estado + "')"; 
            datos.insertar(sql);

        }

      

        public Clase_Libro()
        {

        }
    }
}
