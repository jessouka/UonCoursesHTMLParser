using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
	public class Campus
	{
		public string Code { get; }
		public string Name { get; set; }

		public Campus(string code)
		{
			this.Code = code.Substring(1);
			this.Name = "name not disclosed.";
		}
	}
}
