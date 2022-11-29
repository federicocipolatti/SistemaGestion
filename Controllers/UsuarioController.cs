using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.Repositories;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioRepository repository = new UsuarioRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> listaUsuario = repository.listarUsuario();
                return Ok(listaUsuario);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
