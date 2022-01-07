
class Program
{
    static void Main(string[] args)
    {
        MainMenu();
        
    }
    static void MainMenu()
    {
        String OptionNumber;
        Console.Clear();    
        Console.WriteLine("MPC- Mass Properties Calculator Menu" +
            "enu \r\n");
        Console.WriteLine("1: Load File");
        Console.WriteLine("2: Exit");
        Console.WriteLine("Type the option number to navigate");
        OptionNumber = Console.ReadLine();

        DoAction (OptionNumber);

        MainMenu();
    }
    static void LoadFile()
    {
        string UserFilePath;
        Console.Clear();
        Console.WriteLine("Enter File Path");
        Console.WriteLine(@"Example C:\DataSample1.csv");
        UserFilePath = Console.ReadLine();
        //Todo Load file
        Console.WriteLine($"Todo Load file {UserFilePath}.");
        Console.ReadLine();
    }
    static void Exit()
    {

        string YN;
        Console.WriteLine("Are you sure to quit the app? y/n");
        YN = Console.ReadLine();
        if (YN == "y")
        {
            System.Environment.Exit(0);
            Console.ReadKey();
        }
        else 
        {
            MainMenu();
        }
        
    }
    static void DoAction(string menuaction)
    {
        switch (menuaction) {
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
}

