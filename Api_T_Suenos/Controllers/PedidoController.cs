using ENTITY;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_T_Suenos.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public readonly T_Suenos_Context _dbContext;

        public PedidoController(T_Suenos_Context _context)
        {
            this._dbContext = _context;
        }
        // GET: api/<PedidoController>
        [HttpGet]
        [Route("Listar")]
        public IActionResult Get()
        {
            List<Pedido> lista = new List<Pedido>();
            try
            {
                lista = _dbContext.Pedidos.Include(p => p.Producto).Include(p => p.listaTallas).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = lista });

            }
        }

        // GET api/<PedidoController>/5
        [HttpGet("ListarId:{id}")]
        public IActionResult Get(int id)
        {
            Pedido pedido = _dbContext.Pedidos.Find(id);

            if (pedido == null)
            {
                return BadRequest("Pedido No encontrado");
            }
            try
            {
                pedido = _dbContext.Pedidos.Include(p => p.Producto).Include(p => p.listaTallas)
                    .Where(p => p.idPedido == id).FirstOrDefault();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = pedido });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = pedido });

            }
        }

        // POST api/<PedidoController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Post([FromBody] Pedido objeto)
        {
            try
            {
                _dbContext.Pedidos.Add(objeto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Pedido guardado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // PUT api/<TallaController>/5
        [HttpPut("Edit:{id}")]
        public IActionResult Put(int id, [FromBody] Pedido objeto)
        {

            Pedido pedido = _dbContext.Pedidos.Find(id);

            if (pedido == null)
            {
                return BadRequest("Producto No encontrado");
            }

            try
            {
                pedido.cantidad = objeto.cantidad is null ? pedido.cantidad : objeto.cantidad;


                _dbContext.Pedidos.Update(pedido);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Pedido actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // DELETE api/<PedidoController>/5
        
        [HttpDelete("Eliminar:{id}")]
        public IActionResult Delete(int id)
        {
            Pedido pedido = _dbContext.Pedidos.Include(c =>c.listaTallas).ToList().
                Where(p => p.idPedido==id ).FirstOrDefault();

            if (pedido == null)
            {
                return BadRequest("Producto No encontrado");
            }

            try
            {
                
                _dbContext.Pedidos.Remove(pedido);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Pedido eliminado Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }
    }
    
}
