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

		// GET api/<controller>
		[Route("api/convert")]
		public NameCostModel Convert(NameCostModel nameCost)
		{
			Logic.GenerateWords(nameCost);
			return nameCost;
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}
	}
}