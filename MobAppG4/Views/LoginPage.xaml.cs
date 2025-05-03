using MobAppG4.Services;

namespace MobAppG4.Views;

public partial class LoginPage : ContentPage
{
    private readonly FirebaseAuthService _authService;

    public LoginPage()
    {
        InitializeComponent();
        _authService = new FirebaseAuthService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            var auth = await _authService.SignIn(emailEntry.Text, passwordEntry.Text);
            string token = await _authService.GetFreshToken(auth);

            await Navigation.PushAsync(new HomePage());

        }
        catch (Exception ex)
        {
            await DisplayAlert("Login Failed", ex.Message, "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

}