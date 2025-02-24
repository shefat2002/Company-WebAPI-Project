

using AutoMapper;
using WebApplicationProduct.Features.DomainModels;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewModel;

namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewMapper
{
    public class CompanyPrfile:Profile
    {
        public CompanyPrfile()
        {
            CreateMap<Company, CompanyView>();
            CreateMap<Branch, BranchView>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Company.Branches.FirstOrDefault().Name));

        }
        
    }
}
