using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.Repositories;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoRepository repository = new ProductoVendidoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProductoVendido> listaProductoVendido = repository.listarProductoVendido();
                return Ok(listaProductoVendido);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
