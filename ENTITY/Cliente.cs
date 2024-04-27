using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cliente
    {
        [Key]
        [MaxLength(50)]
        public required string nombreUsuario { get; set; }
        [MaxLength(50)]
        public required string primerNombre { get; set; }
        [MaxLength(50)]
        public string segundoNombre { get; set; }
        [MaxLength(50)]
        public required string primerApellido { get; set; }
        [MaxLength(50)]
        public required string segundoApellido { get; set; }
        public long Celular { get; set; }
        public required string direccionResidencia { get; set; }
        public required string ciudadResidencia { get; set; }
        public required string paisResidencia { get; set; }
        public List<Factura> listaFacturas { get; set; }


        public Cliente()
        {
            segundoNombre = "";
            listaFacturas = new List<Factura>();
        }
    }
}
