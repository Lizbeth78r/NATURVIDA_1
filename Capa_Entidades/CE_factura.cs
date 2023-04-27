using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class CE_factura
    {
        int IdFactu;
        DateTime Fecha;
        int Documento_Cliente;
        int Codigo_Vendedor;

        public int IdFactu1 { get => IdFactu; set => IdFactu = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public int Documento_Cliente1 { get => Documento_Cliente; set => Documento_Cliente = value; }
        public int Codigo_Vendedor1 { get => Codigo_Vendedor; set => Codigo_Vendedor = value; }
    }
}
