using MPC_MassPropertiesCalculator_MAUIapp.ViewModels;

namespace MPC_MassPropertiesCalculator_MAUIapp.Views;

public partial class TestView : ContentPage
{
	public TestView(TestViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}