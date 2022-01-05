using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace P1GadgetStore
{
	[DataContract]

	public class testingClass
	{

		[JsonProperty]
		private string name;
		[JsonProperty]

		private string add;
		public testingClass(string name, string add)
		{
			this.name = name;
			this.add = add;
		}

	
	}
}

