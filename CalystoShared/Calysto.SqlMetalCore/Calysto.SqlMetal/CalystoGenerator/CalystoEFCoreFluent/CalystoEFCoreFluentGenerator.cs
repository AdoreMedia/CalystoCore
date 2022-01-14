using LinqToSqlShared.DbmlObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using Calysto.Linq;
using Calysto.Common;
using System.ComponentModel.DataAnnotations.Schema;
using Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent;

namespace LinqToSqlShared.CalystoGenerator.CalystoEFCoreFluent
{
	partial class CalystoEFCoreFluentGenerator
	{
		public string Generate(Database db)
		{
			//db = Dbml.CopyWithFilledInDefaults(db);
			CalystoStringWriter writer = new CalystoStringWriter();
			WriteWorker(db, writer);
			return writer.ToString();
		}

		private void WriteWorker(Database data, CalystoStringWriter writer)
		{
			writer.WriteBlockLine($@"//************************************************************
// Generated using {nameof(CalystoEFCoreFluentGenerator)} for {data.TargetMode}
//************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Calysto.EntityFrameworkCore;
using Calysto.Data.Direct;
using Calysto.Common;
using Calysto.Common.Extensions;
");

			if (!string.IsNullOrEmpty(data.ContextNamespace))
			{
				writer.WriteBlockLine("namespace " + data.ContextNamespace);
				writer.WriteBlockLine("{");
				writer.Indent++;
			}

			ContextClassWriter.Write(data, writer);

			EntityTypesWriter.WriteTablesTypes(data, writer);

			EntityTypesWriter.WriteFunctionsReturnTypes(data, writer);

			if (!string.IsNullOrEmpty(data.ContextNamespace))
			{
				writer.Indent--;
				writer.WriteLine();
				writer.WriteBlockLine("}");
			}

		}

		internal string Generate(Database db, object useEntityBase)
		{
			throw new NotImplementedException();
		}
	}
}
