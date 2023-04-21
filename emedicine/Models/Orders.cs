using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderTotal { get; set; }
        public int MyProperty { get; set; }
        public string OrderStatus { get; set; }


    }
}