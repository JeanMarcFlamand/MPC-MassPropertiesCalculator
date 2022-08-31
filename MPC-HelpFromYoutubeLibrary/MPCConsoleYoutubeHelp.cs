namespace MPCHelpFromYoutubeLibrary;

public class MPCConsoleYoutubeHelp
{
    public static void GetyouTubeHelp(string youtubeURL)
    {
        try
        {
            System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo
            {
                FileName = youtubeURL,
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(ps);
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
    }
}
