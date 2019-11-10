using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	[Route("api/healthcheck")]
	public class HealthCheckController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get() => Ok(@"I'm alive! ListaTelefonica!" + Environment.NewLine +
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