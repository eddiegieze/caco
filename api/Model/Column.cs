using System.Collections.Generic;

namespace Caco.API.Models
{
    public class Column
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}