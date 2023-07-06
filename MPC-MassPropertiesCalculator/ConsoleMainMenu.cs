using MPCDataManagerLibrary.Models;
using MPCHelpFromYoutubeLibrary;

namespace MPC_MassPropertiesCalculator;

public class ConsoleMainMenu
{
    static public void MainMenu()
    {
        string? optionnumber;
        //Console.Clear();

        //string? appVersion = GetAppReleaseVersion();

        //Console.WriteLine($"MPC- Mass Properties Calculator - Version {appVersion}" + "\r\n");
        Console.WriteLine("MPC- Mass Properties Calculator Menu" + "\r\n");
        Console.WriteLine("1: Load File");
        Console.WriteLine("2: Clear the Screen");
        Console.WriteLine("3: Help on YouTube");
        Console.WriteLine("4: Exit");
        Console.WriteLine("Type the option number to navigate");
        optionnumber = Console.ReadLine();

        DoAction(optionnumber);

        MainMenu();
    }

    static void LoadfileFromDialog(DialogResult result)
    {
        string userfilepath;
        if (result.IsOk)
        {
            userfilepath = result.Path;
            ReadCSV(userfilepath);
            //Todo Display data in console
            FormatComment();
            Console.WriteLine($"// Next Todo - Phase 1.5.1 Add .Net MAUI user interface using Syncfusion \".NET MAUI DataViz & UI Controls\"" + "\r\n");
            Console.ResetColor(); // To return colors back
            MainMenu();
        }
    }

       static void Exit()
    {

        string? yn;
        Console.WriteLine("Are you sure to quit the app? y/n");
        yn = Console.ReadLine();
        if (yn == "y")
        {
            System.Environment.Exit(0);
            Console.ReadKey();
        }
        else
        {
            MainMenu();
        }

    }
    static void DoAction(string? menuaction)
    {
        switch (menuaction)
        {
            case "1":
                //LoadFile();
                Console.Clear();
                //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources));
                //AppDomain.CurrentDomain.BaseDirectory
                // LoadfileFromDialog(Dialog.FileOpen("csv", Environment.CurrentDirectory + "\\" + ScenariosDataforTestingDirectory));
                LoadfileFromDialog(Dialog.FileOpen("csv", AppDomain.CurrentDomain.BaseDirectory + ScenariosDataforTestingDirectory));
                break;
            case "2":
                Console.Clear();
                MainMenu();
                break;
            case "3":
                Console.Clear();
                MPCConsoleYoutubeHelp.GetyouTubeHelp(MPCYouTubeHelpURL);
                break;
            case "4":
                Exit();
                break;

            default:
                Console.WriteLine($"Invalid Selection {menuaction} .");
                // Will delay for three seconds
                Thread.Sleep(2000);
                MainMenu();
                break;
        }

    }
    static void FormatComment()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    static void ReadCSV (string path)
    {

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        //Get the headers
        csv.Read();
        csv.ReadHeader();
        string[] headerRow = csv.HeaderRecord;

        //Print the header
        Console.WriteLine($"File: {path}");
        ConsolePrintaTable.PrintRowSeperator();
        ConsolePrintaTable.DisplayHeanderWanted(headerRow);

        //Read the Data - No header
        var records = csv.GetRecords<MassPropItem>().ToList();
                
        //Print the data
        ConsolePrintaTable.PrintRowSeperator();
        ConsolePrintaTable.DisplayCSV(records);

        Console.WriteLine("");
        MassPropTotal massPropTotal = new MassPropTotal();
        massPropTotal.GetMassPropTotal(records);

        Console.WriteLine($"        Weight   |   Xarm    |   Yarm    |   Zarm    |  XMoment  |  YMoment  |  ZMoment  |");
        //Console.WriteLine($"Total Weight : {massPropTotal.TotalWeight} Xarm :  {massPropTotal.Xarm:F3} Yarm :  {massPropTotal.Yarm:F3} Zarm :  {massPropTotal.Zarm:F3}");
        //Console.WriteLine($"C of G Xarm :  {massPropTotal.Xarm:F3} Yarm :  {massPropTotal.Yarm:F3} Zarm :  {massPropTotal.Zarm:F3}");
        //Console.WriteLine($"Xarm :  {massPropTotal.Xarm:F3}");
        //Console.WriteLine($"Yarm :  {massPropTotal.Yarm:F3}");
        //Console.WriteLine($"Zarm :  {massPropTotal.Zarm:F3}");
        Console.WriteLine($"Total {massPropTotal.TotalWeight,10:F3} |" +
            $"{massPropTotal.Xarm,10:F3} |" +
            $"{massPropTotal.Yarm,10:F3} |" +
            $"{massPropTotal.Zarm,10:F3} |" +
            $"{massPropTotal.XTotalMoment,10:F3} |" +
            $"{massPropTotal.YTotalMoment,10:F3} |" +
            $"{massPropTotal.ZTotalMoment,10:F3} |");

        Console.WriteLine($"\n\n Sub Calculation Results used:\n");

        Console.WriteLine($"Total Weight with Yarm :  {massPropTotal.WeightWithYarm,10:F3}");
        Console.WriteLine($"Total Weight with Yarm :  {massPropTotal.WeightWithYarm,10:F3}");
        Console.WriteLine($"Total Weight with Zarm :  {massPropTotal.WeightWithZarm,10:F3} \n");

        Console.WriteLine($"Total Moment with Xarm :  {massPropTotal.MomentWithXarm,10:F3}");
        Console.WriteLine($"Total Moment with Yarm :  {massPropTotal.MomentWithYarm,10:F3}");
        Console.WriteLine($"Total Moment with Zarm :  {massPropTotal.MomentWithZarm,10:F3}\n");

        Console.WriteLine($"X arm for Weight with Xarm :  {massPropTotal.XArmTotalMomentWithXarm,10:F3}");
        Console.WriteLine($"Y arm for Weight with Yarm :  {massPropTotal.YArmTotalMomentWithYarm,10:F3}");
        Console.WriteLine($"Z arm for Weight with Zarm :  {massPropTotal.ZArmTotalMomentWithZarm,10:F3} \n");

        Console.WriteLine($"Total Weight without Yarm :  {massPropTotal.TotalWeight - massPropTotal.WeightWithYarm,10:F3}");
        Console.WriteLine($"Total Weight without Yarm :  {massPropTotal.TotalWeight - massPropTotal.WeightWithYarm,10:F3}");
        Console.WriteLine($"Total Weight without Zarm :  {massPropTotal.TotalWeight - massPropTotal.WeightWithZarm,10:F3} \n");



    }
    public static string? GetAppReleaseVersion()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var appVersion = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
        return appVersion;
    }
}

