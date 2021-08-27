using Lyre.Repository.Common;
using Autofac;

namespace Lyre.Repository 
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
