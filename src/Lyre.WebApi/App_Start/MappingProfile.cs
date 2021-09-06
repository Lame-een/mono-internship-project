using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.WebApi.Controllers;
using Lyre.Model;

namespace Lyre.WebApi
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongController.SongREST> ();
            CreateMap<Album, AlbumController.AlbumREST>();
            CreateMap<Genre, GenreController.GenreREST>();
            CreateMap<Artist, ArtistController.ArtistREST>();
            CreateMap<User, UserController.UserREST>();
            CreateMap<SongComposite, SongController.SongCompositeREST>();
        }
    }
}
