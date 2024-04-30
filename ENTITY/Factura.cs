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
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFactura { get; set; }
        public DateTime? fecha { get; set; }
        public string? tipoDePago { get; set; }
        public string? direcionDeEntrega { get; set; }
        public string? ciudadDeEntrega { get; set; }
        public string? paisDeEntrega { get; set; }
        public string? tipoEnvio { get; set; }

        public string? nombreUsuario { get; set; }
        //propiedad de navegacion
        [JsonIgnore]
        [ForeignKey("nombreUsuario")]
        public Cliente? Cliente { get; set; }

        public List<Pedido>? listaPedidos { get; set; }



        public Factura()
        {
            
        }



        public double calcularSubTotal()
        {
            return 0; //listaPedidos.Count;
        }
        public double calcularCostoEnvio()
        {
            return 0;
        }

        public double calcularTotal()
        {
            return calcularSubTotal() + calcularCostoEnvio();
        }
    }
}
