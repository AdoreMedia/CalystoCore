using System.Threading.Tasks;

namespace Calysto.Blazor.Utility.Infrastructure
{
	public class StorageProvider
	{
		ScriptContext _module;

		private string _storageName;

		public StorageProvider(ScriptContext module, string storageName)
		{
			_module = module;
			_storageName = storageName;
		}

		public async ValueTask SetItem<TItem>(string key, TItem value)
		{
			string json = System.Text.Json.JsonSerializer.Serialize(value);
			await _module.InvokeVoidAsync($"{_storageName}.setItem", key, json);
		}

		public async ValueTask<TItem> GetItem<TItem>(string key)
		{
			string json = await _module.InvokeAsync<string>($"{_storageName}.getItem", key);
			if (string.IsNullOrEmpty(json))
				return await ValueTask.FromResult<TItem>(default);
			else
				return System.Text.Json.JsonSerializer.Deserialize<TItem>(json);
		}

		public async ValueTask Clear()
		{
			await _module.InvokeVoidAsync($"{_storageName}.clear");
		}

		public async ValueTask RemoveItem(string key)
		{
			await _module.InvokeVoidAsync($"{_storageName}.removeItem", key);
		}
	}
}
