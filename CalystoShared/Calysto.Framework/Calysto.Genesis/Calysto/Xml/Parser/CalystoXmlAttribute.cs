namespace Calysto.Xml.Parser
{
	public class CalystoXmlAttribute
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public CalystoXmlAttribute()
		{
		}

		public string GetString()
		{
			if (Value == null)
			{
				// HTML 5 comapatibility, attribute name may not have value: <audio controls autoplay preload="none">....</audio>
				return Name;
			}
			else
			{
				return Name + "=\"" + Value + "\"";
			}
		}

		public CalystoXmlAttribute(string name, string value)
		{
			Name = name;
			Value = value;
		}

	}


}
