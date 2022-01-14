using Calysto.Serialization.Json.Core.Serialization;
using System;

namespace Calysto.Web.Script.Services
{
	class WebServiceData
	{
		public Type WebServiceType {get;set;}

		internal WebServiceData(Type serviceType)
		{
			this.WebServiceType = serviceType;
		}
	}


}