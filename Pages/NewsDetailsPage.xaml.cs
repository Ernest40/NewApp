using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailsPage : ContentPage
{
    private Article ThisArticle;

    public NewsDetailsPage(Article article)
    {
        InitializeComponent();

        ThisArticle = article;

        ImgNews.Source = ThisArticle.Image;
        LblTitle.Text = ThisArticle.Title;

      
        LblContent.Text = string.IsNullOrWhiteSpace(ThisArticle.Content)
            ? ThisArticle.Description
            : ThisArticle.Content;
    }
}