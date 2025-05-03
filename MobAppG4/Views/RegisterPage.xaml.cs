using MobAppG4.Services;

namespace MobAppG4.Views
{
    public partial class RegisterPage : ContentPage
    {
        private readonly FirebaseAuthService _authService;

        public RegisterPage()
        {
            InitializeComponent();
            _authService = new FirebaseAuthService();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text != confirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            try
            {
                var auth = await _authService.SignUp(emailEntry.Text, passwordEntry.Text);
                string token = await _authService.GetFreshToken(auth);

                await DisplayAlert("Success", $"Account created for {auth.User.Email}", "OK");

                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Registration Failed", ex.Message, "OK");
            }
        }
    }
}