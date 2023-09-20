using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProEventos.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public void ReverseString(int[] nums, int target)
        {
            string originalString = "Hello, World!";
            char[] charArray = originalString.ToCharArray();

            Array.Reverse(charArray);

            string reversedString = new string(charArray);
            Console.WriteLine(reversedString);
        }

        public static bool IsPalindrome(string input)
        {
            // Remove spaces and convert to lowercase (if needed) to make the check case-insensitive
            input = input.Replace(" ", "").ToLower();

            // Reverse the input string
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);

            // Compare the original string with the reversed string
            return input == reversedString;
        }

        public static int CountOccurrences(string inputString, char targetCharacter)
        {
            int count = 0;

            foreach (char character in inputString)
            {
                if (character == targetCharacter)
                {
                    count++;
                }
            }

            return count;
        }

        public static bool AreAnagrams(string str1, string str2)
        {
            // Remove spaces and convert to lowercase for case-insensitive comparison
            string cleanStr1 = new string(str1.ToLower().Where(char.IsLetter).ToArray());
            string cleanStr2 = new string(str2.ToLower().Where(char.IsLetter).ToArray());

            // Check if the two cleaned strings are of the same length
            if (cleanStr1.Length != cleanStr2.Length)
            {
                return false;
            }

            // Create dictionaries to count character frequencies
            Dictionary<char, int> charCount1 = new Dictionary<char, int>();
            Dictionary<char, int> charCount2 = new Dictionary<char, int>();

            // Count character frequencies in the first string
            foreach (char c in cleanStr1)
            {
                if (charCount1.ContainsKey(c))
                {
                    charCount1[c]++;
                }
                else
                {
                    charCount1[c] = 1;
                }
            }

            // Count character frequencies in the second string
            foreach (char c in cleanStr2)
            {
                if (charCount2.ContainsKey(c))
                {
                    charCount2[c]++;
                }
                else
                {
                    charCount2[c] = 1;
                }
            }

            // Compare the character frequencies in both dictionaries
            return charCount1.OrderBy(kv => kv.Key).SequenceEqual(charCount2.OrderBy(kv => kv.Key));
        }

        public static void CountVowelsAndConsonants(string inputString, out int vowelCount, out int consonantCount)
        {
            vowelCount = 0;
            consonantCount = 0;

            string cleanedString = inputString.ToLower(); // Convert the string to lowercase for case-insensitive comparison

            foreach (char c in cleanedString)
            {
                if (char.IsLetter(c))
                {
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
        }

        public static void matchingElements()
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };

            var matchingElements = array1.Where(element => array2.Contains(element));

            foreach (int element in matchingElements)
            {
                Console.WriteLine(element);
            }
        }

        public int[] getMatchingElements(int[] numbers, int target)
        {
            return numbers.Where(x => x == target).ToArray();
        }

        static void BubbleSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap arr[j] and arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped in inner loop, the array is already sorted.
                if (!swapped)
                    break;
            }
        }

        static void InsertionSortAlgorithm(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1] that are greater than key
                // to one position ahead of their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = key;
            }
        }

        static void ReverseArray(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                // Swap elements at left and right indices
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                // Move the pointers towards the center
                left++;
                right--;
            }
        }

        static void swapNumbers(int a, int b) 
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            long result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        static int FibonacciRecursive(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
            }
        }

        static int FibonacciIterative(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            int fib = 0;
            int prev = 1;
            int prevPrev = 0;

            for (int i = 2; i <= n; i++)
            {
                fib = prev + prevPrev;
                prevPrev = prev;
                prev = fib;
            }

            return fib;
        }

        static int FibonacciIndexIterative(int index)
        {
            if (index <= 1)
            {
                return index;
            }

            int fib = 0;
            int prev = 1;
            int prevPrev = 0;

            for (int i = 2; i <= index; i++)
            {
                fib = prev + prevPrev;
                prevPrev = prev;
                prev = fib;
            }

            return fib;
        }

        static int FibonacciIndexRecursive(int index)
        {
            if (index <= 1)
            {
                return index;
            }
            else
            {
                return FibonacciIndexRecursive(index - 1) + FibonacciIndexRecursive(index - 2);
            }
        }
    }   
}
