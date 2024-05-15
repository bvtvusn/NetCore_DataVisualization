
using Microsoft.Data.SqlClient;

namespace DataVisualization.Models
{
    public class Datapoint
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
        public int SensorId { get; set; }
        public string Description { get; set; }
        public Datapoint(double value, string description, DateTime timestamp, int iD, int sensorId)
        {
            ID = iD;
            Timestamp = timestamp;
            Value = value;
            SensorId = sensorId;
            Description = description;
        }
        public Datapoint(double value, string description)
        {
            Value = value;            
            Description = description;
        }
        public Datapoint()
        {
           
        }

        public static List<Datapoint> GetSensorDataSP(string connectionstring, int sensorid, double hours = 1)
        {

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            DateTime end = DateTime.Now;
            DateTime start = end - TimeSpan.FromHours(hours);

            SqlCommand cmd = new SqlCommand("ReadDatapointsInRange", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sensor_id",sensorid));
            cmd.Parameters.Add(new SqlParameter("@start_timestamp", start));
            cmd.Parameters.Add(new SqlParameter("@end_timestamp", end));            
            SqlDataReader dr = cmd.ExecuteReader();




            List<Datapoint> datapoints = new List<Datapoint>();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Datapoint dp = new Datapoint();
                    dp.ID = Convert.ToInt32(dr["ID"]);
                    dp.Timestamp = Convert.ToDateTime(dr["timestamp"]); // dr.GetDateTime("timestamp"); // 
                    dp.Value = Convert.ToDouble(dr["value"]);
                    dp.SensorId = Convert.ToInt32(dr["sensor_id"]);
                    datapoints.Add(dp);
                }
            }

            
            con.Close();
            return datapoints;
        }

        public static List<Datapoint> GetSensorData(string connectionstring, int sensorid)
        {

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string query = "SELECT * FROM Datapoint WHERE sensor_id = " + sensorid.ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;

            Company myCompany = new Company();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Datapoint> datapoints = new List<Datapoint>();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Datapoint dp = new Datapoint();

                    dp.ID = Convert.ToInt32(dr["ID"]);
                    dp.Timestamp = Convert.ToDateTime(dr["timestamp"]); // dr.GetDateTime("timestamp"); // 
                    dp.Value = Convert.ToDouble(dr["value"]);
                    dp.SensorId = Convert.ToInt32(dr["sensor_id"]);
                    datapoints.Add(dp);
                }
            }
            if (dr.Read())
            {
                myCompany.Companyname = dr["CompanyName"].ToString();
            }
            con.Close();
            return datapoints;
        }

    }
}
