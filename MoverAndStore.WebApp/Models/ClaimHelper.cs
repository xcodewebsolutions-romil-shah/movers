using System.Security.Claims;

namespace MoverAndStore.WebApp.Models
{
    public class ClaimHelper : IClaimHelper
    {
        private readonly ClaimsIdentity _claimsIdentity;

        public ClaimHelper(IHttpContextAccessor context)
        {
            _claimsIdentity = context.HttpContext.User?.Identity as ClaimsIdentity;
        }

        public int UserId
        {
            get
            {
                var value = GetClaim(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(value))
                {
                    return int.Parse(value);
                }
                else
                {
                    return 0;
                }
                throw new Exception("Token is invalid");
            }
        }

        public string Name
        {
            get
            {
                var value = GetClaim(ClaimTypes.Name);
                return value;
            }
        }

        public int UserType
        {
            get
            {
                var value = GetClaim("UserType");
                if (!string.IsNullOrEmpty(value)) { return int.Parse(value); } else { return 0; }
            }
        }

        public string Role
        {
            get
            {
                var value = GetClaim(ClaimTypes.Role);
                return value;
            }
        }

        public string Gender
        {
            get
            {
                var value = GetClaim("Gender");
                return value;
            }
        }

        private string GetClaim(string claimType)
        {
            var claim = _claimsIdentity.Claims.FirstOrDefault(f => f.Type == claimType);
            if (claim != null) return claim.Value;

            return string.Empty;
        }

    }
}
