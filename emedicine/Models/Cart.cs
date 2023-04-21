using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public int MedicineId { get; set; }

        public decimal TotalPrice { get; set; }

    }
}