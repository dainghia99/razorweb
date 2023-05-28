using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.AppDbContext;
using razorweb.Models;

namespace razorweb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly razorweb.AppDbContext.BlogContext _context;

        public IndexModel(razorweb.AppDbContext.BlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public const int ITEM_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int curentPageSize { get; set; } = default;

        public int countPageSize { get; set; } = default;

        public async Task OnGetAsync(string searchString)
        {
            if (_context.Articles != null)
            {
                // Article = await _context.Articles.ToListAsync();

                // var qr = from a in _context.Articles
                //         orderby a.PublishDate descending
                //          select a;


                int toltal = await _context.Articles.CountAsync();

                countPageSize = (int)Math.Ceiling((double) toltal / ITEM_PER_PAGE);

                if (curentPageSize < 1) 
                    curentPageSize = 1;
                if (curentPageSize < countPageSize) 
                    curentPageSize = countPageSize;

                if(!string.IsNullOrEmpty(searchString)) {
                   Article = await _context.Articles.Where(x => x.Title.Contains(searchString)).ToListAsync();
                } else {
                    Article = await _context.Articles.ToListAsync();
                }
            }
        }
    }
}
