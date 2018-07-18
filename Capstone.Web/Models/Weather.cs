using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Weather
	{
		/// <summary>
		/// Represents the lowest temperature forcasted for the day in Fahrenheit
		/// </summary>
		public int LowTempF { get; set; }

		/// <summary>
		/// Represents the highest temperature forcasted for the day in Fahrenheit
		/// </summary>
		public int HighTempF { get; set; }

		/// <summary>
		/// Represents the lowest temperature forcasted for the day in Celcius
		/// </summary>
		public int LowTempC
		{
			get
			{
				return ConvertFtoC(this.LowTempF);
			}
		}

		/// <summary>
		/// Represents the highest temperature forcasted for the day in Celcius
		/// </summary>
		public int HighTempC
		{
			get
			{
				return ConvertFtoC(this.HighTempF);
			}
		}

		/// <summary>
		/// Represents the lowest temperature forcasted for the day in Kelvins
		/// </summary>
		public int LowTempK
		{
			get
			{
				return ConvertCtoK(ConvertFtoC(this.LowTempF));
			}
		}

		/// <summary>
		/// Represents the highest temperature forcasted for the day in Kelvins
		/// </summary>
		public int HighTempK
		{
			get
			{
				return ConvertCtoK(ConvertFtoC(this.HighTempF));
			}
		}

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
		/// Converts the given Celcius temperature to Kelvins
		/// </summary>
		/// <param name="temp">A temp in °C</param>
		/// <returns>The converted temp in Kelvins</returns>
		private int ConvertCtoK(int temp)
		{
			temp += 273;
			return temp;
		}
	}
}
