using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        /// <summary>
        /// The id of the survey in the database
        /// </summary>
        public int SurveyID { get; set; }
        
        /// <summary>
        /// The code used to represent the park.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The email address of the user that submitted the survey
        /// </summary>
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// The state where the park primarily resides.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The activity level of the user that submitted the survey.
        /// </summary>
        public string ActivityLevel { get; set; }
    }
}
