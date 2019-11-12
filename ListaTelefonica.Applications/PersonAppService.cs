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

		public async Task<bool> Create(Person person)
		{
			await _personService.Create(person);

			return true;
		}

		public async Task<bool> Update(Person person)
		{
			await _personService.Update(person);

			return true;
		}

		public async Task<bool> Delete(int id)
		{
			var person = await _personService.GetPersonById(id);
			await _personService.Delete(person);

			return true;
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
