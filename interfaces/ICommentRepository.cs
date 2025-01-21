using System;
using sampleAPI.Models;

namespace sampleAPI.interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
}
