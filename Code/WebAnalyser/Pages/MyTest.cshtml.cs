using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAnalyser.Pages
{
    public class MyTestModel : PageModel
    {
        private TrafficLoad trafficLoad;
        public IEnumerable<Square> Trafic { get => trafficLoad.GetTotalTrafficLoad(); }
        public MyTestModel(TrafficLoad trafficLoad)
        {
            this.trafficLoad = trafficLoad;
        }
        public void OnGet()
        {
        }
    }
}
