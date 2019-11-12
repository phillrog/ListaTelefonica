using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseApiController
    {
	    public PersonController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
	    {
	    }

		// GET: api/Person
		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
	        if (!ModelState.IsValid)
		        return BadRequest(ModelState);

	        var response = _mapper.Map<PersonDTO>(await _uow.PersonAppService.GetPersonById(id));

			return Ok(response);
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
