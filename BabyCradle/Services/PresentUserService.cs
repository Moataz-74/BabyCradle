using Microsoft.AspNetCore.Http;

namespace BabyCradle.Services
{
    public class PresentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext context;

        public PresentUserService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }
        public string GetIdForPresentUser()
        {
            var user = httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? string.Empty;
        }
        public int GetIdForPresentChild()
        {
            
            var userId = GetIdForPresentUser();
            var child = context.Children.Where(c => c.UserId == userId).FirstOrDefault();

            if (child == null)
            {
                return 0;
            }
            return child.Id;
        }

    }
}
