using System.ComponentModel.DataAnnotations;

namespace Caco.API.Resources
{
    public class SaveColumnResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}