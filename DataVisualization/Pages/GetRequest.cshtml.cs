using DataVisualization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace DataVisualization.Pages
{
    public class GetRequestModel : PageModel
    {
        public void OnGet()
        {
        }
        public JsonResult OnGetFilter(string filterBy)
        {
            return new JsonResult(filterBy);
        }
        public JsonResult OnGetTable()
        {
            int[][] table = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
            //List<List<object>> list = new List<List<object>>();
            //list.Add(new List<int>() { 2,2});


            //DataTable table = new DataTable();
            //table.Columns.Add("ID", typeof(int));
            //table.Columns.Add("Name", typeof(string));
            //table.Columns.Add("Age", typeof(int));
            //table.Rows.Add(1, "John", 30);
            //table.Rows.Add(2, "Alice", 25);
            //table.Rows.Add(3, "Bob", 35);

            //Datapoint[] d = new Datapoint[] { new Datapoint(2,"sensor1"), new Datapoint(4, "sensor1"), new Datapoint(3, "sensor1") };
            Datapoint[] d =  ReadTempData();

            return new JsonResult(d);
        }


        private Datapoint[] ReadTempData()
        {
            List<Datapoint> pid_setpointData;
            List<Datapoint> pid_measTempData;
            //chartDataList = Datapoint.GetSensorDataSP(Database.Connectionstring, 1);

            pid_setpointData = Datapoint.GetSensorDataSP(Database.Connectionstring, 2,0.1);
            pid_measTempData = Datapoint.GetSensorDataSP(Database.Connectionstring, 4,0.1);
            //pid_outputData = Datapoint.GetSensorDataSP(Database.Connectionstring, 3);

            for (int i = 0; i < pid_setpointData.Count; i++)
            {
                pid_setpointData[i].Description = "sensor1";
            }
            for (int i = 0; i < pid_measTempData.Count; i++)
            {
                pid_measTempData[i].Description = "sensor2";
            }
            return pid_setpointData.Concat(pid_measTempData).ToArray();
            
        }

    }
}
