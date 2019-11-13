using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.Core
{
	public class PersonUpdateEntity : Entity
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBirth { get; set; }
		public IEnumerable<PersonPhoneUpdateEntity> Phones { get; set; }
		public PersonUpdateEntity(int? id, string name, DateTime dateBirth, IEnumerable<PersonPhoneUpdateEntity> phones )
		{
			Id = id;
			Name = name;
			DateBirth = dateBirth;
			Phones = phones;

			Validate(this, new UpdatePersonValidator());
		}
	}

	public class PersonPhoneUpdateEntity
	{
		public int? Id { get; set; }
		public string Description { get; set; }
		public string Number { get; set; }
		public int PersonId { get; set; }
	}
}
