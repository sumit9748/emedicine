using MedicineShop.Models;
using Microsoft.Data.SqlClient;

using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;

namespace emedicine.Models
{
    public class Userapi
    {
        public Response register(Users users,SqlConnection connection)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("sp_Register",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Fund", 0);
            cmd.Parameters.AddWithValue("@Type", "users");
            cmd.Parameters.AddWithValue("@Status", "pending");
            connection.Open();
            int i=cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User registered successfully";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User registered failed";
            }



            return response;
        }
        public Response login(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User exists";
                Users user = new Users();

                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);

                response.users = user;

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User dose not exists";
                response.users = null;
            }

            return response;
        }
        public Response viewUser(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("sp_viewUser", connection);
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User exists";
                Users user = new Users();

                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);

                response.users = user;

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User dose not exists";
                response.users = null;
            }

            return response;
        }
        public Response viewUserList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("sp_viewUserList", connection);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Users> userList = new List<Users>();
            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User exists";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();

                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    user.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);

                    userList.Add(user);

                }
                if (userList.Count > 0)
                {
                    response.statusMessage = "Users detailed fetched successfully";
                    response.statusCode = 200;
                    response.listUsers = userList;
                }
                else
                {
                    response.statusMessage = "Users not exists";
                    response.statusCode = 100;
                    response.listUsers = null;
                }

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User dose not exists";
                response.users = null;
            }

            return response;
        }
        public Response updateProfile(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_UpdateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "User details updated successfully";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "User details can not be updated";
            }
            return response;

        }
    }
}
