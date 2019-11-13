using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.Core
{
	public class PersonEntity : Entity
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBirth { get; set; }
		public IEnumerable<PersonPhoneEntity> Phones { get; set; }
		public PersonEntity(int? id, string name, DateTime dateBirth, IEnumerable<PersonPhoneEntity> phones )
		{
			Id = id;
			Name = name;
			DateBirth = dateBirth;
			Phones = phones;

			Validate(this, new CreatePersonValidator());
		}
	}

	public class PersonPhoneEntity
	{
		public int? Id { get; set; }
		public string Description { get; set; }
		public string Number { get; set; }
		public int PersonId { get; set; }
	}
}
