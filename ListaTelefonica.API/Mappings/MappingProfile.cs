using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
		}
	}
}
