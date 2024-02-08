using Infraestutura.Dados;
using Microsoft.Extensions.Logging;
using Sonambulo.ViewModel;

namespace Sonambulo
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient((services) =>
            {
                return new ContextoDadosSonambulo(Path.Combine(FileSystem.AppDataDirectory, "SQLite001.db3"));
            });

            return builder.Build();
        }
    }
}
