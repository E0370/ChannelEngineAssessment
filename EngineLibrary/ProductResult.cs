using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class ProductResult
    {
        public string ProductName { get; set; }
        public string Gtin { get; set; }
        public int TotalQuantity { get; set; }
        public string MerchantProductNo { get; set; }
        public int StockLocationId { get; set; }
    }
}
