using System.Collections.Generic;

namespace Caco.API.Model
{
    public class Board
    {
        public string Name { get; set; }
        public List<Column> columns { get; set; }
    }
}