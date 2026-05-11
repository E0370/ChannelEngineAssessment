using Microsoft.AspNetCore.Mvc;
using EngineLibrary;
namespace EngineWeb.Controllers
{
    public class HomeController : Controller
    {
      public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var orderService = new OrderService(httpClient);
            var orders = await orderService.GetInProgressOrders();
            var topfive = orderService.GetTopFiveProducts(orders);
            return View(topfive);
        }
    }
}
