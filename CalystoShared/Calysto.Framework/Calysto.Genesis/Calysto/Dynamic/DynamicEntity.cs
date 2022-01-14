using System.Collections.Generic;
using System.Dynamic;

namespace Calysto.Dynamic
{
	public abstract class DynamicEntity : DynamicObject
	{
		private IDictionary<string, object> _values;

		public DynamicEntity(IDictionary<string, object> values)
		{
			_values = values;
		}
		
		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return _values.Keys;
		}
		
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			if (_values.ContainsKey(binder.Name))
			{
				result = _values[binder.Name];
				return true;
			}
			result = null;
			return false;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			if(_values.ContainsKey(binder.Name))
			{
				_values[binder.Name] = value;
				return true;
			}
			return false;
		}
	}

}
