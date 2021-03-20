using System.Collections.Generic;

namespace Caco.API.Model
{
    public class Column
    {
        public string Name { get; set; }
        public List<Card> cards { get; set; }
    }
}