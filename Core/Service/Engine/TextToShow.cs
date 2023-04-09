using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service.DataBase
{
    public static class TextToShow
    {
        public static string GetPageText(SettingClass setting)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[0], setting.PageType));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[0], setting.PageType);
            text = TegConverter.ConvertPageTegs(text, App.Setting);
            return text;
        }

        public static string GetBackgroundText(SettingClass setting)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[1], setting.PageType));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[1], setting.PageType);
            text = TegConverter.ConvertBackgroundTegs(text, App.Setting);
            return text;
        }

        public static string GetViewModelText(SettingClass setting)
        {
            //string text = TextManager.GetSimpleTextFromPath(FileManager.GetFilePath(EnumManager.FoldersType[2], setting.PageType));
            string text = TextManager.GetSimpleTextFromTemplate(EnumManager.FoldersType[2], setting.PageType);
            text = TegConverter.ConvertViewModelTegs(text, App.Setting);
            return text;
        }
    }
}
