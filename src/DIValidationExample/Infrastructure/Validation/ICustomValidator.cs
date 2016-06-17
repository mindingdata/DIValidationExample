using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIValidationExample.Infrastructure.Validation
{
	public interface ICustomValidator
	{
		void Validate( int input, List<string> errorList );
	}
}
