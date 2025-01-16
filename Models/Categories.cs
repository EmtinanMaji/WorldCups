using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Categories Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Categories Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Categories Icon")] 
        public string Icon { get; set; }
        [Required(ErrorMessage = "Please Enter Categories URL")] 
        public string Url { get; set; }

    }
}
