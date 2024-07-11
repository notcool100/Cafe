using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Order
{
    public class OrderCreateDto
    {
        public int TableNumber { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}
