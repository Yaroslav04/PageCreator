using PageCreator.Core.Service.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.ViewModel
{
    public class CreatePagePageViewModel : BaseViewModel
    {
        public CreatePagePageViewModel()
        {

        }

        public void OnAppearing()
        {
            if (!String.IsNullOrWhiteSpace(App.Setting.ProjectName) & !String.IsNullOrWhiteSpace(App.Setting.PageName)
                & !String.IsNullOrWhiteSpace(App.Setting.PageType))
            {
                Text = TextToShow.GetPageText(App.Setting);
            }
        }

        #region Properties


        private string text;
        public string Text
        {
            get => text;
            set
            {
                SetProperty(ref text, value);

            }
        }

        #endregion
    }
}
