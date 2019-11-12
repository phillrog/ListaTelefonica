using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Contexts;
using ListaTelefonica.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Infra.Data.Repositories
{
	public class PersonRepository : RepositoryBase<Person>, IPersonRepository
	{
		public PersonRepository(IContext context) : base(context)
		{
		}
	}
}