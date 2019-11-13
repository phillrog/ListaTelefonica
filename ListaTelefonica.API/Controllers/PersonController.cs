using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Applications.Querys;
using ListaTelefonica.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseApiController
    {
	    private readonly IMediator _mediator;
		public PersonController(IUnitOfWork uow, IMapper mapper, IMediator mediator) : base(uow, mapper)
		{
			_mediator = mediator;
		}

		// GET: api/Person
		[HttpGet]
        public async Task<IActionResult> GetAsync()
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var response = _mapper.Map<IEnumerable<PersonDTO>>(await _uow.PersonAppService.GetAllPerson());

			return Ok(response);
		}

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
			//if (!ModelState.IsValid)
			// return BadRequest(ModelState);

			//var response = _mapper.Map<PersonDTO>(await _uow.PersonAppService.GetPersonById(id));

			var command = new GetPersonByIdQuery(id);

			var response = await _mediator.Send(command);

			return Ok(response);
        }

        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonDTO person)
        {
			var command = _mapper.Map<PersonCreateCommand>(person);
			var response = await _mediator.Send(command);

			if (response.Errors.Any())
			{
				return BadRequest(response.Errors);
			}

			return Ok(response.Result);
		}

        // PUT: api/Person/5
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PersonDTO person)
        {
			var command = _mapper.Map<PersonUpdateCommand>(person);

			var response = await _mediator.Send(command);

			if (response.Errors.Any())
			{
				return BadRequest(response.Errors);
			}

			return Ok(response.Result);
		}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
	        var command = new PersonDeleteCommand(id);

	        var response = await _mediator.Send(command);

	        return Ok(response.Result);
		}

    }
}
