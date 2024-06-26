using AutoMapper;
using Bookify.Web.Core.Models;
using Bookify.Web.Core.ViewModels;

namespace Bookify.Web.Helper.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryView>().ReverseMap();


            CreateMap<Author, AuthorView>().ReverseMap();
            CreateMap<AuthorViewModel, Author>().ReverseMap();
        }

    }
}
