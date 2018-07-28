using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy
{
	public class Order : ActiveRecord
	{


		public int? PrescriptionID { get; set; }
		public int? MedicineID { get; set; }
		public DateTime Date { get; set; }
		public int Amount { get; set; }

		public Order(int? prescriptionID, int? medicineID, DateTime date, int amount)
		{
			PrescriptionID = prescriptionID;
			MedicineID = medicineID;
			Date = date;
			Amount = amount;
		}

		public override void Save()
		{
			throw new NotImplementedException();
		}

		public override void Reload()
		{
			throw new NotImplementedException();
		}

		public override void Remove()
		{
			throw new NotImplementedException();
		}
	}
}
