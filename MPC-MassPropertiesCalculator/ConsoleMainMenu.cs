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
        ConsolePrintaTable.DisplayHeanderWanted(headerRow);

        //Read the Data - No header
        var records = csv.GetRecords<Models.MassPropSample>().ToList();
                
        //Print the data
        ConsolePrintaTable.PrintRowSeperator();
        ConsolePrintaTable.DisplayCSV(records);
    }
    

}

