namespace DataModel
{
    using System.Data.Entity;

    public class DataModelContext : DbContext
    {
        public DataModelContext() : base("name=ContentBlog") { }

        public virtual DbSet<Lead> Leads { get; set; }
    }
}
