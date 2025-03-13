using AutoMapper;
using MediatR;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;
using WebApplicationProduct.Features.DomainModels;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewMapper;

namespace WebApplicationProduct.Features.CQRS
{
    public class GetCompanyHandler : IRequestHandler<GetCompanyQuery, GetCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private IMapper _mapper;
        public GetCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<GetCompanyResponse> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            Company company = await _companyRepository.GetBy(request.id, c => c.Branches);
            return new GetCompanyResponse { Company = company.ConvertToCompanyView(_mapper)};
        }
    }
}
