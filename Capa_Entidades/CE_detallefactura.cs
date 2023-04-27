using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class CE_detallefactura
    {
        int Idfact;
        int Codigo_Productos;
        int Cantidad;
        int Valor_Unidad;

        public int Idfact1 { get => Idfact; set => Idfact = value; }
        public int Codigo_Productos1 { get => Codigo_Productos; set => Codigo_Productos = value; }
        public int Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public int Valor_Unidad1 { get => Valor_Unidad; set => Valor_Unidad = value; }
    }
}
