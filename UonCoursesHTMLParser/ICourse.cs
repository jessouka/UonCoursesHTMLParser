using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
	public interface ICourse
	{
		string ClassCode { get; }
		int Semester { get; }
		Campus Campus { get; }

	}
}
