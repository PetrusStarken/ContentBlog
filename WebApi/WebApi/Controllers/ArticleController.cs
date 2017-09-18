namespace WebApi.Controllers
{
    using BusinessEntities;
    using BusinessServices;
    using System.Net.Http;
    using System.Web.Http;
    using System.Linq;
    using System.Net;
    using WebApi.ActionFilters;

    public class ArticleController : ApiController
    {
        public readonly IArticleServices _articleServices;

        public ArticleController(IArticleServices articleService)
        {
            _articleServices = articleService;
        }

        // GET: api/Post
        public HttpResponseMessage Get()
        {
            var posts = _articleServices.GetAll();

            if (posts == null || !posts.Any())
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nenhum post encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, posts);
        }

        // GET: api/Post/5
        public HttpResponseMessage Get(int id)
        {
            var post = _articleServices.Get(id);

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
