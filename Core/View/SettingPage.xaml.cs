
using System.Diagnostics;

namespace PageCreator.Core.View;

public partial class SettingPage : ContentPage
{
    SettingPageViewModel viewModel;
    public SettingPage()
	{
		InitializeComponent();
        viewModel = new SettingPageViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();
    }

    protected override void OnDisappearing()
    {      
        base.OnDisappearing();
        viewModel.OnDisappearing();
    }
}