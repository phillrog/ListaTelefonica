using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ListaTelefonica.Applications.Commands.PersonPhone;
using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.EntitiesApp;
using ListaTelefonica.Applications.Interfaces;
using MediatR;

namespace ListaTelefonica.Applications.Handler
{
	public class PersonPhoneHandler : 
		IRequestHandler<PersonPhoneDeleteCommand, bool>
	{
		private readonly NotificationContext _notificationContext;
		private readonly IMediator _mediator;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public PersonPhoneHandler(IMediator mediator, IMapper mapper, IUnitOfWork uow,
			NotificationContext notificationContext)
		{
			_mediator = mediator;
			_uow = uow;
			_notificationContext = notificationContext;
			_mapper = mapper;
		}

		public async Task<bool> Handle(PersonPhoneDeleteCommand request, CancellationToken cancellationToken)
		{
			var phoneDeleteEntity = _mapper.Map<PersonPhoneDeleteEntity>(request);

			if (phoneDeleteEntity.Invalid)
			{
				_notificationContext.AddNotifications(phoneDeleteEntity.ValidationResult);
				return false;
			}

			var personDelete = await _uow.PersonPhoneAppService.GetPersonPhoneById(phoneDeleteEntity.Id);

			if (personDelete == null)
			{
				_notificationContext.AddNotification("Problemas ao deletar", "Telefone não encontrado");
				return false;
			}

			var totalPhones = await _uow.PersonPhoneAppService.GetTotalPhone(personDelete.PersonId);
			
			if (totalPhones.Count == 1)
			{
				_notificationContext.AddNotification("Problemas ao deletar", "Não é possível remover o último contato, apague o cadastro da pessoa completo");
				return false;
			}

			var response = await _uow.PersonPhoneAppService.Delete(phoneDeleteEntity.Id);

			await _uow.CommitAsync();

			return response;
		}
	}
}
