using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class CD_vendedores
    {
        CD_conexiones conexion = new CD_conexiones();
        SqlDataReader Leer;
        SqlCommand Comando = new SqlCommand();
        DataTable Tabla = new DataTable();
        
        public DataTable BuscarDatosVendedor(CE_vendedores usuario)
        {
            Tabla.Clear();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BuscarDatosUsuVende";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            Comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            Leer = Comando.ExecuteReader();
            Tabla.Clear();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable Buscarvendedores(CE_vendedores vendedor)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BuscarcVendedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedor.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedor.Usuario);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable EditarBuscarVendedor(CE_vendedores vendedor)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BuscarVendeEditar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedor.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedor.Usuario);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable BuscarNombreVendedor()
        {
            DataTable Tabla = new DataTable();
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_NombreVendedores";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable BuscarTodosVendedores(CE_vendedores vendedor)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BuscarTodosVendores";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedor.Codigo);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable mostrartodatablavendedores()
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_MostrarVendores";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable mostrartodatablavendeditar(CE_vendedores vendedor)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BuscarTodostablaVendores";
            Comando.Parameters.AddWithValue("@Cod", vendedor.Codigo);
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }
        public void InsertarVendedor(CE_vendedores vendedor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_INSERTARVENDORES";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedor.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedor.Usuario);
            Comando.Parameters.AddWithValue("@Contrasena", vendedor.Contraseña);
            Comando.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EditarVendedor(CE_vendedores vendedor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_ACTUALIZARVENDORES";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedor.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedor.Usuario);
            Comando.Parameters.AddWithValue("@Contrasena", vendedor.Contraseña);
            Comando.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EliminarVendedor(CE_vendedores vendedores)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_ELIMINARVEND";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
        }
    }
}
