namespace Pedidos
{
    public class Pedidos
    {
        public required int Id { get; set; } 
        public required string Descripcion { get; set; }
        public required int Productos { get; set; }
        public required string direccionRecogida { get; set; }
        public required string direccionEnvio { get; set; }
        public required string estadoPedido { get; set; }
    }
}
