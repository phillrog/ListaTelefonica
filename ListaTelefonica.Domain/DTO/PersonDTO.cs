using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.DTO
{
	public class PersonDTO
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBirth { get; set; }

		public IEnumerable<PersonPhoneDTO> Phones { get; set; }
	}
}
