namespace WebApi.Controllers
{
    using BusinessEntities;
    using BusinessServices;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebApi.ActionFilters;

    [AuthorizationRequired]
    public class ArticleCategoryController : ApiController
    {
        private readonly IArticleCategoryServices _articleCategoryServices;

        public ArticleCategoryController(IArticleCategoryServices articleCategoryServices)
        {
            _articleCategoryServices = articleCategoryServices;
        }

        // GET: api/PostRepository
        public HttpResponseMessage Get()
        {
            var categories = _articleCategoryServices.GetAll();

            if (categories == null || !categories.Any())
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nenhuma categoria encontrada.");

            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        // GET: api/PostRepository/5
        public HttpResponseMessage Get(int id)
        {
            var category = _articleCategoryServices.Get(id);

            if (category == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Categoria não encontrada.");

            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        // POST: api/PostRepository
        public int Post([FromBody]ArticleCategoryEntity articleCategory)
        {
            return _articleCategoryServices.Add(articleCategory);
        }

        // PUT: api/PostRepository/5
        public bool Put(int id, [FromBody]ArticleCategoryEntity articleCategory)
        {
            return _articleCategoryServices.Edit(id, articleCategory);
        }

        // DELETE: api/PostRepository/5
        public bool Delete(int id)
        {
            return _articleCategoryServices.Delete(id);
        }
    }
}
