using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIValidationExample.Infrastructure.Validation;
using DIValidationExample.Models;

namespace DIValidationExample.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICustomValidator[] _customValidators;

		public HomeController( ICustomValidator[] customValidators)
		{
			_customValidators = customValidators;
		}

		[HttpGet]
		public ActionResult Index( )
		{
			return View( new HomeIndexViewModel( ) );
		}

		[HttpPost]
		public ActionResult Index( HomeIndexViewModel viewModel )
		{
			_customValidators.ToList( ).ForEach( x => x.Validate( viewModel.Input, viewModel.ErrorList ) );
			if ( viewModel.ErrorList.Any( ) )
			{
				viewModel.ResponseMessage = "Please fix the below issues";
			}
			else
			{
				viewModel.ResponseMessage = "All fine";
			}


			return View( viewModel );
		}

	}
}