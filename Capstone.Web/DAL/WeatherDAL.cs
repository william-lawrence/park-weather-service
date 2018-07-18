using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
	public class WeatherDAL : IWeatherDAL
	{
		/// <summary>
		/// Connection string used to connect to DB.
		/// </summary>
		private readonly string ConnectionString;

		/// <summary>
		/// Constructor that takes connection string.
		/// </summary>
		/// <param name="connectionString">Connection string used to connect to DB.</param>
		public WeatherDAL(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		public IList<Weather> GetForecast(string code)
		{
			List<Weather> weather = new List<Weather>();
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();

					string sql = $"SELECT * FROM weather WHERE parkCode = @code ORDER BY fiveDayForecastValue ASC;";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@code", code);
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						weather.Add(TranslateReaderToWeather(reader));
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return weather;
		}

		private Weather TranslateReaderToWeather(SqlDataReader reader)
		{
			return new Weather()
			{
				LowTempF = Convert.ToInt32(reader["low"]),
				HighTempF = Convert.ToInt32(reader["high"]),
				Forecast = Convert.ToString(reader["forecast"])
			};
		}
	}
}
