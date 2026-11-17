namespace JsonPlaceholderApi.Dtos;

public class CommentDto
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string AuthorName { get; set; } = string.Empty;

    public string AuthorEmail { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
