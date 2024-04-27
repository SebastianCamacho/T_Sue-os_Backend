using ENTITY;
using Microsoft.AspNetCore.Mvc;

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
        [Route("listaTallas")]
        public IActionResult listarTallasAll()
        {
            List<Talla> lista=new List<Talla>();
            try
            {
                lista=_dbContext.Tallas.ToList();
                return StatusCode(StatusCodes.Status200OK, new {mensaje="ok", response=lista});
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje =ex.Message, response = lista });

            }

        }

        // GET api/<TallaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TallaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
