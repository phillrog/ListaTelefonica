using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Domain.DTO;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Interfaces.Services
{
	public interface IPersonPhoneService : IServiceBase<PersonPhone>
	{
		Task Delete(PersonPhone phone);
		Task<PersonPhone> GetPersonPhoneById(int id);
	}
}
