namespace DataModel
{
    using System.ComponentModel.Composition;
    using DataModel.UnitOfWork;
    using Resolver;

    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}