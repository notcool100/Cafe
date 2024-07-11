using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Order
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TableNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
