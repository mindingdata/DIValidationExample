using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIValidationExample.Models
{
	public class HomeIndexViewModel
	{
		public HomeIndexViewModel( )
		{
			ErrorList = new List<string>( );
		}

		public int Input { get; set; }
		public List<string> ErrorList { get; set; }
		public string ResponseMessage { get; set; }
	}
}