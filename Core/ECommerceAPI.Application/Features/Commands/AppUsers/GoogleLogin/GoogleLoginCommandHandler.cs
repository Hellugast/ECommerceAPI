using ECommerceAPI.Application.Abstractions.Services.Authentications;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AppUsers.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IAuthExternal _authService;

        public GoogleLoginCommandHandler(IAuthExternal authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleLoginAsync(request.IdToken, 120);
            return new()
            {
                Token = token,
            };

        }
    }
}
