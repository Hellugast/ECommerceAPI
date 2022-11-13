using ECommerceAPI.Application.RequestParameters;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryRequest : Pagination, IRequest<GetRolesQueryResponse>
    {
    }
}