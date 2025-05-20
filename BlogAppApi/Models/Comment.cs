using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        //Foreign key
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
