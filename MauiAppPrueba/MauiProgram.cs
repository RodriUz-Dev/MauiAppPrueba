using Microsoft.Extensions.Logging;

namespace MauiAppPrueba
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
                    fonts.AddFont("Lato-Bold.ttf", "bold");
                    fonts.AddFont("Lato-Regular.ttf", "regular");
                    fonts.AddFont("Lato-Black.ttf", "black");
                    fonts.AddFont("Lato-Italic.ttf", "italic");
                    fonts.AddFont("FontAwesomeSolid.otf", "SolidFont");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
