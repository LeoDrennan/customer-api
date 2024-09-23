using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _baseUrl = "https://localhost:44378/customers";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerViewModel customer)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(customer);
                    StringContent body = new(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(_baseUrl, body);

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError(ex, "Error while contacting API");
                    return RedirectToAction("Error");
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditCustomerViewModel? model;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = _baseUrl + '/' + id.ToString();

                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string? json = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<EditCustomerViewModel>(json);

                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError(ex, "Error while contacting API for id {}", id);
                    return RedirectToAction("Error");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCustomerViewModel customer)
        {
            CustomerViewModel model = customer.ToModel();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = _baseUrl + '/' + customer.Id.ToString();

                    string json = JsonConvert.SerializeObject(model);
                    StringContent body = new(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(url, body);

                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError(ex, "Error while contacting API");
                    return RedirectToAction("Error");
                }
            }

            return RedirectToAction("Index");
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
