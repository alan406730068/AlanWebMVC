using AlanWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace AlanWeb.data
{
    //資料庫內的相關數據
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //若要新增更新數據 add-migration (後面加入更新訊息)

        //在資料庫新增一個資料表  
        public DbSet<Category> Categories { get; set; }

        //創造seedData
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
