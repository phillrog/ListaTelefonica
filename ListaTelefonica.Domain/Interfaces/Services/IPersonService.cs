using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Domain.DTO;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Interfaces.Services
{
	public interface IPersonService : IServiceBase<Person>
	{
		Task Create(Person person);
		Task Update(Person person);
		Task Delete(Person person);
		Task DeleteAll();
		Task<Person> GetPersonById(int id);
		Task<IEnumerable<Person>> GetAllPerson();
	}
}
