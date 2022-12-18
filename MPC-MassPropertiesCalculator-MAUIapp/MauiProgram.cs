using MPC_MassPropertiesCalculator_MAUIapp.ViewModels;
using MPC_MassPropertiesCalculator_MAUIapp.Views;
using MPCFilePickerMauiLibrary;

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

            builder.Services.AddSingleton<MPCDataGridView>();

            builder.Services.AddSingleton<TestView>();
            builder.Services.AddSingleton<TestViewModel>();
            builder.Services.AddSingleton<AboutmeView>();
            builder.Services.AddSingleton<AboutmeViewModel>();

            //From Nuget package https://www.nuget.org/packages/MPCFilePickerMauiLibrary
            builder.Services.AddSingleton<PickTxtFile>();
            builder.Services.AddSingleton<PickFile>();



            return builder.Build();
        }
        
    }
    
}