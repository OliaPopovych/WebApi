using System.Collections.Generic;
using WebApi_LinkManager.Entities;

namespace WebApi_LinkManager.Services
{
    public interface IService
    {
        IEnumerable<Link> GetAllLinks();
        Link GetById(int id);
        Link AddLink(Link link);
        void DeleteById(int id);
        void Edit(Link link);
        IEnumerable<Link> FindByCategory(string category);
    }
}
