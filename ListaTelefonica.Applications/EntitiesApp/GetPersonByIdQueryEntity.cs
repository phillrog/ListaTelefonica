using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.EntitiesApp
{
	public class GetPersonByIdQueryEntity : Entity
	{
		public int Id { get; set; }
		public GetPersonByIdQueryEntity(int id)
		{
			Id = id;

			Validate(this, new GetPersonByIdQueryValidator());
		}
	}

}
