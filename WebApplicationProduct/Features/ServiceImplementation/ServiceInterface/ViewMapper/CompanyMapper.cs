

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
            CreateMap<Branch, BranchView>();           
        }
    }
}
