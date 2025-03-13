using MediatR;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging;

namespace WebApplicationProduct.Features.CQRS
{
    public record class GetCompanyQuery(int id): IRequest<GetCompanyResponse>;
}
