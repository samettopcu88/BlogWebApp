using AutoMapper;
using ENTITY.Entities;
using ENTITY.Models.Users;

namespace SERVICE.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserModel>().ReverseMap();
            CreateMap<AppUser, UserAddModel>().ReverseMap();
            CreateMap<AppUser, UserUpdateModel>().ReverseMap();
            CreateMap<AppUser, UserProfileModel>().ReverseMap();

        }
    }
}
