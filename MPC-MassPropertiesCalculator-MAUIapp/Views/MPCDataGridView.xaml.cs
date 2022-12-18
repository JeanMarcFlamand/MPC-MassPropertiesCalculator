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

    //This method returns a read-only Stream representing the file contents. 
    public async Task<string> ReadTextFile(string filePath)
    {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
        using StreamReader reader = new StreamReader(fileStream);

        return await reader.ReadToEndAsync();
    }
}