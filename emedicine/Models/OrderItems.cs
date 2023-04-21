using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class OrderItems
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { set; get; }


    }
}