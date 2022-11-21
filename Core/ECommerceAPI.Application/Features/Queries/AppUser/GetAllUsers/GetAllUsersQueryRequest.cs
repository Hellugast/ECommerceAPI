using ECommerceAPI.Application.RequestParameters;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUsersQueryRequest : Pagination, IRequest<GetAllUsersQueryResponse>
    {
    }
}