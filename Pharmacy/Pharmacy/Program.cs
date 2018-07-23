using System;

namespace Pharmacy
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu.ShowMenu();

			do
			{
				string command = Console.ReadLine();

				if (command.ToLower() == "exit")
				{
					break;
				}
				if (command.ToLower() == "showAll")
				{
				} else
				if (command.ToLower() == "addMed")
				{
				} else
				if (command.ToLower() == "editMed")
				{
				}else
				if (command.ToLower() == "removeMed")
				{
				} else
				if (command.ToLower() == "sellMed")
				{
				} else
				if (command.ToLower() == "editC")
				{
				}

			} while (true);
		}
	}
}
