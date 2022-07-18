using PcKonfigurator.Client.Views;

namespace PcKonfigurator.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}