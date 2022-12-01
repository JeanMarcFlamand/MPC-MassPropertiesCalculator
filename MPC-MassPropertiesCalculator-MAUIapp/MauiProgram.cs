using MPC_MassPropertiesCalculator_MAUIapp.ViewModels;
using MPC_MassPropertiesCalculator_MAUIapp.Views;


namespace MPC_MassPropertiesCalculator_MAUIapp
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

            builder.Services.AddSingleton<TestView>();
            builder.Services.AddSingleton<TestViewModel>();

            return builder.Build();
        }
        
    }
    
}