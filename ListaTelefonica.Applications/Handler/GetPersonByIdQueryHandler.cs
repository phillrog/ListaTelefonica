using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Applications.Querys;
using ListaTelefonica.Domain.Entities;
using MediatR;

namespace ListaTelefonica.Applications.Handler
{
	public class GetPersonByIdQueryHandler: IRequestHandler<GetPersonByIdQuery, Person>
	{
		private readonly IMediator _mediator;
		private readonly IUnitOfWork _uow;

		public GetPersonByIdQueryHandler(IMediator mediator, IUnitOfWork uow)
		{
			_mediator = mediator;
			_uow = uow;
	
		}

		public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
		{
			return await _uow.PersonAppService.GetPersonById(request.Id);
		}
	}
}
