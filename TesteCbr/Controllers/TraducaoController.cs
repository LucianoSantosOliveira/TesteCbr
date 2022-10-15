using Microsoft.AspNetCore.Mvc;
using TesteCbr.Models;
using TesteCbr.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteCbr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraducaoController : ControllerBase
    {
        private readonly TraducaoService _traducaoService;

        public TraducaoController()
        {
            _traducaoService = new TraducaoService();
        }

        // GET: api/<TraducaoController>
        [HttpGet]
        public IEnumerable<TraducaoModel> Get()
        {
            return _traducaoService.GetAllTraducoes();
        }

        // GET api/<TraducaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TraducaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TraducaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TraducaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
