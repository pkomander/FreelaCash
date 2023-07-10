using FreelaCashApp.Data;
using FreelaCashApp.Model;

namespace FreelaCashApp.Pages;

public partial class LoginUsuarioPage : ContentPage
{
    UserLogin _login;
    private readonly IApiMethodsService _apiMethodsService;
    public LoginUsuarioPage()
	{
		InitializeComponent();
        _login = new UserLogin();
        _apiMethodsService = DependencyService.Resolve<IApiMethodsService>();

        this.BindingContext = _login;
    }

    private async void btnEntrar_clicked(object sender, EventArgs e)
    {
        // Exibir o spinner de carregamento
        ActivityIndicator.IsRunning = true;
        ActivityIndicator.IsVisible = true;

        //a recuperacao dos valores podem ser feitos dessas duas formas
        //string userName = txtUserName.Text;
        //string password = txtSenha.Text;
        if (string.IsNullOrWhiteSpace(_login.UserName) && string.IsNullOrWhiteSpace(_login.Password))
        {
            await DisplayAlert("Atencao", "Preencha todas as informacoes", "Fechar");
            return;
        }

        UserLogin userLogin = new UserLogin
        {
            UserName = _login.UserName,
            Password = _login.Password
        };

        var login = await _apiMethodsService.LoginAccountAsync(userLogin);

        if (login != null)
        {
            await SecureStorage.SetAsync("AuthToken", login.token);
            string token = await SecureStorage.GetAsync("AuthToken");
            //await DisplayAlert("Sucesso!", $"Usuario criado com sucesso!{login.userName}-{login.primeiroNome}-{login.token}", "Fechar");
            Navigation.PushAsync(new HomePrincipalPage());
        }
        else
        {
            // Ocultar o spinner de carregamento
            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
            await DisplayAlert("Atencao", "Error ao tentar logar com usuario", "Fechar");
        }
    }

    private void btnRegisrar_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditarUsuarioPage());
    }
}