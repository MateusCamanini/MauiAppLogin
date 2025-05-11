namespace MauiAppLogin;

public partial class protegida : ContentPage
{
	public protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;
		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"bem_vindo (a) {usuario_logado}";

		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlert("Tem certeza?", "Sair do App?", "sim", "não");

		if (confirmacao) {
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new login();
				
		}
    }
}