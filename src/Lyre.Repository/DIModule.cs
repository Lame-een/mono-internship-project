using Lyre.Repository.Common;
using Autofac;

namespace Lyre.Repository 
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
            builder.RegisterType<SongRepository>().As<ISongRepository>();
        }
    }
}
