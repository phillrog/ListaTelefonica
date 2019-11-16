using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Applications
{
	public class PersonPhoneAppService : AppServiceBase<PersonPhone>, IPersonPhoneAppService
	{
		private readonly IPersonPhoneService _personPhoneService;

		public PersonPhoneAppService(IPersonPhoneService personPhoneService) : base(personPhoneService)
		{
			_personPhoneService = personPhoneService;
		}

		public async Task<bool> Delete(int id)
		{
			var person = await _personPhoneService.GetPersonPhoneById(id);
			await _personPhoneService.Delete(person);

			return true;
		}

		public async Task<PersonPhone> GetPersonPhoneById(int id)
		{
			return await _personPhoneService.GetPersonPhoneById(id);
		}

		public async Task<IList<PersonPhone>> GetTotalPhone(int idPerson)
		{
			return await _personPhoneService.GetAllAsync(d=> d.PersonId == idPerson);
		}
	}
}
