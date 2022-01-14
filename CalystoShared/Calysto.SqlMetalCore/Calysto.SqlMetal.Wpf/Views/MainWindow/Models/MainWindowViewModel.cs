using Calysto.ComponentModel;
using Calysto.SqlMetal.Wpf.Views.OrmGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.SqlMetal.Wpf.Views.MainWindow.Models
{
	public class MainWindowViewModel : BindableBase<MainWindowViewModel>
	{
		public OrmGeneratorViewModel OrmGenerator
		{
			get => base.Get(o => o.OrmGenerator);
			set => base.Set(o => o.OrmGenerator, value);
		}

		public MainWindowViewModel(OrmGeneratorViewModel ormGenerator)
		{
			this.OrmGenerator = ormGenerator;
		}
	}
}
