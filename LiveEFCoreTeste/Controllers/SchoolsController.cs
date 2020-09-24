using Microsoft.AspNetCore.Mvc;

namespace LiveEFCoreTeste.Controllers
{
    [Route("api/[controller]")]
    public class SchoolsController : ControllerBase
    {
        public SchoolsController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Adicionar School e Retornar todas

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // GET por Id

            return Ok();
        }

        [HttpGet("{id}/popular")]
        public IActionResult Post(int id)
        {
            // Trazer School por Id e com Students e ContactInformation, e 

            return Ok();
        }
    }
}
