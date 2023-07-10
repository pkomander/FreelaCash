using FreelaCashApp.Data;
using FreelaCashApp.Model;
using System.Collections.ObjectModel;

namespace FreelaCashApp.Pages;

public partial class ExibirServicoPage : ContentPage
{
    private readonly IApiMethodsService _apiMethodsService;
    private bool _isFirstTimeAppearing = true;
    public ObservableCollection<Servico> ListaServicos { get; set; }

    public ExibirServicoPage()
	{
		InitializeComponent();
        ListaServicos = new ObservableCollection<Servico>();
        BindingContext = this;

        _apiMethodsService = DependencyService.Resolve<IApiMethodsService>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Fazer a requisição ao entrar na página
        if (_isFirstTimeAppearing)
        {
            GetServicos();

            // Atualizar a variável de controle
            _isFirstTimeAppearing = false;
        }
    }

    private async void GetServicos()
    {
        // Lógica da sua requisição
        string token = await SecureStorage.GetAsync("AuthToken");

        if (token != null)
        {
            var servicos = await _apiMethodsService.GetAllServicosAsync(token);

            foreach (var item in servicos)
                ListaServicos.Add(item);
        }
    }

    private void btnNovoServico_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditarServicoPage());
    }
}