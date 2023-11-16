using Hotels.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Data
{
    // Example Sun W3 Start
    public class ApplicationDbContext: DbContext //: = inheritance
    {
        //ctor = للاختصار لانشاء دالة بناء
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
       
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<RoomDetails> roomDetails { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Invoice> invoices { get; set; }
    }
}
// Example Sun W3 End
