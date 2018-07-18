using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Park
	{
		/// <summary>
		/// Represents the Park's Name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Represents the Park's State
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// Represents the Park's Acreage
		/// </summary>
		public int Acreage { get; set; }

		/// <summary>
		/// Represents the Park's Evelvatoin in feet
		/// </summary>
		public int ElevationInFeet { get; set; }

		/// <summary>
		/// Represents the miles of trail in the Park
		/// </summary>
		public double MilesOfTrail { get; set; }

		/// <summary>
		/// Represents thenumber of campsties in the Park
		/// </summary>
		public int NumberOfCampsites { get; set; }

		/// <summary>
		/// Represents the Park's climate
		/// </summary>
		public string Climate { get; set; }

		/// <summary>
		/// Represents the year the Park was founded
		/// </summary>
		public int YearFounded { get; set; }

		/// <summary>
		/// Represents the Park's Annual Vistor Count
		/// </summary>
		public int AnnualVisitorCount { get; set; }

		/// <summary>
		/// Represents the an Quote relevent to the Park
		/// </summary>
		public string InspirationalQuote { get; set; }

		/// <summary>
		/// Represents the Source of the inspirational quote
		/// </summary>
		public string InspirationalQuoteSource { get; set; }

		/// <summary>
		/// Represents the desciption of the Park
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Represents the Park's entry fee
		/// </summary>
		public int EntryFee { get; set; }

		/// <summary>
		/// Represents the number of animal species in the park
		/// </summary>
		public int NumberOfAnimalSpecies { get; set; }

		/// <summary>
		/// Represents A five day forecast for the Park
		/// </summary>
		public IList<Weather> FiveDayForecast { get; set; }
	}
}
