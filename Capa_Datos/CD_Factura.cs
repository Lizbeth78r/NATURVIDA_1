using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Capa_Datos
{
    public class CD_Factura
    {
        CD_conexiones conexion = new CD_conexiones();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();

        public string Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarNfactura";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {

                string factura = leer["IdFactu"].ToString();
                leer.Close();
                return factura;

            }
            else
            {

                leer.Close();
                return " ";
            }
        }

        public void Insertar(CE_factura p)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_AGGFACT";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fech", p.Fecha1);
            comando.Parameters.AddWithValue("@DoClient", p.Documento_Cliente1);
            comando.Parameters.AddWithValue("@CodVende", p.Codigo_Vendedor1);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        
    }
}
