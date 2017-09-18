namespace BusinessServices
{
    using System;
    using System.Collections.Generic;
    using BusinessEntities;
    using DataModel.UnitOfWork;
    using System.Transactions;
    using DataModel;
    using System.Linq;

    class ArticleServices : MapperConfiguration<DataModel.Article, ArticleEntity>, IArticleServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ArticleServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(ArticleEntity articleEntity)
        {
            using (var scope = new TransactionScope())
            {
                var post = new Article()
                {
                    Author = articleEntity.Author,
                    Content = articleEntity.Content,
                    Date = DateTime.Now,
                    Title = articleEntity.Title
                };

                _unitOfWork.ArticleRepository.Insert(post);
                _unitOfWork.Save();
                scope.Complete();

                return post.Id;
            }
        }

        public IEnumerable<ArticleEntity> GetAll()
        {
            var posts = _unitOfWork.ArticleRepository.GetAll().ToList();

            if (!posts.Any())
                return null;

            var postsModel = _mapper.Map<List<Article>, List<ArticleEntity>>(posts);
            return postsModel;
        }

        public ArticleEntity Get(int articleId)
        {
            var post = _unitOfWork.ArticleRepository.GetByID(articleId);

            if (post == null)
                return null;

            var postModel = _mapper.Map<Article, ArticleEntity>(post);
            return postModel;

        }

        public ArticleEntity GetByTitle(string urlTitle)
        {
            var post = _unitOfWork.ArticleRepository.Get(a => a.UrlTitle == urlTitle);

            if (post == null)
                return null;

            var postModel = _mapper.Map<Article, ArticleEntity>(post);
            return postModel;
        }

        public bool Edit(int postId, ArticleEntity articleEntity)
        {
            if (articleEntity == null)
                return false;

            using (var scope = new TransactionScope())
            {
                var post = _unitOfWork.ArticleRepository.GetByID(postId);

                if (articleEntity == null)
                    return false;

                post.Author = articleEntity.Author;
                post.Content = articleEntity.Content;
                post.Date = articleEntity.Date;
                post.Title = post.Title;

                _unitOfWork.ArticleRepository.Update(post);
                _unitOfWork.Save();
                scope.Complete();

                return true;
            }
        }

        public bool Delete(int articleId)
        {
            if (articleId == 0)
                return false;

            using (var scope = new TransactionScope())
            {
                var post = _unitOfWork.ArticleRepository.GetByID(articleId);

                if (post == null)
                    return false;

                _unitOfWork.ArticleRepository.Delete(post);
                _unitOfWork.Save();
                scope.Complete();

                return true;
            }
        }
    }
}
