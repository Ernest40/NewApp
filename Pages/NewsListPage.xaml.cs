using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    public List<Article> ArticleList;

    public NewsListPage(string categoryName)
    {
        InitializeComponent();

        Title = categoryName;             
        ArticleList = new List<Article>();  

        GetNews(categoryName.ToLower());
    }

    private async Task GetNews(string categoryName)
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(categoryName);

        ArticleList.Clear();
        foreach (var item in newsResult.Articles)
            ArticleList.Add(item);

        CvNews.ItemsSource = ArticleList;
    }

    private async void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;

        if (selectedItem == null) return; 

        await Navigation.PushAsync(new NewsDetailsPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}