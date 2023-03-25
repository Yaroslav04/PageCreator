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
        public string PageType { get; set; } //list, simple
        public List<PropertiesClass> Properties { get; set; }

        public SettingClass()
        {
            ProjectName= string.Empty;
            PageName= string.Empty;
            PageType= string.Empty;
            Properties = new List<PropertiesClass>();
        }

    }
}
