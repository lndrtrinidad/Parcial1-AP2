using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial1_AP2.Models
{
    public class Productos
    {
        [key]
        public int ProductoId { get; set; }
        public string Descripccion { get; set; }
        public int Existencia { get; set; }
        public double Costo { get; set; }
        public double Valor_Inventario { get; set; }
    }
}
