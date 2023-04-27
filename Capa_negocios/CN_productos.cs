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
    public class CN_productos
    {
        CD_productos pp = new   CD_productos();


        public DataTable N_MostrarPROD(string consulta) // envia el parametro para buscar en el combobox
        {
            DataTable table = new DataTable();
            table =pp.MostrarPROD(consulta);
            return table;
        }
        public void N_insertarPROD(CE_productos p)
        {
            pp.InsertarPROD(p);
        }

        public void N_EditarPROD(CE_productos p)
        {
            pp.ModificarPROD(p);
        }

        public void N_EliminarPROD(CE_productos p)
        {
            pp.EliminarPROD(p);
            
        }

        public DataTable BuscarProductos(CE_productos Productos)
        {
            DataTable dt = new DataTable();
            dt = pp.BuscarProducto(Productos);
            return dt;
        }
    }
}

