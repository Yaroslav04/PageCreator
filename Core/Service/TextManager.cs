using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service
{
    public static class TextManager
    {
        public static string GetSimpleTextFromPath(string _path)
        {
            string text = string.Empty;
            using (StreamReader sr = new StreamReader(_path))
            {
                text = sr.ReadToEnd();
            }

            return text;
        }
    }
}
