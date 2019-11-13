using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Entities;
using MediatR;

namespace ListaTelefonica.Applications.Handler
{
	public class PersonHandler : IRequestHandler<PersonCreateCommand, Response>,
		IRequestHandler<PersonUpdateCommand, Response>,
		IRequestHandler<PersonDeleteCommand, Response>
	{
		private readonly IMediator _mediator;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public PersonHandler(IMediator mediator, IMapper mapper, IUnitOfWork uow)
		{
			_mediator = mediator;
			_uow = uow;
			_mapper = mapper;
		}

		public async Task<Response> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
		{
			var person = _mapper.Map<Person>(request);

			await _uow.PersonAppService.Create(person);

			await _uow.CommitAsync();

			return new Response("cadastrado com sucesso");
		}

		public async Task<Response> Handle(PersonUpdateCommand request, CancellationToken cancellationToken)
		{
			var personUpdate = _mapper.Map<Person>(request);

			var response = await _uow.PersonAppService.Update(personUpdate);

			await _uow.CommitAsync();

			return new Response("atualizado com sucesso");
		}

		public async Task<Response> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
		{
			var response = await _uow.PersonAppService.Delete(request.Id);

			await _uow.CommitAsync();

			return new Response("deletado com sucesso");
		}
	}
}
