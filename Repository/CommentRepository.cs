using System;
using Microsoft.EntityFrameworkCore;
using sampleAPI.Data;
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

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }
}
