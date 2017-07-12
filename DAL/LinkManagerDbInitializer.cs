using System.Data.Entity;
using System.Data.Entity.Migrations;
using WebApi_LinkManager.Entities;

namespace WebApi_LinkManager.DAL
{
    public class LinkManagerDbInitializer : DropCreateDatabaseAlways<LinkContext>
    {
        public LinkManagerDbInitializer()
        {
        }

        protected override void Seed(LinkContext context)
        {
            context.Links.AddOrUpdate(
                new Link() { Title = "Products", Category = "Redirect", URL = "https://google.com" },
                new Link() { Title = "Home", Category = "Page", URL = "https://magazine.com/home"},
                new Link() { Title = "Index", Category = "Page", URL = "https://magazine.com/home" }
            );
            base.Seed(context);
        }
    }
}
