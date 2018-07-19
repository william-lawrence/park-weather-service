using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        // Dependency Injection
        #region Dependency Injection
        private readonly IParksDAL ParksDAL;
        private readonly IWeatherDAL WeatherDAL;
        private readonly ISurveyDAL SurveyDAL;

        public HomeController(IParksDAL parksDAL, IWeatherDAL weatherDAL, ISurveyDAL surveyDAL)
        {
            this.ParksDAL = parksDAL;
            this.WeatherDAL = weatherDAL;
            this.SurveyDAL = surveyDAL;
        }
        #endregion

		private const string Temp_Unit_Choice = "Temp_Unit_Choice";

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
            return RedirectToAction("FavoritePark", "Home");
        }

        [HttpGet]
        public IActionResult FavoritePark()
        {
            var bestPark = SurveyDAL.GetBestPark();
            return View(bestPark);
        }

		public IActionResult Detail(string code)
		{
			Park park = ParksDAL.GetPark(code);
			park.FiveDayForecast = WeatherDAL.GetForecast(code);
			if (park != new Park())
			{
				return View(park);
			}
			else
			{
				return RedirectToAction("Error");
			}
		}

		public IActionResult ChangeUnits(string code, string unit)
		{
			HttpContext.Session.Set(Temp_Unit_Choice, unit);
			return RedirectToAction("Detail", "Home", code);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
