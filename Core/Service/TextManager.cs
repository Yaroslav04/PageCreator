using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static string GetSimpleTextFromTemplate(string _type, string _obj)
        {
            string result;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"PageCreator.Templates.{_type}.{_obj}.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
