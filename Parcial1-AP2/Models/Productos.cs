using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial1_AP2.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage ="El campo Descripccion esta vacio")]
        public string Descripccion { get; set; }

        [Required(ErrorMessage ="El campo Existencia esta vacio")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "El campo Costo esta vacio")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage =" El campo Valor Inventario esta vacio")]
        public decimal Valor_Inventario { get; set; }
    }
}
