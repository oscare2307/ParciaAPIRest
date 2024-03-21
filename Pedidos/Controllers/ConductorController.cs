using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {

        private static List<Conductor> list = new List<Conductor>()
        {

            new() { Id = 1, Nombres = "Oscar Julian", Apellidos = "Escobar Camaño", Licenciatransito = "ABC12345", Fechanacimiento = "1980-02-12" },
            new() { Id = 2, Nombres = "Jesus David", Apellidos = "Jimenez vergara", Licenciatransito = "GAHB1209", Fechanacimiento ="2000-03-04" },
            new() { Id = 3, Nombres = "Eduardo Francisco", Apellidos = "Mier Corpas",Licenciatransito = "ASDFG909", Fechanacimiento ="1980-12-08 "},
            new() { Id = 4, Nombres = "Moises Eduardo", Apellidos = "Castro Quiroz", Licenciatransito = "CVBNM12", Fechanacimiento = "1999-05-30" },

    };

        public static List<Conductor> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Conductor>> Get()
        {

            return List;
        }


        [HttpPost]
        public ActionResult<Conductor> Post([FromBody] Conductor conductor)
        {

            List.Add(conductor);
            return Ok(conductor);
        }
    }
}
