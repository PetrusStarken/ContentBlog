namespace DataModel.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Data.Entity.Validation;
    using DataModel.GenericRepository;

    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DataModelContext _context = null;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Token> _tokenRepository;
        private GenericRepository<Lead> _leadRepository;
        private GenericRepository<Article> _articleRepository;
        private GenericRepository<ArticleCategory> _articleCategoryRepository;

        public UnitOfWork()
        {
            _context = new DataModelContext();
        }

        #region Public Repository Creation properties...

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<Token>(_context);
                return _tokenRepository;
            }
        }

        public GenericRepository<Lead> LeadRepository
        {
            get
            {
                if (this._leadRepository == null)
                    this._leadRepository = new GenericRepository<Lead>(_context);
                return _leadRepository;
            }
        }

        public GenericRepository<Article> ArticleRepository
        {
            get
            {
                if (this._articleRepository == null)
                    this._articleRepository = new GenericRepository<Article>(_context);
                return _articleRepository;
            }
        }

        public GenericRepository<ArticleCategory> ArticleCategoryRepository
        {
            get
            {
                if (this._articleCategoryRepository == null)
                    this._articleCategoryRepository = new GenericRepository<ArticleCategory>(_context);
                return _articleCategoryRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        private bool disposed = false;

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}