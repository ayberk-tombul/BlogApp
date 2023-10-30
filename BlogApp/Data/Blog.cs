using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data
{

    [Index(nameof(SeoUrl), IsUnique = true)]
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string ImageUrl { get; set; } = null!;


        [MaxLength(250)]
        [Required]
        public string Title { get; set; } = null!;


        [MaxLength(250)]
        [Required]
        public string ShortDescription { get; set; } = null!;


        [Required]
        public string Description { get; set; } = null!;

        [MaxLength(300)]
        [Required]
        public string SeoUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<BlogCategory>? BlogCategories { get; set; }
    }
}
