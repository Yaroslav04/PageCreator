using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service.DataBase
{
    public static class TegConverter
    {
        public static string ConvertPageTegs(string _text, SettingClass _setting)
        {
            string text = _text;
            text = text.Replace("$projectName$", _setting.ProjectName);
            text = text.Replace("$pageName$", _setting.PageName);
            return text;
        }

        public static string ConvertBackgroundTegs(string _text, SettingClass _setting)
        {
            string text = _text;
            text = text.Replace("$projectName$", _setting.ProjectName);
            text = text.Replace("$pageName$", _setting.PageName);
            return text;
        }

        public static string ConvertViewModelTegs(string _text, SettingClass _setting)
        {
            string text = _text;
            text = text.Replace("$projectName$", _setting.ProjectName);
            text = text.Replace("$pageName$", _setting.PageName);


            if (_setting.Properties.Count > 0)
            {
                text = text.Replace("$properties$", CreateProperties(_setting));
            }
            else
            {
                text = text.Replace("$properties$", "");
            }
            return text;

        }

        private static string CreateProperties(SettingClass _setting)
        {
            string text = string.Empty;
            var properties = _setting.Properties;
            foreach (var property in properties) 
            {
                text = text + ConvertPropertyToPropertyText(property) + "\n\n";
            }
            return text;
        }

        private static string ConvertPropertyToPropertyText(PropertyClass _property)
        {
            string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[3], _property.Template));
            text = text.Replace("$propertyMajor$", _property.Name);
            string properyMinor = _property.Name[0].ToString().ToLower() + _property.Name.Substring(1);
            text = text.Replace("$propertyMinor$", _property.Name);
            text = text.Replace("$propertyType$", _property.Type);
            return text;
        }     
    }
}
