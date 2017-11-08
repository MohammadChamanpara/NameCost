using Microsoft.ApplicationInsights;
using NameCost.Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NameCost.Controllers
{
	/// <summary>
	/// An MVC controler for the UI application flow
	/// </summary>
	/// <seealso cref="System.Web.Mvc.Controller" />
	public class ConvertController : Controller
	{
		/// <summary>
		/// The Home view of the UI application.
		/// </summary>
		/// <returns></returns>
		[Route]
		[HttpGet]
		public ActionResult Index()
		{
			//The Action name has been mentioned in order for the UnitTests to verify the action name.
			return View("index");
		}

		/// <summary>
		/// The post action method to reach out to the api and generate the words.
		/// </summary>
		/// <param name="model">The model to be posted to the service.</param>
		/// <returns></returns>
		[Route]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Index(NameCostModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			try
			{
				using (var httpClient = new HttpClient())
				{
					var apiAddress = System.Configuration.ConfigurationManager.AppSettings["WebApiUri"];

					httpClient.BaseAddress = new Uri(apiAddress);

					var postTask = httpClient.PostAsJsonAsync("api/convert", model);
					postTask.Wait();
					var result = postTask.Result;

					if (result.IsSuccessStatusCode)
					{
						model = await result.Content.ReadAsAsync<NameCostModel>();
						return RedirectToAction("output", model);
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
						return View(model);
					}
				}
			}
			catch(Exception exception)
			{
				//Log the exception via sending the telemetry data to Azure Application Insight
				new TelemetryClient().TrackException(exception);

				ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
				return View(model);
			}
		}
		/// <summary>
		/// The Action to render display the Name and Cost in words format of the specified model.
		/// </summary>
		/// <param name="model">The model which contains the name and cost and will be sent via attribute parameters.</param>
		/// <returns></returns>
		[Route("output/{Name}/{Cost}/{CostInWords}")]
		[HttpGet]
		public ActionResult Output(NameCostModel model)
		{
			return View("output", model);
		}
	}
}