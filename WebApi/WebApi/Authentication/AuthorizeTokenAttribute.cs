using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Authentication
{
    /// <summary>
    /// The authorization policy for token-based authentication
    public class AuthorizeTokenAttribute : AuthorizeAttribute
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AuthorizeTokenAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
            
        #endregion
    }
}
