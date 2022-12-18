using MPC_MassPropertiesCalculator_MAUIapp.ViewModels;
using System;

namespace MPC_MassPropertiesCalculator_MAUIapp.Views;

public partial class AboutmeView : ContentPage
{
    public AboutmeView(AboutmeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void LinkedIn_Clicked(object sender, EventArgs e)
    {
        Navigateto("https://www.linkedin.com/in/jean-marc-flamand-79592422/");
    }

    private void GitHub_Clicked(object sender, EventArgs e)
    {
        Navigateto("https://github.com/JeanMarcFlamand?tab=repositories");
    }

    private void StackOverFlow_Clicked(object sender, EventArgs e)
    {
        Navigateto("https://stackoverflow.com/users/2594076/jean-marc-flamand?tab=profile");
    }

    private void AzureDevOps_Clicked(object sender, EventArgs e)
    {
        Navigateto("https://7jtf.visualstudio.com/");
    }

    private static async void Navigateto(string v)
    {
        try
        {
            Uri uri = new Uri(v);
            BrowserLaunchOptions options = new BrowserLaunchOptions()
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Colors.Violet,
                PreferredControlColor = Colors.SandyBrown
            };

            await Browser.Default.OpenAsync(uri, options);
        }
        catch (Exception ex)
        {
            // An unexpected error occured. No browser may be installed on the device.
        }
    }

    
}
