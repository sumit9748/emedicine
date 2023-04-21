using emedicine.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { set; get; }

        public List<Users> listUsers { set; get; }
        public Users users { get; set; }

        public List<Medicines> listMedicines { set; get; }
        public Medicines medicine { set; get; }

        public List<Cart> listCart { set; get; }

        public List<Orders> listOrders { set; get; }
        public Orders order { set; get; }
        public List<OrderItems> listOrderItems { set; get; }
        public OrderItems orderItem { get; set; }

    }
}