using EngineLibrary;

namespace EngineTest
{
    public class OrderServiceTest
    {
        private readonly OrderService _orderService;
        public OrderServiceTest() 
        {
            _orderService = new OrderService(new HttpClient());
        }
        [Fact]
        public void GetTopFiveProducts_WithDummyData_ReturnsCorrectOrder()
        {
            var orders = new List<Order>
            {
                new Order 
                {
                    Status = "IN_PROGRESS",
                    Lines = new List<OrderItem>
                    {
                        new OrderItem { Description = "Red T-Shirt", Gtin = "111", Quantity = 2, MerchantProductNo = "MP1" },
                        new OrderItem { Description = "Blue Jeans", Gtin = "222", Quantity = 1, MerchantProductNo = "MP2" },
                    }
                },
                new Order
                {
                    Status = "IN_PROGRESS",
                    Lines = new List<OrderItem>
                    {
                        new OrderItem { Description = "Red T-Shirt", Gtin = "111", Quantity = 4, MerchantProductNo = "MP1" },
                        new OrderItem { Description = "Black Jeans", Gtin = "333", Quantity = 2, MerchantProductNo = "MP3" },
                    }
                },
                new Order
                {
                    Status = "IN_PROGRESS",
                    Lines = new List<OrderItem>
                    {
                        new OrderItem { Description = "Sneakers", Gtin = "444", Quantity = 3, MerchantProductNo = "MP4" },
                        new OrderItem { Description = "Bag", Gtin = "555", Quantity = 1, MerchantProductNo = "MP5" },
                    }
                }

            };

            var result = _orderService.GetTopFiveProducts(orders);

            Assert.Equal(5, result.Count);
            Assert.Equal("Red T-Shirt", result[0].ProductName);
            Assert.Equal(6, result[0].TotalQuantity);
            Assert.Equal("Sneakers", result[1].ProductName);
            Assert.Equal(3, result[1].TotalQuantity);
            Assert.Equal("Black Jeans", result[2].ProductName);
            Assert.Equal(2, result[2].TotalQuantity);
            Assert.Equal("Blue Jeans", result[3].ProductName);
            Assert.Equal(1, result[3].TotalQuantity);
            Assert.Equal("Bag", result[4].ProductName);
            Assert.Equal(1, result[4].TotalQuantity);
        }
    }
}