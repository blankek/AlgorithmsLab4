using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SortLibrary;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgSort
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isButtonClicked = false;

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            isButtonClicked = true;
            SortButton.Background = Brushes.Black; // Изменяем цвет фона кнопки, чтобы показать, что она была нажата

            string filePath = "C:\\Users\\komba\\source\\repos\\AlgSort\\AlgSort\\bin\\Debug\\net8.0-windows\\lab.txt";
            string text = ReadFromFile(filePath);
            string[] words = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Stopwatch stopwatch = new Stopwatch(); // Создаем экземпляр Stopwatch

            if (InsertionRadio.IsChecked == true)
            {
                // Insertion sort
                InsertionSort insertionSorter = new InsertionSort();
                stopwatch.Start(); // Начинаем отсчет времени
                insertionSorter.Sort(words);
                stopwatch.Stop(); // Останавливаем отсчет времени
                ResultTextBox.Text = $"Insertion sort: {string.Join(", ", words).Replace(".", "").Replace(",,", ",")}\n";
            }
            else if (RadixRadio.IsChecked == true)
            {
                // Radix sort
                RadixSort radixSorter = new RadixSort();
                stopwatch.Start(); // Начинаем отсчет времени
                radixSorter.Sort(words);
                stopwatch.Stop(); // Останавливаем отсчет времени
                ResultTextBox.Text = $"Radix sort: {string.Join(", ", words).Replace(".", "").Replace(",,", ",")}\n";
            }

            // Устанавливаем текст для отображения времени выполнения
            TimeTextBlock.Text = $"Время выполнения: {stopwatch.ElapsedMilliseconds} мс";

            // Подсчет частоты слов
            var wordCount = CountWordFrequencies(words);
            DisplayWordFrequencies(wordCount);

            // Сбрасываем состояние кнопки
            isButtonClicked = false;
            SortButton.Background = Brushes.White; // Возвращаем исходный цвет фона кнопки
        }

        private string ReadFromFile(string filePath)
        {
            string text = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    text = reader.ReadToEnd(); // Чтение всего текста из файла
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }

            return text;
        }

        private Dictionary<string, int> CountWordFrequencies(string[] words)
        {
            var wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
            return wordCount;
        }

        private void DisplayWordFrequencies(Dictionary<string, int> wordCount)
        {
            FrequencyTextBox.Clear();
            foreach (var kvp in wordCount)
            {
                FrequencyTextBox.AppendText($"{kvp.Key}: {kvp.Value}\n");
            }
        }
    }
}
