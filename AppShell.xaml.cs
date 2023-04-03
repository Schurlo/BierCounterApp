using _23._03._10_MAUI_BierApp.View;

namespace _23._03._10_MAUI_BierApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NewPageView), typeof(NewPageView));

        Routing.RegisterRoute(nameof(EditPageView), typeof(EditPageView));
    }
}
