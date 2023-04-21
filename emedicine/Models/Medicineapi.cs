using MedicineShop.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace emedicine.Models
{
    public class Medicineapi
    {

        public Response viewMedine(Medicines medicine,SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter da = new SqlDataAdapter("sp_viewMedicine", connection);
            da.SelectCommand.Parameters.AddWithValue("@ID", medicine.ID);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Medicine exists";
                Medicines med = new Medicines();

                med.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                med.Name = Convert.ToString(dt.Rows[0]["Name"]);
                med.Manufacturer = Convert.ToString(dt.Rows[0]["Manufacturer"]);
                med.UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]);
                med.Discount = Convert.ToDecimal(dt.Rows[0]["Discount"]);
                med.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
                med.ExpDate = Convert.ToDateTime(dt.Rows[0]["ExpDate"]);
                med.ImgUrl = Convert.ToString(dt.Rows[0]["ImgUrl"]);
                med.Type = Convert.ToString(dt.Rows[0]["Type"]);
                med.Status = Convert.ToInt32(dt.Rows[0]["Status"]);


                response.medicine=med;

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Medicine dose not exists";
                response.medicine = null;
            }

            return response;
        }

        public Response medicineList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("sp_medicineList", connection);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Medicines> medicineList = new List<Medicines>();
            if (dt.Rows.Count > 0)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Medicines med = new Medicines();

                    med.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    med.UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]);
                    med.Discount = Convert.ToDecimal(dt.Rows[0]["Discount"]);
                    med.ImgUrl = Convert.ToString(dt.Rows[0]["ImgUrl"]);
                    med.Type = Convert.ToString(dt.Rows[0]["Type"]);

                    medicineList.Add(med);

                }
                if (medicineList.Count > 0)
                {
                    response.statusMessage = "Medicines detailed fetched successfully";
                    response.statusCode = 200;
                    response.listMedicines = medicineList;
                }
                else
                {
                    response.statusMessage = "Medicines not exists";
                    response.statusCode = 100;
                    response.listMedicines = null;
                }

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Medicines dose not exists";
                response.listMedicines = null;
            }

            return response;
        }
        
    }
}
