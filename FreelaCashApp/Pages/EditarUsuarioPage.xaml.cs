using FreelaCashApp.Data;
using FreelaCashApp.Model;

namespace FreelaCashApp.Pages;

public partial class EditarUsuarioPage : ContentPage
{
	User _user;
    private readonly IApiMethodsService _apiMethodsService;
    public EditarUsuarioPage()
	{
		InitializeComponent();
        _user = new User();
        _apiMethodsService = DependencyService.Resolve<IApiMethodsService>();

        this.BindingContext = _user;

    }

    private async void btnCadastrar_clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(_user.PrimeiroNome) && string.IsNullOrWhiteSpace(_user.Password))
        {
            await DisplayAlert("Atencao", "Preencha todas as informacoes", "Fechar");
            return;
        }

        User usuario = new User();
        usuario.UserName = _user.UserName;
        usuario.Email = _user.Email;
        usuario.Password = _user.Password;
        usuario.PrimeiroNome = _user.PrimeiroNome;
        usuario.UltimoNome = _user.UltimoNome;

        var cadastro = await _apiMethodsService.CreateAccountAsync(usuario);

        if(cadastro == "Usuario Criado com Sucesso!")
        {
            await DisplayAlert("Secesso!", "Usuario criado com sucesso!", "Fechar");
            await Navigation.PopAsync();
        }
        else
            await DisplayAlert("Atencao", "Error ao tentar cadastrar usuario", "Fechar");
    }

    private async void btnVoltar_clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}