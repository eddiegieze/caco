using System.Collections.Generic;

namespace Caco.API.Models
{
    public class Column
    {
        public string Name { get; set; }
        public List<Card> cards { get; set; }
    }
}