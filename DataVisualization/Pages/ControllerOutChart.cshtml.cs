using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataVisualization.Models;

namespace DataVisualization.Pages
{
    public class ControllerOutChartModel : PageModel
    {        
        public List<ChartRow> pid_chartData2 = new List<ChartRow>();
        public List<Datapoint> pid_outputData = new List<Datapoint>();

        public void OnGet()
        {           
            pid_outputData = Datapoint.GetSensorDataSP(Database.Connectionstring, 3);
            int resolution = pid_outputData.Count;
            pid_chartData2.Clear();
            for (int i = 0; i < resolution; i++)
            {
                ChartRow myRow = new ChartRow();
                myRow.datetime = pid_outputData[i].Timestamp.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                myRow.c1 = pid_outputData[i].Value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);               
                pid_chartData2.Add(myRow);

            }
        }
    }
}
