using _23._03._10_MAUI_BierApp.View;

namespace _23._03._10_MAUI_BierApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
