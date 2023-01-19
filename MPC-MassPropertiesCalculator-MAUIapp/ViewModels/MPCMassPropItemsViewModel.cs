using CommunityToolkit.Maui.Core.Extensions;
using CsvHelper;
using MPCDataManagerLibrary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace MPC_MassPropertiesCalculator_MAUIapp.ViewModels;

public class MPCMassPropItemsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<MassPropItem> massPropItems;

    public ObservableCollection<MassPropItem> massPropItemsCollection
    {
        get { return massPropItems; ; }
        set
        {
            massPropItems = value;
            NotifyPropertyChanged(nameof(massPropItemsCollection));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



    public MPCMassPropItemsViewModel() //Constructor
    {
        massPropItems = new ObservableCollection<MassPropItem>();
    }


    //TODO - use the GetMasspropertyRecords in lieu of   async Task LoadRecords(string filePath) from MPCDataGridView.xaml.cs
    async public void GetMasspropertyRecords(string fileName)
    {
        char s = Path.DirectorySeparatorChar;

        using var stream = await FileSystem.OpenAppPackageFileAsync($"{Constants.ScenariosDataforTestingDirectory}{s}{fileName}");
        using StreamReader reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
        // was  MPCItemsDaGr.ItemsSource = csv.GetRecords<MassPropItem>().ToList();
        // is now but not working
        massPropItemsCollection = csv.GetRecords<MassPropItem>().ToObservableCollection();
    }
}
