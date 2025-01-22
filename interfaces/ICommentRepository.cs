using System;
using sampleAPI.Dto;
using sampleAPI.Models;

namespace sampleAPI.interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment?> UpdateCommentAsync(int id, CommentPost comment);
    Task<Comment?> DeleteAsync(int id);
}
