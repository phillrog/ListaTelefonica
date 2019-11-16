using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Interfaces.Contexts;
using ListaTelefonica.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Infra.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		protected readonly IContext Context;

		public RepositoryBase(IContext context)
		{
			this.Context = context;
		}

		public async Task AddAsync(TEntity entity)
		{
			await Context.Set<TEntity>().AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await Context.Set<TEntity>().AddRangeAsync(entities);
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().Where(predicate);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}

		public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await Context.Set<TEntity>().Where(predicate).ToListAsync();
		}

		public Task<TEntity> GetByIdAsync(int id)
		{
			return Context.Set<TEntity>().FindAsync(id);
		}

		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public virtual void Update(TEntity entity)
		{
			Context.Entry(entity).State = EntityState.Modified;
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}

		public void Dispose()
		{
			
		}

		public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
		}
	}
}
