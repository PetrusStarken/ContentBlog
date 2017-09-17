namespace BusinessServices
{
    using System.Collections.Generic;
    using BusinessEntities;
    using DataModel.UnitOfWork;
    using DataModel;
    using System.Transactions;
    using System.Linq;

    public class ArticleCategoryServices : MapperConfiguration<DataModel.ArticleCategory, ArticleCategoryEntity>, IArticleCategoryServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ArticleCategoryServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(ArticleCategoryEntity articleCategoryEntity)
        {
            using (var scope = new TransactionScope())
            {
                var articleCategory = new ArticleCategory()
                {
                    Description = articleCategoryEntity.Description,
                    Title = articleCategoryEntity.Title
                };

                _unitOfWork.ArticleCategoryRepository.Insert(articleCategory);
                _unitOfWork.Save();
                scope.Complete();

                return articleCategory.Id;
            }
        }

        public bool Delete(int id)
        {
            if (id == 0)
                return false;

            using (var scope = new TransactionScope())
            {
                var articleCategory = _unitOfWork.ArticleCategoryRepository.GetByID(id);

                if (articleCategory == null)
                    return false;

                _unitOfWork.ArticleCategoryRepository.Delete(articleCategory);
                _unitOfWork.Save();
                scope.Complete();

                return true;
            }
        }

        public bool Edit(int postId, ArticleCategoryEntity articleCategoryEntity)
        {
            if (articleCategoryEntity == null)
                return false;

            using (var scope = new TransactionScope())
            {
                var articleCategory = _unitOfWork.ArticleCategoryRepository.GetByID(postId);

                if (articleCategoryEntity == null)
                    return false;

                articleCategory.Title = articleCategoryEntity.Title;
                articleCategory.Description = articleCategoryEntity.Description;

                _unitOfWork.ArticleCategoryRepository.Update(articleCategory);
                _unitOfWork.Save();
                scope.Complete();

                return true;
            }
        }

        public ArticleCategoryEntity Get(int articleCategoryId)
        {
            var articleCategory = _unitOfWork.ArticleCategoryRepository.GetByID(articleCategoryId);

            if (articleCategory == null)
                return null;

            var articleCategoryModel = _mapper.Map<ArticleCategory, ArticleCategoryEntity>(articleCategory);
            return articleCategoryModel;
        }

        public IEnumerable<ArticleCategoryEntity> GetAll()
        {
            var postCategories = _unitOfWork.ArticleCategoryRepository.GetAll().ToList();

            if (!postCategories.Any())
                return null;

            var postCategoriesModel = _mapper.Map<List<ArticleCategory>, List<ArticleCategoryEntity>>(postCategories);
            return postCategoriesModel;
        }
    }
}
