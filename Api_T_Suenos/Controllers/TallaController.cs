using ENTITY;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_T_Suenos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallaController : ControllerBase
    {
        public readonly T_Suenos_Context _dbContext;


        public TallaController(T_Suenos_Context _context)
        {
            this._dbContext=_context;
        }

        // GET: api/<TallaController>
        [HttpGet]
        [Route("Listar")]
        public IActionResult listarTallasAll()
        {
            List<Talla> lista=new List<Talla>();
            try
            {
                lista=_dbContext.Tallas.Include(p => p.Pedido).ToList();
                return StatusCode(StatusCodes.Status200OK, new {mensaje="ok", response=lista});
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje =ex.Message, response = lista });

            }

        }

        // GET api/<TallaController>/5
        [HttpGet("id:{id}")]
        public IActionResult Get(int id)
        {
            Talla talla = _dbContext.Tallas.Find(id);

            if (talla == null)
            {
                return BadRequest("Producto No encontrado");
            }
            try
            {
                talla = _dbContext.Tallas.Include(t => t.Pedido.Producto)
                    .Where(p=>p.idTalla==id).FirstOrDefault();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = talla });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = talla });

            }
        }

        // POST api/<TallaController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Post([FromBody] Talla objeto)
        {
            try
            {
                _dbContext.Tallas.Add(objeto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Guardado correctamente" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // PUT api/<TallaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TallaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
