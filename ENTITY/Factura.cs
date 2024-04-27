using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int idFactura { get; set; }
        public required DateTime fecha { get; set; }
        public required string tipoDePago { get; set; }
        public required string direcionDeEntrega { get; set; }
        public required string ciudadDeEntrega { get; set; }
        public required string paisDeEntrega { get; set; }
        public required string tipoEnvio { get; set; }

        public string nombreUsuario { get; set; }
        //propiedad de navegacion
        [ForeignKey("nombreUsuario")]
        public Cliente Cliente { get; set; }

        public required List<Pedido> listaPedidos { get; set; }



        public Factura()
        {
            this.nombreUsuario = "";
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
