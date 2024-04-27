using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int idPedido { get; set; }
        public required int cantidad { get; set; }

        public required List<Talla> listaTallas { get; set; } = new List<Talla>();

        public int idFactura { get; set; }
        //propiedad de navegacion
        [ForeignKey("idFactura")]
        public Factura Factura { get; set; }

        public int idProducto { get; set; }
        //propiedad de navegacion
        [ForeignKey("idProducto")]
        public required Producto Producto { get; set; }
    }
}
