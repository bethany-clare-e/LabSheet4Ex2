using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2Books
{
    public class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"{Title} {Price:C} {PurchaseDate.ToShortDateString()} [{Genre.ToUpper()}]";
        }

    }
}
