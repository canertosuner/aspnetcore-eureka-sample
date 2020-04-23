using Microsoft.AspNetCore.Mvc;

namespace EurekaApi.Controllers
{
    [Route("healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Api is UP !";
        }
    }
}