using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public abstract class PrintedEdition
    {
        // Свойства
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        // Конструктор
        protected PrintedEdition(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        // Виртуальный метод (пример)
        public virtual string GetInfo()
        {
            return $"{Title} ({Author}), цена: {Price} руб.";
        }
    }
}
