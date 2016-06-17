using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIValidationExample.Infrastructure.Validation
{
	public class CustomValidatorIsMoreThanZero : ICustomValidator
	{
		public void Validate( int input, List<string> errorList )
		{
			if ( input < 0 )
				errorList.Add( "Item is less than zero" );
		}
	}
}