using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Contexts;
using ListaTelefonica.Domain.Interfaces.Repositories;

namespace ListaTelefonica.Infra.Data.Repositories
{
	public class PersonPhoneRepository : RepositoryBase<PersonPhone>, IPersonPhoneRepository
	{
		private readonly IContext _context;

		public PersonPhoneRepository(IContext context) : base(context)
		{
			_context = context;
		}
	}
}