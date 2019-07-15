using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromicPermutation
{
    public static class StringAnalyzer
    {
        /// <summary>
        /// Check if for the given input exists a permutation that is palindrome.
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>True if a palindromic permutation exists, false otherwise</returns>
        public static bool IsPermutationPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            List<string> formattedInputs = FormatInput(input);
            if (formattedInputs.Any())
            {
                foreach (string str in formattedInputs)
                {
                    if (str.Length == 1)
                    {
                        return true;
                    }

                    Dictionary<char, int> occurencesOfChar = CountOccurrencesOfChar(str);
                    if (IsPalindrome(occurencesOfChar, str.Length))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// for the given iput, counts the occurences of each character
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>a set of characters and their occurences</returns>
        private static Dictionary<char, int> CountOccurrencesOfChar(string input)
        {
            int numberOfOccurencies = 1;
            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            foreach (char c in input)
            {
                numberOfOccurencies = 1;

                if (charOccurrences.ContainsKey(c))
                {
                    numberOfOccurencies = charOccurrences[c];
                    numberOfOccurencies++;
                    charOccurrences[c] = numberOfOccurencies;
                }
                else
                {
                    charOccurrences.Add(c, numberOfOccurencies);
                }
            }

            return charOccurrences;
        }


        /// <summary>
        /// Check if the input is palindrome
        /// </summary>
        /// <param name="occurencesOfChar">a set of characters and their occurences for the input string</param>
        /// <param name="inputlenght">lenght of the input string</param>
        /// <returns>true if the input is palindrome, false otherwise</returns>
        private static bool IsPalindrome(Dictionary<char, int> occurencesOfChar, int inputlenght)
        {
            if (inputlenght % 2 == 0)
            {
                foreach (var elem in occurencesOfChar)
                {
                    if (elem.Value % 2 != 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                int oddOccurencesOfChar = 0;

                foreach (var elem in occurencesOfChar)
                {
                    if (elem.Value % 2 != 0)
                    {
                        oddOccurencesOfChar++;

                        if (oddOccurencesOfChar > 1)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// Format the input.
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>list of strings</returns>
        private static List<string> FormatInput(string input)
        {
            List<string> allStrings = new List<string> { };
            string formattedString = string.Empty;
            bool isUpperCase = false;
            bool isDot = false;
            string inputWithoutSpaces = input.Replace(" ", "");
            int countDots = 0;
            string dots = string.Empty;

            foreach (char c in inputWithoutSpaces)
            {
                isUpperCase = (c >= 'A' && c <= 'Z');
                isDot = c.Equals('.');

                if (isDot)
                {
                    countDots++;
                    dots = dots + c;
                }

                if (countDots >= 1 && !isDot)
                {
                    if (countDots > 1)
                    {
                        formattedString = formattedString + dots;
                    }

                    //More than one consecutive dots (ellipses). Save the string, don't lose the dots
                    if (countDots == 1 && !string.IsNullOrWhiteSpace(formattedString))
                    {
                        allStrings.Add(formattedString);
                        formattedString = string.Empty;
                    }

                    countDots = 0;
                    dots = string.Empty;
                }

                if (!isDot)
                {
                    formattedString = isUpperCase ? formattedString + char.ToLower(c) : formattedString + c;
                }
            }

            //Save the string of only dots
            if (countDots >= 1 && isDot && string.IsNullOrWhiteSpace(formattedString))
            {
                allStrings.Add(dots);
            }

            //Save the string. No more characters are available and we didn't find '.' at the end of the string
            if (!allStrings.Contains(formattedString) && !string.IsNullOrWhiteSpace(formattedString))
            {
                allStrings.Add(formattedString);
            }

            return allStrings;
        }
    }
}
