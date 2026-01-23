using System;

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPromptText()
    {
        return _promptText;
    }

    public string GetEntryText()
    {
        return _entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        // Use ~|~ as separator since it's unlikely to appear in content
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}
