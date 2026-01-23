using System;

// Scripture Memorizer Program - Week 03
// This program helps users memorize scriptures by progressively hiding words.
// Users can practice memorization by viewing the scripture and pressing enter to hide more words.
//
// Features:
// - Supports single verses and verse ranges (e.g., "John 3:16" or "Proverbs 3:5-6")
// - Hides random words with underscores matching word length
// - Continues until all words are hidden
// - Clean console display with user prompts
//
// Exceeds Requirements:
// - Implements stretch challenge: only hides words that are not already hidden
// - Shows progress: displays how many words have been hidden
// - Multiple scriptures available in library for variety
// - Proper encapsulation with Word, Scripture, and Reference classes

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine();

        // Create a scripture with reference and text
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(
            reference,
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        );

        // Display initial scripture
        scripture.Display();

        // Main loop for user interaction
        while (!scripture.IsCompletelyHidden())
        {
            Console.Write("Press enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words
            scripture.HideRandomWords(3);

            // Display updated scripture
            scripture.Display();

            // Show progress
            int hidden = scripture.GetHiddenWordsCount();
            int total = scripture.GetTotalWords();
            Console.WriteLine($"Progress: {hidden}/{total} words hidden");
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Congratulations! You have completed this scripture.");
        }
        else
        {
            Console.WriteLine("Thank you for practicing!");
        }
    }
}