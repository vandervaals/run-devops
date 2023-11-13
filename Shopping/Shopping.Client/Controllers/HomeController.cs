using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Data;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger<HomeController> _logger;

		public HomeController(IHttpClientFactory clientFactory, ILogger<HomeController> logger)
		{
			_httpClient = clientFactory.CreateClient("ShoppingAPIClient");
            _logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var response = await _httpClient.GetAsync("/product");
			var content = await response.Content.ReadAsStringAsync();
			var productsList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

			return View(productsList);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}