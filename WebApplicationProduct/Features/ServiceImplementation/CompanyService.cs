
using AutoMapper;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;
using WebApplicationProduct.Features.DomainModels;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewMapper;

namespace WebApplicationProduct.Features.ServiceImplementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(CompanyRequest request)
        {
            try
            {
                Company company = new()
                {
                    Name = request.Name
                };

                company.AddBranch(request.BranchName);

                await _companyRepository.Add(company);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        public async Task<GetCompanyResponse> GetBy(int id)
        {
            GetCompanyResponse response = new GetCompanyResponse();
            Company company = await _companyRepository.GetBy(id);

            response.Company = company.ConvertToCompanyView(_mapper);

            return response;
        }
    }
}
