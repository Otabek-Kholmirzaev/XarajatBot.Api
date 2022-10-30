using Microsoft.EntityFrameworkCore;
using XarajatBot.Api.Entities;

namespace XarajatBot.Api.Data;

public class XarajatDbContext : DbContext
{
    public XarajatDbContext(DbContextOptions<XarajatDbContext> options) : base(options) {}
    public DbSet<UserEntity> Users { get; set; }
}