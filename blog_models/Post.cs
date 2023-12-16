using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
