using Sistema_Biblioteca.Clases.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Biblioteca.Clases
{ 
    class Clase_Baja
    {


        private string fechaB;

        public string FechaB
        {
            get { return fechaB; }
            set { fechaB = value; }
        }
        private string razon;

        public string Razon
        {
            get { return razon; }
            set { razon = value; }
        }
        private int id_producto;

        public int Id_Producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        public Clase_Baja(string fechaB, string razon, int id_producto)
        {
            this.FechaB = fechaB;
            this.Razon = razon;
            this.Id_Producto = id_producto;
        }
        public static DataTable lista_Bajas()
        {
            Clase_Datos datos = new Clase_Datos();

            DataTable dataTable = new DataTable();
            dataTable = datos.consultaTabla_BajasTodo("Baja");
            return dataTable;
        }
        public static void agregarBaja(Clase_Baja laBaja)
        {
            Clase_Datos datos = new Clase_Datos();
            string sql = "insert into Baja (fecha_baja,razon_baja,id_producto_baja) values('" + laBaja.fechaB + "' ,'" + laBaja.razon + "','" + laBaja.Id_Producto + "')";
            datos.insertar(sql);
        }
    }


}

