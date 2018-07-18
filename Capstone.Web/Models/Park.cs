using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Park
	{
		/// <summary>
		/// Represents A short String that uniquely identifies a park.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Represents the Park's Name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Represents the Park's State
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// Represents the Size of the park in acres
		/// </summary>
		public int Acreage { get; set; }

		/// <summary>
		/// Represents the Park's Evelvatoin in feet above sea level
		/// </summary>
		public int ElevationInFeet { get; set; }

		/// <summary>
		/// Represents the The combined length of all hiking trails in the park

		/// </summary>
		public double MilesOfTrail { get; set; }

		/// <summary>
		/// Represents The total number of campsites available for visitors in the park
		/// </summary>
		public int NumberOfCampsites { get; set; }

		/// <summary>
		/// Represents A general description of the park’s climate (e.g. “Desert”)
		/// </summary>
		public string Climate { get; set; }

		/// <summary>
		/// Represents The year the park joined the National Park System
		/// </summary>
		public int YearFounded { get; set; }

		/// <summary>
		/// Represents The average number of visitors to the park on a annual basis
		/// </summary>
		public int AnnualVisitorCount { get; set; }

		/// <summary>
		/// Represents A famous quote related to the park
		/// </summary>
		public string InspirationalQuote { get; set; }

		/// <summary>
		/// Represents The person to whom the inspirational quote is attributed
		/// </summary>
		public string InspirationalQuoteSource { get; set; }

		/// <summary>
		/// Represents the desciption of the Park
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Represents The cost to enter the park in dollars
		/// </summary>
		public int EntryFee { get; set; }

		/// <summary>
		/// Represents The number of different animal species that can be found within the boundaries of the park
		/// </summary>
		public int NumberOfAnimalSpecies { get; set; }

		/// <summary>
		/// Represents A five day forecast for the Park
		/// </summary>
		public IList<Weather> FiveDayForecast { get; set; }
	}
}
