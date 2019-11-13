using System;
using System.Collections.Generic;

namespace ListaTelefonica.Domain.DTO
{
	public class PersonResponseDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBirth { get; set; }

		public IEnumerable<PersonPhoneResponseDTO> Phones { get; set; }
	}
}
