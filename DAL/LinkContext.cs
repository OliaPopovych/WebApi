using System.Data.Entity;
using WebApi_LinkManager.Entities;

namespace WebApi_LinkManager.DAL
{
    public class LinkContext : DbContext
    {
        public LinkContext() : base("name=LinkDBConnectionString")
        {
            Database.SetInitializer<LinkContext>(new LinkManagerDbInitializer());
        }

        public DbSet<Link> Links { get; set; }
    }
}
