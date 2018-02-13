using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
	public class TeachingPeriod
	{
		public string Code { get; }
		public string Number { get; }

		public TeachingPeriod(string code)
		{
			var index = code.ToCharArray().Length;
			this.Code = code;
			this.Number = code.ToCharArray()[index - 1].ToString();
		}
	}
}
