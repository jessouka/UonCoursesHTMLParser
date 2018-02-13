using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
    public class DataScraper
    {
		void GatherDataFromUonWebsite()
		{
			using (var driver = new ChromeDriver("E:\\Documents\\DevStuff\\Dev Stuff\\Uon Timetable Generator\\UonCoursesHTMLParser\\UonCoursesHTMLParser\\"))
			{
				Console.WriteLine("Scraper navigating to website...");
				var navigator = new UonWebsiteNavigator(driver);
				navigator.NavigateToUonWebsite();

				var courses = GetAndProcessCourses(navigator);

				Console.WriteLine("Populating successfully processed courses with available lessons");
				courses.PopulateCoursesWithLessons(navigator);
			}
		}

		CourseCollection GetAndProcessCourses(UonWebsiteNavigator navigator)
		{
			Console.WriteLine("Getting course codes...");
			CourseCollection courses = new CourseCollection();
			courses.GetCourses(navigator.FindCourseDropDownOptions());

			CourseCodeSuccessReport(courses);

			return courses;
		}

		void CourseCodeSuccessReport(CourseCollection courses)
		{
			Console.WriteLine("{0} course fields not processed. List? (yes/no)", courses.UnprocessedCourses.Count);
			var response = Console.ReadLine();

			if (response.Contains("yes"))
			{
				var i = 0;
				foreach (var course in courses.UnprocessedCourses)
				{
					Console.WriteLine("{0} - {1}", i, course);
					i += 1;
				}
			}
		}
	}
}
