using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    // Пользовательское исключение для ошибок данных учебника
    public class TextbookException : Exception
    {
        public TextbookException(string message) : base(message) { }
    }
}
