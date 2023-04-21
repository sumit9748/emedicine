using MedicineShop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace emedicine.Models
{
    public class Cartapi
    {
        public Response addToCart(Cart cart,SqlConnection connection)
        {
            Response response = new Response();


            SqlCommand cmd=new SqlCommand("sp_AddtoCart",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", cart.UserId);
            cmd.Parameters.AddWithValue("@Price", cart.Price);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@MedicineId", cart.MedicineId);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Item added to cart";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Item counldnot added to cart";
            }
            return response;
        }

        public Response placeOrder(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", users.ID);
            connection.Open();
            int i= cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Order placed successfully";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Order cannot be placed";
            }

            return response;
        }

        public Response orderList(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType=CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);

            DataTable dt = new DataTable();
            List<Orders> orderList = new List<Orders>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);

                    orderList.Add(order);
                }
                if (orderList.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Oreder fetched successfully";
                    response.listOrders = orderList;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "Oreder cannot be fetched";
                    response.listOrders = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Oreder cannot be fetched";
                response.listOrders = null;
            }
            return response;
        }
    }
}
