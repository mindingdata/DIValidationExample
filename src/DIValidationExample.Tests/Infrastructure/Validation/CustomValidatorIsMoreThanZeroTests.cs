using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIValidationExample.Infrastructure.Validation;
using Xunit;

namespace DIValidationExample.Tests.Infrastructure.Validation
{
	
	public class CustomValidatorIsMoreThanZeroTests
	{
		private readonly CustomValidatorIsMoreThanZero _customValidatorIsMoreThanZero;

		public CustomValidatorIsMoreThanZeroTests( )
		{
			_customValidatorIsMoreThanZero = new CustomValidatorIsMoreThanZero( );
		}

		[Fact]
		public void Validate_InputIsLessThanZero_ErrorMessageIsAdded( )
		{
			var errorList = new List<string>( );
			_customValidatorIsMoreThanZero.Validate( -1, errorList );

			Assert.Equal( 1, errorList.Count );
		}

		[Fact]
		public void Validate_InputIsMoreThanZero_ErrorMessageIsEmpty( )
		{
			var errorList = new List<string>( );
			_customValidatorIsMoreThanZero.Validate( 1 , errorList );

			Assert.Equal( 0, errorList.Count );
		}
	}
}
