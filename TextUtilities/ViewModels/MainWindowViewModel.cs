using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextUtilities.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private string _text;

    public string Text
    {
        get => _text;
        set
        {
            if (value == _text)
            {
                return;
            }

            _text = value;
            OnPropertyChanged();
            CalculateValues();
        }
    }

    private int _wordCount;

    public int WordCount
    {
        get => _wordCount;
        set
        {
            if (value == _wordCount)
            {
                return;
            }

            _wordCount = value;
            OnPropertyChanged();
        }
    }

    private int _letterCount;

    public int LetterCount
    {
        get => _letterCount;
        set
        {
            if (value == _letterCount)
            {
                return;
            }

            _letterCount = value;
            OnPropertyChanged();
        }
    }

    private void CalculateValues()
    {
        WordCount = Text.Split(' ').Length;
        LetterCount = Text.Length;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
