using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace razorweb.Models;

public partial class Article
{
    
     public int Id { get; set; }

    [Required(ErrorMessage = "Phải nhập tiêu đề")]
    [MinLength(5, ErrorMessage = "{0} phải dài từ {2} đến {1}")]
    [Display(Name = "Tiêu đề của bài viết")]
    public string? Title { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? ContentArticle { get; set; }
}
