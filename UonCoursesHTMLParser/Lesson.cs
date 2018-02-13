using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
	public class Lesson
	{
		public string LessonType { get; }
		public Course Course { get; }
		public string Day { get; }
		public string Start { get; }
		public string End { get; }
		public string Duration { get; }
		public DateTime StartDate { get; }
		public DateTime EndDate { get; }
		public Campus Campus { get; }
		public string Room { get; }
		public string Comments { get; }

		public Lesson(
			string lessonType,
			Course course,
			string day,
			string start,
			string end,
			string duration,
			string room,
			Campus campus,
			string comments)
		{
			this.LessonType = lessonType;
			this.Course = course;
			this.Day = day;
			this.Start = start;
			this.End = end;
			this.Duration = duration;
			this.Room = room;
			this.Campus = campus;
		}
	}
}
