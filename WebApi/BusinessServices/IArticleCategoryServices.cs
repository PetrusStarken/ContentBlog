using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices
{
    public interface IArticleCategoryServices
    {
        int Add(ArticleCategoryEntity postCategoryEntity);
        IEnumerable<ArticleCategoryEntity> GetAll();
        ArticleCategoryEntity Get(int postCategoryId);
        bool Edit(int postId, ArticleCategoryEntity postCategoryEntity);
        bool Delete(int id);
    }
}
