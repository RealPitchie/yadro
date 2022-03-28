namespace yadro.Data.Models;
#nullable disable
public class Post
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Text { get; set; }
    public string Image { get; set; }
    public string Video { get; set; }
    public DateTime Posted { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    
}
