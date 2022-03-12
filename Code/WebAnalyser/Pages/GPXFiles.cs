using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAnalyser.Pages
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPXFiles : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "some";
        }
    }
}
