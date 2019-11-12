using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;

namespace ListaTelefonica.Applications.Interfaces
{
	public interface IPersonAppService: IAppServiceBase<Person>
	{
		Task Create(Person person);
		Task Update(Person person);
		Task Delete(Person person);
		Task DeleteAll();
		Task<Person> GetPersonById(int id);
		Task<IEnumerable<Person>> GetAllPerson();
	}

}
