using AutoMapper;
using PresidentialElection.ViewModels;

namespace PresidentialElection.Data.Profiles
{
    public class ElectionProfile : Profile
    {
        public ElectionProfile()
        {
            CreateMap<RegisterViewModel, StoreUser>()
                .ForMember(user => user.UserName, m => m.MapFrom(z => z.Email));
        }
    }
}
