using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class OrderItem
    {
        public string Description { get; set; }
        public string Gtin { get; set; }
        public int Quantity { get; set; }
        public string MerchantProductNo { get; set; }
        public StockLocation StockLocation { get; set; }
    }
}
