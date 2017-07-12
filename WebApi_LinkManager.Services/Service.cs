using DataAccess;
using DataAccess.Abstractions;
using System.Collections.Generic;
using WebApi_LinkManager.Entities;

namespace WebApi_LinkManager.Services
{
    public class Service : IService
    {
        private IBasicCRUD<Link> linkRepository;

        public Service()
        {
            linkRepository = new BasicCRUD<Link>();
        }

        public IEnumerable<Link> GetAllLinks()
        {
            return linkRepository.GetAll();
        }

        public Link GetById(int id)
        {
            return linkRepository.Single(l => l.LinkID == id);
        }

        public Link AddLink(Link link)
        {
            linkRepository.Add(link);
            return link;
        }

        public void DeleteById(int id)
        {
            linkRepository.Delete(l => l.LinkID == id);
        }

        public void Edit(Link link)
        {
            linkRepository.Edit(link);
        }

        public IEnumerable<Link> FindByCategory(string category)
        {
            return linkRepository.Find(l => l.Category == category);
        }
    }
}
