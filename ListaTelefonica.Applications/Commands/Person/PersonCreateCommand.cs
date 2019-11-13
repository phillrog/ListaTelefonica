using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Applications.Core;
using MediatR;

namespace ListaTelefonica.Applications.Commands.Person
{
	public class PersonCreateCommand : IRequest<Response>
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public DateTime DateBirth { get; set; }
		public IEnumerable<PersonPhoneCreateCommand> Phones { get; set; }
	}

	public class PersonPhoneCreateCommand
	{
		public int? Id { get; set; }
		public string Description { get; set; }
		public string Number { get; set; }
		public int PersonId { get; set; }
	}
}
