using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_LinkManager.Entities;
using WebApi_LinkManager.Services;

namespace WebApi_LinkManager.Controllers
{
    public class LinksController : ApiController
    {
        private IService service;

        public LinksController()
        {
            service = new Service();
        }
        // GET: /api/links
        public IEnumerable<Link> GetAllLinks()
        {
            return service.GetAllLinks();
        }
        // GET: api/links/3
        public Link GetById(int id)
        {
            return service.GetById(id);
        }
        // POST: api/links
        // Input example: { "Title": "Products", "URL": "http://pr.com", "Cathegory": "Electronics"}
        public HttpResponseMessage PostLinkToDB([FromBody]Link link)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                try
                {
                    var addedLink = service.AddLink(link);

                    response = Request.CreateResponse(
                            HttpStatusCode.Created, addedLink);

                    string uri = Url.Link("DefaultApi", new { id = addedLink.LinkID });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message, ex);
                    response = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return PrepareResponse(HttpStatusCode.OK, "Successfully added");
        }

        [NonAction]
        public virtual HttpResponseMessage PrepareResponse(HttpStatusCode statusCode, string value)
        {
            return Request.CreateResponse(statusCode, value);
        }

        // DELETE: api/links/5
        public HttpResponseMessage Delete(int id)
        {
            Link link = service.GetById(id);

            if (link == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                service.DeleteById(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, link);
        }

        // PUT: api/links/ChangeCategory/1
        // Input example: "Furniture" 
        [HttpPut]
        [Route("api/links/ChangeCategory/{id}")]
        public HttpResponseMessage ChangeCategory(int id, [FromBody]string newCategory)
        {
            Link link = service.GetById(id);

            if(link == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                link.Category = newCategory;
                service.Edit(link);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, link);
        }

        // PUT: api/links/ChangeTitle/1
        // Input example: "RedirectToHome" 
        [HttpPut]
        [Route("api/links/ChangeTitle/{id}")]
        public HttpResponseMessage ChangeTitle(int id, [FromBody]string newTitle)
        {
            Link link = service.GetById(id);

            if (link == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                link.Title = newTitle;
                service.Edit(link);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, link);
        }

        // GET: api/links/LinksByCategory/Page
        [Route("api/links/LinksByCategory/{category}")]
        public IEnumerable<Link> GetLinksByCategory(string category)
        {
            var links = service.FindByCategory(category);
            return links;
        }
    }
}
