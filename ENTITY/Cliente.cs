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
        public string? nombreUsuario { get; set; }
        [MaxLength(50)]
        public string? primerNombre { get; set; }
        [MaxLength(50)]
        public string? segundoNombre { get; set; }
        [MaxLength(50)]
        public string? primerApellido { get; set; }
        [MaxLength(50)]
        public string? segundoApellido { get; set; }
        public long? Celular { get; set; }
        public string? direccionResidencia { get; set; }
        public string? ciudadResidencia { get; set; }
        public string? paisResidencia { get; set; }
        public List<Factura>? listaFacturas { get; set; }


        public Cliente()
        {
            
        }
    }
}
