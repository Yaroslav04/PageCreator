namespace PageCreator.Core.View;

public partial class CreateBackgroundPage : ContentPage
{
    CreateBackgroundPageViewModel viewModel;
    public CreateBackgroundPage()
    {
        InitializeComponent();
        viewModel = new CreateBackgroundPageViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();
    }
}