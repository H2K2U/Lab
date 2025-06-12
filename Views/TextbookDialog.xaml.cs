using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Globalization;

using Lab.Models;

namespace Lab.Views
{
    public partial class TextbookDialog : Window
    {
        public string BookTitle => TitleBox.Text.Trim();
        public string Author => AuthorBox.Text.Trim();
        public decimal Price { get; private set; }
        public List<string> Contents { get; private set; } = new List<string>();

        public TextbookDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(BookTitle) || string.IsNullOrWhiteSpace(Author) || string.IsNullOrWhiteSpace(PriceBox.Text))
                    throw new TextbookException("Пожалуйста, заполните все поля!");

                string priceText = PriceBox.Text.Trim().Replace(',', '.');
                if (!decimal.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out var price))
                    throw new TextbookException("Цена должна быть числом! Используйте точку или запятую в качестве разделителя.");


                if (price < 0)
                    throw new TextbookException("Цена не может быть отрицательной!");

                Price = price;

                // Оглавление по строкам
                Contents = new List<string>();
                foreach (var line in ContentsBox.Text.Split('\n'))
                {
                    var trimmed = line.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                        Contents.Add(trimmed);
                }

                if (Contents.Count == 0)
                    throw new TextbookException("Оглавление не может быть пустым!");

                this.DialogResult = true;
            }
            catch (TextbookException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
