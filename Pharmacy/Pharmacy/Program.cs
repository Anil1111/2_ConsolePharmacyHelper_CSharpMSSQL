﻿using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

					AddMed(new Medicine(name, manufacturer, price, amount, withPrescription));
				}
				else if (command.ToLower() == "editmed")
				{
					Console.WriteLine("Which Medicine ID do you want to edit?");
					int id = Int32.Parse(Console.ReadLine());

					EditMed(id);
				}
				else if (command.ToLower() == "removemed")
				{
					Console.WriteLine("Which Medicine ID do you want to remove?");
					int id = Int32.Parse(Console.ReadLine());

					RemoveMed(id);
				}
				else if (command.ToLower() == "sellmed")
				{
					Console.WriteLine("Which Medicine ID do you want to sell?");
					int id = Int32.Parse(Console.ReadLine());

					if (PrescriptionChecker(id))
					{
					SellMedWithPrescription(id);
					}
					SellMedWithoutPrescription(id);
				}

			} while (true);
		}

		private static void AddMed(Medicine medicine)
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

					while (sqlDataReader.HasRows && sqlDataReader.Read())
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

				var medicine = new Medicine(name, manufacturer, price, amount, withPrescription);

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
		private static void RemoveMed(int id)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"DELETE FROM Medicines WHERE ID = @id;";

					var sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@id"
					};

					sqlCommand.Parameters.Add(sqlIdParam);

					connection.Open();

					sqlCommand.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		private static void SellMedWithoutPrescription(int id)
		{
			try
			{
				Console.WriteLine("How much do you want to sell?:");
				int amount = Int32.Parse(Console.ReadLine());
				int Id = id;
				DateTime date = DateTime.Now;

				var order = new Order(null, Id, date, amount);

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"INSERT INTO Orders (MedicineId, Date, Amount) 
						VALUES (@MedicineId, @Date, @Amount)";

					var sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@MedicineId"
					};

					var sqlDateParam = new SqlParameter
					{
						DbType = System.Data.DbType.DateTime,
						Value = order.Date,
						ParameterName = "@Date"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = order.Amount,
						ParameterName = "@Amount"
					};

					sqlCommand.Parameters.Add(sqlIdParam);
					sqlCommand.Parameters.Add(sqlDateParam);
					sqlCommand.Parameters.Add(sqlAmountParam);

					connection.Open();

					sqlCommand.ExecuteNonQuery();

					EditAmountForOders(id, amount);

					connection.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}

		private static void SellMedWithPrescription(int id)
		{
			try
			{
				Console.WriteLine("How much do you want to sell?:");
				int amount = Int32.Parse(Console.ReadLine());
				int Id = id;
				DateTime date = DateTime.Now;

				var order = new Order(null, Id, date, amount);

				Console.WriteLine("Podaj dane recepty:");
				Console.WriteLine("Imię i nazwisko:");
				string customerName = Console.ReadLine();

				Console.WriteLine("Pesel:");
				string pesel = Console.ReadLine();

				Console.WriteLine("Numer recepty:");
				int prescriptionNumber = Int32.Parse(Console.ReadLine());


				var prescription = new Prescription(customerName, pesel, prescriptionNumber);

				using (SqlConnection connection = new SqlConnection(connectionString))
				{

					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"INSERT INTO Prescriptions (CustomerName, PESEL, PrescriptionNumber) 
						VALUES (@CustomerName, @PESEL, @PrescriptionNumber); SELECT SCOPE_IDENTITY();";

					var sqlCustomerNameParam = new SqlParameter
					{
						DbType = System.Data.DbType.String,
						Value = prescription.CustomerName,
						ParameterName = "@CustomerName"
					};

					var sqlPeselParam = new SqlParameter
					{
						DbType = System.Data.DbType.String,
						Value = prescription.Pesel,
						ParameterName = "@PESEL"
					};

					var sqlPresciptionNumberParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = prescription.PrescriptionNumber,
						ParameterName = "@PrescriptionNumber"
					};

					sqlCommand.Parameters.Add(sqlCustomerNameParam);
					sqlCommand.Parameters.Add(sqlPeselParam);
					sqlCommand.Parameters.Add(sqlPresciptionNumberParam);

					connection.Open();

					var addedPrescriptionId = sqlCommand.ExecuteScalar();

					sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"INSERT INTO Orders (PrescriptionId, MedicineId, Date, Amount) 
						VALUES (@PrescriptionId, @MedicineId, @Date, @Amount);";

					var sqlPrescIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = addedPrescriptionId,
						ParameterName = "@PrescriptionId"
					};

					var sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@MedicineId"
					};

					var sqlDateParam = new SqlParameter
					{
						DbType = System.Data.DbType.DateTime,
						Value = order.Date,
						ParameterName = "@Date"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = order.Amount,
						ParameterName = "@Amount"
					};

					sqlCommand.Parameters.Add(sqlIdParam);
					sqlCommand.Parameters.Add(sqlDateParam);
					sqlCommand.Parameters.Add(sqlAmountParam);
					sqlCommand.Parameters.Add(sqlPrescIdParam);

					sqlCommand.ExecuteNonQuery();

					EditAmountForOders(id, amount);

					connection.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static bool PrescriptionChecker(int id)
		{
			bool validator = false;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"SELECT * FROM Medicines WHERE ID = @id;";

					var sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@id"
					};

					sqlCommand.Parameters.Add(sqlIdParam);

					connection.Open();

					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

					while (sqlDataReader.HasRows && sqlDataReader.Read())
					{
						string validatorTemp = sqlDataReader.GetString(5);

						if (validatorTemp != "0")
						{
							validator = true;
						}
					}

					
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			return validator;
		}

		private static void EditAmountForOders(int id, int amount)
		{
			int actualAmount = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"SELECT * FROM Medicines WHERE ID = @id;";

					var sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@id"
					};
					sqlCommand.Parameters.Add(sqlIdParam);

					connection.Open();

					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

					while (sqlDataReader.HasRows && sqlDataReader.Read())
					{
						actualAmount = sqlDataReader.GetInt32(4);
					}
					actualAmount = actualAmount - amount;

					connection.Close();
					connection.Open();

					sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText =
						@"UPDATE Medicines SET Amount = @Amount
			                     WHERE ID = @id;";

					sqlIdParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@id"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = actualAmount,
						ParameterName = "@Amount"
					};

					sqlCommand.Parameters.Add(sqlIdParam);
					sqlCommand.Parameters.Add(sqlAmountParam);

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





