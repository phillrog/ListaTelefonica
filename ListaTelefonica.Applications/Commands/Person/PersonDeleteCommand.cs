using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Applications.Core;
using MediatR;

namespace ListaTelefonica.Applications.Commands.Person
{
	public class PersonDeleteCommand : IRequest<Response>
	{
		public int Id { get; set; }

		public PersonDeleteCommand(int id)
		{
			Id = id;
		}
	}
}
