using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Weather
	{
		/// <summary>
		/// Returns the low tempurature in the user's unit preference
		/// </summary>
		public string LowTemp
		{
			get
			{
				if (this.UnitPrefence == "C")
				{
					return ConvertFtoC(this.LowTempF) + "°C";
				}
				else if (this.UnitPrefence == "K")
				{
					return ConvertFtoK(this.LowTempF) + "K";
				}
				return this.LowTempF + "°F";
			}
		}

		/// <summary>
		/// Returns the high tempurature in the user's unit preference
		/// </summary>
		public string HighTemp
		{
			get
			{
				if (this.UnitPrefence == "C")
				{
					return ConvertFtoC(this.HighTempF) + "°C";
				}
				else if (this.UnitPrefence == "K")
				{
					return ConvertFtoK(this.HighTempF) + "K";
				}
				return this.HighTempF + "°F";
			}
		}

		/// <summary>
		/// Represents the lowest temperature forcasted for the day in Fahrenheit
		/// </summary>
		public int LowTempF { get; set; }

		/// <summary>
		/// Represents the highest temperature forcasted for the day in Fahrenheit
		/// </summary>
		public int HighTempF { get; set; }

		/// <summary>
		/// Holds the user's prefered unit of temperature measure
		/// </summary>
		public string UnitPrefence { get; set; }
		
		/// <summary>
		/// Represents the forcasted weather for the day (e.g. Sunny, Rain, etc.)
		/// </summary>
		public string Forecast { get; set; }		

		/// <summary>
		/// Converts the given Fahrenheit temperature to Celcius
		/// </summary>
		/// <param name="temp">A temp in °F</param>
		/// <returns>The converted temp in °C</returns>
		private int ConvertFtoC(int temp)
		{
			temp -= 32;
			temp *= 5;
			temp /= 9;
			return temp;
		}

		/// <summary>
		/// Converts the given Fahrenheit temperature to Kelvins
		/// </summary>
		/// <param name="temp">A temp in °F</param>
		/// <returns>The converted temp in Kelvins</returns>
		private int ConvertFtoK(int temp)
		{
			temp = ConvertFtoC(temp);
			temp += 273;
			return temp;
		}
	}
}
