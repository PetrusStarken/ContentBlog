namespace WebApi.Controllers
{
    using BusinessEntities;
    using BusinessServices;
    using System.Net.Http;
    using System.Web.Http;
    using System.Linq;
    using System.Net;
    using WebApi.ActionFilters;
    using System.Collections.Generic;
    using System.Web.Http.OData;

    public class ArticleController : ApiController
    {
        public readonly IArticleServices _articleServices;

        public ArticleController(IArticleServices articleService)
        {
            _articleServices = articleService;
        }

        // GET: api/Post
        [EnableQueryAttribute]
        public HttpResponseMessage Get()
        {
            var articles = _articleServices.GetAll();
            var articlesEntities = articles as List<ArticleEntity> ?? articles.ToList();

            if (articlesEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, articlesEntities.AsQueryable());

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nenhum post encontrado.");
        }

        // GET: api/Post/5
        public HttpResponseMessage Get(int id)
        {
            var post = _articleServices.Get(id);

            if (post == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Post não encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        public HttpResponseMessage Get(string urlTitle)
        {
            var post = _articleServices.GetByTitle(urlTitle);

            if (post == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Post não encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        // POST: api/Post
        [AuthorizationRequired]
        public int Post([FromBody]ArticleEntity article)
        {
            return _articleServices.Add(article);
        }

        // PUT: api/Post/5
        [AuthorizationRequired]
        public bool Put(int id, [FromBody]ArticleEntity article)
        {
            if (id == 0)
                return false;

            return _articleServices.Edit(id, article);
        }

        // DELETE: api/Post/5
        [AuthorizationRequired]
        public bool Delete(int id)
        {
            if (id == 0)
                return false;

            return _articleServices.Delete(id);
        }
    }
}
