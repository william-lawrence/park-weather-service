using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
	public class ParksDAL : IParksDAL
	{
		/// <summary>
		/// Connection string used to connect to DB.
		/// </summary>
		private readonly string ConnectionString;

		/// <summary>
		/// Constructor that takes connection string.
		/// </summary>
		/// <param name="connectionString">Connection string used to connect to DB.</param>
		public ParksDAL(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		public IList<Park> GetAllParks()
		{
			List<Park> parks = new List<Park>();
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();

					string sql = "SELECT * FROM park ORDER BY parkName ASC;";
					SqlCommand cmd = new SqlCommand(sql, conn);
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						parks.Add(TranslateReaderToPark(reader));
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return parks;
		}

		public Park GetPark(string code)
		{
			Park park = new Park();
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();

					string sql = $"SELECT * FROM park WHERE parkcode = @code;";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@code", code);
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						park = TranslateReaderToPark(reader);
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return park;
		}

		private Park TranslateReaderToPark(SqlDataReader reader)
		{
			Park park = new Park();
			park.Code = Convert.ToString(reader["parkCode"]);
			park.Name = Convert.ToString(reader["parkName"]);
			park.State = Convert.ToString(reader["state"]);
			park.Acreage = Convert.ToInt32(reader["acreage"]);
			park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
			park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
			park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
			park.Climate = Convert.ToString(reader["climate"]);
			park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
			park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
			park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
			park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
			park.Description = Convert.ToString(reader["parkDescription"]);
			park.EntryFee = Convert.ToInt32(reader["entryFee"]);
			park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
			if (reader["weatherUrlSlice"] != DBNull.Value)
			{
				park.WeatherUrlSlice = Convert.ToString(reader["weatherUrlSlice"]);
			}
			if (reader["weatherUrlSlice"] != DBNull.Value)
			{
				park.MapUrlSlice = Convert.ToString(reader["mapUrlSlice"]);
			}
			return park;
		}
	}
}
