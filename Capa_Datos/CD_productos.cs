using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_Datos
{
    public class CD_productos
    {
        CD_conexiones conexiones = new CD_conexiones();
        DataTable tabla = new DataTable();
        SqlDataReader leer;
        SqlCommand Comand = new SqlCommand();


        public DataTable MostrarPROD(string consulta)  //para el combocox necesitamos usar un parametro para enviar
        {
            tabla.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = consulta;
            Comand.CommandType = CommandType.Text;
            leer = Comand.ExecuteReader();
            tabla.Load(leer);
            conexiones.CerrarConexion();
            return tabla;
        }
        public void InsertarPROD(CE_productos P)
        //Metodo de insercion de productos :D
        {
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "SP_INSERTARPRODUCT";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Codigo", P.Codigo);
            Comand.Parameters.AddWithValue("@Descri", P.Descripción);
            Comand.Parameters.AddWithValue("@ValUnd", P.Valor_Unidad);
            Comand.Parameters.AddWithValue("@Cantida", P.Cantidad);
            Comand.ExecuteNonQuery();
            Comand.Parameters.Clear();
            conexiones.CerrarConexion();
        }

        public void ModificarPROD(CE_productos P)
       
        {
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "SP_ACTUALIZARPROD";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Cod", P.Codigo);
            Comand.Parameters.AddWithValue("@CodNew", P.Codigo);
            Comand.Parameters.AddWithValue("@Descri", P.Descripción);
            Comand.Parameters.AddWithValue("@ValUnd", P.Valor_Unidad);
            Comand.Parameters.AddWithValue("@Cant", P.Cantidad);
            Comand.ExecuteNonQuery();
            Comand.Parameters.Clear();
            conexiones.CerrarConexion();
        }
        public void EliminarPROD(CE_productos P)
        {
            Comand.Parameters.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "SP_ELIMINARPROD";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Cod",P.Codigo);
            Comand.ExecuteNonQuery();
            Comand.Parameters.Clear();
            conexiones.CerrarConexion();
        }

        public DataTable BuscarProducto(CE_productos P)
        {
            tabla.Clear();
            Comand.Parameters.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "BuscarPructos";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Codigo", P.Codigo);
            leer = Comand.ExecuteReader();
            tabla.Load(leer);
            conexiones.CerrarConexion();
            return tabla;
        }

    }
}
