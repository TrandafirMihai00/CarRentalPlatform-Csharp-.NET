using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.Models.ViewModels
{
	[DataContract]
	public class GraficVanzariVM
    {
		
		public GraficVanzariVM(double x, double y)
		{
			this.x = x;
			this.Y = y;
		}

		
		[DataMember(Name = "x")]
		public Nullable<double> x = null;


		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

	}
}
