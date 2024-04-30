using ENTITY;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_T_Suenos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly T_Suenos_Context _dbContext;


        public ClienteController(T_Suenos_Context _context)
        {
            this._dbContext = _context;
        }


        // GET: api/<ClienteController>
        [HttpGet]
        [HttpGet]
        [Route("Listar")]
        public IActionResult Get()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                lista = _dbContext.Clientes.Include(p => p.listaFacturas).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = lista });

            }

        }

        // GET api/<ClienteController>/5
        [HttpGet("ListarId:{id}")]
        public IActionResult Get(string id)
        {
            Cliente cliente = _dbContext.Clientes.Find(id);

            if (cliente == null)
            {
                return BadRequest("Cliente No encontrado");
            }
            try
            {
                cliente = _dbContext.Clientes.Include(t => t.listaFacturas)
                    .Where(p => p.nombreUsuario == id).FirstOrDefault();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = cliente });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = cliente });

            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Post([FromBody] Cliente objeto)
        {
            try
            {
                _dbContext.Clientes.Add(objeto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Cliente guardado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("Edit:{id}")]
        public IActionResult Put(string id, [FromBody] Cliente objeto)
        {

            Cliente cliente = _dbContext.Clientes.Find(id);

            if (cliente == null)
            {
                return BadRequest("Talla No encontrado");
            }

            try
            {
                cliente.primerNombre = objeto.primerNombre is null ? cliente.primerNombre : objeto.primerNombre;
                cliente.segundoNombre = objeto.segundoNombre is null ? cliente.segundoNombre : objeto.segundoNombre;
                cliente.primerApellido = objeto.primerApellido is null ? cliente.primerApellido : objeto.primerApellido;
                cliente.segundoApellido = objeto.segundoApellido is null ? cliente.segundoApellido : objeto.segundoApellido;
                cliente.Celular = objeto.Celular is null ? cliente.Celular : objeto.Celular;
                cliente.direccionResidencia = objeto.direccionResidencia is null ? cliente.direccionResidencia : objeto.direccionResidencia;
                cliente.ciudadResidencia = objeto.ciudadResidencia is null ? cliente.ciudadResidencia : objeto.ciudadResidencia;
                cliente.paisResidencia = objeto.paisResidencia is null ? cliente.paisResidencia : objeto.paisResidencia;
                


                _dbContext.Clientes.Update(cliente);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Cliente actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("Eliminar:{id}")]
        public IActionResult Delete(string id)
        {


            Cliente cliente = _dbContext.Clientes.Find(id);

            if (cliente == null)
            {
                return BadRequest("Cliente No encontrado");
            }

            try
            {

                _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "El Cliente fue eliminado Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }
    }
}
