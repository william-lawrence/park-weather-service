using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
	public class HomeController : Controller
	{
		// Dependency Injection

		private readonly IParksDAL ParksDAL;
		private readonly IWeatherDAL WeatherDAL;
		private readonly ISurveyDAL SurveyDAL;

		public HomeController(IParksDAL parksDAL, IWeatherDAL weatherDAL, ISurveyDAL surveyDAL)
		{
			this.ParksDAL = parksDAL;
			this.WeatherDAL = weatherDAL;
			this.SurveyDAL = surveyDAL;
		}

        public IActionResult Index()
        {
        	IList<Park> parks = ParksDAL.GetAllParks();
			return View(parks);
        }  
        
        [HttpGet]
        public IActionResult Survey()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Survey(SurveyResult result)
        {
            SurveyDAL.AddNewSurvey(result);
            return RedirectToAction("Index", "Home");
        }

		public IActionResult Detail(string code)
		{
			code = Convert.ToString(ViewData["code"]);
			Park park = ParksDAL.GetPark(code);
			park.FiveDayForecast = WeatherDAL.GetForecast(code);
			return View(park);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
