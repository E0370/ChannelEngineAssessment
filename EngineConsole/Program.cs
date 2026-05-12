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
// Update the stock for the top product to 25
var updateProductStock = topfive.First();
await orderService.UpdateStock(updateProductStock.MerchantProductNo);
Console.WriteLine($"Stock updated to 25 for {updateProductStock.ProductName}");