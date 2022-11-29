using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.Repositories;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaRepository repository = new VentaRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Venta> listaVenta= repository.listarVenta();
                return Ok(listaVenta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
