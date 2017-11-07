using NameCost.Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NameCost.Controllers
{
	public class ConvertController : Controller
	{
		[Route]
		[HttpGet]
		public ActionResult Index()
		{
			return View("index");
		}

		[Route]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Index(NameCostModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri("http://localhost:31331/");

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
				}
			}

			return View(model);
		}

		[Route("output/{Name}/{Cost}/{CostInWords}")]
		[HttpGet]
		public ActionResult Output(NameCostModel model)
		{
			return View("output", model);
		}
	}
}