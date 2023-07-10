using FreelaCashApp.Data;
using FreelaCashApp.Model;

namespace FreelaCashApp.Pages;

public partial class PerfilUsuarioPage : ContentPage
{
    User _user;
    private readonly IApiMethodsService _apiMethodsService;
    private bool _isFirstTimeAppearing = true;

    public PerfilUsuarioPage()
	{
		InitializeComponent();
        BindingContext = this;
        this.BindingContext = _user;
        _apiMethodsService = DependencyService.Resolve<IApiMethodsService>();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Fazer a requisição ao entrar na página
        if (_isFirstTimeAppearing)
        {
            GetUser();

            // Atualizar a variável de controle
            _isFirstTimeAppearing = false;
        }
    }

    private async void GetUser()
    {
        // Lógica da sua requisição
        string token = await SecureStorage.GetAsync("AuthToken");

        if (token != null)
        {
            var informacoesUser = await _apiMethodsService.GetUsertAsync(token);
            txtUserName.Text = informacoesUser.UserName;
            txtTitulo.Text = informacoesUser.Titulo;
            txtPrimeiroNome.Text = informacoesUser.PrimeiroNome;
            txtUltimoNome.Text = informacoesUser.UltimoNome;
            txtEmail.Text = informacoesUser.Email;
            txtPhone.Text = informacoesUser.PhoneNumber;
            txtFuncao.Text = informacoesUser.Funcao;
            txtDescricao.Text = informacoesUser.Descricao;
            txtSenha.Text = informacoesUser.Password;
        }

    }

    private async void btnAtualizar_clicked(object sender, EventArgs e)
    {
        try
        {
            string token = await SecureStorage.GetAsync("AuthToken");

            UserUpdate userUpdate = new UserUpdate
            {
                UserName = txtUserName.Text,
                Titulo = txtTitulo.Text,
                PrimeiroNome = txtPrimeiroNome.Text,
                UltimoNome = txtUltimoNome.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                Funcao = txtFuncao.Text,
                Descricao = txtDescricao.Text,
                Password = txtSenha.Text
            };

            if (userUpdate.Password != null)
            {
                var atulizaUser = await _apiMethodsService.UpdateUsertAsync(token, userUpdate, imgPerfil);

                if (atulizaUser != null)
                {
                    await DisplayAlert("Sucesso", "Usuario atualizado com sucesso!", "Fechar");
                }
                else
                    await DisplayAlert("Erro", "Erro ao tentar atualizar usuario", "Fechar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao tentar atualizar usuario: {ex.Message}", "Fechar");
        }

    }

    private async void btnSelecionarImagem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Abrir o FilePicker para selecionar uma imagem
            var fileResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Selecione uma imagem"
            });

            if (fileResult != null)
            {
                // Carregar a imagem selecionada na ImageView
                var stream = await fileResult.OpenReadAsync();
                imgPerfil.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            // Tratar possíveis erros ao selecionar a imagem
            Console.WriteLine($"Erro ao selecionar a imagem: {ex.Message}");
        }
    }
}