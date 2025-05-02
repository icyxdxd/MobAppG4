namespace MobAppG4.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        try
        {
            Preferences.Remove("FirebaseToken");

            Application.Current.MainPage = new NavigationPage(new LoginPage());

            await DisplayAlert("Logged Out", "You have been successfully logged out.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Logout failed: {ex.Message}", "OK");
        }
    }
}
