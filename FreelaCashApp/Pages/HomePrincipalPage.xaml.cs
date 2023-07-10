namespace FreelaCashApp.Pages;

public partial class HomePrincipalPage : TabbedPage
{
	public HomePrincipalPage()
	{
		InitializeComponent();

        var pagina1 = new ListarFeedPage()
		{
			Title = "Feed",
			IconImageSource = ""
		};

        var pagina2 = new ExibirServicoPage()
        {
            Title = "Servicos",
            IconImageSource = ""
        };

        var pagina3 = new PerfilUsuarioPage()
        {
            Title = "Perfil",
            IconImageSource = ""
        };

        this.Children.Add(pagina1);
        this.Children.Add(pagina2);
        this.Children.Add(pagina3);
    }
}