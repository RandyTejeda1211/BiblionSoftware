using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblion.Application.Dtos
{
    public class BookDto
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Categoria { get; set; }
        public string Author { get; set; }
        public string estado { get; set; }
    }
}
