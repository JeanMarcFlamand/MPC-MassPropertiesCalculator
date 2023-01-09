using CsvHelper;
using MPCDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPC_MassPropertiesCalculator_MAUIapp.ViewModels;

public class MPCMassPropItemsViewModel
{
    private ObservableCollection<MassPropItem> massPropItems;

    public ObservableCollection<MassPropItem> MassPropItemsCollection
    {
        get { return massPropItems; ; }
        set { massPropItems = value; }
    }


    public MPCMassPropItemsViewModel() //Constructor
    {
        massPropItems = new ObservableCollection<MassPropItem>();
    }


    //TODO - use the GetMasspropertyRecords in lieu of   async Task LoadRecords(string filePath) from MPCDataGridView.xaml.cs
    async public void GetMasspropertyRecords(string filePath)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
        using StreamReader reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        //string[] headerRow = csv.HeaderRecord;
        massPropItems = (ObservableCollection<MassPropItem>)csv.GetRecords<MassPropItem>();
    }
}
