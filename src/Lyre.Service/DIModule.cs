using Lyre.Service.Common;
using Autofac;

namespace Lyre.Service 
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<ArtistService>().As<IArtistService>();
        }
    }
}
