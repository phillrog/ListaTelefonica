using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Applications.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly IPersonAppService _personAppService;
		private readonly IContext _context;
		public IPersonAppService PersonAppService => _personAppService;

		public UnitOfWork(IContext context, IPersonAppService personService)
		{
			_context = context;
			_personAppService = personService;
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
