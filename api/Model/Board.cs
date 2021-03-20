using System.Collections.Generic;

namespace Caco.API.Models
{
    public class Board
    {
        public string Name { get; set; }
        public List<Column> columns { get; set; }
    }
}