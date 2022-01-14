using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using Calysto.Extensions;
using Calysto.Utility;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Reflection;
using Calysto.Linq;
using System.Web;
using System.Data;
using System.Threading;

namespace Calysto.Web.Extensions
{
	public static class ControlExtensions
	{
		static FieldInfo _inOnFormRender = typeof(Page).GetField("_inOnFormRender", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

		/// <summary>
		/// Ignore missing form to enable rendering of TextBox and similar controls without Form element on page
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="page"></param>
		/// <returns></returns>
		public static T IgnoreMissingForm<T>(this T page, bool ignore = true) where T: Page
		{
			_inOnFormRender.SetValue(page, ignore); // set to true: it will allow rendering of TextBox, DropDownBox etc. without Form on page
			return page;
		}

		#region Utility extensions

		public static T Set<T>(this T control, Action<T> action) where T : Control
		{
			action.Invoke(control);
			return control;
		}

		/// <summary>
		/// JS events are concatenated, separated by ;
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="control"></param>
		/// <param name="eventName"></param>
		/// <param name="js"></param>
		/// <returns></returns>
		public static T AppendEvent<T>(this T control, JavascriptEventEnum eventName, string js) where T : IAttributeAccessor
		{
			string name = "on" + eventName.GetStringValue();
			string curr = control.GetAttribute(name) ?? "";
			if (!string.IsNullOrEmpty(curr) && !curr.EndsWith(";"))
			{
				curr += ";";
			}
			curr += js;
			if (!curr.EndsWith(";"))
			{
				curr += ";";
			}
			control.SetAttribute(name, curr);
			return control;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T">name or CSV names</typeparam>
		/// <param name="control"></param>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T ApplyAttribute<T>(this T control, string name, string value) where T : IAttributeAccessor
		{
			control.SetAttribute(name, value);
			return control;
		}

		public static T ApplyAttribute<T>(this T control, IEnumerable<string> names, string value) where T : IAttributeAccessor
		{
			names.ForEach(name => control.SetAttribute(name, value));
			return control;
		}

		static FieldInfo _isCallback = typeof(Page).GetField("_isCallback", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
		static MethodInfo _miPreRenderRecursiveInternal = typeof(Control).GetMethod("PreRenderRecursiveInternal", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
		static FieldInfo _parent = typeof(Control).GetField("_parent", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
		static FieldInfo _requestData = typeof(TraceContext).GetField("_requestData", BindingFlags.NonPublic | BindingFlags.Instance);

		public static string ToHtmlRendered(this Control c, bool innerHtmlOnly = false)
		{ 
			bool restoreCallbackState = false;

			if (c.Page != null)
			{
				// allow rendering TextBox without form
				_inOnFormRender.SetValue(c.Page, true);

				bool isCallback = (bool)_isCallback.GetValue(c.Page);
				if (!isCallback)
				{
					// set true to avoid TextBox exception: RegisterForEventValidation can only be called during Render()
					_isCallback.SetValue(c.Page, true);
					restoreCallbackState = true;
				}

				if (HttpRuntime.UsingIntegratedPipeline)
				{
					// required if rendereing from simulated socket web client
					if(_requestData.GetValue(c.Page.Trace) == null)
					{
						DataTable dt = new DataTable("Trace_Control_Tree");
						var col1 = new DataColumn("MyPK") { Unique = true };
						dt.Columns.Add(col1);
						dt.PrimaryKey = new DataColumn[] { col1 };
						DataSet ds = new DataSet();
						ds.Tables.Add(dt);

						_requestData.SetValue(c.Page.Trace, ds);
					}
				}
			}

			// PreRenderRecursiveInternal() should be invoked at the end to create children, especially ITemplates, it invokes CreateChildControl() method in Calysto controls
			// but, invoking PreRenderRecursiveInternal() tests Visible property of ancestors and if any of ancestors is not Visible, this control won't be visible too
			// and that is why we set parent = null to cheat it
			Control parent = c.Parent;
			if(c.Parent != null)
			{
				_parent.SetValue(c, null);
			}

			// must be invoked this way to create children, especially in ITemplates
			// this will invoke OnPreRender(...) in descendants
			_miPreRenderRecursiveInternal.Invoke(c, null);

			System.IO.StringWriter sr = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter h = new HtmlTextWriter(sr);

			if (innerHtmlOnly)
			{
				foreach(Control ch in c.Controls)
				{
					ch.RenderControl(h);
				}
			}
			else
			{
				c.RenderControl(h);
			}

			if(parent != null)
			{
				_parent.SetValue(c, parent);
			}

			// restore isCallback
			if(restoreCallbackState)
			{
				_isCallback.SetValue(c.Page, false);
			}

			return sr.ToString();
		}

		public static TextBox TrimText(this TextBox control)
		{
			control.Text = control.Text.Trim();
			return control;
		}

		public static IEnumerable<TextBox> TrimText(this IEnumerable<TextBox> source)
		{
			return source.ForEach(o => o.Text = o.Text.Trim());
		}

		#endregion

		#region DOM manipulation extensions

		/// <summary>
		/// returns descendants
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="control"></param>
		/// <returns></returns>
		public static IEnumerable<Control> DescendantControls<TSource>(this TSource control) where TSource : Control
		{
			// select children than concat children's descendants
			// return control.Controls.Cast<Control>().Concat(control.Controls.Cast<Control>().SelectMany(n => n.DescendantControls()));
			// better, dig children's children immediately:
			foreach (Control c in control.Controls)
			{
				yield return c;

				foreach (Control c1 in c.DescendantControls())
				{
					yield return c1;
				}
			}
		}

		public static IEnumerable<Control> AncestorControls<TSource>(this TSource control) where TSource : Control
		{
			Control cc = control;
			while ((cc = cc.Parent) != null)
			{
				yield return cc;
			}
		}

		public static IEnumerable<Control> DescendantControls<TSource>(this IEnumerable<TSource> controls) where TSource : Control
		{
			return controls.SelectMany(o => o.DescendantControls());
		}

		public static IEnumerable<Control> AncestorControls<TSource>(this IEnumerable<TSource> controls) where TSource : Control
		{
			return controls.SelectMany(o => o.AncestorControls());
		}

		public static IEnumerable<Control> ParentControls<TSource>(this IEnumerable<TSource> controls) where TSource : Control
		{
			return controls.Select(o => o.Parent);
		}

		public static IEnumerable<Control> ChildControls<TSource>(this IEnumerable<TSource> controls) where TSource : Control
		{
			return controls.SelectMany(o => o.Controls.Cast<Control>());
		}

		public static IEnumerable<Control> ChildControls<TSource>(this TSource control) where TSource : Control
		{
			return control.Controls.Cast<Control>();
		}

		public static TSource RemoveChildren<TSource>(this TSource control) where TSource : Control
		{
			control.Controls.Clear();
			return control;
		}

		public static TSource AddChildren<TSource>(this TSource control, params Control[] children) where TSource : Control
		{
			// must create collection copy because controles are removed from children collection when added to different collection
			children.Where(o => o != null).ToList().ForEach(o => control.Controls.Add(o));
			return control;
		}

		public static TSource AddChildren<TSource>(this TSource control, params ITemplate[] templates) where TSource : Control
		{
			templates.Where(o => o != null).ForEach(o => o.InstantiateIn(control));
			return control;
		}

		public static TSource InsertChildren<TSource>(this TSource control, params Control[] children) where TSource : Control
		{
			// must create collection copy because controles are removed from children collection when added to different collection
			children.Where(o => o != null).Reverse().ToList().ForEach(o => control.Controls.AddAt(0, o));
			return control;
		}

		public static TSource InsertBefore<TSource>(this TSource control, params Control[] items) where TSource : Control
		{
			int index = control.Parent.Controls.IndexOf(control);
			items.Reverse().ForEach(o => control.Parent.Controls.AddAt(index, o));
			return control;
		}

		public static TSource InsertAfter<TSource>(this TSource control, params Control[] items) where TSource : Control
		{
			int index = control.Parent.Controls.IndexOf(control);
			items.Reverse().ForEach(o => control.Parent.Controls.AddAt(index + 1, o));
			return control;
		}

		#endregion
	
		#region next siblings

		public static IEnumerable<Control> NextSiblings<TSource>(this TSource node) where TSource:Control
		{
			if (node.Parent != null)
			{
				foreach (Control s in node.Parent.Controls.Cast<Control>().SkipWhile(o => o != node).Skip(1))
				{
					yield return s;
				}
			}
		}

		public static IEnumerable<Control> NextSiblings<TSource>(this TSource node, Func<Control, bool> predicate) where TSource:Control
		{
			return node.NextSiblings().Where(predicate);
		}

		public static IEnumerable<Control> NextSiblings<TSource>(this IEnumerable<TSource> list) where TSource:Control
		{
			return list.SelectMany(o => o.NextSiblings());
		}

		public static IEnumerable<Control> NextSiblings<TSource>(this IEnumerable<TSource> list, Func<Control, bool> predicate) where TSource:Control
		{
			return list.NextSiblings().Where(predicate);
		}

		#endregion

		#region previous siblings

		public static IEnumerable<Control> PreviousSiblings<TSource>(this TSource node) where TSource:Control
		{
			if (node.Parent != null)
			{
				foreach (Control s in node.Parent.Controls.Cast<Control>().TakeWhile(o => o != node).Reverse())
				{
					// backward:
					// n0, n1, n2, n3, n4=current, n5, n5, will return nodes: n3, n2, n1, n0
					yield return s;
				}
			}
		}

		public static IEnumerable<Control> PreviousSiblings<TSource>(this TSource node, Func<Control, bool> predicate) where TSource:Control
		{
			return node.PreviousSiblings().Where(predicate);
		}

		public static IEnumerable<Control> PreviousSiblings<TSource>(this IEnumerable<TSource> list) where TSource:Control
		{
			return list.SelectMany(o => o.PreviousSiblings());
		}

		public static IEnumerable<Control> PreviousSiblings<TSource>(this IEnumerable<TSource> list, Func<Control, bool> predicate) where TSource:Control
		{
			return list.PreviousSiblings().Where(predicate);
		}

		#endregion

		#region Css Style extensions

		public static List<KeyValuePair<string, string>> ParseStyleValues(string style)
		{
			// should parse style like this:
			// background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAAICAQAAACxSAwfAAAAUklEQ…BbClcIUcSAw21QhXxfIIrwKAMpfNsEUYRXGVCEFc6CQwBqq4CCCtU4VgAAAABJRU5ErkJggg==),-webkit-linear-gradient(#ededed,#ededed 38%,#dedede);
			
			return new Regex("(?<name>[^:;]+):(?<value>(([\\(][^\\)]+[\\)])|[^:;])*)").Matches(style ?? "").Cast<Match>()
				.Select(m=>new KeyValuePair<string, string>(m.Groups["name"].Value.Trim(), m.Groups["value"].Value.Trim()))
				.Where(o=>!string.IsNullOrEmpty(o.Key)).ToList();
		}

		/// <summary>
		/// Remove previous style values with the same names and append new vlues.
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="style"></param>
		/// <returns></returns>
		public static CssStyleCollection ApplyValues(this CssStyleCollection sc, List<KeyValuePair<string, string>> style)
		{
			foreach (KeyValuePair<string, string> kv in style)
			{
				// we must remove preivous values, not just overwrite. By removing first, new values will be appended to the end. Css always use last stye value.
				// eg. in this scenario, if "background" is not removed first, background-color will always be blue because "background" is changed to green, but "background-color" overrides it
				//Panel ppp = new Panel();
				//ppp.Style.SetValues("background:red; background-color:blue;");
				//ppp.Style.SetValues("background:green;");

				sc.Remove(kv.Key); // remove it first so the new value will be appended to the end
				
				sc.Add(kv.Key, kv.Value);
			}
			return sc;
		}

		/// <summary>
		/// Remove previous style values with the same names and append new vlues.
		/// </summary>
		/// <param name="sc"></param>
		/// <param name="style"></param>
		/// <returns></returns>
		public static CssStyleCollection ApplyValues(this CssStyleCollection sc, string style)
		{
			return sc.ApplyValues(ParseStyleValues(style));
		}

		public static T ApplyStyle<T>(this T control, string style) where T : IAttributeAccessor
		{
			if (!string.IsNullOrEmpty(style))
			{
				CssStyleCollection col = new HtmlGenericControl().Style.ApplyValues(control.GetAttribute("style")).ApplyValues(style);
				control.SetAttribute("style", col.Value);
			}
			return control;
		}

		public static IEnumerable<T> ApplyStyle<T>(this IEnumerable<T> source, string style) where T : IAttributeAccessor
		{
			return source.ForEach(o => o.ApplyStyle(style));
		}

		#endregion

		#region Css class extensions

		public static T AddClass<T>(this T control, string cssClass) where T : IAttributeAccessor
		{
			if (!string.IsNullOrEmpty(cssClass))
			{
				control.RemoveClass(cssClass); // to avoid duplicates and to place cssClass at the end
				
				if (control is WebControl)
				{
					WebControl cc = (WebControl)(object)control;
					cc.CssClass = (cc.CssClass + " " + cssClass).Trim();
				}
				else
				{
					string cls = control.GetAttribute("class");
					control.SetAttribute("class", (cls + " " + cssClass).Trim());
				}
			}
			return control;
		}

		public static string SelectClass<T>(this T control) where T : IAttributeAccessor
		{
			if (control is WebControl)
			{
				return ((WebControl)(object)control).CssClass;
			}
			else
			{
				return control.GetAttribute("class");
			}
		}

		public static IEnumerable<T> AddClass<T>(this IEnumerable<T> source, string cssClass) where T : IAttributeAccessor
		{
			return source.ForEach(o => o.AddClass(cssClass));
		}

		public static T RemoveClass<T>(this T control, string cssClass) where T : IAttributeAccessor
		{
			if (!string.IsNullOrEmpty(cssClass))
			{
				if (control is WebControl)
				{
					WebControl cc = (WebControl)(object)control;
					cc.CssClass = (" " + cc.CssClass + " ").Replace(" " + cssClass + " ", " ").Trim();
				}
				else
				{
					string cls = " " + control.GetAttribute("class") + " ";
					control.SetAttribute("class", (cls.Replace(" " + cssClass + " ", " ")).Trim());
				}
			}
			return control;
		}

		public static IEnumerable<T> RemoveClass<T>(this IEnumerable<T> source, string cssClass) where T : IAttributeAccessor
		{
			return source.ForEach(o => o.RemoveClass(cssClass));
		}

		public static bool HasClass<T>(this T control, string cssClass) where T : IAttributeAccessor
		{
			if (!string.IsNullOrEmpty(cssClass))
			{
				if (control is WebControl)
				{
					WebControl cc = (WebControl)(object)control;
					return (" " + cc.CssClass + " ").Contains(" " + cssClass + " ");
				}
				else
				{
					string cls = " " + control.GetAttribute("class") + " ";
					return cls.Contains(" " + cssClass + " ");
				}
			}
			else
			{
				return false;
			}
		}

		public static T ToggleClass<T>(this T control, string cssClass) where T : IAttributeAccessor
		{
			if (control.HasClass(cssClass))
			{
				return control.RemoveClass(cssClass);
			}
			else
			{
				return control.AddClass(cssClass);
			}
		}

		public static IEnumerable<T> ToggleClass<T>(this IEnumerable<T> source, string cssClass) where T : IAttributeAccessor
		{
			return source.ForEach(o => o.ToggleClass(cssClass));
		}

		#endregion

		#region ListControl extensions

		public static bool SetSelectedValue(this ListControl control, object value)
		{
			control.SelectedIndex = -1; // select none or first, if value will not be found, this way we have first (default) item selected

			ListItem item = control.Items.FindByValue(value + "");
			if (item != null)
			{
				control.SelectedIndex = control.Items.IndexOf(item);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool SetSelectedText(this ListControl control, string text)
		{
			control.SelectedIndex = -1; // select none or first, if value will not be found, this way we have first (default) item selected

			ListItem item = control.Items.FindByText(text);
			if (item != null)
			{
				control.SelectedIndex = control.Items.IndexOf(item);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static TResult GetSelectedValue<TResult>(this ListControl control)
		{
			TResult o;
			CalystoTypeConverter.TryChangeType<TResult>(control.SelectedValue, out o);
			return o;
		}

		#endregion

		#region TreeView extensions

		public static IEnumerable<TreeNode> DescendantNodes(this TreeNode node)
		{
			if (node != null && node.ChildNodes != null && node.ChildNodes.Count > 0)
			{
				foreach (TreeNode n in node.ChildNodes)
				{
					yield return n;

					foreach (TreeNode n1 in n.DescendantNodes())
					{
						yield return n1;
					}
				}
			}
		}

		public static IEnumerable<TreeNode> AncestorNodes(this TreeNode node)
		{
			while ((node = node.Parent) != null)
			{
				yield return node;
			}
		}

		public static IEnumerable<TreeNode> DescendantNodes(this TreeView treeView)
		{
			return treeView.Nodes.Cast<TreeNode>().Concat(treeView.Nodes.Cast<TreeNode>().SelectMany(o => o.DescendantNodes()));
		}

		#endregion

	}
}
