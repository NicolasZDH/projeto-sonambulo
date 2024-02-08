using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dominio.Entidade;
using Infraestutura.Dados;
using Java.Util.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using WebApi.ModelosDeVisão;

namespace Sonambulo.ViewModel;

public partial class MainViewModel: ObservableObject
{
    private readonly ContextoDadosSonambulo _dadosSonambulo;
    private readonly ILogger<MainViewModel> _logger;

    [ObservableProperty]
    ObservableCollection<string> items;
    [ObservableProperty]
    string text;

    public MainViewModel(ContextoDadosSonambulo dadosSonambulo, ILogger<MainViewModel> logger) 
    {
        Items = new ObservableCollection<string>();
        _dadosSonambulo = dadosSonambulo;
        _logger = logger;
    }

    [RelayCommand]
    public async Task AddUser()
    {
        Pessoa usuario = new Pessoa()
        {
            Nome = "Nícolas Zanoni",
            Email = "nicolas.zanonidh@gmail.com",
            Senha = "1234",
            Sonhos = new List<Sonho>() { }
        };

        try
        {
            await _dadosSonambulo.Pessoas.AddAsync(usuario);
            await _dadosSonambulo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"[NovoUsuario - NSAJFD28] - Falha ao usuario: {ex.Message}");
            await Shell.Current.DisplayAlert("Erro [NovoUsuario - NSAJFD28] ", $"Falha ao criar usuario: {ex.Message}", "OK");
        }
    }


    [RelayCommand]
    public async Task Add()
    {
        if (string.IsNullOrEmpty(Text))
            return;

        Sonho sonho = new Sonho(
            new CriarSonhoModelodeVisão() { Descricao = Text, Tarefas = new List<CriarTarefaModelodeVisão>() { } }
        );

        try
        {
            await _dadosSonambulo.Sonhos.AddAsync(sonho);
            await _dadosSonambulo.SaveChangesAsync();
            Items.Add(Text);
            Text = string.Empty;
        }
        catch (Exception ex)
        {
            _logger.LogError($"[NovoSonho - MVI384] - Falha ao criar sonho: {ex.Message}");
            await Shell.Current.DisplayAlert("Erro [NovoSonho - MVI384]", $"Falha ao criar sonho: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    public void Delete(string item) 
    {
        if(Items.Contains(item))
            Items.Remove(item);
    }

    [RelayCommand]
    public async Task Tap(string item) 
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={item}");
    }
}
