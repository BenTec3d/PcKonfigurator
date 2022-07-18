using PcKonfigurator.Client.HttpClients;
using PcKonfigurator.Client.Services;
using PcKonfigurator.Client.ViewModels;
using PcKonfigurator.Client.Views;

namespace PcKonfigurator.Client
{
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<AuthenticationPage>();
            builder.Services.AddSingleton<AuthenticationPageViewModel>();

            builder.Services.AddHttpClient<ComponentClient>().ConfigurePrimaryHttpMessageHandler(handler =>
           new HttpClientHandler()
           {
               AutomaticDecompression = System.Net.DecompressionMethods.GZip
           });

            builder.Services.AddHttpClient<AuthenticationClient>().ConfigurePrimaryHttpMessageHandler(handler =>
            new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
            });

            builder.Services.AddScoped<IComponentRepository, ComponentRepository>();
            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddSingleton<IPdfService, PdfService>();

            return builder.Build();
        }
    }
}