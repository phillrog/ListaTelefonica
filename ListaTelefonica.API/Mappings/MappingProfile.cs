using System.Collections.Generic;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Domain.DTO;
using ListaTelefonica.Domain.Entities;

namespace ListaTelefonica.API.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Person, PersonDTO>();
			
			CreateMap<PersonDTO, Person>();
			CreateMap<PersonPhone, PersonPhoneDTO>();
			CreateMap<PersonPhoneDTO, PersonPhone>();



			CreateMap<PersonDTO, PersonCreateCommand>();
			CreateMap<PersonPhoneDTO, PersonPhoneCreateCommand>();

			CreateMap<PersonDTO, PersonUpdateCommand>();

			CreateMap<PersonCreateCommand, Person>();
			CreateMap<PersonPhoneCreateCommand, PersonPhone>();
			CreateMap<PersonUpdateCommand, Person>();
		}
	}
}
