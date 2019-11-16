using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.EntitiesApp
{
	public class PersonPhoneDeleteEntity : Entity
	{
		public int Id { get; set; }
		public PersonPhoneDeleteEntity(int id)
		{
			Id = id;

			Validate(this, new DeletePersonPhoneValidator());
		}
	}

}
