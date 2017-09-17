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
        private object usuarioEntity;

        public ArticleServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(ArticleEntity postEntity)
        {
            using (var scope = new TransactionScope())
            {
                var post = new Article()
                {
                    Author = postEntity.Author,
                    Content = postEntity.Content,
                    Date = DateTime.Now,
                    Title = postEntity.Title
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

        public ArticleEntity Get(int postId)
        {
            var post = _unitOfWork.ArticleRepository.GetByID(postId);

            if (post == null)
                return null;

            var postModel = _mapper.Map<Article, ArticleEntity>(post);
            return postModel;

        }

        public bool Edit(int postId, ArticleEntity postEntity)
        {
            if (postEntity == null)
                return false;

            using (var scope = new TransactionScope())
            {
                var post = _unitOfWork.ArticleRepository.GetByID(postId);

                if (postEntity == null)
                    return false;

                post.Author = postEntity.Author;
                post.Content = postEntity.Content;
                post.Date = postEntity.Date;
                post.Title = post.Title;

                _unitOfWork.ArticleRepository.Update(post);
                _unitOfWork.Save();
                scope.Complete();

                return true;
            }
        }

        public bool Delete(int postId)
        {
            if (postId == 0)
                return false;

            using (var scope = new TransactionScope())
            {
                var post = _unitOfWork.ArticleRepository.GetByID(postId);

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
