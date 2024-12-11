using System.Collections.Generic;

namespace SortLibrary
{
    public class InsertionSort
    {
        public void Sort(List<string> words)
        {
            for (int i = 1; i < words.Count; i++)
            {
                var key = words[i];
                int j = i - 1;

                // Сравниваем и перемещаем элементы
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
