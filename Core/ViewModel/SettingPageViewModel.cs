﻿using PageCreator.Core.Model;
using PageCreator.Core.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace PageCreator.Core.ViewModel
{
    public class SettingPageViewModel : BaseViewModel
    {
        public SettingPageViewModel()
        {
            Properties = new ObservableCollection<PropertyClass>();
            Commands = new ObservableCollection<CommandClass>();
            PageTypeList = new ObservableCollection<string>(EnumManager.PageType);
            PropertiesTemplateList = new ObservableCollection<string>(EnumManager.PropertyTemplate);
            CommandsTemplateList = new ObservableCollection<string>(EnumManager.CommandTemplate);

            AddPropertyCommand = new Command(async () => await AddProperty());
            AddCommandCommand = new Command(async () => await AddCommand());

            ClearCommand = new Command(async () => await Clear());
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
            
            Commands.Clear();
            if (App.Setting.Commands.Count > 0)
            {
                foreach (var item in App.Setting.Commands)
                {
                    Commands.Add(item);
                }
            }

        }

        public void OnDisappearing()
        {
            Import();
        }

        #region Properties


        #region Project

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

        #endregion

        #region Property

        public ObservableCollection<PropertyClass> Properties { get; }
        public ObservableCollection<string> PropertiesTemplateList { get; }

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

        #region Commands

        public ObservableCollection<CommandClass> Commands { get; }

        private string command;
        public string Command
        {
            get => command;
            set
            {
                SetProperty(ref command, value);

            }
        }

        private string commandType;
        public string CommandType
        {
            get => commandType;
            set
            {
                SetProperty(ref commandType, value);

            }
        }

        public ObservableCollection<string> CommandsTemplateList { get; }

        private string commandTemplate;
        public string CommandTemplate
        {
            get => commandTemplate;
            set
            {
                SetProperty(ref commandTemplate, value);

            }
        }

        #endregion

        #endregion

        #region Command

        public Command AddPropertyCommand { get; }
        public Command AddCommandCommand { get; }
        public Command ClearCommand { get; }

        #endregion

        private async Task AddProperty()
        {
            PropertyClass property = new PropertyClass();
            property.Name = Property;
            property.Template = TemplateProperties;
            property.Type = TypeProperties;
            Properties.Add(property);
        }

        private async Task AddCommand()
        {
            CommandClass command = new CommandClass();
            command.Name = Command;
            command.Type = CommandType;
            command.Template = CommandTemplate;
            Commands.Add(command);
        }

        private async Task Clear()
        {
            ProjectName = string.Empty;
            PageName= string.Empty;
            PageType = null;
            TemplateProperties= string.Empty;
            Property = string.Empty;
            TypeProperties = string.Empty;
            Properties.Clear();
            CommandTemplate = string.Empty;
            Command = string.Empty;
            CommandType = string.Empty;
            Commands.Clear();

        }

        private void Import()
        {
            App.Setting.ProjectName = ProjectName;
            App.Setting.PageName = PageName;
            App.Setting.PageType = PageType;

            App.Setting.Properties.Clear();
            if (Properties.Count > 0)
            {
                foreach (var item in Properties)
                {
                    App.Setting.Properties.Add(item);
                }
            }

            App.Setting.Commands.Clear();
            if (Commands.Count > 0)
            {
                foreach (var item in Commands)
                {
                    App.Setting.Commands.Add(item);
                }
            }
        }
    }
}
