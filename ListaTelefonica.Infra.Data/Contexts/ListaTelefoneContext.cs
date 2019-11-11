using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Domain.Entities;
using ListaTelefonica.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace ListaTelefonica.Infra.Data.Contexts
{
	public class ListaTelefoneContext : DbContext 
	{
		public  DbSet<Person> Person { get; set; }
		public DbSet<PersonPhone> PersonPhone { get; set; }

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
	}
}
