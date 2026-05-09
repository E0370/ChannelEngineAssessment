namespace EngineLibrary
{
    public class Order
    {
        public string Status { get; set; }
        public List<OrderItem>Lines { get; set; }
    }
}
