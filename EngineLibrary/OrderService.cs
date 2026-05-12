using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string BaseUrl = "https://api-dev.channelengine.net/api/v2";

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetInProgressOrders()
        {
            var url = $"{BaseUrl}/orders?statuses=IN_PROGRESS&apiKey={ApiKey}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse>(json);
            return result.Content;
        }

        public List<ProductResult> GetTopFiveProducts(List<Order> orders)
        {
            var productTotals = new Dictionary<string, ProductResult>();
            // Loop through each order and its lines (Orderitem) to calculate total quantities for each product
            foreach (var order in orders) 
            {
                foreach (var item in order.Lines) 
                {
                    if (productTotals.ContainsKey(item.Gtin))
                    {
                        productTotals[item.Gtin].TotalQuantity += item.Quantity;
                    }
                    else
                    {
                        productTotals[item.Gtin] = new ProductResult
                        {
                            Gtin = item.Gtin,
                            ProductName = item.Description,
                            TotalQuantity = item.Quantity,
                            MerchantProductNo = item.MerchantProductNo,
                            StockLocationId = item.StockLocation.Id
                        };
                    }
                }
            }
            return productTotals.Values.OrderByDescending(p => p.TotalQuantity).Take(5).ToList();
        }

        // This method updates the stock for a specific product.
        public async Task UpdateStock(string merchantProductNo, int stockLocationId) 
        {
            var url = $"{BaseUrl}/offer/stock?apiKey={ApiKey}";
            var stockUpdate = new List<StockUpdate>
            {
                new StockUpdate
                {
                    MerchantProductNo = merchantProductNo,
                    StockLocations = new List<StockLocationUpdate>
                    {
                        new StockLocationUpdate
                        {
                            Stock = 25,
                            StockLocationId = stockLocationId
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(stockUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(url, content);
           
        }
    }
}
