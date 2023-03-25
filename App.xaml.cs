using PageCreator.Core.Model;

namespace PageCreator;

public partial class App : Application
{
    static SettingClass setting { get; set; }
    public static SettingClass Setting
    {
        get
        {
            if (setting == null)
            {
                setting = new SettingClass();
            }
            return setting;
        }
        set
        {
            setting = value;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
