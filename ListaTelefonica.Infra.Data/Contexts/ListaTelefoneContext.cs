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
		public  DbSet<Person> Persons { get; set; }
		public DbSet<PersonPhone> PersonPhones { get; set; }

		public ListaTelefoneContext(DbContextOptions options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PersonConfiguration());
			modelBuilder.ApplyConfiguration(new PersonPhoneConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
