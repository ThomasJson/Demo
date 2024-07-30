using Microsoft.AspNetCore.Components.Authorization;
using Template.Infrastructure.Storage;
using Template.Infrastructure.Services.Authentication;

namespace Template.Infrastructure.EventHandlers
{
    public static class SessionHandler
    {
        public static AccountSession GetAccountSession(int id, string UserName, string RoleName)
        {
            
            return new AccountSession
            {
                Id = id,
                UserName = UserName,
                Role = RoleName
            };
            
        }

    }
}