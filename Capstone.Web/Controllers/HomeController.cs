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
			var parks = SurveyDAL.GetParkRankings();
			return View(parks);
		}

		public IActionResult Detail(string code)
		{
			// Get the chosen Park
			Park park = ParksDAL.GetPark(code);
			////Get the forecast for the park
			//park.FiveDayForecast = WeatherDAL.GetForecast(code);
			//// If the user has a unit preference for temp unit, apply it to each weather element
			//if (HttpContext.Session.Get<string>(Temp_Unit_Choice) != null)
			//{
			//	park.FiveDayForecast.Select(w => { w.UnitPrefence = HttpContext.Session.Get<string>(Temp_Unit_Choice); return w; }).ToList();
			//}

			TempData["unit"] = HttpContext.Session.Get<string>(Temp_Unit_Choice);

			// Only display the page, if the park was found
			if (park.Code == code)
			{
				return View(park);
			}
			else
			{
				return RedirectToAction("Error");
			}
		}

		public IActionResult ChangeUnits(string parkCode, string unit)
		{
			string currentUnit = HttpContext.Session.Get<string>(Temp_Unit_Choice);
			if (currentUnit == null || currentUnit == "F")
			{
				HttpContext.Session.Set(Temp_Unit_Choice, "C");
			}
			else
			{
				HttpContext.Session.Set(Temp_Unit_Choice, "F");
			}
			return RedirectToAction("Detail", new { code = parkCode });
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
