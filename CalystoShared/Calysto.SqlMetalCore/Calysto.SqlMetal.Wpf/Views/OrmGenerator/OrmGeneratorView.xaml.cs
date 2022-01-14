using Calysto.SqlMetal.Wpf.Views.OrmGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using SqlMetal;

namespace Calysto.SqlMetal.Wpf.Views.OrmGenerator
{
	/// <summary>
	/// Interaction logic for OrmGeneratorView.xaml
	/// </summary>
	public partial class OrmGeneratorView : UserControl
	{
		public OrmGeneratorView()
		{
			this.DataContext = App.ServiceProvider.GetService<OrmGeneratorViewModel>();
			if (this.DataContext == null)
				throw new ArgumentNullException(nameof(DataContext));

			InitializeComponent();
		}

		private void listView_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			ListView listView1 = ((ListView)sender);
			listView1.ItemContainerGenerator.ItemsChanged += (object sender2, System.Windows.Controls.Primitives.ItemsChangedEventArgs e2) =>
			{
				// scroll into view the last row
				if (listView1.Items.Count > 0)
				{
					listView1.SelectedIndex = listView1.Items.Count - 1;
					listView1.ScrollIntoView(listView1.Items[listView1.Items.Count - 1]);
				}
			};
		}

		/// <summary>
		/// Return selected items, or all if none is selected.
		/// </summary>
		/// <returns></returns>
		private IEnumerable<DatabaseItemSetting> GetModelItems()
		{
			var model = App.ServiceProvider.GetService<OrmGeneratorViewModel>();
			var selected = dataGrid1.SelectedItems.Cast<DatabaseItemSetting>().ToList();
			if (selected.Any())
			{
				return selected;
			}
			else
			{
				return model.DatabaseItemsCollection?.ToList();
			}
		}

		private void Button_SelectAll(object sender, RoutedEventArgs e)
		{
			this.GetModelItems()?.ToList().ForEach(o => o.Checked = true);
		}

		private void Button_SelectNone(object sender, RoutedEventArgs e)
		{
			this.GetModelItems()?.ToList().ForEach(o => o.Checked = false);
		}

		private void Button_SelectDefault(object sender, RoutedEventArgs e)
		{
			this.GetModelItems()?.ToList()
				.ForEach(item => item.Checked = !item.FullName.Contains(".__") && !(item.FullName.Contains(".fn_") || item.FullName.Contains(".sp_")));
		}

		private void Button_SelectToggle(object sender, RoutedEventArgs e)
		{
			this.GetModelItems()?.ToList().ForEach(o => o.Checked = !o.Checked);
		}
	}
}
