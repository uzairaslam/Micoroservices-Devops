﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Models;
using System.Diagnostics;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/Product");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<Product>>(content);
            return View(productList);
            //return View();
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