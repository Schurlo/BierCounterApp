using _23._03._10_MAUI_BierApp.ModelView;

namespace _23._03._10_MAUI_BierApp.View;

public partial class EditPageView : ContentPage
{
	public EditPageView()
	{
		InitializeComponent();

		BindingContext = new EditPageModelView();
	}
}