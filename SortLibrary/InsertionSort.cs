using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    public class InsertionSort
    {
        public void Sort(string[] words)
        {
            int n = words.Length;
            for (int i = 1; i < n; i++)
            {
                string key = words[i];
                int j = i - 1;

                // Перемещаем элементы, которые больше ключа, на одну позицию вперед
                while (j >= 0 && string.Compare(words[j], key) > 0)
                {
                    words[j + 1] = words[j];
                    j--;
                }
                words[j + 1] = key;
            }
        }
    }
}
