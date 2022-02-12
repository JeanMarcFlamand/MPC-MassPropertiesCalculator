using MPC_MassPropertiesCalculator.Models;
using NativeFileDialogSharp;

namespace MPC_MassPropertiesCalculator;

public class ConsoleMainMenu
{
    static public void MainMenu()
    {
        string? optionnumber;
        Console.Clear();
        Console.WriteLine("MPC- Mass Properties Calculator Menu" + "\r\n");
        Console.WriteLine("1: Load File");
        Console.WriteLine("2: Exit");
        Console.WriteLine("Type the option number to navigate");
        optionnumber = Console.ReadLine();

        DoAction(optionnumber);

        MainMenu();
    }
    static void LoadFile()
    {
        string? userfilepath;
        Console.Clear();
        Console.WriteLine("Download test files from : https://github.com/JeanMarcFlamand/MPC-MassPropertiesCalculator/tree/main/ScenariosDataforTesting");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 01 - TWeightNot=0 and All CofG are defined (Basic Calcs).csv");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 02 - TWeightNot=0 and Not All CofG are defined (Advanced Calcs).csv");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 03 - TWeight=0  and All CofG are defined.csv");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 04 - TWeight=0  and Not All CofG are defined.csv");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 05 - All CofG are not defined.csv");

        userfilepath = Console.ReadLine();
        while(!File.Exists(userfilepath))
        {
            Console.WriteLine("Please enter a valid file path:");
            userfilepath = Console.ReadLine();
        }    
               
        if (userfilepath == "")
        {
            Console.WriteLine("File Path not supplied");
        }
        else
        {
            ReadCSV(userfilepath);
            //Todo Display data in console
            FormatComment();
            Console.WriteLine($"// Todo - Make the calculations taking into account the missing information." + "\r\n");
            Console.ResetColor(); // To return colors back
        }       
        

        Console.WriteLine("Press any key to main menu return." + "\r\n");
        Console.ReadLine();
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
                LoadFile();
                break;
            case "2":
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
    static void ReadCSV (string? path)
    {

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        //Get the headers
        csv.Read();
        csv.ReadHeader();
        string[] headerRow = csv.HeaderRecord;

        //Print the header
        
        ConsolePrintaTable.PrintRowSeperator();
        ConsolePrintaTable.DisplayHeanderWanted(headerRow);

        //Read the Data - No header
        var records = csv.GetRecords<Models.MassPropItem>().ToList();
                
        //Print the data
        ConsolePrintaTable.PrintRowSeperator();
        ConsolePrintaTable.DisplayCSV(records);

        Console.WriteLine("");
        MassPropTotal massPropTotal = new MassPropTotal();
        massPropTotal.GetMassPropTotal(records);

        Console.WriteLine($"Total Weight : {massPropTotal.TotalWeight}");
        Console.WriteLine($"Xarm :  {massPropTotal.Xarm:F3}");
        Console.WriteLine($"Yarm :  {massPropTotal.Yarm:F3}");
        Console.WriteLine($"Zarm :  {massPropTotal.Zarm:F3}");
        Console.WriteLine("Sub Calculation Results used:");
        Console.WriteLine($"Total Moment in Xarm :  {massPropTotal.XTotalMoment:F3}");
        Console.WriteLine($"Total Moment in Yarm :  {massPropTotal.YTotalMoment:F3}");
        Console.WriteLine($"Total Moment in Zarm :  {massPropTotal.ZTotalMoment:F3}");

        Console.WriteLine($"Total Weight with Xarm :  {massPropTotal.WeightWithXarm:F3}");
        Console.WriteLine($"Total Weight with Yarm :  {massPropTotal.WeighttWithYarm:F3}");
        Console.WriteLine($"Total Weight with Zarm :  {massPropTotal.WeightWithZarm:F3}");

        Console.WriteLine($"Total Moment with Xarm :  {massPropTotal.MomentWithXarm:F3}");
        Console.WriteLine($"Total Moment with Yarm :  {massPropTotal.MomentWithYarm:F3}");
        Console.WriteLine($"Total Moment with Zarm :  {massPropTotal.MomentWithZarm:F3}");

        Console.WriteLine($"X arm for Weight with Xarm :  {massPropTotal.XArmTotalMomentWithXarm:F3}");
        Console.WriteLine($"Y arm for Weight with Yarm :  {massPropTotal.YArmTotalMomentWithYarm:F3}");
        Console.WriteLine($"Z arm for Weight with Zarm :  {massPropTotal.ZArmTotalMomentWithZarm:F3}");


    }
    

}

