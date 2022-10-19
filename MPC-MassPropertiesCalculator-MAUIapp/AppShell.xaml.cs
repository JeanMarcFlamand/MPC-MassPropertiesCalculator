using MPC_MassPropertiesCalculator_MAUIapp.Views;

namespace MPC_MassPropertiesCalculator_MAUIapp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TestView),typeof(TestView));
            
        }
    }
}