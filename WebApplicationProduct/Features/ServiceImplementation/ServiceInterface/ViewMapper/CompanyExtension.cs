using AutoMapper;
using WebApplicationProduct.Features.DomainModels;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewModel;

namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewMapper
{
    public static class CompanyExtension
    {
        public static CompanyView ConvertToCompanyView(this Company company, IMapper mapper)
        {
            return mapper.Map<Company, CompanyView>(company);
        }
        
    }
}
