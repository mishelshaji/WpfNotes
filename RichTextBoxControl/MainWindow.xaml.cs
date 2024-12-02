using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RichTextBoxControl;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddContentButton_Click(object sender, RoutedEventArgs e)
    {
        // var document = new FlowDocument();
        // var paragraph = new Paragraph();
        // paragraph.Inlines.Add(new Run("Hello World!"));
        // document.Blocks.Add(paragraph);
        // MyRichTextBox.Document = document;
        
        // Adding text to the RichTextBox with formatting.
        // Create a new paragraph
        Paragraph paragraph = new Paragraph();

        // Add normal text
        paragraph.Inlines.Add(new Run("This is normal text. "));

        // Add bold text
        Run boldRun = new Run("This is bold text. ");
        boldRun.FontWeight = FontWeights.Bold; // Set the font weight to bold
        paragraph.Inlines.Add(boldRun);

        // Add italic text
        Run italicRun = new Run("This is italic text. ");
        italicRun.FontStyle = FontStyles.Italic; // Set the font style to italic
        paragraph.Inlines.Add(italicRun);

        // Add bold and italic text
        Run boldItalicRun = new Run("This is bold and italic text.");
        boldItalicRun.FontWeight = FontWeights.Bold; // Set the font weight to bold
        boldItalicRun.FontStyle = FontStyles.Italic; // Set the font style to italic
        paragraph.Inlines.Add(boldItalicRun);

        // Add the paragraph to the RichTextBox
        MyRichTextBox.Document.Blocks.Add(paragraph);
    }

    private void ReadContentButton_Click(object sender, RoutedEventArgs e)
    {
        TextRange textRange = new TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.Document.ContentEnd);
        string content = textRange.Text;

        // Show the content in a message box
        MessageBox.Show(content, "RichTextBox Content");
    }
}
