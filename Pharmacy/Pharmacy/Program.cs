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
				Console.WriteLine("Write command:");
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
					Console.WriteLine("Medicine Name:");
					string name = Console.ReadLine();
					Console.WriteLine("Manufacturer:");
					string manufacturer = Console.ReadLine();
					Console.WriteLine("Price:");
					decimal price = Decimal.Parse(Console.ReadLine());
					Console.WriteLine("Amount:");
					int amount = Int32.Parse(Console.ReadLine());
					Console.WriteLine("With Prescription?(True/False):");
					bool withPrescription = bool.Parse(Console.ReadLine());

					AddMed(new Medicines(name, manufacturer, price, amount, withPrescription));
				}
				else if (command.ToLower() == "editmed")
				{
					Console.WriteLine("Which Medicine ID do you want to edit?");
					int id =Int32.Parse(Console.ReadLine());

					EditMed(id);
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

		private static void AddMed(Medicines medicine)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"INSERT INTO Medicines (Name, Manufacturer, Price, Amount, WithPrescription)
			                     VALUES (@Name, @Manufacturer, @Price, @Amount, @WithPrescription);";

					var sqlNameParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = medicine.Name,
						ParameterName = "@Name"
					};

					var sqlManufacturerParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = medicine.Manufacturer,
						ParameterName = "@Manufacturer"
					};

					var sqlPriceParam = new SqlParameter
					{
						DbType = System.Data.DbType.Decimal,
						Value = medicine.Price,
						ParameterName = "@Price"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = medicine.Amount,
						ParameterName = "@Amount"
					};

					var sqlWithPrescriptionParam = new SqlParameter
					{
						DbType = System.Data.DbType.Boolean,
						Value = medicine.WithPrescription,
						ParameterName = "@WithPrescription"
					};

					sqlCommand.Parameters.Add(sqlNameParam);
					sqlCommand.Parameters.Add(sqlManufacturerParam);
					sqlCommand.Parameters.Add(sqlPriceParam);
					sqlCommand.Parameters.Add(sqlAmountParam);
					sqlCommand.Parameters.Add(sqlWithPrescriptionParam);

					connection.Open();

					sqlCommand.ExecuteNonQuery();

					connection.Close();
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

					connection.Open();

					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();



					while (sqlDataReader.Read())
					{
						Console.WriteLine($"ID: {sqlDataReader.GetInt32(0)} | Name: {sqlDataReader.GetString(1)} | Manufacturer: {sqlDataReader.GetString(2)} | Price: {sqlDataReader.GetDecimal(3)} | Amount: {sqlDataReader.GetInt32(4)} | WithPrescription: {sqlDataReader.GetString(5)}");
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void EditMed(int id)
		{
			try
			{
				
				Console.WriteLine("Medicine Name:");
				string name = Console.ReadLine();
				Console.WriteLine("Manufacturer:");
				string manufacturer = Console.ReadLine();
				Console.WriteLine("Price:");
				decimal price = Decimal.Parse(Console.ReadLine());
				Console.WriteLine("Amount:");
				int amount = Int32.Parse(Console.ReadLine());
				Console.WriteLine("With Prescription?(True/False):");
				bool withPrescription = bool.Parse(Console.ReadLine());

				var medicine = new Medicines(name,manufacturer,price,amount,withPrescription);

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"UPDATE Medicines SET Name = @Name, Manufacturer = @Manufacturer, Price = @Price, Amount = @Amount, WithPrescription = @WithPrescription
			                     WHERE ID = @id;";

					var sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@id"
					};

					var sqlNameParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = medicine.Name,
						ParameterName = "@Name"
					};

					var sqlManufacturerParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = medicine.Manufacturer,
						ParameterName = "@Manufacturer"
					};

					var sqlPriceParam = new SqlParameter
					{
						DbType = System.Data.DbType.Decimal,
						Value = medicine.Price,
						ParameterName = "@Price"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = medicine.Amount,
						ParameterName = "@Amount"
					};

					var sqlWithPrescriptionParam = new SqlParameter
					{
						DbType = System.Data.DbType.Boolean,
						Value = medicine.WithPrescription,
						ParameterName = "@WithPrescription"
					};

					sqlCommand.Parameters.Add(sqlIdParam);
					sqlCommand.Parameters.Add(sqlNameParam);
					sqlCommand.Parameters.Add(sqlManufacturerParam);
					sqlCommand.Parameters.Add(sqlPriceParam);
					sqlCommand.Parameters.Add(sqlAmountParam);
					sqlCommand.Parameters.Add(sqlWithPrescriptionParam);

					connection.Open();
					
					sqlCommand.ExecuteNonQuery();

					connection.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}





