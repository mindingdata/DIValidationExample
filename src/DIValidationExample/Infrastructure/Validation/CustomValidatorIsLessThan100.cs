using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIValidationExample.Infrastructure.Validation
{
	public class CustomValidatorIsLessThan100 : ICustomValidator
	{
		public void Validate( int input, List<string> errorList )
		{
			if ( input >= 100 )
				errorList.Add( "Input is more then or equal to 100" );
		}
	}
}