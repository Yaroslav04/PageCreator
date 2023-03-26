namespace PageCreator.Core.View;

public partial class CreateViewModelPage : ContentPage
{
    CreateViewModelPageViewModel viewModel;
    public CreateViewModelPage()
    {
        InitializeComponent();
        viewModel = new CreateViewModelPageViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();
    }
}