using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherInfo.Models;

namespace WeatherInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new WeatherInfoViewModel());
        }

        [HttpPost]
        public ActionResult Index(WeatherInfoViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View( new WeatherInfoViewModel
                {
                    WeatherCode = model.WeatherCode,
                    WeatherInfo = null
                });
            }
            var weatherBug = new WeatherBug.WeatherBug();
            var info = weatherBug.checkWeather(WeatherBug.WeatherTypeEnum.ZipCode, model.WeatherCode.ToString());
            var viewModel = new WeatherInfoViewModel
            {
                WeatherCode = model.WeatherCode,
                WeatherInfo = info
            };
            return View(viewModel);
        }
    }
}