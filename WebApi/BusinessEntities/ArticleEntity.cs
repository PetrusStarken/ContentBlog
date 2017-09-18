namespace BusinessEntities
{
    using System;

    public class ArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public ArticleCategoryEntity Category { get; set; }
        public string Resume { get; set; }
        public string ImageUrl { get; set; }
    }
}
