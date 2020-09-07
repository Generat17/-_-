using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string fileName;
        private string readText;
        private List<string> ListWords = new List<string>();
        private List<string> FindWords = new List<string>();

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Имя файла по умолчанию 
            dlg.DefaultExt = ".txt"; // Расширение файла по умолчанию
            dlg.Filter = "Text documents (.txt)|*.txt"; // Фильтр файлов по расширению 

            // Показать диалоговое окно открытия файла
            bool? result = dlg.ShowDialog();

            // Обработка результатов диалогового окна открытия файла
            if (result == true)
            {
                // Open document
                fileName = dlg.FileName;
                path_file.Text = fileName;        
            }
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Приложение выполняется мгновенно, поэтому искусственная задержка
            Thread.Sleep(1000);

            if (fileName == null) {
                path_file.Text = "Укажите путь к файлу";
                return;
            } 
            else { 
                readText = File.ReadAllText(fileName);
            }

            string[] words = readText.Split(' ', ',', '.', '!', '?');

            foreach (string word in words)
            {
                if (!ListWords.Contains(word))
                {
                    ListWords.Add(word);
                }
            }

            main_content.ItemsSource = ListWords;


            stopWatch.Stop();
            // Получите прошедшее время как значение TimeSpan.
            TimeSpan ts = stopWatch.Elapsed;

            // Отформатируйте и отобразите значение TimeSpan.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            elapsed_time.Text = elapsedTime;

        }

        private void FindWord_Click(object sender, RoutedEventArgs e)
        {
            if (find_field.Text == null)
            {
                return;
            }
            if (ListWords.Contains(find_field.Text))
            {
                FindWords.Add(find_field.Text);
                find_words.ItemsSource = FindWords;
                find_field.Text = "";

            }
            else
            {
                find_field.Text = "";
            }
        }
    }
}
