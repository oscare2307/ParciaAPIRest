using Microsoft.AspNetCore.Mvc;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private static List<Pedidos> list = new List<Pedidos>()
        {

            new() { Id = 1, Descripcion = "Hamburguesa con papas", Productos = 1, direccionRecogida = "Calle 12 # 12 - 87", direccionEnvio = "Calle 37 # 13 - 104", estadoPedido ="Reparto" },
            new() { Id = 2, Descripcion = "Sanchipapa sin gratin", Productos = 2, direccionRecogida = "Calle 10 # 9 - 70", direccionEnvio = "Calle 20 # 18 - 100", estadoPedido ="Reparto" },
            new() { Id = 3, Descripcion = "Salchipapa con gratin", Productos = 1, direccionRecogida = "Calle 9 # 12 - 32", direccionEnvio = "Calle 11 # 21 - 112", estadoPedido= "Entregado"},
            new() { Id = 4, Descripcion = "Picada Mixta", Productos = 1, direccionRecogida = "CRA 12 # 9 - 24", direccionEnvio = "CRA 10 # 6 - 12", estadoPedido ="Entregado" },
            new() { Id = 5, Descripcion = "Carne Asada", Productos = 4, direccionRecogida = "CRA 15 # 14- 108", direccionEnvio = "CRA 11 # 5 - 24", estadoPedido = "Entregado" },
            new() { Id = 6, Descripcion = "Pizza Jaguayana", Productos = 5, direccionRecogida = "CRA 14 # 18- 108", direccionEnvio = "CRA 19 # 15- 89", estadoPedido = "Reparto" },
            new() { Id = 7, Descripcion = "Perro Caliente y gaseosa", Productos = 2, direccionRecogida = "CRA 37 # 14- 105", direccionEnvio = "CRA 25 # 12- 76", estadoPedido ="Reparto"  },
            new() { Id = 8, Descripcion = "2 Pizza con carne", Productos = 2, direccionRecogida = "Calle 38 # 22 - 82", direccionEnvio ="Calle 18 # 23 - 55", estadoPedido = "Reparto" },
            new() { Id = 9, Descripcion = "2 Perros suizos", Productos = 2, direccionRecogida = "Calle 8 # 10 - 12", direccionEnvio = "Calle 9 # 12 - 32", estadoPedido = "Reparto" },
            new() { Id = 10, Descripcion = "10 pizzas con jamon",Productos= 10, direccionRecogida = "Calle 45 # 30 - 120", direccionEnvio = "Calle 30 # 19- 104", estadoPedido = "Entregado" },

    };

        public static List<Pedidos> List { get => list; set => list = value; }

        [HttpGet]
        public ActionResult<List<Pedidos>> Get()
        {

            return List;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedidos> Get(int id)
        {

            Pedidos PedidoEncontrado = List.Find(x => x.Id == id);

            if (PedidoEncontrado is not null)
            {

                return Ok(PedidoEncontrado);

            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Pedidos> Post([FromBody] Pedidos pedidos)
        {

            List.Add(pedidos);
            return Ok(pedidos);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pedidos pedidos)
        {
            Pedidos PedidoEncontrado = List.Find(x => x.Id == id);

            if (PedidoEncontrado is not null)
            {

                PedidoEncontrado.Descripcion = pedidos.Descripcion;
                PedidoEncontrado.Productos = pedidos.Productos;
                PedidoEncontrado.direccionRecogida = pedidos.direccionRecogida;
                PedidoEncontrado.direccionEnvio = pedidos.direccionEnvio;
                PedidoEncontrado.estadoPedido = pedidos.estadoPedido;

                return Ok($"Pedido {id} actualizado correctamente");
            }



            return NotFound("No se encontró el elemento a actualizar");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Pedidos PedidoEncontrado = List.Find(x => x.Id == id);

            if (PedidoEncontrado is not null)
            {
                List.Remove(PedidoEncontrado);
                return Ok($"Pedido {id} borrado");

            }

            return NotFound("No se encontró el elemento a borrar");

        }
        
    }

}
    
 
