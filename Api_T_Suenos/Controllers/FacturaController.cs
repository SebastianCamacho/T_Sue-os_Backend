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
    public class FacturaController : ControllerBase
    {

        public readonly T_Suenos_Context _dbContext;


        public FacturaController(T_Suenos_Context _context)
        {
            this._dbContext = _context;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        [Route("Listar")]
        public IActionResult Get()
        {
            List<Factura> lista = new List<Factura>();
            try
            {
                lista = _dbContext.Facturas.Include(f => f.listaPedidos).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = lista });

            }

        }

        // GET api/<FacturaController>/5
        [HttpGet("ListarId:{id}")]
        public IActionResult Get(int id)
        {
            Factura factura = _dbContext.Facturas.Find(id);

            if (factura == null)
            {
                return BadRequest("Factura No encontrada");
            }
            try
            {
                factura = _dbContext.Facturas.Include(t => t.listaPedidos)
                    .Where(p => p.idFactura == id).FirstOrDefault();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = factura });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = factura });

            }
        }

        // POST api/<FacturaController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Post([FromBody] Factura objeto)
        {
            try
            {
                _dbContext.Facturas.Add(objeto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Factura guardada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("Edit:{id}")]
        public IActionResult Put(int id, [FromBody] Factura objeto)
        {

            Factura factura = _dbContext.Facturas.Find(id);

            if (factura == null)
            {
                return BadRequest("Factura No encontrada");
            }

            try
            {
                factura.fecha = objeto.fecha is null ? factura.fecha : objeto.fecha;
                factura.tipoDePago = objeto.tipoDePago is null ? factura.tipoDePago : objeto.tipoDePago ;
                factura.direcionDeEntrega = objeto.direcionDeEntrega is null ? factura.direcionDeEntrega : objeto.direcionDeEntrega ;
                factura.ciudadDeEntrega = objeto.ciudadDeEntrega is null ? factura.ciudadDeEntrega : objeto.ciudadDeEntrega;
                factura.paisDeEntrega = objeto.paisDeEntrega is null ? factura.paisDeEntrega : objeto.paisDeEntrega;
                factura.tipoEnvio = objeto.tipoEnvio is null ? factura.tipoEnvio : objeto.tipoEnvio;
                factura.nombreUsuario = objeto.nombreUsuario is null ? factura.nombreUsuario : objeto.nombreUsuario;



                _dbContext.Facturas.Update(factura);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Factura actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // DELETE api/<FacturaController>/Eliminar:5
        [HttpDelete("Eliminar:{id}")]
        public IActionResult Delete(int id)
        {


            Factura factura = _dbContext.Facturas.Find(id);

            if (factura == null)
            {
                return BadRequest("Factura No encontrado");
            }

            try
            {

                _dbContext.Facturas.Remove(factura);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Factura eliminada Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }
    }
}
