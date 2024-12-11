using System;

namespace SortLibrary
{
    public class RadixSort
    {
        public List<string> RadixSorted(List<string> words)
        {
            int maxLength = words.Max(word => word.Length);
            for (int k = maxLength - 1; k >= 0; k--)
            {
                words = words.OrderBy(word => k < word.Length ? word[k] : '\0').ToList();
            }
            return words;
        }

    }
}
