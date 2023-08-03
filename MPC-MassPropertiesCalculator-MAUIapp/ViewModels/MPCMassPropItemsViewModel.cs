using CommunityToolkit.Maui.Core.Extensions;
using CsvHelper;
using MPCDataManagerLibrary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Channels;

namespace MPC_MassPropertiesCalculator_MAUIapp.ViewModels;

public class MPCMassPropItemsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<MassPropItem> massPropItems;
    //private ObservableCollection<MassPropTotal> massPropTotal;
    MassPropTotal massPropTotal = new();

    //To reload the ItemsSource of the DataGrid i.e., massPropItemsCollection at the run time,
    //the ViewModel class has to be inherited from INotifyPropertyChanged interface.
    //This allows the DataGrid to be automatically updated when the data in the massPropItemsCollection changes.
    //In this case, the ItemsSource of the DataGrid is bound to the massPropItemsCollection property,
    //which means that when the collection is updated, the DataGrid will be updated with the new data as well.
    public ObservableCollection<MassPropItem> MassPropItemsCollection
    {
        get { return massPropItems; ; }
        set
        {
            massPropItems = value;
            NotifyPropertyChanged(nameof(MassPropItemsCollection));
        }
    }
    public double TotalWeight { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



    public MPCMassPropItemsViewModel() //Constructor
    {
        massPropItems = new ObservableCollection<MassPropItem>();
    }


    async public void GetMasspropertyRecords(string fileName)
    {
        char s = Path.DirectorySeparatorChar;

        using var stream = await FileSystem.OpenAppPackageFileAsync($"{Constants.ScenariosDataforTestingDirectory}{s}{fileName}");
        using StreamReader reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
        MassPropItemsCollection = csv.GetRecords<MassPropItem>().ToObservableCollection();
        massPropTotal.GetMassPropTotal(MassPropItemsCollection.ToList());
        TotalWeight = (double)massPropTotal.TotalWeight;



    }
}
