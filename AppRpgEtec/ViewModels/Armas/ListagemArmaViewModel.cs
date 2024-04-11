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

            //TODO: Você deverá criar o método ObterArmas, observando como foi realizado na viewModel de Personagens
            //ObterArmas();

            _ = ObterArmas();
        }
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









    }
}
