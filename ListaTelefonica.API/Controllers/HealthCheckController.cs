using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	[Route("api/healthcheck")]
	[ApiController]
	public class HealthCheckController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
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
	}
}