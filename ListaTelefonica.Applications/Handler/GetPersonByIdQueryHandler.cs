using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.EntitiesApp;
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
		private readonly NotificationContext _notificationContext;
		private readonly IMapper _mapper;

		public GetPersonByIdQueryHandler(IMapper mapper , IMediator mediator, IUnitOfWork uow, NotificationContext notificationContext)
		{
			_mediator = mediator;
			_uow = uow;
			_notificationContext = notificationContext;
			_mapper = mapper;
		}

		public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
		{
			var getPersonByIdQueryValidate = _mapper.Map<GetPersonByIdQueryEntity>(request);

			if (getPersonByIdQueryValidate.Invalid)
			{
				_notificationContext.AddNotifications(getPersonByIdQueryValidate.ValidationResult);
				return null;
			}

			var person = await _uow.PersonAppService.GetPersonById(getPersonByIdQueryValidate.Id);

			if (person == null)
			{
				_notificationContext.AddNotification("Problemas ao buscar pessoa", "Pessoa não encontrada");
				return null;
			}

			return person;
		}
	}
}
