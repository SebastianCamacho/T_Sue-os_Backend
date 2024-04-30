using ENTITY;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_T_Suenos.Controllers
{
    [EnableCors("ReglasCors")]
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
        public IActionResult Get()
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
        [HttpGet("ListarId:{id}")]
        public IActionResult Get(int id)
        {
            Talla talla = _dbContext.Tallas.Find(id);

            if (talla == null)
            {
                return BadRequest("Talla No encontrada");
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
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Talla guardada correctamente" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // PUT api/<TallaController>/5
        [HttpPut("Edit:{id}")]
        public IActionResult Put(int id, [FromBody] Talla objeto)
        {

            Talla talla = _dbContext.Tallas.Find(id);

            if (talla == null)
            {
                return BadRequest("Talla No encontrado");
            }

            try{
                talla.descripcion = objeto.descripcion is null ? talla.descripcion : objeto.descripcion;
                talla.medida = objeto.medida is null ? talla.medida : objeto.medida;
                talla.idPedido = objeto.idPedido is null ? talla.idPedido : objeto.idPedido;


                _dbContext.Tallas.Update(talla);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Talla actualizada correctamente" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }

        // DELETE api/<TallaController>/5
        [HttpDelete("Eliminar:{id}")]
        public IActionResult Delete(int id)
        {


            Talla talla = _dbContext.Tallas.Find(id);

            if (talla == null)
            {
                return BadRequest("Talla No encontrado");
            }

            try
            {

                _dbContext.Tallas.Remove(talla);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Talla eliminada Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }
    }
}
