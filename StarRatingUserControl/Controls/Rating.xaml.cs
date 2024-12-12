using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StarRatingUserControl.Controls;

public partial class Rating : UserControl
{
    private List<Image> _images;
    public int RatingValue { get; set; }
    public Rating()
    {
        InitializeComponent();
    }

    private void Rating_OnLoaded(object sender, RoutedEventArgs e)
    {
        _images = Container.Children.Cast<Image>().ToList();
        foreach (var image in _images)
        {
            image.MouseEnter += ImageOnMouseEnter;
            image.MouseDown += ImageOnMouseDown;
        }
    }

    private void ImageOnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var selectedImage = (Image)sender;
        RatingValue = int.Parse(selectedImage.Tag.ToString());
        Result.Text = RatingValue.ToString();
    }

    private void ImageOnMouseEnter(object sender, MouseEventArgs e)
    {
        var selectedImage = (Image)sender;
        int imageNumber = int.Parse(selectedImage.Tag.ToString());

        foreach (var item in _images)
        {
            item.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/star-outline.png"));
        }

        for (int i = 0; i < imageNumber; i++)
        {
            var starToFill = _images[i];
            starToFill.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/star-filed.png"));
        }
    }
}
