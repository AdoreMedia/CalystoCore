using LinqToSqlShared.DbmlObjectModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class FunctionParametersCollection
	{
		public ReadOnlyCollection<FunctionParameter> Items { get; private set; }

		public FunctionParametersCollection(IEnumerable<Parameter> parameters)
		{
			var parameters1 = parameters.Select((o, n) => new FunctionParameter()
			{
				Index = n,
				Parameter = o,
			}).ToList();

			// find the last parameter with non-assignable default value
			var par3 = parameters1.Where(o => !o.HasAsignableDefaultValue).LastOrDefault();
			// ako su svi assignable, par3 ce biti null
			// svi parametri nakon ovog mogu imati default value postavljen u C#
			parameters1.Where(o => par3 == null || o.Index > par3.Index).ToList().ForEach(o => o.MayHaveCSharpDefaultValue = true);

			this.Items = parameters1.AsReadOnly();
		}

		public class FunctionParameter
		{
			public int Index { get; set; }

			public Parameter Parameter { get; set; }

			public string CleanedName => EFUtility.GetCSharpValidName(this.Parameter.Name.Replace("@", ""));

			public bool HasDefaultValue => !string.IsNullOrEmpty(this.Parameter.ParameterDefaultNetValue);

			public bool HasAsignableDefaultValue
			{
				get
				{
					// .NET method arguments default values assignment rules:
					// ref or out argument may not have default value
					// arg with default value may not be followed by args without default value
					// if DateTime type, may assign null only, may not instantinate new datetime
					// pronaci zadnjeg koji nema default value, svi ispred moraju biti bez default value
					// svi nakon ovog, mogu imati default value

					if (!this.HasDefaultValue)
						return false;

					if (this.Parameter.IsOutput)
						return false;

					if (this.Parameter.Type == "System.DateTime" && this.Parameter.ParameterDefaultNetValue != "null")
						return false;

					return true;
				}
			}

			public bool MayHaveCSharpDefaultValue { get; set; }
		}
	}
}
