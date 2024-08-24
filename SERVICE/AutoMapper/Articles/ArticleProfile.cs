using AutoMapper;
using ENTITY.Entities;
using ENTITY.Models.Articles;

namespace SERVICE.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleModel, Article>().ReverseMap();
            CreateMap<ArticleUpdateModel, Article>().ReverseMap();
            CreateMap<ArticleUpdateModel, ArticleModel>().ReverseMap();
            CreateMap<ArticleAddModel, Article>().ReverseMap();
        }
    }
}
