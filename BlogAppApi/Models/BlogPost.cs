using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        //Foreign key
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        //Foreign key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
