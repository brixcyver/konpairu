using CommunityToolkit.Maui;
using Konpairu.Models;
using Microsoft.Extensions.Logging;

namespace Konpairu
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<KonpairuPage>();
            builder.Services.AddSingleton<KonpairuViewModel>();
            builder.Services.AddSingleton<AboutPage>();
            builder.Services.AddSingleton<LexicalAnalyzer>();
            builder.Services.AddSingleton<SyntaxAnalyzer>();
            builder.Services.AddSingleton<SemanticAnalyzer>();

            return builder.Build();
        }
    }
}