namespace JsonPlaceholderApi.Models;

public class PostItem
{
    public int UserId { get; set; }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;
}
