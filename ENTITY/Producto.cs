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
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int idProducto { get; set; }
        public  string nombre { get; set; }
        public  string categoria { get; set; }
        public  double precio { get; set; }
        public  string colorPrincipal { get; set; }
        public  string colorSecundario { get; set; }
        public  string colorTerciario { get; set; }
        [JsonIgnore]
        public  List<Pedido> listaPedidos { get; set; }



        public Producto()
        {
            
        }
    }
}
