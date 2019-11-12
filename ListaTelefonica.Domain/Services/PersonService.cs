using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Repositories;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Services
{
	public class PersonService : ServiceBase<Person>,IPersonService
	{
		private readonly IPersonRepository _personRepository;

		public async Task Create(Person person)
		{
			await _personRepository.AddAsync(person);
		}


		public PersonService(IPersonRepository personRepository) : base(personRepository)
		{
			_personRepository = personRepository;
		}
	}
}
