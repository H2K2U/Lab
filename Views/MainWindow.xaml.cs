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
using System.Collections.ObjectModel;

using Lab.Models;
using Lab.Collections;


namespace Lab.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Привязываем коллекцию к таблице
            TextbooksDataGrid.ItemsSource = Textbooks;
            
            AddButton.Click += AddButton_Click;
            RemoveButton.Click += RemoveButton_Click;
            EditButton.Click += EditButton_Click;
        }
        public ObservableCollection<TextbookViewModel> Textbooks { get; set; } = new ObservableCollection<TextbookViewModel>();
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TextbookDialog();
            dialog.Owner = this;
            if (dialog.ShowDialog() == true)
            {
                var newBook = new Lab.Models.Textbook(
                    dialog.BookTitle,
                    dialog.Author,
                    dialog.Price,
                    dialog.Contents
                );
                Textbooks.Add(new Lab.Models.TextbookViewModel(newBook));
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextbooksDataGrid.SelectedItem is Lab.Models.TextbookViewModel selected)
            {
                var result = MessageBox.Show(
                    $"Удалить учебник \"{selected.Title}\"?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Textbooks.Remove(selected);
                }
            }
            else
            {
                MessageBox.Show("Выберите учебник для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextbooksDataGrid.SelectedItem is Lab.Models.TextbookViewModel selected)
            {
                // Заполняем диалог начальными значениями
                var dialog = new Lab.Views.TextbookDialog();
                dialog.Owner = this;

                // Заполняем поля данными
                dialog.TitleBox.Text = selected.Title;
                dialog.AuthorBox.Text = selected.Author;
                dialog.PriceBox.Text = selected.Price.ToString();
                dialog.ContentsBox.Text = selected.ContentsText.Replace("; ", "\n");

                if (dialog.ShowDialog() == true)
                {
                    // Обновляем значения в выбранном элементе
                    selected.Title = dialog.BookTitle;
                    selected.Author = dialog.Author;
                    selected.Price = dialog.Price;
                    selected.ContentsText = string.Join("; ", dialog.Contents);

                    // Принудительно обновляем DataGrid
                    TextbooksDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите учебник для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Лабораторная работа\n\nВариант 3: Печатное издание -> Учебник\n\nАвтор: Пархаев В.У.",
                "О программе",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

    }
}
