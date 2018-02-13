using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UonCoursesHTMLParser
{
	class CourseCollection : List<Course>
	{

		public List<string> UnprocessedCourses;

		public CourseCollection()
		{
			UnprocessedCourses = new List<string>();
		}

		public void GetCourses(ReadOnlyCollection<IWebElement> courseStrings)
		{
			var i = 0;
			foreach (var field in courseStrings)
			{
				bool processSuccessful;
				var processedCourse = Course.TryProcessCourseFromField(field.Text, out processSuccessful);

				if (processSuccessful)
				{
					Add(processedCourse);
					Console.WriteLine("{0} - {1}", i, field.Text);
				}
				else
				{
					UnprocessedCourses.Add(field.Text);
					Console.WriteLine("{0} - field: {1} not processed - added to UnprocessedCourses");
				}

				i += 1;
			}
		}

		public void PopulateCoursesWithLessons(UonWebsiteNavigator navigator)
		{
			foreach (var course in this)
			{
				course.AddAllLessons(navigator.NavigateToAndFindLessonTable(course));
				navigator.ReturnToCourseSelectionPage();
			}
		}
	}
}
