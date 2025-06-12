using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class TextbookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ContentsText { get; set; }

        public TextbookViewModel(Textbook textbook)
        {
            Title = textbook.Title;
            Author = textbook.Author;
            Price = textbook.Price;
            ContentsText = string.Join("; ", textbook.Contents);
        }
    }
}
