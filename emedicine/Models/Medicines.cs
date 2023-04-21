using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class Medicines
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Discount { set; get; }
        public int Quantity { set; get; }
        public DateTime ExpDate { set; get; }
        public string ImgUrl { set; get; }
        public int Status { set; get; }
        public string Type { set; get; }

    }
}