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
            Park park = new Park
            {
                Code = Convert.ToString(reader["parkCode"]),
                Name = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                Description = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
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
