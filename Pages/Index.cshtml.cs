using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorweb.AppDbContext;

namespace razorweb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BlogContext _blogContext;

    public IndexModel(ILogger<IndexModel> logger, BlogContext blogContext)
    {
        _logger = logger;
        _blogContext = blogContext;
    }

    public void OnGet()
    {
        var post = _blogContext.Articles.OrderBy(x => x.Id).ToList();
        ViewData["Post"] = post;
    }
}
