using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTradeMarket
{
    public class ProductViewModel
    {
        public string ProductCustomizeID { get; set; }
        public string ProductName { get; set; }
        public string ProductUnitName { get; set; }
        public string ProductTypeName { get; set; }

        public ProductViewModel()
        {
            ProductCustomizeID = "";
            ProductName = "";
            ProductUnitName = "";
            ProductTypeName = "";
        }
    }
}
