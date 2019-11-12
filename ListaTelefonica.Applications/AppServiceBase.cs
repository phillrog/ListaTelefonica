using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Applications
{
	public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
	{
		private readonly IServiceBase<TEntity> _serviceBase;

		public AppServiceBase(IServiceBase<TEntity> serviceBase)
		{
			_serviceBase = serviceBase;
		}


		public async Task AddAsync(TEntity entity)
		{
			await _serviceBase.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await _serviceBase.AddRangeAsync(entities);
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _serviceBase.Find(predicate);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _serviceBase.GetAllAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _serviceBase.GetByIdAsync(id);
		}

		public void Remove(TEntity entity)
		{
			_serviceBase.Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_serviceBase.RemoveRange(entities);
		}

		public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _serviceBase.SingleOrDefaultAsync(predicate);
		}

		public void Dispose()
		{
			_serviceBase.Dispose();
		}
	}
}
