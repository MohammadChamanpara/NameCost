﻿using NameCost.Core;
using NameCost.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;

namespace NameCost.WebAPI.Controllers
{
	/// <summary>
	/// The main controller of the NameCost web api project
	/// </summary>
	/// <seealso cref="System.Web.Http.ApiController" />
	public class ConvertController : ApiController
	{
		INameCostLogic Logic;
		/// <summary>
		/// Initializes a new instance of the <see cref="ConvertController"/> class.
		/// </summary>
		/// <param name="logic">The logic to be used while generating words for the number.</param>
		public ConvertController(INameCostLogic logic)
		{
			this.Logic = logic;
		}

		/// <summary>
		/// Converts the cost number to words.
		/// </summary>
		/// <param name="nameCost">The parameter to provide the number to be converted to words.</param>
		/// <returns>A model containing the generated words for the numbers</returns>
		[Route("api/convert")]
		[ResponseType(typeof(NameCostModel))]
		[HttpPost]
		public IHttpActionResult Convert(NameCostModel nameCost)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Logic.GenerateWords(nameCost);

			return Ok(nameCost);
		}
	}
}