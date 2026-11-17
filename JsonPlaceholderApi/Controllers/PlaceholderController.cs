using System.Net.Http.Json;
using System.Text.Json;
using JsonPlaceholderApi.Dtos;
using JsonPlaceholderApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JsonPlaceholderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaceholderController : ControllerBase
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [HttpGet("posts")]
    [ProducesResponseType(typeof(IEnumerable<PostDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
    {
        var handler = new HttpClientHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
            Timeout = TimeSpan.FromMinutes(5)
        };

        var response = await client.GetAsync("posts");
        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode);
        }

        var posts = await response.Content.ReadFromJsonAsync<List<PostItem>>(JsonOptions) ?? [];
        var result = new List<PostDto>();
        foreach (var post in posts)
        {
            result.Add(new PostDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Title = post.Title,
                Content = post.Body
            });
        }

        return Ok(result);
    }

    [HttpGet("comments")]
    [ProducesResponseType(typeof(IEnumerable<CommentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
    {
        var handler = new HttpClientHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
            Timeout = TimeSpan.FromMinutes(5)
        };

        var response = await client.GetAsync("comments");
        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode);
        }

        var comments = await response.Content.ReadFromJsonAsync<List<CommentItem>>(JsonOptions) ?? [];
        var result = new List<CommentDto>();
        foreach (var comment in comments)
        {
            result.Add(new CommentDto
            {
                Id = comment.Id,
                PostId = comment.PostId,
                AuthorName = comment.Name,
                AuthorEmail = comment.Email,
                Content = comment.Body
            });
        }

        return Ok(result);
    }

    [HttpGet("albums")]
    [ProducesResponseType(typeof(IEnumerable<AlbumDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAlbums()
    {
        var handler = new HttpClientHandler();
        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
            Timeout = TimeSpan.FromMinutes(5)
        };

        var response = await client.GetAsync("albums");
        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode);
        }

        var albums = await response.Content.ReadFromJsonAsync<List<AlbumItem>>(JsonOptions) ?? [];
        var result = new List<AlbumDto>();
        foreach (var album in albums)
        {
            result.Add(new AlbumDto
            {
                Id = album.Id,
                UserId = album.UserId,
                Title = album.Title
            });
        }

        return Ok(result);
    }
}
