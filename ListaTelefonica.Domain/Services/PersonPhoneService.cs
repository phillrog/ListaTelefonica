using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Repositories;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Services
{
	public class PersonPhoneService : ServiceBase<PersonPhone>,IPersonPhoneService
	{
		private readonly IPersonPhoneRepository _personPhoneRepository;


		public PersonPhoneService(IPersonPhoneRepository personPhoneRepository) : base(personPhoneRepository)
		{
			_personPhoneRepository = personPhoneRepository;
		}

		public async Task Delete(PersonPhone person)
		{
			await Task.Run(() =>
			{
				_personPhoneRepository.Remove(person);
			});
		}

		public async Task<PersonPhone> GetPersonPhoneById(int id)
		{
			return await _personPhoneRepository.GetByIdAsync(id);
		}
	}
}
