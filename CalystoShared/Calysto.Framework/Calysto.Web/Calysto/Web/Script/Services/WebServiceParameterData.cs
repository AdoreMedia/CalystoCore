using System;

namespace Calysto.Web.Script.Services
{
	class WebServiceParameterData
    {
		internal int Index { get; set; }

		internal System.Reflection.ParameterInfo ParameterInfo { get; set; }

		internal string ParameterName { get { return this.ParameterInfo.Name; } }

		internal Type ParameterType { get { return this.ParameterInfo.ParameterType; } }

        internal WebServiceParameterData(System.Reflection.ParameterInfo param, int index)
        {
            this.ParameterInfo = param;
            this.Index = index;
        }

    }
}

