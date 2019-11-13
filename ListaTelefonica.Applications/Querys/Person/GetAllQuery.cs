using System.Collections.Generic;
using ListaTelefonica.Domain.Entities;
using MediatR;

namespace ListaTelefonica.Applications.Querys
{
	public class GetAllPersonQuery : IRequest<IEnumerable<Person>>
	{
		public GetAllPersonQuery()
		{
		
		}
	}
}
