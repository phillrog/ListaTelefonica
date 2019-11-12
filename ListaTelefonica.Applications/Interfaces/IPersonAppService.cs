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
		Task<bool> Create(Person person);
		Task<bool> Update(Person person);
		Task<bool> Delete(int id);
		Task DeleteAll();
		Task<Person> GetPersonById(int id);
		Task<IEnumerable<Person>> GetAllPerson();
	}

}
