using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MovieCatalogApp.Models;
using MovieCatalogApp.Services;

namespace MovieCatalogApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly MovieService _movieService;
    private readonly NavigationService _navigationService;
    private bool _isLoading;
    private Movie? _selectedMovie;

    public ObservableCollection<Movie> Movies { get; } = new();

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading == value) return;
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public Movie? SelectedMovie
    {
        get => _selectedMovie;
        set
        {
            if (_selectedMovie == value) return;
            _selectedMovie = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoadMoreCommand { get; }
    public ICommand RefreshCommand { get; }
    public ICommand OpenMovieCommand { get; }

    public MainViewModel(MovieService movieService, NavigationService navigationService)
    {
        _movieService = movieService;
        _navigationService = navigationService;
        LoadMoreCommand = new Command(async () => await LoadMoviesAsync(false));
        RefreshCommand = new Command(async () => await LoadMoviesAsync(true));
        OpenMovieCommand = new Command<Movie>(async movie => await OpenMovieAsync(movie));
        _ = LoadMoviesAsync(true);
    }

    private async Task OpenMovieAsync(Movie? movie)
    {
        if (movie is null) return;
        try
        {
            await _navigationService.ShowMovieDetailsAsync(movie);
        }
        finally
        {
            // Очищаємо вибір після повернення, щоб той самий елемент
            // можна було відкрити повторно.
            SelectedMovie = null;
        }
    }

    public async Task LoadMoviesAsync(bool reset = false)
    {
        if (IsLoading) return;
        try
        {
            IsLoading = true;
            var newItems = await _movieService.GetMoviesAsync(reset);
            if (reset) Movies.Clear();
            foreach (var item in newItems) Movies.Add(item);
        }
        finally
        {
            IsLoading = false;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
