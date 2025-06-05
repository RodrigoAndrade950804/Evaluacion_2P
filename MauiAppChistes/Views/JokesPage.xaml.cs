using MauiAppChistes.Repositories;
namespace MauiAppChistes.Views;

public partial class JokesPage : ContentPage
{

    private readonly JokeRepository _jokeRepository = new();

    public JokesPage()
    {
        InitializeComponent();
        CargarChiste();
    }

    private async void CargarChiste()
    {
        JokeLabel.Text = "Cargando chiste...";
        try
        {
            var joke = await _jokeRepository.GetRandomJokeAsync();
            JokeLabel.Text = $"{joke.Setup}\n\n{joke.Punchline}";
        }
        catch
        {
            JokeLabel.Text = "No se pudo cargar el chiste.";
        }
    }

    private void GenerarChiste_Clicked(object sender, EventArgs e)
    {
        CargarChiste();
    }
}