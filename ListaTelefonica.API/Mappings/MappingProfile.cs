using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ListaTelefonica.Applications.Commands.Person;
using ListaTelefonica.Applications.Commands.PersonPhone;
using ListaTelefonica.Applications.EntitiesApp;
using ListaTelefonica.Applications.Querys;
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

			CreateMap<PersonCreateCommand, PersonEntity>().ConstructUsing(p => new PersonEntity(p.Id, p.Name, p.DateBirth, 
				(p.Phones == null || p.Phones.Count() == 0) ? null :  p.Phones.Select(
				x => new PersonPhoneEntity(){ Id = x.Id , Number = x.Number, PersonId = x.PersonId, Description = x.Description}).ToList()) );
			CreateMap<PersonPhoneCreateCommand, PersonPhoneEntity>();

			CreateMap<PersonEntity, Person>();
			CreateMap<PersonPhoneEntity, PersonPhone>();

			CreateMap<PersonDTO, PersonUpdateCommand>();
			CreateMap<PersonPhoneDTO, PersonPhoneUpdateCommand>();

			CreateMap<PersonUpdateCommand, PersonUpdateEntity>().ConstructUsing(p => new PersonUpdateEntity(p.Id, p.Name, p.DateBirth,
				(p.Phones == null || p.Phones.Count() == 0) ? null : p.Phones.Select(
					x => new PersonPhoneUpdateEntity() { Id = x.Id, Number = x.Number, PersonId = x.PersonId, Description = x.Description }).ToList()));
			CreateMap<PersonPhoneUpdateCommand, PersonPhoneUpdateEntity>();

			CreateMap<PersonEntity, Person>();
			CreateMap<PersonPhoneEntity, PersonPhone>();

			CreateMap<PersonUpdateEntity, Person>();
			CreateMap<PersonPhoneUpdateEntity, PersonPhone>();

			CreateMap<PersonUpdateCommand, Person>();

			CreateMap<Person, PersonResponseDTO>();
			CreateMap<PersonPhone, PersonPhoneResponseDTO>();

			CreateMap<int, PersonDeleteCommand>().ConstructUsing(d=> new PersonDeleteCommand(d));

			CreateMap<PersonDeleteCommand, PersonDeleteEntity>();

			CreateMap<int, PersonPhoneDeleteCommand>().ConstructUsing(d => new PersonPhoneDeleteCommand(d));

			CreateMap<PersonPhoneDeleteCommand, PersonPhoneDeleteEntity>();

			CreateMap<int, GetPersonByIdQuery>().ConstructUsing(q => new GetPersonByIdQuery(q));
			CreateMap<GetPersonByIdQuery, GetPersonByIdQueryEntity>();

			CreateMap<GetAllPersonQuery, GetAllPersonQuery>();
			CreateMap<GetAllPersonQuery, GetAllPersonQueryEntity>();
			

		}
	}
}
