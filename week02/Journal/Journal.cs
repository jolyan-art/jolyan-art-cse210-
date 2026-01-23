using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
        Console.WriteLine("Entry saved successfully!");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries found.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileFormat());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving file: {e.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            _entries.Clear();
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Entry entry = Entry.FromFileFormat(line);
                        if (entry != null)
                        {
                            _entries.Add(entry);
                        }
                    }
                }
                Console.WriteLine($"Journal loaded from {filename}");
            }
            else
            {
                Console.WriteLine($"File {filename} not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading file: {e.Message}");
        }
    }
}
