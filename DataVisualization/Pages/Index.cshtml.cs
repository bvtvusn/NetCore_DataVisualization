using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using DataVisualization.Models;


namespace DataVisualization.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string myCar;
        //public string companyName;
        public Company company;
        public List<Datapoint> datapoints;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ////Company myCompany = new Company();
            //company =  myCompany.GetCompanyData();// GetData();
            //myCar = "Ford";

            //datapoints = Datapoint.GetSensorData(1);
        }

        

    }
}