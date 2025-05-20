namespace BlogAppApi.Dtos.AuthorDto
{
    public class readAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Navigation property to BlogPosts
        //public ICollection<BlogPostDto> BlogPosts { get; set; } = new List<BlogPostDto>();
    }
}
