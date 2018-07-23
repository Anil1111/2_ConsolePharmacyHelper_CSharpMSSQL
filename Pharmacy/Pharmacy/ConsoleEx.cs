using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy
{
	public static class ConsoleEx
	{
		public static void WriteLine(string text, ConsoleColor x)
		{
			Console.ForegroundColor = x;
			Console.WriteLine(text);
			Console.ResetColor();
		}

		public static void Write(string text, ConsoleColor x)
		{
			Console.ForegroundColor = x;
			Console.Write(text);
			Console.ResetColor();
		}
	}
}
