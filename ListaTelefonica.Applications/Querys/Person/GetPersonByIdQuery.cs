using ListaTelefonica.Domain.Entities;
using MediatR;

namespace ListaTelefonica.Applications.Querys
{
	public class GetPersonByIdQuery : IRequest<Person>
	{
		public int Id { get; set; }

		public GetPersonByIdQuery(int id)
		{
			Id = id;
		}
	}
}
