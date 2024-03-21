using Microsoft.AspNetCore.Mvc;

namespace Productos.Controller
{
    [ApiController]
[Route("[controller]")]

    public class ProductosController : ControllerBase
    {
        private static List<Productos> list = new List<Productos>()
        {

            new() { Id = 1, Codigo = "AGSH123", Descripcion = "Proteina Gym", Marca = "TNT", Categoria ="Suplementos", Estado = "Reparto"},
            new() { Id = 2, Codigo = "ABC456", Descripcion = "Mause", Marca = "Logitech", Categoria ="Tecnologia", Estado = "Entredo"},
            new() { Id = 3, Codigo = "DHF678", Descripcion = "Portatiles", Marca = "HP", Categoria ="Tecnologia", Estado = "Reparto"},
            new() { Id = 4, Codigo = "JKE4567", Descripcion = "Calzado", Marca = "Gucci", Categoria ="Moda", Estado = "Reparto"},
            new() { Id = 5, Codigo = "ACH2139", Descripcion = "Reloj", Marca = "Cartier", Categoria ="Moda", Estado = "Entregado"},
    };
        public static List<Productos> List { get => list; set => list = value; }
        [HttpGet]

        public ActionResult<List<Productos>> Get() 
        {
            return List;
        }

        [HttpPost]
        public ActionResult<Productos> Post([FromBody] Productos producto)
        {
            
            List.Add(producto);
            return Ok(producto);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Productos producto)
        {
            Productos ProductoEncontrado = List.Find(x => x.Id == id);

            if (ProductoEncontrado is not null)
            {

                ProductoEncontrado.Codigo = producto.Codigo;
                ProductoEncontrado.Descripcion = producto.Descripcion;
                ProductoEncontrado.Marca = producto.Marca;
                ProductoEncontrado.Categoria = producto.Categoria;
                ProductoEncontrado.Estado = producto.Estado;

                return Ok($"Producto {id} actualizado correctamente");
            }


            return NotFound("No se encontró el elemento a actualizar");
        }
    }
}
