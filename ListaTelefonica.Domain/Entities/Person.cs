using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.Entities
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBirth { get; set; }

		public virtual ICollection<PersonPhone> Phones { get; set; }
	}
}
