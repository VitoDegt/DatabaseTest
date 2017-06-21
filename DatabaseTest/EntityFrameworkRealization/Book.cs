using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkRealization
{
    public class Book
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int UserID { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
