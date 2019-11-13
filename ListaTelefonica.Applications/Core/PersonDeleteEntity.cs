using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.Core
{
	public class PersonDeleteEntity : Entity
	{
		public int Id { get; set; }
		public PersonDeleteEntity(int id)
		{
			Id = id;

			Validate(this, new DeletePersonValidator());
		}
	}

}
