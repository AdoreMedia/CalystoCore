namespace Calysto.Utility
{
	export function Extend<TDestination>(destination: TDestination, source: object, mayOverwrite ?: boolean, ownPropertiesOnly ?: boolean)
	{
		for (var prop in source)
		{
			if (!ownPropertiesOnly || source.hasOwnProperty(prop))
			{
				if (mayOverwrite || !(prop in destination))
				{
					destination[prop] = source[prop];
				}
			}
		}
		return destination;
	}
}