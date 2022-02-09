using MPC_MassPropertiesCalculator.Models;

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
        Console.WriteLine("Enter File Path");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 01 - TWeightNot=0 and All CofG are defined (Basic Calcs).csv");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 02 - TWeightNot=0 and Not All CofG are defined (Advanced Calcs).csv");
        Console.WriteLine(@"Example D:\MPBC-MassPropertiesCalculator - TestData\BOM MasspropCalc senario 03 - TWeight=0  and All CofG are defined=0.csv");
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
        Console.WriteLine($"Weight with Xarm :  {massPropTotal.WeightWithXarm:F3}");
        Console.WriteLine($"Weight with Yarm :  {massPropTotal.WeighttWithYarm:F3}");
        Console.WriteLine($"Weight with Zarm :  {massPropTotal.WeightWithZarm:F3}");
        Console.WriteLine($"Moment with Xarm :  {massPropTotal.MomentWithXarm:F3}");
        Console.WriteLine($"Moment with Yarm :  {massPropTotal.MomentWithYarm:F3}");
        Console.WriteLine($"Moment with Zarm :  {massPropTotal.MomentWithZarm:F3}");
        Console.WriteLine($"Weight without Xarm :  {massPropTotal.TotalWeight - massPropTotal.WeightWithXarm:F3}");
        Console.WriteLine($"Weight without Yarm :  {massPropTotal.TotalWeight - massPropTotal.WeighttWithYarm:F3}");
        Console.WriteLine($"Weight without Zarm :  {massPropTotal.TotalWeight - massPropTotal.WeightWithZarm:F3}");


    }
    

}

