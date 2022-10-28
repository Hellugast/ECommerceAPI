using ECommerceAPI.Application.RequestParameters;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Order
{
    public class GetAllOrdersQueryRequest : Pagination, IRequest<GetAllOrdersQueryResponse>
    {

    }
}