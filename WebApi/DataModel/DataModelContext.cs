﻿namespace DataModel
{
    using System.Data.Entity;

    public class DataModelContext : DbContext
    {
        public DataModelContext() : base("name=ContentBlog") { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
    }
}
