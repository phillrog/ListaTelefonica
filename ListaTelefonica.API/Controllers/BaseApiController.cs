using ListaTelefonica.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	public abstract class BaseApiController : ControllerBase
	{
		protected readonly IUnitOfWork _uow;
		public BaseApiController(IUnitOfWork uow)
		{
			_uow = uow;
		}
	}
}
