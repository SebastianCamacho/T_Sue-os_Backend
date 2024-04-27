using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int idProducto { get; set; }
        public required string nombre { get; set; }
        public required string categoria { get; set; }
        public required double precio { get; set; }
        public required string colorPrincipal { get; set; }
        public required string colorSecundario { get; set; }
        public required string colorTerciario { get; set; }
        public required List<Pedido> listaPedidos { get; set; }
    }
}
