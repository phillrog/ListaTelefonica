using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.DTO;
using ListaTelefonica.Domain.Entities;
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
        public async Task<IActionResult> Post([FromBody] PersonDTO person)
        {
	        if (!ModelState.IsValid)
		        return BadRequest(ModelState);

	        var personCreate = _mapper.Map<Person>(person);

	        var response = await _uow.PersonAppService.Create(personCreate);

	        await _uow.CommitAsync();

			return Ok(response);
		}

        // PUT: api/Person/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonDTO person)
        {
	        if (!ModelState.IsValid)
		        return BadRequest(ModelState);

			var personUpdate = _mapper.Map<Person>(person);

	        var response = await _uow.PersonAppService.Update(personUpdate);
	        
	        await _uow.CommitAsync();

	        return Ok(response);
		}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var response = await _uow.PersonAppService.Delete(id);

			await _uow.CommitAsync();

			return Ok(response);
		}

    }
}
