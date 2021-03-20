using System.Collections.Generic;

namespace Caco.API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColumnId { get; set; }
        public Column Column { get; set; }
    }
}