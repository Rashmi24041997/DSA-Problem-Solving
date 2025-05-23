﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Problem_Solving.Data_Structures;
public class StringProblems
{
    public static class Easy
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

        public static int[] AbsDifference(String s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;

            int[] result = new int[s.Length];

            int cSum = 0, vSum = 0, sum = 0;

            char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (vowels.Contains(c))
                {
                    vSum += 1;
                }
                else
                {
                    cSum += -1;
                }
                sum = vSum + cSum;
                result[i] = Math.Abs(sum);
            }
            return result;
        }

        public static int StrStrBF(string haystack, string needle)
        {
            int n = haystack.Length, m = needle.Length;

            for (int i = 0; i <= n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if (haystack[i + j] != needle[j])
                        break;
                }
                if (j == m) return i; // Found match
            }
            return -1; // No match found
        }
        public static int StrStr(string haystack, string needle)
        {
            // Edge case: If needle is empty, return 0
            if (needle.Length == 0) return 0;

            // Compute the LPS (Longest Prefix Suffix) array
            int[] lps = ComputeLPSArray(needle);
            int i = 0; // Pointer for haystack
            int j = 0; // Pointer for needle

            // Loop through haystack to find the needle
            while (i < haystack.Length)
            {
                if (haystack[i] == needle[j])
                {
                    // If characters match, move both pointers
                    i++;
                    j++;
                }
                if (j == needle.Length)
                {
                    // If we have matched the entire needle, return the start index
                    return i - j;
                }
                else if (i < haystack.Length && haystack[i] != needle[j])
                {
                    // If mismatch occurs after some matches
                    if (j != 0)
                    {
                        j = lps[j - 1]; // Use LPS array to skip unnecessary comparisons
                    }
                    else
                    {
                        i++; // Move forward in haystack if no previous match
                    }
                }
            }
            return -1; // No match found
        }

        private static int[] ComputeLPSArray(string pattern)
        {
            int m = pattern.Length;
            int[] lps = new int[m];
            int len = 0; // Length of the previous longest prefix suffix
            int i = 1; // Start from the second character

            while (i < m)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len; // Store the length of the longest prefix suffix
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1]; // Reduce length using previously computed LPS
                    }
                    else
                    {
                        lps[i] = 0; // If no match, set LPS to 0 and move ahead
                        i++;
                    }
                }
            }
            return lps;
        }

        public static bool HasSameDigits(string s)
        {
            string temp = NewString(s);
            return (temp[0].ToString() == temp[1].ToString());
        }

        private static string NewString(string s)
        {
            if (s.Length == 2) return s;
            string temp = "";
            for (int i = 0; i < s.Length - 1; i++)
            {
                int n1 = Convert.ToInt32(s[i].ToString());
                int n2 = Convert.ToInt32(s[i + 1].ToString());
                int n = (n1 + n2) % 10;
                temp += n;
            }
            return NewString(temp);
        }

        //125. Valid Palindrome
        public static bool IsPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            s = s.ToLower();
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(s[right]))
                    right--;
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }

    public static class Medium
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
        //    string result = s;
        //    int high = s.Length - 1, low = 0;
        //    while (high != low)
        //    {
        //        if (s[low] == s[high])
        //        {
        //            low--;
        //            high--;
        //        }
        //        else
        //        {
        //            low++;
        //        }
        //    }
        //}

        public static string LongestPalindromeHelper(string s, int low, int high)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 1) return "";

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Check for odd-length palindrome (centered at a single character)
                int len1 = ExpandAroundCenter(s, i, i);

                // Check for even-length palindrome (centered between two characters)
                int len2 = ExpandAroundCenter(s, i, i + 1);

                // Take the longer of the two lengths
                int len = Math.Max(len1, len2);

                // Update the start and end indices if a longer palindrome is found
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            // Extract the longest palindromic substring using start and end indices
            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            // Length of the palindrome is (right - left - 1)
            return right - left - 1;
        }

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

        /*
         Given a string s, find the length of the longest substring without repeating characters.
         */
        public static int LengthOfLongestSubstringBF(string s)
        {
            if (s.Length < 2) return s.Length;
            int ans = 0;
            int n = s.Length;
            HashSet<char> set = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (ans >= s.Length - i) break;
                char o = s[i];
                set.Add(o);
                for (int j = i + 1; j < s.Length; j++)
                {
                    char t = s[j];
                    if (!set.Contains(t))
                    {
                        set.Add(t);
                    }
                    else break;
                }
                if (set.Count > ans)
                    ans = set.Count;
                set = new();
            }
            return ans;
        }

        public static int LengthOfLongestSubstringBtr(string s)
        {
            int maxLen = 0, currLen = 0, l = 0;
            HashSet<char> set = new();

            for (int r = 0; r < s.Length; r++)
            {
                char c = s[r];
                while (l < r && set.Contains(c))
                {
                    set.Remove(c);
                    l++;
                }
                set.Add(c);
                currLen = r - l + 1;
                maxLen = Math.Max(maxLen, currLen);
            }
            return maxLen;
        }

        public static int LengthOfLongestSubstringOpt(string s)
        {
            int left = 0, len = 0;

            Dictionary<char, int> dict = new();

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                if (dict.ContainsKey(c))
                {
                    left = Math.Max(left, dict[c] + 1);
                    dict[c] = right;
                }
                else
                    dict.Add(c, right);
                len = Math.Max(len, right - left + 1);
            }
            return len;
        }

        public static string FrequencySortBF(string s)
        {
            Dictionary<char, int> dict = new();
            List<int> freqs = new();
            int max = 0;
            string ans = "";
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }
            freqs = dict.Values.ToList();
            freqs.Sort();
            for (int j = freqs.Count - 1; j >= 0; j--)
            {
                int fre = freqs[j];
                char chr = dict.FirstOrDefault(x => x.Value == fre).Key;
                if (fre >= max)
                {
                    //ans = ((string)chr * fre) + ans;
                    for (global::System.Int32 i = 0; i < fre; i++)
                    {
                        ans = chr + ans;
                    }
                    max = fre;
                }
                else
                {
                    for (global::System.Int32 i = 0; i < fre; i++)
                    {
                        ans = ans + chr;
                    }
                }
                dict.Remove(chr);

            }
            return ans;
        }

        public static string FrequencySort(string s)
        {
            // Step 1: Count the frequency of each character
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (freqMap.ContainsKey(c))
                    freqMap[c]++;
                else
                    freqMap[c] = 1;
            }

            // Step 2: Sort the characters by frequency in descending order
            // Create a list of characters ordered by their frequency
            var sortedChars = freqMap.OrderByDescending(x => x.Value);

            // Step 3: Build the result string
            StringBuilder sb = new StringBuilder();
            foreach (var pair in sortedChars)
            {
                // Append the character 'frequency' times
                sb.Append(new string(pair.Key, pair.Value));
            }

            // Step 4: Return the result
            return sb.ToString();

        }

        public static int MyAtoiRev(string s)
        {
            s = s.Trim();
            string validChrs = "1234567890-+";
            string temp = "";
            bool tkZs = false, tkSign = true, fstdigt = false;

            for (int i = 0; i < s.Length; i++)
            {
                //string c = s[i].ToString();
                char c = s[i];
                if (!validChrs.Contains(c))
                    break;
                if (c == '-' || c == '+')
                    if (tkSign)
                    {
                        temp += c == '-' ? c : "";
                        tkSign = false;
                    }
                    else
                        break;
                else if (c == '0')
                {
                    tkSign = false;
                    temp += tkZs ? '0' : "";
                }
                else
                //if (c != '.')
                {
                    tkSign = false;
                    //fstdigt = true;
                    tkZs = true;
                    temp += c;
                }
                //else
                //{
                //    tkSign = false;
                //    temp += c;
                //}
            }
            if (temp == "" || temp == "-")
                return 0;
            BigInteger l = BigInteger.Parse(temp);
            if (l > int.MaxValue)
                return int.MaxValue;
            if (l < int.MinValue)
                return int.MinValue;
            return (int)l;
        }

        public static string CountAndSay(int n)
        {
            string ans = "1";
            string prevAns = "1";
            int t = 0;
            while (t < n - 1)
            {
                string crAns = "";
                int left = 0, crnt = 1, cnt = 1;
                while (left <= crnt && crnt < ans.Length)
                {
                    if (ans[left] == ans[crnt])
                    {
                        cnt++;
                    }
                    else
                    {
                        crAns = crAns + cnt + ans[left];
                        left = crnt;
                        cnt = 1;
                    }
                    crnt++;
                }
                crAns = crAns + cnt + ans[left];
                ans = crAns;
                t++;
            }
            return ans;
        }

        public static int BeautySum(string s)
        {
            int ans = 0;
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                int[] freq = new int[26]; // fixed-size array instead of Dictionary
                for (int j = i; j < n; j++)
                {
                    freq[s[j] - 'a']++;

                    int max = 0;
                    int min = int.MaxValue;

                    for (int k = 0; k < 26; k++)
                    {
                        if (freq[k] > 0)
                        {
                            max = Math.Max(max, freq[k]);
                            min = Math.Min(min, freq[k]);
                        }
                    }

                    ans += (max - min);
                }
            }
            return ans;
        }
    }

    class Hard
    {

    }
}
