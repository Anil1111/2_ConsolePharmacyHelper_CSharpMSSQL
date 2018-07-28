using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy
{
	public class Prescription : ActiveRecord
	{

		public string CustomerName { get; set; }
		public string Pesel { get; set; }
		public string Amount { get; set; }
		public Prescription(string customerName, string pesel, string amount)
		{
			CustomerName = customerName;
			Pesel = pesel;
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
