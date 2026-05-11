using EngineLibrary;

var httpClient = new HttpClient();
var orderService = new OrderService(httpClient);
// Fetch in-progress orders and calculate the top five products based on total quantity
var orders = await orderService.GetInProgressOrders();
var topfive = orderService.GetTopFiveProducts(orders);

foreach (var product in topfive)
{
    Console.WriteLine($"Product: {product.ProductName}, GTIN: {product.Gtin}, Total Quantity: {product.TotalQuantity}");
}