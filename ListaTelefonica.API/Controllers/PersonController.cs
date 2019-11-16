using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Applications.Querys;
using ListaTelefonica.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	/// <summary>
	/// Controller para efetuar operações CRUD com pessoa
	/// </summary>
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
		/// <summary>
		/// Método para buscar todas as pessoas cadastradas
		/// </summary>
		/// <returns>Retorna lista de pessoas cadastradas</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAsync()
        {
	        var command = _mapper.Map<GetAllPersonQuery>(new GetAllPersonQuery());

	        var result = _mapper.Map<List<PersonResponseDTO>>(await _mediator.Send(command));

	        return Ok(result);
		}

		/// <summary>
		/// Método para uscar pessoa pelo seu Id 
		/// </summary>
		/// <param name="id">Número identificador da pessoa</param>
		/// <returns>Retorna os dados da pessoa selecionada</returns>
        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetByIdAsync(int id)
        {
			var command = _mapper.Map<GetPersonByIdQuery>(id);

			var result = _mapper.Map<PersonResponseDTO>(await _mediator.Send(command));

			return Ok(result);
        }

		/// <summary>
		/// Método para cadastrar uma nova pessoa
		/// </summary>
		/// <param name="person">Dados da pessoa</param>
		/// <returns>Retorna o objeto da pessoa com o Id</returns>
        // POST: api/Person
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> PostAsync([FromBody] PersonDTO person)
        {
			var command = _mapper.Map<PersonCreateCommand>(person);
			var result = _mapper.Map<PersonResponseDTO>(await _mediator.Send(command));
			
			return Created($"api/person/{result?.Id}", result);
		}

		/// <summary>
		/// Método para atualizar o cadastro de pessoa
		/// </summary>
		/// <param name="person">Dados da pessoa</param>
		/// <returns>Retorna true ou falso para indicar sucesso ou falha na atualização</returns>
		// PUT: api/Person/5
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> PutAsync([FromBody] PersonDTO person)
		{
			var command = _mapper.Map<PersonUpdateCommand>(person);

			var result = _mapper.Map<bool>(await _mediator.Send(command));

			return Ok(new {
				code = HttpStatusCode.OK,
				success = result,
				status = "updated"
			});
		}

		/// <summary>
		/// Método para apaar fisicamente o cadastro de uma pessoa
		/// </summary>
		/// <param name="id">Número identificador da pessoa</param>
		/// <returns>Retorna true ou falso para indicar sucesso ou falha na atualização</returns>
		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var command =  _mapper.Map<PersonDeleteCommand>(id);

			var response = await _mediator.Send(command);

			return Ok(new
			{
				code = HttpStatusCode.OK,
				success = response,
				status = "deleted"
			});
		}

	}
}
