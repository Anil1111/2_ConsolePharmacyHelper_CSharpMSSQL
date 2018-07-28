using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy
{
	class Medicines : ActiveRecord
	{
		public int ID { get; private set; }
		public string Name { get; protected set; }
		public string Manufacturer { get; protected set; }
		public decimal Price { get; protected set; }
		public int Amount { get; protected set; }
		public bool WithPrescription { get; set; }

		public Medicines()
		{

		}

		public Medicines(string name, string manufacturer, decimal price, int amount, bool withPrescription)
		{
			Name = name;
			Manufacturer = manufacturer;
			Price = price;
			Amount = amount;
			WithPrescription = withPrescription;
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
