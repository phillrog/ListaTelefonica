using System;
using System.Collections.Generic;
using System.Text;

namespace ListaTelefonica.Domain.Entities
{
	public class PersonPhone
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Number { get; set; }

		public int PersonId { get; set; }

		public virtual Person Person { get; set; }
	}
}
