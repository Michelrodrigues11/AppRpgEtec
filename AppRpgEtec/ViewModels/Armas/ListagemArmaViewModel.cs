using AppRpgEtec.Models;
using AppRpgEtec.Services.Armas;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Armas
{
    public class ListagemArmaViewModel : BaseViewModel
    {
        private ArmaService aService;
        public ObservableCollection<Arma> Armas { get; set; }

        public ListagemArmaViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            aService = new ArmaService(token);

            Armas = new ObservableCollection<Arma>();
            
            NovaArmaCommand = new Command(async () => { await ExibirCadastroArma(); });

            _ = ObterArmas();
        }

        public ICommand NovaArmaCommand { get; set; }

        public async Task ObterArmas()
        {
            try
            {
                Armas = await aService.GetArmasAsync();
                OnPropertyChanged(nameof(Armas));
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Detalhes" + ex.InnerException, "Ok");
                throw;
            }
        }


        public async Task ExibirCadastroArma()
        {
            try
            {
                await Shell.Current.GoToAsync("cadArmaView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException.Message, "Ok");
            }
        }







    }
}
