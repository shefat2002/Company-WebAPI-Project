using Azure.Core;
using MediatR;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;
using WebApplicationProduct.Features.DomainModels;

namespace WebApplicationProduct.Features.CQRS
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand,int>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        //public CreateCompanyHandler() { }

        public CreateCompanyHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = new() { Name = request.Name };
            foreach (var branchName in request.BranchNames)
            {
                company.AddBranch(branchName);
            }
            await _companyRepository.Add(company);
            await _unitOfWork.SaveAsync();
            return company.Id;
        }
    }
}
