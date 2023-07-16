using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FHIRSubscritionServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundleController : ControllerBase
    {
        private static string _bundle = "{}";
        private static readonly object _lockObject = new object();

        // GET: api/<BundleController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bundle);
        }

        // POST api/<BundleController>
        [HttpPost]
        public void Post([FromBody] JsonDocument value)
        {
            lock (_lockObject)
            {
                _bundle = value?.RootElement.ToString()??"{}";
            }
        }

        // PUT api/<BundleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonDocument value)
        {
            lock (_lockObject)
            {
                _bundle = value?.RootElement.ToString()??"{}";
            }
        }        
    }
}
