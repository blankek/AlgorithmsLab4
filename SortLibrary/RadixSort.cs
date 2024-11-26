using System;

namespace SortLibrary
{
    public class RadixSort
    {
        public void Sort(string[] words)
        {
            int maxLength = 0;
            foreach (var word in words)
            {
                if (word.Length > maxLength)
                    maxLength = word.Length;
            }

            for (int exp = maxLength - 1; exp >= 0; exp--)
            {
                CountingSortForRadix(words, exp);
            }
        }

        private void CountingSortForRadix(string[] words, int exp)
        {
            int n = words.Length;
            string[] output = new string[n];
            int[] count = new int[256];

            for (int i = 0; i < n; i++)
            {
                int index = exp < words[i].Length ? (int)char.ToLower(words[i][exp]) : 0;
                count[index]++;
            }

            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int index = exp < words[i].Length ? (int)char.ToLower(words[i][exp]) : 0;
                output[count[index] - 1] = words[i];
                count[index]--;
            }

            for (int i = 0; i < n; i++)
            {
                words[i] = output[i];
            }
        }
    }
}
