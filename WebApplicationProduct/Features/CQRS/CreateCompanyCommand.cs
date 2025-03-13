using MediatR;

namespace WebApplicationProduct.Features.CQRS
{
    public record CreateCompanyCommand(string Name, List<string>BranchNames) : IRequest<int>;
}
