using Newser.Domain.Entities;

namespace Newser.Application.Common.Authorization;

public interface IJwtTokenGenerator
{
    string TokenGenerate(User user);
}