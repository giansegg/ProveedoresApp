using ProveedoresApp.Entity;
using ProveedoresApp.Infrastructure.Data;

public interface IJwtService
{
    string GenerateToken(User user);
}

