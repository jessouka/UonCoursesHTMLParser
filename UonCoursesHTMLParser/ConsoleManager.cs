using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
    public class ConsoleManager
    {
		List<ConsoleCommand> commands;

		public void Start()
		{
			var userResponse = "";

			while (!userResponse.Contains("-KILLEVERYTHING"))
			{
				userResponse = Console.ReadLine();
			}
		}

		void printCommandOptions()
		{
			Console.WriteLine("yoyoyo Welcome to Jess' uon timetable generator console tool thingo. Here's ur options for commands:");
			Console.WriteLine("----------------------------------------------------------------------------------------------------");

			foreach (var command in commands)
			{
				Console.WriteLine(command.ConstructConsolePrintLine());
			}

			Console.WriteLine("----------------------------------------------------------------------------------------------------");
		}

		void executeUserCommand(string userCommand)
		{

		}

		void generateCommands()
		{
			commands.Add(
				new ConsoleCommand("", "", new DataScraper())))
		}
    }
}
