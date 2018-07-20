﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		[Required(ErrorMessage = "* Required")]
		public string ParkCode { get; set; }

		/// <summary>
		/// The email address of the user that submitted the survey
		/// </summary>
		[Required(ErrorMessage = "* Required")]
		[EmailAddress]
		public string EmailAddress { get; set; }

		/// <summary>
		/// The state where the park primarily resides.
		/// </summary>
		[Required(ErrorMessage = "* Required")]
		public string State { get; set; }

		/// <summary>
		/// The activity level of the user that submitted the survey.
		/// </summary>
		[Required(ErrorMessage = "* Required")]
		public string ActivityLevel { get; set; }

		/// <summary>
		/// List of all the parks for the drop down menu.
		/// </summary>
		public static List<SelectListItem> Parks = new List<SelectListItem>()
		{
			new SelectListItem() {Text = "(Pick a Park)", Value = ""},
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

		/// <summary>
		/// The list of all the states for the drop down menu.
		/// </summary>
		public static List<SelectListItem> States = new List<SelectListItem>()
		{
			new SelectListItem() {Text = "(Pick a State)", Value = ""},
			new SelectListItem() {Text = "Alabama", Value = "Alabama"},
			new SelectListItem() {Text = "Alaska", Value = "Alaska"},
			new SelectListItem() {Text = "Arizona", Value = "Arizona"},
			new SelectListItem() {Text = "Arkansas", Value = "Arkansas"},
			new SelectListItem() {Text = "California", Value = "California"},
			new SelectListItem() {Text = "Colorado", Value = "Colorado"},
			new SelectListItem() {Text = "Connecticut", Value = "Connecticut"},
			new SelectListItem() {Text = "Delaware", Value = "Delaware"},
			new SelectListItem() {Text = "Florida", Value = "Florida"},
			new SelectListItem() {Text = "Georgia", Value = "Georgia"},
			new SelectListItem() {Text = "Hawaii", Value = "Hawaii"},
			new SelectListItem() {Text = "Idaho", Value = "Idaho"},
			new SelectListItem() {Text = "Illinois", Value = "Illinois"},
			new SelectListItem() {Text = "Indiana", Value = "Indiana"},
			new SelectListItem() {Text = "Iowa", Value = "Iowa"},
			new SelectListItem() {Text = "Kansas", Value = "Kansas"},
			new SelectListItem() {Text = "Kentucky", Value = "Kentucky"},
			new SelectListItem() {Text = "Louisiana", Value = "Louisiana"},
			new SelectListItem() {Text = "Maine", Value = "Maine"},
			new SelectListItem() {Text = "Maryland", Value = "Maryland"},
			new SelectListItem() {Text = "Massachusetts", Value = "Massachusetts"},
			new SelectListItem() {Text = "Michigan", Value = "Michigan"},
			new SelectListItem() {Text = "Minnesota", Value = "Minnesota"},
			new SelectListItem() {Text = "Mississippi", Value = "Mississippi"},
			new SelectListItem() {Text = "Missouri", Value = "Missouri"},
			new SelectListItem() {Text = "Montana", Value = "Montana"},
			new SelectListItem() {Text = "Nebraska", Value = "Nebraska"},
			new SelectListItem() {Text = "Nevada", Value = "Nevada"},
			new SelectListItem() {Text = "New Hampshire", Value = "New Hampshire"},
			new SelectListItem() {Text = "New Jersey", Value = "New Jersey"},
			new SelectListItem() {Text = "New Mexico", Value = "New Mexico"},
			new SelectListItem() {Text = "New York", Value = "New York"},
			new SelectListItem() {Text = "North Carolina", Value = "North Carolina"},
			new SelectListItem() {Text = "North Dakota", Value = "North Dakota"},
			new SelectListItem() {Text = "Ohio", Value = "Ohio"},
			new SelectListItem() {Text = "Oklahoma", Value = "Oklahoma"},
			new SelectListItem() {Text = "Oregon", Value = "Oregon"},
			new SelectListItem() {Text = "Pennsylvania", Value = "Pennsylvania"},
			new SelectListItem() {Text = "Rhode Island", Value = "Rhode Island"},
			new SelectListItem() {Text = "South Carolina", Value = "South Carolina"},
			new SelectListItem() {Text = "South Dakota", Value = "South Dakota"},
			new SelectListItem() {Text = "Tennessee", Value = "Tennessee"},
			new SelectListItem() {Text = "Texas", Value = "Texas"},
			new SelectListItem() {Text = "Utah", Value = "Utah"},
			new SelectListItem() {Text = "Vermont", Value = "Vermont"},
			new SelectListItem() {Text = "Virginia", Value = "Virginia"},
			new SelectListItem() {Text = "Washington", Value = "Washington"},
			new SelectListItem() {Text = "West Virginia", Value = "West Virginia"},
			new SelectListItem() {Text = "Wisconsin", Value = "Wisconsin"},
			new SelectListItem() {Text = "Wyoming", Value = "Wyoming"}
		};
	}
}
