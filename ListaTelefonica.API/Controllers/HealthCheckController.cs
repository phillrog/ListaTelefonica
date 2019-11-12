using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	[Route("api/healthcheck")]
	[ApiController]
	public class HealthCheckController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			_uow.PersonAppService.Create(new Person()
			{
				DateBirth = DateTime.Now,
				Name = "TESTE",
				Phones = new List<PersonPhone>()
				{
					new PersonPhone()
					{
						Description = "TESTE",
						Number = "993320555"
					}
				}
			});

			await _uow.CommitAsync();
			return Ok(@"I'm alive! ListaTelefonica!" + Environment.NewLine +
			   Environment.NewLine + @"
    _____________
  / ___________   \:. .
 |__| [0][1][2] |__|:  :
   /  [3][4][5]  \   :  :
  /   [6][7][8]   \   :  :
 /    [*][#][-]    \   ..
|___________________|");

		}

		public HealthCheckController(IUnitOfWork uow) : base(uow)
		{
			
		}
	}
}