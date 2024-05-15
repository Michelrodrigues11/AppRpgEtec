using AppRpgEtec.Views.Personagens;
using AppRpgEtec.Views.Armas;

namespace AppRpgEtec
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadPersonagemView", typeof(CadastroPersonagemView));
            Routing.RegisterRoute("cadArmaView", typeof(CadastroArmaView));

            string login = Preferences.Get("UsuarioUsername", string.Empty);
            lblLogin.Text = $"Login: {login}";
        }
    }
}
