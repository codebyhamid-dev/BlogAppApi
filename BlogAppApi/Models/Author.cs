using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        // Navigation property to BlogPosts
        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
