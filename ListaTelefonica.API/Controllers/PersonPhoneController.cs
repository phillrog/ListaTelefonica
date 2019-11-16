using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Commands.PersonPhone;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Applications.Querys;
using ListaTelefonica.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	/// <summary>
	/// Controller para efetuar operações CRUD com telefone
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseApiController
    {
	    private readonly IMediator _mediator;
		public PersonPhoneController(IUnitOfWork uow, IMapper mapper, IMediator mediator) : base(uow, mapper)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Método para apagar fisicamente o cadastro de telefone de uma pessoa
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
			var command =  _mapper.Map<PersonPhoneDeleteCommand>(id);

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
