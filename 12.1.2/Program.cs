namespace Assignment12_1_2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Assignment 12.1.2 - Palindrome Linked List");

        if (args.Length == 1)
        {
            CheckInput(args[0]);
            return;
        }

        ShowResult(new[] { 1, 2, 2, 1 });
        ShowResult(new[] { 1, 2 });

        Console.Write("\nEnter comma-separated integers (example: 1,2,2,1): ");
        string? input = Console.ReadLine();
        if (input is not null) CheckInput(input);
    }

    public static bool IsPalindrome(ListNode? head)
    {
        List<int> values = new();

        // Walk the actual linked nodes and collect their values.
        for (ListNode? current = head; current is not null; current = current.Next)
            values.Add(current.Value);

        int left = 0;
        int right = values.Count - 1;

        while (left < right)
        {
            if (values[left] != values[right]) return false;
            left++;
            right--;
        }

        return true;
    }

    public static ListNode? CreateList(int[] values)
    {
        ListNode? head = null;
        ListNode? tail = null;

        foreach (int value in values)
        {
            ListNode node = new(value);
            if (head is null) head = node;
            else tail!.Next = node;
            tail = node;
        }

        return head;
    }

    static void CheckInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            ShowResult(Array.Empty<int>());
            return;
        }

        string[] parts = input.Split(',');
        int[] values = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out values[i]))
            {
                Console.WriteLine("Invalid input. Enter integers separated by commas.");
                Environment.ExitCode = 1;
                return;
            }
        }

        ShowResult(values);
    }

    static void ShowResult(int[] values)
    {
        ListNode? head = CreateList(values);
        Console.WriteLine($"head = [{string.Join(",", values)}] -> {IsPalindrome(head).ToString().ToLower()}");
    }
}

public class ListNode
{
    public int Value { get; }
    public ListNode? Next { get; set; }

    public ListNode(int value)
    {
        Value = value;
    }
}
