using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_negocios
{
    public class CN_factura
    {
        CD_Factura oCD_Factura = new CD_Factura();

        public string MostrarFactura()
        {
            string Factura = oCD_Factura.Mostrar();
            return Factura;

        }

        public void InsetarFactura(CE_factura factura)
        {
            oCD_Factura.Insertar(factura);
        }
    }
}
