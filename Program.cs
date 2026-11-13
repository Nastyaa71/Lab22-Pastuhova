using System;
using System.Collections.Generic;


void PrintFrequencies(Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}

void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.TryGetValue(word, out int count))
    {
        frequencies[word] = count + 1;
    }
    else
    {
        frequencies.Add(word, 1);
    }
}

int SumFrequencies(Dictionary<string, int> frequencies)
{
    int total = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        total += entry.Value;
    }
    return total;
}



HashSet<string> excludedWords = new HashSet<string> { "и", "в", "на" };


Console.Write("Слово для добавления в исключения: ");
string addExclude = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

if (excludedWords.Add(addExclude))
{
    Console.WriteLine("Исключение добавлено");
}
else
{
    Console.WriteLine("Такое исключение уже есть");
}


Console.Write("Слово для удаления из исключений: ");
string removeExclude = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

if (excludedWords.Remove(removeExclude))
{
    Console.WriteLine("Исключение удалено");
}
else
{
    Console.WriteLine("Такого исключения нет");
}

Console.WriteLine($"Количество исключений: {excludedWords.Count}");


Console.Write("Введите текст: ");
string text = Console.ReadLine() ?? "";

string[] words = text.ToLowerInvariant()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


Dictionary<string, int> frequencies = new Dictionary<string, int>();

foreach (string word in words)
{
    if (!excludedWords.Contains(word))
    {
        AddWord(frequencies, word);
    }
}


int totalWords = words.Length;
int countedWords = SumFrequencies(frequencies);
int skippedWords = totalWords - countedWords;

Console.WriteLine();
Console.WriteLine(">>> Анализ слов <<<");
Console.WriteLine();
Console.WriteLine($"Исходная строка: [{text}]");
Console.WriteLine($"Всего слов: {totalWords}");
Console.WriteLine($"Пропущено слов: {skippedWords}");
Console.WriteLine($"Учтено слов: {countedWords}");
Console.WriteLine($"Разных учтённых слов: {frequencies.Count}");
Console.WriteLine();
Console.WriteLine("Частоты слов:");
PrintFrequencies(frequencies);


Console.WriteLine();
Console.Write("Слово для поиска: ");
string searchWord = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

if (frequencies.TryGetValue(searchWord, out int found))
{
    Console.WriteLine($"Количество вхождений: {found}");
}
else
{
    Console.WriteLine("Слово не найдено");
}


int CountFrequentWords(Dictionary<string, int> frequencies, int limit)
{
    int result = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        if (entry.Value >= limit)
        {
            result++;
        }
    }
    return result;
}
Console.WriteLine();
Console.Write("Минимальная частота для подсчёта (1-100): ");
int limit = Convert.ToInt32(Console.ReadLine());
int frequentCount = CountFrequentWords(frequencies, limit);
Console.WriteLine($"Слов с частотой не меньше {limit}: {frequentCount}");
