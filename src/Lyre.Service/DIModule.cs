using Lyre.Service.Common;
using Autofac;

namespace Lyre.Service 
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlbumService>().As<IAlbumService>();
            builder.RegisterType<SongService>().As<ISongService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<ArtistService>().As<IArtistService>();
            builder.RegisterType<LyricsService>().As<ILyricsService>();
        }
    }
}
