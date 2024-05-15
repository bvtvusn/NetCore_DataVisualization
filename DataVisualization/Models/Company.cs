using Microsoft.Data.SqlClient;


namespace DataVisualization.Models
{
    public class Company
    {
        public string Companyname { get; set; }
        //public string Companyname { get; set; }
        public Company GetCompanyData()
        {


            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            string connectionstring = "Server=tcp:iotwarehouse.database.windows.net,1433;Initial Catalog=iotdb;Persist Security Info=False;User ID=myuser;Password=mypass;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=1;";
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string query = "SELECT * FROM COMPANY";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;

            Company myCompany = new Company();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                myCompany.Companyname = dr["CompanyName"].ToString();
            }
            con.Close();
            return myCompany;
        }
    }
}
