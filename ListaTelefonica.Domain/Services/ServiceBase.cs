using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Interfaces.Repositories;
using ListaTelefonica.Domain.Interfaces.Services;

namespace ListaTelefonica.Domain.Services
{
	public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> _repository;

		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			_repository = repository;
		}

		public async Task AddAsync(TEntity entity)
		{
			await _repository.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await _repository.AddRangeAsync(entities);
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _repository.Find(predicate);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public void Remove(TEntity entity)
		{
			_repository.Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_repository.RemoveRange(entities);
		}

		public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _repository.SingleOrDefaultAsync(predicate);
		}

		public void Dispose()
		{
			_repository.Dispose();
		}
	}
}