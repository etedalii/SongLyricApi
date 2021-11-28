using AutoMapper;
using SongLyricEntities;
using SongLyricEntities.DTOs;

namespace _301104393Lu_Etedali_SongLyricApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreWithoutAlbumDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Album, AlbumDto>();
            CreateMap<Artist, ArtistDto>();
            CreateMap<GenreForCreationDto, Genre>();
            CreateMap<GenreForUpdateDto, Genre>();

            CreateMap<Song, SongWithoutIdDto>();
        }
    }
}