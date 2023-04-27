using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_negocios
{
    public class CN_factura_detalle
    {
        CD_factura_detalle oCD_Factura_detalle = new CD_factura_detalle();

        public void InsetarFacturaDetalle(CE_detallefactura detallefactura)
        {
            oCD_Factura_detalle.Insertar(detallefactura);
        }
    }
}
