using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataVisualization.Models;

namespace DataVisualization.Pages
{
    public class MeasurementModel : PageModel
    {
        public List<Datapoint> Datapoints { get; set; }
        public void OnGet()
        {
            
            Datapoints = Datapoint.GetSensorDataSP(Database.Connectionstring, 1);
        }
    }
}
