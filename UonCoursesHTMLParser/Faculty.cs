using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
	public class Faculty
	{
		public string Code { get; }
		public string Description { get; set;}

		public Faculty(string code)
		{
			this.Code = code.Substring(0, 4);
			this.Description = "";
		}
	}
}
