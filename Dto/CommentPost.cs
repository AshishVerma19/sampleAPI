using System;
using System.ComponentModel.DataAnnotations;

namespace sampleAPI.Dto;

public class CommentPost
{
    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 character")]
    [MaxLength(280, ErrorMessage = "Title can not be over 280 characters")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(5, ErrorMessage = "Content must be 5 character")]
    [MaxLength(280, ErrorMessage = "Content can not be over 280 characters")]
    public string Content { get; set; } = string.Empty;
}
