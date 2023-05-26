using System;
using System.Collections.Generic;

namespace razorweb.Models;

public partial class Article
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? ContentArticle { get; set; }
}
