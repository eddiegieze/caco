using System.ComponentModel.DataAnnotations;

namespace Caco.API.Resources
{
    public class SaveCardResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
    }
}