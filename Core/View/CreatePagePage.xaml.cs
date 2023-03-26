namespace PageCreator.Core.View;

public partial class CreatePagePage : ContentPage
{

	CreatePagePageViewModel viewModel;
	public CreatePagePage()
	{
		InitializeComponent();
		viewModel = new CreatePagePageViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();
    }
}