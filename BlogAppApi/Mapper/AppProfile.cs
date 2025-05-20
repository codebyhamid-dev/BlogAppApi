using BlogAppApi.Dtos.AuthorDto;
using BlogAppApi.Models;

namespace BlogAppApi.Mapper
{
    public class AppProfile : AutoMapper.Profile
    {
        public AppProfile()
        {
            CreateMap<Author,readAuthorDto>();
            CreateMap<createAuthorDto, Author>();
            CreateMap<updateAuthorDto, Author>();
        }
    }

}
