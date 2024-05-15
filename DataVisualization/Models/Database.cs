namespace DataVisualization.Models
{
    public class Database
    {
        public static string Connectionstring { get;  } = "Server=tcp:iotwarehouse.database.windows.net,1433;Initial Catalog=iotdb;Persist Security Info=False;User ID=myuser;Password=mypass;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    }
}
