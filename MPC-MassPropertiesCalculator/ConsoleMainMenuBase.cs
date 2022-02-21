namespace MPC_MassPropertiesCalculator;

public class ConsoleMainMenuBase
{
    public static string? GetAppReleaseVersion()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var appVersion = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
        return appVersion;
    }
}