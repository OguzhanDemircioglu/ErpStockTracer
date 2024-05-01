using server.Application.Features.Auth.Login;
using server.Domain.Entities;

namespace server.Application.Services;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}