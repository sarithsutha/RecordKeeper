using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecordKeeper.API.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        // GET api/records
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
