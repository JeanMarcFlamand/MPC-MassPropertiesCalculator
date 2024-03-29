using CsvHelper;
using MPC_MassPropertiesCalculator_MAUIapp.ViewModels;
using MPCDataManagerLibrary.Models;
using MPCFilePickerMauiLibrary;
using Syncfusion.Maui.DataGrid;
using System.Globalization;

namespace MPC_MassPropertiesCalculator_MAUIapp.Views;

public partial class MPCMassPropItemsView : ContentPage
{
	public MPCMassPropItemsView() //Constructor
	{
		InitializeComponent();
        SfDataGrid MPCItemsDaGr = new();

        MPCMassPropItemsViewModel viewModel = new();
        MPCItemsDaGr.ItemsSource = viewModel.massPropItemsCollection;

    }

    private async void OpenFile_Clicked(object sender, EventArgs e)
    {
        var filePath = await PickTxtFile.GetFilePathAsync();

        if (File.Exists(filePath))
        {
            var MPCfile = File.ReadAllText(filePath);
            
        }
        else
        {
            await DisplayAlert("File Path", "Usre did not select a file", "OK");
        }


    }

    private void Demo1_Clicked(object sender, EventArgs e)
    {

        var filename = "BOM MasspropCalc " + Demo1.Text;
        //Todo -Move Implicit code in to MPCMassPropItemsViewModel
        // Replace OpenDemoFile(filename)  by viewModel.GetMasspropertyRecords(filename);
        //OpenDemoFile(filename);
        viewModel.GetMasspropertyRecords(filename);
        PickFileExpnd.IsExpanded = false;
    }

    private void Demo2_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo2.Text;
        viewModel.GetMasspropertyRecords(filename);
        PickFileExpnd.IsExpanded = false;
    }

    private void Demo3_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo3.Text;
        viewModel.GetMasspropertyRecords(filename);
        PickFileExpnd.IsExpanded = false;
    }

    private void Demo4_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo4.Text;
        viewModel.GetMasspropertyRecords(filename);
        PickFileExpnd.IsExpanded = false;
    }

    private void Demo5_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo5.Text;
        viewModel.GetMasspropertyRecords(filename);
        PickFileExpnd.IsExpanded = false;
    }

    private void Demo6_Clicked(object sender, EventArgs e)
    {
        var filename = "BOM MasspropCalc " + Demo6.Text;
        viewModel.GetMasspropertyRecords(filename);
        PickFileExpnd.IsExpanded = false;
    }

    public async void OpenDemoFile(string fileName)
    {
        char s = Path.DirectorySeparatorChar;
        string mpcCFile = await LoadMauiAssetStream($"{Constants.ScenariosDataforTestingDirectory}{s}{fileName}");

       await LoadRecords($"{Constants.ScenariosDataforTestingDirectory}{s}{fileName}");

        PickFileExpnd.IsExpanded = false;      

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

    async Task LoadRecords(string filePath)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
        using StreamReader reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        MPCItemsDaGr.ItemsSource = csv.GetRecords<MassPropItem>().ToList();
        return;
    }
}