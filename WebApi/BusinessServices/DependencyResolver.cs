namespace BusinessServices
{
    using Resolver;
    using System.ComponentModel.Composition;

    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<ILeadServices, LeadServices>();
            registerComponent.RegisterType<IArticleServices, ArticleServices>();
            registerComponent.RegisterType<IArticleCategoryServices, ArticleCategoryServices>();
        }
    }
}