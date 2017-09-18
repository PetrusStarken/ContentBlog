namespace BusinessServices
{
    using BusinessEntities;
    using System.Collections.Generic;

    public interface IArticleServices
    {
        int Add(ArticleEntity articleEntity);
        IEnumerable<ArticleEntity> GetAll();
        ArticleEntity Get(int articleId);
        ArticleEntity GetByTitle(string urlTitle);
        bool Edit(int postId, ArticleEntity articleEntity);
        bool Delete(int id);
    }
}
