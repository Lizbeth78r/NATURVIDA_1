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
    public class CD_factura_detalle
    {
        CD_conexiones Conexion = new CD_conexiones();      
        DataTable Tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(CE_detallefactura Registrar)
        {           
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SP_AGGFACTDETA";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IDFac", Registrar.Idfact1);
            comando.Parameters.AddWithValue("@CodProd", Registrar.Codigo_Productos1);
            comando.Parameters.AddWithValue("@Cant", Registrar.Cantidad1);
            comando.Parameters.AddWithValue("@ValUnidad", Registrar.Valor_Unidad1);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }
    }
}
