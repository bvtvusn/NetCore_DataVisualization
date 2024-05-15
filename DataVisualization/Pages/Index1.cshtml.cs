using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DataVisualization.Pages
{
    public class Index1Model : PageModel
    {
        //private PieConfig _config;
        public List<double> chartData = new List<double> { 1, 2, 3, 4, 5 };
        public void OnGet()
        {
            
        }
    }
}
