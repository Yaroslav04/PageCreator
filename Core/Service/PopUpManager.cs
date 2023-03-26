using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.Service
{
    public static class PopUpManager
    {
        public static async Task ShowMessage(string _title, string _message)
        {
            await Shell.Current.DisplayAlert(_title, _message, "OK");
        }
    }
}
