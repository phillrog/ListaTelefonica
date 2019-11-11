using ListaTelefonica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaTelefonica.Infra.Data.EntityConfig
{
	public class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable("Pessoa");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

			builder.Property(p => p.DateBirth).IsRequired();

			builder.HasMany(g => g.Phones).WithOne(p => p.Person);
		}
	}
}
