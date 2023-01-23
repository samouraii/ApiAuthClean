using APiAuthTest.Model.UserModel;
using APiAuthTest.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiAuthTest.Controllers
{

    public class Per
    {
        public IEnumerable<Personne> per { get; set; } 
    }
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        IUserService userservice;

        public PersonneController(IUserService userservice)
        {
            this.userservice = userservice;
        }


        // GET: api/<PersonneController>

        

        [HttpGet]
        public IEnumerable<Personne> Get()
        {
            return this.userservice.GetPersonnes() ;
        }

        // GET api/<PersonneController>/5
        [HttpGet("{id}")]
        public Personne Get(int id)
        {
            return this.userservice.GetPersonne(id);
        }

        // POST api/<PersonneController>
        [HttpPost]
        public void Post([FromBody] PersonneDTO value)
        {
            Personne p = new Personne { FirstName = value.FirstName, Name = value.Name };
        
            this.userservice.PostPersonnes(p);
        }

        // PUT api/<PersonneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PersonneDTO value)
        {
            this.userservice.PutPersonnes(value, id);
        }

        // DELETE api/<PersonneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.userservice.DelPersonnes(id);
        }
    }
}
