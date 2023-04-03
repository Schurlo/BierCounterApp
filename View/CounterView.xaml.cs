using _23._03._10_MAUI_BierApp.ModelView;
using System.Runtime.CompilerServices;

namespace _23._03._10_MAUI_BierApp.View;

public partial class CounterView : ContentPage
{
	public CounterView(CounterModelView viewmodel)
	{
		InitializeComponent();

		BindingContext = viewmodel;
    }
}