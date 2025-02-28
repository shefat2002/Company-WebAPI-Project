using WebApplicationProduct.Features.DomainModels;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewModel;

namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging
{
    public class UpdateCompanyRequest
    {
        public string Name { get; set; }
        public List<BranchView> Branches { get; set; }
        
    }
}
