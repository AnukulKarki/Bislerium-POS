using Microsoft.Extensions.Logging;
using Bislerium.Data;
using MudBlazor.Services;
using Bislerium.Service;
using MudBlazor;

namespace Bislerium;

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
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
		builder.Services.AddSingleton<UserServices>();
		builder.Services.AddSingleton<CoffeeServices>();
		builder.Services.AddSingleton<AddInsServices>();
		builder.Services.AddSingleton<OrderItemServices>();
		builder.Services.AddSingleton<CustomerService>();
		builder.Services.AddSingleton<OrderService>();
		builder.Services.AddSingleton<ReportService>();



#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomStart;
        });
#endif





        return builder.Build();


        
    }
}
