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
        private readonly IBranchRepository _branchRepository;

        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMapper mapper, IBranchRepository branchRepository)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _branchRepository = branchRepository;
        }

        public async Task Add(CompanyRequest request)
        {
            try
            {
                Company company = new()
                {
                    Name = request.Name
                };
                foreach(var branchName in request.Branches)
                {
                    company.AddBranch(branchName);
                }
                
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
            Company company = await _companyRepository.GetBy(id, c=> c.Branches);
            response.Company = company.ConvertToCompanyView(_mapper);

            return response;
        }

        public async Task Update(UpdateBranchRequest request, int id)
        {
            Company company = await _companyRepository.GetBy(id, c => c.Branches);
            company.Name = request.Name;
            Branch branch = company.Branches.FirstOrDefault(b => b.Id == request.branchId);
            if (branch == null)
            {
                throw new Exception("Branch not found");
            }
            branch.Name = request.branchName; 

            await _companyRepository.Update(company);
            await _unitOfWork.SaveAsync();

        }
        public async Task Delete(int id)
        {
            Company company = await _companyRepository.GetBy(id);
            await _companyRepository.Delete(company);
            await _unitOfWork.SaveAsync();
        }
    }
}
