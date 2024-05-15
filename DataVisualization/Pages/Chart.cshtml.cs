using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataVisualization.Models;

namespace DataVisualization.Pages
{
    public struct ChartRow
    {
        public string datetime;
        public string c1;
        public string c2;
    }
    public class ChartModel : PageModel
    {
        public List<Datapoint> chartDataList = new List<Datapoint>();
        public List<Datapoint> pid_setpointData = new List<Datapoint>();
        public List<Datapoint> pid_measTempData = new List<Datapoint>();
        public List<Datapoint> pid_outputData = new List<Datapoint>();

        public List<ChartRow> pid_chartData = new List<ChartRow>();
        public void OnGet()
        {

            chartDataList = Datapoint.GetSensorDataSP(Database.Connectionstring, 1);

            pid_setpointData = Datapoint.GetSensorDataSP(Database.Connectionstring, 2);
            pid_measTempData = Datapoint.GetSensorDataSP(Database.Connectionstring, 4);
            pid_outputData = Datapoint.GetSensorDataSP(Database.Connectionstring, 3);

            int resolution = Math.Min(pid_setpointData.Count, pid_measTempData.Count);
            pid_chartData.Clear();
            for (int i = 0; i < resolution; i++)
            {
                ChartRow myRow = new ChartRow();
                myRow.datetime = pid_setpointData[i].Timestamp.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                myRow.c1 = pid_setpointData[i].Value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                myRow.c2 = pid_measTempData[i].Value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                //string[] row = new string[] { pid_setpointData[i].Timestamp.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), pid_setpointData[i].Value.ToString(), pid_measTempData[i].Value.ToString() };
                
                //string[] row = new string[] { pid_setpointData[i].Timestamp.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), pid_setpointData[i].Value.ToString(), pid_measTempData[i].Value.ToString() };
                
                pid_chartData.Add(myRow);

            }
        }
    }
}
