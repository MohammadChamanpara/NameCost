using NameCost.Core;
using NameCost.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace NameCost.WebAPI.Controllers
{
	public class ConvertController : ApiController
	{
		INameCostLogic Logic;
		public ConvertController(INameCostLogic logic)
		{
			this.Logic = logic;
		}

		/// <summary>
		/// Converts the cost number to words.
		/// </summary>
		/// <param name="nameCost">The parameter to provide the cost.</param>
		/// <returns>A model containing the generated words for the costs</returns>
		[Route("api/generate")]
		public NameCostModel GenerateWords(NameCostModel nameCost)
		{
			Logic.GenerateWords(nameCost);
			return nameCost;
		}
	}
}