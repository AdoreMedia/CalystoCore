using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalystoGenesisTests.Calysto.AbstractSyntaxTree.Model
{
    public class ValidatorsViewModel
    {
        public CalystoModel CalystoModel { get; set; } = new CalystoModel();

        public CalystoModel CalystoModel2 { get; set; } = new CalystoModel();

        public List<CalystoModel> List1 { get; set; } = new List<CalystoModel>() { new CalystoModel() { Age = 1, Name = "naziv" } };

        public Dictionary<string, CalystoModel> Dic1 { get; set; } = new Dictionary<string, CalystoModel>()
        {
            {"Key1", new CalystoModel(){Age = 150, Name = "Thomas" } }
        };
    }

}
