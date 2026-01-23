using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text into words and create Word objects
        string[] wordTexts = text.Split(' ');
        foreach (string wordText in wordTexts)
        {
            if (!string.IsNullOrEmpty(wordText))
            {
                _words.Add(new Word(wordText));
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetReference());
        Console.WriteLine();

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count = 3)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < count && hiddenCount < _words.Count)
        {
            int randomIndex = random.Next(_words.Count);
            if (!_words[randomIndex].IsHidden())
            {
                _words[randomIndex].Hide();
                hiddenCount++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public int GetTotalWords()
    {
        return _words.Count;
    }

    public int GetHiddenWordsCount()
    {
        return _words.Count(word => word.IsHidden());
    }
}
