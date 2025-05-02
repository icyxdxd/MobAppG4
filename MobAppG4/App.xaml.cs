using MobAppG4.Views;

namespace MobAppG4;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new LoginPage());
    }
}
