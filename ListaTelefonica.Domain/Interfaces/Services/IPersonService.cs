using System.Threading.Tasks;
using ListaTelefonica.Domain.DTO;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Interfaces.Services
{
	public interface IPersonService : IServiceBase<Person>
	{
		Task Create(Person person);
	}
}
