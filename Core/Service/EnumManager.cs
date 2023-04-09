using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service
{
    public static class EnumManager
    {
        #region VisualElements

        public static List<string> PageType = new List<string>
        {
            "Список",
        };

        public static List<string> PropertyTemplate = new List<string>
        {
            "Простой",
            "Коллекция",
        };

        public static List<string> CommandTemplate = new List<string>
        {
            "Простой",
        };

        #endregion


        public static List<string> FoldersType = new List<string>
        {
            "Page",
            "Background",
            "ViewModel",
            "Property",
            "Command",
            "Function",
            "Constructor",
        };
    }
}
