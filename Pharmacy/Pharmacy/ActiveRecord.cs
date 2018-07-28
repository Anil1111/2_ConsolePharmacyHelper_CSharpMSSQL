using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Pharmacy
{
	public abstract class ActiveRecord
	{
		public readonly int ID;


		public abstract void Save();
		public abstract void Reload();
		public abstract void Remove();

		protected void Open()
		{
		}

		protected void Close()
		{

		}

	}
}
