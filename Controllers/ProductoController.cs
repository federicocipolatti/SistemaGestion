using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Repositories;
using System.Net;
using SistemaGestion.Models;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductoRepository repository = new ProductoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Producto> listaProducto = repository.listarProducto();
                return Ok(listaProducto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
