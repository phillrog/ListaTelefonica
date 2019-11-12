using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Repositories;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Services
{
	public class PersonService : ServiceBase<Person>,IPersonService
	{
		private readonly IPersonRepository _personRepository;

		public PersonService(IPersonRepository personRepository) : base(personRepository)
		{
			_personRepository = personRepository;
		}
		public async Task Create(Person person)
		{
			await _personRepository.AddAsync(person);
		}

		public async Task Update(Person person)
		{
			await Task.Run(() =>
			{
				_personRepository.Update(person);
			});
		}

		public async Task Delete(Person person)
		{
			await Task.Run(() => 
			{
				_personRepository.Remove(person);
			});
		}

		public async Task DeleteAll()
		{
			var listPerson = await _personRepository.GetAllAsync();

			_personRepository.RemoveRange(listPerson);
		}

		public async Task<Person> GetPersonById(int id)
		{
			return await _personRepository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<Person>> GetAllPerson()
		{
			return await _personRepository.GetAllAsync();
		}
	}
}
