using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Domain.Interfaces.Contexts;
using ListaTelefonica.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Infra.Data.Contexts
{
	public class ListaTelefoneContext : DbContext , IContext
	{
		public  DbSet<Person> Person { get; set; }
		public DbSet<PersonPhone> PersonPhone { get; set; }

		public IQueryable<Person> PersonQuery => Person;
		public ListaTelefoneContext(DbContextOptions<ListaTelefoneContext> options) : base(options)
		{
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("public");
			modelBuilder.ApplyConfiguration(new PersonConfiguration());
			modelBuilder.ApplyConfiguration(new PersonPhoneConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			ChangeTracker.DetectChanges();
			return  base.SaveChangesAsync(true, cancellationToken);
		}

	}
}
