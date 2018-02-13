using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UonCoursesHTMLParser
{
	public class Course
	{
		public string SelectionOption { get; }
		public string Code { get; }
		public Faculty Faculty { get; }
		public string Description { get; }
		public TeachingPeriod Term { get; }
		public Campus Campus { get; }
		public List<Lesson> LessonList { get; set; }

		Course(string selectionOption, string code, string description, string term, string campus)
		{
			this.SelectionOption = selectionOption;
			this.Code = code;
			this.Faculty = new Faculty(code);
			this.Description = description;
			this.Term = new TeachingPeriod(term);
			this.Campus = new Campus(campus);
			this.LessonList = new List<Lesson>();
		}

		static public Course TryProcessCourseFromField(string field, out bool processSuccessful)
		{
			processSuccessful = false;
			var valueRegex = new Regex(@"(.+?(?=\/))\/(.+?(?=_))_(.+?(?=\ - )) - (.+)");
			var values = valueRegex.Match(field);

			if (values.Success)
			{
				processSuccessful = true;
				return new Course(values.Groups[0].Value,
				values.Groups[1].Value,
				values.Groups[4].Value,
				values.Groups[2].Value,
				values.Groups[3].Value);
			}

			return null;
		}

		public void AddAllLessons(IWebElement table)
		{
			var rows = new List<IWebElement>();

			foreach (var element in table.FindElements(By.ClassName("odd")))
			{
				rows.Add(element);
			}

			foreach (var element in table.FindElements(By.ClassName("even")))
			{
				rows.Add(element);
			}

			var numofLessons = 0;
			foreach (var row in rows)
			{
				AddLesson(row);
				numofLessons += 1;
			}

			Console.WriteLine("{0}, lessons added to {1}", numofLessons, Code);
		}

		void AddLesson(IWebElement row)
		{
			var elements = row.FindElements(By.ClassName(" "));

			LessonList.Add(new Lesson(
									Code,
									this,
									elements[2].Text,
									elements[3].Text,
									elements[4].Text,
									elements[5].Text,
									elements[7].Text,
									Campus,
									elements[9].Text));
		}
	}
}
