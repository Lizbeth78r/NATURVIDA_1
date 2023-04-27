using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Capa_negocios
{
    public class CN_vendedores
    {
        CD_vendedores vendedor= new CD_vendedores();
        CE_vendedores oCEvendedores= new CE_vendedores();

        public bool buscardatovende(CE_vendedores usuario)
        {
            DataTable tabla = new DataTable();
            tabla = vendedor.BuscarDatosVendedor(usuario);
            if (tabla.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool BuscarVend(CE_vendedores vendedores)
        {
            DataTable encontrado = vendedor.Buscarvendedores(vendedores);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool BuscarVendEditar(CE_vendedores vendedores)
        {
            DataTable encontrado = vendedor.EditarBuscarVendedor(vendedores);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Buscarnombrevend()
        {
            DataTable tabla = new DataTable();
            tabla = vendedor.BuscarNombreVendedor();
            return tabla;
        }

        public DataTable MostrarTablaVendedores()
        {
            DataTable tabla = vendedor.mostrartodatablavendedores();
            return tabla;
        }

        public DataTable MostrarTablaVendeEditar(CE_vendedores vendedores)
        {
            DataTable tabla3 = vendedor.mostrartodatablavendeditar(vendedores);
            return tabla3;
        }

        public DataTable BuscarTodosVendedores(CE_vendedores vendedores)
        {
            DataTable tabla = vendedor.BuscarTodosVendedores(vendedores);
            return tabla;
        }

        public void InsertarVendedor(CE_vendedores vendedores)
        {
            vendedor.InsertarVendedor(vendedores);
        }

        public void EditarVendedor(CE_vendedores vendedores)
        {
            vendedor.EditarVendedor(vendedores);
        }

        public void EliminarVendedor(CE_vendedores vendedores)
        {
            vendedor.EliminarVendedor(vendedores);
        }
    }
}
