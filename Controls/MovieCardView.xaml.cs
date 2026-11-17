using MovieCatalogApp.Models;

namespace MovieCatalogApp.Controls;

public partial class MovieCardView : ContentView
{
    public static readonly BindableProperty ModelProperty = BindableProperty.Create(
        nameof(Model),
        typeof(Movie),
        typeof(MovieCardView),
        default(Movie),
        BindingMode.OneWay);

    public Movie? Model
    {
        get => (Movie?)GetValue(ModelProperty);
        set => SetValue(ModelProperty, value);
    }

    public MovieCardView()
    {
        InitializeComponent();
        // Keep the inherited BindingContext so Model="{Binding .}"
        // receives the current Movie from the CollectionView DataTemplate.
    }
}
