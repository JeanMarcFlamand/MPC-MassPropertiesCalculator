namespace MPC_MassPropertiesCalculator;

internal class ConsoleMainMenu
{
    public static void MainMenu()
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
        Console.WriteLine(@"Example C:\DataSample1.csv");
        userfilepath = Console.ReadLine();
        //Todo Load file
        FormatComment();
        Console.WriteLine($"// Todo Load file {userfilepath}." + "\r\n");
        Console.ResetColor(); // To return colors back

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
}
