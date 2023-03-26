using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Model
{
    public class SettingClass
    {
        public string ProjectName { get; set; }
        public string PageName { get; set; }
        public string PageType { get; set; }
        public List<PropertyClass> Properties { get; set; }
        public List<CommandClass> Commands { get; set; }

        public SettingClass()
        {
            ProjectName= string.Empty;
            PageName= string.Empty;
            PageType= string.Empty;
            Properties = new List<PropertyClass>();
            Commands = new List<CommandClass>();
        }

    }
}
