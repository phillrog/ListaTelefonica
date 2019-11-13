using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.EntitiesApp
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
