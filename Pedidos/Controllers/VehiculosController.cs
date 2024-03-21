using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos;

namespace Vehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private static List<Vehiculos> list = new List<Vehiculos>()
        {

            new() { Id = 1, Matricula = "ABC123", Marca ="Toyota" ,Modelo = "Spark", },
            new() { Id = 2, Matricula = "DFH456", Marca ="Nissan" ,Modelo = "Sentra", },
            new() { Id = 3, Matricula = "OFGC321", Marca ="Chevrolet" ,Modelo = "Spark", },
            new() { Id = 4, Matricula = "QWE679", Marca ="Nissan" ,Modelo = "Spark", },


    };

        public static List<Vehiculos> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Vehiculos>> Get()
        {

            return List;
        }

        [HttpPost]
        public ActionResult<Vehiculos> Post([FromBody] Vehiculos vehiculos)
        {

            List.Add(vehiculos);
            return Ok(vehiculos);
        }
    }
}
