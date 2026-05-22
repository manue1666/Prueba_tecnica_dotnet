using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers;

public class PostController : Controller
{
    private readonly PostService _postService;
    
    public PostController(PostService postService)
    {
        _postService = postService;
    }

    // show all posts
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var posts = await _postService.GetAllPosts();
        return View(posts);
    }

    // show details of a specific post
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // show form to create a new post
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // create a new post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Post post)
    {
        // return the view with validation errors if the model is not valid
        if (!ModelState.IsValid)
        {
            return View(post);
        }

        var createdPost = await _postService.CreatePost(post);
        if (createdPost == null)
        {
            ModelState.AddModelError("", "Error at creating the post");
            return View(post);
        }
        
        TempData["SuccessMessage"] = "Post created successfully";
        return RedirectToAction(nameof(Index));
    }

    // show form to edit a post
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // edit a post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Post post)
    {
        // validate if id and post id match
        if (id != post.Id)
        {
            return BadRequest();
        }


        if (!ModelState.IsValid)
        {
            return View(post);
        }

        var updatedPost = await _postService.UpdatePost(id, post);
        if (updatedPost == null)
        {
            ModelState.AddModelError("", "Error at updating the post");
            return View(post);
        }

        TempData["SuccessMessage"] = "Post updated successfully";
        return RedirectToAction(nameof(Index));
    }

    // show confirmation page to delete a post
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // delete a post
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }

        var result = await _postService.DeletePost(id);
        if (result == false)
        {
            ModelState.AddModelError("", "Error at deleting the post");
            return View(post);
        }

        TempData["SuccessMessage"] = "Post deleted successfully";
        return RedirectToAction(nameof(Index));
    }
}