using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Domain.Entities;
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
			base.OnModelCreating(modelBuilder);
		}
	}
}
