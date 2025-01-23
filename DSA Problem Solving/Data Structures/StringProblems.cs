﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures
{
    internal class StringProblems
    {
        internal static class Easy
        {
            /// <summary>
            /// Reverses the words in a given string.
            /// Time Complexity: O(n) where n is the length of the string.
            /// Space Complexity: O(n) for storing words and the result.
            /// </summary>
            /// <param name="s">The input string.</param>
            /// <returns>The string with words in reverse order.</returns>
            public static string ReverseWords(string s)
            {
                if (s == null) return null; // Check for null input
                List<string> words = new List<string>(); // List to store words
                string res = ""; // Result string
                string word = ""; // Temporary word storage
                for (int i = 0; i < s.Length; i++) // Iterate through each character in the string
                {
                    string chr = s[i].ToString();
                    if (chr != " ")
                        word += chr; // Build the current word
                    else
                    {
                        if (word != "") words.Add(word); // Add the word to the list if it's not empty
                        word = ""; // Reset the word
                    }
                }
                if (word != "") words.Add(word); // Add the last word if it's not empty
                for (int i = words.Count - 1; i >= 0; i--) // Iterate through the list of words in reverse order
                {
                    if (i != 0)
                        res += words[i] + " "; // Append the word and a space
                    else
                        res += words[i]; // Append the last word without a trailing space
                }
                return res; // Return the result
            }

            public static int RomanToInt(string s)
            {
                if (s == null || s.Length == 0) return 0; // Check for null input
                Dictionary<string, int> symbols = new()
                {
                    { "I", 1 },
                    { "V", 5 },
                    { "X", 10 },
                    { "L", 50 },
                    { "C", 100 },
                    { "D", 500 },
                    { "M", 1000 },
                    { "IV", 4 },
                    { "IX", 9 },
                    { "XL", 40 },
                    { "XC", 90 },
                    { "CD", 400 },
                    { "CM", 900}
                };

                int result = 0;

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    string symbol = s[i].ToString();
                    if (i > 0)
                    {
                        symbol = s[i - 1].ToString() + symbol;
                    }
                    if (symbols.TryGetValue(symbol, out int j))
                    {
                        result += j;
                        i--;
                    }
                    else
                    {
                        symbol = s[i].ToString();
                        if (symbols.TryGetValue(symbol, out int k))
                        {
                            result += k;
                        }
                    }
                }

                return result;
            }

            public static string LongestCommonPrefix(string[] strs)
            {
                if (strs == null || strs.Length == 0) return ""; // Check for null input
                string prefix = strs[0];
                for (int i = 1; i < strs.Length; i++)
                {
                    string word = strs[i];
                    //string newPrefix = "";
                    for (int j = 0; j < prefix.Length; j++)
                    {
                        if (j >= word.Length)
                        {
                            prefix = prefix.Remove(j);
                            break;
                        }
                        //string chr1 = prefix[j].ToString();
                        //string chr2 = word[j].ToString();
                        //if (chr1 == chr2)
                        //    newPrefix += chr1;
                        if (prefix[j] == word[j])
                        {
                            if (j == 0)
                                return "";
                            else
                                prefix = prefix.Remove(j);
                            break;
                        }
                    }
                }
                return prefix;
            }
        }

        internal static class Medium
        {
            /// <summary>
            /// Finds all words in words1 that are universal to words2.
            /// Time Complexity: O(n * m) where n is the length of words1 and m is the length of words2.
            /// Space Complexity: O(n) for storing the result.
            /// </summary>
            /// <param name="words1">The list of words to check.</param>
            /// <param name="words2">The list of words to be universal to.</param>
            /// <returns>A list of universal words.</returns>
            public static IList<string> WordSubsets(string[] words1, string[] words2)
            {
                if (words1 == null || words1.Length == 0) return null; // Check for null or empty input
                if (words2 == null || words2.Length == 0) return null; // Check for null or empty input
                IList<string> result = new List<string>(); // List to store the result
                for (int i = 0; i < words1.Length; i++) // Iterate through each word in words1
                {
                    string word = words1[i];
                    string wordCopy = word; // Copy of the current word
                    bool add = true; // Flag to determine if the word should be added to the result
                    foreach (string subWord in words2) // Iterate through each word in words2
                    {
                        foreach (char chr in subWord) // Iterate through each character in the subWord
                        {
                            if (!word.Contains(chr)) // Check if the character is not in the word
                            {
                                add = false; // Set the flag to false
                                break; // Break the loop
                            }
                        }
                    }
                    if (add) result.Add(wordCopy); // Add the word to the result if the flag is true
                }
                return result; // Return the result
            }


            public static bool RotateString(string s, string goal)
            {
                string result = "";
                string og = s;
                List<KeyValuePair<char, bool>> chars = new();
                foreach (char item in s)
                {
                    chars.Add(new KeyValuePair<char, bool>(item, false));
                }
                for (int i = 0; i <= s.Length; i++)
                {
                    result = s.Remove(0, 1) + s[0];
                    if (result == goal)
                    {
                        return true;
                    }
                    s = s.Remove(0, 1) + s[0];
                }
                return false;
            }
            //public static string LongestPalindrome(string s)
            //{
            //    int high = s.Length-1, low = 0 ;
            //    while 
            //}

            public static int MyAtoi(string s)
            {
                HashSet<char> digits = new HashSet<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                bool signDecided = false;
                int sign = 1;
                string t = "";

                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];

                    if (c == '+')
                    {
                        if (t != "") break;
                        if (!signDecided)
                            signDecided = true;
                        else break;
                        continue;
                    }

                    if (c == '-')
                    {
                        if (t != "") break;
                        if (!signDecided)
                        {
                            sign = -1;
                            signDecided = true;
                            continue;
                        }
                        else break;
                    }

                    if (c == ' ')
                        if (t != "")
                            break;
                        else
                            continue;

                    if (!digits.Contains(c))
                        //if(t != "")
                        break;
                    t += c;
                    long temp = Convert.ToInt64(t == "" ? 0 : t) * sign;
                    if (temp <= int.MinValue) return int.MinValue;
                    if (temp >= int.MaxValue) return int.MaxValue;
                }
                if (t is null || t == "") return 0;
                return Convert.ToInt32(t) * sign;
            }
        }
        class Hard
        {

        }
    }
}
