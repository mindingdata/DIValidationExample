using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIValidationExample.Infrastructure.Validation;
using Xunit;

namespace DIValidationExample.Tests.Infrastructure.Validation
{
	public class CustomValidatorIsLessThan100Tests
	{
		private readonly CustomValidatorIsLessThan100 _customValidatorIsLessThan100;

		public CustomValidatorIsLessThan100Tests( )
		{
			_customValidatorIsLessThan100 = new CustomValidatorIsLessThan100( );
		}

		[Fact]
		public void Validate_WhenInputIsMoreThan100_ErrorMessageAdded( )
		{
			var errorList = new List<string>( );

			_customValidatorIsLessThan100.Validate( 101, errorList );

			Assert.Equal( 1, errorList.Count );
		}

		[Fact]
		public void Validate_WhenInputIsLessThan100_NoErrorMessageAdded( )
		{
			var errorList = new List<string>( );

			_customValidatorIsLessThan100.Validate( 99, errorList );

			Assert.Equal( 0, errorList.Count );
		}
	}
}
