using System;
using System.Collections.Generic;
using System.Text;

namespace UonCoursesHTMLParser
{
    public class ConsoleCommand
    {
		public Delegate method;
		string command;
		string commandDescription;

		public ConsoleCommand(string command, string commandDescription, Delegate method)
		{
			this.command = command;
			this.commandDescription = commandDescription;
			this.method = method;
		}

		public string ConstructConsolePrintLine()
		{
			return string.Format("{0}    : {1}", command, commandDescription);
		}
    }
}
