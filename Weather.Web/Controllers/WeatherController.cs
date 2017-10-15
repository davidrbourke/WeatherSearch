using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.App.Application;

namespace Weather.Web.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            WeatherService service = new WeatherService();
            var result = await service.GetWeatherAsync();

            return View(result);
        }
    }
}