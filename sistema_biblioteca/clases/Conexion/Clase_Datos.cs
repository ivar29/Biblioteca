using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace Sistema_Biblioteca.Clases.Conexion

{
    class Clase_Datos
    {
        //private string cadena = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ivar\Desktop\bd_Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        private string cadena = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\bd_Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection cn;
        private SqlCommand comando;
        public SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        private void conectar()
        {

            cn = new SqlConnection(cadena);

        }

        public Clase_Datos()
        {
            conectar();
        }

        public void insertar(string sql)
        {
            try
            {
                cn.Open();
                comando = new SqlCommand(sql, cn);
                int i = comando.ExecuteNonQuery();
                cn.Close();
                if (i > 0)
                {
                    // MessageBox.Show("Datos Ingresados Satisfactoriamente", "Genial", MessageBoxButton.OK);

                }
                else
                {
                    System.Windows.MessageBox.Show("Error en la consulta", "");

                }

            }
            catch (Exception e)
            {
                //  System.Windows.MessageBox.Show("ID Repetidos","Error", MessageBoxButton.OK ,MessageBoxImage.Error);

                System.Windows.MessageBox.Show("Error: " + e.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public DataTable consultaTabla_BajasTodo(string tabla)
        {

            string sql = "select id_baja as 'ID Baja',fecha_baja as Fecha,razon_baja as Razón, id_producto_baja as 'ID Producto' from " + tabla + "";
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

        public bool eliminar(string tabla, string condicion)
        {
            cn.Close();
            cn.Open();
            string sql = "delete from " + tabla + " where " + condicion;
            comando = new SqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool actualizarEditar(string tabla, string campos, string condicion)
        {

            cn.Close();
            cn.Open();
            string sql = "update " + tabla + " set " + campos + " where " + condicion;
            comando = new SqlCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public DataTable consultaTabla(string tabla)
        {

            string sql = "select * from " + tabla;
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();             
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

        public DataTable consultaTabla_B(string tabla)
        {

            string sql = "select " + tabla;
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

        public DataTable consultaTablaMaterial(string tabla)
        {

            string sql = "select id as ID,titulo as Titulo, estado as Estado from " + tabla + " where tipo_item='Material'";
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();             //Dataset es una ´copia de la tabla.. y se pasa
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

        public DataTable consultaTablaLibro(string tabla)
        {

            string sql = "select id as ID,titulo as Titulo,idioma_libro as Idioma ,isbn as ISBN ,edicion_libro as Edicion ,volumen_libro as Volumen ,tomo_libro as Tomo ,tipo_lector_libro as TipoLector ,autor_libro as Autor, otro_autor as OtroAutor ,contenido as Contenido ,estado as  Estado, editorial_libro as Editorial from " + tabla + " where tipo_item='Libro'";
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();             //Dataset es una ´copia de la tabla.. y se pasa
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }


        public DataTable consultaTablaRevista(string tabla)
        {

            string sql = "select id as ID,titulo as Titulo , fecha_fundacion as 'FechaFundacion', issn_revista as ISSN, estado as Estado, contenido as Contenido from " + tabla + " where tipo_item='Revista'";
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();             //Dataset es una ´copia de la tabla.. y se pasa
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }

        public void llenar_combobox_editorial(string tabla, string condicion, ComboBox combobox )
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT "+condicion+" FROM " + tabla + "  ORDER BY nombre_editorial", cn);
            da.Fill(ds, tabla);
            combobox.ItemsSource = ds.Tables[tabla].DefaultView;
            combobox.DisplayMemberPath = ds.Tables[tabla].Columns["nombre_editorial"].ToString();
            combobox.SelectedValuePath = ds.Tables[tabla].Columns["id_editorial"].ToString();
            
           
        }

        public void llenar_combobox_autor(string tabla, string condicion, ComboBox combobox)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT " + condicion + " FROM " + tabla + "  ORDER BY nombre_autor", cn);
            da.Fill(ds, tabla);
            combobox.ItemsSource = ds.Tables[tabla].DefaultView;
            combobox.DisplayMemberPath = ds.Tables[tabla].Columns["nombre_autor"].ToString();
            combobox.SelectedValuePath = ds.Tables[tabla].Columns["id_autor"].ToString();


        }

        public DataTable consultaTabla_autorTodo(string tabla)
        {
            string sql = "select id_autor as ID,nombre_autor as Autor ,fecha_nacimiento as 'Fecha Nacimiento' ,fecha_muerte as 'Fecha Muerte' , nacionalidad as Nacionalidad from " + tabla + " where id_autor<>1 ";
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

        public DataTable consultaTabla_editorialTodo(string tabla)
        {

            string sql = "select id_editorial as ID, nombre_editorial as Nombre from " + tabla + " where id_editorial<>1 ";
            da = new SqlDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;

        }

        public static DataTable LibrosEspanol()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, autor_libro as Autor, editorial_libro as Editorial from Libro_Revista WHERE tipo_item = 'Libro' AND idioma_libro = 'Español' GROUP BY titulo, autor_libro, editorial_libro ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable LibrosIngles()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, autor_libro as Autor, editorial_libro as Editorial from Libro_Revista WHERE tipo_item = 'Libro' AND idioma_libro = 'Ingles' GROUP BY titulo, autor_libro, editorial_libro ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable libroinglesProfesor()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad From Libro_Revista where idioma_libro='Ingles' AND tipo_lector_libro='Profesor' GROUP BY titulo ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable libroespanolProfesor()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad From Libro_Revista where idioma_libro='Español' AND tipo_lector_libro='Profesor' GROUP BY titulo ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable libroinglesAlumno()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad From Libro_Revista where idioma_libro='Ingles'AND tipo_lector_libro='Alumno' GROUP BY titulo ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable libroespanolAlumno()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad From Libro_Revista where idioma_libro='Español'AND tipo_lector_libro='Alumno' GROUP BY titulo ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable todoActivoPorNombre()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad, tipo_item as Tipo From Libro_Revista where estado='Activo' GROUP BY titulo, tipo_item ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable todoBajoPorNombre()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad, tipo_item as Tipo From Libro_Revista where estado='Baja' GROUP BY titulo, tipo_item ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable revistasMas2000()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad, fecha_fundacion as Fecha From Libro_Revista where tipo_item='Revista'AND fecha_fundacion >= '2000/01/01' GROUP BY titulo, fecha_fundacion ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable revistasMenos2000()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("titulo as Título, Count(titulo) as Cantidad, fecha_fundacion as Fecha From Libro_Revista where tipo_item='Revista' AND fecha_fundacion <= '2000/01/01' AND fecha_fundacion <> ' ' GROUP BY titulo, fecha_fundacion ORDER BY COUNT(titulo)");
            return dataTable;
        }

        public static DataTable cantidadLibrosAutor()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("autor_libro as Autor, Count(autor_libro) as Cantidad From Libro_Revista where tipo_item='Libro' GROUP BY autor_libro ORDER BY COUNT(autor_libro) DESC");
            return dataTable;
        }

        public static DataTable librosChilenos()
        {
            Clase_Datos datos = new Clase_Datos();
            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_B("Libro_Revista.titulo AS Título, COUNT(Libro_Revista.titulo) AS Cantidad, Libro_Revista.autor_libro AS Autor, Libro_Revista.editorial_libro AS Editorial " +
                                              "FROM Libro_Revista " +
                                              "INNER JOIN Autor " +
                                              "ON Libro_Revista.tipo_item = 'Libro' AND Libro_Revista.autor_libro = Autor.nombre_autor AND (Autor.nacionalidad LIKE '%Chileno%' OR Autor.nacionalidad LIKE '%Chilena%') " +
                                              "GROUP BY Libro_Revista.titulo, Libro_Revista.autor_libro, Libro_Revista.editorial_libro");                   
            return dataTable;
        }
    }
}
