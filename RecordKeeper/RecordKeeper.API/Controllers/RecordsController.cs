using Microsoft.AspNetCore.Mvc;
using RecordKeeper.Service;
using System.Linq;

namespace RecordKeeper.API.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        private IRecordsService _recordsService;
        public RecordsController(IRecordsService service)
        {
            _recordsService = service;
        }

        // GET api/records/gender
        [HttpGet]
        [Route("gender")]
        public IActionResult GetByGender()
        {
            return Ok(_recordsService.GetAll().OrderBy(p => p.Gender)
                .ThenBy(p => p.LastName)
                .ToList());
        }

        // GET api/records/birthdate
        [HttpGet]
        [Route("birthdate")]
        public IActionResult GetByDOB()
        {
            return Ok(_recordsService.GetAll().OrderBy(p => p.DateOfBirth)
                .ToList());
        }

        // GET api/records/name
        [HttpGet]
        [Route("name")]
        public IActionResult GetByName()
        {
            return Ok(_recordsService.GetAll().OrderByDescending(p => p.LastName).ToList());
        }

        // POST api/records
        [HttpPost]
        public IActionResult Post([FromBody]string input)
        {
            try
            {
                _recordsService.AddFromString(input);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
