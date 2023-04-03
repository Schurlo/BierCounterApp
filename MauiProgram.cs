using _23._03._10_MAUI_BierApp.ModelView;
using _23._03._10_MAUI_BierApp.View;
using Microsoft.Extensions.Logging;

namespace _23._03._10_MAUI_BierApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<NewPageView>();
		//1:53:00 MAUI 4h YT-Video
		builder.Services.AddSingleton<CounterModelView>();

		builder.Services.AddSingleton<CounterView>();

        return builder.Build();
	}
}
