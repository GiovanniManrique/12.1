namespace Assignment12_1_1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Assignment 12.1.1 - Ransom Note");

        if (args.Length == 2)
        {
            Console.WriteLine(CanConstruct(args[0], args[1]).ToString().ToLower());
            return;
        }

        ShowResult("a", "b");
        ShowResult("aa", "ab");
        ShowResult("aa", "aab");

        Console.Write("\nEnter the ransom note: ");
        string? ransomNote = Console.ReadLine();
        if (ransomNote is null) return;

        Console.Write("Enter the magazine: ");
        string? magazine = Console.ReadLine();
        if (magazine is null) return;

        ShowResult(ransomNote, magazine);
    }

    public static bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> letterCounts = new();

        // Count how many times each letter can be used.
        foreach (char letter in magazine)
        {
            letterCounts.TryGetValue(letter, out int count);
            letterCounts[letter] = count + 1;
        }

        foreach (char letter in ransomNote)
        {
            if (!letterCounts.TryGetValue(letter, out int count) || count == 0)
                return false;

            // Each occurrence in the note uses one occurrence in the magazine.
            letterCounts[letter] = count - 1;
        }

        return true;
    }

    static void ShowResult(string ransomNote, string magazine)
    {
        Console.WriteLine($"ransomNote = \"{ransomNote}\", magazine = \"{magazine}\" -> {CanConstruct(ransomNote, magazine).ToString().ToLower()}");
    }
}
