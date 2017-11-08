using NameCost.Core.Models;
using NameCost.Logic;
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
		/// <returns>A model containing the generated words for the number</returns>
		[Route("api/convert")]
		[ResponseType(typeof(NameCostModel))]
		[HttpPost]
		public IHttpActionResult Convert(NameCostModel nameCost)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//TODO: adopt neccessary measures to handle the probable exceptions from logic
			Logic.GenerateWords(nameCost);

			return Ok(nameCost);
		}
	}
}