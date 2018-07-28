using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy
{
	public static class Menu
	{

		public static void ShowMenu()
		{
			ConsoleEx.WriteLine("Menu:", ConsoleColor.Green);
			ConsoleEx.WriteLine("1.Medicines List - ShowAll", ConsoleColor.Green); // Select * FROM Medicines
			ConsoleEx.WriteLine("2.Add Medicine - AddMed", ConsoleColor.Green); // Dodawanie nowego leku do bazy
			ConsoleEx.WriteLine("3.Edit Medicine - EditMed", ConsoleColor.Green); // Edycja leku - zmiana nazwy / ilosci sztuk na magazynie / czy na recepte itd
			ConsoleEx.WriteLine("4.Remove Medicine - RemoveMed", ConsoleColor.Green); // Kasacja leku z listy -> nothing more
																					  //ConsoleEx.WriteLine("5.Edit Medicine Stock:", ConsoleColor.Green); - Aplikacja będzie sama edytowała ilość sztuk na podstawie sprzedaży leków
			ConsoleEx.WriteLine("5.Sell Medicine - SellMed", ConsoleColor.Green); // Procedura sprzedaży, czyli aktualizacja stanu magazynowego, jeżeli na receptę wprowadzenie recepty i klienta do bazy.
																				  //ConsoleEx.WriteLine("6.Edit Client - EditC", ConsoleColor.Green); // Ręczne wprowadzenie klienta - jeszcze się zastanowie czy to konieczne 
			ConsoleEx.WriteLine("7.Exit - EXIT", ConsoleColor.Green); // Ręczne wprowadzenie klienta - jeszcze się zastanowie czy to konieczne 

		}
	}
}
