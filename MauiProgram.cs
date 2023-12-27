using FinalApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace FinalApp
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
            builder.Services.AddSingleton<MainVM>();
            builder.Services.AddSingleton<DetailsPage>();
            builder.Services.AddSingleton<DetailsPageVM>();
            builder.Services.AddSingleton<FutureTasksPage>();
            builder.Services.AddSingleton<FutureTasksVM>();
            builder.Services.AddSingleton<GeneralTasksPage>();
            builder.Services.AddSingleton<GeneralTasksVM>();
            builder.Services.AddSingleton<AddTasksPage>();
            builder.Services.AddSingleton<AddTaskVM>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}