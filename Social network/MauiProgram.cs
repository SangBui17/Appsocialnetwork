using Microsoft.Extensions.Logging;
using Social_network.Models;
using Social_network.Services;

namespace Social_network
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
                    fonts.AddFont("MaterialIcons-Regular.ttf", "IconFontTypes");
                });

#if DEBUG
    		builder.Logging.AddDebug();

#endif

            return builder.Build();
        }
    }
}
