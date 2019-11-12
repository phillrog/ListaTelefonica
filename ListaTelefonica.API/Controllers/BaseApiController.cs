using AutoMapper;
using ListaTelefonica.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	public abstract class BaseApiController : ControllerBase
	{
		protected readonly IUnitOfWork _uow;
		protected readonly IMapper _mapper;
		public BaseApiController(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}
	}
}
