namespace Calysto.Utility
{
	public class BoxValue<T>
	{
		private T _value;
		private bool _hasValue;

		public bool HasValue => this._hasValue;

		public T Value
		{
			get { return this._value; }
			set
			{
				this._value = value;
				this._hasValue = true;
			}
		}

		public BoxValue()
		{
		}

		public T GetValueOrDefault() => this.HasValue ? this.Value : default(T);

		public T GetValueOrDefault(T defaultValue = default(T)) => this.HasValue ? this.Value : defaultValue;

		public override int GetHashCode() => this.Value == null ? 0 : this.Value.GetHashCode();

	}

}
