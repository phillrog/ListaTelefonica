using System.Collections.Generic;
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
	        var command = _mapper.Map<GetAllPersonQuery>(new GetAllPersonQuery());

	        var result = _mapper.Map<List<PersonResponseDTO>>(await _mediator.Send(command));

	        return Ok(result);
		}

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
			var command = _mapper.Map<GetPersonByIdQuery>(id);

			var result = _mapper.Map<PersonResponseDTO>(await _mediator.Send(command));

			return Ok(result);
        }

        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonDTO person)
        {
			var command = _mapper.Map<PersonCreateCommand>(person);
			var result = _mapper.Map<PersonResponseDTO>(await _mediator.Send(command));
			
			return Created($"api/person/{result.Id}", result);
		}

		// PUT: api/Person/5
		[HttpPut]
		public async Task<IActionResult> PutAsync([FromBody] PersonDTO person)
		{
			var command = _mapper.Map<PersonUpdateCommand>(person);

			var result = _mapper.Map<bool>(await _mediator.Send(command));

			return Ok(result);
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var command =  _mapper.Map<PersonDeleteCommand>(id);

			var response = await _mediator.Send(command);

			return Ok(response);
		}

	}
}
