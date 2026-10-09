# Assignment 12.1

Visual Studio solution with one C# console project per question:

| Project | Question | Source |
| --- | --- | --- |
| 12.1.1 | Construct a ransom note using each magazine letter at most once | 12.1.1/Program.cs |
| 12.1.2 | Check whether a singly linked list is a palindrome | 12.1.2/Program.cs |

## Open in Visual Studio

1. Open **12.1.sln**.
2. Right-click **12.1.1** or **12.1.2** in Solution Explorer and select **Set as Startup Project**.
3. Press **Ctrl+F5** to run. Each project displays the assignment examples, then accepts your own input.

Requires the .NET 10 SDK and Visual Studio with .NET development support.

## Solutions

Question 1 counts magazine characters in a dictionary, then consumes one count for each ransom note character. Missing or exhausted characters return `false`. Comparisons are case-sensitive, including spaces and punctuation. An empty note returns `true`. Time: O(m + n); extra space: O(k) distinct magazine characters.

Question 2 constructs actual singly linked nodes, copies their values into a list, then compares values from both ends toward the center. The linked list is preserved. Empty and single-node lists return `true`. Time: O(n); extra space: O(n).

## Terminal commands

```powershell
dotnet build 12.1.sln -c Release
dotnet run --project 12.1.1 -- aa aab
dotnet run --project 12.1.2 -- "1,2,2,1"
```

The screenshot contains two questions, so this solution contains two question projects.

## Verification

Release build: zero warnings and errors. All 19 checks passed, including the five assignment examples, empty inputs, single-node and odd-length lists, repeated letters, case sensitivity, invalid numbers, and interactive input for both programs.
