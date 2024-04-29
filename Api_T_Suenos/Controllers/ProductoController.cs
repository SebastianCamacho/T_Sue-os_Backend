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
    public class ProductoController : ControllerBase
    {
        public readonly T_Suenos_Context _dbContext;

        public ProductoController(T_Suenos_Context _context)
        {
            this._dbContext = _context;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        [Route("Listar")]
        public IActionResult Get()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                lista = _dbContext.Productos.Include(p => p.listaPedidos).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = lista });

            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("ListarId:{id}")]
        public IActionResult Get(int id)
        {
            Producto producto = _dbContext.Productos.Find(id);

            if (producto == null)
            {
                return BadRequest("Producto No encontrado");
            }
            try
            {
                producto = _dbContext.Productos.Include(p => p.listaPedidos)
                    .Where(p => p.idProducto == id).FirstOrDefault();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = producto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = producto });

            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Post([FromBody] Producto objeto)
        {
            try
            {
                _dbContext.Productos.Add(objeto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Produto guardado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }

        }

        // PUT api/<ProductoController>/5
        [HttpPut("Edit:{id}")]
        public IActionResult Edit(int id, [FromBody] Producto objeto)
        {
            Producto producto = _dbContext.Productos.Find(id);

            if (producto == null)
            {
                return BadRequest("Producto No encontrado");
            }

            try
            {
                producto.nombre = objeto.nombre is null ? producto.nombre : objeto.nombre;
                producto.categoria = objeto.categoria is null ? producto.categoria : objeto.categoria;
                producto.precio = objeto.precio is null ? producto.precio : objeto.precio;
                producto.colorPrincipal = objeto.colorPrincipal is null ? producto.colorPrincipal : objeto.colorPrincipal;
                producto.colorSecundario = objeto.colorSecundario is null ? producto.colorSecundario : objeto.colorSecundario;
                producto.colorTerciario = objeto.colorSecundario is null ? producto.colorTerciario : objeto.colorTerciario;
                


                _dbContext.Productos.Update(producto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Producto actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }

        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Producto producto = _dbContext.Productos.Find(id);

            if (producto == null)
            {
                return BadRequest("Producto No encontrado");
            }
            try
            {
                _dbContext.Productos.Remove(producto);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Producto eliminado Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });

            }
        }
    }
}
