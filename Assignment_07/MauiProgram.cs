using Assignment_07.Mvvm.ViewModels;
using Assignment_07.Mvvm.Views;
using Assignment_07.Services;
using Microsoft.Extensions.Logging;

namespace Assignment_07
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

            builder.Services.AddSingleton<ContactService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
           
            builder.Services.AddSingleton<AddPage>();
            builder.Services.AddSingleton<AddPageViewModel>();
            
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsPageViewModel>();
            
            builder.Services.AddSingleton<EditPage>();
            builder.Services.AddSingleton<EditPageViewModel>();


            return builder.Build();
        }
    }
}