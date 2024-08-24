using AutoMapper;
using ENTITY.Entities;
using ENTITY.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<CategoryAddModel, Category>().ReverseMap();
            CreateMap<CategoryUpdateModel, Category>().ReverseMap();
        }
    }
}
