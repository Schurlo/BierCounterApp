using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace _23._03._10_MAUI_BierApp;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
