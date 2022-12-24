using Microsoft.Maui.Controls.PlatformConfiguration;
using MPCFilePickerMauiLibrary;



namespace MPC_MassPropertiesCalculator_MAUIapp.Views;

public partial class MPCDataGridView : ContentPage
{
	public MPCDataGridView()
	{
		InitializeComponent();
	}

    private async void OpenFile_Clicked(object sender, EventArgs e)
    {
        string? filePath = await PickTxtFile.GetFilePathAsync();

        if (File.Exists(filePath))
        {
            var MPCfile = File.ReadAllText(filePath);
            
        }
        else
        {
            await DisplayAlert("File Path", "Usre did not select a file", "OK");
        }


    }

    private void Demo1_ClickedAsyn(object sender, EventArgs e)
    {

        var filename = "BOM MasspropCalc " + Demo1.Text;
        OpenDemoFile(filename);
    }

    private void Demo2_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo2.Text;
        OpenDemoFile(filename);
    }

    private void Demo3_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo3.Text;
        OpenDemoFile(filename);
    }

    private void Demo4_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo4.Text;
        OpenDemoFile(filename);
    }

    private void Demo5_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo5.Text;
        OpenDemoFile(filename);
    }

    private void Demo6_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo6.Text;
        OpenDemoFile(filename);
    }

    public async void OpenDemoFile(string fileName)
    {
        char s = Path.DirectorySeparatorChar;
        string mpcCFile = await LoadMauiAssetStream($"{Constants.ScenariosDataforTestingDirectory}{s}{fileName}");

        FileOutput.Text = mpcCFile;
        PickFileExpnd.IsExpanded = false;

        await DisplayAlert("ReadAllText", $"Succesfull operation", "OK").ConfigureAwait(false);

    }

    //This method returns a read-only Stream representing the file contents. 
    public async Task<string> ReadTextFile(string filePath)
    {
        using var fileStream = await FileSystem.OpenAppPackageFileAsync(filePath );
        using var reader = new StreamReader(fileStream);

        return await reader.ReadToEndAsync();
    }

    

    async Task<string> LoadMauiAssetStream(string filePath)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        return contents;
    }

   
}