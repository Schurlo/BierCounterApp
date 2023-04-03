using _23._03._10_MAUI_BierApp.ModelView;

namespace _23._03._10_MAUI_BierApp.View;

public partial class NewPageView : ContentPage
{
	public NewPageView()
	{
		InitializeComponent();

        BindingContext = new NewPageModelView();
	}
}