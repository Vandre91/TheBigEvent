﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TheBigEvent.Authentification;
using System.IdentityModel.Tokens.Jwt;
using TheBigEvent.Controllers;

namespace TheBigEvent.Services
{
    public class TokenService
    {
        readonly TokenProviderOptions _options;

        public TokenService(IOptions<TokenProviderOptions> options)
        {
            _options = options.Value;
        }

        public Token GenerateToken(string userId, string email)
        {
            var now = DateTime.UtcNow;

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new Claim[]
            {
                new Claim( JwtRegisteredClaimNames.Sub, userId ),
                new Claim( JwtRegisteredClaimNames.Email, email ),
                new Claim( JwtRegisteredClaimNames.Iat, ( ( int )( now - new DateTime( 1970, 1, 1 ) ).TotalSeconds).ToString(), ClaimValueTypes.Integer64 )
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Token(encodedJwt, (int)_options.Expiration.TotalSeconds);
        }
    }
    public class Token
    {
        public Token(string accessToken, int expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; }

        public int ExpiresIn { get; }
    }
}
