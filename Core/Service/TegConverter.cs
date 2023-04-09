using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service
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


            if (_setting.Commands.Count > 0)
            {
                text = text.Replace("$commands$", CreateCommands(_setting));
            }
            else
            {
                text = text.Replace("$commands$", "");
            }


            if (_setting.Commands.Count > 0)
            {
                text = text.Replace("$functions$", CreateFunctions(_setting));
            }
            else
            {
                text = text.Replace("$functions$", "");
            }


            if (!string.IsNullOrWhiteSpace(GetConstructors(_setting)))
            {
                text = text.Replace("$constructors$", GetConstructors(_setting));
            }
            else
            {
                text = text.Replace("$constructors$", "");
            }

            return text;

        }

        #region PropertiesConverter

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
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[3], _property.Template));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[3], _property.Template);
            text = text.Replace("$propertyMajor$", _property.Name);
            string properyMinor = _property.Name[0].ToString().ToLower() + _property.Name.Substring(1);
            text = text.Replace("$propertyMinor$", properyMinor);
            text = text.Replace("$propertyType$", _property.Type);
            return text;
        }

        #endregion

        #region CommandConverter

        private static string CreateCommands(SettingClass _setting)
        {
            string text = string.Empty;
            var commands = _setting.Commands;
            foreach (var command in commands)
            {
                text = text + ConvertCommandToCommandText(command) + "\n\n";
            }
            return text;
        }
        private static string ConvertCommandToCommandText(CommandClass _command)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[4], _command.Template));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[4], _command.Template);
            text = text.Replace("$commandName$", _command.Name);
            if (!string.IsNullOrWhiteSpace(_command.Type))
            {
                text = text.Replace("$commandType$", _command.Type);
            }
            else
            {
                text = text.Replace("<$commandType$>", "");
            }
            return text;
        }

        #endregion

        #region FunctionsConverter

        private static string CreateFunctions(SettingClass _setting)
        {
            string text = string.Empty;
            var commands = _setting.Commands;
            foreach (var command in commands)
            {
                text = text + GetFunctionFromCommand(command) + "\n\n";
            }
            return text;
        }

        private static string GetFunctionFromCommand(CommandClass _command)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[5], "Простой"));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[5], "Простой");
            text = text.Replace("$functionName$", _command.Name);
            return text;
        }

        #endregion

        #region ConstructorConverter

        private static string GetConstructors(SettingClass _setting)
        {
            string text = string.Empty;

            if (_setting.Properties.Count > 0)
            {
                foreach (var item in _setting.Properties)
                {
                    if (item.Template == EnumManager.PropertyTemplate[1])
                    {
                        text = text + GetPropertyConstructor(item) + "\n\n";
                    }
                }
            }

            if (_setting.Commands.Count > 0)
            {
                foreach (var item in _setting.Commands)
                {
                    text = text + GetCommandConstructor(item) + "\n\n";
                }
            }

            return text;

        }

        private static string GetPropertyConstructor(PropertyClass _property)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[6], "Параметр"));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[6], "Параметр");
            text = text.Replace("$propertyMajor$", _property.Name);
            text = text.Replace("$propertyType$", _property.Type);
            return text;
        }

        private static string GetCommandConstructor(CommandClass _command)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[6], "Команда"));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[6], "Команда");
            text = text.Replace("$commandName$", _command.Name);
            if (!string.IsNullOrWhiteSpace(_command.Type))
            {
                text = text.Replace("$commandType$", _command.Type);
            }
            else
            {
                text = text.Replace("<$commandType$>", "");
            }
            return text;
        }

        #endregion


    }
}
