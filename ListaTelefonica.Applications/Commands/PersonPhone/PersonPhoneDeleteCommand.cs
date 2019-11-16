using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Applications.Core;
using MediatR;

namespace ListaTelefonica.Applications.Commands.PersonPhone
{
	public class PersonPhoneDeleteCommand : IRequest<bool>
	{
		public int Id { get; set; }

		public PersonPhoneDeleteCommand(int id)
		{
			Id = id;
		}
	}
}
