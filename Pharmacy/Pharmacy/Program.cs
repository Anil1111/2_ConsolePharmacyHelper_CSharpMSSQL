using System;
using System.Data.SqlClient;

namespace Pharmacy
{
	class Program
	{
		static string connectionString = "Integrated Security=SSPI;" +
								  "Data Source=.\\SQLEXPRESS;" +
								  "Initial Catalog=Pharmacy;";
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

				if (command.ToLower() == "showall")
				{
					ShowAll();
				}
				else if (command.ToLower() == "addmed")
				{
					AddMed();
				}
				else if (command.ToLower() == "editmed")
				{
				}
				else if (command.ToLower() == "RemoveMed")
				{
				}
				else if (command.ToLower() == "sellmed")
				{
				}
				else if (command.ToLower() == "editc")
				{
				}

			} while (true);
		}

		private static void AddMed()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"INSERT INTO Rentiers (NazwaLeku)
                        VALUES (@);";

					var sqlFirstNameParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = Medicine.FirstName,
						ParameterName = "@FirstName"
					};

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void ShowAll()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"SELECT * FROM Medicines";
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

					while (sqlDataReader.Read())
					{
						Console.WriteLine(sqlDataReader.GetString(0));
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}



