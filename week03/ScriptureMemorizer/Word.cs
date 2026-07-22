public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;
    public bool IsHidden() => _isHidden;
    public string GetDisplayText() => _isHidden ? new string('_', _text.Length) : _text;

    public string GetHintText()
    {
        if (!_isHidden)
            return _text;
        else
        {
            if (string.IsNullOrEmpty(_text))
                return "";

            return _text[0] + new string('_', _text.Length - 1);
        }
    }
}