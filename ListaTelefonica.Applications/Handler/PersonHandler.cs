using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.EntitiesApp;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Entities;
using MediatR;

namespace ListaTelefonica.Applications.Handler
{
	public class PersonHandler : IRequestHandler<PersonCreateCommand, Person>,
		IRequestHandler<PersonUpdateCommand, bool>,
		IRequestHandler<PersonDeleteCommand, bool>
	{
		private readonly NotificationContext _notificationContext;
		private readonly IMediator _mediator;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public PersonHandler(IMediator mediator, IMapper mapper, IUnitOfWork uow,
			NotificationContext notificationContext)
		{
			_mediator = mediator;
			_uow = uow;
			_notificationContext = notificationContext;
			_mapper = mapper;
		}

		public async Task<Person> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
		{
			var personValidate = _mapper.Map<PersonEntity>(request);

			if (personValidate.Invalid)
			{
				_notificationContext.AddNotifications(personValidate.ValidationResult);
				return null;
			}

			var person = _mapper.Map<Person>(personValidate);
			
			await _uow.PersonAppService.Create(person);

			await _uow.CommitAsync();

			return person;
		}

		public async Task<bool> Handle(PersonUpdateCommand request, CancellationToken cancellationToken)
		{
			var personValidate = _mapper.Map<PersonUpdateEntity>(request);

			if (personValidate.Invalid)
			{
				_notificationContext.AddNotifications(personValidate.ValidationResult);
				return false;
			}

			var personUpdate = _mapper.Map<Person>(personValidate);

			var response = await _uow.PersonAppService.Update(personUpdate);

			await _uow.CommitAsync();

			return response;
		}

		public async Task<bool> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
		{
			var personValidate = _mapper.Map<PersonDeleteEntity>(request);

			if (personValidate.Invalid)
			{
				_notificationContext.AddNotifications(personValidate.ValidationResult);
				return false;
			}

			var personDelete = await _uow.PersonAppService.GetPersonById(personValidate.Id);

			if (personDelete == null)
			{
				_notificationContext.AddNotification("Problemas ao deletar", "Pessoa não encontrada");
				return false;
			}

			var response = await _uow.PersonAppService.Delete(personValidate.Id);

			await _uow.CommitAsync();

			return response;
		}
	}
}
