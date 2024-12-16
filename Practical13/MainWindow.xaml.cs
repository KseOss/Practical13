using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Practical13
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Analyze_Click(object sender, RoutedEventArgs e)
        {
            var matrix = ParseMatrix(InputMatrix.Text);
            if (matrix == null)
            {
                MessageBox.Show("Отсутствуют исходные данные для расчета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int resultRow = MatrixHelper.FindRowWithMaxDuplicates(matrix);
            ResultText.Text = resultRow >= 0 ? $"Номер строки: {resultRow + 1}" : "Нет строк с одинаковыми элементами.";
            statusText.Text = $"Size: {matrix.GetLength(0)} x {matrix.GetLength(1)}, Cell: N/A";
        }

        private int[,] ParseMatrix(string input)
        {
            try
            {
                var rows = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var matrix = new int[rows.Length, rows[0].Split(' ').Length];

                for (int i = 0; i < rows.Length; i++)
                {
                    var cols = rows[i].Split(' ').Select(int.Parse).ToArray();
                    for (int j = 0; j < cols.Length; j++)
                    {
                        matrix[i, j] = cols[j];
                    }
                }
                return matrix;
            }
            catch
            {
                return null;
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Создание диалогового окна для открытия файла
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // Чтение содержимого файла и установка его в TextBox
                InputMatrix.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            // Создание диалогового окна для сохранения файла
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                // Сохранение содержимого TextBox в файл
                File.WriteAllText(saveFileDialog.FileName, InputMatrix.Text);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developer: Fals$h\nPractical: #12\\nMatrix Analyzer v1.0", "О программе", MessageBoxButton.OK);
        }
    }
}