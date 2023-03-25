using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service
{
    public static class EnumManager
    {
        public static List<string> PageType = new List<string>
        {
            "Список",
            "Пустой",
        };

        public static List<string> PropertiesTemplateType = new List<string>
        {
            "Простой",
        };
    }
}
