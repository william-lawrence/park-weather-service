using Microsoft.AspNetCore.Mvc.Rendering;
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

        /// <summary>
        /// List of all the parks for the drop down menu.
        /// </summary>
        public static List<SelectListItem> Parks = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Cuyahoga Valley", Value = "CVNP"},
            new SelectListItem() {Text = "Everglades", Value = "ENP"},
            new SelectListItem() {Text = "Grand Canyon", Value = "GCNP"},
            new SelectListItem() {Text = "Glacier", Value = "GNP"},
            new SelectListItem() {Text = "Great Smokey Mountains", Value = "GSMNP"},
            new SelectListItem() {Text = "Grand Teton", Value = "GTNP"},
            new SelectListItem() {Text = "Mount Rainer", Value = "MRNP"},
            new SelectListItem() {Text = "Rocky Mountain", Value = "RMNP"},
            new SelectListItem() {Text = "Yellow Stone", Value = "YNP"},
            new SelectListItem() {Text = "Yosemite", Value = "YNP2"},
        };
    }
}
