using LiveEFCoreTeste.Entities;
using LiveEFCoreTeste.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LiveEFCoreTeste.Controllers
{
    [Route("api/[controller]")]
    public class SchoolsController : ControllerBase
    {
        private readonly LiveEfCoreDbContext _liveEfCoreDbContext;
        public SchoolsController(LiveEfCoreDbContext liveEfCoreDbContext)
        {
            _liveEfCoreDbContext = liveEfCoreDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Adicionar School e Retornar todas
            var school = new School("Escola daora 3");

            _liveEfCoreDbContext.Schools.Add(school);
            _liveEfCoreDbContext.SaveChanges();

            return Ok(school);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // GET por Id
            var school = _liveEfCoreDbContext.Schools
                .Include(s => s.Students)
                .Include(s => s.ContactInformation)
                .SingleOrDefault(s => s.Id == id);

            return Ok(school);
        }

        [HttpGet("{id}/popular")]
        public IActionResult Post(int id)
        {
            // Trazer School por Id e com Students e ContactInformation
            var school = _liveEfCoreDbContext
                .Schools
                .Include(s => s.Students)
                .Include(s => s.ContactInformation)
                .SingleOrDefault(s => s.Id == id);

            school.AddContactInformation("rua zero");
            school.AddStudent("Estudante zero");

            _liveEfCoreDbContext.SaveChanges();

            return Ok();
        }
    }
}
