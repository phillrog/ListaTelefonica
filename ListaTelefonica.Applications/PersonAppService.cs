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
	public class PersonAppService : AppServiceBase<Person>, IPersonAppService
	{
		private readonly IPersonService _personService;
		public PersonAppService(IPersonService personService) : base(personService)
		{
			_personService = personService;
		}

		public async Task Create(Person person)
		{
			await _personService.Create(person);
		}

		public async Task Update(Person person)
		{
			await _personService.Update(person);
		}

		public async Task Delete(Person person)
		{
			await _personService.Delete(person);
		}

		public async Task DeleteAll()
		{
			await _personService.DeleteAll();
		}

		public async Task<Person> GetPersonById(int id)
		{
			return await _personService.GetPersonById(id);
		}

		public async Task<IEnumerable<Person>> GetAllPerson()
		{
			return await _personService.GetAllPerson();
		}
	}
}
