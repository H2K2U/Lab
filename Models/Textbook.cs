using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class Textbook : PrintedEdition, IInfo
    {
        // Оглавление — список строк
        public List<string> Contents { get; set; }

        // Конструктор
        public Textbook(string title, string author, decimal price, List<string> contents)
            : base(title, author, price)
        {
            Contents = contents;
        }

        // Реализация метода интерфейса IInfo
        public string GetShortInfo()
        {
            return $"{Title} ({Author})";
        }

        // Перегружаем виртуальный метод
        public override string GetInfo()
        {
            return base.GetInfo() + $"\nОглавление: {string.Join(", ", Contents)}";
        }

        // Индексатор для оглавления
        public string this[int index]
        {
            get => Contents[index];
            set => Contents[index] = value;
        }
    }
}