using System;
using sampleAPI.Dto;
using sampleAPI.Models;

namespace sampleAPI.Mapper;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
            StockId = comment.StockId,
            Title = comment.Title,
        };
    }
}
