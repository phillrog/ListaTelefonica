using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;

namespace ListaTelefonica.Applications.Interfaces
{
	public interface IPersonPhoneAppService: IAppServiceBase<PersonPhone>
	{
		Task<bool> Delete(int id);
		Task<PersonPhone> GetPersonPhoneById(int id);
		Task<IList<PersonPhone>> GetTotalPhone(int idPerson);
	}

}
