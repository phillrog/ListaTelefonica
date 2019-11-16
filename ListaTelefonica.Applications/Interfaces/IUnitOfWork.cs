using System;
using System.Threading.Tasks;

namespace ListaTelefonica.Applications.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IPersonAppService PersonAppService { get; }
		IPersonPhoneAppService PersonPhoneAppService { get; }
		Task<int> CommitAsync();
	}
}
