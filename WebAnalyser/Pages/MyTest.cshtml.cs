using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAnalyser.Pages
{
    public class MyTestModel : PageModel
    {
        private TrafficLoad trafficLoad;
        public IEnumerable<Square> Trafic { get; set; }
        public MyTestModel(TrafficLoad trafficLoad)
        {
            this.trafficLoad = trafficLoad;
        }
        public void OnGet()
        {
            Trafic = trafficLoad.GetTotalTrafficLoad();
        }
    }
}
