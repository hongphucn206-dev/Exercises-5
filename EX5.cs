using System;

namespace EX5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1: Array operations with random integers
            int[] array = new int[10];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 101); // Random numbers from 1 to 100
            }
            Console.WriteLine("Random Array: " + string.Join(", ", array));

            // Test array functions
            Console.WriteLine("Average: " + CalculateAverage(array));
            int searchValue = array[3];
            Console.WriteLine("Contains " + searchValue + ": " + ContainsValue(array, searchValue));
            Console.WriteLine("Index of " + searchValue + ": " + FindIndex(array, searchValue));
            Console.WriteLine("Array after removing " + searchValue + ": " + string.Join(", ", RemoveElement(array, searchValue)));
            FindMaxMin(array, out int max, out int min);
            Console.WriteLine("Max: " + max + ", Min: " + min);
            Console.WriteLine("Reversed Array: " + string.Join(", ", ReverseArray(array)));
            Console.WriteLine("Duplicates: " + string.Join(", ", FindDuplicates(array)));
            Console.WriteLine("Array without duplicates: " + string.Join(", ", RemoveDuplicates(array)));

            // Part 2: Bubble Sort
            Console.WriteLine("\nEnter 10 integers:");
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Number " + (i + 1) + ": ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            BubbleSort(numbers);
            Console.WriteLine("Sorted Array: " + string.Join(", ", numbers));

            // Part 3: Linear Search in sentence
            Console.WriteLine("\nEnter a sentence:");
            string sentence = Console.ReadLine();
            Console.WriteLine("Enter a word to search:");
            string word = Console.ReadLine();
            bool found = LinearSearchWord(sentence, word);
            Console.WriteLine(found ? "Word '" + word + "' found!" : "Word '" + word + "' not found!");

            Console.ReadLine();
        }

        // 1. Calculate average
        static double CalculateAverage(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return (double)sum / array.Length;
        }

        // 2. Check if array contains value
        static bool ContainsValue(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return true;
            }
            return false;
        }

        // 3. Find index of element
        static int FindIndex(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return i;
            }
            return -1;
        }

        // 4. Remove specific element
        static int[] RemoveElement(int[] array, int value)
        {
            int newSize = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != value)
                    newSize++;
            }
            int[] result = new int[newSize];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != value)
                    result[index++] = array[i];
            }
            return result;
        }

        // 5. Find max and min
        static void FindMaxMin(int[] array, out int max, out int min)
        {
            max = array[0];
            min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
                if (array[i] < min)
                    min = array[i];
            }
        }

        // 6. Reverse array
        static int[] ReverseArray(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[array.Length - 1 - i];
            }
            return result;
        }

        // 7. Find duplicates
        static int[] FindDuplicates(int[] array)
        {
            int[] temp = new int[array.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        bool alreadyAdded = false;
                        for (int k = 0; k < count; k++)
                        {
                            if (temp[k] == array[i])
                                alreadyAdded = true;
                        }
                        if (!alreadyAdded)
                            temp[count++] = array[i];
                    }
                }
            }
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }
            return result;
        }

        // 8. Remove duplicates
        static int[] RemoveDuplicates(int[] array)
        {
            int[] temp = new int[array.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < count; j++)
                {
                    if (array[i] == temp[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                    temp[count++] = array[i];
            }
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }
            return result;
        }

        // Bubble Sort
        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Linear Search for word
        static bool LinearSearchWord(string sentence, string word)
        {
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Equals(word, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}