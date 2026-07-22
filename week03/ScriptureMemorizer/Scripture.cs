using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        var visible = _words.Where(w => !w.IsHidden()).ToList();
        if (visible.Count == 0) return;
        var rand = new Random();
        int hideCount = Math.Min(count, visible.Count);
        for (int i = 0; i < hideCount; i++)
        {
            int idx = rand.Next(visible.Count);
            visible[idx].Hide();
            visible.RemoveAt(idx);
        }
    }

    public bool IsAllHidden() => _words.All(w => w.IsHidden());

    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{reference} - {words}";
    }

    public string GetHintDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string words = string.Join(" ", _words.Select(w => w.GetHintText()));
        return $"{reference} - {words}";
    }
}