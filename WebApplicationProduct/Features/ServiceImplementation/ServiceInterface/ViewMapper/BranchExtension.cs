using AutoMapper;
using WebApplicationProduct.Features.DomainModels;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewModel;

namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewMapper
{
    public static class BranchExtension
    {
        public static BranchView ConvertToCompanyView(this Branch branch, IMapper mapper)
        {
            return mapper.Map<Branch, BranchView>(branch);
        }
    }
}
