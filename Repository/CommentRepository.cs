using System;
using Microsoft.EntityFrameworkCore;
using sampleAPI.Data;
using sampleAPI.Dto;
using sampleAPI.interfaces;
using sampleAPI.Models;

namespace sampleAPI.Repository;

public class CommentRepository : ICommentRepository
{
    public readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Comment?> UpdateCommentAsync(int id, CommentPost commentModal)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }
        comment.Title = commentModal.Title;
        comment.Content = commentModal.Content;

        await _context.SaveChangesAsync();
        return comment;
    }
}
