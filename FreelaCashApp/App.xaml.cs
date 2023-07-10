using FreelaCashApp.Data;
using FreelaCashApp.Pages;

namespace FreelaCashApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        // Registrar a implementação da interface
        DependencyService.Register<IApiMethodsService, ApiMethodsRepository>();

        //MainPage = new AppShell();
        MainPage = new NavigationPage( new LoginUsuarioPage());

        
    }
}
