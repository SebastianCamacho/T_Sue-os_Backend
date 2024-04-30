using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ENTITY
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPedido { get; set; }
        public int? cantidad { get; set; }
        public int? idFactura { get; set; }
        public int? idProducto { get; set; }
        [JsonIgnore]
        public List<Talla>? listaTallas { get; set; } = new List<Talla>();

        
        //propiedad de navegacion
        [JsonIgnore]
        [ForeignKey("idFactura")]
        public Factura? Factura { get; set; }


        //propiedad de navegacion
        [JsonIgnore]
        [ForeignKey("idProducto")]
        public Producto? Producto { get; set; }


        public Pedido()
        {
            
        }
    }
}
