using PageCreator.Core.Model;
using PageCreator.Core.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.ViewModel
{
    public class SettingPageViewModel : BaseViewModel
    {
        public SettingPageViewModel()
        {
            Properties = new ObservableCollection<PropertiesClass>();
            PageTypeList = new ObservableCollection<string>(EnumManager.PageType);
            TemplatePropertiesList = new ObservableCollection<string>(EnumManager.PropertiesTemplateType);

            AddPropertyCommand = new Command(async () => await AddProperty());
            ImportCommand = new Command(async () => await Import());

        }

        private async Task Import()
        {
            App.Setting.ProjectName = ProjectName;
            App.Setting.PageName = PageName;
            App.Setting.PageType = PageType;

            App.Setting.Properties.Clear();
            if (Properties.Count> 0 ) 
            {
                foreach(var item in Properties)
                {
                    App.Setting.Properties.Add(item);
                }
            }
           
        }

        public void OnAppearing()
        {
            ProjectName = App.Setting.ProjectName;
            PageName = App.Setting.PageName;
            PageType = App.Setting.PageType;
            Properties.Clear();
            if (App.Setting.Properties.Count> 0 ) 
            {
                foreach (var item in App.Setting.Properties)
                {
                    Properties.Add(item);
                }
            }        
        }

        #region Properties


        private string projectName;
        public string ProjectName
        {
            get => projectName;
            set
            {
                SetProperty(ref projectName, value);

            }
        }

        private string pageName;
        public string PageName
        {
            get => pageName;
            set
            {
                SetProperty(ref pageName, value);

            }
        }

        public ObservableCollection<string> PageTypeList { get; }

        private string pageType;
        public string PageType
        {
            get => pageType;
            set
            {
                SetProperty(ref pageType, value);

            }
        }

        private string property;
        public string Property
        {
            get => property;
            set
            {
                SetProperty(ref property, value);

            }
        }

        public ObservableCollection<PropertiesClass> Properties { get; }
        public ObservableCollection<string> TemplatePropertiesList { get; }

        private string templateProperties;
        public string TemplateProperties
        {
            get => templateProperties;
            set
            {
                SetProperty(ref templateProperties, value);

            }
        }

        private string typeProperties;
        public string TypeProperties
        {
            get => typeProperties;
            set
            {
                SetProperty(ref typeProperties, value);

            }
        }

        #endregion

        #region Command

        public Command AddPropertyCommand { get; }
        public Command ImportCommand { get; }

        #endregion

        private async Task AddProperty()
        {
            PropertiesClass property = new PropertiesClass();
            property.Name = Property;
            property.Template = TemplateProperties;
            property.Type = TypeProperties;
            Properties.Add(property);
        }
    }
}
