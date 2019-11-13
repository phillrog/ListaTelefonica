using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTelefonica.API.Controllers
{
	/// <summary>
	/// Health checker controller
	/// </summary>
	[Route("api/healthcheck")]
	[ApiController]
	public class HealthCheckController : ControllerBase
	{
		/// <summary>
		/// Método para verificar se api está On
		/// </summary>
		/// <returns>Mensagem avisando que está ok</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[HttpGet]
		public async Task<IActionResult> Get() => Ok(@"I'm alive! ListaTelefonica!" + Environment.NewLine +
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