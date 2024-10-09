using System.Text.RegularExpressions;
// Practice Arrays


// 1. Copying an Array
int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int[] copiedArray = new int[originalArray.Length];

for (int i = 0; i < originalArray.Length; i++)
{
    copiedArray[i] = originalArray[i];
}

Console.WriteLine($"Original Array:");
for (int i = 0; i < originalArray.Length; i++)
{
    Console.Write(originalArray[i] + " ");
}
Console.WriteLine();

Console.WriteLine("Copied Array:");
for (int i = 0; i < copiedArray.Length; i++)
{
    Console.Write(copiedArray[i] + " ");
}
Console.WriteLine();


// 2. list manager
List<string> itemList = new List<string>();

while (true)
{
    Console.WriteLine("Enter command (+ item, - item, or -- to clear):");

    string input = Console.ReadLine();

    if (input.StartsWith("+"))      // Add item +
    {
        string itemToAdd = input.Substring(1).Trim();
        if (!string.IsNullOrEmpty(itemToAdd))
        {
            itemList.Add(itemToAdd);
            Console.WriteLine($"Added: {itemToAdd}");
        }
    }
    else if (input.StartsWith("-"))     // Remove item -
    {
        string itemToRemove = input.Substring(1).Trim();
        if (itemList.Contains(itemToRemove))
        {
            itemList.Remove(itemToRemove);
            Console.WriteLine($"Removed: {itemToRemove}");
        }
        else
        {
            Console.WriteLine($"Item not found: {itemToRemove}");
        }
    }
    else if (input == "--")     //Clear the list --
    {
        itemList.Clear();
        Console.WriteLine("List cleared.");
    }
    else
    {
        Console.WriteLine("Invalid command.");
    }
    Console.WriteLine("Current list:");
    if (itemList.Count > 0)
    {
        foreach (string item in itemList)
        {
            Console.WriteLine("- " + item);
        }
    }
    else
    {
        Console.WriteLine("The list is empty.");
    }
}


// 3. caculate prime numbers
int[] primes = FindPrimesInRange(0, 50);

Console.WriteLine("Prime numbers in the range:");
foreach (int prime in primes)
{
    Console.Write(prime + " ");
}
Console.WriteLine();

static int[] FindPrimesInRange(int startNum, int endNum)
{
    List<int> primes = new List<int>();

    for (int i = startNum; i <= endNum; i++)
    {
        if (IsPrime(i))
        {
            primes.Add(i);
        }
    }

    return primes.ToArray();
}

static bool IsPrime(int num)
{
    if (num <= 1)
        return false;
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
            return false;
    }
    return true;
}


// 4. rotation sum
Console.WriteLine("Enter the array elements (space-separated):");
int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

Console.WriteLine("Enter the number of rotations:");
int k = int.Parse(Console.ReadLine());

int n = array.Length;
int[] sumArray = new int[n];

for (int r = 1; r <= k; r++)
{
    int[] rotatedArray = RotateArrayRight(array, r);
    for (int i = 0; i < n; i++)
    {
        sumArray[i] += rotatedArray[i];
    }
    Console.WriteLine($"After rotation {r}: {string.Join(" ", rotatedArray)}");
}
Console.WriteLine("Sum array: " + string.Join(" ", sumArray));

static int[] RotateArrayRight(int[] array, int r)
{
    int n = array.Length;
    int[] rotatedArray = new int[n];

    for (int i = 0; i < n; i++)
    {
        rotatedArray[(i + r) % n] = array[i];
    }
    return rotatedArray;
}


// 5. Longest Sequence
Console.WriteLine("Enter the array elements (space-separated):");
int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

int longestStart = 0;
int longestLength = 1;

int currentStart = 0;
int currentLength = 1;

for (int i = 1; i < array.Length; i++)
{
    if (array[i] == array[i - 1])
    {
        currentLength++;
    }
    else
    {
        if (currentLength > longestLength)
        {
            longestLength = currentLength;
            longestStart = currentStart;
        }
        currentStart = i;
        currentLength = 1;
    }
}
if (currentLength > longestLength)
{
    longestLength = currentLength;
    longestStart = currentStart;
}
Console.WriteLine("Longest sequence of equal elements:");
for (int i = 0; i < longestLength; i++)
{
    Console.Write(array[longestStart] + " ");
}
Console.WriteLine();


// 7. Most Frequent Number
Console.WriteLine("Enter the sequence of numbers (space-separated):");
int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
for (int i = 0; i < array.Length; i++)
{
    if (frequencyMap.ContainsKey(array[i]))
    {
        frequencyMap[array[i]]++;
    }
    else
    {
        frequencyMap[array[i]] = 1;
    }
}
int maxFrequency = frequencyMap.Values.Max();
int mostFrequentNumber = array.First(n => frequencyMap[n] == maxFrequency);
Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFrequency} times).");



// Practice Arrays


// 1. reverse string
// Convert the string to char array, reverse it, then convert it to string again
Console.WriteLine("Enter a string:");
string input1 = Console.ReadLine();
char[] charArray = input1.ToCharArray();
Array.Reverse(charArray);
string reversedString = new string(charArray);
Console.WriteLine("Reversed string: " + reversedString);

// Print the letters of the string in back direction (from the last to the first) in a for-loop
Console.WriteLine("Enter a string:");
string input2 = Console.ReadLine();
Console.Write("Reversed string: ");
for (int i = input2.Length - 1; i >= 0; i--)
{
    Console.Write(input2[i]);
}
Console.WriteLine();


// 2. reverse words
Console.WriteLine("Enter a sentence:");
string input = Console.ReadLine();
string pattern = @"(\s+|[.,:;=()&[\]""'\\\/!?]+)";
string[] parts = Regex.Split(input, pattern);
List<string> words = new List<string>();
foreach (string part in parts)
{
    if (!Regex.IsMatch(part, pattern))
    {
        words.Add(part);
    }
}
words.Reverse();
int wordIndex = 0;
for (int i = 0; i < parts.Length; i++)
{
    if (!Regex.IsMatch(parts[i], pattern))
    {
        parts[i] = words[wordIndex];
        wordIndex++;
    }
}
string result = string.Join("", parts);
Console.WriteLine("Reversed sentence: " + result);


// 3.
Console.WriteLine("Enter the text:");
string input = Console.ReadLine();
string pattern = @"[\W_]+";
string[] words = Regex.Split(input, pattern, RegexOptions.IgnoreCase);
HashSet<string> palindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var word in words)
{
    if (!string.IsNullOrWhiteSpace(word) && IsPalindrome(word))
    {
        palindromes.Add(word);
    }
}
var sortedPalindromes = palindromes.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
Console.WriteLine(string.Join(", ", sortedPalindromes));
static bool IsPalindrome(string word)
{
    int length = word.Length;
    for (int i = 0; i < length / 2; i++)
    {
        if (char.ToLower(word[i]) != char.ToLower(word[length - 1 - i]))
        {
            return false;
        }
    }
    return true;
}

// 4.
Console.WriteLine("Enter a URL:");
string url = Console.ReadLine();
string protocol = "";
string server = "";
string resource = "";
int protocolEndIndex = url.IndexOf("://");
if (protocolEndIndex != -1)
{
    protocol = url.Substring(0, protocolEndIndex);
    url = url.Substring(protocolEndIndex + 3);
}
int resourceStartIndex = url.IndexOf('/');
if (resourceStartIndex != -1) 
{
    server = url.Substring(0, resourceStartIndex); 
    resource = url.Substring(resourceStartIndex + 1);
}
else
{
    server = url; 
}
Console.WriteLine("[protocol] = \"" + protocol + "\"");
Console.WriteLine("[server] = \"" + server + "\"");
Console.WriteLine("[resource] = \"" + resource + "\"");



Console.ReadLine();