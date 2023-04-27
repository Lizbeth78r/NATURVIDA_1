using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_negocios
{
    public class CN_clientes
    {

        CD_clientes CC = new CD_clientes();


        public DataTable N_bbUSCAR_cliente(CE_clientes c)
        {
            DataTable dt = new DataTable();
            dt = CC.BuscarCliente(c);
            return dt;
        }
        public DataTable N_Mostrar_Clientes()
        { 
            DataTable tabla = new DataTable();
            tabla=CC.MostrarClientes();
            return tabla;    
        }

        public void N_Insertar_Client(CE_clientes c)
        {
          CC.InsertarClientes(c);   
        }

        public void N_Editar_Cliente(CE_clientes c)
        {
            CC.ModificarCLIENT(c);
        }

        public void N_Eliminar_Cliente( CE_clientes c)
        {
            CC.EliminarCLIENT(c);
        }


    }
}
