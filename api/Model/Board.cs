using System.Collections.Generic;

namespace Caco.API.Models
{
    public class Board
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
    }
}