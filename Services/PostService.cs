using PruebaTecnica.Models;

namespace PruebaTecnica.Services;

public class PostService
{
    private readonly IHttpClientFactory _factory;
    public PostService (IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        try
        {
            var client = _factory.CreateClient("JSONPlaceholder");
            var res = await client.GetAsync("posts");
            var posts = await res.Content.ReadFromJsonAsync<IEnumerable<Post>>();
            return posts ?? [];
            
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error fetching posts in GetAllPosts method: {ex.Message}");
            return [];
        }

    }

    public async Task<Post?> GetPost(int id)
    {
        try
        {
            var client = _factory.CreateClient("JSONPlaceholder");
            var res = await client.GetAsync($"posts/{id}");
            var post = await res.Content.ReadFromJsonAsync<Post>();
            return post;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching post in GetPost method: {ex.Message}");
            return null;
        }
    }

    public async Task<Post?> CreatePost(Post post)
    {
        try
        {
            var client = _factory.CreateClient("JSONPlaceholder");
            var res = await client.PostAsJsonAsync("posts", post);
            var createdPost = await res.Content.ReadFromJsonAsync<Post>();
            return createdPost;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating post in CreatePost method: {ex.Message}");
            return null;
        }
    }


    public async Task<Post?> UpdatePost(int id, Post post)
    {
        try
        {
            var client = _factory.CreateClient("JSONPlaceholder");
            var res = await client.PutAsJsonAsync($"posts/{id}", post);
            var updatedPost = await res.Content.ReadFromJsonAsync<Post>();
            return updatedPost;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating post in UpdatePost method: {ex.Message}");
            return null;
        }
    }

    public async Task<bool?> DeletePost (int id)
    {
        try
        {
            var client = _factory.CreateClient("JSONPlaceholder");
            var res = await client.DeleteAsync($"posts/{id}");
            return res.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting post in DeletePost method: {ex.Message}");
            return null;
        }
    }

}