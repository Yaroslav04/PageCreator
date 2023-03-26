using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service
{
    public static class FileManager
    {
        public static string GetPath()
        {
            return @"D:\Projects\PageCreatorTemplate";
        }

        public static string GetPath(string _path)
        {
            return Path.Combine(@"D:\Projects\PageCreatorTemplate", _path);
        }

        public static string GetFilePath(string _type, string _name)
        {
            return Path.Combine(GetPath(), Path.Combine(_type, _name + ".txt"));
        }
    }
}
