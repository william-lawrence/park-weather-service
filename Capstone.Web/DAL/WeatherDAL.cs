using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
<<<<<<< HEAD
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
    }
=======
	public class WeatherDAL : IWeatherDAL
	{
	}
>>>>>>> c2db8c6dc3029bffd8a5c7ea266f1565f4801fee
}
