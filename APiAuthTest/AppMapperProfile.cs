
using APiAuthTest.Model.ApplicationClient;
using APiAuthTest.Model.UserModel;
using APiAuthTest.Services.UserService;
using AutoMapper;



namespace APiAuthTest
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            
            CreateMap<GestionCaisseDto,GestionCaisse>()
            .ForMember(Dest => Dest.societe, o => o.Ignore())
            ;
            CreateMap<GestionCaisse, GestionCaisseDto>()
            .ForMember(Dest => Dest.societe, o => o.Ignore())
            ;
        }
    }
}
