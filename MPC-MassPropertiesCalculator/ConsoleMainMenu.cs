



using Microsoft.Toolkit;
using MPC_MassPropertiesCalculator.Models;

namespace MPC_MassPropertiesCalculator;

internal class ConsoleMainMenu
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
        Console.WriteLine("Enter File Path");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - Ref Docs\masspropsample.csv");
        userfilepath = Console.ReadLine();
               
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
        DislplayHeanderWanted(headerRow);

        //Read the Data - No header
        var records = csv.GetRecords<Models.MassPropSample>().ToList();
                
        //Print the data
        ConsolePrintaTable.PrintRowSeperator();
        DisplayCSV(records);

    }
    static void DisplayCSV(List<MassPropSample> massPropSamples)
    {
        foreach (MassPropSample? massPropSample in massPropSamples)
        {
            //Properties names of Class MassPropSample.cs
            //item,PartNumber,Rev,NIC,Instance,Description,Type,
            //Qty,UnitWeight,Xarm,Yarm,Zarm,PackageCode,ANDetail,DesingOwnerCode,MomentWithXarm,MomentWithYarm,MomentWithZarm,WeightWithoutXarm,WeightWithoutYarm,WeightWithoutZarm
            // Trim Description to lenght of 10
            string? descriptionTrimmed = massPropSample.Description.Truncate(11);

            Console.WriteLine(string.Format($"| {massPropSample.Item,-10} |" +
                $" {massPropSample.PartNumber,-10} |" +
                $" {descriptionTrimmed,-11} |" +
                $" {massPropSample.Qty,5:0} |" +
                $" {massPropSample.UnitWeight,10:0} |" +
                $" {massPropSample.Xarm,10:0.0} |" +
                $" {massPropSample.Yarm,10:0.0} |" +
                $" {massPropSample.Zarm,10:0.0} |"));

            ConsolePrintaTable.PrintRowSeperator();
        }
        
    }
    static void DislplayHeanderWanted(string[] header)
    {
        Console.WriteLine(string.Format($"| {header[0],-10} |" +
                $" {header[1],-10} |" +
                $" {header[5],-11} |" +
                $" {header[7],-5} |" +
                $" {header[8],-5} |" +
                $" {header[9],-10} |" +
                $" {header[10],-10} |" +
                $" {header[11],-10} |"));

    }

}

