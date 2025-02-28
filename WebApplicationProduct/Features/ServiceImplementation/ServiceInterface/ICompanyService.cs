using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging;

namespace WebApplicationProduct.Features.ServiceImplementation.ServiceInterface
{
    public interface ICompanyService
    {
        Task Add(CompanyRequest request);
        Task<GetCompanyResponse> GetBy(int id);
        Task Update(UpdateBranchRequest request, int id);
        //Task Update(UpdateCompanyRequest request, int id);
        Task Delete(int id);

    }


}
