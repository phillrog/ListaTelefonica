using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ListaTelefonica.Domain.Interfaces.Contexts
{
	public interface IContext
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
		EntityEntry Add(object entity);
		EntityEntry Remove(object entity);
		EntityEntry Update(object entity);
		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
	}
}
