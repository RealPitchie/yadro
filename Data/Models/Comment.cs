namespace yadro.Data.Models;
#nullable disable
public class Comment
{
    public string Id { get; set; }
    public string Author { get; set; }
    public DateTime Posted { get; set; }
    public string Text { get; set; }
    public string Image { get; set; }
}
