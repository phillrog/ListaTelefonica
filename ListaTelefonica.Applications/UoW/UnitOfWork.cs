using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Applications.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly IPersonAppService _personAppService;
		protected readonly IPersonPhoneAppService _personPhoneAppService;
		private readonly IContext _context;
		public IPersonAppService PersonAppService => _personAppService;
		public IPersonPhoneAppService PersonPhoneAppService => _personPhoneAppService;

		public UnitOfWork(IContext context, IPersonAppService personService, IPersonPhoneAppService personPhoneService)
		{
			_context = context;
			_personAppService = personService;
			_personPhoneAppService = personPhoneService;
		}

		public void Dispose()
		{
			(_context as DbContext).Dispose();
		}

		public Task<int> CommitAsync()
		{
			return _context.SaveChangesAsync();
		}
	}
}
