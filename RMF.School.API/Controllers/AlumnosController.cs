using Microsoft.AspNetCore.Mvc;
using RMF.School.BLL;
using RMF.School.Entities;

namespace RMF.School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : Controller
    {
        AlumnoService _dbContext;
        public AlumnosController()
        {
            _dbContext = new AlumnoService();
        }

        [HttpGet]
        public IResult Get()
        {
            return Results.Ok(_dbContext.GetAll());
        }

        [HttpGet("{noControl}")]
        public IResult Get(long noControl)
        {
            return Results.Ok(_dbContext.Get(noControl));
        }
        [HttpPost]
        public IResult Post([FromBody] Alumno alumno)
        {
            return Results.Ok(_dbContext.Add(alumno));
        }

        [HttpPut]
        public IResult Put([FromBody] Alumno alumno)
        {
            return Results.Ok(_dbContext.Update(alumno));
        }

        [HttpDelete("{noControl}")]
        public IResult Delete(long noControl)
        {
            return Results.Ok(_dbContext.Delete(noControl));
        }
    }
}
