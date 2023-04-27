using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_clientes
    {
        CD_conexiones conexiones = new CD_conexiones();
        DataTable tabla = new DataTable();
        SqlDataReader leer;
        SqlCommand Comand = new SqlCommand();




        public DataTable BuscarCliente(CE_clientes C)
        {
            Comand.Parameters.Clear();
            tabla.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "BuscarCliente";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Documento",C.Documento);
            leer = Comand.ExecuteReader();
            tabla.Load(leer);
            conexiones.CerrarConexion();
            return tabla;
        }
        
           
        
        public DataTable MostrarClientes()  //para el combocox necesitamos usar un parametro para enviar
        {
            Comand.Parameters.Clear();
            tabla.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "MostrarClientes";
            Comand.CommandType = CommandType.StoredProcedure;
            leer = Comand.ExecuteReader();
            tabla.Load(leer);
            return tabla;
        }

        public void InsertarClientes(CE_clientes C)
        //Metodo de insercion de productos :D
        {
            Comand.Parameters.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "SP_INSERTARCLIENT";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Docu",C.Documento);
            Comand.Parameters.AddWithValue("@Nombre", C.Nombre);
            Comand.Parameters.AddWithValue("@Direccion",C.Direccion);
            Comand.Parameters.AddWithValue("@Tel",C.Telefono);
            Comand.Parameters.AddWithValue("@Corr",C.Correo);
            Comand.ExecuteNonQuery();
            Comand.Parameters.Clear();
            conexiones.CerrarConexion();
        }

        public void ModificarCLIENT(CE_clientes C)

        {
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "SP_ACTUALCLIENT";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Docu", C.Documento);
            Comand.Parameters.AddWithValue("@DocuNew", C.Documento);
            Comand.Parameters.AddWithValue("@Nombre", C.Nombre);
            Comand.Parameters.AddWithValue("@Direccion", C.Direccion);
            Comand.Parameters.AddWithValue("@Tel", C.Telefono);
            Comand.Parameters.AddWithValue("@Corr", C.Correo);
            Comand.ExecuteNonQuery();
            Comand.Parameters.Clear();
            conexiones.CerrarConexion();
        }
        public void EliminarCLIENT(CE_clientes C)
        {
            Comand.Parameters.Clear();
            Comand.Connection = conexiones.AbrirConexion();
            Comand.CommandText = "SP_ELIMINARCLIENT";
            Comand.CommandType = CommandType.StoredProcedure;
            Comand.Parameters.AddWithValue("@Docu",C.Documento);
            Comand.ExecuteNonQuery();
            Comand.Parameters.Clear();
            conexiones.CerrarConexion();
        }

    }
}
