using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class CD_conexiones
    {
        SqlConnection conexiones= new SqlConnection("Server=BUCDFPCSEFSD023;Database=NaturVida1;Integrated Security= True");
        public SqlConnection AbrirConexion()
        {
            if (conexiones.State == ConnectionState.Closed)
            {
                conexiones.Open();
            }
            return conexiones;

        }
        public SqlConnection CerrarConexion()
        {
            if (conexiones.State == ConnectionState.Open)
            {
                conexiones.Close();
            }
            return conexiones;

        }

    }
}
