using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Linq;
using Calysto.Web.UI.Direct;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Calysto.AspNetCore.Mvc.Rendering
{
	public static class SelectListExtensions
	{
		/// <summary>
		/// Create options html.
		/// </summary>
		/// <returns></returns>
		public static string ToInnerHtml(this IEnumerable<SelectListItem> list)
		{
			return new ListRenderer(list).RenderList().Select(o=>o.ToHtml()).ToStringJoined();
		}

		private class ListRenderer
		{
			IEnumerable<SelectListItem> _list;
			public ListRenderer(IEnumerable<SelectListItem> list)
			{
				_list = list;
			}

			SelectListGroup _currentGroup = null;
			CalystoHtmlElement _htmlGroup = null;

			private void ResetRenderer()
			{
				_currentGroup = null;
				_htmlGroup = null;
			}

			private CalystoHtmlElement FinalizeGroup()
			{
				if(_htmlGroup == null)
					throw new InvalidOperationException($"{nameof(_htmlGroup)} is null");
				
				var g1 = _htmlGroup;
				this.ResetRenderer();
				return g1;
			}

			private void StartNewGroup(SelectListItem item)
			{
				if (_currentGroup != null)
					throw new InvalidOperationException($"{nameof(_currentGroup)} is not null");
				if(_htmlGroup != null)
					throw new InvalidOperationException($"{nameof(_htmlGroup)} is not null");

				_currentGroup = item.Group;
				_htmlGroup = new CalystoHtmlElement("optgroup").UsingThis(s =>
				{
					if (item.Group.Disabled)
						s.SetAttribute("disabled", "disabled");

					if (!string.IsNullOrWhiteSpace(item.Group.Name))
						s.SetAttribute("label", item.Group.Name);
				});
			}

			private CalystoHtmlElement CreateOption(SelectListItem item)
			{
				var el1 = new CalystoHtmlElement("option");
				if (item.Disabled)
					el1.SetAttribute("disabled", "disabled");

				if (item.Selected)
					el1.SetAttribute("selected", "selected");

				// value has to be set if it is empty string "", this is required for validation to work
				if (item.Value != null)
					el1.SetAttribute("value", item.Value);

				el1.SetInnerHtml(item.Text);

				return el1;
			}

			public IEnumerable<CalystoHtmlElement> RenderList()
			{
				this.ResetRenderer();

				foreach (var item in _list)
				{
					if (item.Group != null)
					{
						if (_currentGroup?.Name != item.Group.Name || _currentGroup?.Disabled != item.Group.Disabled)
						{
							// we have to start new group, but yield current group first

							if (_currentGroup != null)
								yield return this.FinalizeGroup();

							this.StartNewGroup(item);
						}
						else
						{
							// will append to exsisting group
						}
					}
					else if (_currentGroup != null)
					{
						yield return this.FinalizeGroup();
					}

					// create option element
					var el1 = this.CreateOption(item);

					// add to parent, or yield el if there is no group
					if (_htmlGroup != null)
						_htmlGroup.AddChildren(el1);
					else
						yield return el1;
				}

				// at the end, yield group if there is any
				if (_htmlGroup != null)
					yield return _htmlGroup;
			}
		}
	}
}
