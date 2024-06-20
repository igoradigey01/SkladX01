
using Microsoft.AspNetCore.Mvc;

namespace SkladApi.Controllers
{

    public class VersionInfo
    {
        public string Version { get; set; } = "";
        public string Description { get; set; } = "";
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        string _version = "b2.06.24";
        string _description = "Api Sklad- вторая редакция ( aspnetcore -net8.0.6)(17.06.24)";






        [HttpGet]
        public VersionInfo Info()
        {
            return new VersionInfo { Version = _version, Description = _description }; // отправка в формате json  (-error parsing angular response)

        }

    }
}
