using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.Validators;

namespace ListaTelefonica.Applications.EntitiesApp
{
	public class GetAllPersonQueryEntity : Entity
	{
		public GetAllPersonQueryEntity()
		{
			Validate(this, new GetAllPersonQueryValidator());
		}
	}

}
